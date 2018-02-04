using System;
using Payroll;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public class SalesReceiptTransaction : Transaction
    {
        private readonly DateTime _dateTime;
        private readonly int _amount;
        private readonly int _empId;

        public SalesReceiptTransaction(DateTime dateTime, int amount, int empId)
        {
            _dateTime = dateTime;
            _amount = amount;
            _empId = empId;
        }

        public void Execute()
        {
            Employee e = PayrollDatabase.GetEmployee(this._empId);
            if (e != null)
            {
                if (e.Classification is CommissionedClassification hc)
                {
                    hc.AddSalesRecepit(new SalesReceipt(this._dateTime, this._amount));
                }
                else
                {
                    throw new InvalidOperationException("no commission employee");
                }
            }
            else
            {
                throw new InvalidOperationException("no such employee");
            }
        }
    }
}