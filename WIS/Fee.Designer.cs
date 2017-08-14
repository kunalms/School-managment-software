namespace WIS
{
    partial class Fee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cousenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marks1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marks2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marks3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gradeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataTable4BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.report = new WIS.report();
            this.dataTable4TableAdapter = new WIS.reportTableAdapters.DataTable4TableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.allData = new WIS.AllData();
            this.label6 = new System.Windows.Forms.Label();
            this.studentTableAdapter = new WIS.AllDataTableAdapters.StudentTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable4BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allData)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = global::WIS.Properties.Resources.BtnBack1;
            this.button4.Location = new System.Drawing.Point(15, 516);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(222, 60);
            this.button4.TabIndex = 8;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 478);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Welcome";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pictureBox3.Image = global::WIS.Properties.Resources.admin;
            this.pictureBox3.Location = new System.Drawing.Point(12, 250);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(225, 225);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cousenameDataGridViewTextBoxColumn,
            this.creditsDataGridViewTextBoxColumn,
            this.feeDataGridViewTextBoxColumn,
            this.marks1DataGridViewTextBoxColumn,
            this.marks2DataGridViewTextBoxColumn,
            this.marks3DataGridViewTextBoxColumn,
            this.gradeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.dataTable4BindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(284, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(687, 231);
            this.dataGridView1.TabIndex = 9;
            // 
            // cousenameDataGridViewTextBoxColumn
            // 
            this.cousenameDataGridViewTextBoxColumn.DataPropertyName = "Couse_name";
            this.cousenameDataGridViewTextBoxColumn.HeaderText = "Couse_name";
            this.cousenameDataGridViewTextBoxColumn.Name = "cousenameDataGridViewTextBoxColumn";
            this.cousenameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // creditsDataGridViewTextBoxColumn
            // 
            this.creditsDataGridViewTextBoxColumn.DataPropertyName = "Credits";
            this.creditsDataGridViewTextBoxColumn.HeaderText = "Credits";
            this.creditsDataGridViewTextBoxColumn.Name = "creditsDataGridViewTextBoxColumn";
            this.creditsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // feeDataGridViewTextBoxColumn
            // 
            this.feeDataGridViewTextBoxColumn.DataPropertyName = "Fee";
            this.feeDataGridViewTextBoxColumn.HeaderText = "Fee";
            this.feeDataGridViewTextBoxColumn.Name = "feeDataGridViewTextBoxColumn";
            this.feeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // marks1DataGridViewTextBoxColumn
            // 
            this.marks1DataGridViewTextBoxColumn.DataPropertyName = "Marks_1";
            this.marks1DataGridViewTextBoxColumn.HeaderText = "Marks_1";
            this.marks1DataGridViewTextBoxColumn.Name = "marks1DataGridViewTextBoxColumn";
            this.marks1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // marks2DataGridViewTextBoxColumn
            // 
            this.marks2DataGridViewTextBoxColumn.DataPropertyName = "Marks_2";
            this.marks2DataGridViewTextBoxColumn.HeaderText = "Marks_2";
            this.marks2DataGridViewTextBoxColumn.Name = "marks2DataGridViewTextBoxColumn";
            this.marks2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // marks3DataGridViewTextBoxColumn
            // 
            this.marks3DataGridViewTextBoxColumn.DataPropertyName = "Marks_3";
            this.marks3DataGridViewTextBoxColumn.HeaderText = "Marks_3";
            this.marks3DataGridViewTextBoxColumn.Name = "marks3DataGridViewTextBoxColumn";
            this.marks3DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gradeDataGridViewTextBoxColumn
            // 
            this.gradeDataGridViewTextBoxColumn.DataPropertyName = "Grade";
            this.gradeDataGridViewTextBoxColumn.HeaderText = "Grade";
            this.gradeDataGridViewTextBoxColumn.Name = "gradeDataGridViewTextBoxColumn";
            this.gradeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataTable4BindingSource
            // 
            this.dataTable4BindingSource.DataMember = "DataTable4";
            this.dataTable4BindingSource.DataSource = this.report;
            // 
            // report
            // 
            this.report.DataSetName = "report";
            this.report.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataTable4TableAdapter
            // 
            this.dataTable4TableAdapter.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.groupBox1.Location = new System.Drawing.Point(284, 376);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(685, 291);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fee details";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "None",
            "Continue form certificate (6 months)",
            "Continue student from level 5",
            "Sibling of student"});
            this.comboBox1.Location = new System.Drawing.Point(276, 109);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(338, 32);
            this.comboBox1.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(77, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 24);
            this.label5.TabIndex = 6;
            this.label5.Text = "Student Type";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(276, 216);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(338, 29);
            this.textBox3.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Payable Amount";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(276, 164);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(338, 29);
            this.textBox2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Discount";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(276, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(338, 29);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total Fees";
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.studentBindingSource;
            this.comboBox2.DisplayMember = "Student_name";
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(437, 280);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(262, 32);
            this.comboBox2.TabIndex = 9;
            this.comboBox2.ValueMember = "Student_id";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataMember = "Student";
            this.studentBindingSource.DataSource = this.allData;
            // 
            // allData
            // 
            this.allData.DataSetName = "AllData";
            this.allData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label6.Location = new System.Drawing.Point(282, 288);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 24);
            this.label6.TabIndex = 8;
            this.label6.Text = "Student ID";
            // 
            // studentTableAdapter
            // 
            this.studentTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::WIS.Properties.Resources.BtnSearch1;
            this.button1.Location = new System.Drawing.Point(749, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(222, 60);
            this.button1.TabIndex = 11;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Fee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(981, 679);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.Name = "Fee";
            this.Load += new System.EventHandler(this.Fee_Load);
            this.Controls.SetChildIndex(this.pictureBox3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.button4, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.comboBox2, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable4BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cousenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn feeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marks1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marks2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marks3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gradeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource dataTable4BindingSource;
        private report report;
        private reportTableAdapters.DataTable4TableAdapter dataTable4TableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label6;
        private AllData allData;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private AllDataTableAdapters.StudentTableAdapter studentTableAdapter;
        private System.Windows.Forms.Button button1;
    }
}
