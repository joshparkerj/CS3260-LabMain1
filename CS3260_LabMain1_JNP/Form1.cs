// Project Prolog
// Name: Josh Parker
// CS3260 Section 001
// Project: Lab_01
// Date: 10/19/2018 11:53:57 PM
// Purpose: This project provides a graphical form for inputting data about employees of a company.
//
// I declare that the following code was written by me or provided
// by the instructor for this project. I understand that copying source
// code from any other source constitutes plagiarism, and that I will receive
// a zero on this project if I am found in violation of this policy.
// ---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CS3260_LabMain1_JNP
{
    public partial class Form1 : Form
    {
        BusinessRules empBR;
        List<Employee> initialEmployees;
        int EmpType;
        string first;
        string last;
        Employee employeeToDisplay;
        decimal EmpValue2;
        decimal EmpValue3;
        decimal EmpValue4;
        int EmployeeID;

        public Form1()
        {
            InitializeComponent();
            textBox1.GotFocus += TBSelectAllOnFocus;
            textBox2.GotFocus += TBSelectAllOnFocus;
            numericUpDown1.GotFocus += NUDSelectAllOnFocus;
            numericUpDown2.GotFocus += NUDSelectAllOnFocus;
            numericUpDown3.GotFocus += NUDSelectAllOnFocus;
            numericUpDown4.GotFocus += NUDSelectAllOnFocus;

            initialEmployees = new List<Employee>();

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

            empBR = new BusinessRules(initialEmployees);
            empBR.addToListBox(listBox1);
        }

        private void TBSelectAllOnFocus(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void NUDSelectAllOnFocus(object sender, EventArgs e)
        {
            ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Text.Length);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            EmpType = (int)EType.CONTRACT;
            numericUpDown4.Visible = false;
            label9.Visible = false;
            numericUpDown3.Visible = false;
            label8.Visible = false;
            label7.Text = "Contract Wage";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            EmpType = (int)EType.SALARY;
            numericUpDown4.Visible = false;
            label9.Visible = false;
            numericUpDown3.Visible = false;
            label8.Visible = false;
            label7.Text = "Monthly Salary";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            EmpType = (int)EType.HOURLY;
            numericUpDown4.Visible = false;
            label9.Visible = false;
            numericUpDown3.Visible = true;
            label8.Visible = true;
            label8.Text = "Hours Worked";
            label7.Text = "Hourly Rate";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            EmpType = (int)EType.SALES;
            numericUpDown4.Visible = true;
            label9.Visible = true;
            numericUpDown3.Visible = true;
            label8.Visible = true;
            label8.Text = "Commission";
            label7.Text = "Monthly Salary";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            first = textBox2.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            last = textBox1.Text;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            EmployeeID = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            EmpValue2 = numericUpDown2.Value;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            EmpValue3 = numericUpDown3.Value;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            EmpValue4 = numericUpDown4.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (empBR.idExists(EmployeeID))
            {
                label24.Visible = true;
                return;
            }
            label24.Visible = false;
            if (EmpType == (int)EType.CONTRACT)
            {
                empBR.addEmployee(new Contract(EmployeeID, EmpType, first, last, EmpValue2));
            }
            else if (EmpType == (int)EType.HOURLY)
            {
                empBR.addEmployee(new Hourly(EmployeeID, EmpType, first, last, EmpValue2, (double)EmpValue3));
            }
            else if (EmpType == (int)EType.SALARY)
            {
                empBR.addEmployee(new Salary(EmployeeID, EmpType, first, last, EmpValue2));
            }
            else if (EmpType == (int)EType.SALES)
            {
                empBR.addEmployee(new Sales(EmployeeID, EmpType, first, last, EmpValue2, EmpValue3, EmpValue4));
            }
            listBox1.Items.Clear();
            empBR.addToListBox(listBox1);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            employeeToDisplay = empBR.getemployee((int)listBox1.SelectedItem);
            label23.Visible = true;
            label11.Visible = true;
            label11.Text = employeeToDisplay.FirstName;
            label13.Visible = true;
            label13.Text = employeeToDisplay.LastName;
            label15.Visible = true;
            label15.Text = employeeToDisplay.EmpID.ToString();
            label17.Visible = true;
            if (employeeToDisplay.EmpType == (int)EType.CONTRACT)
            {
                label23.Text = "Contract";
                label16.Text = "Contract Wage:";
                Contract contractEmployee = (Contract)employeeToDisplay;
                label17.Text = contractEmployee.ContractWage.ToString();
                label18.Visible = false;
                label19.Visible = false;
                label20.Visible = false;
                label21.Visible = false;
            }
            else if(employeeToDisplay.EmpType == (int)EType.HOURLY)
            {
                label23.Text = "Hourly";
                label16.Text = "Hourly Rate:";
                Hourly hourlyEmployee = (Hourly)employeeToDisplay;
                label17.Text = hourlyEmployee.HourlyRate.ToString();
                label18.Visible = true;
                label18.Text = "Hours Worked:";
                label19.Visible = true;
                label19.Text = hourlyEmployee.HoursWorked.ToString();
                label20.Visible = false;
                label21.Visible = false;
            }
            else if(employeeToDisplay.EmpType == (int)EType.SALARY)
            {
                label23.Text = "Salary";
                label16.Text = "Monthly Salary:";
                Salary salaryEmployee = (Salary)employeeToDisplay;
                label17.Text = salaryEmployee.MonthlySalary.ToString();
                label18.Visible = false;
                label19.Visible = false;
                label20.Visible = false;
                label21.Visible = false;
            }
            else if (employeeToDisplay.EmpType == (int)EType.SALES)
            {
                label23.Text = "Sales";
                label16.Text = "Monthly Salary:";
                Sales salesEmployee = (Sales)employeeToDisplay;
                label17.Text = salesEmployee.MonthlySalary.ToString();
                label18.Visible = true;
                label18.Text = "Commission:";
                label19.Visible = true;
                label19.Text = salesEmployee.Commission.ToString();
                label20.Visible = true;
                label21.Visible = true;
                label21.Text = salesEmployee.GrossSales.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            empBR.removeEmployee((int)listBox1.SelectedItem);
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label15.Visible = false;
            label13.Visible = false;
            label11.Visible = false;
            label23.Visible = false;
            label17.Visible = false;

            listBox1.Items.Clear();
            empBR.addToListBox(listBox1);
        }
    }
}
