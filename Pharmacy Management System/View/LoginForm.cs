using System;
using System.Windows.Forms;
using Pharmacy_Management_System.Model;
using Pharmacy_Management_System.Controller;

namespace Pharmacy_Management_System.View
{
    public partial class LoginForm : Form
    {
        
        public LoginForm()
        {
            InitializeComponent();
        }

       
        public LoginForm(string userName)
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userId = textBox1.Text;
            string password = textBox2.Text;

            LoginController lgc = new LoginController();
            Login login = lgc.SearchLogin(userId, password);

            if (login != null)
            {
                if (login.UserId.Equals(userId) && login.Password.Equals(password) && login.Role == 1)
                {
                    MessageBox.Show("Welcome Admin");

                    this.Hide();
                    AdminHomeFrame adf = new AdminHomeFrame(login);
                    adf.Show();
                    
                }
                else if (login.UserId.Equals(userId) && login.Password.Equals(password) && login.Role == 2)
                {
                    MessageBox.Show("Welcome Employee");

                    this.Hide();
                    EmployeeHomeFrame ehf = new EmployeeHomeFrame(login);
                    ehf.Show();
                    
                }
                else if (login.UserId.Equals(userId) && login.Password.Equals(password) && login.Role == 3)
                {
                    MessageBox.Show("Welcome Customer");

                    this.Hide();
                    CustomerHomeFrame chf = new CustomerHomeFrame(login);
                    chf.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Id and password");
                }
            }
            else
            {
                MessageBox.Show("Invalid Id and password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration registration = new Registration();
            registration.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ForgetPassword forgetPassword = new ForgetPassword();
            forgetPassword.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }
    }
}
