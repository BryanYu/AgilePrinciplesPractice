using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgilePrinciplesPractice.Ch6;
using NUnit.Framework;

namespace AgilePrinciplesPracticeTests.Ch6
{
    [TestFixture()]
    public class FrameTest
    {
        [Test]
        public void TestScoreNoThrows()
        {
            Frame f = new Frame();
            Assert.AreEqual(0, f.Score);
        }

        [Test]
        public void TestAddOneThrow()
        {
            Frame f = new Frame();
            f.Add(5);
            Assert.AreEqual(5, f.Score);
        }
    }
}