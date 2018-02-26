using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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
    public partial class InvoiceChallanPrint : Form
    {
        public InvoiceChallanPrint()
        {
            InitializeComponent();
        }
        public string ReportPaths = ReportPath.rPath;
        public int CompanyIDs = Company.CompanyID;
        int CustomerID = 0;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
        private void InvoiceChallanPrint_Load(object sender, EventArgs e)
        {
            Auto_Complete();
            comboBoxReportType.Items.Add("Invoice");
            comboBoxReportType.Items.Add("Challan");

            comboBoxReportType.SelectedIndex = 0;
        }

        private void TextboxValue(string ParameterName, int ParameterValue, ParameterField myParameterField, ParameterDiscreteValue myDiscreteValue, ParameterFields myParameterFields)
        {
            myParameterField.ParameterFieldName = ParameterName;
            myDiscreteValue.Value = ParameterValue;
            myParameterField.CurrentValues.Add(myDiscreteValue);
            myParameterFields.Add(myParameterField);
        }
        private void Auto_Complete()
        {
            //Auto Complete search
            textBoxInvoice.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxInvoice.AutoCompleteSource = AutoCompleteSource.CustomSource;
            string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection conSS = new SqlConnection(conStr);
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            col.Clear();
            conSS.Open();
            string sql = "SELECT DISTINCT(SalesNo) as 'SNO' FROM Sales";
            SqlCommand cmd = new SqlCommand(sql, conSS);
            SqlDataReader sdr = null;
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                col.Add(sdr["SNO"].ToString());
            }
            sdr.Close();
            textBoxInvoice.AutoCompleteCustomSource = col;
            conSS.Close();
        }
        private void DataGrid(string InvoiceNo)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT  Sales.SalesNo as 'SalesNo', Sales.SalesDate as 'SalesDate', Sales.SalesTime as 'SalesTime', Sales.SalesCustomerID as 'SalesCustomerID', Sales.SalesRemarks as 'SalesRemarks', Sales.Reference as 'Reference', Sales.SalesProductID as 'SalesProductID', Sales.SalesPurchasePrice as 'SalesPurchasePrice', Sales.SalesSalePrice as 'SalesSalePrice', Sales.SalesQuantity as 'SalesQuantity', Sales.SalesProductDiscount as 'SalesProductDiscount', Sales.SalesTotal as 'SalesTotal',Sales.SalesCustomerName as 'SalesCustomerName',Sales.SalesSoldBy as 'SalesSoldBy',Sales.SalesReceivedAmount as 'SalesReceivedAmount',Sales.SalesChangeAmount as 'SalesChangeAmount',Sales.SalesVatRate as 'SalesVatRate',Sales.SalesVatTotal as 'SalesVatTotal', SalesPuechaseBy as 'SalesPuechaseBy', SalesPurchaseByContact as 'SalesPurchaseByContact', PaymentType as 'PaymentType' FROM Sales WHERE Sales.SalesNo = '" + InvoiceNo + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewInvoice.DataSource = dt;
            con.Close();
        }
        private void Temp_Invoice_Sales_Report_Truncket()
        {
            con.Open();
            string sql = @"DELETE FROM TempInvoiceSalesReport WHERE CompanyID='" + CompanyIDs + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void TempSales_Truncket()
        {
            con.Open();
            string sql = @"DELETE FROM TempSales WHERE TempSalesCompanyID='" + CompanyIDs + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void Temp_Invoice_Sales_Stock()
        {
            TempSales_Truncket();

            foreach (DataGridViewRow row in dataGridViewInvoice.Rows)
            {
               
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO TempSales VALUES('" + CompanyIDs + "',@SalesNo, @SalesDate,@SalesTime,@SalesCustomerID,@SalesRemarks,@Reference,@SalesProductID,@SalesPurchasePrice,@SalesSalePrice,@SalesQuantity,@SalesProductDiscount,@SalesTotal,@SalesCustomerName,@SalesSoldBy,@SalesReceivedAmount,@SalesChangeAmount,@SalesVatRate,@SalesVatTotal,0,@SalesPuechaseBy,@SalesPurchaseByContact, @PaymentType)", con))
                    {
                        
                        cmd.Parameters.AddWithValue("@SalesNo", row.Cells["SalesNo"].Value);
                        cmd.Parameters.AddWithValue("@SalesDate", row.Cells["SalesDate"].Value);
                        cmd.Parameters.AddWithValue("@SalesTime", row.Cells["SalesTime"].Value);
                        cmd.Parameters.AddWithValue("@SalesCustomerID", row.Cells["SalesCustomerID"].Value);
                        cmd.Parameters.AddWithValue("@SalesRemarks", row.Cells["SalesRemarks"].Value);
                        cmd.Parameters.AddWithValue("@Reference", row.Cells["Reference"].Value);
                        cmd.Parameters.AddWithValue("@SalesProductID", row.Cells["SalesProductID"].Value);
                        cmd.Parameters.AddWithValue("@SalesPurchasePrice", row.Cells["SalesPurchasePrice"].Value);
                        cmd.Parameters.AddWithValue("@SalesSalePrice", row.Cells["SalesSalePrice"].Value);
                        cmd.Parameters.AddWithValue("@SalesQuantity", row.Cells["SalesQuantity"].Value);
                        cmd.Parameters.AddWithValue("@SalesProductDiscount", row.Cells["SalesProductDiscount"].Value);
                        cmd.Parameters.AddWithValue("@SalesTotal", row.Cells["SalesTotal"].Value);
                        cmd.Parameters.AddWithValue("@SalesCustomerName", row.Cells["SalesCustomerName"].Value);
                        cmd.Parameters.AddWithValue("@SalesSoldBy", row.Cells["SalesSoldBy"].Value);
                        cmd.Parameters.AddWithValue("@SalesReceivedAmount", row.Cells["SalesReceivedAmount"].Value);
                        cmd.Parameters.AddWithValue("@SalesChangeAmount", row.Cells["SalesChangeAmount"].Value);
                        cmd.Parameters.AddWithValue("@SalesVatRate", row.Cells["SalesVatRate"].Value);
                        cmd.Parameters.AddWithValue("@SalesVatTotal", row.Cells["SalesVatTotal"].Value);

                        cmd.Parameters.AddWithValue("@SalesPuechaseBy", row.Cells["SalesPuechaseBy"].Value);
                        cmd.Parameters.AddWithValue("@SalesPurchaseByContact", row.Cells["SalesPurchaseByContact"].Value);
                        cmd.Parameters.AddWithValue("@PaymentType", row.Cells["PaymentType"].Value);
                        CustomerID = Convert.ToInt32(row.Cells["SalesCustomerID"].Value);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            // MessageBox.Show("Records inserted.");
        }
        private void Insert_Temp_Sales_Amount()
        {
           // int CompanyID = ;
            int TotalVat = 0;
            double NetPayable = 0;
            double CashPaid = 0;
            double ReturnAmount = 0;
            double DueAmount = 0;
            string CurrentUserSales = "";
            string Remarks = "";
            double TempSalesTotal = 0;
            double TempSalesProductDiscount = 0;
            double VatRate = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
            string query = "SELECT * FROM TempSales WHERE TempSalesCompanyID = '"+ CompanyIDs + "'";
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                CashPaid = Convert.ToDouble(reader["TempSalesReceivedAmount"]);
                ReturnAmount = Convert.ToDouble(reader["TempSalesChangeAmount"]);
                DueAmount = Convert.ToDouble(reader["TempSalesVatTotal"]) - Convert.ToDouble(reader["TempSalesReceivedAmount"]);
                Remarks = reader["TempSalesRemarks"].ToString();
                TempSalesTotal = TempSalesTotal + Convert.ToDouble(reader["TempSalesTotal"]);
                TempSalesProductDiscount = TempSalesProductDiscount + Convert.ToDouble(reader["TempSalesProductDiscount"]);
                VatRate = Convert.ToDouble(reader["TempSalesVatRate"]);

            }
            reader.Close();
            con.Close();

            TotalVat = (int)Math.Ceiling((((TempSalesTotal + TempSalesProductDiscount) * VatRate) / 100));

            con.Open();
            string sql = @"DELETE FROM TempSalesAmount WHERE CompanyID = '" + CompanyIDs + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();

           
            con.Open();
            string sql1 = @"INSERT INTO TempSalesAmount(CompanyID, CustomerID, TotalVat, NetPayable, CashPaid, ReturnAmount, DueAmount,CurrentUserSales,Remarks) VALUES('" + CompanyIDs + "','" + CustomerID + "','" + TotalVat + "','" + NetPayable + "','" + CashPaid + "','" + ReturnAmount + "','" + DueAmount + "','" + CurrentUserSales + "','" + Remarks + "')";
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            cmd1.ExecuteNonQuery();
            con.Close();

        }
        private void PrintReport_Invoice()
        {
            ReportDocument cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();

            ParameterFields myParameterFields = new ParameterFields();

            ParameterField myParameterField1 = new ParameterField();
            ParameterDiscreteValue myDiscreteValue1 = new ParameterDiscreteValue();


            string rPath = ReportPaths + "CrystalReportSalesReportInvoiceA4.rpt";
            cryRpt.Load(rPath);
            crConnectionInfo.ServerName = ConfigurationManager.ConnectionStrings["cryServer"].ToString();
            crConnectionInfo.DatabaseName = ConfigurationManager.ConnectionStrings["cryDatabase"].ToString();
            crConnectionInfo.UserID = ConfigurationManager.ConnectionStrings["cryUserID"].ToString();
            crConnectionInfo.Password = ConfigurationManager.ConnectionStrings["cryPass"].ToString();

            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in cryRpt.Database.Tables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }

            TextboxValue("CompanyID", CompanyIDs, myParameterField1, myDiscreteValue1, myParameterFields);

            crystalReportViewer1.ParameterFieldInfo = myParameterFields;
            crystalReportViewer1.Refresh();
            crystalReportViewer1.ReportSource = cryRpt;


        }
        private void PrintReport_Challan()
        {
            ReportDocument cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();

            ParameterFields myParameterFields = new ParameterFields();

            ParameterField myParameterField1 = new ParameterField();
            ParameterDiscreteValue myDiscreteValue1 = new ParameterDiscreteValue();


            string rPath = ReportPaths + "CrystalReportSalesInvoiceChallanA4.rpt";
            cryRpt.Load(rPath);
            crConnectionInfo.ServerName = ConfigurationManager.ConnectionStrings["cryServer"].ToString();
            crConnectionInfo.DatabaseName = ConfigurationManager.ConnectionStrings["cryDatabase"].ToString();
            crConnectionInfo.UserID = ConfigurationManager.ConnectionStrings["cryUserID"].ToString();
            crConnectionInfo.Password = ConfigurationManager.ConnectionStrings["cryPass"].ToString();

            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in cryRpt.Database.Tables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }

            TextboxValue("CompanyID", CompanyIDs, myParameterField1, myDiscreteValue1, myParameterFields);

            crystalReportViewer1.ParameterFieldInfo = myParameterFields;
            crystalReportViewer1.Refresh();
            crystalReportViewer1.ReportSource = cryRpt;

        }
        private void buttonInvoiceSearch_Click(object sender, EventArgs e)
        {
            if (textBoxInvoice.Text=="")
            {
                MessageBox.Show("Please Input Invoice No...");
            }
            else
            {
                string InvoiceNo = textBoxInvoice.Text;

                DataGrid(InvoiceNo);
                Temp_Invoice_Sales_Report_Truncket();
                Temp_Invoice_Sales_Stock();
                Insert_Temp_Sales_Amount();

                if (comboBoxReportType.Text == "Invoice")
                {
                    PrintReport_Invoice();
                }
                if (comboBoxReportType.Text == "Challan")
                {
                    PrintReport_Challan();
                }
            }
            
            
        }
        private void InvoiceChallanPrint_FormClosed(object sender, FormClosedEventArgs e)
        {
            con.Open();
            string sql = @"DELETE FROM TempSalesAmount WHERE CompanyID = '" + CompanyIDs + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            Temp_Invoice_Sales_Report_Truncket();
            TempSales_Truncket();
        }
    }
}
