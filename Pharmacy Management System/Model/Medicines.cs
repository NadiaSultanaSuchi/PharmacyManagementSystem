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
    public class Medicines
    {
        SqlDbDataAccess sda = new SqlDbDataAccess();

        public void AddMedicine(Medicine m)
        {
            SqlCommand cmd = sda.GetQuery("INSERT INTO Medicine VALUES(@id, @name, @quantity, @price, @expiry, @employeeId);");
            cmd.Parameters.AddWithValue("@id", m.MedicineId);
            cmd.Parameters.AddWithValue("@name", m.Name);
            cmd.Parameters.AddWithValue("@quantity", m.Quantity);
            cmd.Parameters.AddWithValue("@price", m.Price);
            cmd.Parameters.AddWithValue("@expiry", m.ExpiryDate);
            cmd.Parameters.AddWithValue("@employeeId", m.EmployeeId);

            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public void UpdateMedicine(Medicine m)
        {
            SqlCommand cmd = sda.GetQuery("UPDATE Medicine SET name=@name, quantity=@quantity, price=@price, expiryDate=@expiry, employeeId=@employeeId WHERE medicineId=@id;");
            cmd.Parameters.AddWithValue("@id", m.MedicineId);
            cmd.Parameters.AddWithValue("@name", m.Name);
            cmd.Parameters.AddWithValue("@quantity", m.Quantity);
            cmd.Parameters.AddWithValue("@price", m.Price);
            cmd.Parameters.AddWithValue("@expiry", m.ExpiryDate);
            cmd.Parameters.AddWithValue("@employeeId", m.EmployeeId);

            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public void DeleteMedicine(string id)
        {
            SqlCommand cmd = sda.GetQuery("DELETE FROM Medicine WHERE medicineId=@id;");
            cmd.Parameters.AddWithValue("@id", id);

            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        private List<Medicine> GetData(SqlCommand cmd)
        {
            List<Medicine> medicineList = new List<Medicine>();
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    Medicine m = new Medicine
                    {
                        MedicineId = reader.GetString(0),
                        Name = reader.GetString(1),
                        Quantity = reader.GetInt32(2),
                        Price = (float)reader.GetDouble(3),
                        ExpiryDate = reader.GetString(4),
                        EmployeeId = reader.GetString(5)
                    };

                    medicineList.Add(m);
                }
            }

            cmd.Connection.Close();
            return medicineList;
        }

        public Medicine SearchMedicineById(string id)
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM Medicine WHERE medicineId=@id;");
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = CommandType.Text;

            List<Medicine> list = GetData(cmd);

            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }

        public Medicine SearchMedicineByName(string name)
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM Medicine WHERE name = @name;");
            cmd.Parameters.AddWithValue("@name", name);
            cmd.CommandType = CommandType.Text;

            List<Medicine> list = GetData(cmd);

            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }


        public void ReduceQuantity(string medicineId, int quantity)
        {
            SqlCommand cmd = sda.GetQuery("UPDATE Medicine SET Quantity = Quantity - @qty WHERE MedicineId = @id");
            cmd.Parameters.AddWithValue("@qty", quantity);
            cmd.Parameters.AddWithValue("@id", medicineId);
            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public List<Medicine> GetAllMedicine()
        {
            SqlCommand cmd = sda.GetQuery("SELECT * FROM Medicine;");
            cmd.CommandType = CommandType.Text;
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<Medicine> list = new List<Medicine>();

            while (reader.Read())
            {
                Medicine m = new Medicine
                {
                    MedicineId = reader.GetString(0),
                    Name = reader.GetString(1),
                    Quantity = reader.GetInt32(2),
                    Price = (float)reader.GetDouble(3),
                    ExpiryDate = reader.GetString(4),
                    EmployeeId = reader.GetString(5)
                };

                list.Add(m);
            }

            cmd.Connection.Close();
            return list;
        }
    }
}
