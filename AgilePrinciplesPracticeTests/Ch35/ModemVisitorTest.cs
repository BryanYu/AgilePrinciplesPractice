using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgilePrinciplesPractice.Ch35.Visitor;
using NUnit.Framework;

namespace AgilePrinciplesPracticeTests.Ch35
{
    [TestFixture]
    public class ModemVisitorTest
    {
        private UnixModemConfigurator v;

        private HayesModem h;

        private ZoomModem z;

        private ErnieModem e;

        [SetUp]
        public void SetUp()
        {
            this.v = new UnixModemConfigurator();
            this.h = new HayesModem();
            this.z = new ZoomModem();
            this.e = new ErnieModem();
        }

        [Test]
        public void HayesForUnix()
        {
            this.h.Accept(v);
            Assert.AreEqual("&s1=4&D=3", h.configurationString);
        }

        [Test]
        public void ZoomForUnix()
        {
            this.z.Accept(v);
            Assert.AreEqual(42, z.configurationValue);
        }

        [Test]
        public void ErnieForUnix()
        {
            this.e.Accept(v);
            Assert.AreEqual("c is too slow", e.internalPattern);
        }
    }
}