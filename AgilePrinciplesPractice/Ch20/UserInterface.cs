using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPractice.Ch20
{
    public abstract class UserInterface
    {
        protected bool isComplete;
        private HotWaterSource _hotWaterSource;

        private ContainmentVessel _containmentVessel;

        public void Complete()
        {
            isComplete = true;
            CompleteCycle();
        }

        public void Init(HotWaterSource hws, ContainmentVessel cv)
        {
            this._hotWaterSource = hws;
            this._containmentVessel = cv;
        }

        public abstract void CompleteCycle();

        public abstract void Done();

        protected void StartBrewing()
        {
            if (_hotWaterSource.IsReady() && _containmentVessel.IsReady())
            {
                isComplete = false;
                _hotWaterSource.Start();
                _containmentVessel.Start();
            }
        }
    }
}