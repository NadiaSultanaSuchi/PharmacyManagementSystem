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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string employeeId = "";

                string firstName = textBox1.Text;
                string lastName = textBox2.Text;
                string userId = textBox3.Text;
                string password = textBox4.Text;
                string confirmPassword = textBox5.Text;
                int age = Convert.ToInt32(textBox6.Text);
                string securityAns = textBox7.Text;
                string phone = textBox8.Text;

                string gender = "";

                if (radioButton1.Checked)
                {
                    gender = radioButton1.Text;
                }
                else if (radioButton2.Checked)
                {
                    gender = radioButton2.Text;
                }

               

                if (password != confirmPassword)
                {
                    MessageBox.Show("Passwords do not match. Please re-enter.");
                    return;
                }

                

                Login login = new Login(userId, password, 3, securityAns);
                Customer customer = new Customer(userId,  firstName,  lastName,  gender,  age, employeeId,  password,  securityAns);


                LoginController loginController = new LoginController();
                loginController.AddLogin(login);

                CustomerController customerController = new CustomerController();
                customerController.AddCustomer(customer);

                MessageBox.Show("Registration Successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }
    }
}
