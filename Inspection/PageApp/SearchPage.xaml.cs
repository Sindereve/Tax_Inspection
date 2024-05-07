using System.Data;
using System.Windows;
using System.Windows.Controls;
using Inspection.Date;

namespace Inspection.PageApp
{

    /// <summary>
    /// Логика взаимодействия для SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        private DataBase db; // Поле для хранения экземпляра класса DataBase

        public SearchPage()
        {
            InitializeComponent();
            // Получаем экземпляр класса DataBase
            db = DataBase.GetInstance();
        }

        //ЗАПОЛНЕНИЕ таблицы
        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            //из какой таблицы берём данные
            string requestTable = " FROM INN ";
            //какие данные берём
            string requestUnit = null;
            //присоединённые таблицы
            string requestConTable = null;
            //where таблицы
            string requestWhere = null;
            //сортировка
            string requestOrder = null;
            //группировка
            string requestGroup = null;
            //фильтр по значению
            string requestHaving = null;

            if (SettingAlternativePeople.IsChecked == true)
            {
                requestConTable = " inner join PEOPLE ON INN.unit_id = PEOPLE.id ";
                requestUnit = "INN.inn_value AS ИНН , PEOPLE.last_name AS Фамилия, PEOPLE.name AS Имя, PEOPLE.middle_name AS Отчество";
                requestWhere = "WHERE INN.type_unit = 'Частное лицо' ";
                requestOrder = "ORDER BY PEOPLE.last_name";
                requestHaving = "";
                requestGroup = "GROUP BY INN.inn_value, PEOPLE.last_name, PEOPLE.name, PEOPLE.middle_name ";

                //день рождения
                if (PeopleBirtsdayEnable.IsChecked == true)
                {
                    requestUnit += ",PEOPLE.birtsday AS 'День рождения'";
                    requestGroup += ",PEOPLE.birtsday ";
                }

                //адрес
                if (PeopleaddressEnable.IsChecked == true)
                {
                    requestUnit += ", PEOPLE.address AS 'Прописка'";
                    requestGroup += ", PEOPLE.address";
                }

                //телефон
                if (PeopleTelephoneEnable.IsChecked == true)
                {
                    requestUnit += ", PEOPLE.telephon AS 'Номер телефона'";
                    requestGroup += ", PEOPLE.telephon";
                }
                //email
                if (PeopleEmailEnable.IsChecked == true)
                {
                    requestUnit += ", PEOPLE.email";
                    requestGroup += ", PEOPLE.email";
                }
                //задолжность
                if (PeopleTaxEnable.IsChecked == true)
                {
                    string UpTax = null;
                    string DownTax = null;
                    if (PeopleUpTaxTextBox.Text != "")
                    {
                        UpTax = PeopleUpTaxTextBox.Text;
                        requestHaving += $" HAVING sum(TAX.tax_sum) > {UpTax} ";
                        if (PeopleDownTaxTextBox.Text != "")
                        {
                            DownTax = PeopleDownTaxTextBox.Text;
                            requestHaving += $" and sum(TAX.tax_sum) < {DownTax} ";
                        }
                    }
                    else
                    {
                        if (PeopleDownTaxTextBox.Text != "")
                        {
                            DownTax = PeopleDownTaxTextBox.Text;
                            requestHaving += $"HAVING sum(TAX.tax_sum) < {DownTax} ";
                        }
                    }

                    requestUnit += ", sum(TAX.tax_sum) AS 'Долг'";
                    requestConTable += " LEFT join TAX ON INN.inn_value = TAX.inn_owner ";
                }
                //руководители
                if (PeopleIsСhiefEnable.IsChecked == true)
                {
                    requestUnit += ", COMPANI.name AS 'Название компании'";
                    requestConTable += "inner join COMPANI ON PEOPLE.id = COMPANI.chief ";
                    requestGroup += ", COMPANI.name";
                }
            }
            else if (SettingAlternativeCompani.IsChecked == true) requestTable = "COMPANI";
            else if (SettingAlternativeTransport.IsChecked == true) requestTable = "TRANSPORT";
            else requestTable = "PROPERTY";

            DataTable table = db.Request($"SELECT {requestUnit} {requestTable} {requestConTable} {requestWhere} {requestGroup} {requestHaving} {requestOrder}");
            myDataGrid.ItemsSource = table.DefaultView;
            
