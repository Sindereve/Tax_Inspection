using Inspection.Date;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Binding = System.Windows.Data.Binding;


namespace Inspection.PageApp
{
    /// <summary>
    /// Логика взаимодействия для searchIN.xaml
    /// </summary>
    public partial class searchINN : Page
    {
        private DataBase db;

        

        private string typeObj;
        private string peopleINNOb;
        private string companiINNOb;

        private DataTable innTable;
        private DataTable peopleObTable;
        private DataTable companiObTable;

        public searchINN()
        {
            InitializeComponent();
            db = DataBase.GetInstance();
        }

        //изменение данных
        private void updateCheckBox_Click(object sender, RoutedEventArgs e)
        {
            bool res;
            System.Windows.Visibility resVS;
            if (updateCheckBox.IsChecked == true)
            {
                res = true;
                resVS = Visibility.Visible;
            }
            else
            {
                if (typeObj == "Физическое лицо")
                {
                    nameObject.Text = $" {peopleObTable.Rows[0][1]} {peopleObTable.Rows[0][0]} {peopleObTable.Rows[0][2]}";
                    addressBox.Text = peopleObTable.Rows[0][4].ToString();
                    telephonBox.Text = peopleObTable.Rows[0][5].ToString();
                    emailBox.Text = peopleObTable.Rows[0][6].ToString();
                    birthdayPeopleBox.Text = peopleObTable.Rows[0][3].ToString();

                    try
                    {
                        DataTable companiForPeopleTable = db.Request($"SELECT id, name, address, telephone, email" +
                        $"  FROM COMPANI WHERE chief = '{innTable.Rows[0][1].ToString()}'");

                        DataTable innCompaniTable = db.Request($"SELECT inn_value" +
                        $"  FROM INN WHERE unit_ID = '{companiForPeopleTable.Rows[0][0]}' and type_unit = N'Юридическое лицо'");

                        chiefCompaniBox.Text = $"{companiForPeopleTable.Rows[0][1]} (INN:{innCompaniTable.Rows[0][0]})";
                        chiefCompaniBox.Visibility = Visibility.Visible;
                    }
                    catch
                    {
                        chiefCompaniName.Text = "Не является руководителем";
                        chiefCompaniBox.Visibility = Visibility.Collapsed;
                    }
                }
                else if (typeObj == "Юридическое лицо")
                {
                    nameObject.Text = $" {companiObTable.Rows[0][0]}";
                    addressBox.Text = companiObTable.Rows[0][1].ToString();
                    telephonBox.Text = companiObTable.Rows[0][2].ToString();
                    emailBox.Text = companiObTable.Rows[0][3].ToString();

                    //забираем данные о руководителе
                    DataTable peopleForCompaniTable = db.Request($"SELECT name, last_name, middle_name, birthday, address, telephon, email" +
                        $"  FROM PEOPLE WHERE id = '{companiObTable.Rows[0][4]}'");
                    DataTable innPeopleTable = db.Request($"SELECT inn_value" +
                        $"  FROM INN WHERE unit_ID = '{companiObTable.Rows[0][4]}'");
                    peopleINNOb = innPeopleTable.Rows[0][0].ToString();

                    //выводим инфо о руководителе
                    chiefCompaniBox.Text = $"{peopleForCompaniTable.Rows[0][1]} (INN:{peopleINNOb})";
                    chiefCompaniBox.Visibility = Visibility.Visible;
                }
                res = false;
                resVS = Visibility.Collapsed;
            }

            updateButton.Visibility = resVS;

            if (typeObj == "Физическое лицо")  chiefNewCompani.Visibility = Visibility.Collapsed;
            else chiefNewCompani.Visibility = resVS;
            
            telephonBox.IsEnabled = res;
            birthdayPeopleBox.IsEnabled = res;
            emailBox.IsEnabled = res;
            addressBox.IsEnabled = res;

        }

