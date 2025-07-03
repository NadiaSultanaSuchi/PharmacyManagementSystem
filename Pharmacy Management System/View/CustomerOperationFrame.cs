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
    public partial class CustomerOperationFrame : Form
    {
        Login login1;
        public CustomerOperationFrame(Login login1)
        {
            InitializeComponent();
            this.login1 = login1;
        }

        SqlDbDataAccess sda = new SqlDbDataAccess();
        private void CustomerOperationFrame_Load(object sender, EventArgs e)
        {
            CustomerController cc = new CustomerController();
            dataGridView1.DataSource = cc.GetAllCustomers();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dvr = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = dvr.Cells[0].Value.ToString();
                textBox2.Text = dvr.Cells[1].Value.ToString();
                textBox3.Text = dvr.Cells[2].Value.ToString();

                string gender = dvr.Cells[3].Value.ToString();
                if (gender == "Male") radioButton1.Checked = true;
                else if (gender == "Female") radioButton2.Checked = true;

                textBox4.Text = dvr.Cells[4].Value.ToString();
                
                textBox5.Text = dvr.Cells[6].Value.ToString();
                textBox6.Text = dvr.Cells[7].Value.ToString();
                textBox1.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (login1.Role == 1)
            {
                this.Hide();
                AdminHomeFrame ahf = new AdminHomeFrame(login1);
                ahf.Show();
            }

            else
            {
                this.Hide();
                EmployeeHomeFrame ehf = new EmployeeHomeFrame(login1);
                ehf.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string customerId = textBox1.Text;
                string firstName = textBox2.Text;
                string lastName = textBox3.Text;
                string password = textBox5.Text;
                string securityAns = textBox6.Text;

                string gender = "";
                if (radioButton1.Checked)
                    gender = "Male";
                else if (radioButton2.Checked)
                    gender = "Female";

                if (customerId != "" && firstName != "" && lastName != "")
                {
                    int age = Convert.ToInt32(textBox4.Text);
                    string employeeId = login1.UserId;

                    Customer c = new Customer(customerId, firstName, lastName, gender, age, employeeId, password, securityAns);
                    CustomerController cc = new CustomerController();
                    cc.AddCustomer(c);

                    Login login = new Login(customerId,password,3,securityAns);  
                    LoginController lc = new LoginController();
                    lc.AddLogin(login);

                    MessageBox.Show("Customer Added Successfully");
                    dataGridView1.DataSource = cc.GetAllCustomers();
                    dataGridView1.Refresh();
                }

                else
                {
                    MessageBox.Show("please fill all the data");
                }
   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string customerId = textBox1.Text;
                string firstName = textBox2.Text;
                string lastName = textBox3.Text;
                string password = textBox5.Text;
                string securityAns = textBox6.Text;

                string gender = "";
                if (radioButton1.Checked)
                    gender = "Male";
                else if (radioButton2.Checked)
                    gender = "Female";

                int age = Convert.ToInt32(textBox4.Text);
                string employeeId = login1.UserId;
                Customer c = new Customer(customerId, firstName, lastName, gender, age, employeeId, password, securityAns);
                CustomerController cc = new CustomerController();
                cc.UpdateCustomer(c);

                Login login = new Login(customerId, password, 3, securityAns);
                LoginController lc = new LoginController();
                lc.UpdateLogin(login);

                MessageBox.Show("Customer Updated Successfully");
                dataGridView1.DataSource = cc.GetAllCustomers();
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string customerId = textBox1.Text;
                if (string.IsNullOrEmpty(customerId))
                {
                    MessageBox.Show("Please enter a Customer ID to delete.");
                    return;
                }
                CustomerController cc = new CustomerController();
                cc.DeleteCustomer(customerId);

                LoginController lc = new LoginController();
                lc.DeleteLogin(customerId);

                MessageBox.Show("Customer Removed Successfully");
                dataGridView1.DataSource = cc.GetAllCustomers();
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string customerId = textBox1.Text;
                if (string.IsNullOrEmpty(customerId))
                {
                    MessageBox.Show("Please enter a Customer ID to search.");
                    return;
                }
                CustomerController cc = new CustomerController();
                Customer c = cc.SearchCustomerById(customerId);

                if (c != null)
                {
                    MessageBox.Show("Customer Found");
                    textBox1.Text = c.CustomerId;
                    textBox2.Text = c.FirstName;
                    textBox3.Text = c.LastName;

                    if (c.Gender == "Male")
                        radioButton1.Checked = true;
                    else if (c.Gender == "Female")
                        radioButton2.Checked = true;

                    textBox4.Text = c.Age.ToString();
                    textBox1.Enabled = false;
                    textBox5.Text = c.Password;
                    textBox6.Text = c.SecurityAns;
                }
                else
                {
                    MessageBox.Show("Customer Not Found");
                }

                dataGridView1.DataSource = cc.GetAllCustomers();
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
