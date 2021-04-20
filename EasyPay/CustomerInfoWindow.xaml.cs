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
                int id;
                id = int.Parse(OrderListBox.SelectedItem.ToString().Substring(0, 1));
                ProductListBox.ItemsSource = SQLiteDataAccess.GetProductsByOrderID(id);
            }
        }
    }
}
