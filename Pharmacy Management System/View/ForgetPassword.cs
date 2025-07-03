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
    public partial class ForgetPassword : Form
    {
        public ForgetPassword()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userId = textBox1.Text;
            string securityAns = textBox2.Text;

            if (userId == "" || securityAns == "")
            {
                MessageBox.Show("Enter User ID and Security Answer");
                return;
            }

            SqlDbDataAccess sda = new SqlDbDataAccess();
            SqlCommand cmd = sda.GetQuery("SELECT userID, password, role, securityAns FROM Login WHERE userID = @userId AND securityAns = @securityAns;");
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@securityAns", securityAns);

            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Login login = new Login
                    {
                        UserId = reader.GetString(0),
                        Password = reader.GetString(1),
                        Role = reader.GetInt32(2),
                        SecurityAns = reader.GetString(3)
                    };

                    this.Hide();

                    if (login.Role == 1) 
                    {
                        this.Hide();
                        AdminHomeFrame adminHomeFrame = new AdminHomeFrame(login);
                        adminHomeFrame.Show();
                    } 
                    else if (login.Role == 2)
                    {
                        this.Hide();
                        EmployeeHomeFrame employeeHomeFrame = new EmployeeHomeFrame(login);
                        employeeHomeFrame.Show();
                    }
                    else if (login.Role == 3)
                    {
                        this.Hide();
                        EmployeeHomeFrame employeeHomeFrame = new EmployeeHomeFrame(login);
                        employeeHomeFrame.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid User ID and Security Answer");
                }

                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void ForgetPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
