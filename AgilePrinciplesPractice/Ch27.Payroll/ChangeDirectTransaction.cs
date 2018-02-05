using Payroll;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public class ChangeDirectTransaction : ChangeMehtodTransaction
    {
        protected override PaymentMethod Method
        {
            get
            {
                return new DirectMethod();
            }
        }

        public ChangeDirectTransaction(int empId) : base(empId)
        {
        }
    }
}