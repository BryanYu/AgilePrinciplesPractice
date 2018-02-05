using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using AgilePrinciplesPractice;
using AgilePrinciplesPractice.Ch27.Payroll;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Payroll;

namespace AgilePrinciplesPracticeTests.Ch27.Payroll
{
    [TestFixture]
    public class PayrollTest
    {
        [Test]
        public void TestAddSalariedEmployee()
        {
            int empId = 1;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bob", "Home", 1000.00);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual("Bob", e.Name);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is SalariedClassification);
            SalariedClassification sc = pc as SalariedClassification;
            Assert.AreEqual(1000.00, sc.Salary, .001);
            PaymentSchedule ps = e.Schedule;

            Assert.IsTrue(ps is MonthlySchedule);

            PaymentMethod pm = e.Method;
            Assert.IsTrue(pm is HoldMethod);
        }

        [Test]
        public void TestAddHourlyEmployee()
        {
            int empId = 2;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bob2", "Home", 100);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual(e.Name, "Bob2");

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is HourlyClassification);

            HourlyClassification hc = pc as HourlyClassification;
            Assert.AreEqual(100, hc.HourlyRate);

            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is WeeklySchedule);
        }

        [Test]
        public void TestAddCommissionedEmployee()
        {
            int empId = 3;
            AddCommissionEmployee t = new AddCommissionEmployee(empId, "Bob3", "Home", 100, 0.5);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.AreEqual(e.Name, "Bob3");

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is CommissionedClassification);

            CommissionedClassification hc = pc as CommissionedClassification;
            Assert.AreEqual(50, hc.Salary);

            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is BiweeklySchedule);
        }

        [Test]
        public void TestDeleteEmployee()
        {
            int empId = 4;
            AddCommissionEmployee t = new AddCommissionEmployee(empId, "Bill", "Home", 2500, 3.2);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);

            Assert.IsNotNull(e);

            DeleteEmployeeTransaction dt = new DeleteEmployeeTransaction(empId);
            dt.Execute();

            e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNull(e);
        }

        [Test]
        public void TestTimeCardTransaction()
        {
            int empId = 5;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();

            TimeCardTransaction tct = new TimeCardTransaction(new DateTime(2005, 7, 31), 8.0, empId);
            tct.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is HourlyClassification);

            HourlyClassification hc = pc as HourlyClassification;

            TimeCard tc = hc.GetTimeCard(new DateTime(2005, 7, 31));
            Assert.IsNotNull(tc);
            Assert.AreEqual(8.0, tc.Hours);
        }

        [Test]
        public void TestSalesReceiptTransaction()
        {
            int empId = 6;

            AddCommissionEmployee t = new AddCommissionEmployee(6, "Bryan", "Home", 100, 1.5);
            t.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.NotNull(e);

            SalesReceiptTransaction st = new SalesReceiptTransaction(new DateTime(2005, 7, 31), 100, empId);
            st.Execute();

            CommissionedClassification cc = e.Classification as CommissionedClassification;
            Assert.IsNotNull(e.Classification is CommissionedClassification);

            SalesReceipt receipt = cc.GetSalesReceipt(new DateTime(2005, 7, 31));
            Assert.AreEqual(receipt.Amount, 100);
        }

        [Test]
        public void TestAddServiceCharge()
        {
            int empId = 2;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);

            UnionAffiliation af = new UnionAffiliation();
            e.Affiliation = af;
            int memberId = 86;
            PayrollDatabase.AddUnionMember(memberId, e);
            ServiceChargeTransaction sct = new ServiceChargeTransaction(memberId, new DateTime(2005, 8, 8), 12.95);
            sct.Execute();

            ServiceCharge sc = af.GetServiceCharge(new DateTime(2005, 8, 8));
            Assert.IsNotNull(sc);
            Assert.AreEqual(12.95, sc.Amount, .001);
        }

        [Test]
        public void TestChangeNameTransaction()
        {
            int empId = 2;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 15.25);
            t.Execute();
            ChangeNameTransaction cnt = new ChangeNameTransaction(empId, "Bob");
            cnt.Execute();
            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            Assert.AreEqual("Bob", e.Name);
        }

        [Test]
        public void TestChangeAddressTransaction()
        {
            int empId = 3;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 12.25);
            t.Execute();

            ChangeAddressTransaction cat = new ChangeAddressTransaction(empId, "Company");
            cat.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);
            Assert.AreEqual(e.Address, "Company");
        }

        [Test]
        public void TestChangeHourlyTransaction()
        {
            int empId = 3;
            AddCommissionEmployee t = new AddCommissionEmployee(empId, "Lance", "Home", 2500, 3.2);
            t.Execute();
            ChangeHourlyTransaction cht = new ChangeHourlyTransaction(empId, 27.52);
            cht.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);

            PaymentClassification pc = e.Classification;
            Assert.IsNotNull(pc);

            Assert.IsTrue(pc is HourlyClassification);

            HourlyClassification hc = pc as HourlyClassification;
            Assert.AreEqual(27.52, hc.HourlyRate, .001);

            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is WeeklySchedule);
        }

        [Test]
        public void TestChangeSalariedTransaction()
        {
            int empId = 4;
            AddCommissionEmployee t = new AddCommissionEmployee(empId, "Bryan", "Home", 100, 1.5);
            t.Execute();

            ChangeSalariedTransaction cst = new ChangeSalariedTransaction(empId, 5000);
            cst.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.IsNotNull(e);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is SalariedClassification);

            SalariedClassification sc = pc as SalariedClassification;
            Assert.AreEqual(5000, sc.Salary);

            PaymentSchedule ps = e.Schedule;
            Assert.IsTrue(ps is MonthlySchedule);
        }

        [Test]
        public void TestChangeCommissionedTransaction()
        {
            int empId = 5;
            AddHourlyEmployee t = new AddHourlyEmployee(empId, "Bill", "Home", 500);
            t.Execute();

            ChangeCommissionedTransaction cct = new ChangeCommissionedTransaction(empId, 100, 1.5);
            cct.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);
            Assert.NotNull(e);

            PaymentClassification pc = e.Classification;
            Assert.IsTrue(pc is CommissionedClassification);

            CommissionedClassification cc = pc as CommissionedClassification;

            Assert.AreEqual(cc.Salary, 150);

            PaymentSchedule bs = e.Schedule;
            Assert.IsTrue(bs is BiweeklySchedule);
        }

        [Test]
        public void TestChangeDirectTranasction()
        {
            int empId = 3;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bryan", "Home", 5000);
            t.Execute();

            ChangeDirectTransaction cdt = new ChangeDirectTransaction(empId);
            cdt.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);

            Assert.NotNull(e);
            Assert.IsTrue(e.Method is DirectMethod);
        }

        [Test]
        public void TestChangeMailTransaction()
        {
            int empId = 3;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bryan", "Home", 5000);
            t.Execute();

            ChangeMailTransaction cmt = new ChangeMailTransaction(empId);
            cmt.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);

            Assert.NotNull(e);
            Assert.IsTrue(e.Method is MailMethod);
        }

        [Test]
        public void TestChangeHoldTransaction()
        {
            int empId = 3;
            AddSalariedEmployee t = new AddSalariedEmployee(empId, "Bryan", "Home", 5000);
            t.Execute();

            ChangeHoldTransaction cht = new ChangeHoldTransaction(empId);
            cht.Execute();

            Employee e = PayrollDatabase.GetEmployee(empId);

            Assert.NotNull(e);
            Assert.IsTrue(e.Method is HoldMethod);
        }
    }
}