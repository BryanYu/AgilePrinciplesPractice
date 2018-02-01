using Payroll;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public class AddHourlyEmployee : AddEmployeeTransaction
    {
        private readonly int _hourlyRate;

        public AddHourlyEmployee(int empId, string name, string address, int hourlyRate) : base(empId, name, address)
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