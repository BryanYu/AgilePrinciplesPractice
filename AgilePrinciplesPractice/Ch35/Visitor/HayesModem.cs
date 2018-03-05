using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgilePrinciplesPractice.Ch35.Visitor
{
    public class HayesModem : Modem
    {
        public string configurationString = null;

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
            v.Visit(this);
        }
    }
}