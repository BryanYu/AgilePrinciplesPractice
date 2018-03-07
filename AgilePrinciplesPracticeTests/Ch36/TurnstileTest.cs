using AgilePrinciplesPractice.Ch36;
using NUnit.Framework;

namespace AgilePrinciplesPracticeTests.Ch36
{
    [TestFixture]
    public class TurnstileTest
    {
        private TurnStile turnStile;

        private TurnstileControllerSpoof controllerSpoof;

        [SetUp]
        public void SetUp()
        {
            controllerSpoof = new TurnstileControllerSpoof();
            this.turnStile = new TurnStile(this.controllerSpoof);
        }

        [Test]
        public void InitialConditions()
        {
            Assert.AreEqual(State.Locked, turnStile.state);
        }

        [Test]
        public void CoinInLockedState()
        {
            this.turnStile.state = State.Locked;
            this.turnStile.HandleEvent(Event.COIN);
            Assert.AreEqual(State.UnLocked, this.turnStile.state);
            Assert.IsTrue(this.controllerSpoof.unlockCalled);
        }

        [Test]
        public void CoinInUnLockedState()
        {
            this.turnStile.state = State.UnLocked;
            this.turnStile.HandleEvent(Event.COIN);
            Assert.AreEqual(State.UnLocked, this.turnStile.state);
            Assert.IsTrue(this.controllerSpoof.unlockCalled);
        }

        [Test]
        public void PassInLockedState()
        {
            this.turnStile.state = State.Locked;
            this.turnStile.HandleEvent(Event.PASS);
            Assert.AreEqual(State.Locked, this.turnStile.state);
            Assert.IsTrue(this.controllerSpoof.thankyouCalled);
        }

        [Test]
        public void PassInUnlockedState()
        {
            this.turnStile.state = State.UnLocked;
            this.turnStile.HandleEvent(Event.PASS);
            Assert.AreEqual(State.Locked, this.turnStile.state);
            Assert.IsTrue(this.controllerSpoof.lockCalled);
        }

        private class TurnstileControllerSpoof : TurnSiteController
        {
            public bool lockCalled = false;

            public bool unlockCalled = false;

            public bool thankyouCalled = false;

            public bool alarmCalled = false;

            public void Lock()
            {
                this.lockCalled = true;
            }

            public void UnLock()
            {
                this.unlockCalled = true;
            }

            public void ThankYou()
            {
                this.thankyouCalled = true;
            }

            public void Alarm()
            {
                this.alarmCalled = true;
            }
        }
    }
}