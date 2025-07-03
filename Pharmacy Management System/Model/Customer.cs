namespace Pharmacy_Management_System.Model
{
    public class Customer
    {
        private string customerId;
        private string firstName;
        private string lastName;
        private string gender;
        private int age;
        private string employeeId;
        private string password;
        private string securityAns;

        public Customer() 
        {

        }

        public Customer(string customerId, string firstName, string lastName, string gender, int age, string employeeId, string password, string securityAns)
        {
            this.CustomerId = customerId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.Age = age;
            this.EmployeeId = employeeId;
            this.Password = password;
            this.SecurityAns = securityAns;
        }

        public string CustomerId { get => customerId; set => customerId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Gender { get => gender; set => gender = value; }
        public int Age { get => age; set => age = value; }
        public string EmployeeId { get => employeeId; set => employeeId = value; }
        public string Password { get => password; set => password = value; }
        public string SecurityAns { get => securityAns; set => securityAns = value; }
    }
}
