namespace IFAD_v1._1
{
    partial class ProductLedger
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
            this.textBoxProductID = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxProductSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewInwards = new System.Windows.Forms.DataGridView();
            this.dataGridViewOutwards = new System.Windows.Forms.DataGridView();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.textBoxProductCode = new System.Windows.Forms.TextBox();
            this.radioButtonInwards = new System.Windows.Forms.RadioButton();
            this.radioButtonOutwards = new System.Windows.Forms.RadioButton();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInwards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutwards)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonOutwards);
            this.groupBox1.Controls.Add(this.radioButtonInwards);
            this.groupBox1.Controls.Add(this.textBoxProductCode);
            this.groupBox1.Controls.Add(this.textBoxProductName);
            this.groupBox1.Controls.Add(this.textBoxProductID);
            this.groupBox1.Controls.Add(this.buttonSearch);
            this.groupBox1.Controls.Add(this.textBoxProductSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1049, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product Ledger";
            // 
            // textBoxProductID
            // 
            this.textBoxProductID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxProductID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxProductID.Location = new System.Drawing.Point(388, 9);
            this.textBoxProductID.Name = "textBoxProductID";
            this.textBoxProductID.Size = new System.Drawing.Size(41, 22);
            this.textBoxProductID.TabIndex = 3;
            this.textBoxProductID.Visible = false;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(551, 33);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(107, 28);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "&Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxProductSearch
            // 
            this.textBoxProductSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxProductSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxProductSearch.Location = new System.Drawing.Point(197, 37);
            this.textBoxProductSearch.Name = "textBoxProductSearch";
            this.textBoxProductSearch.Size = new System.Drawing.Size(338, 22);
            this.textBoxProductSearch.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Name / Product Code";
            // 
            // dataGridViewInwards
            // 
            this.dataGridViewInwards.AllowUserToAddRows = false;
            this.dataGridViewInwards.AllowUserToDeleteRows = false;
            this.dataGridViewInwards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInwards.Location = new System.Drawing.Point(31, 178);
            this.dataGridViewInwards.Name = "dataGridViewInwards";
            this.dataGridViewInwards.ReadOnly = true;
            this.dataGridViewInwards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewInwards.Size = new System.Drawing.Size(417, 150);
            this.dataGridViewInwards.TabIndex = 1;
            // 
            // dataGridViewOutwards
            // 
            this.dataGridViewOutwards.AllowUserToAddRows = false;
            this.dataGridViewOutwards.AllowUserToDeleteRows = false;
            this.dataGridViewOutwards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOutwards.Location = new System.Drawing.Point(568, 178);
            this.dataGridViewOutwards.Name = "dataGridViewOutwards";
            this.dataGridViewOutwards.ReadOnly = true;
            this.dataGridViewOutwards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOutwards.Size = new System.Drawing.Size(417, 161);
            this.dataGridViewOutwards.TabIndex = 2;
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxProductName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxProductName.Location = new System.Drawing.Point(253, 10);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(41, 22);
            this.textBoxProductName.TabIndex = 4;
            this.textBoxProductName.Visible = false;
            // 
            // textBoxProductCode
            // 
            this.textBoxProductCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxProductCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxProductCode.Location = new System.Drawing.Point(317, 10);
            this.textBoxProductCode.Name = "textBoxProductCode";
            this.textBoxProductCode.Size = new System.Drawing.Size(41, 22);
            this.textBoxProductCode.TabIndex = 5;
            this.textBoxProductCode.Visible = false;
            // 
            // radioButtonInwards
            // 
            this.radioButtonInwards.AutoSize = true;
            this.radioButtonInwards.Location = new System.Drawing.Point(694, 37);
            this.radioButtonInwards.Name = "radioButtonInwards";
            this.radioButtonInwards.Size = new System.Drawing.Size(72, 20);
            this.radioButtonInwards.TabIndex = 6;
            this.radioButtonInwards.TabStop = true;
            this.radioButtonInwards.Text = "Inwards";
            this.radioButtonInwards.UseVisualStyleBackColor = true;
            this.radioButtonInwards.CheckedChanged += new System.EventHandler(this.radioButtonInwards_CheckedChanged);
            // 
            // radioButtonOutwards
            // 
            this.radioButtonOutwards.AutoSize = true;
            this.radioButtonOutwards.Location = new System.Drawing.Point(790, 37);
            this.radioButtonOutwards.Name = "radioButtonOutwards";
            this.radioButtonOutwards.Size = new System.Drawing.Size(82, 20);
            this.radioButtonOutwards.TabIndex = 7;
            this.radioButtonOutwards.TabStop = true;
            this.radioButtonOutwards.Text = "Outwards";
            this.radioButtonOutwards.UseVisualStyleBackColor = true;
            this.radioButtonOutwards.CheckedChanged += new System.EventHandler(this.radioButtonOutwards_CheckedChanged);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(2, 93);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowCloseButton = false;
            this.crystalReportViewer1.ShowLogo = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1049, 534);
            this.crystalReportViewer1.TabIndex = 3;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ProductLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 628);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.dataGridViewOutwards);
            this.Controls.Add(this.dataGridViewInwards);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1068, 667);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1068, 667);
            this.Name = "ProductLedger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Ledger";
            this.Load += new System.EventHandler(this.ProductLedger_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInwards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutwards)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxProductSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxProductID;
        private System.Windows.Forms.DataGridView dataGridViewInwards;
        private System.Windows.Forms.DataGridView dataGridViewOutwards;
        private System.Windows.Forms.TextBox textBoxProductCode;
        private System.Windows.Forms.TextBox textBoxProductName;
        private System.Windows.Forms.RadioButton radioButtonOutwards;
        private System.Windows.Forms.RadioButton radioButtonInwards;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}