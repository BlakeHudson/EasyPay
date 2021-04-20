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

            String un;          // To store username
            String pw;          // To store entered password
            String confirmPw;   // To store confirmed password
            EasyPayUser newUser;// Init new EasyPayUser
            
            // Store entered username and encrypted passwords
            un = newUsername.Text;
            pw = Encode_Decode.Encrypt(newPasswordBox.Password);
            confirmPw = Encode_Decode.Encrypt(confirmPasswordBox.Password);
            
            /* If password entered and confrirm passwords match, proceed to
            * create an EasyPayUser with data etered and save it to db
            * Inform user that a new user was added and open main window
            */
            if (pw == confirmPw)
            {
                newUser = new EasyPayUser(un, pw);
                SQLiteDataAccess.SaveUser(newUser);

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
