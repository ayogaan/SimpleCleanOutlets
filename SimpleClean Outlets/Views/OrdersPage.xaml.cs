using SimpleClean_Outlets.Controllers;
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

namespace SimpleClean_Outlets.Views
{
    /// <summary>
    /// Interaction logic for OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        OrderController order;
        public int Index=-1;
        public OrdersPage()
        {
            
            InitializeComponent();
            order = new OrderController(this);
        }

        private void lstOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Index = lstOrders.SelectedIndex;
            order.updateCBB();
            order.UpdateTxt();
        }

       

        private void txtWeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtWeight.Text == "-") {
                txtWeight.IsEnabled = false;
            }
            
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            order.UpdateOrder();
        }
    }
}
