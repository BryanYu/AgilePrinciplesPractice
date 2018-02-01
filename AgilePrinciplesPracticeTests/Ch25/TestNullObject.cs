using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AgilePrinciplesPracticeTests.Ch25
{
    [TestFixture]
    public class TestNullObject
    {
        [Test]
        public void TestNull()
        {
            Employee e = DB.GetEmployee("Bob");
            if (e.IsTimeToPay(new DateTime()))
            {
                Assert.Fail();
            }

            Assert.AreSame(Employee.NULL, e);
        }
    }
}