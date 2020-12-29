using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClean_Outlets.ItemWrapper
{
    class OrderWrapper
    {
        public string IdOrder { get; set; }
        public string Bill { get; set; }
        public string Date { get; set; }
        public string Berat { get; set; }
        public string Layanan { get; set; }
        public string Status { get; set; }
        public string Customer { get; set; }

        public OrderWrapper(string idOrder, string bill, string date, string berat, string layanan, string status, string customer) {
            IdOrder = idOrder;
            Bill = bill;
            Date = date;
            Berat = berat;
            Layanan = layanan;
            Status = status;
            Customer = customer;
        }
    }
}
