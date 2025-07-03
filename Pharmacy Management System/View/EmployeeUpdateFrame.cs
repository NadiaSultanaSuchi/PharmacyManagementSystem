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
    public partial class EmployeeUpdateFrame : Form
    {
        Login login;
        public EmployeeUpdateFrame(Login login)
        {
            InitializeComponent();
            this.login = login;
            //textBox1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeHomeFrame ehf = new EmployeeHomeFrame(login);
            ehf.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                

                string UserId = login.UserId;       
                string Password = textBox2.Text.Trim();    
                int Role = 2;                            
                string SecurityAns = textBox3.Text.Trim();
                string email = textBox5.Text.Trim();
                string phone = textBox4.Text.Trim();
                string name = textBox6.Text.Trim();
                Login log = new Login(UserId,Password,Role,SecurityAns);

                LoginController lc = new LoginController();
                lc.UpdateLogin(log);

                Employee emp = new Employee(UserId, name, "",email, phone, "",Password, SecurityAns);
                EmployeeController ec = new EmployeeController();
                ec.UpdateEmployee(emp);

                MessageBox.Show("Employee credentials updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void EmployeeUpdateFrame_Load(object sender, EventArgs e)
        {

        }
    }
}
