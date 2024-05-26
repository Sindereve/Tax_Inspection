using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Web;
using System.IO;

namespace Inspection.Date
{
    public class DataBase
    {
        //Приватное статическое поле для хранения единственного экземпляра класса
        private static DataBase instance;
        //строка с найстройками подключение
        string connectionString;
        //название БД
        string BDName = "Inspection";
        //Обьект подключения
        SqlConnection connection = null;


        public DataBase()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\data\Inspection.mdf;Integrated Security=True";
        }

        // Метод для получения единственного экземпляра класса DataBase
        public static DataBase GetInstance()
        {
            // Создаем экземпляр класса, если он еще не был создан
            if (instance == null)
            {
                instance = new DataBase();
            }
            return instance;
        }

        
        // Подключение к БД
        private void Connect()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        // Отключение от базы данных
        private void Disconnect()
        {
            connection.Close();
            connection.Dispose();
        }


        //принимаем запрос, выводим таблицу
        public DataTable Request(string querystring)
        {
            Connect();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand(querystring, connection);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            Disconnect();
            return table;
        }

        public bool avtoriRequest(string nameTable, string login, string password)
        {
            try
            {
                Connect();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                SqlCommand command = new SqlCommand($"SELECT password,login FROM {nameTable} WHERE login = @Value0  and password = @Value1 ", connection);
                command.Parameters.AddWithValue($"@Value0", login);
                command.Parameters.AddWithValue($"@Value1", password);
                adapter.SelectCommand = command;
                adapter.Fill(table);
                Disconnect();
                if (table.Rows.Count == 1) return true;
                else return false;
            }
            catch
            {
                return false;
            }
        }

        //принимаем запрос, добавлям данные
        public string addRequest(string nameTable,string[] ArrInto, string[] ArrValue)
        {
            string res;
            try
            {
                Connect();
                string querystring = $"INSERT INTO {nameTable} (";
                querystring += $" {ArrInto[0]}";
                // INSERT INTO NameTable (...)
                for (int i = 1; i < ArrInto.Length; i++)
                {
                    querystring += $", {ArrInto[i]} ";
                }

                querystring += ") VALUES (";

                string valAAA = "@Values";
                querystring += $" {valAAA}0";
                for (int i = 1; i < ArrValue.Length; i++)
                {
                    querystring += $",{valAAA}{i}";
                }
                querystring += ")";

                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(querystring, connection);

                // иньекция ?
                for (int i = 0; i < ArrValue.Length; i++)
                {
                    command.Parameters.AddWithValue($"{valAAA}{i}", ArrValue[i]);
                }
                command.ExecuteNonQuery();
                Disconnect();
                res = "Данные успешно добавлены.";
            }

            catch (Exception ex)
            {
                res = "Не удалось добавить данные, проверьте правильность введённых данных.";
            }
            
            return res;
        }



        // обновление данных numValues - сколько новых данных мы вносим
        // если numValues=1, то мы вносим ArrInto[0] и ArrValue[0] для изменения
        public string upadateRequest(string nameTable,int numValues, string[] ArrInto, string[] ArrValue)
        {
            string res;
            try
            {
                Connect();
                string querystring = $"UPDATE {nameTable} SET";
                
                // INSERT INTO NameTable (...)
                for (int i = 0; i < numValues; i++)
                {
                    querystring += $" {ArrInto[i]} ";
                    querystring += " = ";
                    querystring += $"@Values{i} ";
                    if (i+1 < numValues) querystring += ",";
                }

                if (numValues < ArrValue.Length)
                {
                    for (int i = numValues ; i < ArrInto.Length;i++) {
                        querystring += " WHERE ";
                        querystring += $"{ArrInto[i]} ";
                        querystring += " = ";
                        querystring += $"@Values{i} ";
                        if (i + 1 < ArrInto.Length) querystring += "and";
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(querystring, connection);



                // иньекция ?
                for (int i = 0; i < ArrValue.Length; i++)
                {
                    command.Parameters.AddWithValue($"Values{i}", ArrValue[i]);
                }
                command.ExecuteNonQuery();
                Disconnect();
                res = "Данные успешно добавлены.";
            }
            catch (Exception ex)
            {
                res = "Не удалось добавить данные, проверьте правильность введённых данных.";
            }

            return res;
        }
    }

    
    public static class UserWorking
    {
        private static string login = "Null";

        // пример kozlova_tv
        //логин пользователя
        public static string Login { 
            get { return login; }
            set { login = value; }
        }
    }
    

}
