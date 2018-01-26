using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgilePrinciplesPractice.Ch20
{
    public abstract class ContainmentVessel
    {
        protected bool isBrewing;
        protected bool isComplete;
        private UserInterface ui;
        private HotWaterSource hws;

        public ContainmentVessel()
        {
            isBrewing = false;
            isComplete = true;
        }

        public void Init(UserInterface ui, HotWaterSource hws)
        {
            this.ui = ui;
            this.hws = hws;
        }

        public void Start()
        {
            isBrewing = true;
            isComplete = false;
        }

        public void Done()
        {
            isBrewing = false;
        }

        public abstract bool IsReady();

        protected void DelcareComplete()
        {
            isComplete = true;
            ui.Complete();
        }

        protected void ContainerAvailable()
        {
            hws.Resume();
        }

        protected void ContainerUnavailable()
        {
            hws.Pause();
        }
    }
}