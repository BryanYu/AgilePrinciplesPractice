using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgilePrinciplesPracticeTests.Ch25
{
    public abstract class Employee
    {
        public static readonly Employee NULL = new NullEmployee();

        public abstract bool IsTimeToPay(DateTime time);

        public abstract void Pay();

        private class NullEmployee : Employee
        {
            public override void Pay()
            {
            }

            public override bool IsTimeToPay(DateTime time)
            {
                return false;
            }
        }
    }
}