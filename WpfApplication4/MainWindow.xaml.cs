using System;
using System.Collections.Generic;
using System.Data.Entity;
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



//  https://msdn.microsoft.com/en-us/library/jj574514(v=vs.113).aspx

namespace WpfApplication4 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private ProductContext _context = new ProductContext();

        public MainWindow() {
            InitializeComponent();
        }

        ProductContext productContext=new ProductContext();

        private void button_Click(object sender, RoutedEventArgs e) {
            Category category = new Category();
            category.CategoryId = 6037;
            category.Name="myCatEmil";

            productContext.Categories.Add(category);

            Product product = new Product();
            product.Category = category;
            product.CategoryId = category.CategoryId;
            product.Name = "DuckDuckGo";
            product.ProductId = 6042;

            productContext.Products.Add(product);

            productContext.SaveChanges();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {

            System.Windows.Data.CollectionViewSource categoryViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("categoryViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // categoryViewSource.Source = [generic data source]

            _context.Categories.Load();
            categoryViewSource.Source = _context.Categories.Local;

        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e) {
            base.OnClosing(e);
            this._context.Dispose();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e) {
            foreach(var product in _context.Products.Local.ToList()) {
                if(product.Category == null) {
                    _context.Products.Remove(product);
                }
            }

            _context.SaveChanges();

            this.categoryDataGrid.Items.Refresh();
            this.productsDataGrid.Items.Refresh();
        }

        private void buttonCleanUp_Click(object sender, RoutedEventArgs e) {
            foreach(var product in _context.Products.Local.ToList()) {
                    _context.Products.Remove(product);
            }

            foreach(var category in _context.Categories.Local.ToList()) {
                _context.Categories.Remove(category);
            }

            _context.SaveChanges();

            this.categoryDataGrid.Items.Refresh();
            this.productsDataGrid.Items.Refresh();
        }
    }
}
