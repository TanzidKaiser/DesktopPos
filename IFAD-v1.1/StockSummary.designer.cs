namespace IFAD_v1._1
{
    partial class StockSummary
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
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewStuckSummary = new System.Windows.Forms.DataGridView();
            this.dataGridViewSales = new System.Windows.Forms.DataGridView();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.dataGridViewOpenPurchase = new System.Windows.Forms.DataGridView();
            this.dataGridViewOpenSales = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStuckSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOpenPurchase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOpenSales)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.buttonSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1121, 69);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "&Stock Summary";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(481, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "&End Date";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(546, 27);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(795, 23);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 31);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "&Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "&Start Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(205, 26);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // dataGridViewStuckSummary
            // 
            this.dataGridViewStuckSummary.AllowUserToAddRows = false;
            this.dataGridViewStuckSummary.AllowUserToDeleteRows = false;
            this.dataGridViewStuckSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStuckSummary.Location = new System.Drawing.Point(34, 78);
            this.dataGridViewStuckSummary.Name = "dataGridViewStuckSummary";
            this.dataGridViewStuckSummary.ReadOnly = true;
            this.dataGridViewStuckSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStuckSummary.Size = new System.Drawing.Size(446, 129);
            this.dataGridViewStuckSummary.TabIndex = 1;
            // 
            // dataGridViewSales
            // 
            this.dataGridViewSales.AllowUserToAddRows = false;
            this.dataGridViewSales.AllowUserToDeleteRows = false;
            this.dataGridViewSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSales.Location = new System.Drawing.Point(34, 213);
            this.dataGridViewSales.Name = "dataGridViewSales";
            this.dataGridViewSales.ReadOnly = true;
            this.dataGridViewSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSales.Size = new System.Drawing.Size(446, 98);
            this.dataGridViewSales.TabIndex = 2;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(2, 63);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowCloseButton = false;
            this.crystalReportViewer1.ShowLogo = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1121, 577);
            this.crystalReportViewer1.TabIndex = 3;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // dataGridViewOpenPurchase
            // 
            this.dataGridViewOpenPurchase.AllowUserToAddRows = false;
            this.dataGridViewOpenPurchase.AllowUserToDeleteRows = false;
            this.dataGridViewOpenPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOpenPurchase.Location = new System.Drawing.Point(486, 78);
            this.dataGridViewOpenPurchase.Name = "dataGridViewOpenPurchase";
            this.dataGridViewOpenPurchase.ReadOnly = true;
            this.dataGridViewOpenPurchase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOpenPurchase.Size = new System.Drawing.Size(592, 129);
            this.dataGridViewOpenPurchase.TabIndex = 4;
            // 
            // dataGridViewOpenSales
            // 
            this.dataGridViewOpenSales.AllowUserToAddRows = false;
            this.dataGridViewOpenSales.AllowUserToDeleteRows = false;
            this.dataGridViewOpenSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOpenSales.Location = new System.Drawing.Point(486, 213);
            this.dataGridViewOpenSales.Name = "dataGridViewOpenSales";
            this.dataGridViewOpenSales.ReadOnly = true;
            this.dataGridViewOpenSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOpenSales.Size = new System.Drawing.Size(592, 98);
            this.dataGridViewOpenSales.TabIndex = 5;
            // 
            // StockSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 642);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.dataGridViewSales);
            this.Controls.Add(this.dataGridViewStuckSummary);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewOpenPurchase);
            this.Controls.Add(this.dataGridViewOpenSales);
            this.Name = "StockSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Summary";
            this.Load += new System.EventHandler(this.StockSummary_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStuckSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOpenPurchase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOpenSales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridViewStuckSummary;
        private System.Windows.Forms.DataGridView dataGridViewSales;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.DataGridView dataGridViewOpenPurchase;
        private System.Windows.Forms.DataGridView dataGridViewOpenSales;
    }
}