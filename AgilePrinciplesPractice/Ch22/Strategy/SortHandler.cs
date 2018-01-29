using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgilePrinciplesPractice.Ch22.Strategy
{
    public interface SortHandler
    {
        void Swap(int index);

        bool OutOfOrder(int index);

        int Length();

        void SetArray(object array);
    }
}