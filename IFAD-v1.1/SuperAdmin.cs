using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFAD_v1._1
{
    public partial class SuperAdmin : Form
    {
        public SuperAdmin()
        {
            InitializeComponent();
        }
        string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
        string sql = "";
        private void proHidden()
        {
            progressBar2.Visible = false;           
            label3.Visible = false;
        }
        private void SuperAdmin_Load(object sender, EventArgs e)
        {
            buttonRestore.Enabled = false;
            proHidden();
        }

        private void buttonRestorePath_Click(object sender, EventArgs e)
        {
            proHidden();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Backup Files(*.bak)|*.bak|All Files(*.*)|*.*";
            ofd.FilterIndex = 0;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxDatabaseRestorePath.Text = ofd.FileName;
                buttonRestore.Enabled = true;
            }

        }
        private void UpdateAppConfig()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["PosConString"].ConnectionString = "SERVER = "+textBoxServerName.Text+";"+" DATABASE =pos;"+ "user id = "+textBoxUserName.Text+";"+ "PASSWORD = "+textBoxPassword.Text;
            connectionStringsSection.ConnectionStrings["cryServer"].ConnectionString = textBoxServerName.Text;
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
        }
        private void buttonRestore_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar2.Visible = true;
                label3.Visible = true;
                SqlConnection conn = new SqlConnection(conStr);
                conn.Open();
                sql = @"USE master;";
                sql += @"ALTER DATABASE pos SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                sql += @"RESTORE DATABASE pos FROM DISK = '" + textBoxDatabaseRestorePath.Text + "' WITH REPLACE;";
                sql += @"ALTER DATABASE pos SET Multi_User;";
                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();

                backgroundWorker2.RunWorkerAsync();
                // MessageBox.Show("Restore Database Successfully....!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            int i;
            for (i = 1; i <= 100; i++)
            {
                backgroundWorker2.ReportProgress(i);
            }
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar2.Value = e.ProgressPercentage;
            label3.Text = e.ProgressPercentage.ToString() + " %";
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Restore Database Successfully....!!!");
        }

        private void buttonCreateDB_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxServerName.Text=="")
                {
                    MessageBox.Show("Server Name is not Empty...");
                }
                else if (textBoxUserName.Text=="")
                {
                    MessageBox.Show("User Name is not Empty...");
                }
                else if (textBoxPassword.Text=="")
                {
                    MessageBox.Show("Password is not Empty...");
                }
                else
                {
                    string conStr = "SERVER = ";
                    conStr += textBoxServerName.Text+";" ;
                    conStr += "DATABASE =master;";
                    conStr += "user id = ";
                    conStr += textBoxUserName.Text+";";
                    conStr += "PASSWORD = ";
                    conStr += textBoxPassword.Text;
                    SqlConnection connection = new SqlConnection(conStr);
                    connection.Open();
                    //string query = @"USE master;";
                    //query += @"DROP DATABASE pos;";
                    string query = "CREATE DATABASE pos";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    UpdateAppConfig();
                    textBoxServerName.Text = textBoxUserName.Text = textBoxPassword.Text="";
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
