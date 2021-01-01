using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClean_Outlets.Models
{
    class AccountModel:Connection
    {
        private string query;
        private string message;
        private string uname;
        private static string outlets;
        private static string id;
        private string pass;
        public string Uname { get { return uname; } set { uname = value; } }
        public string Pass { get { return pass; } set { pass = value; } }
        public static string Outlets { get { return outlets; } }
        public static string OutletsId { get { return id; } }

        public string Message { get { return message; } }
        private SqlCommand command;
        private SqlDataReader reader;
        public bool Login() {
            query = "select * from account join outlets on outlets.id_account = account.id where privileges = 1 and username ='"+uname+"'";
            Console.WriteLine(query);
            openConnSql();
            sqlConnection.Open();
            int count = 0;
            bool loginStat = false;
            bool unameVal = false;
            string name = null, address = null, level = null, phoneNum = null, accountId = null, outletsId = null, truePass = null;
            using (command = new SqlCommand(query, sqlConnection))
            {
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        count++;
                        if (count > 0)
                        {
                            truePass = reader["password"].ToString();
                            name = reader["name"].ToString();
                            phoneNum = reader["phone_num"].ToString();
                            address = reader["address"].ToString();
                            outletsId = reader["id"].ToString();
                            level = reader["privileges"].ToString();
                            unameVal = true;
                            break;
                        }
                        
                    }
                    if ((unameVal) && (level == "1"))
                    {
                        if (pass == truePass)
                        {
                            loginStat = true;
                            outlets = name;
                            id = outletsId;
                        }
                        else
                        {
                            message = "password salah";
                        }
                    }
                    else
                    {
                        message = "akun tidak terdaftar";
                        Console.WriteLine(message);
                    }
                }
            }
                        return loginStat;
        }
        public bool Register(string uname, string pass, string address, string outletsName, string phone)
        {
            bool flag = false;
            query = "insert into account values ('"+uname+"', '"+pass+"','1')";
            Console.WriteLine(query);
            openConnSql();
            sqlConnection.Open();
            using (command = new SqlCommand(query, sqlConnection))
            {
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        flag = true;
                        RegisterCont(uname,address,outletsName, phone);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("update error : " + e.ToString());
                    }
                }
            }
            return flag;
        }

        public bool RegisterCont(string username,string address, string outletsName, string phone)
        {
            bool flag = false;
            query = "insert into outlets values ('"+ GetUsernameId(username) +"','"+outletsName+"','"+address+"','"+phone+"')";
            
            Console.WriteLine(query);
            openConnSql();
            sqlConnection.Open();
            using (command = new SqlCommand(query, sqlConnection))
            {
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        flag = true;                       
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("insert error : " + e.ToString());
                    }
                }
            }
            return flag;
        }
        public string GetUsernameId(string username) {
            query = "select id from account where username ='"+username+"'";
            string id = "";
            openConnSql();
            sqlConnection.Open();
            using (command = new SqlCommand(query, sqlConnection))
            {
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = reader["Id"].ToString();
                    }
                }
            }
                        return id;
        }
        
    }
}
