using SimpleClean_Outlets.ItemWrapper;
using SimpleClean_Outlets.Models;
using SimpleClean_Outlets.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SimpleClean_Outlets.Controllers
{
    

    class TransactionsController
    {
        private TransactionsModel transactionModel;
        private TransactionPage transactions;
        public TransactionsController(TransactionPage _transaction) {
            transactions = _transaction;
            transactionModel = new TransactionsModel();
            
        }

        public void GetTransaction()
        {
            transactionModel.GetTransaction();
            transactions.lstTransaction.ItemsSource = transactionModel.transactions;
            transactionModel.GetOmzet();
            transactions.lblIncome.Content = "Rp." + transactionModel.Omset;
            transactions.lblOutlets.Content = AccountModel.Outlets;
        }

        public void UpdateStat() {
            string status;
            TransactionWraper selectedObj = transactionModel.transactions[transactions.Index];
            if (selectedObj.status.ToUpper()=="DONE") {
                status = "waiting";
            }
            else
            {
                status = "done";
            }
            if (transactionModel.ConfirmPayment(selectedObj.transactionId, status)) {
                transactionModel.GetTransaction();
                transactions.lstTransaction.Items.Refresh();
            }
        }

        public void updateBtn() {
            Console.WriteLine(transactions.Index);
            TransactionWraper selectedObj = transactionModel.transactions[transactions.Index];
            BrushConverter bc = new BrushConverter();

            if (selectedObj.status.ToUpper() == "DONE")
            {
                transactions.lblBayar.Text = "Batalkan Pembayaran";
                transactions.btnConfirm.Background = (Brush)bc.ConvertFrom("#e74c3c");
            }
            else
            {
                transactions.lblBayar.Text = "Konfirmasi Pembayaran";
                transactions.btnConfirm.Background = (Brush)bc.ConvertFrom("#DBC0E4");

            }
            
            
        }
    }
}
