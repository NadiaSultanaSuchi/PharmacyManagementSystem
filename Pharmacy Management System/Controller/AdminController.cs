using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pharmacy_Management_System.Model;

namespace Pharmacy_Management_System.Controller
{
    public class AdminController
    {
        public void AddAdmin(Admin a)
        {
            Admins admins = new Admins();
            admins.AddAdmin(a);
        }

        public void UpdateAdmin(Admin a)
        {
            Admins admins = new Admins();
            admins.UpdateAdmin(a);
        }

        public void DeleteAdmin(string id)
        {
            Admins admins = new Admins();
            admins.DeleteAdmin(id);
        }

        public Admin SearchAdminById(string id)
        {
            Admins admins = new Admins();
            return admins.SearchAdminById(id);
        }

        public List<Admin> GetAllAdmins()
        {
            Admins admins = new Admins();
            return admins.GetAllAdmins();
        }
    }
}
