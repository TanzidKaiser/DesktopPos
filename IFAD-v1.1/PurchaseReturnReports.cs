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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFAD_v1._1
{
    public partial class PurchaseReturnReports : Form
    {
        public PurchaseReturnReports()
        {
            InitializeComponent();
        }

        private void PurchaseReturnReports_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            DateTime date = DateTime.Today;
            dateTimePicker1.Value = date;
            dateTimePicker2.Value = date;
        }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
        private void DataGrid(string date1, string date2)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT PurchaseReturn.Date as 'Date', PurchaseReturn.InvoiceNo as 'InvoiceNo', Product.Code as 'ProductCode',  Product.Name as 'ProductName', PurchaseReturn.PurchasePrice as 'PurchasePrice', PurchaseReturn.Quantity as 'Quantity', PurchaseReturn.Total as 'Total' FROM PurchaseReturn, Product WHERE PurchaseReturn.ProductID = Product.ID AND PurchaseReturn.Date BETWEEN '" + date1 + "' AND '" + date2 + "' ORDER BY PurchaseReturn.Date";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewPurchaseReturn.DataSource = dt;
            con.Close();
        }
        private void Temp_Sales_Rerurn_Report_Stock()
        {
            foreach (DataGridViewRow row in dataGridViewPurchaseReturn.Rows)
            {
                //string constring = @"SERVER = Kamrul-pc; DATABASE =pos; user id = sa; PASSWORD = 123";
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO TempPurchaseReturnReport VALUES(1,'" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "',@Date,@InvoiceNo,@ProductCode,@ProductName,@PurchasePrice,@Quantity,@Total)", con))
                    {
                        cmd.Parameters.AddWithValue("@Date", row.Cells["Date"].Value);
                        cmd.Parameters.AddWithValue("@InvoiceNo", row.Cells["InvoiceNo"].Value);
                        cmd.Parameters.AddWithValue("@ProductCode", row.Cells["ProductCode"].Value);
                        cmd.Parameters.AddWithValue("@ProductName", row.Cells["ProductName"].Value);
                        cmd.Parameters.AddWithValue("@PurchasePrice", row.Cells["PurchasePrice"].Value);
                        cmd.Parameters.AddWithValue("@Quantity", row.Cells["Quantity"].Value);
                        cmd.Parameters.AddWithValue("@Total", row.Cells["Total"].Value);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            // MessageBox.Show("Records inserted.");
        }
        private void Temp_Sales_Rerurn_Report_Truncket()
        {
            con.Open();
            string sql = @"TRUNCATE TABLE TempPurchaseReturnReport";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public string ReportPaths = ReportPath.rPath;
        private void PrintReport()
        {
            Temp_Sales_Rerurn_Report_Truncket();
            Temp_Sales_Rerurn_Report_Stock();
            ReportDocument cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            //string rPath = @"C:\Reports\CrystalReportPurchaseReturnReport.rpt";
            string rPath = ReportPaths + "CrystalReportPurchaseReturnReport.rpt";
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

            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.RefreshReport();
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {

            string date1 = dateTimePicker1.Text;
            string date2 = dateTimePicker2.Text;
            DataGrid(date1, date2);
            PrintReport();
        }
    }
}
