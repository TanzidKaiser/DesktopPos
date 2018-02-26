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
    public partial class ViewUser : Form
    {
        public ViewUser()
        {
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
        private void DataGrid()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Date, Name, Address, Mobile, Email, UserName, Password FROM [user] WHERE UserName <> 'admin'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewAllUser.DataSource = dt;
            con.Close();
            //dataGridViewAllUser.Columns["Password"].Visible = false;
        }

        private void ViewUser_Load(object sender, EventArgs e)
        {
            DataGrid();
        }

        private void dataGridViewAllUser_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBoxUserName.Text = textBoxPassword.Text = "";
            textBoxUserName.Text = dataGridViewAllUser.SelectedRows[0].Cells[5].Value.ToString();
            textBoxPassword.Text = dataGridViewAllUser.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "")
            {
                MessageBox.Show("Password Field Is Not Empty...!!!!");
            }
            if (textBoxUserName.Text == "")
            {
                MessageBox.Show("Please Select a User in DataGrid...!!");
            }
            else
            {
                try
                {
                    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
                    string query1 = "UPDATE [user] SET Password = '" + textBoxPassword.Text + "' WHERE UserName = '" + textBoxUserName.Text + "'";
                    SqlCommand command1 = new SqlCommand(query1, con1);
                    con1.Open();
                    int rowEffict1 = command1.ExecuteNonQuery();
                    con1.Close();
                    if (rowEffict1 > 0)
                    {
                        MessageBox.Show("Password Changed Successfully...!!!!");
                        DataGrid();
                        textBoxUserName.Text = textBoxPassword.Text = "";
                    }
                }
                catch (Exception ss)
                {
                    MessageBox.Show(ss.Message);
                }
            }
        }
        string conStrs = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
        private int GetUserID(string UserName)
        {
            int i = 0;

            SqlConnection connections = new SqlConnection(conStrs);
            string querys = "SELECT ID FROM [user] WHERE UserName='" + UserName + "'";
            SqlCommand commands = new SqlCommand(querys, connections);
            connections.Open();
            SqlDataReader readers = commands.ExecuteReader();
            while (readers.Read())
            {
                i = Convert.ToInt32(readers["ID"]);
            }
            readers.Close();
            connections.Close();
            return i;
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure, you will Delete this User?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return;
            }
            else
            {

                int UserID = GetUserID(textBoxUserName.Text);
                if (textBoxUserName.Text == "")
                {
                    MessageBox.Show("Please Select a User in DataGrid...!!");
                }
                else
                {
                    try
                    {
                        SqlConnection connection1 = new SqlConnection(conStrs);
                        string query1 = @"DELETE FROM [user] WHERE  ID = '" + UserID + "'; ";
                        query1 += @"DELETE FROM [UserAccessArea] WHERE  UserID = '" + UserID + "'; ";
                        SqlCommand command1 = new SqlCommand(query1, connection1);
                        connection1.Open();
                        int rowEffict1 = command1.ExecuteNonQuery();
                        if (rowEffict1 > 1)
                        {
                            MessageBox.Show("User Delete Successfully...!!!");
                            DataGrid();
                            textBoxUserName.Text = textBoxPassword.Text = "";

                        }
                        connection1.Close();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Please Select a Product in DataGrid...!!");
                    }
                }
            }
        }

        private void buttonEditUser_Click(object sender, EventArgs e)
        {
            AddUserEdit aue = new AddUserEdit();
            aue.Show();
        }

        private void dataGridViewAllUser_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (e.Value != null)
                {
                    e.Value = new string('*', e.Value.ToString().Length);
                }
            }
        }
    }
}
