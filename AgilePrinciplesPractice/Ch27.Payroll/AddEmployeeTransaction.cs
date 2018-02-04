using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgilePrinciplesPractice;

namespace Payroll
{
    public abstract class AddEmployeeTransaction : Transaction
    {
        private readonly int empId;
        private readonly string name;
        private readonly string address;

        public AddEmployeeTransaction(int empid, string name, string address)
        {
            this.empId = empid;
            this.name = name;
            this.address = address;
        }

        public void Execute()
        {
            PaymentClassification pc = MakeClassification();
            PaymentSchedule ps = MakeSchedule();
            PaymentMethod pm = new HoldMethod();
            Employee e = new Employee(empId, name, address);
            e.Classification = pc;
            e.Schedule = ps;
            e.Method = pm;
            PayrollDatabase.AddEmployee(empId, e);
        }

        protected abstract PaymentClassification MakeClassification();

        protected abstract PaymentSchedule MakeSchedule();
    }
}