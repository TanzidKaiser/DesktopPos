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
    public partial class InExReport : Form
    {
        public InExReport()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
        private void Income_Enable_On()
        {
            dateTimePickerI1.Enabled = true;
            dateTimePickerI2.Enabled = true;
            buttonIncomeSearch.Enabled = true;
        }
        private void Expensive_Enable_On()
        {
            dateTimePickerE1.Enabled = true;
            dateTimePickerE2.Enabled = true;
            comboBoxExpenseType.Enabled = true;
            buttonExpensiveSearch.Enabled = true;
        }
        private void Income_Enable_Off()
        {
            dateTimePickerI1.Enabled = false;
            dateTimePickerI2.Enabled = false;
            buttonIncomeSearch.Enabled = false;
        }
        private void Expensive_Enable_Off()
        {
            dateTimePickerE1.Enabled = false;
            dateTimePickerE2.Enabled = false;
            comboBoxExpenseType.Enabled = false;
            buttonExpensiveSearch.Enabled = false;
        }
        private void DueList_Load(object sender, EventArgs e)
        {
           
            Income_Enable_On();
            Expensive_Enable_Off();
            dateTimePickerI1.CustomFormat = "yyyy-MM-dd";
            dateTimePickerI2.CustomFormat = "yyyy-MM-dd";
            dateTimePickerE1.CustomFormat = "yyyy-MM-dd";
            dateTimePickerE2.CustomFormat = "yyyy-MM-dd";
            DateTime today = DateTime.Today;
            dateTimePickerI1.Value = today;
            dateTimePickerI2.Value = today;
            dateTimePickerE1.Value = today;
            dateTimePickerE2.Value = today;

            comboBoxExpenseType.Items.Add("All-Expense");
            comboBoxExpenseType.Items.Add("General-Expense");
            comboBoxExpenseType.Items.Add("Special-Discount");
            comboBoxExpenseType.Items.Add("Customer-Payment");

            comboBoxExpenseType.SelectedIndex = 0;

        }

        private void radioButtonIncome_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonIncome.Checked==true)
            {
                Income_Enable_On();
                Expensive_Enable_Off();
            }
        }

        private void radioButtonExpensive_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonExpensive.Checked == true)
            {
                Income_Enable_Off();
                Expensive_Enable_On();
            }
        }
        
        private void DataGrid(string date1, string date2)
        {
            
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Date as 'Date', Description as 'Description', Remarks as 'Remarks',  Amount as 'Amount' FROM Income WHERE Date BETWEEN '" + date1 + "' AND '" + date2 + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewIncome.DataSource = dt;
            con.Close();
        }
        public string ReportPaths = ReportPath.rPath;
        private void Print_Income()
        {
            ReportDocument cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();

            //string rPath = @"C:\Reports\CrystalReportIncome.rpt";
            string rPath = ReportPaths + "CrystalReportIncome.rpt";
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
        private void Temp_Income_Truncket()
        {
            con.Open();
            string sql = @"TRUNCATE TABLE TempIncome";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void buttonIncomeSearch_Click(object sender, EventArgs e)
        {
            string date1 = dateTimePickerI1.Text;
            string date2 = dateTimePickerI2.Text;
            DataGrid(date1, date2);
            Temp_Income_Truncket();
            Temp_Income_Stock();
            Print_Income();
        }
        private void Temp_Income_Stock()
        {
            string date1 = dateTimePickerI1.Text;
            string date2 = dateTimePickerI2.Text;
            foreach (DataGridViewRow row in dataGridViewIncome.Rows)
            {
                //string constring = @"SERVER = Kamrul-pc; DATABASE =pos; user id = sa; PASSWORD = 123";
                using (SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO TempIncome VALUES(1,'" + date1 + "','" + date2 + "', @Date,@Description,@Remarks,@Amount)", con1))
                    {
                        cmd.Parameters.AddWithValue("@Date", row.Cells["Date"].Value);
                        cmd.Parameters.AddWithValue("@Description", row.Cells["Description"].Value);
                        cmd.Parameters.AddWithValue("@Remarks", row.Cells["Remarks"].Value);
                        cmd.Parameters.AddWithValue("@Amount", row.Cells["Amount"].Value);

                        con1.Open();
                        cmd.ExecuteNonQuery();
                        con1.Close();
                    }
                }
            }
           // MessageBox.Show("Records inserted.");
        }
        private void DataGrid_Expense(string date1, string date2)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Date as 'Date', ExpenseType as 'ExpenseType', Description as 'Description', Remarks as 'Remarks',  Amount as 'Amount' FROM Expense WHERE Date BETWEEN '" + date1 + "' AND '" + date2 + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewExpensive.DataSource = dt;
            con.Close();
        }

        private void DataGrid_Expense_Type(string date1, string date2, string ExpenseType)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Date as 'Date', ExpenseType as 'ExpenseType', Description as 'Description', Remarks as 'Remarks',  Amount as 'Amount' FROM Expense WHERE ExpenseType ='" + ExpenseType + "' AND Date BETWEEN '" + date1 + "' AND '" + date2 + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewExpensive.DataSource = dt;
            con.Close();
        }
        private void Temp_Expense_Truncket()
        {
            con.Open();
            string sql = @"TRUNCATE TABLE TempExpenseReport";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void Temp_Expense_Stock()
        {
            string dateE1 = dateTimePickerE1.Text;
            string dateE2 = dateTimePickerE2.Text;
            foreach (DataGridViewRow row in dataGridViewExpensive.Rows)
            {
                //string constring = @"SERVER = Kamrul-pc; DATABASE =pos; user id = sa; PASSWORD = 123";
                using (SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO TempExpenseReport VALUES(1,'" + dateE1 + "','" + dateE2 + "', @Date,@ExpenseType,@Description,@Remarks,@Amount)", con1))
                    {
                        cmd.Parameters.AddWithValue("@Date", row.Cells["Date"].Value);
                        cmd.Parameters.AddWithValue("@ExpenseType", row.Cells["ExpenseType"].Value);
                        cmd.Parameters.AddWithValue("@Description", row.Cells["Description"].Value);
                        cmd.Parameters.AddWithValue("@Remarks", row.Cells["Remarks"].Value);
                        cmd.Parameters.AddWithValue("@Amount", row.Cells["Amount"].Value);

                        con1.Open();
                        cmd.ExecuteNonQuery();
                        con1.Close();
                    }
                }
            }
            // MessageBox.Show("Records inserted.");
        }
        private void Print_Expense()
        {
            ReportDocument cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();

            //string rPath = @"C:\Reports\CrystalReportExpensive.rpt";
            string rPath = ReportPaths + "CrystalReportExpense.rpt";
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
        private void buttonExpensiveSearch_Click(object sender, EventArgs e)
        {
            string date1 = dateTimePickerE1.Text;
            string date2 = dateTimePickerE2.Text;
            if (comboBoxExpenseType.Text== "All-Expense")
            {
                DataGrid_Expense(date1, date2);
            }
            if (comboBoxExpenseType.Text == "General-Expense")
            {
                DataGrid_Expense_Type(date1, date2, "General-Expense");
            }
            if (comboBoxExpenseType.Text == "Special-Discount")
            {
                DataGrid_Expense_Type(date1, date2, "Special-Discount");
            }
            if (comboBoxExpenseType.Text == "Customer-Payment")
            {
                DataGrid_Expense_Type(date1, date2, "Customer-Payment");
            }
            Temp_Expense_Truncket();
            Temp_Expense_Stock();
            Print_Expense();
        }
    }
}
