using Payroll;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public class AddHourlyEmployee : AddEmployeeTransaction
    {
        private readonly double _hourlyRate;

        public AddHourlyEmployee(int empId, string name, string address, double hourlyRate) : base(empId, name, address)
        {
            _hourlyRate = hourlyRate;
        }

        protected override PaymentClassification MakeClassification()
        {
            return new HourlyClassification(_hourlyRate);
        }

        protected override PaymentSchedule MakeSchedule()
        {
            return new WeeklySchedule();
        }
    }
}