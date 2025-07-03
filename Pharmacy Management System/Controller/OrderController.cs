using Pharmacy_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Management_System.Controller
{
    public class OrderController
    {
        public int AddOrder(Order m)
        {
            Orders mm = new Orders();
            mm.AddOrder(m);

            return m.OrderId;
        }
        public List<Order> GetAllOrder()
        {
            Orders mm = new Orders();
            return mm.GetAllOrder();
        }
    }
}
