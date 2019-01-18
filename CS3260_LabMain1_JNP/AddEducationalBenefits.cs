using System.Windows.Forms;

namespace CS3260_LabMain1_JNP
{
    public partial class AddEducationalBenefits : Form
    {
        private static AddEducationalBenefits inst;
        public static AddEducationalBenefits GetForm
        {
            get
            {
                if (inst == null || inst.IsDisposed)
                {
                    inst = new AddEducationalBenefits();
                }
                return inst;
            }
        }
        public AddEducationalBenefits()
        {
            InitializeComponent();
            inst = this;
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void homeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Form1.GetForm.Show();
            this.Hide();
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            AddEmployee.GetForm.Show();
            this.Hide();
        }

        private void viewEmployeeToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ViewEmployee.GetForm.Show();
            this.Hide();
        }

        private void addCourseToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            AddCourse.GetForm.Show();
            this.Hide();
        }

        private void addToolStripMenuItem_Click(object sender, System.EventArgs e)
        {

        }

        private void addDepartmentToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            AddDepartment.GetForm.Show();
            this.Hide();
        }

        private void addInstitutionToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            AddInstitution.GetForm.Show();
            this.Hide();
        }

        private void viewEducationalBenefitsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ViewEducationalBenefits.GetForm.Show();
            this.Hide();
        }

        private void viewCourseToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ViewCourse.GetForm.Show();
            this.Hide();
        }

        private void viewDepartmentToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ViewDepartment.GetForm.Show();
            this.Hide();
        }

        private void viewInstitutionToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ViewInstitution.GetForm.Show();
            this.Hide();
        }
    }
}
