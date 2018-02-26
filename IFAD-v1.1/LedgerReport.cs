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
    public partial class LedgerReport : Form
    {
        public LedgerReport()
        {
            InitializeComponent();
            //string query12 = "SELECT * FROM Customer";
            string query12 = "SELECT * FROM Customer ORDER BY CustomerName";      //Change
            fillCombo(comboBox1, query12, "CustomerName", "CustomerID");
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable table;
        public void fillCombo(ComboBox combo, string query, string displayMember, string valueMember)
        {
            command = new SqlCommand(query, con);
            adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            combo.DataSource = table;
            combo.DisplayMember = displayMember;
            combo.ValueMember = valueMember;

        }
        private void DataGrid()
        {
            int id;
            Int32.TryParse(comboBox1.SelectedValue.ToString(), out id);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT CustomerName as 'TempCustomerName', ReceiveDate as 'TempCustomerDate', InvoiceNo as 'TempCustomerInvoiceNo', Debit as 'TempCustomerDebit', Credit as 'TempCustomerCredit', Adjustment as 'TempAdjustment',PaymentType as 'TempPaymentType',BankName as 'TempBankName', ChequeNo as 'TempChequeNo',ChequeDate as 'TempChequeDate', Remarks as 'TempCustomerRemarks' FROM Customer, CustomerLedger WHERE CustomerLedger.CustomerID = '" + id + "' AND Customer.CustomerID = CustomerLedger.CustomerID";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void LedgerReport_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            int id;
            Int32.TryParse(comboBox1.SelectedValue.ToString(), out id);

            double ledger_debit = 0.0;
            double ledger_credit = 0.0;
            string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection con = new SqlConnection(conStr);
            string query = "SELECT * FROM CustomerLedger WHERE CustomerID = " + id;
            SqlCommand command112 = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader12 = command112.ExecuteReader();
            while (reader12.Read())
            {

                ledger_debit = ledger_debit + Convert.ToDouble(reader12["Debit"]);
                ledger_credit = ledger_credit + Convert.ToDouble(reader12["Credit"]);

            }
            reader12.Close();
            con.Close();
            DataGrid();
        }
        private void Temp_Purchase_Report()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO TempCustomerLedger(TempCompanyID,TempCustomerName,TempCustomerDate,TempCustomerInvoiceNo,TempCustomerDebit,TempCustomerCredit,TempAdjustment,TempPaymentType,TempBankName,TempChequeNo,TempChequeDate,TempCustomerRemarks) VALUES(1, @TempCustomerName, @TempCustomerDate, @TempCustomerInvoiceNo,@TempCustomerDebit,@TempCustomerCredit,@TempAdjustment,@TempPaymentType,@TempBankName,@TempChequeNo,@TempChequeDate,@TempCustomerRemarks)", con))
                    {
                        cmd.Parameters.AddWithValue("@TempCustomerName", row.Cells["TempCustomerName"].Value);
                        cmd.Parameters.AddWithValue("@TempCustomerDate", row.Cells["TempCustomerDate"].Value);
                        cmd.Parameters.AddWithValue("@TempCustomerInvoiceNo", row.Cells["TempCustomerInvoiceNo"].Value);
                        cmd.Parameters.AddWithValue("@TempCustomerDebit", row.Cells["TempCustomerDebit"].Value);
                        cmd.Parameters.AddWithValue("@TempCustomerCredit", row.Cells["TempCustomerCredit"].Value);
                        cmd.Parameters.AddWithValue("@TempAdjustment", row.Cells["TempAdjustment"].Value);
                        cmd.Parameters.AddWithValue("@TempPaymentType", row.Cells["TempPaymentType"].Value);

                        cmd.Parameters.AddWithValue("@TempBankName", row.Cells["TempBankName"].Value);
                        cmd.Parameters.AddWithValue("@TempChequeNo", row.Cells["TempChequeNo"].Value);
                        cmd.Parameters.AddWithValue("@TempChequeDate", row.Cells["TempChequeDate"].Value);
                        cmd.Parameters.AddWithValue("@TempCustomerRemarks", row.Cells["TempCustomerRemarks"].Value);


                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            // MessageBox.Show("Records inserted.");
        }
        private void Temp_Purchase_Report_Truncket()
        {
            con.Open();
            string sql = @"TRUNCATE TABLE TempCustomerLedger";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        ReportDocument cryRpt = new ReportDocument();
        public string ReportPaths = ReportPath.rPath;
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            Temp_Purchase_Report_Truncket();
            Temp_Purchase_Report();

            
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            //string rPath = @"C:\Reports\CrystalReportTempCustomerLedger.rpt";
            string rPath = ReportPaths + "CrystalReportCustomerLedger.rpt";
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

        private void LedgerReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            cryRpt.Close();
            cryRpt.Dispose();
            crystalReportViewer1.ReportSource = null;
            crystalReportViewer1.Dispose();
            crystalReportViewer1 = null;
        }
    }
}
