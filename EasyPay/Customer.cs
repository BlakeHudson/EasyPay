using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPay
{
    public class Customer
    {
        public int Customer_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }

        List<Order> OrderHistory;

        public Customer()
        {

        }

        public Customer(int id, string a, string b, string c)
        {
            Customer_ID = id;
            First_Name = a;
            Last_Name = b;
            Email = c;

            OrderHistory = SQLiteDataAccess.GetOrderHistoryById(Customer_ID);
        }

        public override string ToString()
        {
            return Customer_ID + ": " + Last_Name + ", " + First_Name + " " + Email;
        }
    }
}
