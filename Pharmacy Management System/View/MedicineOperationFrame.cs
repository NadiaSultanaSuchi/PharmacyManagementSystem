using Pharmacy_Management_System.Controller;
using Pharmacy_Management_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy_Management_System.View
{
    public partial class MedicineOperationFrame : Form
    {
        Login login;

        public MedicineOperationFrame(Login login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void MedicineOperationFrame_Load_1(object sender, EventArgs e)
        {
            MedicineController mc = new MedicineController();
            dataGridView1.DataSource = mc.GetAllMedicine();

            

        }

        private void button6_Click_1(object sender, EventArgs e)
        {

            if (login.Role == 1)
            {
                this.Hide();
                AdminHomeFrame ahf = new AdminHomeFrame(login);
                ahf.Show();
            }

            else
            {
                this.Hide();
                EmployeeHomeFrame ehf = new EmployeeHomeFrame(login);
                ehf.Show();
            }

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox1.Enabled = true;
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dvr = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = dvr.Cells[0].Value.ToString();
                textBox2.Text = dvr.Cells[1].Value.ToString();
                textBox3.Text = dvr.Cells[2].Value.ToString();
                textBox4.Text = dvr.Cells[3].Value.ToString();
                textBox5.Text = dvr.Cells[4].Value.ToString();
                textBox1.Enabled = false;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                string id = textBox1.Text;
                if (string.IsNullOrWhiteSpace(id))
                {
                    MessageBox.Show("Please enter a valid Medicine ID to delete.");
                    return;
                }

                MedicineController mc = new MedicineController();
                mc.DeleteMedicine(id);

                MessageBox.Show("Medicine Removed Successfully");
                dataGridView1.DataSource = mc.GetAllMedicine();
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                string id = textBox1.Text;
                if (string.IsNullOrWhiteSpace(id))
                {
                    MessageBox.Show("Please enter a Medicine ID to search.");
                    return;
                }

                MedicineController mc = new MedicineController();
                Medicine m = mc.SearchMedicineById(id);

                if (m != null)
                {
                    MessageBox.Show("Medicine Found");

                    textBox1.Text = m.MedicineId;
                    textBox2.Text = m.Name;
                    textBox3.Text = m.Quantity.ToString();
                    textBox4.Text = m.Price.ToString();
                    textBox5.Text = m.ExpiryDate;
                    textBox1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Medicine Not Found");
                }

                dataGridView1.DataSource = mc.GetAllMedicine();
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                string id = textBox1.Text.Trim();
                string name = textBox2.Text.Trim();
                string quantityText = textBox3.Text.Trim();
                string priceText = textBox4.Text.Trim();
                string expiry = textBox5.Text.Trim();
                string employeeId = login.UserId;

                if (string.IsNullOrWhiteSpace(id) ||
                    string.IsNullOrWhiteSpace(name) ||
                    string.IsNullOrWhiteSpace(quantityText) ||
                    string.IsNullOrWhiteSpace(priceText) ||
                    string.IsNullOrWhiteSpace(expiry))
                {
                    MessageBox.Show("Please fill all fields properly.");
                    return;
                }

                int quantity = Convert.ToInt32(quantityText);
                float price = Convert.ToSingle(priceText);

                Medicine m = new Medicine(id, name, quantity, price, expiry, employeeId);
                MedicineController mc = new MedicineController();
                mc.UpdateMedicine(m);

                MessageBox.Show("Medicine Updated Successfully");
                dataGridView1.DataSource = mc.GetAllMedicine();
                dataGridView1.Refresh();
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string id = textBox1.Text.Trim();
                string name = textBox2.Text.Trim();
                string quantityText = textBox3.Text.Trim();
                string priceText = textBox4.Text.Trim();
                string expiry = textBox5.Text.Trim();
                string employeeId = login.UserId;

                if (string.IsNullOrWhiteSpace(id) ||
                    string.IsNullOrWhiteSpace(name) ||
                    string.IsNullOrWhiteSpace(quantityText) ||
                    string.IsNullOrWhiteSpace(priceText) ||
                    string.IsNullOrWhiteSpace(expiry))
                {
                    MessageBox.Show("Please fill all fields properly.");
                    return;
                }

                int quantity = Convert.ToInt32(quantityText);
                float price = Convert.ToSingle(priceText);

                Medicine m = new Medicine(id, name, quantity, price, expiry, employeeId);
                MedicineController mc = new MedicineController();
                mc.AddMedicine(m);

                MessageBox.Show("Medicine Added Successfully");
                dataGridView1.DataSource = mc.GetAllMedicine();
                dataGridView1.Refresh();
            }
            catch (FormatException)
            {
                MessageBox.Show("Quantity and Price must be numeric.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
