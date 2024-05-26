using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;
using Inspection.Date;
using System.Windows.Data;
using System.Data.Common;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using System.Threading.Tasks;


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
            //включение полосы загрузки
            loadTableBar.Visibility = Visibility.Visible;
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
           

            //формирование запроса
            if (SettingAlternativePeople.IsChecked == true)
            {
                requestConTable = " inner join PEOPLE ON INN.unit_id = PEOPLE.id ";
                requestUnit = "INN.inn_value AS ИНН , PEOPLE.last_name AS Фамилия, PEOPLE.name AS Имя, PEOPLE.middle_name AS Отчество";
                requestWhere = "WHERE INN.type_unit = N'Физическое лицо' ";
                requestOrder = "ORDER BY INN.inn_value";
                requestHaving = "";
                requestGroup = "GROUP BY INN.inn_value, PEOPLE.last_name, PEOPLE.name, PEOPLE.middle_name ";

                if (PeopleBirtsdayEnable.IsChecked == true)
                {
                    requestUnit += ",PEOPLE.birthday AS 'День рождения'";
                    requestGroup += ",PEOPLE.birthday ";
                }

                if (PeopleaddressEnable.IsChecked == true)
                {
                    requestUnit += ", PEOPLE.address AS 'Прописка'";
                    requestGroup += ", PEOPLE.address";
                }

                if (PeopleTelephoneEnable.IsChecked == true)
                {
                    requestUnit += ", PEOPLE.telephon AS 'Номер телефона'";
                    requestGroup += ", PEOPLE.telephon";
                }

                if (PeopleEmailEnable.IsChecked == true)
                {
                    requestUnit += ", PEOPLE.email";
                    requestGroup += ", PEOPLE.email";
                }

                if (PeopleTaxEnable.IsChecked == true)
                {
                    string UpTax = null;
                    string DownTax = null;
                    if (PeopleUpTaxTextBox.Text != "")
                    {
                        decimal.TryParse(PeopleUpTaxTextBox.Text, out decimal valueUp);    
                        UpTax = valueUp.ToString();
                        requestHaving += $" HAVING sum(TAX.tax_sum) > {UpTax} ";
                        if (PeopleDownTaxTextBox.Text != "")
                        {
                            decimal.TryParse(PeopleDownTaxTextBox.Text, out decimal valueDown).ToString();
                            DownTax = valueDown.ToString();
                            requestHaving += $" and sum(TAX.tax_sum) < {DownTax} ";
                        }
                    }
                    else
                    {
                        if (PeopleDownTaxTextBox.Text != "")
                        {
                            decimal.TryParse(PeopleDownTaxTextBox.Text, out decimal valueDown).ToString();
                            DownTax = valueDown.ToString();
                            requestHaving += $"HAVING sum(TAX.tax_sum) < {DownTax} ";
                        }
                    }

                    requestUnit += ", sum(TAX.tax_sum) AS 'Долг'";
                    requestConTable += " LEFT join TAX ON INN.inn_value = TAX.inn_owner ";
                }

                if (PeopleIsСhiefEnable.IsChecked == true)
                {
                    requestUnit += ", COMPANI.name AS 'Название компании'";
                    requestConTable += "inner join COMPANI ON PEOPLE.id = COMPANI.chief ";
                    requestGroup += ", COMPANI.name";
                }
            }
            else if (SettingAlternativeCompani.IsChecked == true)
            {
                requestConTable = " inner join COMPANI ON INN.unit_id = COMPANI.id ";
                requestUnit = "INN.inn_value AS ИНН , COMPANI.name AS Название";
                requestWhere = "WHERE INN.type_unit = N'Юридическое лицо' ";
                requestOrder = "ORDER BY INN.inn_value";
                requestHaving = "";
                requestGroup = "GROUP BY INN.inn_value, COMPANI.name";

                if (CompaniAdresEnable.IsChecked == true)
                {
                    requestUnit += ", COMPANI.address AS 'Адрес'";
                    requestGroup += ", COMPANI.address";
                }
                if (CompaniTelephoneEnable.IsChecked == true)
                {
                    requestUnit += ", COMPANI.telephone AS 'Телефон'";
                    requestGroup += ", COMPANI.telephone";
                }
                if (CompaniEmailEnable.IsChecked == true)
                {
                    requestUnit += ", COMPANI.email AS 'email'";
                    requestGroup += ", COMPANI.email";
                }

                if (CompaniChiefPeopleEnable.IsChecked == true)
                {
                    requestUnit += ", PEOPLE.last_name + ' ' + PEOPLE.name + ' ' + PEOPLE.middle_name AS 'Руководитель'";
                    requestConTable += "inner join PEOPLE ON COMPANI.chief = PEOPLE.id";
                    requestGroup += ", PEOPLE.last_name + ' ' + PEOPLE.name + ' ' + PEOPLE.middle_name";
                }

                if (CompaniTaxEnable.IsChecked == true)
                {
                    string UpTax = null;
                    string DownTax = null;
                    if (CompaniUpTaxTextBox.Text != "")
                    {
                        decimal.TryParse(CompaniUpTaxTextBox.Text, out decimal valueUp);
                        UpTax = valueUp.ToString();
                        requestHaving += $" HAVING sum(TAX.tax_sum) > {UpTax} ";
                        if (CompaniDownTaxTextBox.Text != "")
                        {
                            decimal.TryParse(CompaniDownTaxTextBox.Text, out decimal valueDown);
                            DownTax = valueDown.ToString();
                            requestHaving += $" and sum(TAX.tax_sum) < {DownTax} ";
                        }
                    }
                    else
                    {
                        if (CompaniDownTaxTextBox.Text != "")
                        {
                            decimal.TryParse(CompaniDownTaxTextBox.Text, out decimal valueDown);
                            DownTax = valueDown.ToString();
                            requestHaving += $"HAVING sum(TAX.tax_sum) < {DownTax} ";
                        }
                    }

                    requestUnit += ", sum(TAX.tax_sum) AS 'Долг'";
                    requestConTable += " LEFT join TAX ON INN.inn_value = TAX.inn_owner ";
                }

            }
            else if (SettingAlternativeTransport.IsChecked == true)
            {
                requestTable = " FROM TRANSPORT";
                requestConTable = " inner join INN ON TRANSPORT.inn_owner = INN.inn_value ";
                requestUnit = " TRANSPORT.inn_owner AS 'ИНН владельца' , TRANSPORT.brand + ' ' + TRANSPORT.model  AS 'Модель и марка' ";
                requestOrder = " ORDER BY TRANSPORT.inn_owner ";
                requestHaving = "";
                requestGroup = " GROUP BY TRANSPORT.inn_owner, TRANSPORT.brand + ' ' + TRANSPORT.model";

                if (TransportTypeEnable.IsChecked == true)
                {
                    requestUnit += ", TRANSPORT.type AS 'Тип'";
                    requestGroup += ", TRANSPORT.type";
                }
                if (TransportYearEnable.IsChecked == true)
                {
                    requestUnit += ", TRANSPORT.year_prom AS 'Год выпуска'";
                    requestGroup += ", TRANSPORT.year_prom";
                }

                if (TransportPriceEnable.IsChecked == true)
                {
                    requestUnit += ", TRANSPORT.price AS 'Стоимость'";
                    requestGroup += ", TRANSPORT.price";
                    string UpPrice = null;
                    string DownPrice = null;
                    if (TransportUpPriceTextBox.Text != "")
                    {
                        decimal.TryParse(TransportUpPriceTextBox.Text, out decimal valueUp);
                        UpPrice = valueUp.ToString();
                        requestHaving += $" HAVING sum(TRANSPORT.price) > {UpPrice} ";
                        if (TransportDownPriceTextBox.Text != "")
                        {
                            decimal.TryParse(TransportDownPriceTextBox.Text, out decimal valueDown);
                            DownPrice = valueDown.ToString();
                            requestHaving += $" and sum(TRANSPORT.price) < {DownPrice} ";
                        }
                    }
                    else
                    {
                        if (TransportDownPriceTextBox.Text != "")
                        {
                            decimal.TryParse(TransportDownPriceTextBox.Text, out decimal valueDown);
                            DownPrice = valueDown.ToString();
                            requestHaving += $"HAVING sum(TRANSPORT.price) < {DownPrice} ";
                        }
                    }


                }


            }
            else
            {
                requestTable = "FROM PROPERTY";
                requestConTable = " inner join INN ON PROPERTY.inn_owner = INN.inn_value ";
                requestUnit = " PROPERTY.inn_owner AS 'ИНН владельца' ,PROPERTY.address AS 'Адрес' ";
                requestOrder = " ORDER BY PROPERTY.inn_owner ";
                requestHaving = "";
                requestGroup = " GROUP BY PROPERTY.inn_owner, PROPERTY.address";

                if (PropertyTypeEnable.IsChecked == true)
                {
                    requestUnit += ", PROPERTY.type AS 'Тип'";
                    requestGroup += ", PROPERTY.type";
                }

                if (PropertyPriceEnable.IsChecked == true)
                {
                    requestUnit += ", PROPERTY.price AS 'Стоимость'";
                    requestGroup += ", PROPERTY.price";
                    string UpPrice = null;
                    string DownPrice = null;
                    if (PropertyUpPriceTextBox.Text != "")
                    {
                        
                        decimal.TryParse(PropertyUpPriceTextBox.Text, out decimal valueUp);
                        UpPrice = valueUp.ToString();
                        requestHaving += $" HAVING sum(PROPERTY.price) > {UpPrice} ";

                        if (PropertyDownPriceTextBox.Text != "")
                        {
                            decimal.TryParse(PropertyDownPriceTextBox.Text, out decimal valueDown);
                            DownPrice = valueDown.ToString();
                            requestHaving += $" and sum(PROPERTY.price) < {DownPrice} ";
                        }

                        if (PropertySizeEnable.IsChecked == true)
                        {
                            requestUnit += ", PROPERTY.S AS 'Площадь'";
                            requestGroup += ", PROPERTY.S";
                            if (PropertyUpSizeTextBox.Text != "")
                            {
                                decimal.TryParse(PropertyUpSizeTextBox.Text, out decimal valueSUp);
                                UpPrice = valueSUp.ToString();
                                requestHaving += $" and sum(PROPERTY.S) > {UpPrice} ";
                            }

                            if (PropertyDownSizeTextBox.Text != "")
                            {
                                decimal.TryParse(PropertyDownSizeTextBox.Text, out decimal valueSDown);
                                DownPrice = valueSDown.ToString();
                                requestHaving += $" and sum(PROPERTY.S) < {DownPrice} ";
                            }
                        }
                    }
                    else
                    {
                        if (PropertyDownPriceTextBox.Text != "")
                        {
                            decimal.TryParse(PropertyDownPriceTextBox.Text, out decimal valueDown);
                            DownPrice = valueDown.ToString();
                            requestHaving += $"HAVING sum(PROPERTY.price) < {DownPrice} ";

                            if (PropertySizeEnable.IsChecked == true)
                            {
                                requestUnit += ", PROPERTY.S AS 'Площадь'";
                                requestGroup += ", PROPERTY.S";
                                if (PropertyUpSizeTextBox.Text != "")
                                {
                                    decimal.TryParse(PropertyUpSizeTextBox.Text, out decimal valueSUp);
                                    UpPrice = valueSUp.ToString();
                                    requestHaving += $" and sum(PROPERTY.S) > {UpPrice} ";
                                }

                                if (PropertyDownSizeTextBox.Text != "")
                                {
                                    decimal.TryParse(PropertyDownSizeTextBox.Text, out decimal valueSDown);
                                    DownPrice = valueSDown.ToString();
                                    requestHaving += $" and sum(PROPERTY.S) < {DownPrice} ";
                                }
                            }
                        }
                        else
                        {
                            if (PropertySizeEnable.IsChecked == true)
                            {
                                requestUnit += ", PROPERTY.S AS 'Площадь'";
                                requestGroup += ", PROPERTY.S";
                                string UpS = null;
                                string DownS = null;
                                if (PropertyUpSizeTextBox.Text != "")
                                {
                                    decimal.TryParse(PropertyUpSizeTextBox.Text, out decimal valueSUp);
                                    UpS = valueSUp.ToString();
                                    requestHaving += $" HAVING sum(PROPERTY.S) > {UpS} ";
                                    if (PropertyDownSizeTextBox.Text != "")
                                    {
                                        decimal.TryParse(PropertyDownSizeTextBox.Text, out decimal valueSDown);
                                        DownS = valueSDown.ToString();
                                        requestHaving += $" and sum(PROPERTY.S) < {DownS} ";
                                    }
                                }
                                else
                                {
                                    if (PropertyDownSizeTextBox.Text != "")
                                    {
                                        decimal.TryParse(PropertyDownSizeTextBox.Text, out decimal valueSDown);
                                        DownS = valueSDown.ToString();
                                        requestHaving += $"HAVING sum(PROPERTY.S) < {DownS} ";
                                    }
                                }
                            }
                        }
                    }
                }
                else if (PropertySizeEnable.IsChecked == true)
                {
                    requestUnit += ", PROPERTY.S AS 'Площадь'";
                    requestGroup += ", PROPERTY.S";
                    string UpS = null;
                    string DownS = null;
                    if (PropertyUpSizeTextBox.Text != "")
                    {
                        decimal.TryParse(PropertyUpSizeTextBox.Text, out decimal valueSUp);
                        UpS = valueSUp.ToString();
                        requestHaving += $" HAVING sum(PROPERTY.S) > {UpS} ";
                        if (PropertyDownSizeTextBox.Text != "")
                        {
                            decimal.TryParse(PropertyDownSizeTextBox.Text, out decimal valueSDown);
                            DownS = valueSDown.ToString();
                            requestHaving += $" and sum(PROPERTY.S) < {DownS} ";
                        }
                    }
                    else
                    {
                        if (PropertyDownSizeTextBox.Text != "")
                        {
                            decimal.TryParse(PropertyDownSizeTextBox.Text, out decimal valueSDown);
                            DownS = valueSDown.ToString();
                            requestHaving += $"HAVING sum(PROPERTY.S) < {DownS} ";
                        }
                    }


                }

            }

            DataTable table = db.Request($"SELECT {requestUnit} {requestTable} {requestConTable} {requestWhere} {requestGroup} {requestHaving} {requestOrder}");

            myDataGrid.ItemsSource = table.DefaultView;


            if (SettingAlternativePeople.IsChecked == true)
            {
                int columnCount = myDataGrid.Columns.Count;
                for (int i = 0; i < columnCount; i++)
                {
                    if (myDataGrid.Columns[i].Header.ToString() == "День рождения")
                    {
                        DataGridColumn column = myDataGrid.Columns[i];
                        if (column is DataGridTextColumn textColumn)
                        {
                            // Устанавливаем новый формат отображения данных
                            textColumn.Binding.StringFormat = "dd.MM.yyyy";
                            // Пример изменения ширины столбца
                            textColumn.Width = new DataGridLength(150);
                        }
                    }

                    if (myDataGrid.Columns[i].Header.ToString() == "Долг")
                    {
                        DataGridColumn column = myDataGrid.Columns[i];
                        if (column is DataGridTextColumn textColumn)
                        {
                            // Создаем новый Binding для текущего столбца
                            Binding binding = textColumn.Binding as Binding;
                            if (binding != null)
                            {
                                binding.StringFormat = "{0:C0}";
                                binding.ConverterCulture = new System.Globalization.CultureInfo("ru-RU");
                            }
                        }
                    }
                }
            } 
            else if (SettingAlternativeCompani.IsChecked == true)
            {
                int columnCount = myDataGrid.Columns.Count;
                for (int i = 0; i < columnCount; i++)
                {
                    
                    if (myDataGrid.Columns[i].Header.ToString() == "Долг")
                    {
                        DataGridColumn column = myDataGrid.Columns[i];
                        if (column is DataGridTextColumn textColumn)
                        {
                            // Создаем новый Binding для текущего столбца
                            Binding binding = textColumn.Binding as Binding;
                            if (binding != null)
                            {
                                binding.StringFormat = "{0:C0}";
                                binding.ConverterCulture = new System.Globalization.CultureInfo("ru-RU");
                            }
                        }
                    }
                }
            }
            else if (SettingAlternativeProperty.IsChecked == true)
            {
                int columnCount = myDataGrid.Columns.Count;
                for (int i = 0; i < columnCount; i++)
                {
                    if (myDataGrid.Columns[i].Header.ToString() == "Стоимость")
                    {
                        DataGridColumn column = myDataGrid.Columns[i];
                        if (column is DataGridTextColumn textColumn)
                        {
                            // Создаем новый Binding для текущего столбца
                            Binding binding = textColumn.Binding as Binding;
                            if (binding != null)
                            {
                                binding.StringFormat = "{0:C0}";
                                binding.ConverterCulture = new System.Globalization.CultureInfo("ru-RU");
                            }
                        }
                    }
                }
            }
            else if (SettingAlternativeTransport.IsChecked == true)
            {
                int columnCount = myDataGrid.Columns.Count;
                for (int i = 0; i < columnCount; i++)
                {
                    if (myDataGrid.Columns[i].Header.ToString() == "Стоимость")
                    {
                        DataGridColumn column = myDataGrid.Columns[i];
                        if (column is DataGridTextColumn textColumn)
                        {
                            // Создаем новый Binding для текущего столбца
                            Binding binding = textColumn.Binding as Binding;
                            if (binding != null)
                            {
                                binding.StringFormat = "{0:C0}";
                                binding.ConverterCulture = new System.Globalization.CultureInfo("ru-RU");
                            }
                        }
                    }
                }
            }

            loadTableBarAsy();
        }

        //событие при неправильном вводе данных
        private async void loadTableBarAsy()
        {

            await Task.Run(() =>
            {

                Thread.Sleep(10000);

                Dispatcher.Invoke((Action)(() =>
                {
                    loadTableBar.Visibility = Visibility.Hidden;
                }));
            });
        }

        //логика для переключения поиска Физ.лица/Юр.лица/Недвижимость/Люди
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
