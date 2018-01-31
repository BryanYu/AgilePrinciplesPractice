using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgilePrinciplesPractice.Ch24;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AgilePrinciplesPracticeTests.Ch24
{
    [TestFixture]
    public class TestMonostate
    {
        [Test]
        public void TestInstance()
        {
            Monostate m = new Monostate();
            for (int x = 0; x < 10; x++)
            {
                m.X = x;
                Assert.AreEqual(x, m.X);
            }
        }

        public void TestInstancesBehaveAsOne()
        {
            Monostate m1 = new Monostate();
            Monostate m2 = new Monostate();

            for (int x = 0; x < 10; x++)
            {
                m1.X = x;
                Assert.AreEqual(x, m2.X);
            }
        }
    }
}