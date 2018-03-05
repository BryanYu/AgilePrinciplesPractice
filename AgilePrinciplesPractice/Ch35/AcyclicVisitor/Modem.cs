using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgilePrinciplesPractice.Ch35.AcyclicVisitor;

namespace AgilePrinciplesPractice.Ch35.AcycliVisitor
{
    public interface Modem
    {
        void Dial(string pno);

        void Hangup();

        void Send(char c);

        char Recv();

        void Accept(ModemVisitor v);
    }
}