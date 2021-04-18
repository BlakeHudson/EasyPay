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
        IList<Product> items;

        public Product getProductAtIndex(int index) {
            return items[index];
        }
        public int size()
        {
            return items.Count();
        }
    }
}
