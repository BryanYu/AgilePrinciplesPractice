using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgilePrinciplesPractice.Ch20
{
    public class M4ContainmentVessel : ContainmentVessel, IPollable
    {
        private ICoffeeMakerAPI api;

        private WarmerPlateStatus lastPotStatus;

        private bool isBrewing = false;

        public M4ContainmentVessel(ICoffeeMakerAPI api)
        {
            this.api = api;
            lastPotStatus = WarmerPlateStatus.POT_EMPTY;
        }

        public override bool IsReady()
        {
            WarmerPlateStatus status = CoffeeMaker.api.GetWarmerPlateStatus();
            return status == WarmerPlateStatus.POT_EMPTY;
        }

        public void Poll()
        {
            WarmerPlateStatus potStatus = api.GetWarmerPlateStatus();
            if (potStatus != lastPotStatus)
            {
                if (isBrewing)
                {
                    HandleBrewingEvent(potStatus);
                }
                else if (isComplete == false)
                {
                    HandleCompleteEvent(potStatus);
                }

                lastPotStatus = potStatus;
            }
        }

        private void HandleBrewingEvent(WarmerPlateStatus potStatus)
        {
            if (potStatus == WarmerPlateStatus.POT_NOT_EMPTY)
            {
                ContainerAvailable();
                api.SetWarmerState(WarmerState.ON);
            }
            else if (potStatus == WarmerPlateStatus.WARMER_EMPTY)
            {
                ContainerAvailable();
                api.SetWarmerState(WarmerState.OFF);
            }
            else
            {
                ContainerAvailable();
                api.SetWarmerState(WarmerState.OFF);
            }
        }

        private void HandleCompleteEvent(WarmerPlateStatus potStatus)
        {
            if (potStatus == WarmerPlateStatus.POT_NOT_EMPTY)
            {
                api.SetWarmerState(WarmerState.ON);
            }
            else if (potStatus == WarmerPlateStatus.WARMER_EMPTY)
            {
                api.SetWarmerState(WarmerState.OFF);
            }
            else
            {
                api.SetWarmerState(WarmerState.OFF);
                DelcareComplete();
            }
        }
    }
}