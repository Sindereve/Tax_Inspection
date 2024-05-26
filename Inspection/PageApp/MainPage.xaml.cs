using System;
using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Inspection.Helpers;
using Inspection.Date;
using System.Threading.Tasks;
using System.Threading;


namespace Inspection.PageApp
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {

        private DataBase db; // Поле для хранения экземпляра класса DataBase
        public MainPage()
        {
            InitializeComponent();
            // Задаём цвет согласно темы
            this.Background = MainMenu.Background;
            //закрепляем стр за frame 

            System.Uri searchPageClass = new Uri("SearchPage.xaml", UriKind.Relative);
            System.Uri addPageClass = new Uri("addPage.xaml", UriKind.Relative);
            System.Uri searchForINNClass = new Uri("searchINN.xaml", UriKind.Relative);
            System.Uri madeFr = new Uri("madeFrom.xaml", UriKind.Relative);

            searchPage.Source = searchPageClass;
            addPage.Source = addPageClass;
            searchForINN.Source = searchForINNClass;
            infoProm.Source = madeFr;


            // Получаем экземпляр класса DataBase
            db = DataBase.GetInstance();
            // Прописываем log юзера
            loginUser.Text = UserWorking.Login;
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


        //нажатие на изменение 
        private void ToggleThemeButton_Click(object sender, RoutedEventArgs e)
        {
            // Инвертируем текущее состояние темы (светлая <-> тёмная)
            matDesWpfThemeChanger.IsDarkThemeEnabled = !matDesWpfThemeChanger.IsDarkThemeEnabled;
            // Изменяем иконку
            if (this.ThemeButtonIcon.Kind == PackIconKind.Lamp) this.ThemeButtonIcon.Kind = PackIconKind.LampOutline;
            else this.ThemeButtonIcon.Kind = PackIconKind.Lamp;
            // Применяем выбранную тему
            matDesWpfThemeChanger.ApplyTheme(matDesWpfThemeChanger.IsDarkThemeEnabled);
            

            object i1 = searchPage.Height.ToString();
            object i2 =  searchPage.Width.ToString();

            this.Background = MainMenu.Background;
        }


       

        

    }
}
