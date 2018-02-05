using Payroll;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public abstract class ChangeClassificationTransaction : ChangeEmployeeTransaction
    {
        protected abstract PaymentClassification Classification { get; }

        protected abstract PaymentSchedule Schedule { get; }

        protected ChangeClassificationTransaction(int empId) : base(empId)
        {
        }

        protected override void Change(Employee e)
        {
            e.Classification = this.Classification;
            e.Schedule = this.Schedule;
        }
    }
}