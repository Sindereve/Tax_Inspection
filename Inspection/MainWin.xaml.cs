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
    /// Логика взаимодействия для MainWin.xaml
    /// </summary>
    public partial class MainWin : Window
    {
        public MainWin()
        {
            InitializeComponent();
            mainBorder.Width = backGrid.Width - 20;
            mainBorder.Height = backGrid.Height - 50;
        }

        private void Clossing_Form (object sender, System.ComponentModel.CancelEventArgs e){
            AvtorizWin avtorizWin = new AvtorizWin();
            avtorizWin.Show();
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e){
            this.Close();
        }
    }
}
