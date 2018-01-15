using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AgilePrinciplesPracticeTests.Ch4
{
    [TestFixture]
    public class Ch4SampleTest
    {
        [Test]
        public void TestMove()
        {
            WumpusGame g = new WumpusGame();
            g.Connect(4, 5, "E");
            g.GetPlayerRoom(4);
            g.East();
            Assert.AreEqual(5, g.GetPlayerRoom());
        }
    }
}