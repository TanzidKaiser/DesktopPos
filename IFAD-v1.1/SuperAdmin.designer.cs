namespace IFAD_v1._1
{
    partial class SuperAdmin
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.buttonRestorePath = new System.Windows.Forms.Button();
            this.textBoxDatabaseRestorePath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonCreateDB = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxServerName = new System.Windows.Forms.TextBox();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.progressBar2);
            this.groupBox4.Controls.Add(this.buttonRestore);
            this.groupBox4.Controls.Add(this.buttonRestorePath);
            this.groupBox4.Controls.Add(this.textBoxDatabaseRestorePath);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(571, 401);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Database Backup";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(475, 331);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 17);
            this.label3.TabIndex = 10;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(95, 334);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(367, 13);
            this.progressBar2.TabIndex = 11;
            // 
            // buttonRestore
            // 
            this.buttonRestore.Location = new System.Drawing.Point(473, 291);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(75, 30);
            this.buttonRestore.TabIndex = 7;
            this.buttonRestore.Text = "Restore";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
            // 
            // buttonRestorePath
            // 
            this.buttonRestorePath.Location = new System.Drawing.Point(387, 291);
            this.buttonRestorePath.Name = "buttonRestorePath";
            this.buttonRestorePath.Size = new System.Drawing.Size(75, 30);
            this.buttonRestorePath.TabIndex = 6;
            this.buttonRestorePath.Text = "Browse";
            this.buttonRestorePath.UseVisualStyleBackColor = true;
            this.buttonRestorePath.Click += new System.EventHandler(this.buttonRestorePath_Click);
            // 
            // textBoxDatabaseRestorePath
            // 
            this.textBoxDatabaseRestorePath.Location = new System.Drawing.Point(95, 295);
            this.textBoxDatabaseRestorePath.Name = "textBoxDatabaseRestorePath";
            this.textBoxDatabaseRestorePath.ReadOnly = true;
            this.textBoxDatabaseRestorePath.Size = new System.Drawing.Size(264, 25);
            this.textBoxDatabaseRestorePath.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Backup Path";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonCreateDB);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxUserName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxServerName);
            this.groupBox1.Location = new System.Drawing.Point(107, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 213);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "&Create Database";
            // 
            // buttonCreateDB
            // 
            this.buttonCreateDB.Location = new System.Drawing.Point(133, 167);
            this.buttonCreateDB.Name = "buttonCreateDB";
            this.buttonCreateDB.Size = new System.Drawing.Size(184, 30);
            this.buttonCreateDB.TabIndex = 24;
            this.buttonCreateDB.Text = "&Create DataBase";
            this.buttonCreateDB.UseVisualStyleBackColor = true;
            this.buttonCreateDB.Click += new System.EventHandler(this.buttonCreateDB_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "&Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(133, 124);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(184, 25);
            this.textBoxPassword.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "&User Name";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(133, 82);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.PasswordChar = '*';
            this.textBoxUserName.Size = new System.Drawing.Size(184, 25);
            this.textBoxUserName.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "&Server Name";
            // 
            // textBoxServerName
            // 
            this.textBoxServerName.Location = new System.Drawing.Point(133, 42);
            this.textBoxServerName.Name = "textBoxServerName";
            this.textBoxServerName.Size = new System.Drawing.Size(184, 25);
            this.textBoxServerName.TabIndex = 18;
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // SuperAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 425);
            this.Controls.Add(this.groupBox4);
            this.Name = "SuperAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Admin";
            this.Load += new System.EventHandler(this.SuperAdmin_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Button buttonRestore;
        private System.Windows.Forms.Button buttonRestorePath;
        private System.Windows.Forms.TextBox textBoxDatabaseRestorePath;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonCreateDB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxServerName;
    }
}