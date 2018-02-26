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
    public partial class StockSummary : Form
    {
        public StockSummary()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
        private void StockSummary_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
           
            DateTime today = DateTime.Today;
            dateTimePicker1.Value = today;
            dateTimePicker2.Value = today;
           
            

        }
        
        private void DataGridPurchase(string date1, string date2)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT purchase_details.pur_dtl_prod_id as 'ProID', SUM(purchase_details.pur_dtl_prod_qty) as 'InwardsQuantity',(SUM(purchase_details.pur_dtl_prod_price_total)/SUM(purchase_details.pur_dtl_prod_qty)) as 'InwardsRate',SUM(purchase_details.pur_dtl_prod_price_total) as 'InwardsValue' FROM purchase_details WHERE purchase_details.pur_date BETWEEN '" + date1 + "' AND '" + date2 + "' GROUP BY purchase_details.pur_dtl_prod_id";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewStuckSummary.DataSource = dt;
            con.Close();
        }
        private void DataGridSales(string date1, string date2)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT sales_details.sales_dtl_prod_id as 'ProIDOut', SUM(sales_details.sales_dtl_prod_qty) as 'OutwardsQuantity',(SUM(sales_details.sales_dtl_prod_price_total)/SUM(sales_details.sales_dtl_prod_qty)) as 'OutwardsRate', SUM(sales_details.sales_dtl_prod_price_total) as 'OutwardsValue' FROM sales_details WHERE sales_details.sales_date BETWEEN '" + date1 + "' AND '" + date2 + "' GROUP BY sales_details.sales_dtl_prod_id";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewSales.DataSource = dt;
            con.Close();
        }
        private void DataGridOpenPurchase(string date1, string date2)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT purchase_details.pur_dtl_prod_id as 'PurchaseProID', SUM(purchase_details.pur_dtl_prod_qty) as 'PurchaseQuantity',(SUM(purchase_details.pur_dtl_prod_price_total)/SUM(purchase_details.pur_dtl_prod_qty)) as 'PurchaseRate',SUM(purchase_details.pur_dtl_prod_price_total) as 'PurchaseValue' FROM purchase_details WHERE purchase_details.pur_date BETWEEN '" + date1 + "' AND '" + date2 + "' GROUP BY purchase_details.pur_dtl_prod_id";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewOpenPurchase.DataSource = dt;
            con.Close();
        }
        private void DataGridOpenSale(string date1, string date2)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT sales_details.sales_dtl_prod_id as 'SalesProID', SUM(sales_details.sales_dtl_prod_qty) as 'SalesQuantity',(SUM(sales_details.sales_dtl_prod_price_total)/SUM(sales_details.sales_dtl_prod_qty)) as 'SalesRate', SUM(sales_details.sales_dtl_prod_price_total) as 'SalesValue' FROM sales_details WHERE sales_details.sales_date BETWEEN '" + date1 + "' AND '" + date2 + "' GROUP BY sales_details.sales_dtl_prod_id";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewOpenSales.DataSource = dt;
            con.Close();
        }
        private void AddProductID()
        {
            con.Open();
            string sql = @"INSERT INTO TempStockSummary(ProductID) SELECT pro_id FROM product";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void UpdateInwards()
        {
            foreach (DataGridViewRow row in dataGridViewStuckSummary.Rows)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE TempStockSummary SET InwardsQuantity = @InwardsQuantity, InwardsRate=@InwardsRate, InwardsValue=@InwardsValue, StartDate='"+ dateTimePicker1.Text+ "', EndDate='"+ dateTimePicker2.Text + "' WHERE ProductID = @ProID", con))
                    {
                        cmd.Parameters.AddWithValue("@ProID", row.Cells["ProID"].Value);
                        cmd.Parameters.AddWithValue("@InwardsQuantity", row.Cells["InwardsQuantity"].Value);
                        cmd.Parameters.AddWithValue("@InwardsRate", row.Cells["InwardsRate"].Value);
                        cmd.Parameters.AddWithValue("@InwardsValue", row.Cells["InwardsValue"].Value);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }
        private void UpdateOutwards()
        {
            foreach (DataGridViewRow row in dataGridViewSales.Rows)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE TempStockSummary SET OutwardsQuantity = @OutwardsQuantity, OutwardsRate=@OutwardsRate, OutwardsValue=@OutwardsValue, StartDate='" + dateTimePicker1.Text + "', EndDate='" + dateTimePicker2.Text + "' WHERE ProductID = @ProIDOut", con))
                    {
                        cmd.Parameters.AddWithValue("@ProIDOut", row.Cells["ProIDOut"].Value);
                        cmd.Parameters.AddWithValue("@OutwardsQuantity", row.Cells["OutwardsQuantity"].Value);
                        cmd.Parameters.AddWithValue("@OutwardsRate", row.Cells["OutwardsRate"].Value);
                        cmd.Parameters.AddWithValue("@OutwardsValue", row.Cells["OutwardsValue"].Value);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }
        private void UpdateOpenPurchase()
        {
            foreach (DataGridViewRow row in dataGridViewOpenPurchase.Rows)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE TempStockSummary SET PurchaseQuantity = @PurchaseQuantity, PurchaseRate=@PurchaseRate, PurchaseValue=@PurchaseValue, StartDate='" + dateTimePicker1.Text + "', EndDate='" + dateTimePicker2.Text + "' WHERE ProductID = @PurchaseProID", con))
                    {
                        cmd.Parameters.AddWithValue("@PurchaseProID", row.Cells["PurchaseProID"].Value);
                        cmd.Parameters.AddWithValue("@PurchaseQuantity", row.Cells["PurchaseQuantity"].Value);
                        cmd.Parameters.AddWithValue("@PurchaseRate", row.Cells["PurchaseRate"].Value);
                        cmd.Parameters.AddWithValue("@PurchaseValue", row.Cells["PurchaseValue"].Value);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }

        private void UpdateOpenSales()
        {
            foreach (DataGridViewRow row in dataGridViewOpenSales.Rows)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE TempStockSummary SET SalesQuantity = @SalesQuantity, SalesRate=@SalesRate, SalesValue=@SalesValue, StartDate='" + dateTimePicker1.Text + "', EndDate='" + dateTimePicker2.Text + "' WHERE ProductID = @SalesProID", con))
                    {
                        cmd.Parameters.AddWithValue("@SalesProID", row.Cells["SalesProID"].Value);
                        cmd.Parameters.AddWithValue("@SalesQuantity", row.Cells["SalesQuantity"].Value);
                        cmd.Parameters.AddWithValue("@SalesRate", row.Cells["SalesRate"].Value);
                        cmd.Parameters.AddWithValue("@SalesValue", row.Cells["SalesValue"].Value);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }
        public void Truncate()
        {
            con.Open();
            string sql = @"TRUNCATE TABLE TempStockSummary";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void PrintReport()
        {
            
            ReportDocument cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            string rPath = @"C:\Reports\CrystalReportStockSummary.rpt";
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
           Truncate();
           AddProductID();
            string date1 = dateTimePicker1.Text;
            string date2 = dateTimePicker2.Text;

            DataGridPurchase(date1, date2);
            DataGridSales(date1, date2);
            DataGridOpenPurchase("2016-01-01", date1);
            DataGridOpenSale("2016-01-01", date1);

            UpdateOpenPurchase();
            UpdateOpenSales();
            UpdateInwards();
            UpdateOutwards();

            PrintReport();


        }
    }
}
