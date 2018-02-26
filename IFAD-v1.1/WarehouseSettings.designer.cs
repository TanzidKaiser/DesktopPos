namespace IFAD_v1._1
{
    partial class WarehouseSettings
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
            this.AddWarehouseButton = new System.Windows.Forms.Button();
            this.textBoxAddWarehouse = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonAddRack = new System.Windows.Forms.Button();
            this.textBoxAddRack = new System.Windows.Forms.TextBox();
            this.comboBoxWarehouseNameInRack = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panelAddCategory = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxRackNameInCell = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonAddCell = new System.Windows.Forms.Button();
            this.textBoxAddCell = new System.Windows.Forms.TextBox();
            this.comboBoxWarehouseNameInCell = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxAdd = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxCellID = new System.Windows.Forms.TextBox();
            this.textBoxRackID = new System.Windows.Forms.TextBox();
            this.textBoxWarehouseID = new System.Windows.Forms.TextBox();
            this.buttonUpdateCell = new System.Windows.Forms.Button();
            this.textBoxCell = new System.Windows.Forms.TextBox();
            this.buttonUpdateRack = new System.Windows.Forms.Button();
            this.textBoxRack = new System.Windows.Forms.TextBox();
            this.buttonUpdateWarehouse = new System.Windows.Forms.Button();
            this.textBoxWarehouse = new System.Windows.Forms.TextBox();
            this.comboBoxEditCellRack = new System.Windows.Forms.ComboBox();
            this.comboBoxEditCellWarehouse = new System.Windows.Forms.ComboBox();
            this.dataGridViewCell = new System.Windows.Forms.DataGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxEditRackWarehouse = new System.Windows.Forms.ComboBox();
            this.dataGridViewRack = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridViewWarehouse = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageAdd = new System.Windows.Forms.TabPage();
            this.tabPageEdit = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panelAddCategory.SuspendLayout();
            this.groupBoxAdd.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCell)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRack)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarehouse)).BeginInit();
            this.panel6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageAdd.SuspendLayout();
            this.tabPageEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddWarehouseButton
            // 
            this.AddWarehouseButton.BackColor = System.Drawing.Color.Thistle;
            this.AddWarehouseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddWarehouseButton.ForeColor = System.Drawing.Color.Navy;
            this.AddWarehouseButton.Location = new System.Drawing.Point(21, 63);
            this.AddWarehouseButton.Name = "AddWarehouseButton";
            this.AddWarehouseButton.Size = new System.Drawing.Size(213, 28);
            this.AddWarehouseButton.TabIndex = 0;
            this.AddWarehouseButton.Text = "Add";
            this.AddWarehouseButton.UseVisualStyleBackColor = false;
            this.AddWarehouseButton.Click += new System.EventHandler(this.AddWarehouseButton_Click);
            // 
            // textBoxAddWarehouse
            // 
            this.textBoxAddWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.textBoxAddWarehouse.Location = new System.Drawing.Point(21, 34);
            this.textBoxAddWarehouse.Name = "textBoxAddWarehouse";
            this.textBoxAddWarehouse.Size = new System.Drawing.Size(212, 22);
            this.textBoxAddWarehouse.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(20, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Add Warehouse Name";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.AddWarehouseButton);
            this.panel1.Controls.Add(this.textBoxAddWarehouse);
            this.panel1.Location = new System.Drawing.Point(6, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 116);
            this.panel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CadetBlue;
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(6, 21);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(257, 39);
            this.panel3.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Yellow;
            this.label8.Location = new System.Drawing.Point(1, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 23);
            this.label8.TabIndex = 12;
            this.label8.Text = "1. ADD WAREHOUSE";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.CadetBlue;
            this.panel4.Controls.Add(this.label15);
            this.panel4.Location = new System.Drawing.Point(6, 182);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(257, 39);
            this.panel4.TabIndex = 33;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Yellow;
            this.label15.Location = new System.Drawing.Point(4, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 23);
            this.label15.TabIndex = 12;
            this.label15.Text = "2. ADD RACK";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.buttonAddRack);
            this.panel2.Controls.Add(this.textBoxAddRack);
            this.panel2.Controls.Add(this.comboBoxWarehouseNameInRack);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(6, 221);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(257, 204);
            this.panel2.TabIndex = 32;
            // 
            // buttonAddRack
            // 
            this.buttonAddRack.BackColor = System.Drawing.Color.Thistle;
            this.buttonAddRack.ForeColor = System.Drawing.Color.Navy;
            this.buttonAddRack.Location = new System.Drawing.Point(16, 150);
            this.buttonAddRack.Name = "buttonAddRack";
            this.buttonAddRack.Size = new System.Drawing.Size(217, 28);
            this.buttonAddRack.TabIndex = 9;
            this.buttonAddRack.Text = "ADD";
            this.buttonAddRack.UseVisualStyleBackColor = false;
            this.buttonAddRack.Click += new System.EventHandler(this.buttonAddRack_Click);
            // 
            // textBoxAddRack
            // 
            this.textBoxAddRack.Location = new System.Drawing.Point(16, 112);
            this.textBoxAddRack.Name = "textBoxAddRack";
            this.textBoxAddRack.Size = new System.Drawing.Size(217, 22);
            this.textBoxAddRack.TabIndex = 7;
            // 
            // comboBoxWarehouseNameInRack
            // 
            this.comboBoxWarehouseNameInRack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWarehouseNameInRack.FormattingEnabled = true;
            this.comboBoxWarehouseNameInRack.Location = new System.Drawing.Point(16, 52);
            this.comboBoxWarehouseNameInRack.Name = "comboBoxWarehouseNameInRack";
            this.comboBoxWarehouseNameInRack.Size = new System.Drawing.Size(218, 24);
            this.comboBoxWarehouseNameInRack.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(16, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Add Rack";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(13, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Select Warehouse";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.CadetBlue;
            this.panel5.Controls.Add(this.label7);
            this.panel5.Location = new System.Drawing.Point(269, 21);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(260, 39);
            this.panel5.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Yellow;
            this.label7.Location = new System.Drawing.Point(6, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 23);
            this.label7.TabIndex = 12;
            this.label7.Text = "3. ADD CELL";
            // 
            // panelAddCategory
            // 
            this.panelAddCategory.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelAddCategory.Controls.Add(this.label5);
            this.panelAddCategory.Controls.Add(this.comboBoxRackNameInCell);
            this.panelAddCategory.Controls.Add(this.label6);
            this.panelAddCategory.Controls.Add(this.buttonAddCell);
            this.panelAddCategory.Controls.Add(this.textBoxAddCell);
            this.panelAddCategory.Controls.Add(this.comboBoxWarehouseNameInCell);
            this.panelAddCategory.Controls.Add(this.label4);
            this.panelAddCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelAddCategory.Location = new System.Drawing.Point(269, 60);
            this.panelAddCategory.Name = "panelAddCategory";
            this.panelAddCategory.Size = new System.Drawing.Size(260, 365);
            this.panelAddCategory.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label5.Location = new System.Drawing.Point(13, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Select Warehouse";
            // 
            // comboBoxRackNameInCell
            // 
            this.comboBoxRackNameInCell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRackNameInCell.FormattingEnabled = true;
            this.comboBoxRackNameInCell.Location = new System.Drawing.Point(15, 83);
            this.comboBoxRackNameInCell.Name = "comboBoxRackNameInCell";
            this.comboBoxRackNameInCell.Size = new System.Drawing.Size(225, 24);
            this.comboBoxRackNameInCell.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(14, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Select Rack";
            // 
            // buttonAddCell
            // 
            this.buttonAddCell.BackColor = System.Drawing.Color.Thistle;
            this.buttonAddCell.ForeColor = System.Drawing.Color.Navy;
            this.buttonAddCell.Location = new System.Drawing.Point(17, 178);
            this.buttonAddCell.Name = "buttonAddCell";
            this.buttonAddCell.Size = new System.Drawing.Size(224, 28);
            this.buttonAddCell.TabIndex = 14;
            this.buttonAddCell.Text = "ADD";
            this.buttonAddCell.UseVisualStyleBackColor = false;
            this.buttonAddCell.Click += new System.EventHandler(this.buttonAddCell_Click);
            // 
            // textBoxAddCell
            // 
            this.textBoxAddCell.Location = new System.Drawing.Point(16, 140);
            this.textBoxAddCell.Name = "textBoxAddCell";
            this.textBoxAddCell.Size = new System.Drawing.Size(225, 22);
            this.textBoxAddCell.TabIndex = 10;
            // 
            // comboBoxWarehouseNameInCell
            // 
            this.comboBoxWarehouseNameInCell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWarehouseNameInCell.FormattingEnabled = true;
            this.comboBoxWarehouseNameInCell.Location = new System.Drawing.Point(15, 32);
            this.comboBoxWarehouseNameInCell.Name = "comboBoxWarehouseNameInCell";
            this.comboBoxWarehouseNameInCell.Size = new System.Drawing.Size(225, 24);
            this.comboBoxWarehouseNameInCell.TabIndex = 13;
            this.comboBoxWarehouseNameInCell.SelectedIndexChanged += new System.EventHandler(this.comboBoxWarehouseNameInCell_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(16, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Add New Cell";
            // 
            // groupBoxAdd
            // 
            this.groupBoxAdd.Controls.Add(this.panel3);
            this.groupBoxAdd.Controls.Add(this.panel1);
            this.groupBoxAdd.Controls.Add(this.panelAddCategory);
            this.groupBoxAdd.Controls.Add(this.panel5);
            this.groupBoxAdd.Controls.Add(this.panel4);
            this.groupBoxAdd.Controls.Add(this.panel2);
            this.groupBoxAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAdd.Location = new System.Drawing.Point(162, 25);
            this.groupBoxAdd.Name = "groupBoxAdd";
            this.groupBoxAdd.Size = new System.Drawing.Size(535, 432);
            this.groupBoxAdd.TabIndex = 36;
            this.groupBoxAdd.TabStop = false;
            this.groupBoxAdd.Text = "&ADD Warehouse";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxCellID);
            this.groupBox2.Controls.Add(this.textBoxRackID);
            this.groupBox2.Controls.Add(this.textBoxWarehouseID);
            this.groupBox2.Controls.Add(this.buttonUpdateCell);
            this.groupBox2.Controls.Add(this.textBoxCell);
            this.groupBox2.Controls.Add(this.buttonUpdateRack);
            this.groupBox2.Controls.Add(this.textBoxRack);
            this.groupBox2.Controls.Add(this.buttonUpdateWarehouse);
            this.groupBox2.Controls.Add(this.textBoxWarehouse);
            this.groupBox2.Controls.Add(this.comboBoxEditCellRack);
            this.groupBox2.Controls.Add(this.comboBoxEditCellWarehouse);
            this.groupBox2.Controls.Add(this.dataGridViewCell);
            this.groupBox2.Controls.Add(this.panel8);
            this.groupBox2.Controls.Add(this.comboBoxEditRackWarehouse);
            this.groupBox2.Controls.Add(this.dataGridViewRack);
            this.groupBox2.Controls.Add(this.panel7);
            this.groupBox2.Controls.Add(this.dataGridViewWarehouse);
            this.groupBox2.Controls.Add(this.panel6);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(13, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(839, 431);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "&EDIT Warehouse";
            // 
            // textBoxCellID
            // 
            this.textBoxCellID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCellID.Location = new System.Drawing.Point(691, 404);
            this.textBoxCellID.Name = "textBoxCellID";
            this.textBoxCellID.Size = new System.Drawing.Size(51, 20);
            this.textBoxCellID.TabIndex = 49;
            this.textBoxCellID.Visible = false;
            // 
            // textBoxRackID
            // 
            this.textBoxRackID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRackID.Location = new System.Drawing.Point(348, 404);
            this.textBoxRackID.Name = "textBoxRackID";
            this.textBoxRackID.Size = new System.Drawing.Size(51, 20);
            this.textBoxRackID.TabIndex = 48;
            this.textBoxRackID.Visible = false;
            // 
            // textBoxWarehouseID
            // 
            this.textBoxWarehouseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxWarehouseID.Location = new System.Drawing.Point(69, 404);
            this.textBoxWarehouseID.Name = "textBoxWarehouseID";
            this.textBoxWarehouseID.Size = new System.Drawing.Size(51, 20);
            this.textBoxWarehouseID.TabIndex = 47;
            this.textBoxWarehouseID.Visible = false;
            // 
            // buttonUpdateCell
            // 
            this.buttonUpdateCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonUpdateCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdateCell.ForeColor = System.Drawing.Color.Yellow;
            this.buttonUpdateCell.Location = new System.Drawing.Point(561, 364);
            this.buttonUpdateCell.Name = "buttonUpdateCell";
            this.buttonUpdateCell.Size = new System.Drawing.Size(269, 38);
            this.buttonUpdateCell.TabIndex = 46;
            this.buttonUpdateCell.Text = "Update Cell";
            this.buttonUpdateCell.UseVisualStyleBackColor = false;
            this.buttonUpdateCell.Click += new System.EventHandler(this.buttonUpdateCell_Click);
            // 
            // textBoxCell
            // 
            this.textBoxCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBoxCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCell.Location = new System.Drawing.Point(561, 336);
            this.textBoxCell.Name = "textBoxCell";
            this.textBoxCell.Size = new System.Drawing.Size(269, 24);
            this.textBoxCell.TabIndex = 45;
            // 
            // buttonUpdateRack
            // 
            this.buttonUpdateRack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonUpdateRack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdateRack.ForeColor = System.Drawing.Color.Yellow;
            this.buttonUpdateRack.Location = new System.Drawing.Point(280, 364);
            this.buttonUpdateRack.Name = "buttonUpdateRack";
            this.buttonUpdateRack.Size = new System.Drawing.Size(274, 38);
            this.buttonUpdateRack.TabIndex = 44;
            this.buttonUpdateRack.Text = "Update Rack";
            this.buttonUpdateRack.UseVisualStyleBackColor = false;
            this.buttonUpdateRack.Click += new System.EventHandler(this.buttonUpdateRack_Click);
            // 
            // textBoxRack
            // 
            this.textBoxRack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBoxRack.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRack.Location = new System.Drawing.Point(280, 336);
            this.textBoxRack.Name = "textBoxRack";
            this.textBoxRack.Size = new System.Drawing.Size(274, 24);
            this.textBoxRack.TabIndex = 43;
            // 
            // buttonUpdateWarehouse
            // 
            this.buttonUpdateWarehouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonUpdateWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdateWarehouse.ForeColor = System.Drawing.Color.Yellow;
            this.buttonUpdateWarehouse.Location = new System.Drawing.Point(4, 363);
            this.buttonUpdateWarehouse.Name = "buttonUpdateWarehouse";
            this.buttonUpdateWarehouse.Size = new System.Drawing.Size(273, 38);
            this.buttonUpdateWarehouse.TabIndex = 42;
            this.buttonUpdateWarehouse.Text = "Update Warehouse";
            this.buttonUpdateWarehouse.UseVisualStyleBackColor = false;
            this.buttonUpdateWarehouse.Click += new System.EventHandler(this.buttonUpdateWarehouse_Click);
            // 
            // textBoxWarehouse
            // 
            this.textBoxWarehouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBoxWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxWarehouse.Location = new System.Drawing.Point(4, 336);
            this.textBoxWarehouse.Name = "textBoxWarehouse";
            this.textBoxWarehouse.Size = new System.Drawing.Size(273, 24);
            this.textBoxWarehouse.TabIndex = 41;
            // 
            // comboBoxEditCellRack
            // 
            this.comboBoxEditCellRack.AllowDrop = true;
            this.comboBoxEditCellRack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEditCellRack.FormattingEnabled = true;
            this.comboBoxEditCellRack.Location = new System.Drawing.Point(560, 89);
            this.comboBoxEditCellRack.Name = "comboBoxEditCellRack";
            this.comboBoxEditCellRack.Size = new System.Drawing.Size(269, 24);
            this.comboBoxEditCellRack.TabIndex = 40;
            this.comboBoxEditCellRack.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditCellRack_SelectedIndexChanged);
            // 
            // comboBoxEditCellWarehouse
            // 
            this.comboBoxEditCellWarehouse.AllowDrop = true;
            this.comboBoxEditCellWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEditCellWarehouse.FormattingEnabled = true;
            this.comboBoxEditCellWarehouse.Location = new System.Drawing.Point(560, 61);
            this.comboBoxEditCellWarehouse.Name = "comboBoxEditCellWarehouse";
            this.comboBoxEditCellWarehouse.Size = new System.Drawing.Size(269, 24);
            this.comboBoxEditCellWarehouse.TabIndex = 39;
            this.comboBoxEditCellWarehouse.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditCellWarehouse_SelectedIndexChanged);
            // 
            // dataGridViewCell
            // 
            this.dataGridViewCell.AllowUserToAddRows = false;
            this.dataGridViewCell.AllowUserToDeleteRows = false;
            this.dataGridViewCell.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCell.Location = new System.Drawing.Point(561, 115);
            this.dataGridViewCell.Name = "dataGridViewCell";
            this.dataGridViewCell.ReadOnly = true;
            this.dataGridViewCell.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCell.Size = new System.Drawing.Size(268, 215);
            this.dataGridViewCell.TabIndex = 38;
            this.dataGridViewCell.DoubleClick += new System.EventHandler(this.dataGridViewCell_DoubleClick);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel8.Controls.Add(this.label11);
            this.panel8.Location = new System.Drawing.Point(561, 19);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(269, 39);
            this.panel8.TabIndex = 37;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Yellow;
            this.label11.Location = new System.Drawing.Point(1, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 23);
            this.label11.TabIndex = 12;
            this.label11.Text = "3. EDIT CELL";
            // 
            // comboBoxEditRackWarehouse
            // 
            this.comboBoxEditRackWarehouse.AllowDrop = true;
            this.comboBoxEditRackWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEditRackWarehouse.FormattingEnabled = true;
            this.comboBoxEditRackWarehouse.Location = new System.Drawing.Point(280, 60);
            this.comboBoxEditRackWarehouse.Name = "comboBoxEditRackWarehouse";
            this.comboBoxEditRackWarehouse.Size = new System.Drawing.Size(274, 24);
            this.comboBoxEditRackWarehouse.TabIndex = 36;
            this.comboBoxEditRackWarehouse.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditRackWarehouse_SelectedIndexChanged);
            // 
            // dataGridViewRack
            // 
            this.dataGridViewRack.AllowUserToAddRows = false;
            this.dataGridViewRack.AllowUserToDeleteRows = false;
            this.dataGridViewRack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRack.Location = new System.Drawing.Point(281, 86);
            this.dataGridViewRack.Name = "dataGridViewRack";
            this.dataGridViewRack.ReadOnly = true;
            this.dataGridViewRack.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRack.Size = new System.Drawing.Size(273, 244);
            this.dataGridViewRack.TabIndex = 35;
            this.dataGridViewRack.DoubleClick += new System.EventHandler(this.dataGridViewRack_DoubleClick);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel7.Controls.Add(this.label10);
            this.panel7.Location = new System.Drawing.Point(281, 18);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(274, 39);
            this.panel7.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Yellow;
            this.label10.Location = new System.Drawing.Point(1, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 23);
            this.label10.TabIndex = 12;
            this.label10.Text = "2. EDIT RACK";
            // 
            // dataGridViewWarehouse
            // 
            this.dataGridViewWarehouse.AllowUserToAddRows = false;
            this.dataGridViewWarehouse.AllowUserToDeleteRows = false;
            this.dataGridViewWarehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWarehouse.Location = new System.Drawing.Point(4, 57);
            this.dataGridViewWarehouse.Name = "dataGridViewWarehouse";
            this.dataGridViewWarehouse.ReadOnly = true;
            this.dataGridViewWarehouse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewWarehouse.Size = new System.Drawing.Size(272, 273);
            this.dataGridViewWarehouse.TabIndex = 33;
            this.dataGridViewWarehouse.DoubleClick += new System.EventHandler(this.dataGridViewWarehouse_DoubleClick);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel6.Controls.Add(this.label9);
            this.panel6.Location = new System.Drawing.Point(4, 18);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(273, 39);
            this.panel6.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Yellow;
            this.label9.Location = new System.Drawing.Point(1, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(167, 23);
            this.label9.TabIndex = 12;
            this.label9.Text = "1. EDIT WAREHOUSE";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageAdd);
            this.tabControl1.Controls.Add(this.tabPageEdit);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(866, 528);
            this.tabControl1.TabIndex = 38;
            // 
            // tabPageAdd
            // 
            this.tabPageAdd.Controls.Add(this.groupBoxAdd);
            this.tabPageAdd.Location = new System.Drawing.Point(4, 27);
            this.tabPageAdd.Name = "tabPageAdd";
            this.tabPageAdd.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdd.Size = new System.Drawing.Size(858, 497);
            this.tabPageAdd.TabIndex = 0;
            this.tabPageAdd.Text = "Warehouse ADD";
            this.tabPageAdd.UseVisualStyleBackColor = true;
            // 
            // tabPageEdit
            // 
            this.tabPageEdit.Controls.Add(this.groupBox2);
            this.tabPageEdit.Location = new System.Drawing.Point(4, 27);
            this.tabPageEdit.Name = "tabPageEdit";
            this.tabPageEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEdit.Size = new System.Drawing.Size(858, 497);
            this.tabPageEdit.TabIndex = 1;
            this.tabPageEdit.Text = "Warehouse Edit";
            this.tabPageEdit.UseVisualStyleBackColor = true;
            // 
            // WarehouseSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(865, 525);
            this.Controls.Add(this.tabControl1);
            this.Name = "WarehouseSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warehouse Settings";
            this.Load += new System.EventHandler(this.WarehouseSettings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panelAddCategory.ResumeLayout(false);
            this.panelAddCategory.PerformLayout();
            this.groupBoxAdd.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCell)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRack)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWarehouse)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageAdd.ResumeLayout(false);
            this.tabPageEdit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddWarehouseButton;
        private System.Windows.Forms.TextBox textBoxAddWarehouse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonAddRack;
        private System.Windows.Forms.TextBox textBoxAddRack;
        private System.Windows.Forms.ComboBox comboBoxWarehouseNameInRack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelAddCategory;
        private System.Windows.Forms.ComboBox comboBoxRackNameInCell;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonAddCell;
        private System.Windows.Forms.TextBox textBoxAddCell;
        private System.Windows.Forms.ComboBox comboBoxWarehouseNameInCell;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBoxAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewRack;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridViewWarehouse;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxEditRackWarehouse;
        private System.Windows.Forms.ComboBox comboBoxEditCellRack;
        private System.Windows.Forms.ComboBox comboBoxEditCellWarehouse;
        private System.Windows.Forms.DataGridView dataGridViewCell;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonUpdateWarehouse;
        private System.Windows.Forms.TextBox textBoxWarehouse;
        private System.Windows.Forms.TextBox textBoxWarehouseID;
        private System.Windows.Forms.Button buttonUpdateCell;
        private System.Windows.Forms.TextBox textBoxCell;
        private System.Windows.Forms.Button buttonUpdateRack;
        private System.Windows.Forms.TextBox textBoxRack;
        private System.Windows.Forms.TextBox textBoxCellID;
        private System.Windows.Forms.TextBox textBoxRackID;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageAdd;
        private System.Windows.Forms.TabPage tabPageEdit;
    }
}