using Payroll;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public class ChangeSalariedTransaction : ChangeClassificationTransaction
    {
        private readonly double salary;

        protected override PaymentClassification Classification
        {
            get
            {
                return new SalariedClassification(this.salary);
            }
        }

        protected override PaymentSchedule Schedule
        {
            get
            {
                return new MonthlySchedule();
            }
        }

        public ChangeSalariedTransaction(int empId, double salary) : base(empId)
        {
            this.salary = salary;
        }
    }
}