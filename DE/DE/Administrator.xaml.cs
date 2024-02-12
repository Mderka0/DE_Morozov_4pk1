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

namespace DE
{
    /// <summary>
    /// Логика взаимодействия для Administrator.xaml
    /// </summary>
    public partial class Administrator : Window
    {
        public Administrator()
        {
            InitializeComponent();
        }
        TradeEntities db;

        private void AddBut_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.ProductName = NameTB.Text;
            product.ProductManufacturer = ManufTB.Text;
            product.ProductStatus = StatusTB.Text;
            product.ProductDescription = DescrTB.Text; 
            product.ProductCategory = CategoryTB.Text;
            //product.ProductPhoto = Convert.ToByte(PhotoTB.Text);
            product.ProductCost = Convert.ToInt32( CostTB.Text);
            product.ProductDiscountAmount = Convert.ToByte(DiscontTB.Text);
            product.ProductQuantityInStock = Convert.ToInt32(QuantitiTB.Text); 
            db.Product.Add(product);
            db.SaveChanges();
            dg.ItemsSource = db.Product.ToList();

        }

        private void DelBut_Click(object sender, RoutedEventArgs e)
        {
            var selectedId = db.Product.Where(p => p.ProductArticleNumber == IdDelTB.Text).FirstOrDefault();
            db.Product.Remove(selectedId);
            db.SaveChanges();
            dg.ItemsSource = db.Product.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new TradeEntities();
            dg.ItemsSource = db.Product.ToList();
        }
    }
}
