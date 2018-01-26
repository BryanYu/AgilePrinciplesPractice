using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AgilePrinciplesPractice.Ch20
{
    public abstract class HotWaterSource
    {
        protected bool isBrewing;
        private UserInterface ui;
        private ContainmentVessel cv;

        public HotWaterSource()
        {
            isBrewing = false;
        }

        public void Init(UserInterface ui, ContainmentVessel cv)
        {
            this.ui = ui;
            this.cv = cv;
        }

        public void Start()
        {
            isBrewing = true;
            StartBrewing();
        }

        public void Done()
        {
            isBrewing = false;
        }

        public abstract bool IsReady();

        public abstract void StartBrewing();

        public abstract void Pause();

        public abstract void Resume();

        protected void DeclareDone()
        {
            ui.Done();
            cv.Done();
            isBrewing = false;
        }
    }
}