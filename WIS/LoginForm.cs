using System;
using System.Windows.Forms;
using WIS.Classes;
using WIS.DataAccess;

namespace WIS
{
    public partial class LoginForm : WIS.TemplateForm
    {

        public LoginForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dao dao = new Dao();
            if (comboBox1.SelectedIndex == 0)
            {
                String Username = textBox1.Text.ToString();
                String Password = textBox2.Text.ToString();
                Employee employee = dao.Employee_login(Username, Password);
                if (employee == null)
                {
                    MessageBox.Show("Invalid login details");
                }
                else
                {
                    if (employee.Employee_role == "admin" || employee.Employee_role == "staff")
                    {
                        this.Hide();
                        AdminForm adminform = new AdminForm(employee);
                        adminform.Closed += (s, args) => this.Close();
                        adminform.Show();
                    }
                    else if (employee.Employee_role == "lecturer")
                    {
                        this.Hide();
                        LecturerForm lecturerform = new LecturerForm(employee);
                        lecturerform.Closed += (s, args) => this.Close();
                        lecturerform.Show();
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                String Username = textBox1.Text.ToString();
                String Password = textBox2.Text.ToString();
                Student_program student = dao.Student_login(Username, Password);
                //MessageBox.Show("hi" + student.Student_father.ToString());
                if (student == null)
                {
                    MessageBox.Show("Invalid login details");
                }
                else
                {
                    this.Hide();
                    StudentForm studentform = new StudentForm(student);
                    studentform.Closed += (s, args) => this.Close();
                    studentform.Show();
                }
            }
            dao.CloseConnection();
        }
    }
}
