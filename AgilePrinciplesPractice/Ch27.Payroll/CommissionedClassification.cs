using System;
using System.Collections;
using Payroll;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public class CommissionedClassification
        : PaymentClassification
    {
        private readonly double _salary;
        private readonly double _commissionRate;

        private readonly Hashtable _salesRecipet = new Hashtable();

        public double Salary
        {
            get { return this._salary * this._commissionRate; }
        }

        public CommissionedClassification(double salary, double commissionRate)
        {
            _salary = salary;
            _commissionRate = commissionRate;
        }

        public void AddSalesRecepit(SalesReceipt salesReceipt)
        {
            this._salesRecipet[salesReceipt.DateTime] = salesReceipt;
        }

        public SalesReceipt GetSalesReceipt(DateTime dateTime)
        {
            return this._salesRecipet[dateTime] as SalesReceipt;
        }
    }
}