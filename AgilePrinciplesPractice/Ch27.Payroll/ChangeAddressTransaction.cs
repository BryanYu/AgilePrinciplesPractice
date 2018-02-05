using Payroll;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public class ChangeAddressTransaction : ChangeEmployeeTransaction
    {
        private readonly string address;

        public ChangeAddressTransaction(int empId, string address)
            : base(empId)
        {
            this.address = address;
        }

        protected override void Change(Employee e)
        {
            e.Address = this.address;
        }
    }
}