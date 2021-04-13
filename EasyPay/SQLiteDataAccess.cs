// This class connects to the EasyPayDatabase.
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPay
{
    public class SQLiteDataAccess
    {
        public static List<EasyPayUser> LoadUsers()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<EasyPayUser>("select * from User", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveUser(EasyPayUser user)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into User (USER_NAME, PASSWORD) values (@UserName, @Password)", user);
            }
        }

        public static List<Customer> LoadCustomers()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Customer>("select * from Customer", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveCustomer(Customer customer)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Customer (Customer_ID, First_Name, Last_Name, Email) values (@ID, @FName, @LName, @Email)", customer);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
