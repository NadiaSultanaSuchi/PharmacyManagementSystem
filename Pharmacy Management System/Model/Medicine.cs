namespace Pharmacy_Management_System.Model
{
    public class Medicine
    {
        private string medicineId;
        private string name;
        private int quantity;
        private float price;
        private string expiryDate;
        private string employeeId;

        public Medicine() 
        {

        }

        public Medicine(string medicineId, string name, int quantity, float price, string expiryDate, string employeeId)
        {
            this.MedicineId = medicineId;
            this.Name = name;
            this.Quantity = quantity;
            this.Price = price;
            this.ExpiryDate = expiryDate;
            this.EmployeeId = employeeId;
        }

        public string MedicineId { get => medicineId; set => medicineId = value; }
        public string Name { get => name; set => name = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public float Price { get => price; set => price = value; }
        public string ExpiryDate { get => expiryDate; set => expiryDate = value; }
        public string EmployeeId { get => employeeId; set => employeeId = value; }
    }
}
