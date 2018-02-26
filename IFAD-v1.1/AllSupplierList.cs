using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;


namespace IFAD_v1._1
{
    public partial class AllSupplierList : Form
    {
        public AllSupplierList()
        {
            InitializeComponent();
        }

        private void AllSupplierList_Load(object sender, EventArgs e)
        {
            PrintReport();
        }

        public string ReportPaths = ReportPath.rPath;

        private void PrintReport()
        {
            ReportDocument cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            string rPath = @"C:\IFAD-Reports\CrystalReportAllSupplierList.rpt";
            //string rPath = ReportPaths + "CrystalReportAllCustomerList";
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
