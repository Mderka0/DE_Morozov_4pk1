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

namespace DE
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
        TradeEntities db;

        private void SignInBut_Click(object sender, RoutedEventArgs e)
        {
            db = new TradeEntities();

            var User = db.User.Where(d => (d.UserLogin == LoginTB.Text && d.UserPassword == PassTB.Text)).FirstOrDefault();

            if (User.UserRole == 1)
            {
                Administrator adm = new Administrator();
                adm.Show();
                this.Close();
            }
            else if (User.UserRole == 2)
            {
                Manager mng = new Manager();
                mng.Show();
                this.Close();
            }
            else if (User.UserRole == 2)
            {
                Client cli = new Client();
                cli.Show();
                this.Close();
            }
            else
            {
                Guest g = new Guest();
                g.Show();
                this.Close();
            }


        }

        private void SignInGstBut_Click(object sender, RoutedEventArgs e)
        {
            Guest g = new Guest();
            g.Show();
            this.Close();
        }
    }
}
