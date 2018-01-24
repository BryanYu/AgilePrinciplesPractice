using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPractice.Ch20
{
    public class M4UserInterface : UserInterface
    {
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