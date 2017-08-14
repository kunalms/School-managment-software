using System;
using System.Windows.Forms;
using WIS.Classes;

namespace WIS
{
    public partial class Viewgradestudent : WIS.TemplateForm
    {
        Student_program student;
        public Viewgradestudent(Student_program stud)
        {
            InitializeComponent();
            student = stud;
            label1.Text = "Welcome " + student.Student_name.ToString();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;

        }

        private void Viewgradestudent_Load(object sender, EventArgs e)
        {
            this.dataTable3TableAdapter.Fill(this.report.DataTable3, Convert.ToInt16(student.Student_id.ToString()));
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridView1.SelectedRows[0];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
            textBox5.Text = row.Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
