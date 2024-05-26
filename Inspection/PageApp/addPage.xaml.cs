using Inspection.Date;
using System;
using System.Data;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Inspection.PageApp
{
    /// <summary>
    /// Логика взаимодействия для addPage.xaml
    /// </summary>
    public partial class addPage:Page
    {
        private DataBase db; // Поле для хранения экземпляра класса DataBase

        public addPage()
        {
            InitializeComponent();
            db = DataBase.GetInstance();
        }



        // изменение видимости (физ лицо)/(руководитель)
        private void innChiefCompaniInPeopleBox_Click(object sender, RoutedEventArgs e){
            if (innChiefCompaniInPeopleBox.IsChecked == true) innChiefCompaniInPeopleMaskfBox.Visibility = Visibility.Visible;
            else innChiefCompaniInPeopleMaskfBox.Visibility = Visibility.Collapsed;
        }

        // изменение видимости (физ лицо)/(уже имеет ИНН)
        private void innPeopleCheсkBox_Click(object sender, RoutedEventArgs e)
        {
            if (innPeopleCheсkBox.IsChecked == true) innPeopleMaskfBox.Visibility = Visibility.Visible;
            else innPeopleMaskfBox.Visibility = Visibility.Collapsed;
        }
        // изменение видимости (юр лицо)/(уже имеет ИНН)
        private void innCompaniCheсkBox_Click(object sender, RoutedEventArgs e)
        {
            if (innCompaniCheсkBox.IsChecked == true) innCompaniMaskfBox.Visibility = Visibility.Visible;
            else innCompaniMaskfBox.Visibility = Visibility.Collapsed;
        }
        
        //настройка правильного ввода года транспорта
        private void yearTransport_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Проверяем, является ли введенный символ цифрой
            if (!char.IsDigit(e.Text, 0))
            {
                // Если символ не является цифрой, отменяем его добавление в текст
                e.Handled = true;
            }
            // Проверяем текущую длину текста в TextBox после добавления нового символа
            string newText = yearTransportBox.Text + e.Text;
            if (newText.Length > 4)
            {
                e.Handled = true; // Блокируем ввод, если количество символов превышает 4
                return;
            }

            // Дополнительно проверяем, чтобы число не превышало текущего года
            int enteredYear;
            if (int.TryParse(newText, out enteredYear))
            {
                int currentYear = DateTime.Now.Year;
                if (enteredYear > currentYear)
                {
                    e.Handled = true; // Блокируем ввод, если введенный год превышает текущий год
                    return;
                }
            }
            else
            {
                e.Handled = true; // Блокируем ввод, если текст не удалось преобразовать в число
                return;
            }


        }



        //сохранение физ.лица
        private void savePeopleButton_Click(object sender, RoutedEventArgs e)
        {
            //изменяем кнопку на инфо об изменении
            updatePeopleStackPanel.Visibility = Visibility.Visible;
            updatePeopleButton.Visibility = Visibility.Collapsed;
            updatePeopleProgressBar.Value = 10;

            string errorChek = checkTrueDataPeople();
            //проверка ввёл-ли пользователь данные
            if ( errorChek != "true")
            {
                errorInfoPeopleShow(errorChek);
                return;
            }

            //обязательные переменные
            string name, last_name, middle_name, address, telephon, email, innValue,
                typeUnit= "Физическое лицо";
            //магия над датой
            DateTime myDateTime = (DateTime)birthdayBox.SelectedDate;
            string birthday = myDateTime.ToString("yyyy-MM-dd");
            
            //забираем введённые данные
            last_name = lastNameBox.Text;
            name = nameBox.Text;
            middle_name = middleNameBox.Text;
            address = addressBox.Text;
            telephon = telephonMaskBox.Text;
            email = emailBox.Text;

            

            //есть ли у человека INN
            if (innPeopleCheсkBox.IsChecked == true)
            {
                if (innPeopleMaskfBox.Text=="____________")
                {
                    errorInfoPeopleShow("Не верно введены данные");
                    return;
                }
                innValue = innPeopleMaskfBox.Text;
            }
            else
            {
                //генерируем уникальный INN
                DataTable tableCount = db.Request($"SELECT count(inn_value) FROM INN");
                DataTable inn = db.Request($"SELECT inn_value FROM INN ORDER BY inn_value");
                int numRow = Convert.ToInt32(tableCount.Rows[0][0]);
                innValue = inn.Rows[numRow - 1][0].ToString();
                innValue = (BigInteger.Parse(innValue) + 1).ToString();
            }

            //обновляем прогресс работы
            updatePeopleProgressBar.Value = 30;

            string[] ArrInto = new string[] { "name", "last_name", "middle_name", "birthday", "address", "telephon", "email"};
            string[] ArrValue = new string[] { name, last_name, middle_name,birthday,address,telephon,email};

            //создаём Row in PEOPLE
            db.addRequest("PEOPLE",ArrInto, ArrValue);

            //узнаём id добавленного человечка и добавляем в inn таблицу
            DataTable idValue = db.Request($"SELECT id FROM PEOPLE WHERE name = N\'{name}\' and last_name = N\'{last_name}\' and " +
                $"middle_name = N\'{middle_name}\' and address = N\'{address}\' and email = N\'{email}\'");
            string unitID = idValue.Rows[0][0].ToString();

            updatePeopleProgressBar.Value = 50;

            //создаём Row in INN
            ArrInto = new string[] {"inn_value","type_unit", "unit_ID"};
            ArrValue = new string[] { innValue,typeUnit,unitID};
            string res = db.addRequest("INN",ArrInto,ArrValue);

            //в табл компании задаём руководителя компании
            if (innChiefCompaniInPeopleBox.IsChecked == true)
            {
                if (innChiefCompaniInPeopleMaskfBox.Text == "____________")
                {
                    errorInfoPeopleShow("Не верно введены данные");
                    return;
                }

                string innCompani = innChiefCompaniInPeopleMaskfBox.Text;

                DataTable idCompValue = db.Request($"SELECT unit_ID FROM INN WHERE inn_value = N'{innCompani}' and type_unit = N'Юридическое лицо'");

                string CompaniID = idCompValue.Rows[0][0].ToString();

                ArrInto = new string[] { "chief", "id" };
                ArrValue = new string[] { unitID, CompaniID };
                db.upadateRequest("COMPANI", 1, ArrInto, ArrValue);



            }

            updatePeopleProgressBar.Value = 100;
            completedDataPeopleAsy();
            //очищаем textBox
            lastNameBox.Text = string.Empty;
            nameBox.Text = string.Empty;
            middleNameBox.Text = string.Empty;
            addressBox.Text = string.Empty;
            telephonMaskBox.Text = string.Empty;
            emailBox.Text = string.Empty;
            innChiefCompaniInPeopleMaskfBox.Text = string.Empty;
            innPeopleMaskfBox.Text = string.Empty;

        }   
        //успешное занесение данных PEOPLE
        private async void completedDataPeopleAsy()
        {
            await Task.Run(() =>
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    //возвращаем кнопку 
                    updatePeopleStackPanel.Visibility = Visibility.Collapsed;
                    errorPeopleStackPanel.Visibility = Visibility.Collapsed;
                    updatePeopleButton.Visibility = Visibility.Visible;
                    completedDataPeopleSnackBar.IsActive = true;
                }));
                Thread.Sleep(5000);
                Dispatcher.Invoke((Action)(() =>
                {
                    completedDataPeopleSnackBar.IsActive = false;
                }));
            });
        }
        //проверка на ошибки ввода PEOPLE
        private string checkTrueDataPeople()
        {
            if (lastNameBox.Text == string.Empty)
            {
                return "Введите фамилию";
            }else if(nameBox.Text == string.Empty)
            {
                return "Введите имя";
            }
            else if (middleNameBox.Text == string.Empty)
            {
                return "Введите отчество";
            }
            else if (birthdayBox.Text == string.Empty)
            {
                return "Введите дату рождения";
            }
            else if (addressBox.Text == string.Empty)
            {
                return "Введите адрес";
            }
            else if (telephonMaskBox.Text == "+7 (___) ___-__-__")
            {
                return "Введите номер телефона";
            }
            else if (emailBox.Text == string.Empty)
            {
                return "Введите email";
            }

            if (telephonMaskBox.Text.Contains('_'))
            {
                return "Проверьте правильность ввода номера телефона";
            }

            DateTime tm = Convert.ToDateTime(birthdayBox.Text.ToString());
            if ( tm > DateTime.Today)
            {
                return "Не верно введена дата !";
            }

            if (emailBox.Text.Contains('@'))
            {
                if (emailBox.Text.Contains('.'))
                {

                }
                else
                {
                    return "Не верно ввеён email";
                }
            }
            else {
                return "Не верно ввеён email";
            }

            

            if (innChiefCompaniInPeopleBox.IsChecked == true)
            {
                if (innChiefCompaniInPeopleMaskfBox.Text == "____________")
                {
                    return "Введите ИНН компании";
                }
                else
                {
                    string innPeople = innChiefCompaniInPeopleMaskfBox.Text;
                    if (innPeople.Contains('_'))
                    {
                        return "Неправильно введён ИНН";
                    }

                    try {
                        string innCompani = innChiefCompaniInPeopleMaskfBox.Text;
                        DataTable idCompValue = db.Request($"SELECT unit_ID FROM INN WHERE inn_value = N'{innCompani}' and type_unit = N'Юридическое лицо'");
                        string CompaniID = idCompValue.Rows[0][0].ToString(); 
                    }
                    catch {
                        return "ИНН компании не существует";
                    }
                }
            }

            if (innPeopleCheсkBox.IsChecked == true)
            {
                if (innPeopleMaskfBox.Text == "____________")
                {
                    return "Введите ИНН физ.лица";
                }
                else
                {
                    try
                    {
                        string innPeople = innPeopleMaskfBox.Text;
                        DataTable idPeoValue = db.Request($"SELECT unit_ID FROM INN WHERE inn_value = N'{innPeople}'");
                        string CompaniID = idPeoValue.Rows[0][0].ToString();
                        return "ИНН занят";
                    }
                    catch
                    {
                        string innPeople = innPeopleMaskfBox.Text;
                        if (innPeople.Contains('_'))
                        {
                            return "Неправильно введён ИНН";
                        }
                    }
                }
            }
            return "true";
        }
        //вывод инфо об ошибке PEOPLE
        private void errorInfoPeopleShow(string info)
        {
            //возвращаем кнопку сохранения
            updatePeopleStackPanel.Visibility = Visibility.Collapsed;
            updatePeopleButton.Visibility = Visibility.Visible;
            //выводим info об ошибке
            errorPeopleStackPanel.Visibility = Visibility.Visible;
            errorPeopleText.Text = info;
            return;
        }


        //сохранение юр.лица
        private void saveCompaniButton_Click(object sender, RoutedEventArgs e)
        {
            //изменяем кнопку на инфо об изменении
            updateCompaniStackPanel.Visibility = Visibility.Visible;
            updateCompaniButton.Visibility = Visibility.Collapsed;
            updateCompaniProgressBar.Value = 10;

            //проверка ввёл-ли пользователь данные
            string errorChek = checkTrueDataCompani();
            if (errorChek != "true")
            {
                errorInfoCompaniShow(errorChek);
                return;
            }

            ////обязательные переменные
            string name, address, telephon, email, inn_chief, innValue, 
                typeUnit = "Юридическое лицо";

            //забираем введённые данные
            name = nameCompaniBox.Text;
            address = addressCompaniBox.Text;
            telephon = telephoneCompaniMaskBox.Text;
            email = emailCompaniBox.Text;
            inn_chief = innChiefCompaniMaskfBox.Text;


            //есть ли у компании INN
            if (innPeopleCheсkBox.IsChecked == true)
            {
                if (innPeopleMaskfBox.Text == "____________")
                {
                    errorInfoCompaniShow("Не верно введены данные");
                    return;
                }
                innValue = innCompaniMaskfBox.Text;
            }
            else
            {
                //генерируем уникальный INN
                DataTable tableCount = db.Request($"SELECT count(inn_value) FROM INN");
                DataTable inn = db.Request($"SELECT inn_value FROM INN ORDER BY inn_value");
                int numRow = Convert.ToInt32(tableCount.Rows[0][0]);
                innValue = inn.Rows[numRow - 1][0].ToString();
                innValue = (BigInteger.Parse(innValue) + 1).ToString();
            }

            //обновляем прогресс работы
            updateCompaniProgressBar.Value = 30;

            //узнаём id руководителя компании
            DataTable idValue = db.Request($"SELECT unit_ID FROM INN WHERE inn_value = N\'{inn_chief}\' and type_unit = N'Физическое лицо'");
            string unitIDchif = idValue.Rows[0][0].ToString();

            string[] ArrInto = new string[] { "name", "address", "telephone", "email", "chief"};
            string[] ArrValue = new string[] { name, address, telephon, email, unitIDchif };
            //создаём Row in COMPANI
            db.addRequest("COMPANI", ArrInto, ArrValue);

            //узнаём id добавленной компании и добавляем в inn таблицу
            idValue = db.Request($"SELECT id FROM COMPANI WHERE name = N\'{name}\' and address = N\'{address}\' and " +
                $"telephone = N\'{telephon}\' and email = N\'{email}\'");
            string unitID = idValue.Rows[0][0].ToString();

            updateCompaniProgressBar.Value = 50;

            //создаём Row in INN
            ArrInto = new string[] { "inn_value", "type_unit", "unit_ID" };
            ArrValue = new string[] { innValue, typeUnit, unitID };
            string res = db.addRequest("INN", ArrInto, ArrValue);

            updateCompaniProgressBar.Value = 100;
            completedDataCompaniAsy();

            //очищаем textBox
            nameCompaniBox.Text = string.Empty;
            addressCompaniBox.Text = string.Empty;
            telephoneCompaniMaskBox.Text = string.Empty;
            emailCompaniBox.Text = string.Empty;
            innChiefCompaniMaskfBox.Text = string.Empty;

        }
        //успешное занесение данных COMPANI
        private async void completedDataCompaniAsy()
        {
            await Task.Run(() =>
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    //возвращаем кнопку и изменяем текст info
                    updateCompaniStackPanel.Visibility = Visibility.Collapsed;
                    errorCompaniStackPanel.Visibility = Visibility.Collapsed;
                    updateCompaniButton.Visibility = Visibility.Visible;
                    completedDataCompaniSnackBar.IsActive = true;
                }));
                Thread.Sleep(5000);
                Dispatcher.Invoke((Action)(() =>
                {
                    completedDataCompaniSnackBar.IsActive = false;
                }));
            });
        }
        //проверка на ошибки ввода COMPANI
        private string checkTrueDataCompani()
        {
            if (nameCompaniBox.Text == string.Empty)
            {
                return "Введите название";
            }
            else if (addressCompaniBox.Text == string.Empty)
            {
                return "Введите адрес";
            }
            else if (telephoneCompaniMaskBox.Text == "+7 (___) ___-__-__")
            {
                return "Введите номер телефона";
            }
            else if (emailCompaniBox.Text == string.Empty)
            {
                return "Введите email";
            }
            else if (innChiefCompaniMaskfBox.Text == "____________")
            {
                return "Введите ИНН руководителя";   
            }

            if (telephoneCompaniMaskBox.Text != "+7 (___) ___-__-__")
            {
                string r = telephoneCompaniMaskBox.Text;
                if (r.Contains('_'))
                {
                    return "Не верно введён номер телефона";
                }
            }

            if (innChiefCompaniMaskfBox.Text != "____________")
            {
                try
                {
                    string innPeople = innChiefCompaniMaskfBox.Text;
                    DataTable idPeopleValue = db.Request($"SELECT unit_ID FROM INN WHERE inn_value = N'{innPeople}' and type_unit = N'Физическое лицо'");
                    string CompaniID = idPeopleValue.Rows[0][0].ToString();
                }
                catch
                {
                    return "ИНН руководителя не существует";
                }
            }

            if (innCompaniCheсkBox.IsChecked == true)
            {
                if (innCompaniMaskfBox.Text == "____________")
                {
                    return "Введите ИНН компании";
                }
                else
                {
                    try
                    {
                        string innCompani = innCompaniMaskfBox.Text;
                        DataTable idCompaniValue = db.Request($"SELECT unit_ID FROM INN WHERE inn_value = N'{innCompani}'");
                        string CompaniID = idCompaniValue.Rows[0][0].ToString();
                        return "ИНН компании занят";
                    }
                    catch
                    {
                        string innCompani = innCompaniMaskfBox.Text;
                        if (innCompani.Contains('_'))
                        {
                            return "Не верно введён ИНН";
                        }
                    }
                }
            }

            return "true";
        }
        //вывод инфо об ошибке COMPANI
        private void errorInfoCompaniShow(string info)
        {
            //возвращаем кнопку сохранения
            updateCompaniStackPanel.Visibility = Visibility.Collapsed;
            updateCompaniButton.Visibility = Visibility.Visible;
            //выводим info об ошибке
            errorCompaniStackPanel.Visibility = Visibility.Visible;
            errorCompaniText.Text = info;
            return;
        }


        //сохранение PROPERTY
        private void savePropertyButton_Click(object sender, RoutedEventArgs e)
        {
            //изменяем кнопку на инфо об изменении
            updatePropertyStackPanel.Visibility = Visibility.Visible;
            updatePropertyButton.Visibility = Visibility.Collapsed;
            updatePropertyProgressBar.Value = 10;

            //проверка ввёл-ли пользователь данные
            string res = checkTrueDataProperty();
            if ( res != "true")
            {
                errorInfoPropertyShow(res);
                return;
            }


            //обязательные переменные
            string INN, address, type, size, price;

            //забираем введённые данные
            INN = innOwnerPropertyMaskBox.Text;
            address = addressPropertyBox.Text;
            type = typePropertyBox.Text;

            decimal.TryParse(sizePropertyBox.Text, out decimal valueSize).ToString();
            size = valueSize.ToString();

            decimal.TryParse(prisePropertyBox.Text, out decimal valuePrice).ToString();
            price = valuePrice.ToString();

            //обновляем прогресс работы
            updatePropertyProgressBar.Value = 60;

            string[] ArrInto = new string[] { "inn_owner", "type", "address", "S", "price" };
            string[] ArrValue = new string[] { INN, type, address, size, price};
            //создаём Row in PROPERTY
            db.addRequest("PROPERTY", ArrInto, ArrValue);

            updatePropertyProgressBar.Value = 100;
            completedDataPropertyAsy();

            //очищаем textBox
            innOwnerPropertyMaskBox.Text = string.Empty;
            addressPropertyBox.Text = string.Empty;
            typePropertyBox.Text = string.Empty;
            sizePropertyBox.Text = string.Empty;
            prisePropertyBox.Text = string.Empty;
        }
        //успешное занесение данных PROPERTY
        private async void completedDataPropertyAsy()
        {
            await Task.Run(() =>
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    //возвращаем кнопку и изменяем текст info
                    updatePropertyStackPanel.Visibility = Visibility.Collapsed;
                    errorPropertyStackPanel.Visibility = Visibility.Collapsed;
                    updatePropertyButton.Visibility = Visibility.Visible;
                    completedDataPropertySnackBar.IsActive = true;
                }));
                Thread.Sleep(5000);
                Dispatcher.Invoke((Action)(() =>
                {
                    completedDataPropertySnackBar.IsActive = false;
                }));
            });
        }
        //проверка на ошибки ввода PROPERTY
        private string checkTrueDataProperty()
        {
            if (innOwnerPropertyMaskBox.Text == "____________")
            {
                return "Введите ИНН владельца";
            }
            else if (addressPropertyBox.Text == string.Empty)
            {
                return "Введите адрес";
            }
            else if (typePropertyBox.Text == string.Empty)
            {
                return "Введите тип";
            }
            else if (sizePropertyBox.Text == string.Empty)
            {
                return "Введите площадь";
            }
            else if (prisePropertyBox.Text == string.Empty)
            {
                return "Введите стоимость";
            }
            if (innOwnerPropertyMaskBox.Text != "____________")
            {
                string inn = innOwnerPropertyMaskBox.Text;
                if (inn.Contains('_'))
                {
                    return "Не верно ведён ИНН";
                }
                else
                {
                    try
                    {
                        string innPers = innOwnerPropertyMaskBox.Text;
                        DataTable idValue = db.Request($"SELECT unit_ID FROM INN WHERE inn_value = N'{innPers}'");
                        string idi = idValue.Rows[0][0].ToString();
                    }
                    catch
                    {
                        return "ИНН не существует";
                    }
                }
            }
            return "true";
        }
        //вывод инфо об ошибке PROPERTY
        private void errorInfoPropertyShow(string info)
        {
            //возвращаем кнопку сохранения
            updatePropertyStackPanel.Visibility = Visibility.Collapsed;
            updatePropertyButton.Visibility = Visibility.Visible;
            //выводим info об ошибке
            errorPropertyStackPanel.Visibility = Visibility.Visible;
            errorPropertyText.Text = info;
            return;
        }


        //сохранение TRANSPORT
        private void saveTransportButton_Click(object sender, RoutedEventArgs e)
        {
            //изменяем кнопку на инфо об изменении
            updateTransportStackPanel.Visibility = Visibility.Visible;
            updateTransportButton.Visibility = Visibility.Collapsed;
            updateTransportProgressBar.Value = 10;

            //проверка ввёл-ли пользователь данные
            string res = checkTrueDataTransport();
            if (res != "true")
            {
                errorInfoTransportShow(res);
                return;
            }


            //обязательные переменные
            string INN, brand, model, price, year, type ;

            //забираем введённые данные
            INN = innOwnerTransportMaskBox.Text;
            brand = brandTransportBox.Text;
            model = modelTransportBox.Text;
            type = typeTransportBox.Text;

            decimal.TryParse(priseTransportBox.Text, out decimal valueSize).ToString();
            price = valueSize.ToString();

            decimal.TryParse(yearTransportBox.Text, out decimal valuePrice).ToString();
            year = valuePrice.ToString();

            //обновляем прогресс работы
            updateTransportProgressBar.Value = 60;

            string[] ArrInto = new string[] { "inn_owner", "brand", "model", "year_prom", "price", "type" };
            string[] ArrValue = new string[] { INN, brand, model, year, price, type };

            //создаём Row in TRANSPORT
            db.addRequest("TRANSPORT", ArrInto, ArrValue);

            updateTransportProgressBar.Value = 100;
            completedDataTransportAsy();

            //очищаем textBox
            innOwnerTransportMaskBox.Text = string.Empty;
            brandTransportBox.Text = string.Empty;
            modelTransportBox.Text = string.Empty;
            typeTransportBox.Text = string.Empty;
            priseTransportBox.Text = string.Empty;
            yearTransportBox.Text = string.Empty;
        }
        //успешное занесение данных Transport
        private async void completedDataTransportAsy()
        {
            await Task.Run(() =>
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    //возвращаем кнопку и изменяем текст info
                    updateTransportStackPanel.Visibility = Visibility.Collapsed;
                    errorTransportStackPanel.Visibility = Visibility.Collapsed;
                    updateTransportButton.Visibility = Visibility.Visible;
                    completedDataTransportSnackBar.IsActive = true;
                }));
                Thread.Sleep(5000);
                Dispatcher.Invoke((Action)(() =>
                {
                    completedDataTransportSnackBar.IsActive = false;
                }));
            });
        }
        //проверка на ошибки ввода Transport
        private string checkTrueDataTransport()
        {
            if (innOwnerTransportMaskBox.Text == "____________")
            {
                return "Введите ИНН владельца";
            }
            else if (brandTransportBox.Text == string.Empty)
            {
                return "Введите марку";
            }
            else if (modelTransportBox.Text == string.Empty)
            {
                return "Введите модель";
            }
            else if (yearTransportBox.Text == string.Empty)
            {
                return "Введите год производства";
            }
            else if (priseTransportBox.Text == string.Empty)
            {
                return "Введите стоимость";
            }
            else if (typeTransportBox.Text == string.Empty)
            {
                return "Введите тип";
            }

            string rr = innOwnerTransportMaskBox.Text;
            if (rr.Contains('_'))
            {
                return "Не верно введён ИНН";
            }
            else
            {
                try
                {
                    string inn = innOwnerTransportMaskBox.Text;
                    DataTable idValue = db.Request($"SELECT unit_ID FROM INN WHERE inn_value = N'{inn}' ");
                    string CompaniID = idValue.Rows[0][0].ToString();
                }
                catch
                {
                    return "ИНН не существует";
                }
            }

            

            return "true";
        }
        //вывод инфо об ошибке Transport
        private void errorInfoTransportShow(string info)
        {
            //возвращаем кнопку сохранения
            updateTransportStackPanel.Visibility = Visibility.Collapsed;
            updateTransportButton.Visibility = Visibility.Visible;
            //выводим info об ошибке
            errorTransportStackPanel.Visibility = Visibility.Visible;
            errorTransportText.Text = info;
            return;
        }

        //сохранение Tax
        private void saveTaxButton_Click(object sender, RoutedEventArgs e)
        {
            //изменяем кнопку на инфо об изменении
            updateTaxStackPanel.Visibility = Visibility.Visible;
            updateTaxButton.Visibility = Visibility.Collapsed;
            updateTaxProgressBar.Value = 10;

            //проверка ввёл-ли пользователь данные
            string errorChek = checkTrueDataTax();
            if (errorChek != "true")
            {
                errorInfoTaxShow(errorChek);
                return;
            }

            //обязательные переменные
            string INN, sum, status, type;

            //магия над датой
            DateTime myDateTime = (DateTime)dataTaxPicker.SelectedDate;
            string time = myDateTime.ToString("yyyy-MM-dd");

            //забираем введённые данные
            INN = innOwnerTaxMaskBox.Text;
            status = statusTaxBox.Text;
            type = typeTaxBox.Text;

            decimal.TryParse(sumTaxBox.Text, out decimal valuePrice).ToString();
            sum = valuePrice.ToString();


            //обновляем прогресс работы
            updateTaxProgressBar.Value = 60;

            string[] ArrInto = new string[] { "inn_owner", "tax_sum", "type", "date", "status" };
            string[] ArrValue = new string[] { INN, sum, type, time, status };

            //создаём Row in TAX
            db.addRequest("TAX", ArrInto, ArrValue);

            updateTransportProgressBar.Value = 100;
            completedDataTaxtAsy();

            //очищаем textBox
            sumTaxBox.Text = string.Empty;
            innOwnerTaxMaskBox.Text = string.Empty;
            statusTaxBox.Text = string.Empty;
            typeTaxBox.Text = string.Empty;
            dataTaxPicker.Text = string.Empty;
        }
        //успешное занесение данных Tax
        private async void completedDataTaxtAsy()
        {
            await Task.Run(() =>
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    //возвращаем кнопку и изменяем текст info
                    updateTaxStackPanel.Visibility = Visibility.Collapsed;
                    errorTaxStackPanel.Visibility = Visibility.Collapsed;
                    updateTaxButton.Visibility = Visibility.Visible;
                    completedDataTaxSnackBar.IsActive = true;
                }));
                Thread.Sleep(5000);
                Dispatcher.Invoke((Action)(() =>
                {
                    completedDataTaxSnackBar.IsActive = false;
                }));
            });
        }
       
        //проверка на ошибки ввода Tax
        private string checkTrueDataTax()
        {
            if (innOwnerTaxMaskBox.Text == "____________")
            {
                return "Введите ИНН";
            }
            else if (sumTaxBox.Text == string.Empty)
            {
                return "Введите сумму";
            }
            else if (statusTaxBox.Text == string.Empty)
            {
                return "Введите статус";
            }
            else if (typeTaxBox.Text == string.Empty)
            {
                return "Введите тип налога";
            }
            else if (dataTaxPicker.Text == string.Empty)
            {
                return "Введите дату";
            }

            string ss = innOwnerTaxMaskBox.Text;
            if (ss.Contains('_'))
            {
                return "Не верно введён ИНН";
            }
            else {
                try
                {
                    string inn = innOwnerTaxMaskBox.Text;
                    DataTable idValue = db.Request($"SELECT unit_ID FROM INN WHERE inn_value = N'{inn}' ");
                    string CompaniID = idValue.Rows[0][0].ToString();
                }
                catch
                {
                    return "ИНН не существует";
                }
            }
            

            return "true";
        }
        //вывод инфо об ошибке Tax
        private void errorInfoTaxShow(string info)
        {
            //возвращаем кнопку сохранения
            updateTaxStackPanel.Visibility = Visibility.Collapsed;
            updateTaxButton.Visibility = Visibility.Visible;
            //выводим info об ошибке
            errorTaxStackPanel.Visibility = Visibility.Visible;
            errorTaxText.Text = info;
            return;
        }

    }
}
