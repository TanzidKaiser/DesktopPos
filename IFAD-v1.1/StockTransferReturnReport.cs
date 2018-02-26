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
    public partial class StockTransferReturnReport : Form
    {
        public StockTransferReturnReport()
        {
            InitializeComponent();
        }

        private void StockTransferReturnReport_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            DateTime today = DateTime.Today;
            dateTimePicker1.Value = today;
            dateTimePicker2.Value = today;
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string date1 = dateTimePicker1.Text;
            string date2 = dateTimePicker2.Text;
            string query = "SELECT Distinct(TransferReturnNo) FROM StockTransferReturn WHERE TransferReturnDate BETWEEN '" + date1 + "' AND '" + date2 + "'";
            fillCombo(comboBoxInvoiceNo, query, "TransferReturnNo", "TransferReturnNo");
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            string date1 = dateTimePicker1.Text;
            string date2 = dateTimePicker2.Text;
            string query = "SELECT Distinct(TransferReturnNo) FROM StockTransferReturn WHERE TransferReturnDate BETWEEN '" + date1 + "' AND '" + date2 + "'";
            fillCombo(comboBoxInvoiceNo, query, "TransferReturnNo", "TransferReturnNo");
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
                    PrintReport();
                    StorePrecedureCall();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
        private void StorePrecedureCall()
        {
            string  id = comboBoxInvoiceNo.SelectedValue.ToString();
            con.Open();
            string query = "EXEC sp_StockTransferReturn @TransferReturnNo = '" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void PrintReport()
        {
            string id = comboBoxInvoiceNo.SelectedValue.ToString();

            ParameterFields myParameterFields = new ParameterFields();

            ParameterField myParameterField1 = new ParameterField();
            ParameterDiscreteValue myDiscreteValue1 = new ParameterDiscreteValue();

            ReportDocument cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();

            string rPath = ReportPaths + "CrystalReportStockTransferReturnReport.rpt";
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

            TextboxValue("@TransferReturnNo", id, myParameterField1, myDiscreteValue1, myParameterFields);

            crystalReportViewer1.ParameterFieldInfo = myParameterFields;
            crystalReportViewer1.Refresh();
            crystalReportViewer1.ReportSource = cryRpt;
        }

        private void TextboxValue(string ParameterName, string ParameterValue, ParameterField myParameterField, ParameterDiscreteValue myDiscreteValue, ParameterFields myParameterFields)
        {
            myParameterField.ParameterFieldName = ParameterName;
            myDiscreteValue.Value = ParameterValue;
            myParameterField.CurrentValues.Add(myDiscreteValue);
            myParameterFields.Add(myParameterField);
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

        public string ReportPaths = ReportPath.rPath;
        private void btnAllReport_Click(object sender, EventArgs e)
        {
            string id = comboBoxInvoiceNo.SelectedValue.ToString();

            ReportDocument cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();

            string rPath = ReportPaths + "CrystalReportAllStockTransferReturnReport.rpt";
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
            
            crystalReportViewer1.Refresh();
            crystalReportViewer1.ReportSource = cryRpt;
        }

        
    }
}
