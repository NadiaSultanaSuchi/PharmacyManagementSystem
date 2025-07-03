using System;

namespace Pharmacy_Management_System.Model
{
    public class Employee
    {
        private string employeeId;
        private string name;
        private string role;
        private string email;
        private string phone;
        private string adminId;
        private string password;
        private string securityAns;

        public Employee() 
        {

        }

        public Employee(string employeeId, string name, string role, string email, string phone, string adminId, string password, string securityAns)
        {
            this.EmployeeId = employeeId;
            this.Name = name;
            this.Role = role;
            this.Email = email;
            this.Phone = phone;
            this.AdminId = adminId;
            this.Password = password;
            this.SecurityAns = securityAns;
        }

        public string EmployeeId { get => employeeId; set => employeeId = value; }
        public string Name { get => name; set => name = value; }
        public string Role { get => role; set => role = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string AdminId { get => adminId; set => adminId = value; }
        public string Password { get => password; set => password = value; }
        public string SecurityAns { get => securityAns; set => securityAns = value; }
    }
}
