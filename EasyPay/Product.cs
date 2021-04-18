using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPay
{
    public class Product
    {
        int Product_ID { get; set; }
        String Product_Name { get; set; }
        double Product_Price { get; set; }

        public override string ToString()
        {
            return String.Format("{0,10}{1,6}\n", Product_Name, Product_Price) ;
        }
    }
}
