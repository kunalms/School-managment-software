using System;
using System.Windows.Forms;
using WIS.Classes;
using WIS.DataAccess;

namespace WIS
{
    public partial class ViewCourseStudent : WIS.TemplateForm
    {
        Student_program student;
        public ViewCourseStudent(Student_program stud)
        {
            InitializeComponent();
            student = stud;
            label1.Text = "Welcome " + student.Student_name.ToString();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewCourseStudent_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'allData.DataTable1' table. You can move, or remove it, as needed.
            this.dataTable1TableAdapter.Fill(this.allData.DataTable1);

        }


        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridView1.SelectedRows[0];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
            textBox5.Text = row.Cells[4].Value.ToString();
            textBox6.Text = row.Cells[5].Value.ToString() + " Months";
            textBox7.Text = row.Cells[6].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dao dao = new Dao();
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridView1.SelectedRows[0];
            bool tmp = dao.AddFavourite(Convert.ToInt16(student.Student_id), Convert.ToInt16(row.Cells[6].Value.ToString()));
            if (tmp == true)
                MessageBox.Show("Successfully added in favourite");
            else
                MessageBox.Show("course already in the favourite");
            dao.CloseConnection();
        }
    }
}
