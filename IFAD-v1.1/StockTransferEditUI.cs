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
    public partial class StockTransferEditUI : Form
    {
        public StockTransferEditUI()
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
        int insertStock = 0;
        //int newTransferQty = TransferQuantity.ToString();
        string transferQuantity2 = "0";
        int transferQty = 0;
        int finalStock = 0;
        int newQty = 0;
        int addProduct = 0;

        string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
        public StockTransferEditUI(int TransferID, string TransferCompany, string TransferNo, string TransferDate, string TransferTime, string TransferTo, string TransferRemarks, string TransferReference, string TransferProductID, string TransferProductName, double TransferQuantity, string TransferBy, string TransferReceivedBy)
        {
            InitializeComponent();
            textHiddenId.Text = TransferProductID;
            
            txtTransferId.Text = TransferID.ToString();
            txtCompany.Text = TransferCompany;
           // Discount = SalesProductDiscount;
            
            txtTransferNo.Text = TransferNo.ToString();
            dateTimePickerTransferDate.Text = TransferDate;
            txtTransferTime.Text = TransferTime.ToString();
            txtTransferTo.Text = TransferTo;
            txtTransferRemarks.Text = TransferRemarks.ToString();
            txtTransferReference.Text = TransferReference.ToString();
           
            txtTransferProductId.Text = TransferProductID;
            txtProductName.Text = TransferProductName;
            txtTransferQuantity.Text = TransferQuantity.ToString();
            transferQty = Convert.ToInt32(TransferQuantity);
            txtTransferBy.Text = TransferBy;
            txtTransferReceived.Text = TransferReceivedBy;


            SqlConnection conww = new SqlConnection(conStr);
            conww.Open();
            string sqlww = "SELECT stock FROM Product WHERE Id ='" + textHiddenId.Text + "' ";
            SqlCommand cmdww = new SqlCommand(sqlww, conww);
            SqlDataReader sdrww = null;
            sdrww = cmdww.ExecuteReader();
            while (sdrww.Read())
            {
                txtHiddenQuantityOld.Text  = sdrww["stock"].ToString();
            }
            sdrww.Close();
            conww.Close();


            SqlConnection conww2 = new SqlConnection(conStr);
            conww2.Open();
            string sqlww2 = "SELECT transferquantity FROM StockTransfer WHERE transferId ='" + txtTransferId.Text + "' ";
            SqlCommand cmdww2 = new SqlCommand(sqlww2, conww2);
            SqlDataReader sdrww2 = null;
            sdrww2 = cmdww2.ExecuteReader();
            while (sdrww2.Read())
            {
                transferQuantity2  = sdrww2["transferquantity"].ToString();
            }
            sdrww2.Close();
            conww2.Close();


        }
        private void Auto_Complete()
        {
            //Auto Complete search
            txtProductName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtProductName.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txtTransferTime.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTransferTime.AutoCompleteSource = AutoCompleteSource.CustomSource;

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
            txtProductName.AutoCompleteCustomSource = col;

            conSS.Close();
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
     
        int addStock = 0;

        private void UpdateTransfer()
        {
           // double sales_total = Convert.ToDouble(txtSubTotal.Text) - Convert.ToDouble(txtDiscount.Text);
            SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
            string querys = "Update StockTransfer set [CompanyID] = '"+txtCompany.Text+"',[TransferNo] ='"+txtTransferNo.Text+"',[TransferDate] ='"+dateTimePickerTransferDate.Text+"',[TransferTime] ='"+ txtTransferTime.Text + "',[TransferTo] = '"+txtTransferTo.Text+"',[TransferRemarks] = '"+txtTransferRemarks.Text+"',[TransferReference] ='"+txtTransferReference.Text+"' ,[TransferProductID] = '"+txtTransferProductId.Text+"',[TransferQuantity] = '"+ newQty + "',[TransferBy] = '"+txtTransferBy.Text+"' ,[TransferReceivedBy] =  '"+txtTransferReceived.Text+"' where[TransferID] ='"+ txtTransferId.Text+"' ";
            SqlCommand commands = new SqlCommand(querys, cons);
            cons.Open();
            commands.ExecuteNonQuery();
            cons.Close();
        }

        private void UpdateByReturnProduct()
        {

            SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
            string querys = "Update product set [stock] = '" + addProduct + "' where[ID] ='" + txtTransferProductId.Text + "' ";
            SqlCommand commands = new SqlCommand(querys, cons);
            cons.Open();
            commands.ExecuteNonQuery();
            cons.Close();
        }
        int PaymentType = 0;

        private void UpdateProductDetails(string pro_id, double quantity)
        {
            SqlConnection connection1 = new SqlConnection(conStr);
            string query1 = "UPDATE Product SET Stock = '" + quantity + "' WHERE ID = '" + pro_id + "'";
            SqlCommand command1 = new SqlCommand(query1, connection1);
            connection1.Open();
            command1.ExecuteNonQuery();
            connection1.Close();

        }
      

       
        private void buttonUpdate_Click_1(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtTransferQuantity.Text) >= 0)
            {
                int newQuantitySum = Convert.ToInt32(txtHiddenFieldQuantityNew.Text) + Convert.ToInt32(txtTransferQuantity.Text);  // for check database quantity
                DialogResult dr = MessageBox.Show("Are you sure, you will Edit this Item?", "Transfer Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                {
                    return;
                }
                else
                {
                    try
                    {
                        if (txtTransferTo.Text == "")
                        {
                            MessageBox.Show("Please Select Transfer To");
                        }
                        else if (txtTransferQuantity.Text == "")
                        {
                            MessageBox.Show("Please Input Product Quantity");
                        }
                        else if (txtTransferProductId.Text == "")
                        {
                            MessageBox.Show("Please Input Transfer Product Id");
                        }

                        else
                        {

                            if ((textHiddenId.Text != txtTransferProductId.Text))
                            {
                                finalStock = transferQty + Convert.ToInt32(txtHiddenQuantityOld.Text);
                                // MessageBox.Show("Id is changed");
                                SqlConnection conww1 = new SqlConnection(conStr);
                                int matchid = 0;
                                int check = 0;
                                conww1.Open();
                                string sqlww1 = " select transferProductid from StockTransfer where transferNo = '" + txtTransferNo.Text + "'";
                                SqlCommand cmdww1 = new SqlCommand(sqlww1, conww1);
                                SqlDataReader sdrww1 = null;
                                sdrww1 = cmdww1.ExecuteReader();
                                while (sdrww1.Read())
                                {
                                    //spro_id = sdrww["ID"].ToString();
                                    string transferProductid = sdrww1["transferProductid"].ToString();
                                    if ((txtTransferProductId.Text == transferProductid))
                                    {
                                        check = 1;
                                    }

                                }
                                if (check == 1)
                                {
                                    MessageBox.Show("This product you can't change from here.");
                                }
                                if (Convert.ToInt32(txtHiddenFieldQuantityNew.Text) >= Convert.ToInt32(txtTransferQuantity.Text))
                                {
                                    if (txtHiddenFieldUpdatedTransferQty.Text == "")
                                    {
                                        txtHiddenFieldUpdatedTransferQty.Text = "0";
                                    }

                                    newQty = Convert.ToInt32(txtTransferQuantity.Text);
                                    addProduct = (Convert.ToInt32(txtHiddenFieldQuantityNew.Text) - Convert.ToInt32(txtTransferQuantity.Text));
                                    //MessageBox.Show("Methch id. you can just update stock table.");
                                    UpdateTransfer();
                                    UpdateProductDetails(textHiddenId.Text, finalStock);
                                    // UpdateByReturnProduct();

                                    //UpdateCustomerLedger();
                                    UpdateByReturnProduct();
                                    // UpdatePdouctStock();
                                    MessageBox.Show("Transfer Updated Successfully....!!!!");
                                    Close();

                                    matchid = 1;
                                    //break;
                                    // matchid = 1;
                                    // MessageBox.Show("This product you can't change from here.");




                                }
                                else
                                {

                                    MessageBox.Show("Please choose less quantity.");

                                }
                            }

                            else
                            {


                                SqlConnection conww1 = new SqlConnection(conStr);
                                int matchid = 0;
                                conww1.Open();
                                string sqlww1 = " select transferProductid from StockTransfer where transferNo = '" + txtTransferNo.Text + "'";
                                SqlCommand cmdww1 = new SqlCommand(sqlww1, conww1);
                                SqlDataReader sdrww1 = null;
                                sdrww1 = cmdww1.ExecuteReader();
                                while (sdrww1.Read())
                                {
                                    //spro_id = sdrww["ID"].ToString();
                                    string transferProductid = sdrww1["transferProductid"].ToString();
                                    if ((transferProductid == txtTransferProductId.Text) && (Convert.ToInt32(txtHiddenQuantityOld.Text) + transferQty) >= Convert.ToInt32(txtTransferQuantity.Text))
                                    {


                                        matchid = 1;
                                        //break;
                                    }



                                }
                                if (matchid != 1)
                                {
                                    // matchid = 1;
                                    MessageBox.Show("Please choose less quantity.");
                                }
                                else
                                {
                                    newQty = Convert.ToInt32(txtTransferQuantity.Text);
                                    finalStock = (Convert.ToInt32(txtHiddenQuantityOld.Text) + transferQty) - newQty;
                                    int checkOverflowQty = (Convert.ToInt32(txtHiddenQuantityOld.Text) + transferQty);
                                    if (checkOverflowQty >= Convert.ToInt32(txtTransferQuantity.Text))
                                    {
                                        // int addProduct = (Convert.ToInt32(txtHiddenQuantityOld.Text) - Convert.ToInt32(txtTransferQuantity.Text));
                                        //MessageBox.Show("Methch id. you can just update stock table.");
                                        UpdateTransfer();
                                        UpdateProductDetails(txtTransferProductId.Text, finalStock);

                                       // UpdateCustomerLedger();
                                       // UpdatePdouctStock();
                                        MessageBox.Show("Transfer Updated Successfully....!!!!");
                                        Close();

                                    }
                                    else
                                    {
                                        MessageBox.Show("Please choose less quantity.");
                                    }

                                }
                               

                            }


                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            else
            {
                MessageBox.Show("Negetive value not allowed.");
            }
        }

        private void TransferEditUI_Load(object sender, EventArgs e)
        {
            Auto_Complete();
            dateTimePickerTransferDate.CustomFormat = "yyyy-MM-dd";
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            string spro_id = txtProductName.Text;
            SqlConnection conww = new SqlConnection(conStr);
            conww.Open();
            string sqlww = "SELECT stock,Id FROM Product WHERE Name ='" + spro_id +"' ";
            SqlCommand cmdww = new SqlCommand(sqlww, conww);
            SqlDataReader sdrww = null;
            sdrww = cmdww.ExecuteReader();
            while (sdrww.Read())
            {
                //spro_id = sdrww["ID"].ToString();
                txtTransferProductId.Text = sdrww["ID"].ToString();
                txtHiddenFieldQuantityNew.Text = sdrww["stock"].ToString();
            }
            sdrww.Close();
            conww.Close();


            SqlConnection conww2 = new SqlConnection(conStr);
            conww2.Open();
            string sqlww2 = "select sum(TransferQuantity) as qty from StockTransfer where TransferProductID ='" + txtTransferProductId.Text + "' ";
            SqlCommand cmdww2 = new SqlCommand(sqlww2, conww2);
            SqlDataReader sdrww2 = null;
            sdrww2 = cmdww2.ExecuteReader();
            while (sdrww2.Read())
            {
                //spro_id = sdrww["ID"].ToString();
                txtHiddenFieldUpdatedTransferQty.Text = sdrww2["qty"].ToString();
           }
            sdrww2.Close();
            conww2.Close();

            //for check same id or not









        }
    }
}
