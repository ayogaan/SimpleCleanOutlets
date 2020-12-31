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
using System.Windows.Shapes;

namespace SimpleClean_Outlets.Views
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
        AccountController controller;
        public int SelectedProv;
        public int SelectedKab;
        public int SelectedKec;

        public RegisterPage()
        {
            
            InitializeComponent();
            controller = new AccountController(this);
        }

        //register
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            controller.Register();

        }

        private void kabupatenLst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedKab = kabupatenLst.SelectedIndex;
            controller.GetKecLst();
        }

        private void provinsiLst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedProv=provinsiLst.SelectedIndex;
            Console.WriteLine(SelectedProv);
            controller.GetKabLst();
        }

        private void kecamatanLst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(kecamatanLst.SelectedIndex);
            SelectedKec = kecamatanLst.SelectedIndex;
            controller.getKelurahanLst();
        }

        private void kelurahanLst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
