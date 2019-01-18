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
        OpenFileDialog openfiledialog;
        SaveFileDialog savefiledialog;
        FileIO ifa;
        BusinessRules empBR;
        public static Form1 inst;
        public Form1()
        {
            InitializeComponent();
            inst = this;
        }
        public static Form1 GetForm
        {
            get
            {
                if (inst == null || inst.IsDisposed)
                {
                    inst = new Form1();
                }
                return inst;
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
        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEducationalBenefits.GetForm.Show();
            this.Hide();
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEmployee.GetForm.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddEmployee.GetForm.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ViewEmployee.GetForm.Show();
            this.Hide();
        }

        private void viewEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewEmployee.GetForm.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AddEducationalBenefits.GetForm.Show();
            this.Hide();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            ViewCourse.GetForm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddCourse.GetForm.Show();
            this.Hide();
        }


        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCourse.GetForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewInstitution.GetForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewDepartment.GetForm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ViewEducationalBenefits.GetForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddInstitution.GetForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddDepartment.GetForm.Show();
            this.Hide();
        }

        private void addDepartmentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddDepartment.GetForm.Show();
            this.Hide();
        }

        private void addInstitutionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddInstitution.GetForm.Show();
            this.Hide();
        }

        private void viewEducationalBenefitsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ViewEducationalBenefits.GetForm.Show();
            this.Hide();
        }

        private void viewCourseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ViewCourse.GetForm.Show();
            this.Hide();
        }

        private void viewDepartmentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ViewDepartment.GetForm.Show();
            this.Hide();
        }

        private void viewInstitutionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ViewInstitution.GetForm.Show();
            this.Hide();
        }
    }
}
