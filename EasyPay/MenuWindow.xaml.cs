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

        public void LoadCustomerList()
        {
            customers = SQLiteDataAccess.LoadCustomers();

            WireUpPeopleList(customers);
        }

        public void WireUpPeopleList(List<Customer> customers)
        {
            CustomerListBox.ItemsSource = customers;
        }

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
