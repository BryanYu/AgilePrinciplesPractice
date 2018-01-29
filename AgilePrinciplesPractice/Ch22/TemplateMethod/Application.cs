using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPractice.Ch22.TemplateMethod
{
    public abstract class Application
    {
        private bool isDone = false;

        public void Run()
        {
            Init();
            while (!Done())
            {
                Idle();
            }
            CleanUp();
        }

        protected abstract void Init();

        protected abstract void Idle();

        protected abstract void CleanUp();

        protected void SetDone()
        {
            isDone = true;
        }

        protected bool Done()
        {
            return isDone;
        }
    }
}