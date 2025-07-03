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
    public partial class SupplierOperationFrame : Form
    {
        Login login;

        public SupplierOperationFrame(Login login)
        {
            InitializeComponent();
            this.login = login;
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

        private void SupplierOperationFrame_Load_1(object sender, EventArgs e)
        {
            SupplierController sc = new SupplierController();
            dataGridView1.DataSource = sc.GetAllSupplier();

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

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                string id = textBox1.Text;

                SupplierController sc = new SupplierController();
                Supplier s = sc.SearchSupplierById(id);

                if (s != null)
                {
                    MessageBox.Show("Supplier Found");

                    textBox1.Text = s.SupplierId;
                    textBox2.Text = s.Company;
                    textBox3.Text = s.Contact;
                    textBox4.Text = s.Email;
                    textBox5.Text = s.Address;

                    textBox1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Supplier Not Found");
                }

                dataGridView1.DataSource = sc.GetAllSupplier();
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                string id = textBox1.Text;
                if(id == "" || id == null)
                {
                    MessageBox.Show("Please enter a valid Supplier ID to delete.");
                    return;
                }
                SupplierController sc = new SupplierController();
                sc.DeleteSupplier(id);

                MessageBox.Show("Supplier Removed Successfully");

                dataGridView1.DataSource = sc.GetAllSupplier();
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                string id = textBox1.Text;
                string company = textBox2.Text;
                string contact = textBox3.Text;
                string email = textBox4.Text;
                string address = textBox5.Text;
                string adminId = login.UserId;

                Supplier s = new Supplier(id, company, contact, email, address, adminId);
                SupplierController sc = new SupplierController();
                sc.UpdateSupplier(s);

                MessageBox.Show("Supplier Updated Successfully");

                dataGridView1.DataSource = sc.GetAllSupplier();
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string id = textBox1.Text;
                string company = textBox2.Text;
                string contact = textBox3.Text;
                string email = textBox4.Text;
                string address = textBox5.Text;
                string adminId = login.UserId;

                if (id!="" && company!="" && contact!="" && email!="" && address!="" )
                {
                    Supplier s = new Supplier(id, company, contact, email, address, adminId);
                    SupplierController sc = new SupplierController();
                    sc.AddSupplier(s);

                    MessageBox.Show("Supplier Added Successfully");

                    dataGridView1.DataSource = sc.GetAllSupplier();
                    dataGridView1.Refresh();
                }

                else 
                {
                    MessageBox.Show("please fill the data properly");
                }
    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
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

        
    }
}
