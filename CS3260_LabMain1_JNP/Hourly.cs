using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3260_LabMain1_JNP
{
    sealed class Hourly : Employee
    {
        public decimal HourlyRate;
        public double HoursWorked;

        public Hourly(int id, int etype, string first, string last, decimal rate, double time) : base(id, etype, first, last)
        {
            HourlyRate = rate;
            HoursWorked = time;
        }
    }
}
