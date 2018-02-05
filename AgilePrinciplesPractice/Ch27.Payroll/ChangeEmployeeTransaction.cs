using System;
using Payroll;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public abstract class ChangeEmployeeTransaction : Transaction
    {
        private readonly int empId;

        protected ChangeEmployeeTransaction(int empId)
        {
            this.empId = empId;
        }

        public void Execute()
        {
            Employee e = PayrollDatabase.GetEmployee(this.empId);
            if (e != null)
            {
                this.Change(e);
            }
            else
            {
                throw new InvalidOperationException("No Such Employee");
            }
        }

        protected abstract void Change(Employee e);
    }
}