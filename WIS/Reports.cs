using WIS.Classes;

namespace WIS
{
    public partial class Reports : WIS.TemplateForm
    {
        Employee admin;
        public Reports(Employee abc)
        {
            InitializeComponent();
            this.admin = abc;
            label1.Text = "Welcome " + admin.Employee_name;
            comboBox1.SelectedIndex = 0;
            reportViewer2.Visible = false;
        }

        private void Reports_Load(object sender, System.EventArgs e)
        {
            // TODO: This line of code loads data into the 'report.DataTable2' table. You can move, or remove it, as needed.
            this.DataTable2TableAdapter.Fill(this.report.DataTable2);
            // TODO: This line of code loads data into the 'report.DataTable1' table. You can move, or remove it, as needed.
            this.DataTable1TableAdapter.Fill(this.report.DataTable1);
            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            if (comboBox1.SelectedIndex == 0)
            {
                reportViewer1.Visible = true;
                reportViewer2.Visible = false;
            }

            else if (comboBox1.SelectedIndex == 1)
            {
                reportViewer1.Visible = false;
                reportViewer2.Visible = true;

            }
        }
    }
}
