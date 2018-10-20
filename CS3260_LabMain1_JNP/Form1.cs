using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS3260_LabMain1_JNP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.GotFocus += TBSelectAllOnFocus;
            textBox2.GotFocus += TBSelectAllOnFocus;
            numericUpDown1.GotFocus += NUDSelectAllOnFocus;
            numericUpDown2.GotFocus += NUDSelectAllOnFocus;
            numericUpDown3.GotFocus += NUDSelectAllOnFocus;
            numericUpDown4.GotFocus += NUDSelectAllOnFocus;
        }

        private void TBSelectAllOnFocus(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void NUDSelectAllOnFocus(object sender, EventArgs e)
        {
            ((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Text.Length);
        }

        List<Employee> ListOfEmployees = new List<Employee>();

        int EmpType;

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

        string first;
        string last;

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            first = textBox2.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            last = textBox1.Text;
        }

        int EmployeeID;

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            EmployeeID = (int)numericUpDown1.Value;
        }

        Employee employeeToDisplay;

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            employeeToDisplay = ListOfEmployees.Find(employee => employee.EmpID == (int)listBox1.SelectedItem);
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

        decimal EmpValue2;
        decimal EmpValue3;
        decimal EmpValue4;

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
            if (ListOfEmployees.Exists(employee => employee.EmpID == EmployeeID))
            {
                label24.Visible = true;
                return;
            }
            label24.Visible = false;
            if(EmpType == (int)EType.CONTRACT)
            {
                ListOfEmployees.Add(new Contract(EmployeeID, EmpType, first, last, EmpValue2));
            }
            else if(EmpType == (int)EType.HOURLY)
            {
                ListOfEmployees.Add(new Hourly(EmployeeID, EmpType, first, last, EmpValue2, (double)EmpValue3));
            }
            else if(EmpType == (int)EType.SALARY)
            {
                ListOfEmployees.Add(new Salary(EmployeeID, EmpType, first, last, EmpValue2));
            }
            else if(EmpType == (int)EType.SALES)
            {
                ListOfEmployees.Add(new Sales(EmployeeID, EmpType, first, last, EmpValue2, EmpValue3, EmpValue4));
            }
            listBox1.Items.Clear();
            ListOfEmployees.ForEach(employee => listBox1.Items.Add(employee.EmpID));
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
