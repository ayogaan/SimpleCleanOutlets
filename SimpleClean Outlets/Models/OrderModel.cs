using SimpleClean_Outlets.ItemWrapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClean_Outlets.Models
{
    class OrderModel:Connection
    {
        private SqlCommand command;
        private SqlDataReader reader;
        private string query;
        public List<OrderWrapper> orders = new List<OrderWrapper>();
        public static List<String> Status = new List<String>();
        public static List<String> StatusId = new List<String>();
        public void GetOrders() {
            orders.Clear();
            query = "select orders.id,tanggal, users.name, total_harga, berat, layanan, status from orders join users on users.id = orders.id_users join status on status.id = orders.status_id where id_outlets =" + AccountModel.OutletsId;
            openConnSql();
            sqlConnection.Open();
            using (command = new SqlCommand(query, sqlConnection))
            {
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orders.Add(new OrderWrapper(
                            reader["id"].ToString(),
                            reader["total_harga"].ToString(),
                            reader["tanggal"].ToString(),
                            reader["berat"].ToString(),
                            reader["layanan"].ToString(),
                            reader["status"].ToString(),
                            reader["name"].ToString()                            
                            ));
                    }

                }
            }
        }
        public bool UpdateOrder(string status, string idOrder, string berat)
        {

            bool flag = false;
            
            query = "update orders set status_id = '" + StatusId[Int32.Parse(status)] + "' ,total_harga="+Int32.Parse(berat)*4000+", berat='"+berat+"' where id=" + idOrder;
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
                        Console.WriteLine("update error : " + e.ToString());
                    }
                }
            }
            return flag;
        }

        public void GetStatusList() {
            Status.Clear();
            openConnSql();
            sqlConnection.Open();
            query = "select * from status";
            using (command = new SqlCommand(query, sqlConnection))
            {
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Status.Add(
                            reader["status"].ToString()                            
                            );
                        StatusId.Add(
                            reader["id"].ToString()
                            );
                    }

                }
            }
        }
    }
}
