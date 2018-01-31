using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgilePrinciplesPractice.Ch24;

namespace AgilePrinciplesPractice.Ch24
{
    public class Turnstile
    {
        protected static readonly Turnstile LOCKED = new Locked();
        protected static readonly Turnstile UNLOCKED = new Unlocked();
        protected static Turnstile iteState = LOCKED;
        private static bool isLocked = true;
        private static bool isAlarming = false;
        private static int itsCoins = 0;
        private static int itsRefunds = 0;

        public int Coins
        {
            get { return itsCoins; }
        }

        public int Refunds
        {
            get { return itsRefunds; }
        }

        public void Deposit()
        {
            itsCoins++;
        }

        public void Refund()
        {
            itsRefunds++;
        }

        public void Reset()
        {
            Lock(true);
            Alarm(false);
            itsCoins = 0;
            itsRefunds = 0;
            iteState = LOCKED;
        }

        public bool Locked()
        {
            return isLocked;
        }

        public bool Alarm()
        {
            return isAlarming;
        }

        public virtual void Coin()
        {
            iteState.Coin();
        }

        public virtual void Pass()
        {
            iteState.Pass();
        }

        protected void Lock(bool shouldLock)
        {
            isLocked = shouldLock;
        }

        protected void Alarm(bool shouldAlarm)
        {
            isAlarming = shouldAlarm;
        }
    }
}