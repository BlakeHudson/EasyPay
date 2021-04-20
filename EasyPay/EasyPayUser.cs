using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPay
{
    public class EasyPayUser
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public EasyPayUser()
        {

        }

        public EasyPayUser(String un, String pw)
        {
            this.UserName = un;
            this.Password = pw; 
        }
        override
        public String ToString()
        {
            return ("Username: " + this.UserName);
        }
    }
}
