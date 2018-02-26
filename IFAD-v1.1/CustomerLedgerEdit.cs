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
    public partial class CustomerLedgerEdit : Form
    {
        public CustomerLedgerEdit()
        {
            InitializeComponent();
            textBoxReceivedAmount.KeyPress += new KeyPressEventHandler(textBoxReceivedAmount_KeyPress);
           
        }
        public static int LedgerIDNew = CustomerLedger.LedgerID;
       
        private void Form_Load()
        {
            comboBoxPaymentType.Items.Add("Cash");
            comboBoxPaymentType.Items.Add("Chaque");
            dateTimePicker1.CustomFormat="yyyy-MM-dd";
            string PayMentType = "";
            double Credit = 0;
            double Debit = 0;
            double ReceivedAmount = 0;
            string ReceivedDate = "";
            string BankName = "";
            string ChequeNo = "";
            string ChequeDate = "";
            string Remarks = "";
            string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection connection = new SqlConnection(conStr);
            string query = "SELECT * FROM [CustomerLedger] WHERE ID = '" + LedgerIDNew + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                PayMentType = reader["PaymentType"].ToString();
                Credit = Convert.ToInt32(reader["Credit"]);
                Debit = Convert.ToInt32(reader["Debit"]);
                ReceivedDate = reader["ReceiveDate"].ToString();
                BankName = reader["BankName"].ToString();
                ChequeNo = reader["ChequeNo"].ToString();
                ChequeDate = reader["ChequeDate"].ToString();
                Remarks = reader["Remarks"].ToString();
            }
            reader.Close();
            connection.Close();

            if (Debit > 0)
            {
                radioPayment.Checked = true;
                radioRecived.Checked = false;
                ReceivedAmount = Debit;
            }
            if (Credit > 0)
            {
                radioPayment.Checked = false;
                radioRecived.Checked = true;
                ReceivedAmount = Credit;
            }
            if (PayMentType == "Cash")
            {
                comboBoxPaymentType.SelectedIndex = 0;
            }
            if (PayMentType == "Chaque")
            {
                comboBoxPaymentType.SelectedIndex = 1;
            }
            dateTimePicker1.Text = ReceivedDate;
            textBoxBankName.Text = BankName;
            textBoxChequeNo.Text = ChequeNo;
            dateTimePickerDate.Text = ChequeDate;
            textBoxReceivedAmount.Text = ReceivedAmount.ToString();
            textBoxRemarks.Text = Remarks;

        }
        private void CustomerLedger_Load(object sender, EventArgs e)
        {
            Form_Load();
            Auto_Complete();
            dateTimePickerDate.CustomFormat = "yyyy-MM-dd";
            DateTime today = DateTime.Today;
            dateTimePickerDate.Value = today;
            
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

        private void btnUpdate_Click(object sender, EventArgs e)
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
                else
                {
                    string date = dateTimePicker1.Text;
                    double ledger_credit = Convert.ToDouble(textBoxReceivedAmount.Text);
                    double ledger_debit = Convert.ToDouble(textBoxReceivedAmount.Text);
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
                        string query11 = "UPDATE [CustomerLedger] SET ReceiveDate = '" + date + "' , Debit='" + ledger_debit + "', Credit='" + ledger_credit + "', PaymentType = '" + PaymentType + "', BankName = '" + BankName + "', ChequeNo='" + ChequeNo + "', ChequeDate = '" + ChequeDate + "', Remarks = '" + ledger_remarks + "' WHERE ID ='"+ LedgerIDNew + "'";
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

                            MessageBox.Show("Payment Update Successfully !");
                            
                        }
                    }

                    if (radioRecived.Checked == false && radioPayment.Checked == true)
                    {
                        ledger_credit = 0.0;

                        string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
                        SqlConnection connection = new SqlConnection(conStr);
                        string query11 = "UPDATE [CustomerLedger] SET ReceiveDate='" + date + "',Debit='" + ledger_debit + "',Credit='" + ledger_credit + "',PaymentType = '" + PaymentType + "',BankName = '" + BankName + "',ChequeNo='" + ChequeNo + "',ChequeDate = '" + ChequeDate + "',Remarks = '" + ledger_remarks + "' WHERE ID='" + LedgerIDNew + "'";
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

                            MessageBox.Show("Received Update Successfully !");

                        }
                    }
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }
    }
}
