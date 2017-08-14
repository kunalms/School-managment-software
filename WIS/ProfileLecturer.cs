using System;
using System.Windows.Forms;
using WIS.Classes;
using WIS.DataAccess;

namespace WIS
{
    public partial class ProfileLecturer : WIS.TemplateForm
    {
        Employee lecturer;
        public ProfileLecturer(Employee Lecturer)
        {
            InitializeComponent();
            this.functionsTableAdapter.Fill(this.allData.Functions);
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            comboBox1.Enabled = false;
            checkBox3.Enabled = false;
            lecturer = Lecturer;
            comboBox1.SelectedItem = lecturer.Employee_function;


        }


        private void checkBox3_CheckedChanged(object sender, System.EventArgs e)
        {
            textBox7.PasswordChar = checkBox3.Checked ? '\0' : '*';

        }

        private void checkBox2_CheckedChanged(object sender, System.EventArgs e)
        {
            if (checkBox2.Checked.Equals(true))
            {
                textBox1.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                textBox7.Enabled = true;
                comboBox1.Enabled = true;
                checkBox3.Enabled = true;

            }
            else
            {
                textBox1.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                comboBox1.Enabled = false;
                checkBox3.Enabled = false;
            }


        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void ProfileLecturer_Load(object sender, System.EventArgs e)
        {
            // TODO: This line of code loads data into the 'allData.Functions' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'allData.Functions' table. You can move, or remove it, as needed.
            this.functionsTableAdapter.Fill(this.allData.Functions);
            textBox1.Text = lecturer.Employee_name;
            textBox2.Text = lecturer.Employee_role;
            textBox3.Text = lecturer.Employee_Address;
            textBox4.Text = lecturer.Employee_number.ToString();
            textBox5.Text = lecturer.Employee_username;
            textBox6.Text = lecturer.Employee_email;
            textBox7.Text = lecturer.Employee_password;


        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            Employee tmp = new Employee(lecturer.Employee_id, textBox1.Text.ToString(), textBox5.Text.ToString(), textBox7.Text.ToString(), lecturer.Employee_role, Convert.ToInt16(comboBox1.SelectedValue), lecturer.Employee_enable, textBox3.Text.ToString(), Convert.ToInt32(textBox4.Text.ToString()), textBox6.Text.ToString());
            Dao doa = new Dao();
            int ret = doa.UpdateEployee(tmp);
            if (ret == 1)
            {
                MessageBox.Show("Information Update Succesfully. Please Logout and login to update The information");
                doa.CloseConnection();
                this.Close();
            }
            else
            {
                MessageBox.Show("Something went wrong.");
                doa.CloseConnection();
                this.Close();
            }
        }
    }
}
