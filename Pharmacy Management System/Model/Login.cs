using System;

namespace Pharmacy_Management_System.Model
{
    public class Login
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public string SecurityAns { get; set; }

        public Login() 
        {

        }

        public Login(string userId, string password, int role, string securityAns)
        {
            this.UserId = userId;
            this.Password = password;
            this.Role = role;
            this.SecurityAns = securityAns;
        }
    }
}
