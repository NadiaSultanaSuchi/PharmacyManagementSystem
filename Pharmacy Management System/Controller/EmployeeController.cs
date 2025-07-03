using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using Pharmacy_Management_System.Model;

namespace Pharmacy_Management_System.Controller
{
    public class EmployeeController
    {
        public void AddEmployee(Employee e)
        {
            Employees emps = new Employees();
            emps.AddEmployee(e);
        }

        public void UpdateEmployee(Employee e)
        {
            Employees emps = new Employees();
            emps.UpdateEmployee(e);
        }

        public void DeleteEmployee(string id)
        {
            Employees emps = new Employees();
            emps.DeleteEmployee(id);
        }

        public Employee SearchEmployeeById(string id)
        {
            Employees emps = new Employees();
            return emps.SearchEmployeeById(id);
        }

        public List<Employee> GetAllEmployee()
        {
            Employees emps = new Employees();
            return emps.GetAllEmployee();
        }
    }
}
