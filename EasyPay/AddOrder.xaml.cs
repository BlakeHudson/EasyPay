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
        List<Product> order = null;
        Customer customer;
        public AddOrder(Customer cust)
        {            
            InitializeComponent();
            productsList.ItemsSource = SQLiteDataAccess.LoadProducts();
            customer = cust;
        }

        private void AddProduct_Button_Click(object sender, RoutedEventArgs e)
        {
            order.Add(SQLiteDataAccess.LoadProducts()[productsList.SelectedIndex]);
            orderList.ItemsSource = order;

        }
        private void RemoveProduct_Button_Click(object sender, RoutedEventArgs e)
        {
            order.RemoveAt(orderList.SelectedIndex);
            orderList.ItemsSource = order;
        }

        private void FinishOrder_Button_Click(object sender, RoutedEventArgs e)
        {
            Order finishedOrder = new Order(1,customer.Customer_ID,""+System.DateTime.Today,order);
            SQLiteDataAccess.SaveOrder(finishedOrder);
            EmailManager emailManager = new EmailManager(customer, finishedOrder);
            emailManager.SendEmail();
        }
    }
}
