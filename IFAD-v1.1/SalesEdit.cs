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
    public partial class SalesEdit : Form
    {
        public SalesEdit()
        {
            InitializeComponent();
        }
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
            cmd.CommandText = "SELECT SalesID, SalesNo, SalesDate, SalesCustomerName, Reference, SalesRemarks, Product.Name as 'Name',SalesSalePrice, SalesQuantity, SalesProductDiscount, SalesTotal, SalesSoldBy, SalesReceivedAmount, SalesChangeAmount, SalesVatTotal, SalesPuechaseBy, SalesPurchaseByContact, SalesProductID, SalesCustomerID, SalesVatRate, PaymentType FROM Sales, Product WHERE Sales.SalesNo='" + InvoiceNo + "' AND Sales.SalesProductID = Product.ID";
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

        private void PurchaseEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string date1 = dateTimePicker1.Text;
            string date2 = dateTimePicker2.Text;
            string query = "SELECT DISTINCT(SalesNo) FROM Sales WHERE SalesDate  BETWEEN '" + date1 + "' AND '" + date2 + "'";
            fillCombo(comboBoxInvoiceNo, query, "SalesNo", "SalesNo");
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            string date1 = dateTimePicker1.Text;
            string date2 = dateTimePicker2.Text;
            string query = "SELECT DISTINCT(SalesNo) FROM Sales WHERE SalesDate  BETWEEN '" + date1 + "' AND '" + date2 + "'";
            fillCombo(comboBoxInvoiceNo, query, "SalesNo", "SalesNo");
        }
        
        private void dataGridViewPurchaseEdit_DoubleClick(object sender, EventArgs e)
        {
            int SalesID=Convert.ToInt32(dataGridViewPurchaseEdit.SelectedRows[0].Cells[0].Value);
            string SalesNo = dataGridViewPurchaseEdit.SelectedRows[0].Cells[1].Value.ToString();
            string SalesDate = dataGridViewPurchaseEdit.SelectedRows[0].Cells[2].Value.ToString();
            string SalesCustomerName = dataGridViewPurchaseEdit.SelectedRows[0].Cells[3].Value.ToString();
            string Reference = dataGridViewPurchaseEdit.SelectedRows[0].Cells[4].Value.ToString();
            string SalesRemarks = dataGridViewPurchaseEdit.SelectedRows[0].Cells[5].Value.ToString();
            string ProductName = dataGridViewPurchaseEdit.SelectedRows[0].Cells[6].Value.ToString();
           
            double SalesSalePrice =Convert.ToDouble(dataGridViewPurchaseEdit.SelectedRows[0].Cells[7].Value);
            double SalesQuantity = Convert.ToDouble(dataGridViewPurchaseEdit.SelectedRows[0].Cells[8].Value);
            double SalesProductDiscount = Convert.ToDouble(dataGridViewPurchaseEdit.SelectedRows[0].Cells[9].Value);
            double SalesTotal = Convert.ToDouble(dataGridViewPurchaseEdit.SelectedRows[0].Cells[10].Value);
            string SalesSoldBy = dataGridViewPurchaseEdit.SelectedRows[0].Cells[11].Value.ToString();
            double SalesReceivedAmount = Convert.ToDouble(dataGridViewPurchaseEdit.SelectedRows[0].Cells[12].Value);
            double SalesChangeAmount = Convert.ToDouble(dataGridViewPurchaseEdit.SelectedRows[0].Cells[13].Value);
            double SalesVatTotal = Convert.ToDouble(dataGridViewPurchaseEdit.SelectedRows[0].Cells[14].Value);
            string SalesPuechaseBy = dataGridViewPurchaseEdit.SelectedRows[0].Cells[15].Value.ToString();
            string SalesPurchaseByContact = dataGridViewPurchaseEdit.SelectedRows[0].Cells[16].Value.ToString();

            int ProductID = Convert.ToInt32(dataGridViewPurchaseEdit.SelectedRows[0].Cells[17].Value);
            int CustomerID = Convert.ToInt32(dataGridViewPurchaseEdit.SelectedRows[0].Cells[18].Value);
            int vatrate = Convert.ToInt32(dataGridViewPurchaseEdit.SelectedRows[0].Cells[19].Value);
            int payment_type = Convert.ToInt32(dataGridViewPurchaseEdit.SelectedRows[0].Cells[20].Value);

            SalesEditUI seu = new SalesEditUI(SalesID, SalesNo, SalesDate, SalesCustomerName, Reference, SalesRemarks, ProductName, SalesSalePrice, SalesQuantity, SalesProductDiscount, SalesTotal, SalesSoldBy, SalesReceivedAmount, SalesChangeAmount, SalesVatTotal, SalesPuechaseBy, SalesPurchaseByContact, ProductID, CustomerID, vatrate, payment_type);
            seu.ShowDialog();

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
    }
}
