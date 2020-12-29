﻿using SimpleClean_Outlets.Controllers;
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
        public OrdersPage()
        {
            
            InitializeComponent();
            order = new OrderController(this);
        }
    }
}
