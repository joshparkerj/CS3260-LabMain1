using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CS3260_LabMain1_JNP
{
    public class FileIO : object, IFileAccess
    {
        private Stream file;
        public string filename;
        public SortedDictionary<uint, Employee> EmployeeDB { get; set; }

        //member data as required
        public void WriteFileDB()
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, EmployeeDB);

        }
        public void OpenFileDB()
        {
            file = File.Open(filename, FileMode.OpenOrCreate);
        }

        public void ReadFileDB()
        {
            BinaryFormatter bf = new BinaryFormatter();
            EmployeeDB = (SortedDictionary<uint,Employee>)bf.Deserialize(file);
        }

        public void CloseFileDB()
        {
            file.Close();
        }

        void setfilename(string fn)
        {
            filename = fn;
        }
        //member properties & indexers as required

        //member methods as required

    }//end class FileIO
}
