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
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        Controllers.AccountController controller; 
        public ProfilePage()
        {
            InitializeComponent();
            controller = new Controllers.AccountController(this);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            controller.SetImg();
        }
    }
}