        //поиск обькта
        private void searchOb_Click(object sender, RoutedEventArgs e)
        {
            //проверка на правильность введённых данных
            string check = chekTrueINNValue();
            if (check != "true")
            {
                errorMesAsy(check);
                return;
            }

            resultSearch.Visibility = Visibility.Visible;

            //определяем кто Об физ или юр 
            innTable = db.Request($"SELECT type_unit,unit_id FROM INN WHERE inn_value = '{innValue.Text}'");
            typeObj = innTable.Rows[0][0].ToString();
            string idOb = innTable.Rows[0][1].ToString();

            //разделение для работы с физ/юр лицом
            if (typeObj == "Физическое лицо")
            {
                peopleINNOb = innValue.Text;
                companiINNOb = string.Empty;

                //редактируем окно под об
                chiefCompaniName.Text = "Руководит:";
                birthdayPeople.Visibility = Visibility.Visible;
                chiefNewCompaniText.Text = "ИНН новой компании:";
                


                peopleObTable = db.Request($"SELECT name, last_name, middle_name, birthday, address, telephon, email, id" +
                    $"  FROM PEOPLE WHERE id = '{idOb}'");
                nameObject.Text = $" {peopleObTable.Rows[0][1]} {peopleObTable.Rows[0][0]} {peopleObTable.Rows[0][2]}";
                addressBox.Text = peopleObTable.Rows[0][4].ToString();
                telephonBox.Text = peopleObTable.Rows[0][5].ToString();
                emailBox.Text = peopleObTable.Rows[0][6].ToString();
                birthdayPeopleBox.Text = peopleObTable.Rows[0][3].ToString();

                //проверка на наличие компании
                try
                {
                    DataTable companiForPeopleTable = db.Request($"SELECT id, name, address, telephone, email" +
                    $"  FROM COMPANI WHERE chief = '{idOb}'");

                    DataTable innCompaniTable = db.Request($"SELECT inn_value" +
                    $"  FROM INN WHERE unit_ID = '{companiForPeopleTable.Rows[0][0]}' and type_unit = N'Юридическое лицо'");

                    chiefCompaniBox.Text = $"{companiForPeopleTable.Rows[0][1]} (INN:{innCompaniTable.Rows[0][0]})";
                    chiefCompaniBox.Visibility = Visibility.Visible;
                }
                catch
                {
                    chiefCompaniName.Text = "Не является руководителем";
                    chiefCompaniBox.Visibility = Visibility.Collapsed;
                }

                //находим недвижимость
                DataTable propertyCountTable = db.Request($"SELECT COUNT(address) FROM PROPERTY WHERE inn_owner = {peopleINNOb}");

                if (propertyCountTable.Rows[0][0].ToString() != "0")
                {
                    properyExpander.Visibility = Visibility.Visible;
                    propertyCount.Text = $"Кол: {propertyCountTable.Rows[0][0]}";

                    properyExpander.IsExpanded = true;

                    DataTable propertyTable = db.Request($"SELECT type AS 'Тип', address AS 'Адрес', S AS 'Площадь', price AS 'Стоимость'  FROM PROPERTY WHERE inn_owner = {peopleINNOb}");
                    propertyDataGrid.ItemsSource = propertyTable.DefaultView;
                    propertyDataGrid.Items.Refresh();

                    DataGridColumn column = propertyDataGrid.Columns[3];
                    if (column is DataGridTextColumn textColumn)
                    {
                        Binding binding = textColumn.Binding as Binding;
                        if (binding != null)
                        {
                            binding.StringFormat = "{0:C0}";
                            binding.ConverterCulture = new System.Globalization.CultureInfo("ru-RU");
                        }
                    }
                    properyExpander.IsExpanded = false;
                }
                else
                {
                    properyExpander.Visibility = Visibility.Collapsed;
                }

                //находим транспорт
                DataTable transportCountTable = db.Request($"SELECT COUNT(brand) FROM TRANSPORT WHERE inn_owner = {peopleINNOb}");
                if (transportCountTable.Rows[0][0].ToString() != "0")
                {
                    transportExpander.Visibility = Visibility.Visible;
                    transportCount.Text = $"Кол: {transportCountTable.Rows[0][0]}";

                    transportExpander.IsExpanded = true;

                    DataTable transportTable = db.Request($"SELECT type AS 'Тип', brand AS 'Марка', model AS 'Модель', year_prom AS 'Год выпуска',price AS 'Стоимость'  FROM TRANSPORT WHERE inn_owner = {peopleINNOb}");
                    transportDataGrid.ItemsSource = transportTable.DefaultView;
                    transportDataGrid.Items.Refresh();

                    DataGridColumn column = transportDataGrid.Columns[4];
                    if (column is DataGridTextColumn textColumn)
                    {
                        Binding binding = textColumn.Binding as Binding;
                        if (binding != null)
                        {
                            binding.StringFormat = "{0:C0}";
                            binding.ConverterCulture = new System.Globalization.CultureInfo("ru-RU");
                        }
                    }
                    transportExpander.IsExpanded = false;
                }
                else
                {
                    transportExpander.Visibility = Visibility.Collapsed;
                }
                
                //находим tax
                DataTable taxCountTable = db.Request($"SELECT COUNT(tax_sum) FROM TAX WHERE inn_owner = {peopleINNOb}");
                taxCount.Text = $"Кол. транспорта: {taxCountTable.Rows[0][0]}";

                if (taxCountTable.Rows[0][0].ToString() != "0")
                {
                    taxExpander.Visibility = Visibility.Visible;
                    taxCount.Text = $"Кол: {taxCountTable.Rows[0][0]}";

                    taxExpander.IsExpanded = true;

                    DataTable taxTable = db.Request($"SELECT type AS 'Тип', tax_sum AS 'Cумма', status AS 'Статус', date AS 'Дата' FROM TAX WHERE inn_owner = {peopleINNOb}");
                    taxDataGrid.ItemsSource = taxTable.DefaultView;
                    taxDataGrid.Items.Refresh();

                    DataGridColumn column = taxDataGrid.Columns[1];
                    if (column is DataGridTextColumn textColumn)
                    {
                        Binding binding = textColumn.Binding as Binding;
                        if (binding != null)
                        {
                            binding.StringFormat = "{0:C0}";
                            binding.ConverterCulture = new System.Globalization.CultureInfo("ru-RU");
                        }
                    }

                    DataGridColumn columnn = taxDataGrid.Columns[3];
                    if (columnn is DataGridTextColumn texxtColumn)
                    {
                        texxtColumn.Binding.StringFormat = "dd.MM.yyyy";
                        texxtColumn.Width = new DataGridLength(150);
                    }

                    taxExpander.IsExpanded = false;
                }
                else
                {
                    taxExpander.Visibility = Visibility.Collapsed;
                }

            }
            else if (typeObj == "Юридическое лицо")
            {
                peopleINNOb = string.Empty;
                companiINNOb = innValue.Text;

                //редактируем окно под об
                chiefCompaniName.Text = "Руководитель:";
                birthdayPeople.Visibility = Visibility.Collapsed;
                chiefNewCompaniText.Text = "ИНН нового руководителя:";

                //забираем данные о компании
                companiObTable = db.Request($"SELECT name, address, telephone, email, chief, id" +
                    $"  FROM COMPANI WHERE id = '{idOb}'");
                nameObject.Text = $" {companiObTable.Rows[0][0]}";
                addressBox.Text = companiObTable.Rows[0][1].ToString();
                telephonBox.Text = companiObTable.Rows[0][2].ToString();
                emailBox.Text = companiObTable.Rows[0][3].ToString();

                //забираем данные о руководителе
                DataTable peopleForCompaniTable = db.Request($"SELECT name, last_name, middle_name, birthday, address, telephon, email" +
                    $"  FROM PEOPLE WHERE id = '{companiObTable.Rows[0][4]}'");
                DataTable innPeopleTable = db.Request($"SELECT inn_value" +
                    $"  FROM INN WHERE unit_ID = '{companiObTable.Rows[0][4]}'");
                peopleINNOb = innPeopleTable.Rows[0][0].ToString();

                //выводим инфо о руководителе
                chiefCompaniBox.Text = $"{peopleForCompaniTable.Rows[0][1]} (INN:{peopleINNOb})";
                chiefCompaniBox.Visibility = Visibility.Visible;

                //находим недвижимость
                DataTable propertyCountTable = db.Request($"SELECT COUNT(address) FROM PROPERTY WHERE inn_owner = {companiINNOb}");

                if (propertyCountTable.Rows[0][0].ToString() != "0")
                {
                    properyExpander.Visibility = Visibility.Visible;
                    propertyCount.Text = $"Кол: {propertyCountTable.Rows[0][0]}";

                    properyExpander.IsExpanded = true;

                    DataTable propertyTable = db.Request($"SELECT type AS 'Тип', address AS 'Адрес', S AS 'Площадь', price AS 'Стоимость'  FROM PROPERTY WHERE inn_owner = {companiINNOb}");
                    propertyDataGrid.ItemsSource = propertyTable.DefaultView;
                    propertyDataGrid.Items.Refresh();

                    DataGridColumn column = propertyDataGrid.Columns[3];
                    if (column is DataGridTextColumn textColumn)
                    {
                        Binding binding = textColumn.Binding as Binding;
                        if (binding != null)
                        {
                            binding.StringFormat = "{0:C0}";
                            binding.ConverterCulture = new System.Globalization.CultureInfo("ru-RU");
                        }
                    }
                    properyExpander.IsExpanded = false;
                }
                else
                {
                    properyExpander.Visibility = Visibility.Collapsed;
                }

                //находим транспорта
                DataTable transportCountTable = db.Request($"SELECT COUNT(brand) FROM TRANSPORT WHERE inn_owner = {companiINNOb}");

                if (transportCountTable.Rows[0][0].ToString() != "0")
                {
                    transportExpander.Visibility = Visibility.Visible;
                    transportCount.Text = $"Кол: {transportCountTable.Rows[0][0]}";

                    transportExpander.IsExpanded = true;

                    DataTable transportTable = db.Request($"SELECT type AS 'Тип', brand AS 'Марка', model AS 'Модель', year_prom AS 'Год выпуска',price AS 'Стоимость'  FROM TRANSPORT WHERE inn_owner = {companiINNOb}");
                    transportDataGrid.ItemsSource = transportTable.DefaultView;
                    transportDataGrid.Items.Refresh();

                    DataGridColumn column = transportDataGrid.Columns[4];
                    if (column is DataGridTextColumn textColumn)
                    {
                        Binding binding = textColumn.Binding as Binding;
                        if (binding != null)
                        {
                            binding.StringFormat = "{0:C0}";
                            binding.ConverterCulture = new System.Globalization.CultureInfo("ru-RU");
                        }
                    }
                    transportExpander.IsExpanded = false;
                }
                else
                {
                    transportExpander.Visibility = Visibility.Collapsed;
                }

                //находим tax
                DataTable taxCountTable = db.Request($"SELECT COUNT(tax_sum) FROM TAX WHERE inn_owner = {companiINNOb}");
                taxCount.Text = $"Кол. транспорта: {taxCountTable.Rows[0][0]}";

                if (taxCountTable.Rows[0][0].ToString() != "0")
                {
                    taxExpander.Visibility = Visibility.Visible;
                    taxCount.Text = $"Кол: {taxCountTable.Rows[0][0]}";

                    taxExpander.IsExpanded = true;

                    DataTable taxTable = db.Request($"SELECT type AS 'Тип', tax_sum AS 'Cумма', status AS 'Статус', date AS 'Дата' FROM TAX WHERE inn_owner = {companiINNOb}");
                    taxDataGrid.ItemsSource = taxTable.DefaultView;
                    taxDataGrid.Items.Refresh();

                    DataGridColumn column = taxDataGrid.Columns[1];
                    if (column is DataGridTextColumn textColumn)
                    {
                        Binding binding = textColumn.Binding as Binding;
                        if (binding != null)
                        {
                            binding.StringFormat = "{0:C0}";
                            binding.ConverterCulture = new System.Globalization.CultureInfo("ru-RU");
                        }
                    }

                    DataGridColumn columnn = taxDataGrid.Columns[3];
                    if (columnn is DataGridTextColumn texxtColumn)
                    {
                        texxtColumn.Binding.StringFormat = "dd.MM.yyyy";
                        texxtColumn.Width = new DataGridLength(150);
                    }

                    taxExpander.IsExpanded = false;
                }
                else
                {
                    taxExpander.Visibility = Visibility.Collapsed;
                }

            }
        }

