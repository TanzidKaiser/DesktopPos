using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace IFAD_v1._1
{
    public partial class StockTransferEdit : Form
    {
        public StockTransferEdit()
        {
            InitializeComponent();
        }

        private void DataGrid(string InvoiceNo)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "SELECT SalesID, SalesNo, SalesDate, SalesCustomerName, Reference, SalesRemarks, Product.Name as 'Name',SalesSalePrice, SalesQuantity, SalesProductDiscount, SalesTotal, SalesSoldBy, SalesReceivedAmount, SalesChangeAmount, SalesVatTotal, SalesPuechaseBy, SalesPurchaseByContact, SalesProductID, SalesCustomerID, SalesVatRate, PaymentType FROM Sales, Product WHERE Sales.SalesNo='" + InvoiceNo + "' AND Sales.SalesProductID = Product.ID";
            cmd.CommandText = "Select [TransferID], [CompanyID], [TransferNo], [TransferDate], [TransferTime], [TransferTo], [TransferRemarks], [TransferReference],[TransferProductID], Product.Name, [TransferQuantity], [TransferBy], [TransferReceivedBy] From[StockTransfer] inner join Product  on Product.ID = StockTransfer.TransferProductID  Where [TransferNo] = '"+InvoiceNo+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewStockTransfer.DataSource = dt;
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
              string date1 = dateTimePicker1.Text;
            string date2 = dateTimePicker2.Text;
            string query = "SELECT Distinct(TransferNo) FROM StockTransfer WHERE TransferDate BETWEEN '" + date1 + "' AND '" + date2 + "'";
            fillCombo(comboBoxInvoiceNo, query, "TransferNo", "TransferNo");
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            string date1 = dateTimePicker1.Text;
            string date2 = dateTimePicker2.Text;
            string query = "SELECT Distinct(TransferNo) FROM StockTransfer WHERE TransferDate BETWEEN '" + date1 + "' AND '" + date2 + "'";
            fillCombo(comboBoxInvoiceNo, query, "TransferNo", "TransferNo");
        }

        private void StockTransferReport2_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            DateTime today = DateTime.Today;
            dateTimePicker1.Value = today;
            dateTimePicker2.Value = today;
        }



        public void fillCombo(ComboBox combo, string query, string displayMember, string valueMember)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
            SqlCommand command = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            combo.DataSource = table;
            combo.DisplayMember = displayMember;
            combo.ValueMember = valueMember;
        }

        private void dataGridViewStockTransfer_DoubleClick(object sender, EventArgs e)
        {
            int TransferID = Convert.ToInt32(dataGridViewStockTransfer.SelectedRows[0].Cells[0].Value);
            string TransferCompany = dataGridViewStockTransfer.SelectedRows[0].Cells[1].Value.ToString();
            string TransferNo = dataGridViewStockTransfer.SelectedRows[0].Cells[2].Value.ToString();
            string TransferDate = dataGridViewStockTransfer.SelectedRows[0].Cells[3].Value.ToString();
            string TransferTime = dataGridViewStockTransfer.SelectedRows[0].Cells[4].Value.ToString();
            string TransferTo = dataGridViewStockTransfer.SelectedRows[0].Cells[5].Value.ToString();
            string TransferRemarks = dataGridViewStockTransfer.SelectedRows[0].Cells[6].Value.ToString();
            string TransferReference = dataGridViewStockTransfer.SelectedRows[0].Cells[7].Value.ToString();

            string TransferProductID = dataGridViewStockTransfer.SelectedRows[0].Cells[8].Value.ToString();
            string TransferProductName = dataGridViewStockTransfer.SelectedRows[0].Cells[9].Value.ToString();
            double TransferQuantity = Convert.ToDouble(dataGridViewStockTransfer.SelectedRows[0].Cells[10].Value);
            string TransferBy = dataGridViewStockTransfer.SelectedRows[0].Cells[11].Value.ToString();
            string TransferReceivedBy = dataGridViewStockTransfer.SelectedRows[0].Cells[12].Value.ToString();

            StockTransferEditUI seu = new StockTransferEditUI(TransferID, TransferCompany, TransferNo, TransferDate, TransferTime, TransferTo, TransferRemarks, TransferReference, TransferProductID, TransferProductName, TransferQuantity, TransferBy, TransferReceivedBy);
            seu.ShowDialog();

            DataGrid(comboBoxInvoiceNo.Text);
        }
    }
}
