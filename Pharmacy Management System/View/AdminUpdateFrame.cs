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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pharmacy_Management_System.View
{
    public partial class AdminUpdateFrame : Form
    {
        Login login1;


        public AdminUpdateFrame(Login login1)
        {
            InitializeComponent();
            this.login1 = login1;
             
        }

        private void AdminUpdateFrame_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string userId = login1.UserId;      
                string password = textBox2.Text.Trim();    
                int role = 1;                           
                string securityAns = textBox3.Text.Trim();  
                string name = textBox7.Text.Trim(); 
                string email = textBox6.Text.Trim(); 
                string phone = textBox5.Text.Trim(); 
                string branch = textBox4.Text.Trim();
                if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(securityAns) ||
                                       string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(branch))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }
                Login login = new Login(userId,password,role,securityAns);

                LoginController lc = new LoginController();
                lc.UpdateLogin(login);                     
                Admin adm = new Admin(userId, name, email, phone, branch, password, securityAns);
                AdminController ac = new AdminController();
                ac.UpdateAdmin(adm);
                MessageBox.Show("Admin credentials updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHomeFrame ahf = new AdminHomeFrame(login1);
            ahf.Show();
        }

        private void button33(object sender, EventArgs e)
        {
            MessageBox.Show("hi");
        }
    }
}
