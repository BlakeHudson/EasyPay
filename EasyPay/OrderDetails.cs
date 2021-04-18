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
        int Order_ID { get; set; }
        int Product_ID { get; set; }
        double Product_Price { get; set; }

        public OrderDetails()
        {

        }

        public OrderDetails(int Orderid, int Productid, double price)
        {
            Order_ID = Orderid;
            Product_ID = Productid;
            Product_Price = price;
        }
    }
}
