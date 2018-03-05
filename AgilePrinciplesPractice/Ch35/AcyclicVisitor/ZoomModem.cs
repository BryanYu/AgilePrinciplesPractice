using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgilePrinciplesPractice.Ch35.AcyclicVisitor
{
    public class ZoomModem
    {
        public int configurationValue = 0;

        public void Dial(string pno)
        {
        }

        public void Hangup()
        {
        }

        public void Send(char c)
        {
        }

        public char Recv()
        {
            return (char)0;
        }

        public void Accept(ModemVisitor v)
        {
            if (v is ZoomModemVisitor)
            {
                (v as ZoomModemVisitor).Visit(this);
            }
        }
    }
}