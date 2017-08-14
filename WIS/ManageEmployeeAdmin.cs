using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WIS.Classes;
using WIS.DataAccess;

namespace WIS
{
    public partial class ManageEmployeeAdmin : WIS.TemplateForm
    {
        Employee admin;
        SqlDataAdapter da;
        DataSet ds;
        Dao dao;

        public ManageEmployeeAdmin(Employee abc)
        {
            InitializeComponent();
            dao = new Dao();
            ds = new DataSet();
            da = new SqlDataAdapter("select * from Employee where Employee_role = 'lecturer' or Employee_role = 'staff'", dao.connection);
            da.Fill(ds, "Employee");
            this.admin = abc;
            label1.Text = "Welcome " + admin.Employee_name;
            dao.CloseConnection();
        }

        private void ManageEmployeeAdmin_Load(object sender, System.EventArgs e)
        {
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "Employee";
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, System.EventArgs e)
        {
            AddLecturer addLecturer = new AddLecturer(admin);
            addLecturer.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
            this.Hide();
            addLecturer.Show();
        }

        private void button8_Click(object sender, System.EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataGridView2.SelectedRows[0];

                Employee emp = new Employee(Convert.ToInt32(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[7].Value.ToString(), row.Cells[8].Value.ToString(), row.Cells[2].Value.ToString(), Convert.ToInt32(row.Cells[3].Value.ToString()), Convert.ToInt32(row.Cells[4].Value.ToString()), row.Cells[5].Value.ToString(), Convert.ToInt32(row.Cells[6].Value.ToString()), row.Cells[9].Value.ToString());
                AddLecturer addLecturer = new AddLecturer(admin, emp);
                addLecturer.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
                this.Hide();
                addLecturer.Show();
            }
        }

        void otherForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            dao = new Dao();
            ds = new DataSet();
            da = new SqlDataAdapter("select * from Employee where Employee_role = 'lecturer' or Employee_role = 'staff'", dao.connection);
            da.Fill(ds, "Employee");
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "Employee";
            //dao.CloseConnection();
            this.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AdminLecturer otherForm = new AdminLecturer(admin);
            otherForm.FormClosed += new FormClosedEventHandler(otherForm_FormClosed);
            this.Hide();
            otherForm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dao = new Dao();
            if (comboBox1.SelectedIndex == 0)
            {
                groupBox2.Text = "Lecturer";
                ds.Clear();
                da = new SqlDataAdapter("select * from Employee where Employee_role = 'lecturer'", dao.connection);
                da.Fill(ds, "Employee");
                dataGridView2.DataSource = ds;
                dataGridView2.DataMember = "Employee";
            }
            else
            {
                groupBox2.Text = "Staff";
                ds.Clear();
                da = new SqlDataAdapter("select * from Employee where Employee_role = 'staff'", dao.connection);
                da.Fill(ds, "Employee");
                dataGridView2.DataSource = ds;
                dataGridView2.DataMember = "Employee";
            }
            dao.CloseConnection();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
