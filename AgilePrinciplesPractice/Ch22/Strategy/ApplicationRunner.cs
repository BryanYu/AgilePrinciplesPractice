using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPractice.Ch22.Strategy
{
    public class ApplicationRunner
    {
        private Application itsApplication = null;

        public ApplicationRunner(Application app)
        {
            this.itsApplication = app;
        }

        public void Run()
        {
            itsApplication.Init();
            while (!itsApplication.Done())
            {
                itsApplication.Idle();
            }

            itsApplication.CleanUp();
            {
            }
        }
    }
}