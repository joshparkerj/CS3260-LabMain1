using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3260_LabMain1_JNP
{
    sealed class Contract : Employee
    {
        public decimal ContractWage;

        public Contract(int id, int etype, string first, string last, decimal wage) : base(id,etype,first,last)
        {
            ContractWage = wage;
        }
    }
}
