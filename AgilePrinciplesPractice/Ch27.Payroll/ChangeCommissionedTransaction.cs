using Payroll;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public class ChangeCommissionedTransaction : ChangeClassificationTransaction
    {
        private readonly double salary;

        private readonly double commissionRate;

        protected override PaymentClassification Classification
        {
            get
            {
                return new CommissionedClassification(this.salary, this.commissionRate);
            }
        }

        protected override PaymentSchedule Schedule
        {
            get
            {
                return new BiweeklySchedule();
            }
        }

        public ChangeCommissionedTransaction(int empId, double salary, double commissionRate) : base(empId)
        {
            this.salary = salary;
            this.commissionRate = commissionRate;
        }
    }
}