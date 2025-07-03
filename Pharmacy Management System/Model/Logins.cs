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
    public class Logins
    {
        SqlDbDataAccess sda = new SqlDbDataAccess();

        public void AddLogin(Login login)
        {
            SqlCommand cmd = sda.GetQuery("INSERT INTO Login VALUES(@userId, @password, @role, @securityAns);");

            cmd.Parameters.AddWithValue("@userId", login.UserId);
            cmd.Parameters.AddWithValue("@password", login.Password);
            cmd.Parameters.AddWithValue("@role", login.Role);
            cmd.Parameters.AddWithValue("@securityAns", login.SecurityAns);

            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public void UpdateLogin(Login login)
        {
            SqlCommand cmd = sda.GetQuery("UPDATE Login SET password=@password, role=@role, securityAns=@securityAns WHERE userId=@userId;");

            cmd.Parameters.AddWithValue("@userId", login.UserId);
            cmd.Parameters.AddWithValue("@password", login.Password);
            cmd.Parameters.AddWithValue("@role", login.Role);
            cmd.Parameters.AddWithValue("@securityAns", login.SecurityAns);

            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public void DeleteLogin(string userId)
        {
            SqlCommand cmd = sda.GetQuery("DELETE FROM Login WHERE userId=@userId;");
            cmd.Parameters.AddWithValue("@userId", userId);

            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public Login SearchLogin(string userId, string password)
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM Login WHERE userId=@userId AND password=@password;");
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.CommandType = CommandType.Text;

            List<Login> loginList = GetData(cmd);

            if (loginList.Count > 0)
            {
                return loginList[0];
            }
            else
            {
                return null;
            }
        }

        public List<Login> GetAllLogin()
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM Login;");
            cmd.CommandType = CommandType.Text;
            return GetData(cmd);
        }

        private List<Login> GetData(SqlCommand cmd)
        {
            List<Login> loginList = new List<Login>();
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    Login login = new Login
                    {
                        UserId = reader.GetString(0),
                        Password = reader.GetString(1),
                        Role = reader.GetInt32(2),
                        SecurityAns = reader.GetString(3)
                    };

                    loginList.Add(login);
                }

                reader.Close();
            }

            cmd.Connection.Close();
            return loginList;
        }
    }
}
