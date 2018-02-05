using Payroll;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public class ChangeMailTransaction : ChangeMehtodTransaction
    {
        protected override PaymentMethod Method
        {
            get
            {
                return new MailMethod();
            }
        }

        public ChangeMailTransaction(int empId) : base(empId)
        {
        }
    }
}