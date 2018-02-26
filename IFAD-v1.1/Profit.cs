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
    public partial class Profit : Form
    {
        public Profit()
        {
            InitializeComponent();
        }

        private void Profit_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            DateTime today = DateTime.Today;
            dateTimePicker1.Value = today;
            dateTimePicker2.Value = today;
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
        private void DataGrid(string date1, string date2)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT sales_details.sales_dtl_sales_no as 'Invoice_No', product.pro_name as 'Product_Name', sales_details.sales_dtl_prod_id as 'Product_ID', sales_details.sales_dtl_prod_qty as 'Quantity', sales_details.sales_dtl_prod_purchase_price as 'Purchase_Price',sales_details.sales_dtl_prod_sale_price  as 'Sales_Price', sales_details.sales_dtl_prod_discount as 'Sales_Discount', sales_details.sales_dtl_prod_price_total as 'Sales_Total', (sales_details.sales_dtl_prod_purchase_price*sales_details.sales_dtl_prod_qty) as 'Purchase_Total',  (sales_details.sales_dtl_prod_price_total-(sales_details.sales_dtl_prod_purchase_price*sales_details.sales_dtl_prod_qty)) as 'Gross_Profit' FROM sales_details, product  WHERE sales_details.sales_dtl_prod_id=product.pro_id AND sales_details.sales_date BETWEEN '" + date1 + "' AND '" + date2 + "' ORDER BY sales_details.sales_date";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewProfit.DataSource = dt;
            con.Close();
        }
        private void Temp_Profit_Stock()
        {
            string date1 = dateTimePicker1.Text;
            string date2 = dateTimePicker2.Text;
            foreach (DataGridViewRow row in dataGridViewProfit.Rows)
            {
                //string constring = @"SERVER = Kamrul-pc; DATABASE =pos; user id = sa; PASSWORD = 123";
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Temp_Profit VALUES('"+ date1 + "','" + date2 + "', @Invoice_No,@Product_Name,@Product_ID,@Quantity,@Purchase_Price,@Sales_Price,@Sales_Discount,@Sales_Total,@Purchase_Total,@Gross_Profit)", con))
                    {
                        cmd.Parameters.AddWithValue("@Invoice_No", row.Cells["Invoice_No"].Value);
                        cmd.Parameters.AddWithValue("@Product_Name", row.Cells["Product_Name"].Value);
                        cmd.Parameters.AddWithValue("@Product_ID", row.Cells["Product_ID"].Value);
                        cmd.Parameters.AddWithValue("@Quantity", row.Cells["Quantity"].Value);
                        cmd.Parameters.AddWithValue("@Purchase_Price", row.Cells["Purchase_Price"].Value);
                        cmd.Parameters.AddWithValue("@Sales_Price", row.Cells["Sales_Price"].Value);
                        cmd.Parameters.AddWithValue("@Sales_Discount", row.Cells["Sales_Discount"].Value);
                        cmd.Parameters.AddWithValue("@Sales_Total", row.Cells["Sales_Total"].Value);
                        cmd.Parameters.AddWithValue("@Purchase_Total", row.Cells["Purchase_Total"].Value);
                        cmd.Parameters.AddWithValue("@Gross_Profit", row.Cells["Gross_Profit"].Value);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            //MessageBox.Show("Records inserted.");
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string date1 = dateTimePicker1.Text;
            string date2 = dateTimePicker2.Text;
            DataGrid(date1, date2);
            PrintReport();
        }

        private void Temp_Profit_Stock_Truncket()
        {
            con.Open();
            string sql = @"TRUNCATE TABLE Temp_Profit;";
            sql += @"TRUNCATE TABLE Temp_Income_Expensive";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        
        private double Get_Income()
        {
            double income = 0;
            string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection connection = new SqlConnection(conStr);
            string query = "SELECT * FROM Income WHERE Date BETWEEN '" + dateTimePicker1.Text + "' AND '" + dateTimePicker2.Text + "' ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                income = income + Convert.ToDouble(reader["Amount"]);
            }
            reader.Close();
            connection.Close();
            return income;
        }
        private double Get_Expensive()
        {
            double expensive = 0;
            string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection connection = new SqlConnection(conStr);
            string query = "SELECT * FROM Expensive WHERE Date BETWEEN '" + dateTimePicker1.Text + "' AND '" + dateTimePicker2.Text + "' ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                expensive = expensive + Convert.ToDouble(reader["Amount"]);
            }
            reader.Close();
            connection.Close();
            return expensive;
        }
        private void Temp_Income_Expensive_Stock(double income, double expensive)
        {
            string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection connection = new SqlConnection(conStr);
            string query = "INSERT INTO Temp_Income_Expensive VALUES('" + income + "','" + expensive + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        private void PrintReport()
        {
            Temp_Profit_Stock_Truncket();
            Temp_Profit_Stock();
            double income = Get_Income();
            double expensive = Get_Expensive();
            Temp_Income_Expensive_Stock(income, expensive);

            ReportDocument cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            string rPath = @"C:\Reports\CrystalReportProfit.rpt";
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
