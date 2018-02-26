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
    public partial class Expense : Form
    {
        public Expense()
        {
            InitializeComponent();
            textBoxAmount.KeyPress += new KeyPressEventHandler(textBoxAmount_KeyPress);
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
        private void DataGrid(string ExpenseType)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ID as 'ID', Date as 'Date', Description as 'Description', Remarks as 'Remarks', Amount as 'Amount' FROM Expense WHERE ExpenseType='"+ ExpenseType + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewExpensive.DataSource = dt;
            con.Close();
        }
        private void Expensive_Load(object sender, EventArgs e)
        {
            buttonUpdate.Enabled = false;
            textBoxID.Text = "";
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            DateTime today = DateTime.Today;
            dateTimePicker1.Value = today;

            comboBoxExpensetype.Items.Add("General-Expense");
            comboBoxExpensetype.Items.Add("Special-Discount");
            comboBoxExpensetype.SelectedIndex = 0;



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
                    string query11 = "INSERT INTO Expense VALUES('1','" + dateTimePicker1.Text + "','"+comboBoxExpensetype.Text+"','" + textBoxDescription.Text + "','" + textBoxRemarks.Text + "','" + textBoxAmount.Text + "')";
                    SqlCommand command = new SqlCommand(query11, connection);
                    connection.Open();
                    int rowEffict11 = command.ExecuteNonQuery();
                    
                    connection.Close();
                    if (rowEffict11 > 0)
                    {
                        textBoxDescription.Text = textBoxRemarks.Text = textBoxAmount.Text = textBoxID.Text= "";
                        DataGrid(comboBoxExpensetype.Text);
                        buttonUpdate.Enabled = false;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewExpensive_DoubleClick(object sender, EventArgs e)
        {
            textBoxID.Text = dateTimePicker1.Text = textBoxDescription.Text = textBoxRemarks.Text = textBoxAmount.Text = "";
            textBoxID.Text = dataGridViewExpensive.SelectedRows[0].Cells[0].Value.ToString();
            dateTimePicker1.Text = dataGridViewExpensive.SelectedRows[0].Cells[1].Value.ToString();
            textBoxDescription.Text = dataGridViewExpensive.SelectedRows[0].Cells[2].Value.ToString();
            textBoxRemarks.Text = dataGridViewExpensive.SelectedRows[0].Cells[3].Value.ToString();
            textBoxAmount.Text = dataGridViewExpensive.SelectedRows[0].Cells[4].Value.ToString();
            buttonUpdate.Enabled = true;
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
                    string query1 = "UPDATE Expense SET Date = '" + dateTimePicker1.Text + "',ExpenseType = '" + comboBoxExpensetype.Text + "', Description = '" + textBoxDescription.Text + "', Remarks = '" + textBoxRemarks.Text + "' , Amount  = '" + textBoxAmount.Text + "' WHERE ID = '" + textBoxID.Text + "'";
                    SqlCommand command = new SqlCommand(query1, connection);
                    connection.Open();
                    int rowEffict11 = command.ExecuteNonQuery();
                    connection.Close();
                    if (rowEffict11 > 0)
                    {
                        textBoxDescription.Text = textBoxRemarks.Text = textBoxAmount.Text = textBoxID.Text = "";
                        DataGrid(comboBoxExpensetype.Text);
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
        private void Auto_Complete()
        {
            //Auto Complete search
            textBoxRemarks.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxRemarks.AutoCompleteSource = AutoCompleteSource.CustomSource;
            string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection conSS = new SqlConnection(conStr);
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            col.Clear();
            conSS.Open();
            string sql = "SELECT DISTINCT(SalesNo) FROM Sales";
            SqlCommand cmd = new SqlCommand(sql, conSS);
            SqlDataReader sdr = null;
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                col.Add(sdr["SalesNo"].ToString());
            }
            sdr.Close();
            textBoxRemarks.AutoCompleteCustomSource = col;
            conSS.Close();
        }

        private void Auto_Complete_Name()
        {
            //Auto Complete search
            textBoxRemarks.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxRemarks.AutoCompleteSource = AutoCompleteSource.CustomSource;
            string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection conSS = new SqlConnection(conStr);
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            col.Clear();
            conSS.Open();
            string sql = "SELECT CustomerName FROM Customer";
            SqlCommand cmd = new SqlCommand(sql, conSS);
            SqlDataReader sdr = null;
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                col.Add(sdr["CustomerName"].ToString());
            }
            sdr.Close();
            textBoxRemarks.AutoCompleteCustomSource = col;
            conSS.Close();
        }
        private void comboBoxExpensetype_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGrid(comboBoxExpensetype.Text);
            if(comboBoxExpensetype.Text== "General-Expense")
            {
                labelremarks.Text = "Remarks";
                textBoxRemarks.AutoCompleteMode = AutoCompleteMode.None;
                textBoxRemarks.AutoCompleteSource = AutoCompleteSource.None;
            }
            if (comboBoxExpensetype.Text == "Special-Discount")
            {
                labelremarks.Text = "Invoice No";
                Auto_Complete();

            }
            if (comboBoxExpensetype.Text == "Customer-Payment")
            {
                labelremarks.Text = "Customer Name";
                Auto_Complete_Name();
            }

        }
    }
}
