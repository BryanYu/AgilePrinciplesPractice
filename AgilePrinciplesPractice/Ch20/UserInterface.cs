using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPractice.Ch20
{
    public class UserInterface
    {
        private HotWaterSource _hotWaterSource;

        private ContainmentVessel _containmentVessel;

        public void Done()
        {
        }

        public void Complete()
        {
        }

        protected void StartBrewing()
        {
            if (_hotWaterSource.IsReady() && _containmentVessel.IsReady())
            {
                _hotWaterSource.Start();
                _containmentVessel.Start();
            }
        }
    }
}