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
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        List<Customer> customers = new List<Customer>();
        public MenuWindow()
        {
            InitializeComponent();

            LoadCustomerList();
        }

        /// <summary>
        /// gets all customers from db and displays them in 
        /// CustomerListBox using WireUpPeopleList method
        /// </summary>
        public void LoadCustomerList()
        {
            customers = SQLiteDataAccess.LoadCustomers();

            WireUpPeopleList(customers);
        }

        /// <summary>
        /// sets CustomerListBox to show a list of customers
        /// using List parameter
        /// </summary>
        /// <param name="customers"></param>
        public void WireUpPeopleList(List<Customer> customers)
        {
            CustomerListBox.ItemsSource = customers;
        }

        /// <summary>
        /// Finds all customers that contain the text entered in SearchBar
        /// and sets CustomerlistBox to the result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            List<Customer> searchedCustomers = new List<Customer>();
            foreach (Customer customer in customers)
            {
                if (customer.ToString().Contains(SearchBar.Text))
                    searchedCustomers.Add(customer);
            }

            WireUpPeopleList(searchedCustomers);
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
