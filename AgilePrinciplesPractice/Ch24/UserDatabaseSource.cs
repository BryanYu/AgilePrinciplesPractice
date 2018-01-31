using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPractice.Ch24
{
    public class UserDatabaseSource : UserDatabase
    {
        private static UserDatabase thisInstance = new UserDatabaseSource();

        public static UserDatabase Instance
        {
            get { return thisInstance; }
        }

        public User ReadUser(string userName)
        {
            throw new NotImplementedException();
        }

        public void WriteUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}