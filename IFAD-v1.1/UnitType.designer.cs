namespace IFAD_v1._1
{
    partial class UnitType
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonAddUnit = new System.Windows.Forms.Button();
            this.textBoxUnitName = new System.Windows.Forms.TextBox();
            this.Address = new System.Windows.Forms.Label();
            this.unitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.purchasedetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonUpdateUnit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxUnitID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNewUnitName = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewViewUnit = new System.Windows.Forms.DataGridView();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchasedetailsBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewViewUnit)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CadetBlue;
            this.panel3.Controls.Add(this.label17);
            this.panel3.Location = new System.Drawing.Point(0, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(527, 36);
            this.panel3.TabIndex = 34;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Yellow;
            this.label17.Location = new System.Drawing.Point(213, 4);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(109, 25);
            this.label17.TabIndex = 0;
            this.label17.Text = "Unit Details";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.buttonAddUnit);
            this.panel2.Controls.Add(this.textBoxUnitName);
            this.panel2.Controls.Add(this.Address);
            this.panel2.Location = new System.Drawing.Point(0, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 119);
            this.panel2.TabIndex = 35;
            // 
            // buttonAddUnit
            // 
            this.buttonAddUnit.BackColor = System.Drawing.Color.DarkGreen;
            this.buttonAddUnit.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddUnit.ForeColor = System.Drawing.Color.Thistle;
            this.buttonAddUnit.Location = new System.Drawing.Point(105, 65);
            this.buttonAddUnit.Name = "buttonAddUnit";
            this.buttonAddUnit.Size = new System.Drawing.Size(142, 34);
            this.buttonAddUnit.TabIndex = 5;
            this.buttonAddUnit.Text = "Add";
            this.buttonAddUnit.UseVisualStyleBackColor = false;
            this.buttonAddUnit.Click += new System.EventHandler(this.buttonAddUnit_Click);
            // 
            // textBoxUnitName
            // 
            this.textBoxUnitName.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUnitName.Location = new System.Drawing.Point(105, 33);
            this.textBoxUnitName.Name = "textBoxUnitName";
            this.textBoxUnitName.Size = new System.Drawing.Size(142, 26);
            this.textBoxUnitName.TabIndex = 3;
            // 
            // Address
            // 
            this.Address.AutoSize = true;
            this.Address.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Address.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Address.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Address.Location = new System.Drawing.Point(32, 34);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(68, 20);
            this.Address.TabIndex = 2;
            this.Address.Text = "Unit Name";
            // 
            // unitBindingSource
            // 
            this.unitBindingSource.DataMember = "unit";
            // 
            // purchasedetailsBindingSource
            // 
            this.purchasedetailsBindingSource.DataMember = "purchase_details";
            // 
            // buttonUpdateUnit
            // 
            this.buttonUpdateUnit.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonUpdateUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdateUnit.ForeColor = System.Drawing.Color.LavenderBlush;
            this.buttonUpdateUnit.Location = new System.Drawing.Point(127, 67);
            this.buttonUpdateUnit.Name = "buttonUpdateUnit";
            this.buttonUpdateUnit.Size = new System.Drawing.Size(121, 34);
            this.buttonUpdateUnit.TabIndex = 8;
            this.buttonUpdateUnit.Text = "Update";
            this.buttonUpdateUnit.UseVisualStyleBackColor = false;
            this.buttonUpdateUnit.Click += new System.EventHandler(this.buttonUpdateUnit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.NavajoWhite;
            this.panel1.Controls.Add(this.textBoxUnitID);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxNewUnitName);
            this.panel1.Controls.Add(this.buttonUpdateUnit);
            this.panel1.Location = new System.Drawing.Point(1, 227);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 134);
            this.panel1.TabIndex = 6;
            // 
            // textBoxUnitID
            // 
            this.textBoxUnitID.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUnitID.Location = new System.Drawing.Point(18, 67);
            this.textBoxUnitID.Name = "textBoxUnitID";
            this.textBoxUnitID.Size = new System.Drawing.Size(68, 26);
            this.textBoxUnitID.TabIndex = 11;
            this.textBoxUnitID.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(17, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "New Unit Name";
            // 
            // textBoxNewUnitName
            // 
            this.textBoxNewUnitName.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNewUnitName.Location = new System.Drawing.Point(125, 24);
            this.textBoxNewUnitName.Name = "textBoxNewUnitName";
            this.textBoxNewUnitName.Size = new System.Drawing.Size(121, 26);
            this.textBoxNewUnitName.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SlateGray;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(0, 34);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(268, 37);
            this.panel4.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(81, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Add Unit";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SlateGray;
            this.panel5.Controls.Add(this.label3);
            this.panel5.Location = new System.Drawing.Point(1, 190);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(267, 37);
            this.panel5.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(73, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Update Unit";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.SlateGray;
            this.panel6.Controls.Add(this.label5);
            this.panel6.Location = new System.Drawing.Point(274, 35);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(253, 36);
            this.panel6.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(79, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "View Unit";
            // 
            // dataGridViewViewUnit
            // 
            this.dataGridViewViewUnit.AllowUserToAddRows = false;
            this.dataGridViewViewUnit.AllowUserToDeleteRows = false;
            this.dataGridViewViewUnit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewViewUnit.Location = new System.Drawing.Point(274, 71);
            this.dataGridViewViewUnit.Name = "dataGridViewViewUnit";
            this.dataGridViewViewUnit.ReadOnly = true;
            this.dataGridViewViewUnit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewViewUnit.Size = new System.Drawing.Size(253, 290);
            this.dataGridViewViewUnit.TabIndex = 40;
            this.dataGridViewViewUnit.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewViewUnit_CellMouseDoubleClick);
            // 
            // UnitType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(528, 361);
            this.Controls.Add(this.dataGridViewViewUnit);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(544, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(544, 400);
            this.Name = "UnitType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unit Type";
            this.Load += new System.EventHandler(this.UnitType_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchasedetailsBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewViewUnit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxUnitName;
        private System.Windows.Forms.Label Address;
        private System.Windows.Forms.Button buttonAddUnit;

        private System.Windows.Forms.BindingSource purchasedetailsBindingSource;


        private System.Windows.Forms.BindingSource unitBindingSource;
        private System.Windows.Forms.Button buttonUpdateUnit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNewUnitName;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridViewViewUnit;
        private System.Windows.Forms.TextBox textBoxUnitID;
    }
}