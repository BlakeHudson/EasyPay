﻿using System;
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
        int OrderID { get; set; }
        int ProductID { get; set; }
        double ProductPrice { get; set; }

        public OrderDetails()
        {

        }

        public OrderDetails(int Orderid, int Productid, double price)
        {
            OrderID = Orderid;
            ProductID = Productid;
            ProductPrice = price;
        }
    }
}
