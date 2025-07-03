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
    public class SupplierController
    {
        public void AddSupplier(Supplier s)
        {
            Suppliers ss = new Suppliers();
            ss.AddSupplier(s);
        }

        public void UpdateSupplier(Supplier s)
        {
            Suppliers ss = new Suppliers();
            ss.UpdateSupplier(s);
        }

        public void DeleteSupplier(string id)
        {
            Suppliers ss = new Suppliers();
            ss.DeleteSupplier(id);
        }

        public Supplier SearchSupplierById(string id)
        {
            Suppliers ss = new Suppliers();
            return ss.SearchSupplierById(id);
        }

        public List<Supplier> GetAllSupplier()
        {
            Suppliers ss = new Suppliers();
            return ss.GetAllSupplier();
        }
    }
}
