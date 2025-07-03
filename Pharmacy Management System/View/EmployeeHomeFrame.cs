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
    public partial class EmployeeHomeFrame : Form
    {
        private Login login;

        public EmployeeHomeFrame(Login login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MedicineOperationFrame mof = new MedicineOperationFrame(login);
            mof.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerOperationFrame cof = new CustomerOperationFrame(login);
            cof.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm lf = new LoginForm();
            lf.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            SupplierOperationFrame sof = new SupplierOperationFrame(login);
            sof.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeUpdateFrame euf = new EmployeeUpdateFrame(login);
            euf.Show();
        }

        private void EmployeeHomeFrame_Load(object sender, EventArgs e)
        {
            EmployeeController ec = new EmployeeController();
            Employee employee = ec.SearchEmployeeById(login.UserId);
            label1.Text = login.UserId;
            label2.Text = employee.Name;
            label3.Text = employee.Email;
            label4.Text = employee.Phone;
            label5.Text = employee.Role;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrderDataForm odf = new OrderDataForm(login);
            odf.Show();
        }
    }
}
