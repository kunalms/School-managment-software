using System;
using System.Windows.Forms;
using WIS.Classes;
using WIS.DataAccess;

namespace WIS
{
    public partial class Course_info : WIS.TemplateForm
    {
        Course course;
        public Course_info()
        {
            InitializeComponent();
        }
        public Course_info(Course course)
        {
            InitializeComponent();
            this.course = course;
            this.programTableAdapter.Fill(this.allData.Program);
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            comboBox1.Enabled = false;
            textBox1.Text = course.Couse_name;
            textBox2.Text = course.Credits.ToString();
            textBox3.Text = course.Fee.ToString();
            textBox4.Text = course.Prerequsite;

            comboBox1.SelectedIndex = course.Program_id;
            //yaha se baaki
        }

        private void Course_info_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'allData.Program' table. You can move, or remove it, as needed.


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked.Equals(true))
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                comboBox1.Enabled = true;
                button1.Visible = true;
                button1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                comboBox1.Enabled = false;
                button1.Visible = false;
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Course tmp = new Course(course.Course_id, textBox1.Text.ToString(), Convert.ToInt16(textBox2.Text.ToString()), Convert.ToInt16(textBox3.Text.ToString()), textBox4.Text.ToString(), Convert.ToInt16(comboBox1.SelectedValue.ToString()));
            Dao dao = new Dao();
            dao.UpdateCourse(tmp);
            MessageBox.Show("Course Information Updated Successfully");
            dao.CloseConnection();
            this.Close();
        }
    }
}
