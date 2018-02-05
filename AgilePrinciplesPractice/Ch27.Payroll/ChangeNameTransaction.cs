using Payroll;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public class ChangeNameTransaction : ChangeEmployeeTransaction
    {
        private readonly string newName;

        public ChangeNameTransaction(int empId, string newName) : base(empId)
        {
            this.newName = newName;
        }

        protected override void Change(Employee e)
        {
            e.Name = this.newName;
        }
    }
}