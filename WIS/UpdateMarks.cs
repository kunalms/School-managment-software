using System;
using System.Windows.Forms;
using WIS.DataAccess;

namespace WIS
{
    public partial class UpdateMarks : WIS.TemplateForm
    {
        public UpdateMarks(string student, string course, int marks1, int marks2, int marks3, string grade)
        {
            InitializeComponent();
            this.courseTableAdapter.Fill(this.allData.Course);
            // TODO: This line of code loads data into the 'allData.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.allData.Student);
            comboBox1.SelectedValue = student;
            comboBox2.SelectedValue = course;
            textBox1.Text = marks1.ToString();
            textBox2.Text = marks2.ToString();
            textBox3.Text = marks3.ToString();
            textBox4.Text = grade.ToString();
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            Dao dao = new Dao();
            string student = comboBox1.SelectedValue.ToString();
            string course = comboBox2.SelectedValue.ToString();
            int marks1 = Convert.ToInt16(textBox1.Text.ToString());
            int marks2 = Convert.ToInt16(textBox2.Text.ToString());
            int marks3 = Convert.ToInt16(textBox3.Text.ToString());
            string grade = textBox4.Text.ToString();
            dao.UpdateMarks(student, course, marks1, marks2, marks3, grade);
            MessageBox.Show("Data Updated Succesfully");
            this.Close();
        }

        private void UpdateMarks_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'allData.Course' table. You can move, or remove it, as needed.



        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
