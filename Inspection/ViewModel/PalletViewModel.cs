using Inspection.Helpers;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace Inspection.ViewModel
{
    public class PalletViewModel : ObservableObject
    {
        public IEnumerable<Swatch> Swatches { get; set; }

        public PalletViewModel()
        {
            Swatches = new SwatchesProvider().Swatches;
        }

        public ICommand SetThemeCommand
        {
            get
            {
                return new DelegateCommand(o => ChangeTheme((bool)o));
            }
        }

        private void ChangeTheme(bool isDark)
        {
            // Создаем экземпляр PaletteHelper
            var paletteHelper = new PaletteHelper();

            // Получаем текущую тему
            Theme theme = paletteHelper.GetTheme();

            
            // Применяем измененную тему
            paletteHelper.SetTheme(theme);
        }
    }
}
