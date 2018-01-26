using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPractice.Ch20
{
    public class M4CoffeeMaker
    {
        public static void Main(string[] args)
        {
            M4UserInterface ui = new M4UserInterface(CoffeeMaker.api);
            M4HotWaterSource hws = new M4HotWaterSource(CoffeeMaker.api);
            M4ContainmentVessel cv = new M4ContainmentVessel(CoffeeMaker.api);

            ui.Init(hws, cv);
            hws.Init(ui, cv);
            cv.Init(ui, hws);
            while (true)
            {
                ui.Poll();
                hws.Poll();
                cv.Poll();
            }
        }
    }
}