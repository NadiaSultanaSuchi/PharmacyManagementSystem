using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Management_System.Model
{
    public class Order
    {
        private int orderId;
        private float totalAmount;
        private float paidAmount;
        private float changeAmount;


        public Order()
        {
        }
        public Order(int orderId, float totalAmount, float paidAmount, float changeAmount)
        {
            this.orderId = orderId;
            this.totalAmount = totalAmount;
            this.paidAmount = paidAmount;
            this.changeAmount = changeAmount;
        }
        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }
        public float TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; }
        }
        public float PaidAmount
        {
            get { return paidAmount; }
            set { paidAmount = value; }
        }
        public float ChangeAmount
        {
            get { return changeAmount; }
            set { changeAmount = value; }
        }
    }
}
