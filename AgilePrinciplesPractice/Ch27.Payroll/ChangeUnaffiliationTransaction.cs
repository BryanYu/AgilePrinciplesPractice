using Payroll;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public class ChangeUnaffiliationTransaction : ChangeAffiliationTransaction
    {
        protected override Affiliation Affiliation { get { return new NoAffiliation(); } }

        public ChangeUnaffiliationTransaction(int empId)
            : base(empId)
        {
        }

        protected override void RecordMembership(Employee e)
        {
            Affiliation af = e.Affiliation;
            if (af is UnionAffiliation)
            {
                UnionAffiliation unionAffiliation = af as UnionAffiliation;
                int memberId = unionAffiliation.MemberId;
                PayrollDatabase.RemoveUnionMember(memberId);
            }
        }
    }
}