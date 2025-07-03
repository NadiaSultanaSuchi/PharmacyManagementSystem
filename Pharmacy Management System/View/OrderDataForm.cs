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
    public partial class OrderDataForm : Form
    {
        Login login;
        public OrderDataForm(Login login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void OrderDataForm_Load(object sender, EventArgs e)
        {
            OrderController mc = new OrderController();
            dataGridView1.DataSource = mc.GetAllOrder();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (login.Role == 1)
            {
                AdminHomeFrame ahf = new AdminHomeFrame(login);
                ahf.Show();
            }
            else if (login.Role == 2)
            {
                EmployeeHomeFrame ehf = new EmployeeHomeFrame(login);
                ehf.Show();
            }
            
        }
    }
}
