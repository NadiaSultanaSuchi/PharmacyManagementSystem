using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pharmacy_Management_System.Model;
using Pharmacy_Management_System.Controller;

namespace Pharmacy_Management_System.View
{
    public partial class AdminHomeFrame : Form
    {
        Login login;

        public AdminHomeFrame(Login login)
        {
            InitializeComponent();
            this.login = login;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeOperationFrame eof = new EmployeeOperationFrame(login);
            eof.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SupplierOperationFrame sof = new SupplierOperationFrame(login);
            sof.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm lf = new LoginForm();
            lf.Show();  
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            MedicineOperationFrame mof = new MedicineOperationFrame(login);
            mof.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerOperationFrame cof = new CustomerOperationFrame(login);
            cof.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminUpdateFrame adf = new AdminUpdateFrame(login);
            adf.Show();
        }

        private void AdminHomeFrame_Load(object sender, EventArgs e)
        {
            AdminController admin = new AdminController();           
            Admin admin1 = admin.SearchAdminById(login.UserId);
            label1.Text = login.UserId;
            label2.Text = admin1.Name;
            label3.Text = admin1.Email;
            label4.Text = admin1.Phone;
            label5.Text = admin1.Branch;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrderDataForm odf = new OrderDataForm(login);
            odf.Show();
        }
    }
}
