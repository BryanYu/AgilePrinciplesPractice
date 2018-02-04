using System.Collections;

namespace Payroll
{
    public class PayrollDatabase
    {
        private static Hashtable employees = new Hashtable();

        private static Hashtable members = new Hashtable();

        public static void AddEmployee(int id, Employee employee)
        {
            employees[id] = employee;
        }

        public static Employee GetEmployee(int empId)
        {
            return employees[empId] as Employee;
        }

        public static void DeleteEmployee(int empId)
        {
            employees.Remove(empId);
        }

        public static void AddUnionMember(int memberId, Employee employee)
        {
            members[memberId] = employee;
        }

        public static Employee GetUnionMember(int memberId)
        {
            return members[memberId] as Employee;
        }
    }
}