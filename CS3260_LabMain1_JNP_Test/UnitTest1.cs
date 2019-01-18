using System;
using System.Collections.Generic;
using CS3260_LabMain1_JNP;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CS3260_LabMain1_JNP_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            List<Employee> initialEmployees = new List<Employee>();

            initialEmployees.Add(new Contract(5322, (int)EType.CONTRACT, "Kendrick", "Lamar", (decimal)10.00));
            initialEmployees.Add(new Contract(7050, (int)EType.CONTRACT, "Selena", "Gomez", (decimal)14.14));
            initialEmployees.Add(new Contract(6847, (int)EType.CONTRACT, "Ira", "Gershwin", (decimal)20.00));
            initialEmployees.Add(new Contract(5164, (int)EType.CONTRACT, "Hedy", "Lamarr", (decimal)28.28));
            initialEmployees.Add(new Sales(4839, (int)EType.SALES, "Flying", "Lotus", (decimal)40000.00, (decimal)15000.00, (decimal)80000.00));
            initialEmployees.Add(new Sales(8661, (int)EType.SALES, "Jodie", "Foster", (decimal)50000.00, (decimal)45000.00, (decimal)100000.00));
            initialEmployees.Add(new Sales(7953, (int)EType.SALES, "Zebulon", "Pike", (decimal)60000.00, (decimal)135000.00, (decimal)120000.00));
            initialEmployees.Add(new Hourly(1882, (int)EType.HOURLY, "Veronica", "Lodge", (decimal)40.00, 40.00));
            initialEmployees.Add(new Hourly(6926, (int)EType.HOURLY, "Anthony", "Fantano", (decimal)56.57, 50.00));
            initialEmployees.Add(new Salary(9718, (int)EType.SALARY, "Dorothy", "Gale", (decimal)100000.00));

            BusinessRules businessrules = new BusinessRules(initialEmployees);

            //Act
            businessrules.addEmployee(new Salary(7472, (int)EType.SALARY, "Scooby", "Doo", (decimal)44000.00));

            //Assert
            Assert.IsTrue(businessrules.idExists(7472));
            Assert.IsFalse(businessrules.idExists(7473));
        }
    }
}
