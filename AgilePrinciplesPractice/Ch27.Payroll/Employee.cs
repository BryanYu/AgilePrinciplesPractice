namespace Payroll
{
    public class Employee
    {
        public PaymentClassification Classification { get; set; }
        public PaymentMethod Method { get; set; }
        public string Name { get; set; }
        public PaymentSchedule Schedule { get; set; }

        public Employee(int empId, string name, string address)
        {
            this.Name = name;
        }
    }
}