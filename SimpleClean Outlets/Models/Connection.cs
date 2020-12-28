using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClean_Outlets.Models
{
    class Connection
    {
        public SqlConnection sqlConnection;
        public void openConnSql()
        {
            string strConn = "Data Source=localhost;Database=simple_clean;User Id=arfany;Password=arfan;";
            try
            {
                sqlConnection = new SqlConnection(strConn);

            }
            catch (Exception e)
            {
                Console.Write("ERROR : " + e.ToString());
            }
        }
    }
}
