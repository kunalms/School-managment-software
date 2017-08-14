using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WIS.Classes;
using WIS.DataAccess;

namespace WIS
{
    public partial class LecturerForm : WIS.TemplateForm
    {
        Employee Lecturer;
        SqlDataAdapter da;
        DataSet ds;
        Dao dao;
        public LecturerForm()
        {
            InitializeComponent();
            dao = new Dao();
            ds = new DataSet();
            da = new SqlDataAdapter("select * from Student", dao.connection);
            da.Fill(ds, "Student");
            comboBox1.SelectedIndex = 0;
            textBox1.Visible = true;
            label2.Visible = true;
            label2.Text = "Course name";
            dao.CloseConnection();
        }
        public LecturerForm(Employee lecturer)
        {
            InitializeComponent();
            dao = new Dao();
            ds = new DataSet();
            da = new SqlDataAdapter("select * from Student", dao.connection);
            da.Fill(ds, "Student");
            this.Lecturer = lecturer;
            label1.Text = "Welcome " + lecturer.Employee_name;
            comboBox1.SelectedIndex = 0;
            textBox1.Visible = true;
            label2.Visible = true;
            label2.Text = "Course name";
            dao.CloseConnection();

        }

        private void LecturerForm_Load(object sender, System.EventArgs e)
        {
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Student";
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            int searchBy = this.comboBox1.SelectedIndex;

            if (searchBy == 0)
            {
                if (textBox1.Text.Length == 0)
                {
                    MessageBox.Show("enter valid inputs");
                }
                else
                {
                    dao = new Dao();
                    string query = "SELECT Course.Couse_name, Course.Course_id, Student.Student_name, Student.Student_father, Student.Student_mother, Student.Student_username, Student.Student_contact, Student.Student_email FROM  Course INNER JOIN Student_course ON Course.Course_id = Student_course.Course_id INNER JOIN Student ON Student_course.Student_id = Student.Student_id WHERE (Course.Couse_name LIKE '%" + textBox1.Text.ToString() + "%')";
                    SqlCommand cmd = new SqlCommand(query, dao.connection);


                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable("Users");
                    dt.Load(dr);
                    dao.CloseConnection();
                    dataGridView1.DataSource = dt;
                }
            }
            if (searchBy == 1)
            {
                if (textBox1.Text.Length == 0)
                {
                    MessageBox.Show("enter valid inputs");
                }
                else
                {
                    dao = new Dao();
                    string query = "SELECT Program.Program_name, Student.Student_name, Student.Student_father, Student.Student_mother, Student.Student_contact, Student.Student_email FROM  Program INNER JOIN Student ON Program.Program_id = Student.Student_program WHERE (Program.Program_name LIKE '%" + textBox1.Text.ToString() + "%')";
                    SqlCommand cmd = new SqlCommand(query, dao.connection);


                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable("Users");
                    dt.Load(dr);
                    dao.CloseConnection();
                    dataGridView1.DataSource = dt;
                }
            }

            if (searchBy == 2)
            {
                if (textBox1.Text.Length == 0)
                {
                    MessageBox.Show("enter valid inputs");
                }
                else
                {
                    dao = new Dao();
                    string query = "SELECT Student_id, Student_name, Student_father, Student_mother, Student_username, Student_contact, Student_email FROM Student WHERE (Student_id LIKE'%" + textBox1.Text.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query, dao.connection);


                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable("Users");
                    dt.Load(dr);
                    dao.CloseConnection();
                    dataGridView1.DataSource = dt;
                }
            }


            if (searchBy == 3)
            {
                string query = "SELECT Student.Student_name, Student.Student_father, Student.Student_mother, Student.Student_username, Student.Student_contact, Student.Student_email, Course.Couse_name FROM  Course INNER JOIN Student_course ON Course.Course_id = Student_course.Course_id INNER JOIN Student ON Student_course.Student_id = Student.Student_id WHERE (Student.Student_name LIKE '%" + textBox1.Text.ToString() + "%')";
                dao = new Dao();

                SqlCommand cmd = new SqlCommand(query, dao.connection);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable("Users");
                dt.Load(dr);
                dao.CloseConnection();
                dataGridView1.DataSource = dt;
            }

            if (searchBy == 4)
            {
                if (textBox1.Text.Length == 0)
                {
                    MessageBox.Show("enter valid inputs");
                }
                else
                {
                    dao = new Dao();
                    string query = "SELECT Course.Couse_name, Course.Course_id, Student.Student_name, Student.Student_father, Student.Student_mother, Student.Student_username, Student.Student_contact, Student.Student_email FROM  Course INNER JOIN Student_course ON Course.Course_id = Student_course.Course_id INNER JOIN Student ON Student_course.Student_id = Student.Student_id WHERE (Course.Course_id = '" + textBox1.Text.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query, dao.connection);


                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable("Users");
                    dt.Load(dr);
                    dao.CloseConnection();
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            this.Close();
            //this.Hide();
            //LoginForm loginfrom = new LoginForm();
            //loginfrom.Closed += (s, args) => this.Close();
            //loginfrom.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label2.Visible = true;
                label2.Text = "Course_name";
                textBox1.Visible = true;
            }

            if (comboBox1.SelectedIndex == 1)
            {
                label2.Visible = true;
                label2.Text = "Program_name";
                textBox1.Visible = true;
            }

            if (comboBox1.SelectedIndex == 2)
            {
                label2.Visible = true;
                label2.Text = "Student_id";
                textBox1.Visible = true;
            }

            if (comboBox1.SelectedIndex == 3)
            {
                label2.Visible = true;
                label2.Text = "First name or Last name";
                textBox1.Visible = true;
            }
            if (comboBox1.SelectedIndex == 4)
            {
                label2.Visible = true;
                label2.Text = "Course id";
                textBox1.Visible = true;

            }


        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            LecturerCourse otherForm = new LecturerCourse(Lecturer);
            otherForm.FormClosed += new FormClosedEventHandler(otherForm_FormCl);
            this.Hide();
            otherForm.Show();
        }


        void otherForm_FormCl(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            if (Lecturer.Employee_function != 3)
            {
                ManageGrades managegrades = new ManageGrades(Lecturer);
                managegrades.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
                this.Hide();
                managegrades.Show();
            }
            else
            {
                MessageBox.Show(" Access Denied ! Please Contact Admin.");
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            ProfileLecturer form = new ProfileLecturer(Lecturer);
            form.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
            this.Hide();
            form.Show();
        }

        void otherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
