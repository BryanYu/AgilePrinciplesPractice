using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgilePrinciplesPractice.Ch20
{
    public abstract class HotWaterSource
    {
        public abstract void Start();

        public abstract bool IsReady();
    }
}