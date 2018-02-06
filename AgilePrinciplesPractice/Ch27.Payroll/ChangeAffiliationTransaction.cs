using Payroll;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public abstract class ChangeAffiliationTransaction : ChangeEmployeeTransaction
    {
        protected abstract Affiliation Affiliation { get; }

        public ChangeAffiliationTransaction(int empId)
            : base(empId)
        {
        }

        protected override void Change(Employee e)
        {
            this.RecordMembership(e);
            Affiliation affiliation = this.Affiliation;
            e.Affiliation = affiliation;
        }

        protected abstract void RecordMembership(Employee e);
    }
}