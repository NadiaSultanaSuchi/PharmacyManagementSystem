namespace Pharmacy_Management_System.Model
{
    public class Supplier
    {
        private string supplierId;
        private string company;
        private string contact;
        private string email;
        private string address;
        private string adminId;
        

        public Supplier() 
        {

        }

        public Supplier(string supplierId, string company, string contact, string email, string address, string adminId)
        {
            this.SupplierId = supplierId;
            this.Company = company;
            this.Contact = contact;
            this.Email = email;
            this.Address = address;
            this.AdminId = adminId;
        }

        public string SupplierId { get => supplierId; set => supplierId = value; }
        public string Company { get => company; set => company = value; }
        public string Contact { get => contact; set => contact = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
        public string AdminId { get => adminId; set => adminId = value; }
    }
}