            // ВНИМАНИЕ КОСТЫЛЬ !!!!
            
            // ВСЁ
        }

        //лоогика для переключения поиска Физ.лица/Юр.лица/Недвижимость/Люди
        private void SettingAlternative (object sender, RoutedEventArgs e){

            settingSearchCompani.Visibility = Visibility.Collapsed;
            settingSearchPeople.Visibility = Visibility.Collapsed;
            settingSearchProperty.Visibility = Visibility.Collapsed;
            settingSearchTransport.Visibility = Visibility.Collapsed;

            if (SettingAlternativePeople.IsChecked == true){
                settingSearchPeople.Visibility = Visibility.Visible;
            }else if (SettingAlternativeCompani.IsChecked == true){
                settingSearchCompani.Visibility = Visibility.Visible;
            }else if (SettingAlternativeProperty.IsChecked == true){
                settingSearchProperty.Visibility = Visibility.Visible;
            }else{
                settingSearchTransport.Visibility = Visibility.Visible;
            }

        }

        //логика ЛЮДИ включение поиска задолжности "от... до..." 
        private void PeopleTaxEnable_Click(object sender,RoutedEventArgs e){
            if (this.PeopleTaxEnable.IsChecked == true){
                PeopleUpTaxTextBox.IsEnabled = true;
                PeopleDownTaxTextBox.IsEnabled = true;
            }
            else
            {
                PeopleUpTaxTextBox.IsEnabled = false;
                PeopleUpTaxTextBox.Text = string.Empty;
                PeopleDownTaxTextBox.IsEnabled = false;
                PeopleDownTaxTextBox.Text = string.Empty;
            }
        }
        //логика КОМПАНИИ включение поиска задолжности "от... до..." 
        private void CompaniTaxEnable_Click(object sender, RoutedEventArgs e)
        {
            if (this.CompaniTaxEnable.IsChecked == true)
            {
                CompaniUpTaxTextBox.IsEnabled = true;
                CompaniDownTaxTextBox.IsEnabled = true;
            }
            else
            {
                CompaniUpTaxTextBox.IsEnabled = false;
                CompaniUpTaxTextBox.Text= string.Empty;
                CompaniDownTaxTextBox.IsEnabled = false;
                CompaniDownTaxTextBox.Text = string.Empty;
            }
        }
        //логика НЕДВИЖИМОСТЬ(Размер) включение поиска задолжности "от... до..." 
        private void PropertySizeEnable_Click(object sender, RoutedEventArgs e)
        {
            if (this.PropertySizeEnable.IsChecked == true)
            {
                PropertyUpSizeTextBox.IsEnabled = true;
                PropertyDownSizeTextBox.IsEnabled = true;
            }
            else
            {
                PropertyUpSizeTextBox.IsEnabled = false;
                PropertyUpSizeTextBox.Text  = string.Empty;
                PropertyDownSizeTextBox.IsEnabled = false;
                PropertyDownSizeTextBox.Text = string.Empty;
            }
        }
        //логика НЕДВИЖИМОСТЬ(цена) включение поиска задолжности "от... до..." 
        private void PropertyPriceEnable_Click(object sender, RoutedEventArgs e)
        {
            if (this.PropertyPriceEnable.IsChecked == true)
            {
                PropertyUpPriceTextBox.IsEnabled = true;
                PropertyDownPriceTextBox.IsEnabled = true;
            }
            else
            {
                PropertyUpPriceTextBox.IsEnabled = false;
                PropertyUpPriceTextBox.Text = string.Empty;
                PropertyDownPriceTextBox.IsEnabled = false;
                PropertyDownPriceTextBox.Text = string.Empty;
            }
        }
        //логика Транспорт включение поиска задолжности "от... до..." 
        private void TransportPriceEnable_Click(object sender, RoutedEventArgs e)
        {
            if (this.TransportPriceEnable.IsChecked == true)
            {
                TransportUpPriceTextBox.IsEnabled = true;
                TransportDownPriceTextBox.IsEnabled = true;
            }
            else
            {
                TransportUpPriceTextBox.IsEnabled = false;
                TransportUpPriceTextBox.Text = string.Empty;    
                TransportDownPriceTextBox.IsEnabled = false;
                TransportDownPriceTextBox.Text = string.Empty;
            }
        }


    }
}
