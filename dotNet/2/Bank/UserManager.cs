using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class UserManager
    {
        private List<User> users = new List<User>();

        public bool Register(string username, string password, decimal initialBalance)
        {
            if (users.Exists(u => u.Username == username))
            {
                return false; 
            }

            
            Account account = new Account(username, initialBalance);
            users.Add(new User(username, password, account));
            return true;
        }

        public User Login(string username, string password)
        {
            return users.Find(u => u.Username == username && u.Password == password);
        }

        
        public User this[string username]
        {
            get
            {
                return users.Find(u => u.Username == username);
            }
            set { }
        }
    }
}
