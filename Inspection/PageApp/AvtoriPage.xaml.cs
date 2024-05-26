using Inspection.Date;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Inspection.PageApp
{
    /// <summary>
    /// Логика взаимодействия для Avtori.xaml
    /// </summary>
    public partial class AvtoriPage : Page
    {

        private DataBase db; // Поле для хранения экземпляра класса DataBase

        public AvtoriPage()
        {
            InitializeComponent();

            // Получаем экземпляр класса DataBase
            db = DataBase.GetInstance();
        }

        //выход из приложения
        private void ExitButton_Click(object sender, RoutedEventArgs e){
            Application.Current.Shutdown();
        }

        //кнопка авторизации
        private void AvtoriButton_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new MainPage());

            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Password;

            if (db.avtoriRequest("WORKER", login, password))
            {
                UserWorking.Login = login;
                NavigationService.Navigate(new MainPage());
            }
            else
            {
                IsErrorLoginOrPasswordAsync();
            }
        }

        //событие при неправильном вводе ИНН для поиска 
        private async void IsErrorLoginOrPasswordAsync()
        {
            
            await Task.Run(() =>
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    ErrorLoginOrPassword.IsActive = true;
                }));

                Thread.Sleep(10000);

                Dispatcher.Invoke((Action)(() =>
                {
                    ErrorLoginOrPassword.IsActive = false;
                }));
            });
        }



    }
}
