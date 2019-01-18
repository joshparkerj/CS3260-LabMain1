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
    public partial class ViewDepartment : Form
    {
        private static ViewDepartment inst;
        public static ViewDepartment GetForm
        {
            get
            {
                if (inst == null || inst.IsDisposed)
                {
                    inst = new ViewDepartment();
                }
                return inst;
            }
        }

        public ViewDepartment()
        {
            InitializeComponent();
            inst = this;
        }

        private void homeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form1.GetForm.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addEmployeeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddEmployee.GetForm.Show();
            this.Hide();
        }

        private void addToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddEducationalBenefits.GetForm.Show();
            this.Hide();
        }

        private void addCourseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddCourse.GetForm.Show();
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

        private void viewEmployeeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ViewEmployee.GetForm.Show();
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
        }

        private void viewInstitutionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ViewInstitution.GetForm.Show();
            this.Hide();
        }
    }
}
