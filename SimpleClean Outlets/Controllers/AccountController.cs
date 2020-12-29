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
    class AccountController
    {
        AccountModel account;
        LoginPage login;
        public AccountController(LoginPage _login) {

            account = new AccountModel();
            login = _login;            
        }

        public void Login() {
            account.Uname = login.txtUsername.Text;
            account.Pass = login.txtPassword.Password;
            if (account.Login()) {
                HomePage homePage = new HomePage();
                homePage.Show();
                login.Close();
            }
            else
            {
                var bc = new BrushConverter();
                login.txtUsername.Text = "";
                login.txtPassword.Password = "";
                login.txtUsername.Focus();
                login.lblError.Content = account.Message;
                login.lblError.Background = (Brush)bc.ConvertFrom("#e74c3c");
                login.UpdateLayout();
            }

        }
    }
}
