using Newtonsoft.Json.Linq;
using SimpleClean_Outlets.Models;
using SimpleClean_Outlets.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        WebClient webClient;
        private List<string> provinsiList = new List<string>();
        private List<string> idProf = new List<string>();
        private List<string> kabList = new List<string>();
        private List<string> idkab = new List<string>();
        private List<string> kecLst = new List<string>();
        private List<string> idkec = new List<string>();
        private List<string> klrLst = new List<string>();
        private List<string> idklr = new List<string>();
        public AccountController(LoginPage _login) {

            account = new AccountModel();
            login = _login;            
        }

        public AccountController(RegisterPage _register)
        {
            register = _register;
            account = new AccountModel();
            webClient =  new WebClient();
            GetProfinsiApi();
        }

        public void GetProfinsiApi()
        {

            provinsiList.Clear();
            idProf.Clear();
            string Provinsi = webClient.DownloadString("https://dev.farizdotid.com/api/daerahindonesia/provinsi");
            JObject objProvinsi = JObject.Parse(Provinsi);
            foreach (JObject obj in objProvinsi["provinsi"])
            {
                provinsiList.Add(obj["nama"].ToString());
                idProf.Add(obj["id"].ToString());
            }
            register.provinsiLst.ItemsSource = provinsiList;
        }

        public void GetKabLst()
        {
            if (register.SelectedProv>=0) { 
            kabList.Clear();
            idkab.Clear();
            string Kabupaten = webClient.DownloadString("https://dev.farizdotid.com/api/daerahindonesia/kota?id_provinsi="+idProf[register.SelectedProv]);
            JObject objKab = JObject.Parse(Kabupaten);
            foreach (JObject obj in objKab["kota_kabupaten"])
            {
                kabList.Add(obj["nama"].ToString());
                idkab.Add(obj["id"].ToString());
            }
            register.kabupatenLst.ItemsSource = kabList;
            register.kabupatenLst.Items.Refresh();
            }
        }

        public void GetKecLst()
        {
            if (register.SelectedKab >= 0) { 
            kecLst.Clear();
            idkec.Clear();
            string Kecamatan = webClient.DownloadString("https://dev.farizdotid.com/api/daerahindonesia/kecamatan?id_kota=" + idkab[register.SelectedKab]);
            JObject objKec = JObject.Parse(Kecamatan);
            foreach (JObject obj in objKec["kecamatan"])
            {
                kecLst.Add(obj["nama"].ToString());
                idkec.Add(obj["id"].ToString());
            }
            register.kecamatanLst.ItemsSource = kecLst;
            register.kecamatanLst.Items.Refresh();
            }
        }

        public void getKelurahanLst() {
            if (register.SelectedKec >= 0) { 
            klrLst.Clear();
            idklr.Clear();
            Console.WriteLine(idkec[register.SelectedKec]);
            string Kecamatan = webClient.DownloadString("https://dev.farizdotid.com/api/daerahindonesia/kelurahan?id_kecamatan=" + idkec[register.SelectedKec]);
            JObject objKlr = JObject.Parse(Kecamatan);
            foreach (JObject obj in objKlr["kelurahan"])
            {
                Console.WriteLine(obj["nama"].ToString());
                klrLst.Add(obj["nama"].ToString());
                
            }
            register.kelurahanLst.ItemsSource = klrLst;
            }
        }

        public bool RegisterValidate(){
            bool stat = false;
            if (register.txtPassword.Password == register.txtPasswordCnfrm.Password)
            {
                stat = true;
            }
            else {
                error = "Password tidak cocok";                
            }
            
            return stat;
        }

        public void Register() {
            if (RegisterValidate())
            {
                
                if(account.Register(register.txtUsername.Text, register.txtPassword.Password, register.provinsiLst.Text+","+register.kabupatenLst.Text+ "," + register.kecamatanLst.Text+ "," + register.kelurahanLst.Text+ "," +register.txtOutletsAlamat.Text,register.txtOutletsName.Text, register.txtOutletsPhonr.Text))
                {
                    LoginPage login = new LoginPage();
                    login.Show();
                    register.Close();
                }
            }
            else
            {
                var bc = new BrushConverter();
                register.lblError.Content = error;
                register.lblError.Background = (Brush)bc.ConvertFrom("#e74c3c");
                register.UpdateLayout();
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
