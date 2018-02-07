using Payroll;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public abstract class ChangeMethodTransaction : ChangeEmployeeTransaction
    {
        protected abstract PaymentMethod Method { get; }

        public ChangeMethodTransaction(int empId, PayrollDatabase database)
                    : base(empId, database)
        { }

        protected override void Change(Employee e)
        {
            PaymentMethod method = Method;
            e.Method = method;
        }
    }
}