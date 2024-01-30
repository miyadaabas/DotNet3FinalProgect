using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    internal class DBConnection
    {
        internal static SqlConnection getConnection()
        {

            string connectionString = "data source=localhost;initial catalog=bikedb;integrated security=true";
            SqlConnection conn = new SqlConnection(connectionString);

            return conn;
        }
    }
}
