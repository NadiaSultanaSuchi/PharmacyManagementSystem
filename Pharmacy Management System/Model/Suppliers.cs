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
    public class Suppliers
    {
        SqlDbDataAccess sda = new SqlDbDataAccess();

        public void AddSupplier(Supplier s)
        {
            SqlCommand cmd = sda.GetQuery("INSERT INTO Supplier VALUES(@id, @company, @contact, @email, @address, @adminId);");
            cmd.Parameters.AddWithValue("@id", s.SupplierId);
            cmd.Parameters.AddWithValue("@company", s.Company);
            cmd.Parameters.AddWithValue("@contact", s.Contact);
            cmd.Parameters.AddWithValue("@email", s.Email);
            cmd.Parameters.AddWithValue("@address", s.Address);
            cmd.Parameters.AddWithValue("@adminId",s.AdminId);

            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public void UpdateSupplier(Supplier s)
        {
            SqlCommand cmd = sda.GetQuery("UPDATE Supplier SET company=@company, contact=@contact, email=@email, address=@address, adminId=adminId WHERE supplierId=@id;");
            cmd.Parameters.AddWithValue("@id", s.SupplierId);
            cmd.Parameters.AddWithValue("@company", s.Company);
            cmd.Parameters.AddWithValue("@contact", s.Contact);
            cmd.Parameters.AddWithValue("@email", s.Email);
            cmd.Parameters.AddWithValue("@address", s.Address);
            cmd.Parameters.AddWithValue("@adminId",s.AdminId);

            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public void DeleteSupplier(string id)
        {
            SqlCommand cmd = sda.GetQuery("DELETE FROM Supplier WHERE supplierId=@id;");
            cmd.Parameters.AddWithValue("@id", id);

            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        private List<Supplier> GetData(SqlCommand cmd)
        {
            List<Supplier> supplierList = new List<Supplier>();
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    Supplier s = new Supplier
                    {
                        SupplierId = reader.GetString(0),
                        Company = reader.GetString(1),
                        Contact = reader.GetString(2),
                        Email = reader.GetString(3),
                        Address = reader.GetString(4),
                        AdminId = reader.GetString(5)
                    };

                    supplierList.Add(s);
                }
            }

            cmd.Connection.Close();
            return supplierList;
        }



        public Supplier SearchSupplierById(string id)
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM Supplier WHERE supplierId=@id;");
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = CommandType.Text;

            List<Supplier> list = GetData(cmd);

            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }



        public List<Supplier> GetAllSupplier()
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM Supplier;");
            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Supplier> list = new List<Supplier>();

            while (reader.Read())
            {
                Supplier s = new Supplier
                {
                    SupplierId = reader.GetString(0),
                    Company = reader.GetString(1),
                    Contact = reader.GetString(2),
                    Email = reader.GetString(3),
                    Address = reader.GetString(4),
                    AdminId = reader.GetString(5)
                };

                list.Add(s);
            }

            cmd.Connection.Close();
            return list;
        }
    }
}
