using Payroll;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public class CommissionedClassification
        : PaymentClassification
    {
        private readonly double _salary;
        private readonly double _commissionRate;

        public double Salary
        {
            get { return this._salary * this._commissionRate; }
        }

        public CommissionedClassification(double salary,
            double commissionRate)
        {
            _salary = salary;
            _commissionRate = commissionRate;
        }
    }
}