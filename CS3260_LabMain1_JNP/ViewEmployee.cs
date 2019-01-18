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
    public partial class ViewEmployee : Form
    {
        private static ViewEmployee inst;
        public static ViewEmployee GetForm
        {
            get
            {
                if (inst == null || inst.IsDisposed)
                {
                    inst = new ViewEmployee();
                }
                return inst;
            }
        }
        List<Employee> initialEmployees;
        BusinessRules empBR;
        OpenFileDialog openfiledialog;
        SaveFileDialog savefiledialog;
        FileIO ifa;
        Employee employeeToDisplay;

        public ViewEmployee()
        {
            InitializeComponent();
            inst = this;
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
            openfiledialog = new OpenFileDialog();
            savefiledialog = new SaveFileDialog();
            ifa = new FileIO();

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
            else if (employeeToDisplay.EmpType == (int)EType.HOURLY)
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
            else if (employeeToDisplay.EmpType == (int)EType.SALARY)
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
            if (employeeToDisplay == null)
                return;
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
            employeeToDisplay = null;
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.GetForm.Show();
            this.Hide();
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
