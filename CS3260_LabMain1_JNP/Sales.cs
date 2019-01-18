using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3260_LabMain1_JNP
{
    [Serializable]
    public sealed class Sales : Salary
    {
        public decimal Commission;
        public decimal GrossSales;

        public Sales(int id, int etype, string first, string last, decimal pay, decimal com, decimal gross) : base(id,etype,first,last,pay)
        {
            Commission = com;
            GrossSales = gross;
        }
    }
}
