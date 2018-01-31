using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgilePrinciplesPractice.Ch24
{
    public class Locked : Turnstile
    {
        public override void Coin()
        {
            iteState = UNLOCKED;
            Lock(false);
            Alarm(false);
            Deposit();
        }

        public override void Pass()
        {
            Alarm(true);
        }
    }
}