using SimpleClean_Outlets.ItemWrapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClean_Outlets.Models
{
    class TransactionsModel:Connection
    {
        private SqlCommand command;
        private SqlDataReader reader;
        private string query;
        private string omset;
        public string Omset { get { return omset; } }
        public List<TransactionWraper> transactions = new List<TransactionWraper>();
        public void GetTransaction()
        {
            transactions.Clear();            
            openConnSql();
            sqlConnection.Open();
            query = "select total_harga,users.name,invoice.date ,invoice.metode_bayar, orders.id, invoice.status from invoice join orders on orders.id = invoice.id_order join users on users.id=orders.id_users where orders.id_outlets="+AccountModel.OutletsId;
            using (command = new SqlCommand(query, sqlConnection))
            {
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transactions.Add(new TransactionWraper(
                            reader["id"].ToString(),
                            reader["date"].ToString(),
                            reader["name"].ToString(),
                            reader["metode_bayar"].ToString(),
                            reader["status"].ToString(),
                            reader["total_harga"].ToString()
                            ));
                    }
                   
                }
            }
            
        }

        public void GetOmzet() {
            query = "select sum(orders.total_harga) as [total] from invoice join orders on orders.id = invoice.id_order  where orders.id_outlets =" + AccountModel.OutletsId;
            openConnSql();
            sqlConnection.Open();
            using (command = new SqlCommand(query, sqlConnection))
            {
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        omset = reader["total"].ToString();                    
                    }
                }
            }


        }

        public bool ConfirmPayment(string PaymentId,string status) {
            bool flag = false;
            query = "update invoice set status = '"+status+"' where id_order ="+PaymentId;
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
                        Console.WriteLine("update error : " + e.ToString());
                    }
                }
            }
            return flag;
        }
    }

    
}
