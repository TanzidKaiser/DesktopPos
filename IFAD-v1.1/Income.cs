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
    public partial class Income : Form
    {
        public Income()
        {
            InitializeComponent();
            textBoxAmount.KeyPress += new KeyPressEventHandler(textBoxAmount_KeyPress);
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
        private void DataGrid()
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ID as 'ID', Date as 'Date', Description as 'Description', Remarks as 'Remarks', Amount as 'Amount' FROM Income";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewIncome.DataSource = dt;
            con.Close();
        }
        private void Income_Load(object sender, EventArgs e)
        {
            buttonUpdate.Enabled = false;
            textBoxID.Text = "";
            DataGrid();
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            DateTime today = DateTime.Today;
            dateTimePicker1.Value = today;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxDescription.Text == "")
                {
                    MessageBox.Show("Please fill the all field...");
                }

                else if (textBoxRemarks.Text == "")
                {
                    MessageBox.Show("Please fill the all field...");
                }
                else if (textBoxAmount.Text == "")
                {
                    MessageBox.Show("Please fill the all field...");
                }
                else
                {
                    string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
                    SqlConnection connection = new SqlConnection(conStr);
                    string query11 = "INSERT INTO Income VALUES(1,'" + dateTimePicker1.Text + "','" + textBoxDescription.Text + "','" + textBoxRemarks.Text + "','" + textBoxAmount.Text + "')";
                    SqlCommand command = new SqlCommand(query11, connection);
                    connection.Open();
                    int rowEffict11 = command.ExecuteNonQuery();

                    connection.Close();
                    if (rowEffict11 > 0)
                    {
                        textBoxDescription.Text = textBoxRemarks.Text = textBoxAmount.Text = textBoxID.Text = "";
                        DataGrid();
                        buttonUpdate.Enabled = false;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBoxID.Text == "")
                {
                    MessageBox.Show("Please double click datagrid to update...");
                }

                else if (textBoxRemarks.Text == "")
                {
                    MessageBox.Show("Please fill the all field...");
                }
                else if (textBoxAmount.Text == "")
                {
                    MessageBox.Show("Please fill the all field...");
                }
                else if (textBoxRemarks.Text == "")
                {
                    MessageBox.Show("Please fill the all field...");
                }
                else
                {
                    string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
                    SqlConnection connection = new SqlConnection(conStr);
                    string query1 = "UPDATE Income SET Date = '" + dateTimePicker1.Text + "', Description = '" + textBoxDescription.Text + "', Remarks = '" + textBoxRemarks.Text + "' , Amount  = '" + textBoxAmount.Text + "' WHERE ID = '" + textBoxID.Text + "'";
                    SqlCommand command = new SqlCommand(query1, connection);
                    connection.Open();
                    int rowEffict11 = command.ExecuteNonQuery();
                    connection.Close();
                    if (rowEffict11 > 0)
                    {
                        textBoxDescription.Text = textBoxRemarks.Text = textBoxAmount.Text = textBoxID.Text = "";
                        DataGrid();
                        buttonUpdate.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back) //The  character represents a backspace
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
        }

        private void dataGridViewIncome_DoubleClick(object sender, EventArgs e)
        {
            textBoxID.Text = dateTimePicker1.Text = textBoxDescription.Text = textBoxRemarks.Text = textBoxAmount.Text = "";
            textBoxID.Text = dataGridViewIncome.SelectedRows[0].Cells[0].Value.ToString();
            dateTimePicker1.Text = dataGridViewIncome.SelectedRows[0].Cells[1].Value.ToString();
            textBoxDescription.Text = dataGridViewIncome.SelectedRows[0].Cells[2].Value.ToString();
            textBoxRemarks.Text = dataGridViewIncome.SelectedRows[0].Cells[3].Value.ToString();
            textBoxAmount.Text = dataGridViewIncome.SelectedRows[0].Cells[4].Value.ToString();
            buttonUpdate.Enabled = true;
        }
    }
}
