using System.Windows.Forms;
using WIS.Classes;

namespace WIS
{

    public partial class StudentForm : WIS.TemplateForm
    {
        Student_program student;
        public StudentForm(Student_program stud)
        {
            InitializeComponent();
            student = stud;
            label1.Text = "Welcome " + student.Student_name.ToString();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            ProfileStudent otherform = new ProfileStudent(student);
            otherform.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
            this.Hide();
            otherform.Show();
        }

        void otherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            this.Close();
            //this.Hide();
            //LoginForm loginfrom = new LoginForm();
            //loginfrom.Closed += (s, args) => this.Close();
            //loginfrom.Show();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {

            ViewCourseStudent otherform = new ViewCourseStudent(student);
            this.Hide();
            otherform.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
            otherform.Show();
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            Viewgradestudent otherform = new Viewgradestudent(student);
            this.Hide();
            otherform.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
            otherform.Show();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            //manage favourite
            Managefavourite otherform = new Managefavourite(student);
            this.Hide();
            otherform.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
            otherform.Show();
        }
    }
}
