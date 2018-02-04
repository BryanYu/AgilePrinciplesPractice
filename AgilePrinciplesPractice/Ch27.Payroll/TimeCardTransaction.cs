using System;
using Payroll;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public class TimeCardTransaction : Transaction
    {
        private readonly DateTime date;
        private readonly double hours;
        private readonly int empId;

        public TimeCardTransaction(DateTime dateTime, double hours, int empId)
        {
            this.date = dateTime;
            this.hours = hours;
            this.empId = empId;
        }

        public void Execute()
        {
            Employee e = PayrollDatabase.GetEmployee(this.empId);
            if (e != null)
            {
                if (e.Classification is HourlyClassification hc)
                {
                    hc.AddTimeCard(new TimeCard(this.date, this.hours));
                }
                else
                {
                    throw new InvalidOperationException("Tried to add timecard to" + "non hourly employee");
                }
            }
            else
            {
                throw new InvalidOperationException("no such employee");
            }
        }
    }
}