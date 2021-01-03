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
            SetCBStatus();
        }

        public void SetView() {
            order.GetOrders();
            page.lstOrders.ItemsSource = order.orders;
        }
        public void SetCBStatus() {
            order.GetStatusList();
           
            page.StatusLst.ItemsSource = OrderModel.Status;
            
        }
        public void updateCBB() {
            if (page.Index >= 0)
            {
                page.StatusLst.Text = order.orders[page.Index].Status;
            }
        } 
        public void UpdateTxt()
        {
            if (page.Index >= 0)
            {
                page.txtWeight.Text = order.orders[page.Index].Berat;
            }
        }
        public void UpdateOrder() {
            if (page.Index >= 0)
            {
                if (
                order.UpdateOrder((page.StatusLst.SelectedIndex).ToString(), order.orders[page.Index].IdOrder, page.txtWeight.Text)
                )
                {
                    order.GetOrders();
                    page.lstOrders.Items.Refresh();
                }
            }
            else {
                Console.WriteLine("alert");
            }
        }
    }
}
