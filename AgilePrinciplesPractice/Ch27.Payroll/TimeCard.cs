using System;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public class TimeCard
    {
        private readonly DateTime _dateTime;
        private readonly double _hours;

        public DateTime Date => this._dateTime;

        public double Hours => this._hours;

        public TimeCard(DateTime dateTime, double hours)
        {
            _dateTime = dateTime;
            _hours = hours;
        }
    }
}