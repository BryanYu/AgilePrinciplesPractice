using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgilePrinciplesPractice.Ch24
{
    public class Unlocked : Turnstile
    {
        public override void Coin()
        {
            Refund();
        }

        public override void Pass()
        {
            Lock(true);
            iteState = LOCKED;
        }
    }
}