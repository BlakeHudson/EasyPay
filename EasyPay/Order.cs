using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPay
{
    public class Order
    {
        public int Order_ID {get; set; }
        public int Customer_ID { get; set; }
        public string Order_Date { get; set; }
        int Product_ID { get; set; }

        public IList<Product> items;

        public Order()
        {

        }

        public Order(int oId, int cId, string od)
        {
            Order_ID = oId;
            Customer_ID = cId;
            Order_Date = od;
        }

        public Order(int oId, int cId, string od, List<Product> i)
        {
            Order_ID = oId;
            Customer_ID = cId;
            Order_Date = od;
            items = i;
        }

        public void setItems()
        {
            items = SQLiteDataAccess.GetProductsByOrderID(Order_ID);
        }

        //Returns product from array at a given index
        public Product getProductAtIndex(int index)
        {
            setItems();
            return items[index];
           
        }

        public int size()
        {
            setItems();
            return items.Count();
        }

        public override string ToString()
        {
            return Order_ID + ", Order Date: " + Order_Date;
        }

        public Boolean compareTo(string s)
        {
            if (this.ToString() == s)
                return true;
            return false;
        }

    }
}
