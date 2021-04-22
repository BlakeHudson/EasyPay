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
    /// Interaction logic for CustomerInfoWindow.xaml
    /// </summary>
    public partial class CustomerInfoWindow : Window
    {
        List<Order> orders = new List<Order>();
        List<Product> products = new List<Product>();
        Customer cust;
        public CustomerInfoWindow(Customer c)
        {
            InitializeComponent();
            cust = c;
            CustIDBlock.Text = "Customer ID: " + cust.Customer_ID;
            LoadAll();
        }

        public void LoadAll()
        {
            setBoxes();
            LoadOrderList();
        }

        public void setBoxes()
        {
            LNameBox.Text = cust.Last_Name;
            FNameBox.Text = cust.First_Name;
            EmailBox.Text = cust.Email;
        }

        public void LoadOrderList()
        {
            orders = SQLiteDataAccess.GetOrderHistoryById(cust.Customer_ID);
            WireUpOrderList(orders);
        }

        public void WireUpOrderList(List<Order> orders)
        {
            OrderListBox.ItemsSource = orders;

        }

        private void ProductShowButton_Click(object sender, RoutedEventArgs e)
        {
            if (OrderListBox.SelectedItem != null)
            {
                Order selectedOrder = new Order();
                string s = OrderListBox.SelectedItem.ToString();
                if (orders.Count != 0)
                {
                    foreach (Order o in orders)
                    {
                        if (o.compareTo(s))
                            selectedOrder = o;
                    }
                }

                //id = int.Parse(OrderListBox.SelectedItem.ToString().Substring(0, 1));
                products = SQLiteDataAccess.GetProductsByOrderID(selectedOrder.Order_ID);
                ProductListBox.ItemsSource = products;
                
                double amount = 0.0;
                foreach(Product p in products)
                {
                    amount += p.Product_Price;
                }
                productTotalBlock.Text = "$" + amount;                

            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            cust.Last_Name = LNameBox.Text;
            cust.First_Name = FNameBox.Text;
            cust.Email = EmailBox.Text;
            SQLiteDataAccess.updateCustomer(cust);

            MessageBox.Show("Customer info updated.");

            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            SQLiteDataAccess.deleteCustomer(cust);
            MessageBox.Show("Customer info deleted.");

            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
        }

        private void ReminderButton_Click(object sender, RoutedEventArgs e)
        {
            EmailManager emailManager = new EmailManager(cust);
            emailManager.SendReminder();

            MessageBox.Show("Payment reminder sent.");

            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
        }

        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            AddOrder orderWindow = new AddOrder(cust);
            orderWindow.Show();
            this.Close();
        }

        private void prevPageBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
        }
    }
}
