using Payroll;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public class AddCommissionEmployee : AddEmployeeTransaction
    {
        private readonly double _salary;
        private readonly double _commissionRate;

        public AddCommissionEmployee(int empId,
            string name,
            string address, double salary, double commissionRate) : base(empId, name, address)
        {
            _salary = salary;
            _commissionRate = commissionRate;
        }

        protected override PaymentClassification MakeClassification()
        {
            return new CommissionedClassification(_salary, _commissionRate);
        }

        protected override PaymentSchedule MakeSchedule()
        {
            return new BiweeklySchedule();
        }
    }
}