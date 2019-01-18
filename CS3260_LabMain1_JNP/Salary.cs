using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3260_LabMain1_JNP
{
    [Serializable]
    public class Salary : Employee
    {
        public decimal MonthlySalary;
        public Salary(int id, int etype, string first, string last, decimal pay) : base(id,etype,first,last)
        {
            MonthlySalary = pay;
        }
    }
}
