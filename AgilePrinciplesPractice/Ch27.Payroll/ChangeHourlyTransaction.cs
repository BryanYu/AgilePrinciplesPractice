using Payroll;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public class ChangeHourlyTransaction : ChangeClassificationTransaction
    {
        private readonly double hourlyRate;

        protected override PaymentClassification Classification
        {
            get
            {
                return new HourlyClassification(this.hourlyRate);
            }
        }

        protected override PaymentSchedule Schedule
        {
            get
            {
                return new WeeklySchedule();
            }
        }

        public ChangeHourlyTransaction(int empId, double hourlyRate) : base(empId)
        {
            this.hourlyRate = hourlyRate;
        }
    }
}