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
    /// Interaction logic for AddUser.xaml
    /// Adds a new user by asking for a username and password
    /// Saves the new user to the db
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void addUser_Submit_Click(object sender, RoutedEventArgs e)
        {
            String un;
            String pw;
            EasyPayUser newUser;

            un = newUsername.Text;
            pw = newPasswordBox.Password;

            newUser = new EasyPayUser(un, pw);
            SQLiteDataAccess.SaveUser(newUser);

            MessageBox.Show("New user added");

            MainWindow dashboard = new MainWindow();
            dashboard.Show();
            this.Close();
        }
    }


}
