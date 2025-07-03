using Pharmacy_Management_System.Controller;
using Pharmacy_Management_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy_Management_System.View
{
    public partial class CustomerUpdateFrame : Form
    {
        Login login;
        
        public CustomerUpdateFrame(Login login)
        {
            InitializeComponent();
            this.login = login;
            //textBox1.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerHomeFrame chf = new CustomerHomeFrame(login);
            chf.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                //string userId = textBox1.Text.Trim();
                string userId = login.UserId;  
                string Password = textBox2.Text.Trim();     
                int Role = 3;                            
                string SecurityAns = textBox3.Text.Trim();
                string FirstName = textBox6.Text.Trim();
                string LastName = textBox5.Text.Trim();
                int age = Convert.ToInt32(textBox4.Text.Trim());
                string gender = "";
                //string employeeId = textBox7.Text.Trim();
                string employeeId = "";

                if (radioButton1.Checked)
                {
                    gender = radioButton1.Text;
                }
                else if (radioButton2.Checked)
                {
                    gender = radioButton2.Text;
                }
                if(string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(SecurityAns) || age <= 0)
                {
                    MessageBox.Show("Please fill in all fields correctly.");
                    return;
                }

                
                Customer c = new Customer(userId, FirstName, LastName, gender, age, employeeId, Password, SecurityAns);
                CustomerController cc = new CustomerController();
                cc.UpdateCustomer(c); 
                Login log = new Login(userId, Password, Role, SecurityAns);
                LoginController lc = new LoginController();
                lc.UpdateLogin(log);                     

                MessageBox.Show("Customer credentials updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CustomerUpdateFrame_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
