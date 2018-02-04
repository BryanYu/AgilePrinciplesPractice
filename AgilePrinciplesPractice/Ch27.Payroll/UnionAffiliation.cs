using System;
using System.Collections;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public class UnionAffiliation
    {
        private Hashtable serviceCharges = new Hashtable();

        public ServiceCharge GetServiceCharge(DateTime dateTime)
        {
            return this.serviceCharges[dateTime] as ServiceCharge;
        }

        public void AddServiceCharge(ServiceCharge serviceCharge)
        {
            this.serviceCharges[serviceCharge.DateTime] = serviceCharge;
        }
    }
}