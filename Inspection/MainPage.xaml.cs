using System;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;



namespace Inspection
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //Выход в окно авторизации
        private void ExitInAvtori_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AvtoriPage()); ;
        }


        //Обработка событий из listBoxItem
        private void ListBoxItem_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Получаем ListBoxItem, который вызвал событие
            ListBoxItem item = sender as ListBoxItem;

            // Получаем TextBlock внутри ListBoxItem
            TextBlock textBlock = item.Content as TextBlock;

            // Проверяем, был ли нажат TextBlock
            if (textBlock != null)
            {
                // Получаем текст из TextBlock
                string text = textBlock.Text;

                // Выполнение действий в зависимости от текста
                switch (text)
                {
                    case "Выход из пользователя":
                        // Действия для "Выход из пользователя"
                        ExitInAvtori_Click(sender, e);
                        break;
                    case "Выход":
                        // Действия для "Выход"
                        ExitButton_Click(sender, e);
                        break;
                    default:
                        // Действия по умолчанию
                        break;
                }
            }
        }

        //Выход из приложения
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


    }
}
