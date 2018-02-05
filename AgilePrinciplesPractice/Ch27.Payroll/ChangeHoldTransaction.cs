using Payroll;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public class ChangeHoldTransaction : ChangeMehtodTransaction
    {
        protected override PaymentMethod Method
        {
            get
            {
                return new HoldMethod();
            }
        }

        public ChangeHoldTransaction(int empId) : base(empId)
        {
        }
    }
}