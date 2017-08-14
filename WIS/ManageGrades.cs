using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WIS.Classes;
using WIS.DataAccess;

namespace WIS
{
    public partial class ManageGrades : WIS.TemplateForm
    {
        Employee Lecturer;
        SqlDataAdapter da;
        DataSet ds;
        Dao dao;
        public ManageGrades(Employee lec)
        {
            InitializeComponent();
            dao = new Dao();
            Lecturer = lec;
            ds = new DataSet();
            da = new SqlDataAdapter("SELECT  Student.Student_id,Student.Student_name, Course.Course_id, Course.Couse_name, Student_course.Marks_1, Student_course.Marks_2, Student_course.Marks_3, Student_course.Grade  FROM Course INNER JOIN Student_course ON Course.Course_id = Student_course.Course_id INNER JOIN Student ON Student_course.Student_id = Student.Student_id", dao.connection);
            da.Fill(ds, "Student_Course");
            dao.CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageGrades_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'allData.Course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.allData.Course);
            // TODO: This line of code loads data into the 'allData.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.allData.Student);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Student_Course";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Lecturer.Employee_function == 1 || Lecturer.Employee_function == 5)
            {
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[0];

                    string student = row.Cells["Student_id"].Value.ToString();
                    string course = row.Cells["Course_id"].Value.ToString();
                    int marks1 = Convert.ToInt16(row.Cells["Marks_1"].Value.ToString());
                    int marks2 = Convert.ToInt16(row.Cells["Marks_2"].Value.ToString());
                    int marks3 = Convert.ToInt16(row.Cells["Marks_3"].Value.ToString());
                    string grade = row.Cells["grade"].Value.ToString();
                    UpdateMarks update = new UpdateMarks(student, course, marks1, marks2, marks3, grade);
                    update.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
                    this.Hide();
                    update.Show();
                }
                else
                {
                    MessageBox.Show("Please Select entire Row to be Updated");
                }
            }
            else
            {
                MessageBox.Show("You dont have rights to update marks");
            }
        }

        void otherForm_FormClosed(object sender, FormClosedEventArgs e)

        {
            Dao dao = new Dao();
            ds = new DataSet();
            da = new SqlDataAdapter("SELECT  Student.Student_id,Student.Student_name, Course.Course_id, Course.Couse_name, Student_course.Marks_1, Student_course.Marks_2, Student_course.Marks_3, Student_course.Grade  FROM Course INNER JOIN Student_course ON Course.Course_id = Student_course.Course_id INNER JOIN Student ON Student_course.Student_id = Student.Student_id", dao.connection);
            da.Fill(ds, "Student_Course");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Student_Course";
            dao.CloseConnection();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Lecturer.Employee_function == 1 || Lecturer.Employee_function == 4)
            {
                Dao dao = new Dao();
                int student = Convert.ToInt16(comboBox1.SelectedValue.ToString());
                int course = Convert.ToInt16(comboBox2.SelectedValue.ToString());
                int marks1 = Convert.ToInt16(textBox1.Text.ToString());
                int marks2 = Convert.ToInt16(textBox2.Text.ToString());
                int marks3 = Convert.ToInt16(textBox3.Text.ToString());
                string grade = textBox4.Text.ToString();

                bool res = dao.AddGrade(student, course, marks1, marks2, marks3, grade);
                if (res == true)
                    MessageBox.Show("Marks Successfully added");
                else if (res == false)
                {
                    MessageBox.Show("Marks Already entered \n please modify already existing entry");
                }
                ds = new DataSet();
                da = new SqlDataAdapter("SELECT  Student.Student_id,Student.Student_name, Course.Course_id, Course.Couse_name, Student_course.Marks_1, Student_course.Marks_2, Student_course.Marks_3, Student_course.Grade  FROM Course INNER JOIN Student_course ON Course.Course_id = Student_course.Course_id INNER JOIN Student ON Student_course.Student_id = Student.Student_id", dao.connection);
                da.Fill(ds, "Student_Course");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Student_Course";
                dao.CloseConnection();

                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";


            }
            else
            {
                MessageBox.Show("You dont have rights to Add marks");
            }
        }
    }
}
