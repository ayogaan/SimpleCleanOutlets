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
        RegisterPage register;
        private string error;
        public AccountController(LoginPage _login) {

            account = new AccountModel();
            login = _login;            
        }

        public AccountController(RegisterPage _register)
        {
            register = _register;
            account = new AccountModel();
        }

        public bool RegisterValidate(){
            bool stat = false;
            if (register.txtPassword == register.txtPasswordCnfrm)
            {
                
            }
            else {
                error = "Password tidak cocok";
                stat = false;
            }
            
            return stat;
        }

        public void Register() {
            if (RegisterValidate())
            {

            }
            else
            {
                var bc = new BrushConverter();
                login.lblError.Content = error;
                login.lblError.Background = (Brush)bc.ConvertFrom("#e74c3c");
                login.UpdateLayout();
            }
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
