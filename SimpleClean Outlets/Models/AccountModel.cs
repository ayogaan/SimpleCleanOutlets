using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClean_Outlets.Models
{
    class AccountModel:Connection
    {
        private string query;
        private string message;
        private string uname;
        private string pass;
        public string Uname { get { return uname; } set { uname = value; } }
        public string Pass { get { return pass; } set { pass = value; } }

        public string Message { get { return message; } }
        private SqlCommand command;
        private SqlDataReader reader;
        public bool Login() {
            query = "select * from account join outlets on outlets.id_account = account.id where privileges = 1 and username ='"+uname+"'";
            Console.WriteLine(query);
            openConnSql();
            sqlConnection.Open();
            int count = 0;
            using (command = new SqlCommand(query, sqlConnection))
            {
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        count++;
                        if (count > 0)
                        {
                        }
                    }
                }
            }
                        return true;
        }
    }
}
