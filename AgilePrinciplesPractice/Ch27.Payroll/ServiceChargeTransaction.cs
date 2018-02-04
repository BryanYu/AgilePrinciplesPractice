using System;
using Payroll;

namespace AgilePrinciplesPractice.Ch27.Payroll
{
    public class ServiceChargeTransaction : Transaction
    {
        private readonly int _memberId;
        private readonly DateTime _dateTime;
        private readonly double _charge;

        public ServiceChargeTransaction(int memberId, DateTime dateTime, double charge)
        {
            _memberId = memberId;
            _dateTime = dateTime;
            _charge = charge;
        }

        public void Execute()
        {
            Employee e = PayrollDatabase.GetUnionMember(this._memberId);
            if (e != null)
            {
                UnionAffiliation ua = null;
                if (e.Affiliation is UnionAffiliation)
                {
                    ua = e.Affiliation as UnionAffiliation;
                }

                if (ua != null)
                {
                    ua.AddServiceCharge(new ServiceCharge(this._dateTime, this._charge));
                }
                else
                {
                    throw new InvalidOperationException(
                        "Tires to add service charge to union member without a union affiliation");
                }
            }
            else
            {
                throw new InvalidOperationException("no such union member");
            }
        }
    }
}