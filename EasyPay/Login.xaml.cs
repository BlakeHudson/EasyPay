using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

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

                AddUser addUser = new AddUser();
                addUser.Show();
                this.Close();
            }

        }
        /// <summary>
        /// Handles login credienteials by verifying if the Username is contained in the db,
        /// then checks for password accuracy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Submit_Click(object sender, RoutedEventArgs e)
        {
            // Username entered in Username Text box
            string unEntered = Username.Text;
            int userIndex = LoginManager.indexOfUser(unEntered);
           
            // If the username is valid and password is correct continue, else bad credientials
            if (userIndex >= 0 && LoginManager.validPassword(userIndex, unEntered))
            {

                MainWindow dashboard = new MainWindow();
                //dashboard.Show();  
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
