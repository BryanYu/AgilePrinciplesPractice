using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgilePrinciplesPractice.Ch20
{
    public class M4ContainmentVessel : ContainmentVessel
    {
        private ICoffeeMakerAPI api;

        private bool isBrewing = false;

        public M4ContainmentVessel(ICoffeeMakerAPI api)
        {
            this.api = api;
        }

        public override bool IsReady()
        {
            WarmerPlateStatus status = CoffeeMaker.api.GetWarmerPlateStatus();
            return status == WarmerPlateStatus.POT_EMPTY;
        }

        public override void Start()
        {
            isBrewing = true;
        }
    }
}