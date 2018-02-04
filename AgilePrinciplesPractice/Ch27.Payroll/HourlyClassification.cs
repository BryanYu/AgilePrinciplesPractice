using System;
using System.Collections;
using System.Collections.Generic;
using Payroll;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public class HourlyClassification : PaymentClassification
    {
        private Hashtable _timeCard = new Hashtable();

        public double Salary { get; set; }

        public HourlyClassification(double salary)
        {
            this.Salary = salary;
        }

        public TimeCard GetTimeCard(DateTime dateTime)
        {
            return this._timeCard[dateTime] as TimeCard;
        }

        public void AddTimeCard(TimeCard timeCard)
        {
            this._timeCard[timeCard.Date] = timeCard;
        }
    }
}