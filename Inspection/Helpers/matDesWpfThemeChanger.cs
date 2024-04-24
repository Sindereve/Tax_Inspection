using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Inspection.Helpers
{
    public static class matDesWpfThemeChanger
    {
        public static bool IsDarkThemeEnabled = true;

        public static void ApplyTheme(bool isDarkTheme)
        {
            // Определяем пути к ресурсам темы (светлой или тёмной)
            string themeDictionaryUri = isDarkTheme ? "pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Dark.xaml"
                                                      : "pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml";

            // Загружаем ресурсы темы
            var themeDictionary = new ResourceDictionary();
            themeDictionary.Source = new Uri(themeDictionaryUri);

            // Применяем загруженные ресурсы в качестве текущей темы приложения

            Application.Current.Resources.MergedDictionaries.Add(themeDictionary);
        }
    }

    
}
