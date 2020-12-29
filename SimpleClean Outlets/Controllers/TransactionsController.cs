using SimpleClean_Outlets.Models;
using SimpleClean_Outlets.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
