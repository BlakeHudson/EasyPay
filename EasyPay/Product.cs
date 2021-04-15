using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPay
{
    class Product
    { 
        String Name { get; set; }
        double Cost { get; set; }

        public override string ToString()
        {
            return String.Format("{0,10}{1,6}\n",Name,Cost) ;
        }
    }
}
