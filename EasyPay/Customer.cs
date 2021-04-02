using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPay
{
    class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Customer (string a, string b)
        {
            Name = a;
            Email = b;
        } 

    }
}
