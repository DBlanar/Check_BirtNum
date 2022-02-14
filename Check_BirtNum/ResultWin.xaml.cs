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
using System.Windows.Shapes;

namespace Check_BirtNum
{
    /// <summary>
    /// Interaction logic for ResultWin.xaml
    /// </summary>
    public partial class ResultWin : Window
    {
        public ResultWin()
        {
            InitializeComponent();
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow winMain = new MainWindow();

            winMain.Input.Text = "";

            winMain.Show();
            this.Close();
        }
    }
}
