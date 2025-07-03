using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pharmacy_Management_System.Model;
using System.Data;

namespace Pharmacy_Management_System.Controller
{
    public class CustomerController
    {
  
        public void AddCustomer(Customer customer)
        {
            Customers c = new Customers();
            c.AddCustomer(customer);
        }
      
        public void UpdateCustomer(Customer customer)
        {
            Customers c = new Customers();
            c.UpdateCustomer(customer);
        }

        public void DeleteCustomer(string id)
        {
            Customers c = new Customers();
            c.DeleteCustomer(id);
        }

        public Customer SearchCustomerById(string id)
        {
            Customers c = new Customers();
            return c.SearchCustomerById(id);
        }

        public List<Customer> GetAllCustomers()
        {
            Customers c = new Customers();
            return c.GetAllCustomers();
        }
    }
}
