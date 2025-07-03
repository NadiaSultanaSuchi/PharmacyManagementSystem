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
using Pharmacy_Management_System.Model;
using Pharmacy_Management_System.Controller;

namespace Pharmacy_Management_System.View
{
    public partial class EmployeeOperationFrame : Form
    {
        Login login1;
        public EmployeeOperationFrame(Login login1)
        {
            InitializeComponent();
            this.login1 = login1;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHomeFrame ahf = new AdminHomeFrame(login1);
            ahf.Show();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();

            textBox1.Enabled = true;
            
        }

       
        private void EmployeeOperationFrame_Load(object sender, EventArgs e)
        {
            EmployeeController ec = new EmployeeController();
            dataGridView1.DataSource = ec.GetAllEmployee();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string id = textBox1.Text;
                string name = textBox2.Text;
                string role = textBox3.Text;
                string email = textBox4.Text;
                string phone = textBox5.Text;
                string adminId = login1.UserId;
                string password = textBox6.Text;
                string securityAns = textBox7.Text;

                if (id != "" && name != "" && role != "" && email != "" && phone != "" &&  password != "" && securityAns != "")
                {
                    Employee emp = new Employee(id, name, role, email, phone, adminId, password, securityAns);

                    Login login = new Login(id,password,2,securityAns);
                    LoginController lc = new LoginController();
                    lc.AddLogin(login);

                    EmployeeController ec = new EmployeeController();
                    ec.AddEmployee(emp);

                    MessageBox.Show("Employee Added Successfully");

                    dataGridView1.DataSource = ec.GetAllEmployee();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex !=-1) 
            {
                DataGridViewRow dvr = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = dvr.Cells[0].Value.ToString();
                textBox2.Text = dvr.Cells[1].Value.ToString();
                textBox3.Text = dvr.Cells[2].Value.ToString();
                textBox4.Text = dvr.Cells[3].Value.ToString();
                textBox5.Text = dvr.Cells[4].Value.ToString();
                textBox6.Text = dvr.Cells[6].Value.ToString();
                textBox7.Text = dvr.Cells[7].Value.ToString();

                


                textBox1.Enabled = false;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string id = textBox1.Text;
                string name = textBox2.Text;
                string role = textBox3.Text;
                string email = textBox4.Text;
                string phone = textBox5.Text;
                string adminId = login1.UserId;
                string password = textBox6.Text;
                string securityAns = textBox7.Text;
                if (id != "" && name != "" && role != "" && email != "" && phone != "" && password != "" && securityAns != "")
                {
                    

                    Employee emp = new Employee(id, name, role, email, phone, adminId, password, securityAns);

                    Login login = new Login(id, password, 2, securityAns);
                    LoginController lc = new LoginController();
                    lc.UpdateLogin(login);

                    EmployeeController ec = new EmployeeController();
                    ec.UpdateEmployee(emp);

                    MessageBox.Show("Employee Updated Successfully");

                    dataGridView1.DataSource = ec.GetAllEmployee();
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string id = textBox1.Text;

                if (string.IsNullOrEmpty(id))
                {
                    MessageBox.Show("Please enter a Employee ID to delete.");
                    return;
                }
                LoginController lc = new LoginController();
                lc.DeleteLogin(id);
 
                EmployeeController ec = new EmployeeController();
                ec.DeleteEmployee(id);

                MessageBox.Show("Employee Removed Successfully");

                dataGridView1.DataSource = ec.GetAllEmployee();
                dataGridView1.Refresh();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string id = textBox1.Text;
                if (string.IsNullOrEmpty(id))
                {
                    MessageBox.Show("Please enter a Employee ID to search.");
                    return;
                }

                EmployeeController ec = new EmployeeController();
                Employee emp = ec.SearchEmployeeById(id);

                if (emp != null)
                {
                    MessageBox.Show("Employee Found");

                    textBox1.Text = emp.EmployeeId;
                    textBox2.Text = emp.Name;
                    textBox3.Text = emp.Role;
                    textBox4.Text = emp.Email;
                    textBox5.Text = emp.Phone;
                    
                    textBox6.Text = emp.Password; 
                    textBox7.Text = emp.SecurityAns;
                }

                else 
                {
                    MessageBox.Show("Employee Not Found");
                }

                    

                dataGridView1.DataSource = ec.GetAllEmployee();
                dataGridView1.Refresh();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}
