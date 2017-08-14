using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WIS.Classes;
using WIS.DataAccess;

namespace WIS
{
    public partial class ManageStudentAdmin : WIS.TemplateForm
    {
        Employee admin;
        SqlDataAdapter da;
        DataSet ds;
        Dao dao;

        private void ManageStudentAdmin_Load(object sender, System.EventArgs e)
        {
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Student";
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            dao = new Dao();
            if (dataGridView1.SelectedRows.Count == 1)
            {

                DataGridViewRow row = dataGridView1.SelectedRows[0];
                //MessageBox.Show(row.Cells[0].Value.ToString() + row.Cells[1].Value.ToString());
                Student_program student = new Student_program((int)row.Cells["Student_id"].Value, row.Cells["Student_name"].Value.ToString(), row.Cells["Student_username"].Value.ToString(), row.Cells["Student_password"].Value.ToString(), row.Cells["Student_father"].Value.ToString(), row.Cells["Student_mother"].Value.ToString(), row.Cells["Student_past_course"].Value.ToString(), (int)row.Cells["Student_contact"].Value, row.Cells["Student_email"].Value.ToString(), (int)row.Cells["Student_sibling"].Value, (int)row.Cells["Student_program"].Value);
                bool tmp = dao.DeleteStudent(student);
                if (tmp == true)
                {
                    ds = new DataSet();
                    da = new SqlDataAdapter("select * from Student", dao.connection);
                    da.Fill(ds, "Student");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "Student";
                    MessageBox.Show("Student removed Succesfully");
                }
            }
            dao.CloseConnection();
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            AddStudent otherForm = new AddStudent();
            otherForm.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
            this.Hide();
            otherForm.Show();
        }

        void otherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            dao = new Dao();
            ds = new DataSet();
            da = new SqlDataAdapter("select * from Student", dao.connection);
            da.Fill(ds, "Student");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Student";
            dao.CloseConnection();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                Student_program student = new Student_program((int)row.Cells[0].Value, row.Cells[1].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[6].Value.ToString(), (int)row.Cells[7].Value, row.Cells[8].Value.ToString(), (int)row.Cells[9].Value, (int)row.Cells[10].Value);
                AddStudent otherForm = new AddStudent(student);
                otherForm.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
                this.Hide();
                otherForm.Show();
            }
        }


        public ManageStudentAdmin(Employee abc)
        {
            InitializeComponent();
            dao = new Dao();
            ds = new DataSet();
            da = new SqlDataAdapter("select [Student_id],[Student_name],[Student_father],[Student_mother],[Student_username],[Student_password],[Student_past_course],[Student_contact],[Student_email],[Student_sibling],[Student_program] from Student", dao.connection);
            da.Fill(ds, "Student");
            this.admin = abc;
            label1.Text = "Welcome " + admin.Employee_name;
            dao.CloseConnection();
        }
    }
}
