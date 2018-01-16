using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgilePrinciplesPractice.Ch6;
using NUnit.Framework;

namespace AgilePrinciplesPracticeTests.Ch6
{
    [TestFixture]
    public class GameTest
    {
        private Game _game;

        [SetUp]
        public void SetUp()
        {
            this._game = new Game();
        }

        [Test]
        public void TestTwoThrowsNoMark()
        {
            this._game.Add(5);
            this._game.Add(4);
            Assert.AreEqual(9, this._game.Score);
        }

        [Test]
        public void TestFourThrowsNoMark()
        {
            this._game.Add(5);
            this._game.Add(4);
            this._game.Add(7);
            this._game.Add(2);
            Assert.AreEqual(18, this._game.Score);
            Assert.AreEqual(9, this._game.ScoreForFrame(1));
            Assert.AreEqual(18, this._game.ScoreForFrame(2));
            Assert.AreEqual(3, this._game.CuurentFrame);
        }

        [Test]
        public void TestSimpleSpare()
        {
            this._game.Add(3);
            this._game.Add(7);
            this._game.Add(3);
            Assert.AreEqual(13, this._game.ScoreForFrame(1));
            Assert.AreEqual(2, this._game.CuurentFrame);
        }

        [Test]
        public void TestSimpleFrameAfterSpare()
        {
            this._game.Add(3);
            this._game.Add(7);
            this._game.Add(3);
            this._game.Add(2);
            Assert.AreEqual(13, this._game.ScoreForFrame(1));
            Assert.AreEqual(18, this._game.ScoreForFrame(2));
            Assert.AreEqual(18, this._game.Score);
            Assert.AreEqual(3, this._game.CuurentFrame);
        }

        [Test]
        public void TestSimpleStike()
        {
            this._game.Add(10);
            this._game.Add(3);
            this._game.Add(6);
            Assert.AreEqual(19, this._game.ScoreForFrame(1));
            Assert.AreEqual(28, this._game.Score);
        }

        [Test]
        public void TestPerfectGame()
        {
            for (int i = 0; i < 12; i++)
            {
                this._game.Add(10);
            }

            Assert.AreEqual(300, this._game.Score);
        }

        [Test]
        public void TestEndOfArray()
        {
            for (int i = 0; i < 9; i++)
            {
                this._game.Add(0);
                this._game.Add(0);
            }
            this._game.Add(2);
            this._game.Add(8);
            this._game.Add(10);
            Assert.AreEqual(20, this._game.Score);
        }

        [Test]
        public void TestSampleGame()
        {
            this._game.Add(1);
            this._game.Add(4);
            this._game.Add(4);
            this._game.Add(5);
            this._game.Add(6);
            this._game.Add(4);
            this._game.Add(5);
            this._game.Add(5);
            this._game.Add(10);
            this._game.Add(0);
            this._game.Add(1);
            this._game.Add(7);
            this._game.Add(3);
            this._game.Add(6);
            this._game.Add(4);
            this._game.Add(10);
            this._game.Add(2);
            this._game.Add(8);
            this._game.Add(6);
            Assert.AreEqual(133, this._game.Score);
        }

        [Test]
        public void TestHeartBreak()
        {
            for (int i = 0; i < 11; i++)
            {
                this._game.Add(10);
            }

            this._game.Add(9);
            Assert.AreEqual(299, this._game.Score);
        }

        [Test]
        public void TestTenthFrameSpare()
        {
            for (int i = 0; i < 9; i++)
            {
                this._game.Add(10);
            }
            this._game.Add(9);
            this._game.Add(1);
            this._game.Add(1);
            Assert.AreEqual(270, this._game.Score);
        }
    }
}