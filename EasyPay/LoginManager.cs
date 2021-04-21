using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPay
{
    class LoginManager
    {
        
        /// <summary>
        /// Checks for a match between password entered and pasword saved in database for a given user based on index of
        /// the EasyPayUser in the List returned.
        /// </summary>
        /// <param name="index">int index of EasyPayUser location in List</param>
        /// <param name="pw">String password entered in login screen</param>
        /// <returns>True if password mathches pw at given index</returns>
        public static Boolean validPassword(int index, String pw)
        {
            List<EasyPayUser> userList = SQLiteDataAccess.LoadUsers();
            EasyPayUser currentUser = userList.ElementAt(index);

            if(Encode_Decode.Decrypt(currentUser.Password) == pw)
            {
                return true;
            }
            else
            {
                return false;
            }
         
        }
        /// <summary>
        /// Returns the index of an EasyPayUser based on username 
        /// </summary>
        /// <param name="enteredUser">String username</param>
        /// <returns>int index of location on LoadUsers, otherwise -1 if nonexistent() list</returns>
        public static int indexOfUser(String enteredUser)
        {
            List<EasyPayUser> userList = SQLiteDataAccess.LoadUsers();

            foreach (EasyPayUser user in userList)
            {
                if (user.UserName == enteredUser)
                {
                    return userList.IndexOf(user);
                }
            }
            return -1;
        }


    }
}
