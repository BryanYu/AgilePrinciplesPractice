using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgilePrinciplesPractice.Ch35.Decorator;
using NUnit.Framework;

namespace AgilePrinciplesPracticeTests.Ch35
{
    [TestFixture]
    public class ModemDecoratorTest
    {
        [Test]
        public void CreateHayes()
        {
            Modem m = new HayesModem();
            Assert.AreEqual(null, m.PhoneNumber);
            m.Dial("5551212");
            Assert.AreEqual("5551212", m.PhoneNumber);
            Assert.AreEqual(0, m.SpeakerVolume);
            m.SpeakerVolume = 10;
            Assert.AreEqual(10, m.SpeakerVolume);
        }

        [Test]
        public void LoudDialModem()
        {
            Modem m = new HayesModem();
            Modem d = new LoudDialModem(m);
            Assert.AreEqual(null, d.PhoneNumber);
            Assert.AreEqual(0, d.SpeakerVolume);
            d.Dial("5551212");
            Assert.AreEqual("5551212", d.PhoneNumber);
            Assert.AreEqual(10, d.SpeakerVolume);
        }
    }
}