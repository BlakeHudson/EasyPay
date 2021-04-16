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
using System.Security.Cryptography;

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
        /// <summary>
        /// Upon addUser_Submit_Click the String in the TextBox and Password in the Password box will be applied sent to
        /// the constructor for an EasyPayUser to be created called newUser.
        /// newUSer will then be passed to the SQLLiteDataAccess SaveUser function, saving it to the database.
        /// A messagebox will display informing the user of a sucessful save.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void addUser_Submit_Click(object sender, RoutedEventArgs e)
        {

            String un;
            String pw;
            String confirmPw;
            //EasyPayUser newUser;

            un = newUsername.Text;
            pw = newPasswordBox.Password;
            confirmPw = confirmPasswordBox.Password;

            if (pw == confirmPw)
            {
                //newUser = new EasyPayUser(un, pw);
                //SQLiteDataAccess.SaveUser(newUser);

                MessageBox.Show("New user added");

                MainWindow dashboard = new MainWindow();
                dashboard.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please make sure passwords match");
            }

        }
    }
}
