using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPay
{
    /// <summary>
    /// This class connects to the EasyPay Database.
    /// </summary>
    public class SQLiteDataAccess
    {
        /// <summary>
        /// gets a list of users in the db
        /// </summary>
        /// <returns></returns>
        public static List<EasyPayUser> LoadUsers()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<EasyPayUser>("select * from User", new DynamicParameters());
                return output.ToList();
            }
        }

        /// <summary>
        /// adds a user to the db
        /// </summary>
        /// <param name="user"></param>
        public static void SaveUser(EasyPayUser user)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into User (User_Name, Password) values (@User_Name, @Password)", user);
            }
        }

        /// <summary>
        /// gets list of customers from db
        /// </summary>
        /// <returns></returns>
        public static List<Customer> LoadCustomers()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Customer>("select * from Customer", new DynamicParameters());
                return output.ToList();
            }
        }

        /// <summary>
        /// saves a customer to the db
        /// </summary>
        /// <param name="customer"></param>
        public static void SaveCustomer(Customer customer)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Customer (First_Name, Last_Name, Email) values (@First_Name, @Last_Name, @Email)", customer);
            }
        }

        /// <summary>
        /// gets list of all orders from db
        /// </summary>
        /// <returns></returns>
        public static List<Order> LoadOrders()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Order>("select * from [Order]", new DynamicParameters());
                return output.ToList();
            }
        }

        /// <summary>
        /// saves an order to the db
        /// </summary>
        /// <param name="order"></param>
        public static void SaveOrder(Order order)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into [Order] (Order_ID, Customer_ID, Order_Date) values (" + order.Order_ID + ", " + order.Customer_ID
                    + ", '" + order.Order_Date + "')", order);
            }
        }

        /// <summary>
        /// gets order details from db
        /// </summary>
        /// <returns></returns>
        public static List<OrderDetails> LoadOrderDetails()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<OrderDetails> ("select * from [Order Details]", new DynamicParameters());
                return output.ToList();
            }
        }

        /// <summary>
        /// saves an order's details to db
        /// </summary>
        /// <param name="od"></param>
        public static void SaveOrderDetails(OrderDetails od)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into [Order_Details] (Order_ID, Product_ID, Product_Price) values (@Order_ID, @Product_ID, @Product_Price)", od);
            }
        }

        /// <summary>
        /// gets list of products from db
        /// </summary>
        /// <returns></returns>
        public static List<Product> LoadProducts()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Product>("select * from Product", new DynamicParameters());
                return output.ToList();
            }
        }

        /// <summary>
        /// saves a product to db
        /// </summary>
        /// <param name="product"></param>
        public static void SaveProduct(Product product)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Product (Product_ID, Product_Name, Product_Price) values (@Product_ID, @Product_Name, @Product_Price)", product);
            }
        }


        public static void UpdateProduct(Product product)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("Update Product set Product_Name = '" + product.Product_Name + "' where Product_ID = " + product.Product_ID, product);
                cnn.Execute("update Product set Product_Price = '" + product.Product_Price + "' where Product_ID = " + product.Product_ID, product);
            }
        }

        /// <summary>
        /// gets all orders made by a customer by customer id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Order> GetOrderHistoryById(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string Query = "select * from [Order] where Customer_ID = " + id;
                var output = cnn.Query<Order>(Query, new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<Product> GetProductsByOrderID(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string query = "Select P.Product_ID, Product_Name, P.Product_Price From ([Order] O inner join [Order_Details] OD On O.Order_ID = OD.Order_ID)" +
                " inner join Product P On OD.Product_ID = P.Product_ID Where O.Order_ID = " + id;
                var output = cnn.Query<Product>(query, new DynamicParameters());
                return output.ToList();
            }
        }

        public static void deleteProductByName(string n)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("Delete From Product where Product_Name = '" + n + "'", n);
            }
        }

        public static void updateCustomer(Customer customer)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("update Customer set First_Name = '" + customer.First_Name + "' where Customer_ID = " + customer.Customer_ID, customer);
                cnn.Execute("update Customer set Last_Name = '" + customer.Last_Name + "' where Customer_ID = " + customer.Customer_ID, customer);
                cnn.Execute("update Customer set Email = '" + customer.Email + "' where Customer_ID = " + customer.Customer_ID, customer);
            }
        }

        public static void deleteCustomer(Customer customer)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("Delete From Customer where Customer_ID = " + customer.Customer_ID, customer);
            }
        }

        public static void deleteOrder(int orderNum)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("Delete From [Order] where Order_ID = " + orderNum, orderNum);
            }
        }

        /// <summary>
        /// connection to the db
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
