using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPay
{
    public class Customer
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public Customer(int id, string a, string b, string c)
        {
            ID = id;
            FName = a;
            LName = b;
            Email = c;
        }

    }
}
