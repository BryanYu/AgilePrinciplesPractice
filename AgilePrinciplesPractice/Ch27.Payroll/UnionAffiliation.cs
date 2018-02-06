using System;
using System.Collections;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public class UnionAffiliation : Affiliation
    {
        private Hashtable serviceCharges = new Hashtable();
        private int memberId;
        private double dues;

        public int MemberId
        {
            get
            {
                return this.memberId;
            }
        }

        public UnionAffiliation(int memberId, double dues)
        {
            this.memberId = memberId;
            this.dues = dues;
        }

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