using Payroll;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public class ChangeMemberTransaction : ChangeAffiliationTransaction
    {
        private readonly int memberId;

        private readonly double dues;

        protected override Affiliation Affiliation
        {
            get
            {
                return new UnionAffiliation(this.memberId, this.dues);
            }
        }

        public ChangeMemberTransaction(int empId, int memberId, double dues) : base(empId)
        {
            this.memberId = memberId;
            this.dues = dues;
        }

        protected override void RecordMembership(Employee e)
        {
            PayrollDatabase.AddUnionMember(this.memberId, e);
        }
    }
}