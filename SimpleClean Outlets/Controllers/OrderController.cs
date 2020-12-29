using SimpleClean_Outlets.Models;
using SimpleClean_Outlets.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClean_Outlets.Controllers
{

    class OrderController
    {
        private OrderModel order;
        private OrdersPage page;

        public OrderController(OrdersPage page) {
            order = new OrderModel();
            this.page = page;
            SetView();
        }

        public void SetView() {
            order.GetOrders();
            page.lstOrders.ItemsSource = order.orders;
        }

    }
}
