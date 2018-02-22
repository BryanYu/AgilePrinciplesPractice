namespace AgilePrinciplesPractice.Ch32
{
    public class MockTimeSink : Observer
    {
        private int hours;

        private int minutes;

        private int seconds;

        private TimeSource timeSource;

        public int GetHours()
        {
            return this.hours;
        }

        public int GetMinutes()
        {
            return this.minutes;
        }

        public int GetSeconds()
        {
            return this.seconds;
        }

        public void Update()
        {
            hours = this.timeSource.GetHours();
            minutes = this.timeSource.GetMinutes();
            seconds = this.timeSource.GetSeconds();
        }
    }
}