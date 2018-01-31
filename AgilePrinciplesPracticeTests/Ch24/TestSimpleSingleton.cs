using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AgilePrinciplesPractice.Ch24;
using NUnit.Framework;

namespace AgilePrinciplesPracticeTests.Ch24
{
    [TestFixture]
    public class TestSimpleSingleton
    {
        [Test]
        public void TestCreateSingleton()
        {
            Singleton s = Singleton.Instance;
            Singleton s2 = Singleton.Instance;
            Assert.AreSame(s, s2);
        }

        [Test]
        public void TestNoPublicConstructors()
        {
            Type singleton = typeof(Singleton);
            ConstructorInfo[] ctrs = singleton.GetConstructors();
            bool hasPublicConstructor = false;
            foreach (var c in ctrs)
            {
                if (c.IsPublic)
                {
                    hasPublicConstructor = true;
                    break;
                }
            }

            Assert.IsFalse(hasPublicConstructor);
        }
    }
}