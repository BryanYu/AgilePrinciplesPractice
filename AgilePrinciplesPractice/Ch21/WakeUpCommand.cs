using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgilePrinciplesPractice.Ch21
{
    public class WakeUpCommand : Command
    {
        public bool executed = false;

        public void Execute()
        {
            executed = true;
        }
    }
}