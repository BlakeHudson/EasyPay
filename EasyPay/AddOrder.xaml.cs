using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EasyPay
{
    /// <summary>
    /// Interaction logic for AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        List<Product> products = new List<Product>();
        List<Product> newOrder = new List<Product>();
        Customer customer;
        public AddOrder(Customer cust)
        {            
            InitializeComponent();
            
            customer = cust;
            LoadProductsList();
        }

        public void LoadProductsList()
        {
            products = SQLiteDataAccess.LoadProducts();
            productsList.ItemsSource = products;
        }

        public void LoadOrderList(List<Product> order)
        {
            orderList.ItemsSource = null;
            orderList.ItemsSource = order;
        }

        private void AddProduct_Button_Click(object sender, RoutedEventArgs e)
        {
            //order.Add(SQLiteDataAccess.LoadProducts()[productsList.SelectedIndex]);
            string s = productsList.SelectedItem.ToString();
            foreach(Product p in products)
            {
                if(p.compareTo(s))
                {
                    newOrder.Add(p);
                    break;
                }
            }

            LoadProductsList();
            LoadOrderList(newOrder);
        }
        private void RemoveProduct_Button_Click(object sender, RoutedEventArgs e)
        {
            string s = orderList.SelectedItem.ToString();
            foreach (Product p in newOrder)
            {
                if (p.compareTo(s))
                {
                    newOrder.Remove(p);
                    break;
                }
            }

            LoadProductsList();
            LoadOrderList(newOrder);
        }

        private void FinishOrder_Button_Click(object sender, RoutedEventArgs e)
        {
            List<Order> allOrders = SQLiteDataAccess.LoadOrders();
            int i = 1;

            if(allOrders.Count != 0)
            {
                i = allOrders.Last().Order_ID + 1;
            }

            Order finishedOrder = new Order(i, customer.Customer_ID, System.DateTime.Today.ToString());
            SQLiteDataAccess.SaveOrder(finishedOrder);

            OrderDetails od = new OrderDetails();
            od.Order_ID = i;

            foreach(Product p in newOrder)
            {
                od.Product_ID = p.Product_ID;
                od.Product_Price = p.Product_Price;

                SQLiteDataAccess.SaveOrderDetails(od);
            }
            
            EmailManager emailManager = new EmailManager(customer, finishedOrder);
            emailManager.SendEmail();

            CustomerInfoWindow customerInfoWindow = new CustomerInfoWindow(customer);
            customerInfoWindow.Show();
            this.Close();
        }
    }
}
