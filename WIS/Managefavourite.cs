using System;
using System.Windows.Forms;
using WIS.Classes;
using WIS.DataAccess;

namespace WIS
{
    public partial class Managefavourite : WIS.TemplateForm
    {
        Student_program student;
        public Managefavourite(Student_program stud)
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

        private void button1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void Managefavourite_Load(object sender, System.EventArgs e)
        {
            this.dataTable11TableAdapter.Fill(this.report.DataTable11, Convert.ToInt16(student.Student_id.ToString()));
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                row = dataGridView1.SelectedRows[0];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                textBox6.Text = row.Cells[5].Value.ToString() + " Months";
                textBox7.Text = row.Cells[6].Value.ToString();

            }
            else
            {
                textBox1.Text = " ";
                textBox2.Text = " ";
                textBox3.Text = " ";
                textBox4.Text = " ";
                textBox5.Text = " ";
                textBox6.Text = " ";
                textBox7.Text = " ";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dao dao = new Dao();
            DataGridViewRow row = new DataGridViewRow();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                row = dataGridView1.SelectedRows[0];
                bool tmp = dao.DeleteFavourite(Convert.ToInt16(student.Student_id), Convert.ToInt16(row.Cells[5].Value.ToString()));
                if (tmp == true)
                    MessageBox.Show("Successfully deleted from favourite");
                else
                    MessageBox.Show("Something went wrong :(");
                dao.CloseConnection();
                this.dataTable11TableAdapter.Fill(this.report.DataTable11, Convert.ToInt16(student.Student_id.ToString()));
            }

        }
    }
}
