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
    /// Interaction logic for TransactionPage.xaml
    /// </summary>
    public partial class TransactionPage : Page
    {
        TransactionsController transactions;
        public int Index;
        public TransactionPage()
        {
            transactions = new TransactionsController(this);
            InitializeComponent();
            transactions.GetTransaction();
        }

        private void lstTransaction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Index = lstTransaction.SelectedIndex;
             
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            transactions.UpdateStat();
            
        }
    }
}
