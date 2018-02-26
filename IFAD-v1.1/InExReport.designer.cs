namespace IFAD_v1._1
{
    partial class InExReport
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonExpensiveSearch = new System.Windows.Forms.Button();
            this.buttonIncomeSearch = new System.Windows.Forms.Button();
            this.dateTimePickerE2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerE1 = new System.Windows.Forms.DateTimePicker();
            this.radioButtonExpensive = new System.Windows.Forms.RadioButton();
            this.dateTimePickerI2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerI1 = new System.Windows.Forms.DateTimePicker();
            this.radioButtonIncome = new System.Windows.Forms.RadioButton();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.dataGridViewIncome = new System.Windows.Forms.DataGridView();
            this.dataGridViewExpensive = new System.Windows.Forms.DataGridView();
            this.comboBoxExpenseType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIncome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpensive)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBoxExpenseType);
            this.groupBox1.Controls.Add(this.buttonExpensiveSearch);
            this.groupBox1.Controls.Add(this.buttonIncomeSearch);
            this.groupBox1.Controls.Add(this.dateTimePickerE2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePickerE1);
            this.groupBox1.Controls.Add(this.radioButtonExpensive);
            this.groupBox1.Controls.Add(this.dateTimePickerI2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePickerI1);
            this.groupBox1.Controls.Add(this.radioButtonIncome);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1083, 99);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report";
            // 
            // buttonExpensiveSearch
            // 
            this.buttonExpensiveSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExpensiveSearch.Location = new System.Drawing.Point(917, 67);
            this.buttonExpensiveSearch.Name = "buttonExpensiveSearch";
            this.buttonExpensiveSearch.Size = new System.Drawing.Size(98, 24);
            this.buttonExpensiveSearch.TabIndex = 11;
            this.buttonExpensiveSearch.Text = "Search";
            this.buttonExpensiveSearch.UseVisualStyleBackColor = true;
            this.buttonExpensiveSearch.Click += new System.EventHandler(this.buttonExpensiveSearch_Click);
            // 
            // buttonIncomeSearch
            // 
            this.buttonIncomeSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIncomeSearch.Location = new System.Drawing.Point(314, 70);
            this.buttonIncomeSearch.Name = "buttonIncomeSearch";
            this.buttonIncomeSearch.Size = new System.Drawing.Size(94, 24);
            this.buttonIncomeSearch.TabIndex = 10;
            this.buttonIncomeSearch.Text = "Search";
            this.buttonIncomeSearch.UseVisualStyleBackColor = true;
            this.buttonIncomeSearch.Click += new System.EventHandler(this.buttonIncomeSearch_Click);
            // 
            // dateTimePickerE2
            // 
            this.dateTimePickerE2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerE2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerE2.Location = new System.Drawing.Point(584, 68);
            this.dateTimePickerE2.Name = "dateTimePickerE2";
            this.dateTimePickerE2.Size = new System.Drawing.Size(143, 22);
            this.dateTimePickerE2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(582, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "End Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(419, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Start Date";
            // 
            // dateTimePickerE1
            // 
            this.dateTimePickerE1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerE1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerE1.Location = new System.Drawing.Point(422, 70);
            this.dateTimePickerE1.Name = "dateTimePickerE1";
            this.dateTimePickerE1.Size = new System.Drawing.Size(143, 22);
            this.dateTimePickerE1.TabIndex = 6;
            // 
            // radioButtonExpensive
            // 
            this.radioButtonExpensive.AutoSize = true;
            this.radioButtonExpensive.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonExpensive.Location = new System.Drawing.Point(422, 23);
            this.radioButtonExpensive.Name = "radioButtonExpensive";
            this.radioButtonExpensive.Size = new System.Drawing.Size(79, 20);
            this.radioButtonExpensive.TabIndex = 5;
            this.radioButtonExpensive.TabStop = true;
            this.radioButtonExpensive.Text = "Expense";
            this.radioButtonExpensive.UseVisualStyleBackColor = true;
            this.radioButtonExpensive.CheckedChanged += new System.EventHandler(this.radioButtonExpensive_CheckedChanged);
            // 
            // dateTimePickerI2
            // 
            this.dateTimePickerI2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerI2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerI2.Location = new System.Drawing.Point(165, 71);
            this.dateTimePickerI2.Name = "dateTimePickerI2";
            this.dateTimePickerI2.Size = new System.Drawing.Size(143, 22);
            this.dateTimePickerI2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(162, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "End Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(13, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start Date";
            // 
            // dateTimePickerI1
            // 
            this.dateTimePickerI1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerI1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerI1.Location = new System.Drawing.Point(9, 71);
            this.dateTimePickerI1.Name = "dateTimePickerI1";
            this.dateTimePickerI1.Size = new System.Drawing.Size(143, 22);
            this.dateTimePickerI1.TabIndex = 1;
            // 
            // radioButtonIncome
            // 
            this.radioButtonIncome.AutoSize = true;
            this.radioButtonIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonIncome.Location = new System.Drawing.Point(9, 27);
            this.radioButtonIncome.Name = "radioButtonIncome";
            this.radioButtonIncome.Size = new System.Drawing.Size(70, 20);
            this.radioButtonIncome.TabIndex = 0;
            this.radioButtonIncome.TabStop = true;
            this.radioButtonIncome.Text = "Income";
            this.radioButtonIncome.UseVisualStyleBackColor = true;
            this.radioButtonIncome.CheckedChanged += new System.EventHandler(this.radioButtonIncome_CheckedChanged);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(3, 108);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowCloseButton = false;
            this.crystalReportViewer1.ShowLogo = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1083, 540);
            this.crystalReportViewer1.TabIndex = 1;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // dataGridViewIncome
            // 
            this.dataGridViewIncome.AllowUserToAddRows = false;
            this.dataGridViewIncome.AllowUserToDeleteRows = false;
            this.dataGridViewIncome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIncome.Location = new System.Drawing.Point(873, 151);
            this.dataGridViewIncome.Name = "dataGridViewIncome";
            this.dataGridViewIncome.ReadOnly = true;
            this.dataGridViewIncome.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewIncome.Size = new System.Drawing.Size(240, 150);
            this.dataGridViewIncome.TabIndex = 2;
            // 
            // dataGridViewExpensive
            // 
            this.dataGridViewExpensive.AllowUserToAddRows = false;
            this.dataGridViewExpensive.AllowUserToDeleteRows = false;
            this.dataGridViewExpensive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExpensive.Location = new System.Drawing.Point(873, 324);
            this.dataGridViewExpensive.Name = "dataGridViewExpensive";
            this.dataGridViewExpensive.ReadOnly = true;
            this.dataGridViewExpensive.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewExpensive.Size = new System.Drawing.Size(240, 88);
            this.dataGridViewExpensive.TabIndex = 3;
            // 
            // comboBoxExpenseType
            // 
            this.comboBoxExpenseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExpenseType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxExpenseType.FormattingEnabled = true;
            this.comboBoxExpenseType.Location = new System.Drawing.Point(743, 67);
            this.comboBoxExpenseType.Name = "comboBoxExpenseType";
            this.comboBoxExpenseType.Size = new System.Drawing.Size(168, 24);
            this.comboBoxExpenseType.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(740, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Expense Type";
            // 
            // InExReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 648);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewIncome);
            this.Controls.Add(this.dataGridViewExpensive);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1087, 687);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1087, 687);
            this.Name = "InExReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.Load += new System.EventHandler(this.DueList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIncome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpensive)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerI1;
        private System.Windows.Forms.RadioButton radioButtonIncome;
        private System.Windows.Forms.DateTimePicker dateTimePickerE2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerE1;
        private System.Windows.Forms.RadioButton radioButtonExpensive;
        private System.Windows.Forms.DateTimePicker dateTimePickerI2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonExpensiveSearch;
        private System.Windows.Forms.Button buttonIncomeSearch;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.DataGridView dataGridViewIncome;
        private System.Windows.Forms.DataGridView dataGridViewExpensive;
        private System.Windows.Forms.ComboBox comboBoxExpenseType;
        private System.Windows.Forms.Label label5;
    }
}