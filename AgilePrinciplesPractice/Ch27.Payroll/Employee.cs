using AgilePrinciplesPractice.Ch27.Payroll;

namespace Payroll
{
    public class Employee
    {
        public PaymentClassification Classification { get; set; }
        public PaymentMethod Method { get; set; }
        public string Name { get; set; }
        public PaymentSchedule Schedule { get; set; }
        public Affiliation Affiliation { get; set; }

        public string Address { get; set; }

        public Employee(int empId, string name, string address)
        {
            this.Name = name;
            this.Address = address;
        }
    }
}