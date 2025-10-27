using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Bank
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Account Account { get; set; }
        
        public User(string username, string password,Account account)
        {
            Username = username;
            Password = password;
            Account = account;


        }
    }
     
    

}
