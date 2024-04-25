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
using Inspection.Helpers;
using Inspection.PageApp;



namespace Inspection.PageApp
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            this.Background = MainMenu.Background;
            searchPage.Source = new Uri("SearchPage.xaml", UriKind.Relative); ;
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
                    case "Сменить пользователя":
                        // Действия для "Смена пользователя"
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

        //смена пользователя
        private void ExitInAvtori_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AvtoriPage()); ;
        }

        //Выход из приложения
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        //изменение темы
        private void ToggleThemeButton_Click(object sender, RoutedEventArgs e)
        {
            // Инвертируем текущее состояние темы (светлая <-> тёмная)
            matDesWpfThemeChanger.IsDarkThemeEnabled = !matDesWpfThemeChanger.IsDarkThemeEnabled;
            // Изменяем иконку
            if (this.ThemeButtonIcon.Kind == PackIconKind.Lamp) this.ThemeButtonIcon.Kind = PackIconKind.LampOutline;
            else this.ThemeButtonIcon.Kind = PackIconKind.Lamp;
            // Применяем выбранную тему
            matDesWpfThemeChanger.ApplyTheme(matDesWpfThemeChanger.IsDarkThemeEnabled);
            this.Background = MainMenu.Background;

        }


        

    }
}
