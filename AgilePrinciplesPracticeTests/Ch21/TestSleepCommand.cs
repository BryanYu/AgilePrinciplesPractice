using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgilePrinciplesPractice.Ch21;
using NUnit.Framework;

namespace AgilePrinciplesPracticeTests.Ch21
{
    [TestFixture]
    public class TestSleepCommand
    {
        public void TestSleep()
        {
            WakeUpCommand wakeup = new WakeUpCommand();
            ActiveObjectEngine e = new ActiveObjectEngine();
            SleepCommand c = new SleepCommand(1000, e, wakeup);
            e.AddCommand(c);
            DateTime start = DateTime.Now;
            e.Run();
            DateTime stop = DateTime.Now;
            double sleepTime = (stop - start).TotalMilliseconds;
            Assert.IsTrue(sleepTime >= 1000, "SleepTime" + sleepTime + "exepected > 1000");
            Assert.IsTrue(sleepTime <= 1100, "SleepTime " + sleepTime + "expected < 1100");
            Assert.IsTrue(wakeup.executed, "Command Executed");
        }
    }
}