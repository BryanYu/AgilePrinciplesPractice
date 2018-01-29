using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilePrinciplesPractice.Ch21
{
    public class DelayedTyper : Command
    {
        private static bool stop = false;

        private static ActiveObjectEngine engine = new ActiveObjectEngine();

        private long itsDelay;

        private char itsChar;

        public DelayedTyper(long itsDelay, char itsChar)
        {
            this.itsDelay = itsDelay;
            this.itsChar = itsChar;
        }

        public static void Main(string[] args)
        {
            engine.AddCommand(new DelayedTyper(100, '1'));
            engine.AddCommand(new DelayedTyper(300, '3'));
            engine.AddCommand(new DelayedTyper(500, '5'));
            engine.AddCommand(new DelayedTyper(700, '7'));

            Command stopCommand = new StopCommand();
            engine.AddCommand(new SleepCommand(20000, engine, stopCommand));
            engine.Run();
        }

        public void Execute()
        {
            Console.WriteLine(itsChar);
            if (!stop)
            {
                DelayAndRepeat();
            }
        }

        private void DelayAndRepeat()
        {
            engine.AddCommand(new SleepCommand(itsDelay, engine, this));
        }

        private class StopCommand : Command
        {
            public void Execute()
            {
                DelayedTyper.stop = true;
            }
        }
    }
}