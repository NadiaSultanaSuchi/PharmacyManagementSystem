using Pharmacy_Management_System.Controller;
using Pharmacy_Management_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pharmacy_Management_System.View
{
    public partial class CustomerHomeFrame : Form
    {
        Login login;
        
        public CustomerHomeFrame(Login login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            
        }

        private void CustomerHomeFrame_Load(object sender, EventArgs e)
        {
            CustomerController cc = new CustomerController();
            Customer customer = cc.SearchCustomerById(login.UserId);
            label1.Text = login.UserId;
            label2.Text = customer.FirstName + " " + customer.LastName;
            label3.Text = customer.Age.ToString();
            label4.Text = customer.Gender;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm lf = new LoginForm();
            lf.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

         

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerUpdateFrame cuf = new CustomerUpdateFrame(login);
            cuf.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrderForm of = new OrderForm(login);
            of.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
