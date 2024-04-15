using System;
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
using System.Windows.Media.Animation;

namespace Inspection
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AvtorizWin : Window
    {
        public AvtorizWin(){
            InitializeComponent();
        }

        private void Button_Avtoriz_Click(object sender, RoutedEventArgs e){
            if (boxLogin.Text == "111" && boxPassword.Password == "111"){
                MainWin mainWin = new MainWin();
                mainWin.Show();
                this.Hide();
            }
            else if (boxLogin.Text != "111" ){
                errorText.Visibility = Visibility.Visible;
            }

        }
    }
}
