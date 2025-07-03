using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Pharmacy_Management_System.Model
{
    public class SqlDbDataAccess
    {
        private const string connectionString = @"Data Source=LAPTOP-59ALHS65\SQLEXPRESS; Initial Catalog=PMS 5 (1); Trusted_Connection=True";

        public SqlCommand GetQuery(string query) 
        {
            var connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query);
            cmd.Connection = connection;

            return cmd;
        }
    }
}
