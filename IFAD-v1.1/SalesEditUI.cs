using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IFAD_v1._1
{
    public partial class SalesEditUI : Form
    {
        public SalesEditUI()
        {
            InitializeComponent();
        }
        static double Discount = 0;
        static double VatPlusTotal = 0;
        static double OldSubTotal = 0;
        static double OldReceivedAmount = 0;
        static int ProID = 0;
        static int NewProID = 0;
        static int customerID = 0;
        static double OldQuantity = 0;
        static double vat_rate = 0;
        static double vat_total_byid = 0;

        string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
        public SalesEditUI(int SalesID, string SalesNo, string SalesDate, string SalesCustomerName, string Reference, string SalesRemarks,string ProductName, double SalesSalePrice, double SalesQuantity, double SalesProductDiscount, double SalesTotal,string SalesSoldBy,double SalesReceivedAmount, double SalesChangeAmount, double SalesVatTotal,string SalesPuechaseBy, string SalesPurchaseByContact,int ProductID,int CustomerID, int vatrate, int payment_type)
        {
            InitializeComponent();
            textBoxVatRate.Text = vatrate.ToString();
            Discount = SalesProductDiscount;

            txtDiscount.Text = SalesProductDiscount.ToString();
            txtSalesNo.Text = SalesNo;
            txtSalesID.Text = SalesID.ToString();
            txtProName.Text = ProductName;
            txtSalePrice.Text = SalesSalePrice.ToString();
            txtQuantity.Text = SalesQuantity.ToString();
            txtSubTotal.Text = (SalesSalePrice*SalesQuantity).ToString();

            dateTimePickerDate.Text = SalesDate;
            txtCustomer.Text = SalesCustomerName;
            txtRemarks.Text = SalesRemarks;
            txtReference.Text = Reference;
            txtVatTotal.Text = SalesVatTotal.ToString();
            txtReceiverAmount.Text = SalesReceivedAmount.ToString();
            txtChangeAmount.Text = SalesChangeAmount.ToString();
            txtPurchaseBy.Text = SalesPuechaseBy;
            txtPurchaseContact.Text = SalesPurchaseByContact;

            txtQuantity.KeyPress += new KeyPressEventHandler(txtQuantity_KeyPress);
            VatPlusTotal = SalesVatTotal;
            OldSubTotal = SalesTotal;
            OldReceivedAmount = SalesReceivedAmount;
            ProID = ProductID;
            NewProID = ProductID;
            customerID = CustomerID;
            OldQuantity = SalesQuantity;
            vat_total_byid = SalesVatTotal;
            if (payment_type == 1)
            {
                radioButtonCash.Checked = true;
            }
            else if (payment_type == 2)
            {
                radioButtonDue.Checked = true;
            }
            else
            {
                radioButtonCheque.Checked = true;
            }


        }
        private void Auto_Complete()
        {
            //Auto Complete search
            txtProName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtProName.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txtCustomer.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtCustomer.AutoCompleteSource = AutoCompleteSource.CustomSource;

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
            txtProName.AutoCompleteCustomSource = col;



            AutoCompleteStringCollection col2 = new AutoCompleteStringCollection();
            col2.Clear();

            string sql2 = "SELECT CustomerName FROM Customer";
            SqlCommand cmd2 = new SqlCommand(sql2, conSS);
            SqlDataReader sdr2 = null;
            sdr2 = cmd2.ExecuteReader();
            while (sdr2.Read())
            {
                col2.Add(sdr2["CustomerName"].ToString());

            }
            sdr2.Close();
            txtCustomer.AutoCompleteCustomSource = col2;

            conSS.Close();
        }
        private void SalesEditUI_Load(object sender, EventArgs e)
        {
            Auto_Complete();
            dateTimePickerDate.CustomFormat = "yyyy-MM-dd";
        }
        private int IsProductExist(string proname)
        {
            int exist = 0;
            SqlConnection conww = new SqlConnection(conStr);
            conww.Open();
            string sqlww = "SELECT * FROM Product WHERE Name ='" + proname + "' OR Code ='" + proname + "'";
            SqlCommand cmdww = new SqlCommand(sqlww, conww);
            SqlDataReader sdrww = null;
            sdrww = cmdww.ExecuteReader();
            while (sdrww.Read())
            {
                exist = Convert.ToInt32(sdrww["ID"]);
            }
            sdrww.Close();
            conww.Close();
            return exist;
        }
        private void txtProName_TextChanged(object sender, EventArgs e)
        {
            if (IsProductExist(txtProName.Text) > 0)
            {
                int spro_id = 0;
                SqlConnection conww = new SqlConnection(conStr);
                conww.Open();
                string sqlww = "SELECT * FROM Product WHERE Name ='" + txtProName.Text + "' OR Code ='" + txtProName.Text + "'";
                SqlCommand cmdww = new SqlCommand(sqlww, conww);
                SqlDataReader sdrww = null;
                sdrww = cmdww.ExecuteReader();
                while (sdrww.Read())
                {
                    spro_id =Convert.ToInt32(sdrww["ID"]);
                }
                NewProID = spro_id;
                sdrww.Close();
                conww.Close();

                try
                { 
                    SqlConnection connection12 = new SqlConnection(conStr);
                    string query12 = "SELECT * FROM Product WHERE ID = '" + spro_id + "'";
                    SqlCommand command112 = new SqlCommand(query12, connection12);

                    connection12.Open();
                    SqlDataReader reader12 = command112.ExecuteReader();

                    while (reader12.Read())
                    {
                        txtSalePrice.Text = reader12["SalePrice"].ToString();
                    }
                    reader12.Close();
                    connection12.Close();
                    

                }
                catch (Exception)
                {
                    txtSalePrice.Text = "";
                   
                }
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            double total = 0;
            if (txtQuantity.Text == "")
            {
                txtSubTotal.Text = total.ToString();
                txtVatTotal.Text = VatPlusTotal.ToString();
                txtReceiverAmount.Text = OldReceivedAmount.ToString();
            }

            if (txtQuantity.Text != "")
            {
                total = Convert.ToDouble(txtQuantity.Text)* Convert.ToDouble(txtSalePrice.Text);
                vat_rate = Convert.ToDouble(textBoxVatRate.Text);
                txtSubTotal.Text = total.ToString();
            //    txtVatTotal.Text = ((VatPlusTotal - OldSubTotal) + total).ToString();
                //txtVatTotal.Text = (total+(total/vat_rate)).ToString() ;       // Change
                txtVatTotal.Text = ((total + (vat_rate*total/100)) - Convert.ToDouble(txtDiscount.Text)).ToString();
               // txtReceiverAmount.Text = ((OldReceivedAmount - OldSubTotal) + total).ToString();
            }


            //////////////////////////////////////
            double new_invoice_total_all = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
            string query = "SELECT SUM(SalesVatTotal) As Total  from Sales WHERE SalesNo = '" + txtSalesNo.Text + "'";
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                new_invoice_total_all = Convert.ToDouble(reader["Total"]);
            }
            reader.Close();
            con.Close();

            double new_invoice_total_all_byid = vat_total_byid;
           

            label18.Text = ((new_invoice_total_all - new_invoice_total_all_byid) + Convert.ToDouble(txtVatTotal.Text)).ToString();



        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back) //The  character represents a backspace
            {
                e.Handled = false; //Do not reject the input
            }
            else
            {
                e.Handled = true; //Reject the input
            }
        }
        private void UpdateSales()
        {
            double sales_total = Convert.ToDouble(txtSubTotal.Text) - Convert.ToDouble(txtDiscount.Text);
            SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
            string querys = "UPDATE Sales SET SalesQuantity = '" + txtQuantity.Text + "', SalesTotal = '" + sales_total + "', SalesProductID = '" + NewProID + "', SalesSalePrice = '" + txtSalePrice.Text + "' , SalesProductDiscount = '" + txtDiscount.Text + "', SalesVatTotal = '" + txtVatTotal.Text + "' WHERE SalesID = '" + txtSalesID.Text + "'";
            SqlCommand commands = new SqlCommand(querys, cons);
            cons.Open();
            commands.ExecuteNonQuery();
            cons.Close();
        }
        int PaymentType = 0;
        private void UpdateTotalSales()
        {
            if (radioButtonCash.Checked)
            {
                PaymentType = 1;
            }
            if (radioButtonDue.Checked)
            {
                PaymentType = 2;
            }
            if (radioButtonCheque.Checked)
            {
                PaymentType = 3;
            }
            SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
            string querys = "UPDATE Sales SET SalesDate = '" + dateTimePickerDate.Text + "', SalesCustomerID = '" + customerID + "', SalesRemarks = '" + txtRemarks.Text + "', Reference = '" + txtReference.Text + "', SalesCustomerName = '" + txtCustomer.Text + "',SalesReceivedAmount = '" + txtReceiverAmount.Text + "',SalesChangeAmount = '" + txtChangeAmount.Text + "', SalesPuechaseBy = '" + txtPurchaseBy.Text + "', SalesPurchaseByContact = '" + txtPurchaseContact.Text + "', PaymentType = '"+ PaymentType + "' WHERE SalesNo = '" + txtSalesNo.Text + "'";
            SqlCommand commands = new SqlCommand(querys, cons);
            cons.Open();
            commands.ExecuteNonQuery();
            cons.Close();
        }
        private void UpdateCustomerLedger()
        {

            double ledger_credit = 0.0;
            if (Convert.ToDouble(txtReceiverAmount.Text) > Convert.ToDouble(label18.Text))
            {
                ledger_credit = Convert.ToDouble(label18.Text);
            }
            else if (Convert.ToDouble(txtReceiverAmount.Text) == 0.0)
            {
                //ledger_credit = Convert.ToDouble(label18.Text);
                ledger_credit = 0.0;
            }
            else {
                ledger_credit = Convert.ToDouble(txtReceiverAmount.Text);
            }

            string Remarks = "***Sales Edit";
            SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
           // string querys = "UPDATE CustomerLedger SET Debit = '" + txtVatTotal.Text + "', Credit = '" + txtReceiverAmount.Text + "', Remarks = '" + Remarks + "' WHERE InvoiceNo = '" + txtSalesNo.Text + "'";
            string querys = "UPDATE CustomerLedger SET Debit = '" + label18.Text + "', Credit = '" + ledger_credit + "', Remarks = '" + Remarks + "' WHERE InvoiceNo = '" + txtSalesNo.Text + "'";  //Change
            SqlCommand commands = new SqlCommand(querys, cons);
            cons.Open();
            commands.ExecuteNonQuery();
            cons.Close();
        }
        private void UpdatePdouctStock()
        {
            //Old Product Update
            double Stock = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
            string query = "SELECT * FROM Product WHERE ID = '" + ProID + "'";
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Stock = Convert.ToDouble(reader["Stock"]);
            }
            reader.Close();
            con.Close();
            Stock = (Stock + OldQuantity);
            SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
            string querys = "UPDATE Product SET Stock = '" + Stock + "' WHERE ID = '"+ProID+"'";
            SqlCommand commands = new SqlCommand(querys, cons);
            cons.Open();
            commands.ExecuteNonQuery();
            cons.Close();


            //New Product Update
            Stock = 0;
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
            query = "SELECT * FROM Product WHERE ID = '" + NewProID + "'";
            command = new SqlCommand(query, con);
            con.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Stock = Convert.ToDouble(reader["Stock"]);
            }
            reader.Close();
            con.Close();
            Stock = Stock - Convert.ToDouble(txtQuantity.Text);
            cons = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
            querys = "UPDATE Product SET Stock = '" + Stock + "' WHERE ID = '" + NewProID + "'";
            commands = new SqlCommand(querys, cons);
            cons.Open();
            commands.ExecuteNonQuery();
            cons.Close();

        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Are you sure, you will Edit this Item?", "Sales Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return;
            }
            else
            {
                try
                {
                    if (txtProName.Text=="")
                    {
                        MessageBox.Show("Please Select a Product");
                    }
                    else if (txtQuantity.Text=="")
                    {
                        MessageBox.Show("Please Input Product Quantity");
                    }
                    else if (txtReceiverAmount.Text == "")
                    {
                        MessageBox.Show("Please Input Received Amount");
                    }
                    
                    else
                    {
                        UpdateSales();
                        UpdateTotalSales();


                        UpdateCustomerLedger();
                        UpdatePdouctStock();
                        MessageBox.Show("Sales Update Successfully....!!!!");
                        Close();
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void txtCustomer_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conww = new SqlConnection(conStr);
            conww.Open();
            string sqlww = "SELECT * FROM Customer WHERE CustomerName ='" + txtCustomer.Text + "'";
            SqlCommand cmdww = new SqlCommand(sqlww, conww);
            SqlDataReader sdrww = null;
            sdrww = cmdww.ExecuteReader();
            while (sdrww.Read())
            {
                customerID = Convert.ToInt32(sdrww["CustomerID"]);
            }
            sdrww.Close();
            conww.Close();
        }

        private void txtReceiverAmount_TextChanged(object sender, EventArgs e)
        {
            if(txtReceiverAmount.Text == "")
            {
                txtReceiverAmount.Text = "0";
            }
            txtChangeAmount.Text = (Convert.ToDouble(label18.Text) - Convert.ToDouble(txtReceiverAmount.Text)).ToString();
        }
    }
}
