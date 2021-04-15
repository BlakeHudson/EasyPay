using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPay
{
    class Order
    {
        int OrderID { get; set; }
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
