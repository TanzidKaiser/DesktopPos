using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IFAD_v1._1
{
    public partial class StockTransferReturnEdit : Form
    {
        public StockTransferReturnEdit()
        {
            InitializeComponent();
        }

        string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();

        public static string InvoiceNoForEdit = "";
        private void PurchaseEdit_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            DateTime today = DateTime.Today;
            dateTimePicker1.Value = today;
            dateTimePicker2.Value = today;

        }
        private void DataGrid(string InvoiceNo)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT TransferReturnID, TransferReturnDate, TransferReturnNo, ProductID, Product.Name as 'Product Name', Quantity, TransferReturnBy, Remarks  FROM StockTransferReturn, Product WHERE StockTransferReturn.TransferReturnNo='"+ InvoiceNo +"' AND StockTransferReturn.ProductID = Product.ID";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewPurchaseEdit.DataSource = dt;
            con.Close();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxInvoiceNo.Text == "")
                {
                    MessageBox.Show("Please Fill Invoice No....!!!");
                    return;
                }

                else
                {
                    DataGrid(comboBoxInvoiceNo.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable table;
        public void fillCombo(ComboBox combo, string query, string displayMember, string valueMember)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
            command = new SqlCommand(query, con);
            adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            combo.DataSource = table;
            combo.DisplayMember = displayMember;
            combo.ValueMember = valueMember;

        }

        private void ClearAll()
        {
            textBoxTransferRetuenID.Text = "";
            textBoxReturnDate.Text = "";
            textBoxReturnNo.Text = "";
            textBoxProductID.Text = "";
            textBoxProductName.Text = "";
            textBoxQuantity.Text = "";
            textBoxRemarks.Text = "";
            textBoxNewQuantity.Text = "";
            textBoxNewRemarks.Text = "";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string date1 = dateTimePicker1.Text;
            string date2 = dateTimePicker2.Text;
            string query = "SELECT DISTINCT(TransferReturnNo) FROM StockTransferReturn WHERE TransferReturnDate BETWEEN '" + date1 + "' AND '" + date2 + "'";
            fillCombo(comboBoxInvoiceNo, query, "TransferReturnNo", "TransferReturnNo");
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            string date1 = dateTimePicker1.Text;
            string date2 = dateTimePicker2.Text;
            string query = "SELECT DISTINCT(TransferReturnNo) FROM StockTransferReturn WHERE TransferReturnDate BETWEEN '" + date1 + "' AND '" + date2 + "'";
            fillCombo(comboBoxInvoiceNo, query, "TransferReturnNo", "TransferReturnNo");
        }
        
        private void dataGridViewPurchaseEdit_DoubleClick(object sender, EventArgs e)
        {
            textBoxTransferRetuenID.Text = dataGridViewPurchaseEdit.SelectedRows[0].Cells[0].Value.ToString();
            textBoxReturnDate.Text = dataGridViewPurchaseEdit.SelectedRows[0].Cells[1].Value.ToString();
            textBoxReturnNo.Text = dataGridViewPurchaseEdit.SelectedRows[0].Cells[2].Value.ToString();
            textBoxProductID.Text = dataGridViewPurchaseEdit.SelectedRows[0].Cells[3].Value.ToString();
            textBoxProductName.Text = dataGridViewPurchaseEdit.SelectedRows[0].Cells[4].Value.ToString();
            textBoxQuantity.Text = dataGridViewPurchaseEdit.SelectedRows[0].Cells[5].Value.ToString();
            string TransferReturnBy = dataGridViewPurchaseEdit.SelectedRows[0].Cells[6].Value.ToString();
            textBoxRemarks.Text = dataGridViewPurchaseEdit.SelectedRows[0].Cells[7].Value.ToString();

            //SalesEditUI seu = new SalesEditUI(TransferReturnID, TransferReturnDate, TransferReturnNo, ProductID, ProductName, Quantity, TransferReturnBy, Remarks);
            //seu.ShowDialog();

            DataGrid(comboBoxInvoiceNo.Text);

        }

        private void buttonAddMore_Click(object sender, EventArgs e)
        {
            if (comboBoxInvoiceNo.Text == "")
            {
                MessageBox.Show("There Is No Selected Invoice No...");
            }
            else
            {
                InvoiceNoForEdit = comboBoxInvoiceNo.Text;
                AddMoreSales ams = new AddMoreSales();
                ams.Show();
            }
        }


        private void buttonEdit_Click(object sender, EventArgs e)
        {
            double old_quantity = Convert.ToDouble(textBoxQuantity.Text);
            double new_quantity = Convert.ToDouble(textBoxNewQuantity.Text);
            double difference_quantity = old_quantity - new_quantity;
            int prod_id = Convert.ToInt32(textBoxProductID.Text);

            if (textBoxNewQuantity.Text == "")
            {
                textBoxNewQuantity.Text = "0";
            }

            else if (new_quantity > old_quantity)
            {
                MessageBox.Show("Return Quantity is too big...");
            }
           
            else if (textBoxNewRemarks.Text == "")
            {
                MessageBox.Show("You Must Write Some Remarks");
            }

            else
            {
                SqlConnection connection1 = new SqlConnection(conStr);
                
                string query1 = "UPDATE StockTransferReturn SET Quantity = '"+ new_quantity + "' WHERE TransferReturnID = '"+ textBoxTransferRetuenID.Text + "'";
                SqlCommand command1 = new SqlCommand(query1, connection1);
                connection1.Open();
                command1.ExecuteNonQuery();
                connection1.Close();

                string query2 = "UPDATE StockTransfer SET TransferQuantity = ((SELECT TransferQuantity FROM StockTransfer WHERE TransferNo = '" + textBoxReturnNo.Text + "' AND TransferProductID = '" + prod_id + "') + '"+ difference_quantity + "') WHERE TransferNo = '" + textBoxReturnNo.Text + "' AND TransferProductID = '" + prod_id + "'";
                SqlCommand command2 = new SqlCommand(query2, connection1);
                connection1.Open();
                command2.ExecuteNonQuery();
                connection1.Close();

                string query3 = "UPDATE Product SET Stock = ((SELECT Stock FROM Product WHERE ID = '" + prod_id + "' ) - '" + difference_quantity + "') WHERE ID = '" + prod_id + "'";
                SqlCommand command3 = new SqlCommand(query3, connection1);
                connection1.Open();
                command3.ExecuteNonQuery();
                connection1.Close();


                //DataGrid(InvoiceNo);
                //OtherInfo(InvoiceNo);
                MessageBox.Show("Edit Successfully..");
                ClearAll();
            }
            
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
   }
}
