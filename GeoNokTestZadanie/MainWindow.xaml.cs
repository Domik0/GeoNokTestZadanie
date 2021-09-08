using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace GeoNokTestZadanie
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int flagLanguage = 0;
        string tmpStr = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenLogin(object sender, MouseButtonEventArgs e)
        {
            DateTime? dt = DatePick.SelectedDate;
            int summDT = dt.Value.Day % 10 + dt.Value.Day / 10 + 
                dt.Value.Month % 10 + dt.Value.Month / 10 + 
                dt.Value.Year % 10 / 100 + dt.Value.Year / 10 + dt.Value.Year % 100 / 1000 + dt.Value.Year % 1000;
            GenTextLog.Text = BoxName.Text + summDT;
        }

        private void GenPas(object sender, MouseButtonEventArgs e)
        {
            bool en = false;
            bool symbol = false;
            bool number = false;

            string s0, s1, st;
            s0 = "";
            Random rnd = new Random();
            int n;
            st = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-!_";

            while (!en || !symbol || !number)
            {
                for (int j = 0; j < 10; j++)
                {
                    n = rnd.Next(0, 65);
                    s1 = st.Substring(n, 1);
                    s0 += s1;
                }
                for (int i = 0; i < s0.Length; i++)
                {
                    if (s0[i] >= 'A' & s0[i] <= 'Z') en = true;
                    if (s0[i] >= '0' & s0[i] <= '9') number = true;
                    if (s0[i] == '_' || s0[i] == '-' || s0[i] == '!') symbol = true;
                }
                if (en && number && symbol)
                {
                    GenTextPas.Text = s0;
                }
                s0 = "";
            }
        }

        private void Save(object sender, MouseButtonEventArgs e)
        {
            App.dbContext.users.Add(new user()
            {
                login = GenTextLog.Text,
                password = GenTextPas.Text,
                name = BoxName.Text,
                date = DatePick.SelectedDate
            });
            App.dbContext.SaveChanges();
        }

        private void Clear(object sender, MouseButtonEventArgs e)
        {
            ComboLan.SelectedItem = null;
            BoxName.Text = "";
            DatePick.SelectedDate = null;
            GenTextLog.Text = "";
            GenTextPas.Text = "";
            flagLanguage = 0;
            tmpStr = "";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ComboLan.SelectedItem != null)
            {
                if ((string)(e.AddedItems[0] as ComboBoxItem).Content == "Русский")
                {
                    //InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("ru-RU"));
                    flagLanguage = 1;
                }
                else
                {
                    //InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-US"));
                    flagLanguage = 2;
                }
            }
        }

        private void BoxName_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (flagLanguage == 1)
            {
                if (!Regex.IsMatch(BoxName.Text, @"^[А-Яа-я]+$"))
                {
                    BoxName.Text = tmpStr;
                }
                else
                {
                    tmpStr = BoxName.Text;
                }
            }
            else if (flagLanguage == 2)
            {
                if (!Regex.IsMatch(BoxName.Text, @"^[A-Za-z]+$"))
                {
                    BoxName.Text = tmpStr;
                }
                else
                {
                    tmpStr = BoxName.Text;
                }
            }
            else
            {
                BoxName.Text = tmpStr;
            }
        }

        private void DatePick_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DatePick.SelectedDate > DateTime.Now)
            {
                DatePick.SelectedDate = null;
            }
        }
    }
}
