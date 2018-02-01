namespace Payroll
{
    public class AddSalariedEmployee : AddEmployeeTransaction
    {
        private readonly double _salary;

        public AddSalariedEmployee(int empId, string name, string address, double salary) : base(empId, name, address)
        {
            _salary = salary;
        }

        protected override PaymentClassification MakeClassification()
        {
            return new SalariedClassification(_salary);
        }

        protected override PaymentSchedule MakeSchedule()
        {
            return new MonthlySchedule();
        }
    }
}