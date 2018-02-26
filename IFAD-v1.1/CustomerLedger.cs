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
    public partial class CustomerLedger : Form
    {

        public CustomerLedger()
        {
            InitializeComponent();
            textBoxReceivedAmount.KeyPress += new KeyPressEventHandler(textBoxReceivedAmount_KeyPress);
            string query12 = "SELECT * FROM Customer ORDER BY CustomerName";
            fillCombo(comboBoxCustomerName, query12, "CustomerName", "CustomerID");
        }
        public static int LedgerID = 0;
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
            Int32.TryParse(comboBoxCustomerName.SelectedValue.ToString(), out id);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ID as 'ID', ReceiveDate as 'Date', InvoiceNo as 'Invoice No', Debit as 'Ledger Debit', Credit as 'Ledger Credit',PaymentType as 'Payment Type',BankName as 'Bank Name', ChequeNo as 'Cheque No',ChequeDate as 'Cheque Date', Remarks as 'Remarks' FROM CustomerLedger WHERE CustomerID = '" + id+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void Form_Load()
        {
            DateTime now = DateTime.Now;
            textBoxDate.Text = now.ToString("yyyy-MM-dd");
            textBoxDate.ReadOnly = true;
        }
        private void CustomerLedger_Load(object sender, EventArgs e)
        {
            Form_Load();
            Auto_Complete();
            dateTimePickerDate.CustomFormat = "yyyy-MM-dd";
            DateTime today = DateTime.Today;
            dateTimePickerDate.Value = today;
            comboBoxPaymentType.Items.Add("Cash");
            comboBoxPaymentType.Items.Add("Chaque");

            comboBoxPaymentType.SelectedIndex = 0;
        }
        private void Auto_Complete()
        {
            textBoxBankName.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxBankName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            col.Clear();
            col.Add("AB Bank Limited");
            col.Add("Agrani Bank Limited");
            col.Add("Al-Arafah Islami Bank Limited");
            col.Add("Bangladesh Commerce Bank Limited");
            col.Add("Bangladesh Development Bank Limited");
            col.Add("Bangladesh Krishi Bank");
            col.Add("Bank Al-Falah Limited");
            col.Add("Bank Asia Limited");
            col.Add("BASIC Bank Limited");
            col.Add("BRAC Bank Limited");
            col.Add("Citibank N.A");
            col.Add("Commercial Bank of Ceylon Limited");
            col.Add("Dhaka Bank Limited");
            col.Add("Dutch-Bangla Bank Limited");
            col.Add("Eastern Bank Limited");
            col.Add("EXIM Bank Limited");
            col.Add("First Security Islami Bank Limited");
            col.Add("Habib Bank Ltd.");
            col.Add("ICB Islamic Bank Ltd.");
            col.Add("IFIC Bank Limited");
            col.Add("Islami Bank Bangladesh Ltd");
            col.Add("Jamuna Bank Ltd");
            col.Add("Janata Bank Limited");
            col.Add("Meghna Bank Limited");
            col.Add("Mercantile Bank Limited");
            col.Add("Midland Bank Limited");
            col.Add("Mutual Trust Bank Limited");
            col.Add("National Bank Limited");
            col.Add("National Bank of Pakistan");
            col.Add("National Credit & Commerce Bank Ltd");
            col.Add("NRB Commercial Bank Limited");
            col.Add("One Bank Limited");
            col.Add("Premier Bank Limited");
            col.Add("Prime Bank Ltd");
            col.Add("Pubali Bank Limited");
            col.Add("Rajshahi Krishi Unnayan Bank");
            col.Add("Rupali Bank Limited");
            col.Add("Shahjalal Bank Limited");
            col.Add("Shimanto Bank Limited");
            col.Add("Social Islami Bank Ltd.");
            col.Add("Sonali Bank Limited");
            col.Add("South Bangla Agriculture & Commerce Bank Limited");
            col.Add("Southeast Bank Limited");
            col.Add("Standard Bank Limited");
            col.Add("Standard Chartered Bank");
            col.Add("State Bank of India");
            col.Add("The City Bank Ltd.");
            col.Add("The Hong Kong and Shanghai Banking Corporation. Ltd.");
            col.Add("Trust Bank Limited");
            col.Add("Union Bank Limited");
            col.Add("United Commercial Bank Limited");
            col.Add("Uttara Bank Limited");
            col.Add("Woori Bank");
            textBoxBankName.AutoCompleteCustomSource = col;
        }
        private void comboBoxCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxPreviousDue.Text = textBoxReceivedAmount.Text = textBoxRemarks.Text = "";
            int id;
            Int32.TryParse(comboBoxCustomerName.SelectedValue.ToString(), out id);

            double ledger_debit = 0.0;
            double ledger_credit = 0.0;
            double Adjustment = 0.0;
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
                Adjustment = Adjustment + Convert.ToDouble(reader12["Adjustment"]);

            }
            reader12.Close();
            con.Close();
            textBoxPreviousDue.Text = ((ledger_debit - ledger_credit) + Adjustment).ToString();
            DataGrid();
        }

        private void btnAddBuyer_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (radioPayment.Checked == false && radioRecived.Checked == false)
                {
                    MessageBox.Show("Please Select Payment Type");
                }
                else if (textBoxReceivedAmount.Text == "")
                {
                    MessageBox.Show("Please Input Received Amount");
                }
                else {
                    int id;
                    Int32.TryParse(comboBoxCustomerName.SelectedValue.ToString(), out id);
                    string date = textBoxDate.Text;
                    string ledger_invoice_no = "";
                    double ledger_credit = Convert.ToDouble(textBoxReceivedAmount.Text);
                    double ledger_debit = Convert.ToDouble(textBoxReceivedAmount.Text);
                    string date1 = "0000-00-00";
                    string ledger_remarks = textBoxRemarks.Text;
                    string BankName = "";
                    string ChequeNo = "";
                    string ChequeDate = "";
                    string PaymentType = comboBoxPaymentType.Text;
                    if (comboBoxPaymentType.Text == "Chaque")
                    {
                        BankName = textBoxBankName.Text;
                        ChequeNo = textBoxChequeNo.Text;
                        ChequeDate = dateTimePickerDate.Text;
                    }

                    if (radioRecived.Checked == true && radioPayment.Checked == false)
                    {
                        ledger_debit = 0.0;

                        string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
                        SqlConnection connection = new SqlConnection(conStr);
                        string query11 = "INSERT INTO [CustomerLedger](ReceiveDate,CustomerID,InvoiceNo,Debit,Credit,PaymentType,BankName,ChequeNo,ChequeDate,Remarks,NextPaymentDate,IsPreviousDue) VALUES('" + date + "','" + id + "','" + ledger_invoice_no + "','" + ledger_debit + "','" + ledger_credit + "','" + PaymentType + "','" + BankName + "','" + ChequeNo + "','" + ChequeDate + "','" + ledger_remarks + "','" + date1 + "','1')";
                        SqlCommand command = new SqlCommand(query11, connection);
                        connection.Open();
                        int rowEffict11 = command.ExecuteNonQuery();
                        connection.Close();
                        if (rowEffict11 > 0)
                        {
                            textBoxBankName.Text = "";
                            textBoxChequeNo.Text = "";
                            dateTimePickerDate.Text = "";
                            textBoxReceivedAmount.Text = "";
                            textBoxRemarks.Text = "";

                            DataGrid();
                            MessageBox.Show("Payment Receive Successfully !");

                        }
                    }

                    if (radioRecived.Checked == false && radioPayment.Checked == true)
                    {
                        ledger_credit = 0.0;

                        string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
                        SqlConnection connection = new SqlConnection(conStr);
                        string query11 = "INSERT INTO [CustomerLedger](ReceiveDate,CustomerID,InvoiceNo,Debit,Credit,PaymentType,BankName,ChequeNo,ChequeDate,Remarks,NextPaymentDate,IsPreviousDue) VALUES('" + date + "','" + id + "','" + ledger_invoice_no + "','" + ledger_debit + "','" + ledger_credit + "','" + PaymentType + "','" + BankName + "','" + ChequeNo + "','" + ChequeDate + "','" + ledger_remarks + "','" + date1 + "','1')";
                        SqlCommand command = new SqlCommand(query11, connection);
                        connection.Open();
                        int rowEffict11 = command.ExecuteNonQuery();
                        connection.Close();
                        if (rowEffict11 > 0)
                        {
                            textBoxBankName.Text = "";
                            textBoxChequeNo.Text = "";
                            dateTimePickerDate.Text = "";
                            textBoxReceivedAmount.Text = "";
                            textBoxRemarks.Text = "";

                            DataGrid();
                            MessageBox.Show("Payment Receive Successfully !");

                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxReceivedAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)Keys.Back) //The  character represents a backspace
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
        }

        private void comboBoxPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPaymentType.Text=="Cash")
            {
                labelBank.Enabled = false;
                textBoxBankName.Enabled = false;
                labelChaque.Enabled = false;
                textBoxChequeNo.Enabled = false;
                labelChaqueDate.Enabled = false;
                dateTimePickerDate.Enabled = false;
               
            }
            if (comboBoxPaymentType.Text == "Chaque")
            {
                labelBank.Enabled = true;
                textBoxBankName.Enabled = true;
                labelChaque.Enabled = true;
                textBoxChequeNo.Enabled = true;
                labelChaqueDate.Enabled = true;
                dateTimePickerDate.Enabled = true;
               
            }

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            LedgerID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            CustomerLedgerEdit cle = new CustomerLedgerEdit();
            cle.ShowDialog();
            DataGrid();

        }
    }
}
