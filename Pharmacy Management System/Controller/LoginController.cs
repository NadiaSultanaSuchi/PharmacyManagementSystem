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
    public class LoginController
    {
        public void AddLogin(Login login)
        {
            Logins logins = new Logins();
            logins.AddLogin(login);
        }

        public void UpdateLogin(Login login)
        {
            Logins logins = new Logins();
            logins.UpdateLogin(login);
        }

        public void DeleteLogin(string userId)
        {
            Logins logins = new Logins();
            logins.DeleteLogin(userId);
        }

        public Login SearchLogin(string userId, string password)
        {
            Logins logins = new Logins();
            return logins.SearchLogin(userId, password);
        }

        public List<Login> GetAllLogin()
        {
            Logins logins = new Logins();
            return logins.GetAllLogin();
        }
    }
}
