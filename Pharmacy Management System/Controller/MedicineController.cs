using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using Pharmacy_Management_System.Model;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace Pharmacy_Management_System.Controller
{
    public class MedicineController
    {
        public void AddMedicine(Medicine m)
        {
            Medicines mm = new Medicines();
            mm.AddMedicine(m);
        }

        public void UpdateMedicine(Medicine m)
        {
            Medicines mm = new Medicines();
            mm.UpdateMedicine(m);
        }

        public void DeleteMedicine(string id)
        {
            Medicines mm = new Medicines();
            mm.DeleteMedicine(id);
        }

        public Medicine SearchMedicineById(string id)
        {
            Medicines mm = new Medicines();
            return mm.SearchMedicineById(id);
        }

        public Medicine SearchMedicineByName(string name)
        {
            Medicines mm = new Medicines();
            return mm.SearchMedicineByName(name);
        }


        public List<Medicine> GetAllMedicine()
        {
            Medicines mm = new Medicines();
            return mm.GetAllMedicine();
        }

        public void ReduceQuantity(string medicineId, int quantityToReduce)
        {
            Medicines medicines = new Medicines();
            medicines.ReduceQuantity(medicineId, quantityToReduce);
        }
    }
}
