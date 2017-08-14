using System;
using System.Windows.Forms;
using WIS.Classes;
using WIS.DataAccess;

namespace WIS
{
    public partial class Fee : WIS.TemplateForm
    {
        Employee admin;
        public Fee(Employee adm)
        {
            InitializeComponent();
            admin = adm;
            label1.Text = "Welcome " + admin.Employee_name.ToString();
            this.studentTableAdapter.Fill(this.allData.Student);
            comboBox2.SelectedItem = 0;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            comboBox1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Fee_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataTable4TableAdapter.Fill(this.report.DataTable4, Convert.ToInt16(comboBox2.SelectedValue.ToString()));
            Double fees = 0, discount = 0, pay = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                fees += Convert.ToDouble(row.Cells[2].Value.ToString());
            }
            Dao dao = new Dao();

            Student_program stud = dao.FetchStudentbyID(Convert.ToInt16(comboBox2.SelectedValue.ToString()));
            comboBox1.SelectedIndex = stud.Student_sibling;

            dao.CloseConnection();

            if (stud.Student_sibling == 0)
            {
                discount = 0;
            }
            else if (stud.Student_sibling == 1)
            {
                discount = (0.05 * fees);
            }
            else if (stud.Student_sibling == 2)
            {
                discount = (0.1 * fees);
            }
            else if (stud.Student_sibling == 3)
            {
                discount = (0.2 * fees);
            }
            textBox1.Text = fees.ToString() + "/- ";
            textBox2.Text = discount.ToString() + "/- ";
            textBox3.Text = (fees - discount).ToString() + "/- ";
        }
    }
}