        //проверка на правильность ввода ИНН для поиска
        private string chekTrueINNValue()
        {
            if (innValue.Text.Contains('_'))
            {
                return "Не верно введён ИНН";
            }

            try
            {
                DataTable idValue = db.Request($"SELECT unit_ID FROM INN WHERE inn_value = '{innValue.Text}' ");
                string CompaniID = idValue.Rows[0][0].ToString();
            }
            catch
            {
                return "ИНН не существует";
            }

            return "true";
        }

        //событие при неправильном вводе данных
        private async void errorMesAsy(string info)
        {

            await Task.Run(() =>
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    errorMessage.IsActive = true;
                    errorMessage.Message.Content = info;
                }));

                Thread.Sleep(10000);

                Dispatcher.Invoke((Action)(() =>
                {
                    errorMessage.IsActive = false;
                }));
            });
        }

        //событие при изменении данных
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (typeObj == "Физическое лицо")
            {
                string address = addressBox.Text;
                string telephon = telephonBox.Text;
                string email = emailBox.Text;

                DateTime myDateTime = (DateTime)birthdayPeopleBox.SelectedDate;
                string birthday = myDateTime.ToString("yyyy-MM-dd");

                string[] ArrInto = new string[] { "birthday", "address", "telephon", "email", "id" };
                string[] ArrValue = new string[] { birthday, address, telephon, email, peopleObTable.Rows[0][7].ToString() };
                db.upadateRequest("PEOPLE", 4, ArrInto, ArrValue);

                peopleObTable.Rows[0][3] = myDateTime;
                peopleObTable.Rows[0][4] = address;
                peopleObTable.Rows[0][5] = telephon;
                peopleObTable.Rows[0][6] = email;
                errorMesAsy("Данные успешно изменены");
            }
            else if (typeObj == "Юридическое лицо")
            {
                string address = addressBox.Text;
                string telephon = telephonBox.Text;
                string email = emailBox.Text;

                string newChief = chiefNewCompaniBox.Text.ToString();
                if (newChief.Contains('_'))
                {
                    string[] ArrInto = new string[] { "address", "telephone", "email", "id" };
                    string[] ArrValue = new string[] { address, telephon, email, companiObTable.Rows[0][5].ToString() };
                    db.upadateRequest("COMPANI", 3, ArrInto, ArrValue);
                    errorMesAsy("Данные успешно изменены");

                    companiObTable.Rows[0][1] = address;
                    companiObTable.Rows[0][2] = telephon;
                    companiObTable.Rows[0][3] = email;
                }
                else 
                {
                    try
                    {
                        DataTable dt = db.Request($"SELECT unit_ID FROM INN WHERE inn_value = '{newChief}'");
                        string idChief = dt.Rows[0][0].ToString();

                        string[] ArrInto = new string[] { "address", "telephone", "email", "chief", "id" };
                        string[] ArrValue = new string[] { address, telephon, email, idChief, companiObTable.Rows[0][5].ToString() };
                        db.upadateRequest("COMPANI", 4, ArrInto, ArrValue);

                        companiObTable.Rows[0][1] = address;
                        companiObTable.Rows[0][2] = telephon;
                        companiObTable.Rows[0][3] = email;
                        companiObTable.Rows[0][4] = idChief;

                        //забираем данные о руководителе
                        DataTable peopleForCompaniTable = db.Request($"SELECT name, last_name, middle_name, birthday, address, telephon, email" +
                            $"  FROM PEOPLE WHERE id = '{companiObTable.Rows[0][4]}'");

                        //выводим инфо о руководителе
                        chiefCompaniBox.Text = $"{peopleForCompaniTable.Rows[0][1]} (INN:{newChief})";
                        chiefNewCompaniBox.Text=string.Empty;
                        errorMesAsy("Данные успешно изменены");
                    }
                    catch
                    {
                        errorMesAsy("Не верно введены данные");
                    }
                }
            }
        }
        private void deletOb_Click( object sender, RoutedEventArgs e)
        {
            if (typeObj == "Физическое лицо")
            {
                db.Request($"DELETE FROM INN WHERE inn_value = '{peopleINNOb}'");
            }
            else
            {
                db.Request($"DELETE FROM INN WHERE inn_value = '{companiINNOb}'");
            }

            innValue.Text= string.Empty;
            resultSearch.Visibility = Visibility.Hidden;
            errorMesAsy("Субьект успешно удалён");

        }

    }
}
