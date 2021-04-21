using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPay
{
    public class Order
    {
        int Order_ID { get; set; }
        int Customer_ID { get; set; }
        string Order_Date { get; set; }
        int Product_ID { get; set; }

        IList<Product> items;

        public Order()
        {

        }

        public Order(int oId, int cId, string od)
        {
            Order_ID = oId;
            Customer_ID = cId;
            Order_Date = od;
        }

        //Returns product from array at a given index
        public Product getProductAtIndex(int index)
        {
            return items[index];
           
        }

        public int size()
        {
            return items.Count();
        }

        public override string ToString()
        {
            return Order_ID + ", Order Date: " + Order_Date;
        }

    }
}
