using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgilePrinciplesPractice.Ch22.Strategy
{
    public interface Application
    {
        void Init();

        void Idle();

        void CleanUp();

        bool Done();
    }
}