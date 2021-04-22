using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPay
{
    public class Product
    {
        public int Product_ID { get; set; }
        public String Product_Name { get; set; }
        public double Product_Price { get; set; }

        public Product()
        {

        }

        public Product(int id, string name, double price)
        {
            Product_ID = id;
            Product_Name = name;
            Product_Price = price;
        }

        //Returns the product info in the format "Item_Name      Item_Cost"
        public override string ToString()
        {
            return String.Format("{0,10}{1,6}\n", Product_Name, "$"+Product_Price) ;
        }

        public string ProductInfo()
        {
            return Product_ID + ": " + Product_Name + ", $" + Product_Price;
        }

        public Boolean compareTo(string s)
        {
            if (this.ToString() == s)
                return true;
            return false;
        }
    }
}
