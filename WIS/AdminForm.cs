using System;
using System.Windows.Forms;
using WIS.Classes;

namespace WIS
{
    public partial class AdminForm : WIS.TemplateForm
    {
        Employee admin;


        public AdminForm(Employee abc)
        {
            InitializeComponent();
            this.admin = abc;
            label1.Text = "Welcome " + admin.Employee_name;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManageStudentAdmin otherForm = new ManageStudentAdmin(admin);
            otherForm.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
            this.Hide();
            otherForm.Show();
        }

        void otherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManageEmployeeAdmin otherForm = new ManageEmployeeAdmin(admin);
            otherForm.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
            this.Hide();
            otherForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reports otherForm = new Reports(admin);
            otherForm.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
            this.Hide();
            otherForm.Show();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }


        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            //this.Hide();
            //LoginForm loginfrom = new LoginForm();
            //loginfrom.Closed += (s, args) => this.Close();
            //loginfrom.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //fee
            Fee otherForm = new Fee(admin);
            otherForm.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
            this.Hide();
            otherForm.Show();
        }
    }
}
