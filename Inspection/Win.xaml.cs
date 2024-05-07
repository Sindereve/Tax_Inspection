using System.Windows;
using Inspection.PageApp;
using Inspection.Helpers;


namespace Inspection
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Win : Window
    {
        public Win()
        {
            InitializeComponent();
            MainFrame.Content = new AvtoriPage();
            matDesWpfThemeChanger.IsDarkThemeEnabled = !matDesWpfThemeChanger.IsDarkThemeEnabled;

            // Изменяем иконку
            // Применяем выбранную тему
            matDesWpfThemeChanger.ApplyTheme(matDesWpfThemeChanger.IsDarkThemeEnabled);
        }
    }
}