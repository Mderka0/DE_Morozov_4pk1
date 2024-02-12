using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace DE
{
    /// <summary>
    /// Логика взаимодействия для Guest.xaml
    /// </summary>
    public partial class Guest : Window
    {

        public Guest()
        {
            InitializeComponent();
        }
        TradeEntities db;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new TradeEntities();
            dg.ItemsSource = db.Product.ToList();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
