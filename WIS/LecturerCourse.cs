using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WIS.Classes;
using WIS.DataAccess;

namespace WIS
{
    public partial class LecturerCourse : WIS.TemplateForm
    {
        SqlDataAdapter da;
        DataSet ds;
        Dao dao;
        public LecturerCourse(Employee emp)
        {
            InitializeComponent();
            label1.Text = "Welcome" + emp.Employee_name;
            dao = new Dao();
            ds = new DataSet();
            da = new SqlDataAdapter("SELECT Course.Course_id, Course.Couse_name, Course.Credits, Course.Fee, Course.Prerequsite, Program.Program_name, Program.Program_length FROM Course INNER JOIN Program ON Course.Program_id = Program.Program_id", dao.connection);
            da.Fill(ds, "Course");
            comboBox2.SelectedIndex = 0;
            label10.Text = "Course Id";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LecturerCourse_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'report.Course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.report.Course);
            // TODO: This line of code loads data into the 'report.Course1' table. You can move, or remove it, as needed.
            this.course1TableAdapter.Fill(this.report.Course1);
            // TODO: This line of code loads data into the 'allData.Program' table. You can move, or remove it, as needed.
            this.programTableAdapter.Fill(this.allData.Program);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Course";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                label9.Visible = true;
            }
            else
            {
                label9.Visible = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
            {
                label7.Visible = true;
            }
            else
            {
                label7.Visible = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 0)
            {
                label8.Visible = true;
            }
            else
            {
                label8.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int tmp = 99;
            string course_name = textBox1.Text.ToString();
            int credits = Convert.ToUInt16(textBox2.Text.ToString());
            int fee = Convert.ToUInt16(textBox3.Text.ToString());
            string pre = textBox4.Text.ToString();
            int prog = Convert.ToUInt16(comboBox1.SelectedValue.ToString());
            Course course1 = new Course(tmp, textBox1.Text.ToString(), Convert.ToUInt16(textBox2.Text.ToString()), Convert.ToUInt16(textBox3.Text.ToString()), textBox4.Text.ToString(), Convert.ToUInt16(comboBox1.SelectedValue.ToString()));
            //MessageBox.Show(course.Couse_name + course.Credits + course.Fee + course.Program_id);

            Dao dao = new Dao();
            bool ret = dao.AddCourse(course1);
            if (ret.Equals(true))
            {
                MessageBox.Show("Course added Succesfully..");
            }
            else
            {
                MessageBox.Show("Something went wrong try again later");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                label10.Text = "Course Id";
                comboBox4.Visible = false;
                comboBox3.Visible = true;
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                label10.Text = "Credits";
                comboBox3.Visible = false;
                comboBox4.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {

                ds = new DataSet();
                da = new SqlDataAdapter("SELECT Course.Course_id, Course.Couse_name, Course.Credits, Course.Fee, Course.Prerequsite, Program.Program_name, Program.Program_length FROM Course INNER JOIN Program ON Course.Program_id = Program.Program_id WHERE (Course.Course_id =" + comboBox3.SelectedValue.ToString() + ")", dao.connection);
                da.Fill(ds, "Course");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Course";
            }
            if (comboBox2.SelectedIndex == 1)
            {

                ds = new DataSet();
                da = new SqlDataAdapter("SELECT Course.Course_id, Course.Couse_name, Course.Credits, Course.Fee, Course.Prerequsite, Program.Program_name, Program.Program_length FROM Course INNER JOIN Program ON Course.Program_id = Program.Program_id WHERE (Course.Credits =" + comboBox4.SelectedValue.ToString() + ")", dao.connection);
                da.Fill(ds, "Course");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Course";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                dao = new Dao();
                //MessageBox.Show(row.Cells["Course_id"].Value.ToString());
                Course tmp = dao.FetchCourse(Convert.ToInt16(row.Cells["Course_id"].Value.ToString()));
                if (tmp.Equals(null))
                {
                    MessageBox.Show("Something Went Wrong");
                }
                else
                {
                    Course_info frm_course_info = new Course_info(tmp);
                    frm_course_info.FormClosed += new FormClosedEventHandler(otherForm_FormClose);
                    this.Hide();
                    frm_course_info.Show();

                }

            }
            else
            {
                MessageBox.Show("Please Select One Course only");
            }
        }

        void otherForm_FormClose(object sender, FormClosedEventArgs e)
        {
            dao = new Dao();
            ds = new DataSet();
            da = new SqlDataAdapter("select * from Student", dao.connection);
            da.Fill(ds, "Student");
            this.Show();
        }
    }
}
