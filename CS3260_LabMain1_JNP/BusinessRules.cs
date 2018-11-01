using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3260_LabMain1_JNP
{
    sealed class BusinessRules
    {
        List<Employee> employee = new List<Employee>();

        public BusinessRules(List<Employee>constructorEmployees)
        {
            constructorEmployees.ForEach(item => employee.Add(item));
            
        }

        public void addEmployee(Employee hiree)
        {
            employee.Add(hiree);
        }

        public void removeEmployee(int GonerID)
        {
            employee.RemoveAll(emp => emp.EmpID == GonerID);
        }

        public Employee getemployee(int id)
        {
            return employee.Find(emp => emp.EmpID == id);
        }

        public bool idExists(int id)
        {
            return employee.Exists(emp => emp.EmpID == id);
        }

        public void addToListBox(System.Windows.Forms.ListBox lb)
        {
            employee.ForEach(emp => lb.Items.Add(emp.EmpID));
        }

    }
}
