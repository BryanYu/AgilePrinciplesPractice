using Payroll;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public class HourlyClassification : PaymentClassification
    {
        public double Salary { get; set; }

        public HourlyClassification(double salary)
        {
            this.Salary = salary;
        }
    }
}