using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPay
{
    public class EasyPayUser
    {
        public string User_Name { get; set; }

        public string Password { get; set; }

        public EasyPayUser()
        {

        }

        public EasyPayUser(String un, String pw)
        {
            this.User_Name = un;
            this.Password = pw; 
        }
        override
        public String ToString()
        {
            return ("Username: " + this.User_Name);
        }
    }
}
