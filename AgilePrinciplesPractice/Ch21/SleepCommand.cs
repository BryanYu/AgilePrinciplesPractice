using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgilePrinciplesPractice.Ch21
{
    public class SleepCommand : Command
    {
        private Command wakeCommand = null;

        private ActiveObjectEngine engine = null;

        private long sleepTime = 0;

        private DateTime startTime;

        private bool started = false;

        public SleepCommand(long milliseconds, ActiveObjectEngine e, Command wakeUpCommand)
        {
            this.sleepTime = milliseconds;
            this.engine = e;
            this.wakeCommand = wakeUpCommand;
        }

        public void Execute()
        {
            DateTime currentTime = DateTime.Now;
            if (!started)
            {
                started = true;
                startTime = currentTime;
                engine.AddCommand(this);
            }
            else
            {
                TimeSpan elapseTime = currentTime - startTime;
                if (elapseTime.TotalMilliseconds < sleepTime)
                {
                    engine.AddCommand(this);
                }
                else
                {
                    engine.AddCommand(wakeCommand);
                }
            }
        }
    }
}