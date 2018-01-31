using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPractice.Ch24
{
    public interface UserDatabase
    {
        User ReadUser(string userName);

        void WriteUser(User user);
    }
}