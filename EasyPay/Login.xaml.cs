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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        /*
         * Upon application startup, the Login window is intialized.
         * If there are no stored users in db, start add user form to add inital user.
         */
        public Login()
        {
            InitializeComponent();
            if (SQLiteDataAccess.LoadUsers().Count() == 0)
            {
                MessageBox.Show("Welcome new user!");
            }

        }

        private void Login_Submit_Click(object sender, RoutedEventArgs e)
        {
            if (Username.Text == passwordBox.Password)
            {

                MainWindow dashboard = new MainWindow();
                dashboard.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect credentials" +
                    "\n" + "Please re-enter.");
            }
        }
    }
}
