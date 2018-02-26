using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace IFAD_v1._1
{
    public partial class PaymentReport : Form
    {
        public PaymentReport()
        {
            InitializeComponent();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string date1 = dateTimePicker1.Text;
            string date2 = dateTimePicker2.Text;
            DataGrid(date1, date2);
            PrintReport();
        }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());

        private void DataGrid(string date1, string date2)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Customer.CustomerID as 'CustomerID', CustomerLedger.ReceiveDate as 'ReceiveDate', CustomerName as 'CustomerName', Debit as 'Debit', Credit as 'Credit' FROM  CustomerLedger,Customer  WHERE CustomerLedger.CustomerID = Customer.CustomerID AND CustomerLedger.ReceiveDate BETWEEN '" + date1 + "' AND '" + date2 + "' ORDER BY CustomerLedger.ReceiveDate";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void PaymentReport_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            DateTime date = DateTime.Today;
            dateTimePicker1.Value = date;
            dateTimePicker2.Value = date;
        }

        private void PrintReport()
        {
            Temp_Payment_Report_Truncate();
            Temp_Payment_Stock_report();

            ReportDocument cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();

            if (radioButtonPayment.Checked)
            {
                string rPath = @"C:\IFAD-Reports\CrystalReportPaymentReport.rpt";
                cryRpt.Load(rPath);
            }
            if (radioButtonRecived.Checked)
            {
                string rPath2 = @"C:\IFAD-Reports\CrystalReportRecivedReport.rpt";
                cryRpt.Load(rPath2);
            }

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

        private void Temp_Payment_Report_Truncate()
        {
            con.Open();
            string sql = @"TRUNCATE TABLE TempPaymentReport";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void Temp_Payment_Stock_report()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //string constring = @"SERVER = Kamrul-pc; DATABASE =pos; user id = sa; PASSWORD = 123";
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO TempPaymentReport(TempRecivedDate,TempCustomerID,TempCustomerName,TempPaidAmount) VALUES(@RecivedDate,@ID,@CustomerName,@Debit)", con))
                    {
                        cmd.Parameters.AddWithValue("@RecivedDate", row.Cells["ReceiveDate"].Value);
                        cmd.Parameters.AddWithValue("@ID", row.Cells["Credit"].Value);
                        cmd.Parameters.AddWithValue("@CustomerName", row.Cells["CustomerName"].Value);
                        cmd.Parameters.AddWithValue("@Debit", row.Cells["Debit"].Value);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }
    }
}
