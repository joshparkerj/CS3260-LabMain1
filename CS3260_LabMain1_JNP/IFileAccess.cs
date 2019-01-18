using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3260_LabMain1_JNP
{
    interface IFileAccess

    {
        void WriteFileDB();

        void ReadFileDB();

        void OpenFileDB();

        void CloseFileDB();

        SortedDictionary<uint, Employee> EmployeeDB { get; set; }

    }//End interface IFileAccess
}
