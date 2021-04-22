using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPay
{
    /// <summary>
    /// Needed in the case of multiple products purchased per order
    /// </summary>
    public class OrderDetails
    {
        public int Order_ID { get; set; }
        public int Product_ID { get; set; }
        public double Product_Price { get; set; }

        public OrderDetails()
        {

        }

        public OrderDetails(int Orderid, int Productid, double p)
        {
            Order_ID = Orderid;
            Product_ID = Productid;
            Product_Price = p;
        }
    }
}
