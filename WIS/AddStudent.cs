using System;
using System.Windows.Forms;
using WIS.Classes;
using WIS.DataAccess;

namespace WIS
{
    public partial class AddStudent : WIS.TemplateForm
    {
        Student_program student;
        int flag = 0;
        public AddStudent()
        {
            InitializeComponent();
            this.programTableAdapter.Fill(this.allData.Program);
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            button1.Image = WIS.Properties.Resources.BtnAdd1;
            pictureBox3.Image = WIS.Properties.Resources.Student;
            this.programTableAdapter.Fill(this.allData.Program);
        }

        public AddStudent(Student_program stude)
        {
            InitializeComponent();
            this.programTableAdapter.Fill(this.allData.Program);
            student = stude;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            comboBox2.SelectedIndex = stude.Student_programs;
            flag = 1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                label7.Visible = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                label8.Visible = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 0)
            {
                label9.Visible = false;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length > 0)
            {
                label10.Visible = false;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Length > 0)
            {
                label11.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dao dao = new Dao();
            if (flag == 1)
            {
                Student_program tmp = new Student_program(student.Student_id, textBox1.Text.ToString(), textBox1.Text.ToString(), student.Student_password, textBox2.Text.ToString(), textBox3.Text.ToString(), student.Student_past_course, Convert.ToInt32(textBox4.Text.ToString()), textBox5.Text.ToString(), comboBox1.SelectedIndex, comboBox2.SelectedIndex);
                dao.UpdateStudent(tmp);
                MessageBox.Show("Student Information Updated Successfully");
                dao.CloseConnection();
                this.Close();
            }
            else
            {
                string password = "student";
                Student_program tmp = new Student_program(999, textBox1.Text.ToString(), textBox1.Text.ToString(), password.ToString(), textBox2.Text.ToString(), textBox3.Text.ToString(), " ", Convert.ToInt32(textBox4.Text.ToString()), textBox5.Text.ToString(), comboBox1.SelectedIndex, comboBox2.SelectedIndex);

                bool ans = dao.AddStudent(tmp);
                if (ans == true)
                {
                    MessageBox.Show("data entered succesfully");
                }
                else
                {
                    MessageBox.Show("Something Went wrong Please try later.");
                }
                dao.CloseConnection();
                this.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label12.Visible = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label14.Visible = false;
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'allData.Program' table. You can move, or remove it, as needed.

            if (flag == 1)
            {
                comboBox1.SelectedIndex = student.Student_sibling;
                comboBox2.SelectedValue = student.Student_programs;
                textBox1.Text = student.Student_name.ToString();
                textBox2.Text = student.Student_father.ToString();
                textBox3.Text = student.Student_mother.ToString();
                textBox4.Text = student.Student_contact.ToString();
                textBox5.Text = student.Student_email.ToString();
                button1.Image = WIS.Properties.Resources.BtnUpdate;
                label6.Visible = false;
                pictureBox3.Image = WIS.Properties.Resources.admin;
            }
        }
    }
}
