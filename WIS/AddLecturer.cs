using System;
using System.Windows.Forms;
using WIS.Classes;
using WIS.DataAccess;

namespace WIS
{
    public partial class AddLecturer : WIS.TemplateForm
    {
        Employee admin, update;
        int flag = 0;


        public AddLecturer(Employee abc)
        {
            InitializeComponent();
            this.functionsTableAdapter.Fill(this.allData.Functions);
            admin = abc;
            label1.Text = "Welcome " + admin.Employee_name;
            comboBox1.SelectedIndex = 0;

        }

        public AddLecturer(Employee abc, Employee updated)
        {
            InitializeComponent();
            admin = abc;
            update = updated;
            button1.Image = WIS.Properties.Resources.BtnUpdate;

            this.functionsTableAdapter.Fill(this.allData.Functions);

            textBox1.Text = updated.Employee_name;
            comboBox1.SelectedItem = updated.Employee_role;
            comboBox2.SelectedIndex = updated.Employee_function;
            textBox2.Text = updated.Employee_Address;
            textBox3.Text = updated.Employee_number.ToString();
            textBox4.Text = updated.Employee_username;
            textBox5.Text = updated.Employee_password;
            textBox6.Text = updated.Employee_email;
            checkBox1.Checked = update.Employee_enable == 1 ? true : false;

            if (abc.Employee_role == "staff")
            {
                checkBox1.Enabled = false;
            }
            flag = 1;
            label1.Text = "Welcome " + admin.Employee_name;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddLecturer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'allData.Functions' table. You can move, or remove it, as needed.


        }

        private void textBox3_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = textBox1.Text;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.PasswordChar = checkBox3.Checked ? '\0' : '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                textBox1.Text = update.Employee_name;
                comboBox1.SelectedItem = update.Employee_role;
                comboBox2.SelectedIndex = update.Employee_function;
                textBox2.Text = update.Employee_Address;
                textBox3.Text = update.Employee_number.ToString();
                textBox4.Text = update.Employee_username;
                textBox5.Text = update.Employee_password;
                textBox6.Text = update.Employee_email;
                checkBox1.Checked = update.Employee_enable == 1 ? true : false;

                if (admin.Employee_role == "staff")
                {
                    checkBox1.Enabled = false;
                }
                flag = 1;
                label1.Text = "Welcome " + admin.Employee_name;
            }
            else
            {
                textBox1.Text = "";
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                checkBox1.Checked = false;

                if (admin.Employee_role == "staff")
                {
                    checkBox1.Enabled = false;
                }
                flag = 1;
                label1.Text = "Welcome " + admin.Employee_name;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int enabled = checkBox1.Checked ? 1 : 0;
            Employee employee;
            Dao doa = new Dao();
            if (flag == 1)
            {
                employee = new Employee(update.Employee_id, textBox1.Text.ToString(), textBox4.Text.ToString(), textBox5.Text.ToString(), comboBox1.SelectedItem.ToString(), Convert.ToInt32(comboBox2.SelectedValue.ToString()), enabled, textBox2.Text.ToString(), (int)Convert.ToInt64(textBox3.Text.ToString()), textBox6.Text.ToString());
                doa.UpdateEployee(employee);
                doa.CloseConnection();
                MessageBox.Show("Updated Successfully");
                this.Close();
            }
            else
            {

                employee = new Employee(200, textBox1.Text.ToString(), textBox4.Text.ToString(), textBox5.Text.ToString(), comboBox1.SelectedItem.ToString(), Convert.ToInt32(comboBox2.SelectedValue.ToString()), enabled, textBox2.Text.ToString(), (int)Convert.ToInt64(textBox3.Text.ToString()), textBox6.Text.ToString());

                doa.AddEmployee(employee);
                doa.CloseConnection();
                MessageBox.Show("Added Successfully");
                this.Close();
            }
        }
    }
}
