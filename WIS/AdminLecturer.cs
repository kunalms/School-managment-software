using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WIS.Classes;
using WIS.DataAccess;

namespace WIS
{
    public partial class AdminLecturer : WIS.TemplateForm
    {
        Employee admin;
        SqlDataAdapter da;
        DataSet ds;
        Dao dao;

        private void AdminLecturer_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Employee";
            comboBox1.SelectedIndex = 0;

        }

        public AdminLecturer(Employee abc)
        {
            InitializeComponent();
            admin = abc;
            this.admin = abc;
            label1.Text = "Welcome " + admin.Employee_name;
            dao = new Dao();
            ds = new DataSet();
            da = new SqlDataAdapter("select * from Employee where employee_role='lecturer' or employee_role='staff' ", dao.connection);
            da.Fill(ds, "Employee");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dao.CloseConnection();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label2.Text = "Lecturer ID";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                label2.Text = "Lecturer Name";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                label2.Text = "Course Name";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                if (textBox1.Text.Length == 0)
                {
                    MessageBox.Show("enter valid inputs");
                }
                else
                {
                    dao = new Dao();
                    string query = "SELECT * FROM Employee WHERE (Employee_role = 'lecturer' or Employee_role='staff') AND (Employee_id = '" + textBox1.Text.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query, dao.connection);
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable("Users");
                    dt.Load(dr);
                    dao.CloseConnection();
                    dataGridView1.DataSource = dt;
                }
            }

            if (comboBox1.SelectedIndex == 1)
            {
                if (textBox1.Text.Length == 0)
                {
                    MessageBox.Show("enter valid inputs");
                }
                else
                {
                    dao = new Dao();
                    string query = "SELECT * FROM Employee WHERE (Employee_role = 'lecturer' or Employee_role ='staff') AND ( Employee_name  like '%" + textBox1.Text.ToString() + "%')";
                    SqlCommand cmd = new SqlCommand(query, dao.connection);
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable("Users");
                    dt.Load(dr);
                    dao.CloseConnection();
                    dataGridView1.DataSource = dt;
                }
            }

            if (comboBox1.SelectedIndex == 2)
            {
                if (textBox1.Text.Length == 0)
                {
                    MessageBox.Show("enter valid inputs");
                }
                else
                {
                    dao = new Dao();
                    string query = "SELECT  Employee.Employee_id, Employee.Employee_name, Course.Couse_name, Employee.Employee_role, Employee.Employee_function, Employee.Employee_enable, Employee.Employee_Address,  Employee.Employee_number, Employee.Employee_username, Employee.Employee_password, Employee.Employee_email FROM Course INNER JOIN Employee_course ON Course.Course_id = Employee_course.Course_id INNER JOIN Employee ON Employee_course.Employee_id = Employee.Employee_id WHERE (Course.Couse_name LIKE '%" + textBox1.Text.ToString() + "%') AND (Employee.Employee_role ='lecturer' or Employee.Employee_role='staff')";
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                //MessageBox.Show(row.Cells[0].Value.ToString() + row.Cells[1].Value.ToString());
                int Id = (int)row.Cells["Employee_id"].Value;
                bool tmp = dao.DeleteLecturer(Id);

                if (tmp == true)
                    MessageBox.Show("deleted successfully");
                else
                    MessageBox.Show("Something went wrong");
                dao.CloseConnection();
                this.Close();
            }
        }
    }
}
