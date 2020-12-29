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
        public void GetOrders() {
            orders.Clear();
            query = "select orders.id,tanggal, users.name, total_harga, berat, layanan, status from orders join users on users.id = orders.id_users join status on status.id = orders.status_id where id_outlets = 2";
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
    }
}
