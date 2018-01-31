using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgilePrinciplesPractice.Ch24;
using NUnit.Framework;

namespace AgilePrinciplesPracticeTests.Ch24
{
    [TestFixture]
    public class TurnstileTest
    {
        [SetUp]
        public void SetUp()
        {
            Turnstile t = new Turnstile();
            t.Reset();
        }

        [Test]
        public void TestInit()
        {
            Turnstile t = new Turnstile();
            Assert.IsTrue(t.Locked());
            Assert.IsFalse(t.Alarm());
        }

        [Test]
        public void TestCoin()
        {
            Turnstile t = new Turnstile();
            t.Coin();
            Turnstile t1 = new Turnstile();
            Assert.IsFalse(t1.Locked());
            Assert.IsFalse(t1.Alarm());
            Assert.AreEqual(1, t1.Coins);
        }

        [Test]
        public void TestCoinAndPass()
        {
            Turnstile t = new Turnstile();
            t.Coin();
            t.Pass();

            Turnstile t1 = new Turnstile();
            Assert.IsTrue(t1.Locked());
            Assert.IsFalse(t1.Alarm());
            Assert.AreEqual(1, t1.Coins, "coins");
        }

        [Test]
        public void TestTwoCoins()
        {
            Turnstile t = new Turnstile();
            t.Coin();
            t.Coin();

            Turnstile t1 = new Turnstile();
            Assert.IsFalse(t1.Locked(), "unlocked");
            Assert.AreEqual(1, t1.Coins, "coins");
            Assert.AreEqual(1, t1.Refunds, "refunds");
            Assert.IsFalse(t1.Alarm());
        }

        [Test]
        public void TestPass()
        {
            Turnstile t = new Turnstile();
            t.Pass();

            Turnstile t1 = new Turnstile();
            Assert.IsTrue(t1.Alarm(), "alarm");
            Assert.IsTrue(t1.Locked(), "locked");
        }

        [Test]
        public void TestCancelAlarm()
        {
            Turnstile t = new Turnstile();
            t.Pass();
            t.Coin();

            Turnstile t1 = new Turnstile();
            Assert.IsFalse(t1.Alarm(), "alarm");
            Assert.IsFalse(t1.Locked(), "locked");
            Assert.AreEqual(1, t1.Coins, "coin");
            Assert.AreEqual(0, t1.Refunds, "refund");
        }

        [Test]
        public void TestTwoOperations()
        {
            Turnstile t = new Turnstile();
            t.Coin();
            t.Pass();
            t.Coin();
            Assert.IsFalse(t.Locked(), "unlocked");
            Assert.AreEqual(2, t.Coins, "coins");
            t.Pass();
            Assert.IsTrue(t.Locked(), "locked");
        }
    }
}