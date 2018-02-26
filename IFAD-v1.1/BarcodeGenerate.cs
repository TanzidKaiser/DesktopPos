using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.Shared;

namespace IFAD_v1._1
{
    public partial class BarcodeGenerate : Form
    {
        ReportDocument crystal = new ReportDocument();
        public BarcodeGenerate()
        {
            InitializeComponent();
        }
        private int CodeAldeary(string procode)
        {
            string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection connection = new SqlConnection(conStr);
            string query = "SELECT * FROM [Product] WHERE Code='" + procode+"'";
            SqlCommand command1 = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command1.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                i++; 
            }
           
            reader.Close();
            connection.Close();
            return i;
        }
        private void buttonShowBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxProductCode.Text=="")
            {
                MessageBox.Show("Please Fill Product Code....!!!");
                return;
            }
            if (textBoxNumberOfCopies.Text == "")
            {
                MessageBox.Show("Please Fill Number Of Copies....!!!");
                return;
            }
            if (CodeAldeary(textBoxFProductCode.Text)==0)
            {
               MessageBox.Show("Unknown Product code....!!!");
               return;
            }


                string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
                SqlConnection connection = new SqlConnection(conStr);
                string sql = "Select * FROM Product WHERE Code = '" + textBoxFProductCode.Text + "'";
                for (int i = 1; i < int.Parse(textBoxNumberOfCopies.Text); i++)
                {
                    sql = sql + "Union ALL Select * FROM Product WHERE Code = '" + textBoxFProductCode.Text + "'";
                }
                SqlDataAdapter sda = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                sda.Fill(ds, "Product");
                crystal.SetDataSource(ds);
                crystalReportViewer1.ReportSource = crystal;
                crystalReportViewer1.RefreshReport();
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
        }
        private void Auto_Complete()
        {
            //Auto Complete search
            textBoxProductCode.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxProductCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
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
            textBoxProductCode.AutoCompleteCustomSource = col;
            conSS.Close();
        }

        private bool IsNumeric(string input)
        {
            int test;
            return int.TryParse(input, out test);
        }

        public string ReportPaths = ReportPath.rPath;
        private void BarcodeGenerate_Load(object sender, EventArgs e)
        {
            Auto_Complete();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            // string rPath = @"C:\Reports\CrystalReportBarcodeGenerate.rpt";
            string rPath = ReportPaths + "CrystalReportBarcodeGenerateA4.rpt";
            crystal.Load(rPath);
            crConnectionInfo.ServerName = ConfigurationManager.ConnectionStrings["cryServer"].ToString();
            crConnectionInfo.DatabaseName = ConfigurationManager.ConnectionStrings["cryDatabase"].ToString();
            crConnectionInfo.UserID = ConfigurationManager.ConnectionStrings["cryUserID"].ToString();
            crConnectionInfo.Password = ConfigurationManager.ConnectionStrings["cryPass"].ToString();

            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in crystal.Database.Tables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }

            //crystalReportViewer1.ReportSource = cryRpt;
            //crystalReportViewer1.RefreshReport();
            //crystal.Load(@"C:\Reports\CrystalReportBarcodeGenerate.rpt");
        }

        private void buttonShowAllBarcode_Click(object sender, EventArgs e)
        {
            string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection connection = new SqlConnection(conStr);
            SqlDataAdapter sda = new SqlDataAdapter("Select * FROM Product", connection);
            DataSet ds = new DataSet();
            sda.Fill(ds, "Product");
            crystal.SetDataSource(ds);
            crystalReportViewer1.ReportSource = crystal;
            crystalReportViewer1.RefreshReport();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxProductCode_TextChanged(object sender, EventArgs e)
        {
            //string spro_id = textBoxProductCode.Text;
            if (IsNumeric(textBoxProductCode.Text) == false)
            {
                string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
                SqlConnection conww = new SqlConnection(conStr);
                conww.Open();
                string sqlww = "SELECT * FROM Product WHERE Name='" + textBoxProductCode.Text + "' OR Code='" + textBoxProductCode.Text + "'";
                SqlCommand cmdww = new SqlCommand(sqlww, conww);
                SqlDataReader sdrww = null;
                sdrww = cmdww.ExecuteReader();
                while (sdrww.Read())
                {
                    textBoxFProductCode.Text = sdrww["Code"].ToString();
                }
                sdrww.Close();
                conww.Close();
            }
        }
    }
}
