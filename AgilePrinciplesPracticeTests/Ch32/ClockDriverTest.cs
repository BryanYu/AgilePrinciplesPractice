using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgilePrinciplesPractice.Ch32;
using NUnit.Framework;

namespace AgilePrinciplesPracticeTests.Ch32
{
    [TestFixture]
    public class ClockDriverTest
    {
        private MockTimeSource source;

        private MockTimeSink sink;

        [SetUp]
        public void SetUp()
        {
            this.source = new MockTimeSource();
            this.sink = new MockTimeSink();
            this.source.RegisterObserver(this.sink);
        }

        [Test]
        public void TestTimeChange()
        {
            MockTimeSource source = new MockTimeSource();
            MockTimeSink sink = new MockTimeSink();
            source.RegisterObserver(sink);

            source.SetTime(3, 4, 5);
            AssertSinkEquals(sink, 3, 4, 5);

            source.SetTime(7, 8, 9);
            AssertSinkEquals(sink, 7, 8, 9);
        }

        [Test]
        public void TestMultipleSinks()
        {
            MockTimeSink sink2 = new MockTimeSink();
            this.source.RegisterObserver(sink2);
            this.source.SetTime(12, 13, 14);
            AssertSinkEquals(sink2, 12, 13, 14);
        }

        private void AssertSinkEquals(MockTimeSink sink,
                                              int hours,
                                      int mins,
                                      int secs)
        {
            Assert.AreEqual(hours, sink.GetHours());
            Assert.AreEqual(mins, sink.GetMinutes());
            Assert.AreEqual(secs, sink.GetSeconds());
        }
    }
}