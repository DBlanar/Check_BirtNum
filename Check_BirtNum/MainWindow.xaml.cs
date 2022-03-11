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
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;

namespace Check_BirtNum
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Check_Key(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Check_Click(sender, e);
            }
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            Check_Num(Input.Text.ToString());
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV (*.csv)|*.csv|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                Read_File(openFileDialog.FileName);
            }
        }

        protected internal void Read_File(string del)
        {
            List<string> fileList = new List<string>();

            if (del != null)
            {
                char[] sep = new char[] { ' ', '.', '\n', ',' };
                string[] data = File.ReadAllText(del).Split(sep, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in data)
                {
                    if (item == " ")
                    {
                        continue;
                    }
                    fileList.Add(item.Trim());
                }
            }

            foreach (var item in fileList)
            {
                Check_Num(item);
            }
        }

        private void Check_Num(string input)
        {
            ResultWin win = new ResultWin();
            CheckNum chk = new CheckNum();
            bool helpBool = false;

            win.NumberShow.Content = input;

            // kontrola jestli input je cislo spravne zadane (cislo nebo cislo s lomitkem) = true, cislo s pismeny = false, nebo pismena = false
            if (chk.Check0(input) == false)
            {
                win.Show6.Content = "Chyba";
                helpBool = true;
            }

            // kontrola zda je cislo dostatecne dlouhe
            if (chk.Check1() == false)
            {
                win.Show7.Content = "Chyba";
                helpBool = true;
            }

            // kontrola zde cislo neni delsi nez ma byt
            if (chk.Check2() == false)
            {
                win.Show8.Content = "Chyba";
                helpBool = true;
            }

            // kontrola zda 9 cisla maji koncovku 000 = spatne
            if (chk.Check3() == false)
            {
                win.Show9.Content = "Chyba";
                helpBool = true;
            }

            // kontrola zda EPČ a RČ+ = true
            List<bool> arg = chk.Check4();
            if (arg[0] == true && arg[1] == true)
            {
                win.Show10.Content = "Ano";
            }
            else if (arg[0] == true && arg[1] == false)
            {
                win.Show10.Content = "RČ+";
            }
            else if (arg[0] == false && arg[1] == true)
            {
                win.Show10.Content = "EPČ";
            }
            else
            {
                win.Show10.Content = "Ne";
            }

            // kontrola zda rok cisla je ve spravnem rozmezi
            if (chk.Check5() == false)
            {
                win.Show11.Content = "Chyba";
                helpBool = true;
            }

            // kontrola zda mesic cisla je ve spravnem rozmezi
            if (chk.Check6() == false)
            {
                win.Show0.Content = "Chyba";
                helpBool = true;
            }

            // kontrola zda den cisla je ve spravnem rozmezi
            if (chk.Check7() == false)
            {
                win.Show1.Content = "Chyba";
                helpBool = true;
            }

            // kontrola zda cislo neni z budoucnosti cisla je ve spravnem rozmezi
            if (chk.Check8() == false)
            {
                win.Show2.Content = "Chyba";
                helpBool = true;
            }

            // kontrola zda cislo ma spravnou velkou koncovku jestli je cisle 9 mistne
            if (chk.Check9() == false)
            {
                win.Show3.Content = "True";
                helpBool = true;
            }
            else if (arg[1] == false)
            {
                win.Show3.Content = "--";
            }
            else
            {
                win.Show3.Content = "False";
            }

            // kontrola zda cislo ma spravnou velkou koncovku jestli je cisle 10 mistne
            if (chk.Check10() == false)
            {
                win.Show4.Content = "True";
                helpBool = true;
            }
            else if (arg[1] == false)
            {
                win.Show4.Content = "--";
            }
            else
            {
                win.Show4.Content = "False";
            }

            // kontrola zda je cislo delitelne 11 beze zbitku
            if (chk.Check11() == false)
            {
                win.Show5.Content = "Chyba";
                helpBool = true;
            }
            else if (input.Length == 9)
            {
                win.Show5.Content = "--";
            }

            // hlavni output kontrola "zkraceni"
            if (helpBool)
            {
                win.MainShow.Content = "Chyba";
            }

            Input.Clear();
            win.Show();
        }
    }
}
