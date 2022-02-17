﻿using System;
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

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            ResultWin win = new ResultWin();
            CheckNum chk = new CheckNum();
            string input = Input.Text.ToString();
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
            if (chk.Check4() == false)
            {
                win.Show10.Content = "Ano";
                helpBool = true;
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
