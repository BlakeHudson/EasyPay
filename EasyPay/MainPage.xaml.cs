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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EasyPay
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        List<Customer> customers = new List<Customer>();
        public MainPage()
        {
            InitializeComponent();

            LoadCustomerList();
        }

        public void LoadCustomerList()
        {
            customers = SQLiteDataAccess.LoadCustomers();

            WireUpPeopleList();
        }

        public void WireUpPeopleList()
        {
            CustomerBox.Text = null;
            //will get back to this
            //when an iterator for customers is created
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
