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

namespace WpfApplication4 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            /*
            if(VariableName.DatabaseExists()) {
                MessageBox.Show("Data is in");
            }
            */
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }


        ProductContext productContext=new ProductContext();

        private void button_Click(object sender, RoutedEventArgs e) {
            Category category = new Category();
            category.CategoryId = 6037;
            category.Name="myCat";

            productContext.Categories.Add(category);

            Product product = new Product();
            product.Category = category;
            product.CategoryId = category.CategoryId;
            product.Name = "Duck";
            product.ProductId = 6042;

            productContext.Products.Add(product);

            productContext.SaveChanges();
        }
    }
}
