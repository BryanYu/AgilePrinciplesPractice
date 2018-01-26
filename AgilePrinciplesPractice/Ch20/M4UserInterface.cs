using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPractice.Ch20
{
    public class M4UserInterface : UserInterface, IPollable
    {
        private ICoffeeMakerAPI api;

        public M4UserInterface(ICoffeeMakerAPI api)
        {
            this.api = api;
        }

        public void Poll()
        {
            BrewButtonStatus status = api.GetBrewButtonStatus();
            if (status == BrewButtonStatus.PUSHED)
            {
                StartBrewing();
            }
        }

        public override void CompleteCycle()
        {
            api.SetIndicatorState(IndicatorState.OFF);
        }

        public override void Done()
        {
            api.SetIndicatorState(IndicatorState.ON);
        }

        private void CheckButton()
        {
            BrewButtonStatus status = CoffeeMaker.api.GetBrewButtonStatus();
            if (status == BrewButtonStatus.PUSHED)
            {
                StartBrewing();
            }
        }
    }
}