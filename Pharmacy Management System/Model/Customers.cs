using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Pharmacy_Management_System.Model
{
    public class Customers
    {
        SqlDbDataAccess sda = new SqlDbDataAccess();

        public void AddCustomer(Customer c)
        {
            SqlCommand cmd = sda.GetQuery("INSERT INTO Customer VALUES(@customerId, @firstName, @lastName, @gender, @age, @employeeId, @password, @securityAns);");
            cmd.Parameters.AddWithValue("@customerId", c.CustomerId);
            cmd.Parameters.AddWithValue("@firstName", c.FirstName);
            cmd.Parameters.AddWithValue("@lastName", c.LastName);
            cmd.Parameters.AddWithValue("@gender", c.Gender);
            cmd.Parameters.AddWithValue("@age", c.Age);
            cmd.Parameters.AddWithValue("@employeeId", c.EmployeeId);
            cmd.Parameters.AddWithValue("@password", c.Password);
            cmd.Parameters.AddWithValue("@securityAns", c.SecurityAns);
            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public void UpdateCustomer(Customer c)
        {
            SqlCommand cmd = sda.GetQuery("UPDATE Customer SET firstName=@firstName, lastName=@lastName, gender=@gender, age=@age, employeeId=@employeeId, password=@password, securityAns=@securityAns WHERE customerId=@customerId;");
            cmd.Parameters.AddWithValue("@customerId", c.CustomerId);
            cmd.Parameters.AddWithValue("@firstName", c.FirstName);
            cmd.Parameters.AddWithValue("@lastName", c.LastName);
            cmd.Parameters.AddWithValue("@gender", c.Gender);
            cmd.Parameters.AddWithValue("@age", c.Age);
            cmd.Parameters.AddWithValue("@employeeId", c.EmployeeId);
            cmd.Parameters.AddWithValue("@password", c.Password);
            cmd.Parameters.AddWithValue("@securityAns", c.SecurityAns);
            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public void DeleteCustomer(string id)
        {
            SqlCommand cmd = sda.GetQuery("DELETE FROM Customer WHERE customerId=@id;");
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        private List<Customer> GetData(SqlCommand cmd)
        {
            List<Customer> customerList = new List<Customer>();
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    Customer c = new Customer
                    {
                        CustomerId = reader.GetString(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Gender = reader.GetString(3),
                        Age = reader.GetInt32(4),
                        EmployeeId = reader.GetString(5),
                        Password = reader.GetString(6),
                        SecurityAns = reader.GetString(7)
                    };

                    customerList.Add(c);
                }
            }

            cmd.Connection.Close();
            return customerList;
        }



        public Customer SearchCustomerById(string id)
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM Customer WHERE customerId=@id;");
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = CommandType.Text;

            List<Customer> list = GetData(cmd);

            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }



        public List<Customer> GetAllCustomers()
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM Customer;");
            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();

            List<Customer> list = new List<Customer>();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Customer c = new Customer
                    {
                        CustomerId = reader["customerId"].ToString(),
                        FirstName = reader["firstName"].ToString(),
                        LastName = reader["lastName"].ToString(),
                        Gender = reader["gender"].ToString(),
                        Age = Convert.ToInt32(reader["age"]),
                        EmployeeId = reader["employeeId"].ToString(),
                        Password = reader["password"].ToString(),
                        SecurityAns = reader["securityAns"].ToString()
                    };


                    list.Add(c);
                }
            }

            cmd.Connection.Close();
            return list;
        }



    }
}
