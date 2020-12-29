using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClean_Outlets.ItemWrapper
{
    class TransactionWraper
    {
        public string transactionId { get; set; }
        public string invoiceDate { get; set; }
        public string customer { get; set; }
        public string paymentMethod { get; set; }
        public string status { get; set; }
        public string bill { get; set; }

        public TransactionWraper(string transactionId,string invoiceDate,string customer,string paymentMethod,string status, string bill)
        {
            this.transactionId = transactionId;
            this.invoiceDate = invoiceDate;
            this.customer = customer;
            this.paymentMethod = paymentMethod;
            this.status = status;
            this.bill = bill;
        }   
    }
}
