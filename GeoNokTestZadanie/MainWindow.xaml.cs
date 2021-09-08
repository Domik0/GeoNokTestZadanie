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

namespace GeoNokTestZadanie
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenLogin(object sender, MouseButtonEventArgs e)
        {

        }

        private void GenPas(object sender, MouseButtonEventArgs e)
        {

        }

        private void Save(object sender, MouseButtonEventArgs e)
        {

        }

        private void Clear(object sender, MouseButtonEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if ((string)(e.AddedItems[0] as ComboBoxItem).Content == "Русский")
            //{
            //    InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("ru-RU"));
            //}
            //else
            //{
            //    InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-US"));
            //}
        }
    }
}
