using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

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
            connectionString = $"Server={Environment.MachineName}\\SQLEXPRESS;Database={BDName};Trusted_Connection=True;TrustServerCertificate = True;";
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
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        // Отключение от базы данных
        private void Disconnect()
        {
            connection.Close();
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
