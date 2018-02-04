using System;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public class ServiceCharge
    {
        private readonly DateTime _dateTime;
        private readonly double _amount;

        public DateTime DateTime => this._dateTime;
        public double Amount => this._amount;

        public ServiceCharge(DateTime dateTime, double amount)
        {
            _dateTime = dateTime;
            _amount = amount;
        }
    }
}