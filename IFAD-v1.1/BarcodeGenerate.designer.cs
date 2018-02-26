namespace IFAD_v1._1
{
    partial class BarcodeGenerate
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.buttonShowAllBarcode = new System.Windows.Forms.Button();
            this.buttonShowBarcode = new System.Windows.Forms.Button();
            this.textBoxNumberOfCopies = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxProductCode = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxFProductCode = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(3, 75);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowCloseButton = false;
            this.crystalReportViewer1.ShowGroupTreeButton = false;
            this.crystalReportViewer1.ShowLogo = false;
            this.crystalReportViewer1.ShowParameterPanelButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1061, 618);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // buttonShowAllBarcode
            // 
            this.buttonShowAllBarcode.BackColor = System.Drawing.Color.GreenYellow;
            this.buttonShowAllBarcode.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowAllBarcode.Location = new System.Drawing.Point(806, 25);
            this.buttonShowAllBarcode.Name = "buttonShowAllBarcode";
            this.buttonShowAllBarcode.Size = new System.Drawing.Size(94, 31);
            this.buttonShowAllBarcode.TabIndex = 4;
            this.buttonShowAllBarcode.Text = "Show All";
            this.buttonShowAllBarcode.UseVisualStyleBackColor = false;
            this.buttonShowAllBarcode.Click += new System.EventHandler(this.buttonShowAllBarcode_Click);
            // 
            // buttonShowBarcode
            // 
            this.buttonShowBarcode.BackColor = System.Drawing.Color.Yellow;
            this.buttonShowBarcode.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowBarcode.Location = new System.Drawing.Point(691, 25);
            this.buttonShowBarcode.Name = "buttonShowBarcode";
            this.buttonShowBarcode.Size = new System.Drawing.Size(95, 31);
            this.buttonShowBarcode.TabIndex = 3;
            this.buttonShowBarcode.Text = "Show";
            this.buttonShowBarcode.UseVisualStyleBackColor = false;
            this.buttonShowBarcode.Click += new System.EventHandler(this.buttonShowBarcode_Click);
            // 
            // textBoxNumberOfCopies
            // 
            this.textBoxNumberOfCopies.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNumberOfCopies.Location = new System.Drawing.Point(506, 32);
            this.textBoxNumberOfCopies.Name = "textBoxNumberOfCopies";
            this.textBoxNumberOfCopies.Size = new System.Drawing.Size(170, 22);
            this.textBoxNumberOfCopies.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(393, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Number of Copy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(15, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Product Name / Code";
            this.label2.UseMnemonic = false;
            // 
            // textBoxProductCode
            // 
            this.textBoxProductCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProductCode.Location = new System.Drawing.Point(160, 33);
            this.textBoxProductCode.Name = "textBoxProductCode";
            this.textBoxProductCode.Size = new System.Drawing.Size(227, 22);
            this.textBoxProductCode.TabIndex = 1;
            this.textBoxProductCode.TextChanged += new System.EventHandler(this.textBoxProductCode_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxFProductCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonShowAllBarcode);
            this.groupBox1.Controls.Add(this.textBoxProductCode);
            this.groupBox1.Controls.Add(this.buttonShowBarcode);
            this.groupBox1.Controls.Add(this.textBoxNumberOfCopies);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1061, 70);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Barcode Generate";
            // 
            // textBoxFProductCode
            // 
            this.textBoxFProductCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFProductCode.Location = new System.Drawing.Point(921, 30);
            this.textBoxFProductCode.Name = "textBoxFProductCode";
            this.textBoxFProductCode.Size = new System.Drawing.Size(82, 22);
            this.textBoxFProductCode.TabIndex = 7;
            this.textBoxFProductCode.Visible = false;
            // 
            // BarcodeGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 698);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.crystalReportViewer1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1080, 737);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1080, 737);
            this.Name = "BarcodeGenerate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barcode Generate";
            this.Load += new System.EventHandler(this.BarcodeGenerate_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button buttonShowAllBarcode;
        private System.Windows.Forms.Button buttonShowBarcode;
        private System.Windows.Forms.TextBox textBoxNumberOfCopies;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxProductCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxFProductCode;
    }
}