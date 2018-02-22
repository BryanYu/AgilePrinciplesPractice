using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgilePrinciplesPractice.Ch32
{
    public interface TimeSource
    {
        int GetHours();

        int GetMinutes();

        int GetSeconds();
    }
}