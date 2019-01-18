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
    public partial class AddEmployee : Form
    {

        private static AddEmployee inst;
        public static AddEmployee GetForm
        {
            get
            {
                if (inst == null || inst.IsDisposed)
                {
                    inst = new AddEmployee();
                }
                return inst;
            }
        }
        private void AddEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
            BusinessRules empBR;
            int EmpType;
            string first;
            string last;
            decimal EmpValue2;
            decimal EmpValue3;
            decimal EmpValue4;
            int EmployeeID;
            OpenFileDialog openfiledialog;
            SaveFileDialog savefiledialog;
            FileIO ifa;

            public AddEmployee()
            {
                InitializeComponent();
                inst = this;
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
            }


            private void openToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (openfiledialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ifa.filename = openfiledialog.FileName;
                    ifa.OpenFileDB();
                    ifa.ReadFileDB();
                    ifa.CloseFileDB();
                    empBR.takeDictionary(ifa.EmployeeDB);
                }
            }

            private void saveToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (savefiledialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ifa.filename = savefiledialog.FileName;
                    ifa.EmployeeDB = empBR.getDictionary();
                    ifa.OpenFileDB();
                    ifa.WriteFileDB();
                    ifa.CloseFileDB();
                }
            }

        private void AddEmployee_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.GetForm.Show();
            this.Hide();
        }

        private void viewEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewEmployee.GetForm.Show();
            this.Hide();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEducationalBenefits.GetForm.Show();
            this.Hide();
        }

        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCourse.GetForm.Show();
            this.Hide();
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void addDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDepartment.GetForm.Show();
            this.Hide();
        }

        private void addInstitutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddInstitution.GetForm.Show();
            this.Hide();
        }

        private void viewEducationalBenefitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewEducationalBenefits.GetForm.Show();
            this.Hide();
        }

        private void viewCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewCourse.GetForm.Show();
            this.Hide();
        }

        private void viewDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewDepartment.GetForm.Show();
            this.Hide();
        }

        private void viewInstitutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewInstitution.GetForm.Show();
            this.Hide();
        }
    }
    }
