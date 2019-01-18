using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3260_LabMain1_JNP
{
    public enum EType {SALARY, SALES, HOURLY, CONTRACT};
    ///<summary>
    /// This class models an employee. It contains key information
    /// about employees. It is inherited by the other employee types./// </summary>
    [Serializable]
    public abstract class Employee
    {
        public int EmpID;
        public int EmpType;
        public string FirstName;
        public string LastName;

        public Employee(int id, int etype, string first, string last)
        {
            EmpID = id;
            EmpType = etype;
            FirstName = first;
            LastName = last;
        }
    }
}
