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
    public partial class ProductLedger : Form
    {
        public ProductLedger()
        {
            InitializeComponent();
        }
        string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
        private void Auto_Complete()
        {
            //Auto Complete search
            textBoxProductSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxProductSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            SqlConnection conSS = new SqlConnection(conStr);
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            col.Clear();
            conSS.Open();
            string sql = "SELECT * FROM Product";
            SqlCommand cmd = new SqlCommand(sql, conSS);
            SqlDataReader sdr = null;
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                col.Add(sdr["Code"].ToString());
                col.Add(sdr["Name"].ToString());

            }
            sdr.Close();
            textBoxProductSearch.AutoCompleteCustomSource = col;
            conSS.Close();
        }
        private void ProductLedger_Load(object sender, EventArgs e)
        {
            Auto_Complete();
            radioButtonInwards.Enabled = false;
            radioButtonOutwards.Enabled = false;
        }
        private void GetProductID()
        {
            try
            {
                textBoxProductID.Text = textBoxProductName.Text = textBoxProductCode.Text = "";
                int flag = 0;
               
                SqlConnection conww = new SqlConnection(conStr);
                conww.Open();
                string sqlww = "SELECT * FROM Product WHERE Name='" + textBoxProductSearch.Text + "' OR Code='" + textBoxProductSearch.Text + "'";
                SqlCommand cmdww = new SqlCommand(sqlww, conww);
                SqlDataReader sdrww = null;
                sdrww = cmdww.ExecuteReader();
                while (sdrww.Read())
                {
                    textBoxProductID.Text = sdrww["ID"].ToString();
                    textBoxProductName.Text = sdrww["Name"].ToString();
                    textBoxProductCode.Text = sdrww["Code"].ToString();
                    flag = 1;
                }
                sdrww.Close();
                conww.Close();

                if (flag==0)
                {
                    textBoxProductSearch.Text = "";
                    MessageBox.Show("Invalied Product Name or Product Code.\nPlease Input a Valid Product Name or Code.","Invalied Name or Code", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DataGrid(int id)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Purchase.PurchaseDate as 'Date', Purchase.PurchaseNo as 'InvoiceNo', Purchase.PurchaseQuantity as 'Quantity' FROM Purchase WHERE Purchase.PurchaseProductID = '" + id + "' ORDER BY Purchase.PurchaseDate";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewInwards.DataSource = dt;
            con.Close();
        }
        private void DataGridsales(int id)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Sales.SalesDate as 'Date', Sales.SalesNo as 'InvoiceNo', Sales.SalesQuantity as 'Quantity' FROM Sales WHERE Sales.SalesProductID = '" + id + "' ORDER BY Sales.SalesDate";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewOutwards.DataSource = dt;
            con.Close();
        }
        private void TempProductInwards()
        {
            foreach (DataGridViewRow row in dataGridViewInwards.Rows)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO TempProductInwards VALUES(@Date,@InvoiceNo,@Quantity,'"+textBoxProductName.Text+ "','" + textBoxProductCode.Text + "')", con))
                    {
                        cmd.Parameters.AddWithValue("@Date", row.Cells["Date"].Value);
                        cmd.Parameters.AddWithValue("@InvoiceNo", row.Cells["InvoiceNo"].Value);
                        cmd.Parameters.AddWithValue("@Quantity", row.Cells["Quantity"].Value);
                       
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            // MessageBox.Show("Records inserted.");
        }

        private void TempProductOutwards()
        {
            foreach (DataGridViewRow row in dataGridViewOutwards.Rows)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO TempProductOutwards VALUES(@Date,@InvoiceNo,@Quantity,'" + textBoxProductName.Text + "','" + textBoxProductCode.Text + "')", con))
                    {
                        cmd.Parameters.AddWithValue("@Date", row.Cells["Date"].Value);
                        cmd.Parameters.AddWithValue("@InvoiceNo", row.Cells["InvoiceNo"].Value);
                        cmd.Parameters.AddWithValue("@Quantity", row.Cells["Quantity"].Value);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            // MessageBox.Show("Records inserted.");
        }
        private void TempProductInwards_Outwards()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sql = @"TRUNCATE TABLE TempProductInwards;";
            sql += @"TRUNCATE TABLE TempProductOutwards";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void FrontPage()
        {
            ReportDocument cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            string rPath = @"C:\Reports\CrystalReportFrontPage.rpt";
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
        private void InsertData()
        {
            TempProductInwards_Outwards();
            TempProductInwards();
            TempProductOutwards();
            radioButtonInwards.Enabled = true;
            radioButtonOutwards.Enabled = true;
            FrontPage();
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            GetProductID();
            DataGrid(Convert.ToInt32(textBoxProductID.Text));
            DataGridsales(Convert.ToInt32(textBoxProductID.Text));
            InsertData();


        }

        private void radioButtonInwards_CheckedChanged(object sender, EventArgs e)
        {
            ReportDocument cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            string rPath = @"C:\Reports\CrystalReportProductLedgerInwards.rpt";
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

        private void radioButtonOutwards_CheckedChanged(object sender, EventArgs e)
        {
            ReportDocument cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            string rPath = @"C:\Reports\CrystalReportProductLedgerOutwards.rpt";
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
    }
}