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
    public class Employees
    {
        SqlDbDataAccess sda = new SqlDbDataAccess();

        public void AddEmployee(Employee e)
        {
            SqlCommand cmd1 = sda.GetQuery("INSERT INTO Employee VALUES(@id, @name, @role, @email, @phone, @adminId, @password, @securityAns);");
            cmd1.Parameters.AddWithValue("@id", e.EmployeeId);
            cmd1.Parameters.AddWithValue("@name", e.Name);
            cmd1.Parameters.AddWithValue("@role", e.Role);
            cmd1.Parameters.AddWithValue("@email", e.Email);
            cmd1.Parameters.AddWithValue("@phone", e.Phone);
            cmd1.Parameters.AddWithValue("@adminId", e.AdminId);
            cmd1.Parameters.AddWithValue("@password", e.Password);
            cmd1.Parameters.AddWithValue("@securityAns", e.SecurityAns);

            cmd1.CommandType = CommandType.Text;
            cmd1.Connection.Open();
            cmd1.ExecuteNonQuery();
            cmd1.Connection.Close();

        }

        public void UpdateEmployee(Employee e)
        {
            
            SqlCommand cmd1 = sda.GetQuery("UPDATE Employee SET name = @name, role = @role, email = @email, phone = @phone, adminId = @adminId, password = @password, securityAns = @securityAns WHERE employeeId = @id;");
            cmd1.Parameters.AddWithValue("@id", e.EmployeeId);
            cmd1.Parameters.AddWithValue("@name", e.Name);
            cmd1.Parameters.AddWithValue("@role", e.Role);
            cmd1.Parameters.AddWithValue("@email", e.Email);
            cmd1.Parameters.AddWithValue("@phone", e.Phone);
            cmd1.Parameters.AddWithValue("@adminId", e.AdminId);
            cmd1.Parameters.AddWithValue("@password", e.Password);
            cmd1.Parameters.AddWithValue("@securityAns", e.SecurityAns);

            cmd1.CommandType = CommandType.Text;
            cmd1.Connection.Open();
            cmd1.ExecuteNonQuery();
            cmd1.Connection.Close();


        }

        public void DeleteEmployee(string id)
        {
            
            SqlCommand cmd1 = sda.GetQuery("DELETE FROM Employee WHERE employeeId = @id;");
            cmd1.Parameters.AddWithValue("@id", id);

            cmd1.CommandType = CommandType.Text;
            cmd1.Connection.Open();
            cmd1.ExecuteNonQuery();
            cmd1.Connection.Close();


        }

        private List<Employee> GetData(SqlCommand cmd)
        {
            List<Employee> employeeList = new List<Employee>();
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    Employee emp = new Employee
                    {
                        EmployeeId = reader.GetString(0),
                        Name = reader.GetString(1),
                        Role = reader.GetString(2),
                        Email = reader.GetString(3),
                        Phone = reader.GetString(4),
                        AdminId = reader.GetString(5),
                        Password = reader.GetString(6),
                        SecurityAns = reader.GetString(7)
                    };

                    employeeList.Add(emp);
                }
            }

            cmd.Connection.Close();
            return employeeList;
        }

        public Employee SearchEmployeeById(string id)
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM Employee WHERE employeeId=@id;");
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = CommandType.Text;

            List<Employee> list = GetData(cmd);

            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }



        public List<Employee> GetAllEmployee()
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM Employee;");
            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Employee> list = new List<Employee>();
            while (reader.Read())
            {
                Employee emp = new Employee
                {
                    EmployeeId = reader.GetString(0),
                    Name = reader.GetString(1),
                    Role = reader.GetString(2),
                    Email = reader.GetString(3),
                    Phone = reader.GetString(4),
                    AdminId = reader.GetString(5),
                    Password = reader.GetString(6),
                    SecurityAns = reader.GetString(7)
                };

                list.Add(emp);
            }

            cmd.Connection.Close();
            return list;
        }
    }
}
