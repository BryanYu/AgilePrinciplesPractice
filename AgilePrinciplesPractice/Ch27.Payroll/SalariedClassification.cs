using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll
{
    public class SalariedClassification : PaymentClassification
    {
        public double Salary { get; set; }

        public SalariedClassification(double salary)
        {
            this.Salary = salary;
        }
    }
}