using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgilePrinciplesPractice.Ch36
{
    public interface TurnSiteController
    {
        void Lock();

        void UnLock();

        void ThankYou();

        void Alarm();
    }
}