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

namespace SimpleClean_Outlets.Views
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        BrushConverter bc;
        public HomePage()
        {
            bc = new BrushConverter();
            InitializeComponent();
            btnOrders.Background = (Brush)bc.ConvertFrom("#DBC0E4");
            btnHome.Background = (Brush)bc.ConvertFrom("#fff");
            btnTransactions.Background = (Brush)bc.ConvertFrom("#fff");
        }

        private void btnTransactions_Click(object sender, RoutedEventArgs e)
        {
            btnTransactions.Background = (Brush)bc.ConvertFrom("#DBC0E4");
            btnOrders.Background = (Brush)bc.ConvertFrom("#fff");
            btnHome.Background = (Brush)bc.ConvertFrom("#fff");
            pageControl.Source = new Uri("TransactionPage.xaml", UriKind.Relative);
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            btnOrders.Background = (Brush)bc.ConvertFrom("#DBC0E4");
            btnHome.Background = (Brush)bc.ConvertFrom("#fff");
            btnTransactions.Background = (Brush)bc.ConvertFrom("#fff");
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            btnHome.Background = (Brush)bc.ConvertFrom("#DBC0E4");
            btnOrders.Background = (Brush)bc.ConvertFrom("#fff");
            btnTransactions.Background = (Brush)bc.ConvertFrom("#fff");
        }
    }
}
