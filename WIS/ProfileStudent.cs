using System;
using System.Windows.Forms;
using WIS.Classes;
using WIS.DataAccess;

namespace WIS
{
    public partial class ProfileStudent : WIS.TemplateForm
    {
        Student_program student;
        public ProfileStudent(Student_program stud)
        {
            InitializeComponent();
            student = stud;
        }

        private void ProfileStudent_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'allData.Program' table. You can move, or remove it, as needed.
            this.programTableAdapter.Fill(this.allData.Program);
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            checkBox1.Enabled = false;


            textBox1.Text = student.Student_name.ToString();
            textBox2.Text = student.Student_father.ToString();
            textBox3.Text = student.Student_mother.ToString();
            textBox4.Text = student.Student_contact.ToString();
            textBox5.Text = student.Student_email.ToString();
            textBox6.Text = student.Student_username.ToString();
            textBox7.Text = student.Student_password.ToString();
            comboBox1.SelectedIndex = student.Student_sibling;
            comboBox2.SelectedValue = student.Student_programs;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox7.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                checkBox1.Enabled = false;
            }
            else
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                textBox7.Enabled = true;
                checkBox1.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Student_program tmp = new Student_program(student.Student_id, textBox1.Text.ToString(), textBox6.Text.ToString(), textBox7.Text.ToString(), textBox2.Text.ToString(), textBox3.Text.ToString(), " ", Convert.ToInt32(textBox4.Text.ToString()), textBox5.Text.ToString(), comboBox1.SelectedIndex, Convert.ToInt16(comboBox2.SelectedValue.ToString()));
            Dao doa = new Dao();
            doa.UpdateStudent(tmp);
            MessageBox.Show("Data Update sucessfully");
            doa.CloseConnection();
            this.Close();
        }
    }
}
