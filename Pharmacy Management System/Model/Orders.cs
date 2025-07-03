using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Management_System.Model
{
    public class Orders
    {
        SqlDbDataAccess sda = new SqlDbDataAccess();

        public int AddOrder(Order order)
        {
            int orderId = 0;

            SqlCommand cmd = sda.GetQuery("INSERT INTO [Order] ( TotalAmount, PaidAmount, ChangeAmount) VALUES ( @totalAmount, @paidAmount, @changeAmount)");
            //cmd.Parameters.AddWithValue("@orderId", order.OrderId);
            cmd.Parameters.AddWithValue("@totalAmount", order.TotalAmount);
            cmd.Parameters.AddWithValue("@paidAmount", order.PaidAmount);
            cmd.Parameters.AddWithValue("@changeAmount", order.ChangeAmount);
            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                orderId = Convert.ToInt32(result);
            }
            /*else
            {
                throw new Exception("Failed to insert order.");
            }*/
            cmd.Connection.Close();
            return orderId;
        }

        public List<Order> GetAllOrder()
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM [Order];");
            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Order> list = new List<Order>();

            while (reader.Read())
            {
                Order m = new Order
                {
                    OrderId = reader.GetInt32(0),
                    TotalAmount = (float)reader.GetDouble(1),
                    PaidAmount = (float)reader.GetDouble(2),
                    ChangeAmount = (float)reader.GetDouble(3)                  
                };

                list.Add(m);
            }

            cmd.Connection.Close();
            return list;
        }
    }
}
