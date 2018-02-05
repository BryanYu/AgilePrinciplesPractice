using Payroll;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public abstract class ChangeMehtodTransaction : ChangeEmployeeTransaction
    {
        protected abstract PaymentMethod Method { get; }

        public ChangeMehtodTransaction(int empId) : base(empId)
        {
        }

        protected override void Change(Employee e)
        {
            e.Method = this.Method;
        }
    }
}