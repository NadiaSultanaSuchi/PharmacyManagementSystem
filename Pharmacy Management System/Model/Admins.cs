using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Pharmacy_Management_System.Model
{
    public class Admins
    {
        SqlDbDataAccess sda = new SqlDbDataAccess();

        public void AddAdmin(Admin a)
        {
            SqlCommand cmd = sda.GetQuery("INSERT INTO Admin VALUES(@id, @name, @email, @phone, @branch, @password, @securityAns);");
            cmd.Parameters.AddWithValue("@id", a.AdminId);
            cmd.Parameters.AddWithValue("@name", a.Name);
            cmd.Parameters.AddWithValue("@email", a.Email);
            cmd.Parameters.AddWithValue("@phone", a.Phone);
            cmd.Parameters.AddWithValue("@branch",a.Branch);
            cmd.Parameters.AddWithValue("@password",a.Password);
            cmd.Parameters.AddWithValue("@securityAns",a.SecurityAns);
            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public void UpdateAdmin(Admin a)
        {
            SqlCommand cmd = sda.GetQuery("UPDATE Admin SET name=@name, email=@email, phone=@phone, branch=@branch, password=@password , securityAns = @securityAns WHERE adminId=@id;");
            cmd.Parameters.AddWithValue("@id", a.AdminId);
            cmd.Parameters.AddWithValue("@name", a.Name);
            cmd.Parameters.AddWithValue("@email", a.Email);
            cmd.Parameters.AddWithValue("@phone", a.Phone);
            cmd.Parameters.AddWithValue("@branch",a.Branch);
            cmd.Parameters.AddWithValue("@password", a.Password);
            cmd.Parameters.AddWithValue("@securityAns", a.SecurityAns);
            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public void DeleteAdmin(string id)
        {
            SqlCommand cmd = sda.GetQuery("DELETE FROM Admin WHERE adminId=@id;");
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        private List<Admin> GetData(SqlCommand cmd)
        {
            List<Admin> adminList = new List<Admin>();
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    Admin a = new Admin
                    {
                        AdminId = reader.GetString(0),
                        Name = reader.GetString(1),
                        Email = reader.GetString(2),
                        Phone = reader.GetString(3),
                        Branch = reader.GetString(4)
                    };

                    adminList.Add(a);
                }
            }

            cmd.Connection.Close();
            return adminList;
        }

        public Admin SearchAdminById(string id)
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM Admin WHERE adminId=@id;");
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = CommandType.Text;

            List<Admin> list = GetData(cmd);

            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }


        public List<Admin> GetAllAdmins()
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM Admin;");
            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            List<Admin> list = new List<Admin>();

            while (reader.Read())
            {
                string adminId = reader.GetString(0);
                string name = reader.GetString(1);
                string email = reader.GetString(2);
                string phone = reader.GetString(3);
                string branch = reader.GetString(4);
                string password = reader.GetString(5);
                string securityAns = reader.GetString(6);

                Admin a = new Admin(adminId, name, email, phone, branch,password,securityAns);
                list.Add(a);
            }

            cmd.Connection.Close();
            return list;
        }
    }
}
