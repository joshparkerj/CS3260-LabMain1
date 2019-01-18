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
    public partial class AddCourse : Form
    {
        private static AddCourse inst;
        public static AddCourse GetForm
        {
            get
            {
                if (inst == null || inst.IsDisposed)
                {
                    inst = new AddCourse();
                }
                return inst;
            }
        }
        public AddCourse()
        {
            InitializeComponent();
            inst = this;
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.GetForm.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEmployee.GetForm.Show();
            this.Hide();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEducationalBenefits.GetForm.Show();
            this.Hide();
        }

        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewEmployee.GetForm.Show();
            this.Hide();
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
