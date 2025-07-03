using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy_Management_System.View;
using Pharmacy_Management_System.Controller;

namespace Pharmacy_Management_System.Model
{
    public class Admin
    {
        private string adminId;
        private string name;
        private string email;
        private string phone;
        private string branch;
        private string password;
        private string securityAns;

        public Admin() 
        {

        }

        public Admin(string adminId, string name, string email, string phone, string branch, string password, string securityAns)
        {
            this.adminId = adminId;
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.branch = branch;
            this.password = password;
            this.securityAns = securityAns;
        }

        public string AdminId { get => adminId; set => adminId = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Branch { get => branch; set => branch = value; }
        public string Password { get => password; set => password = value; }
        public string SecurityAns { get => securityAns; set => securityAns = value; }
    }
}
