using System.Collections;

namespace AgilePrinciplesPractice.Ch32
{
    public class MockTimeSource : Subject, TimeSource
    {
        private int hours;

        private int mins;

        private int secs;

        public void SetTime(int hours,
                            int mins,
                            int secs)
        {
            this.hours = hours;
            this.mins = mins;
            this.secs = secs;
            NotifyObservers();
        }

        public int GetHours()
        {
            return this.hours;
        }

        public int GetMinutes()
        {
            return this.mins;
        }

        public int GetSeconds()
        {
            return this.secs;
        }
    }
}