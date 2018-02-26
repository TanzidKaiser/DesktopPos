using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace IFAD_v1._1
{
    public partial class MainBody : Form
    {
 
        public MainBody()
        {
            InitializeComponent();
            MouseEvent();


        }
        public string currentuser = Login.loguser;
        public int UserID = Login.loguserID;
        public void MouseEvent()
        {
            btnMenuGroup1.MouseEnter += new EventHandler(btnMenuGroup1_MouseEnter);
            btnMenuGroup1.MouseLeave += new EventHandler(btnMenuGroup1_MouseLeave);
        }

        private void itemSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }


        private void viewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void purchaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login lin = new Login();
            lin.Show();
            Hide();

        }
      
        
        private void Down()
        {
            btnMenuGroup1.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.mmmm));
            btnMenuGroup2.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.mmmm));
            btnMenuGroup3.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.mmmm));
            btnMenuGroup5.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.mmmm));
            btnMenuGroup6.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.mmmm));
            btnMenuGroup7.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.mmmm));
            btnMenuGroup8.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.mmmm));
            btnMenuGroup9.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.mmmm));
            btnMenuGroup10.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.mmmm));
            btnMenuGroup11.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.mmmm));
            btnMenuGroup12.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.mmmm));
            btnMenuGroup13.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.mmmm));
            btnMenuGroup14.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.mmmm));
        }

        //public double Totalsell(string date1)
        //{
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
        //    double total = 0.0;
        //    string query = "SELECT Distinct(SalesNo), SalesVatTotal FROM Sales WHERE SalesDate = '" + date1 + "'";
        //    SqlCommand command = new SqlCommand(query, con);
        //    con.Open();
        //    SqlDataReader reader = command.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        total = total + Convert.ToDouble(reader["SalesVatTotal"]);
        //    }

        //    reader.Close();
        //    con.Close();
        //    return total;
        //}

        public double Totalsell(string date1)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
            double total = 0.0;
            //string query = "SELECT SUM(SalesVatTotal) FROM Sales WHERE SalesDate = '" + date1 + "'";
            string query = "SELECT CASE WHEN SUM(SalesVatTotal) IS NULL  THEN 0 ELSE SUM(SalesVatTotal) END FROM Sales WHERE SalesDate = '" + date1 + "'";
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            total = (double)command.ExecuteScalar();
            con.Close();
            return total;
        }
        public void UserSell()
        {
            var curr = DateTime.Now;
            DateTime today = DateTime.Today;
            string s = curr.ToString("HHmm");
            string date1 = today.ToString("yyyy-MM-dd");
            int time = Convert.ToInt32(s);
            if (time > 0001 && time <= 0500)
            {
                labelGoodMorning.Text = "Good Night";
            }
            if (time> 0500 && time <=1159)
            {
                labelGoodMorning.Text = "Good Morning";
            }
            if (time > 1159 && time <=1600)
            {
                labelGoodMorning.Text = "Good AfterNoon";
            }
            if (time > 1600 && time <= 2400)
            {
                labelGoodMorning.Text = "Good Evening";
            }
            labelAdmin.Text=currentuser;
            double total = Totalsell(date1);
            labelTodaysSell.Text = "Todays Sell";
            labelTodaysSellTK.Text ="TK. "+ total.ToString();
        }
        private void UserAccess()
        {

            bool c1 = false; bool c2 = false; bool c3 = false; bool c4 = false; bool c5 = false; bool c6 = false; bool c7 = false;
            bool c8 = false; bool c9 = false; bool c10 = false; bool c11 = false; bool c12 = false; bool c13 = false; bool c14 = false;
            bool c15 = false; bool c16 = false; bool c17 = false; bool c18 = false; bool c19 = false; bool c20 = false; bool c21 = false;
            bool c22 = false; bool c23 = false; bool c24 = false; bool c25 = false; bool c26 = false; bool c27 = false; bool c28 = false;
            bool c29 = false; bool c30 = false; bool c31 = false; bool c32 = false; bool c33 = false; bool c34 = false; bool c35 = false;
            bool c36 = false; bool c37 = false; bool c38 = false; bool c39 = false; bool c40 = false; bool c41 = false; bool c42 = false;
            bool c43 = false;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
            string query = "SELECT * FROM [UserAccessAreaNew] WHERE UserID = '" + UserID + "' ";
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader12 = command.ExecuteReader();

            while (reader12.Read())
            {
                c1 = Convert.ToBoolean(reader12["A1"]);
                c2 = Convert.ToBoolean(reader12["A2"]);
                c3 = Convert.ToBoolean(reader12["A3"]);
                c4 = Convert.ToBoolean(reader12["A4"]);
                c5 = Convert.ToBoolean(reader12["A5"]);
                c6 = Convert.ToBoolean(reader12["A6"]);
                c7 = Convert.ToBoolean(reader12["A7"]);
                c8 = Convert.ToBoolean(reader12["A8"]);
                c9 = Convert.ToBoolean(reader12["A9"]);
                c10 = Convert.ToBoolean(reader12["A10"]);
                c11 = Convert.ToBoolean(reader12["A11"]);
                c12 = Convert.ToBoolean(reader12["A12"]);
                c13 = Convert.ToBoolean(reader12["A13"]);
                c14 = Convert.ToBoolean(reader12["A14"]);
                c15 = Convert.ToBoolean(reader12["A15"]);
                c16 = Convert.ToBoolean(reader12["A16"]);
                c17 = Convert.ToBoolean(reader12["A17"]);
                c18 = Convert.ToBoolean(reader12["A18"]);
                c19 = Convert.ToBoolean(reader12["A19"]);
                c20 = Convert.ToBoolean(reader12["A20"]);
                c21 = Convert.ToBoolean(reader12["A21"]);
                c22 = Convert.ToBoolean(reader12["A22"]);
                c23 = Convert.ToBoolean(reader12["A23"]);
                c24 = Convert.ToBoolean(reader12["A24"]);
                c25 = Convert.ToBoolean(reader12["A25"]);
                c26 = Convert.ToBoolean(reader12["A26"]);
                c27 = Convert.ToBoolean(reader12["A27"]);
                c28 = Convert.ToBoolean(reader12["A28"]);
                c29 = Convert.ToBoolean(reader12["A29"]);
                c30 = Convert.ToBoolean(reader12["A30"]);
                c31 = Convert.ToBoolean(reader12["A31"]);
                c32 = Convert.ToBoolean(reader12["A32"]);
                c33 = Convert.ToBoolean(reader12["A33"]);
                c34 = Convert.ToBoolean(reader12["A34"]);
                c35 = Convert.ToBoolean(reader12["A35"]);
                c36 = Convert.ToBoolean(reader12["A36"]);
                c37 = Convert.ToBoolean(reader12["A37"]);
                c38 = Convert.ToBoolean(reader12["A38"]);
                c39 = Convert.ToBoolean(reader12["A39"]);
                c40 = Convert.ToBoolean(reader12["A40"]);
                c41 = Convert.ToBoolean(reader12["A41"]);
                c42 = Convert.ToBoolean(reader12["A42"]);
                c43 = Convert.ToBoolean(reader12["A43"]);
            }
            reader12.Close();
            con.Close();
            //Item
            btnItemSettings.Enabled = c1;
            btnItemAddInitialStock.Enabled = c2;
            buttonItemEdit.Enabled = c3;

            //Sales
            bntSalesLeft.Enabled = c4;
            buttonFOCSales.Enabled = c5;
            btnSalesReturnLeft.Enabled = c6;
            buttonInvoiceOrChallanPrint.Enabled = c7;
            buttonSalesEdit.Enabled = c8;

            //Purchase
            button10.Enabled = c9;
            buttonPurchaseReturn.Enabled = c10;
            buttonPurchaseEdit.Enabled = c11;

            //Damage Product
            buttonDamageProductReceive.Enabled = c12;
            buttonDamageProductReport.Enabled = c13;

            //settings
            buttonAddUser.Enabled = c14;
            buttonViewUser.Enabled = c15;
            buttonUnitType.Enabled = c16;
            buttonAddCompany.Enabled = c17;
            buttonCompanyInfo.Enabled = c18;
            buttonWarehouse.Enabled = c19;

            //Accounts
            buttonAddLedger.Enabled = c20;
            buttonIncome.Enabled = c21;
            buttonExpensive.Enabled = c22;
            buttonDueList.Enabled = c23;

            //Customer
            buttonAddCustomer.Enabled = c24;
            buttonCustomerList.Enabled = c25;

            //Supplier
            buttonAddSupplier.Enabled = c26;
            buttonSupplierList.Enabled = c27;

            //My Profile
            buttonUpdateProfile.Enabled = c28;

            //Barcode
            buttonBarcodeGenerate.Enabled = c29;

            //Profit
            buttonProfit.Enabled = c30;
            buttonProfitReport.Enabled = c31;

            //Reports
            buttonStockReport.Enabled = c32;
            buttonLedgerReport.Enabled = c33;
            buttonSalesReport.Enabled = c34;
            btnFocSales.Enabled = c35;
            buttonPurchase.Enabled = c36;
            buttonProductLedger.Enabled = c37;
            buttonSalesReturnReport.Enabled = c38;
            buttonPurchaseReturnReport.Enabled = c39;
            buttonStockSummary.Enabled = c40;
            btnPaymentReport.Enabled = c41;
            buttonCustLedgerSummary.Enabled = c42;
            buttonSalesSummary.Enabled = c43;

        }

        public void GetCompanyInfo()
        {
            int one = 1;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
            string query1 = "SELECT Image FROM [CompanyInformation] WHERE CompanyID = '" + one + "'";
            SqlCommand command1 = new SqlCommand(query1, conn);

            conn.Open();
            SqlDataReader reader1 = command1.ExecuteReader();

            while (reader1.Read())
            {
                
                byte[] img = (byte[])reader1["Image"];
                if (img == null)
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
            reader1.Close();
            conn.Close();

        }
        private void MainBody_Load_1(object sender, EventArgs e)
        {
            GetCompanyInfo();
            UserSell();
            //Sales saa = new Sales();
            //saa.Temp_Amount_Truncate();
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            Left = Top = 0;

            pnlMenuGroup1.Height = 35;
            pnlMenuGroup2.Height = 35;
            pnlMenuGroup3.Height = 35;
            pnlMenuGroup5.Height = 35;
            pnlMenuGroup6.Height = 35;
            pnlMenuGroup7.Height = 35;
            pnlMenuGroup8.Height = 35;
            pnlMenuGroup9.Height = 35;
            pnlMenuGroup10.Height = 35;
            pnlMenuGroup11.Height = 35;
            pnlMenuGroup12.Height = 35;
            pnlMenuGroup13.Height = 35;
            pnlMenuGroup14.Height = 35;
            Down();
            UserAccess();
            //Menu Off
            MenuOff();
        }
        private void MenuOff()
        {
           

        }
        private void btnMenuGroup1_Click_1(object sender, EventArgs e)
        {
            pnlMenuGroup2.Height = 35;
            pnlMenuGroup3.Height = 35;
            pnlMenuGroup5.Height = 35;
            pnlMenuGroup6.Height = 35;
            pnlMenuGroup7.Height = 35;
            pnlMenuGroup8.Height = 35;
            pnlMenuGroup9.Height = 35;
            pnlMenuGroup10.Height = 35;
            pnlMenuGroup11.Height = 35;
            pnlMenuGroup12.Height = 35;
            pnlMenuGroup13.Height = 35;
            pnlMenuGroup14.Height = 35;
            if (pnlMenuGroup1.Height == 35)
            {
               
                pnlMenuGroup1.Height = (35 * 4) + 2;
            }
            else
            {
               
                pnlMenuGroup1.Height = 35;
            }
        }
        private void btnMenuGroup2_Click_1(object sender, EventArgs e)
        {
            pnlMenuGroup1.Height = 35;
            pnlMenuGroup3.Height = 35;
            pnlMenuGroup5.Height = 35;
            pnlMenuGroup6.Height = 35;
            pnlMenuGroup7.Height = 35;
            pnlMenuGroup8.Height = 35;
            pnlMenuGroup9.Height = 35;
            pnlMenuGroup10.Height = 35;
            pnlMenuGroup11.Height = 35;
            pnlMenuGroup12.Height = 35;
            pnlMenuGroup13.Height = 35;
            pnlMenuGroup14.Height = 35;
            if (pnlMenuGroup2.Height == 35)
            { 
                pnlMenuGroup2.Height = (35 * 6) + 2;
            }
            else
            {
                pnlMenuGroup2.Height = 35;
            }
        }
        private void btnMenuGroup3_Click_1(object sender, EventArgs e)
        {
            pnlMenuGroup1.Height = 35;
            pnlMenuGroup2.Height = 35;
            pnlMenuGroup5.Height = 35;
            pnlMenuGroup6.Height = 35;
            pnlMenuGroup7.Height = 35;
            pnlMenuGroup8.Height = 35;
            pnlMenuGroup9.Height = 35;
            pnlMenuGroup10.Height = 35;
            pnlMenuGroup11.Height = 35;
            pnlMenuGroup12.Height = 35;
            pnlMenuGroup13.Height = 35;
            pnlMenuGroup14.Height = 35;
            if (pnlMenuGroup3.Height == 35)
            {
                pnlMenuGroup3.Height = (35 * 4) + 2;
            }
            else
            {
                pnlMenuGroup3.Height = 35;
            }
        }
        
        private void btnMenuGroup5_Click(object sender, EventArgs e)
        {
            pnlMenuGroup1.Height = 35;
            pnlMenuGroup2.Height = 35;
            pnlMenuGroup3.Height = 35;
            pnlMenuGroup6.Height = 35;
            pnlMenuGroup7.Height = 35;
            pnlMenuGroup8.Height = 35;
            pnlMenuGroup9.Height = 35;
            pnlMenuGroup10.Height = 35;
            pnlMenuGroup11.Height = 35;
            pnlMenuGroup12.Height = 35;
            pnlMenuGroup13.Height = 35;
            pnlMenuGroup14.Height = 35;
            if (pnlMenuGroup5.Height == 35)
            {
                pnlMenuGroup5.Height = (35 * 7) + 2;
            }
            else
            {
                pnlMenuGroup5.Height = 35;
            }
        }
        private void btnMenuGroup6_Click_1(object sender, EventArgs e)
        {
            pnlMenuGroup1.Height = 35;
            pnlMenuGroup2.Height = 35;
            pnlMenuGroup3.Height = 35;
            pnlMenuGroup5.Height = 35;
            pnlMenuGroup7.Height = 35;
            pnlMenuGroup8.Height = 35;
            pnlMenuGroup9.Height = 35;
            pnlMenuGroup10.Height = 35;
            pnlMenuGroup11.Height = 35;
            pnlMenuGroup12.Height = 35;
            pnlMenuGroup13.Height = 35;
            pnlMenuGroup14.Height = 35;
            if (pnlMenuGroup6.Height == 35)
            {
               // pnlMenuGroup6.Height = (35 * 13) + 2;
                pnlMenuGroup6.Height = (35 * 11) + 2;
            }
            else
            {
                pnlMenuGroup6.Height = 35;
            }
        }
        private void btnMenuGroup7_Click_1(object sender, EventArgs e)
        {
            pnlMenuGroup1.Height = 35;
            pnlMenuGroup2.Height = 35;
            pnlMenuGroup3.Height = 35;
            
            pnlMenuGroup5.Height = 35;
            pnlMenuGroup6.Height = 35;
            pnlMenuGroup8.Height = 35;
            pnlMenuGroup9.Height = 35;
            pnlMenuGroup10.Height = 35;
            pnlMenuGroup11.Height = 35;
            pnlMenuGroup12.Height = 35;
            pnlMenuGroup13.Height = 35;
            pnlMenuGroup14.Height = 35;
            if (pnlMenuGroup7.Height == 35)
            {
                pnlMenuGroup7.Height = (35 * 3) + 2;
            }
            else
            {
                pnlMenuGroup7.Height = 35;
            }
        }
        private void btnMenuGroup8_Click(object sender, EventArgs e)
        {
            pnlMenuGroup1.Height = 35;
            pnlMenuGroup2.Height = 35;
            pnlMenuGroup3.Height = 35;
            
            pnlMenuGroup5.Height = 35;
            pnlMenuGroup6.Height = 35;
            pnlMenuGroup7.Height = 35;
            pnlMenuGroup9.Height = 35;
            pnlMenuGroup10.Height = 35;
            pnlMenuGroup11.Height = 35;
            pnlMenuGroup12.Height = 35;
            pnlMenuGroup13.Height = 35;
            pnlMenuGroup14.Height = 35;
            if (pnlMenuGroup8.Height == 35)
            {
                pnlMenuGroup8.Height = (35 * 5) + 2;
            }
            else
            {
                pnlMenuGroup8.Height = 35;
            }
        }
        private void btnMenuGroup9_Click(object sender, EventArgs e)
        {
            pnlMenuGroup1.Height = 35;
            pnlMenuGroup2.Height = 35;
            pnlMenuGroup3.Height = 35;

            pnlMenuGroup5.Height = 35;
            pnlMenuGroup6.Height = 35;
            pnlMenuGroup7.Height = 35;
            pnlMenuGroup8.Height = 35;
            pnlMenuGroup10.Height = 35;
            pnlMenuGroup11.Height = 35;
            pnlMenuGroup12.Height = 35;
            pnlMenuGroup13.Height = 35;
            pnlMenuGroup14.Height = 35;
            if (pnlMenuGroup9.Height == 35)
            {
                pnlMenuGroup9.Height = (35 * 3) + 2;
            }
            else
            {
                pnlMenuGroup9.Height = 35;
            }
        }
        private void btnMenuGroup10_Click(object sender, EventArgs e)
        {
            pnlMenuGroup1.Height = 35;
            pnlMenuGroup2.Height = 35;
            pnlMenuGroup3.Height = 35;
            pnlMenuGroup5.Height = 35;
            pnlMenuGroup6.Height = 35;
            pnlMenuGroup7.Height = 35;
            pnlMenuGroup8.Height = 35;
            pnlMenuGroup9.Height = 35;
            pnlMenuGroup12.Height = 35;
            pnlMenuGroup11.Height = 35;
            pnlMenuGroup13.Height = 35;
            pnlMenuGroup14.Height = 35;
            if (pnlMenuGroup10.Height == 35)
            {
                pnlMenuGroup10.Height = (35 * 2) + 2;
            }
            else
            {
                pnlMenuGroup10.Height = 35;
            }
        }
        private void btnMenuGroup11_Click(object sender, EventArgs e)
        {
            pnlMenuGroup1.Height = 35;
            pnlMenuGroup2.Height = 35;
            pnlMenuGroup3.Height = 35;
            
            pnlMenuGroup5.Height = 35;
            pnlMenuGroup6.Height = 35;
            pnlMenuGroup7.Height = 35;
            pnlMenuGroup8.Height = 35;
            pnlMenuGroup9.Height = 35;
            pnlMenuGroup10.Height = 35;
            pnlMenuGroup12.Height = 35;
            pnlMenuGroup13.Height = 35;
            pnlMenuGroup14.Height = 35;
            if (pnlMenuGroup11.Height == 35)
            {
                pnlMenuGroup11.Height = (35 * 2) + 2;
            }
            else
            {
                pnlMenuGroup11.Height = 35;
            }
        }
       
        private void btnMenuGroup12_Click(object sender, EventArgs e)
        {
            pnlMenuGroup1.Height = 35;
            pnlMenuGroup2.Height = 35;
            pnlMenuGroup3.Height = 35;

            pnlMenuGroup5.Height = 35;
            pnlMenuGroup6.Height = 35;
            pnlMenuGroup7.Height = 35;
            pnlMenuGroup8.Height = 35;
            pnlMenuGroup9.Height = 35;
            pnlMenuGroup10.Height = 35;
            pnlMenuGroup11.Height = 35;
            pnlMenuGroup13.Height = 35;
            pnlMenuGroup14.Height = 35;
            if (pnlMenuGroup12.Height == 35)
            {
                pnlMenuGroup12.Height = (35 * 3) + 2;
            }
            else
            {
                pnlMenuGroup12.Height = 35;
            }
        }
        private void btnMenuGroup13_Click(object sender, EventArgs e)
        {
            pnlMenuGroup1.Height = 35;
            pnlMenuGroup2.Height = 35;
            pnlMenuGroup3.Height = 35;

            pnlMenuGroup5.Height = 35;
            pnlMenuGroup6.Height = 35;
            pnlMenuGroup7.Height = 35;
            pnlMenuGroup8.Height = 35;
            pnlMenuGroup9.Height = 35;
            pnlMenuGroup10.Height = 35;
            pnlMenuGroup11.Height = 35;
            pnlMenuGroup12.Height = 35;
            pnlMenuGroup14.Height = 35;

            if (pnlMenuGroup13.Height == 35)
            {
                pnlMenuGroup13.Height = (35 * 3) + 2;
            }
            else
            {
                pnlMenuGroup13.Height = 35;
            }
        }

        private void btnMenuGroup14_Click(object sender, EventArgs e)
        {
            pnlMenuGroup1.Height = 35;
            pnlMenuGroup2.Height = 35;
            pnlMenuGroup3.Height = 35;
            pnlMenuGroup5.Height = 35;
            pnlMenuGroup6.Height = 35;
            pnlMenuGroup7.Height = 35;
            pnlMenuGroup8.Height = 35;
            pnlMenuGroup9.Height = 35;
            pnlMenuGroup10.Height = 35;
            pnlMenuGroup11.Height = 35;
            pnlMenuGroup12.Height = 35;
            pnlMenuGroup13.Height = 35;
            if (pnlMenuGroup14.Height == 35)
            {
                pnlMenuGroup14.Height = (35 * 7) + 2;
            }
            else
            {
                pnlMenuGroup14.Height = 35;
            }
        }
        private void btnItemSettings_Click(object sender, EventArgs e)
        {
           
            ItemSetting itemsetting = new ItemSetting();
            itemsetting.MdiParent = this;
            itemsetting.Show();
        }
        private void btnItemAddInitialStock_Click(object sender, EventArgs e)
        {
           
           ViewProductCode vpc = new ViewProductCode();
            vpc.MdiParent = this;
            vpc.Show();
        }
       
        private void bntSalesLeft_Click(object sender, EventArgs e)
        {
           Sales sa = new Sales();
           sa.MdiParent = this;
           sa.Show();
        }
       
        private void btnSalesReturnLeft_Click(object sender, EventArgs e)
        {
            SalesReturn sr = new SalesReturn();
            sr.MdiParent = this;
            sr.Show();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Purchase frmpurchaseitem = new Purchase();
            frmpurchaseitem.MdiParent = this;
            frmpurchaseitem.Show();
        }
        

        private void buttonUnitType_Click(object sender, EventArgs e)
        {
           UnitType ut = new UnitType();
           ut.MdiParent = this;
           ut.Show();
        }  

        
        private void buttonItemEdit_Click_1(object sender, EventArgs e)
        {
           ItemSettingEdit ise = new ItemSettingEdit();
           ise.MdiParent = this;
           ise.Show();
        }
        private void purchaseReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void saleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void salesReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void unitTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void addBuyerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           
        }

        private void addSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

       

        private void buttonStockReport_Click_1(object sender, EventArgs e)
        {
            StockReport sr = new StockReport();
            sr.MdiParent = this;
            sr.Show();
        }

        private void buttonSalesReport_Click(object sender, EventArgs e)
        {
           SalesReport srinr = new SalesReport();
           srinr.MdiParent = this;
           srinr.Show();
        }

        private void MainBody_Close(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
            Close();
        }

       

        private void buttonAddCompany_Click(object sender, EventArgs e)
        {
          WarehouseSettings cie = new WarehouseSettings();
           cie.MdiParent = this;
           cie.Show();
        }

        private void buttonCompanyInfo_Click(object sender, EventArgs e)
        {
            CompanyInfoEdit cie = new CompanyInfoEdit();
            cie.MdiParent = this;
            cie.Show();
        }



        private void buttonIncome_Click(object sender, EventArgs e)
        {
           Income inC = new Income();
           inC.MdiParent = this;
           inC.Show();
        }

        private void buttonExpensive_Click(object sender, EventArgs e)
        {
           Expense expn = new Expense();
           expn.MdiParent = this;
           expn.Show();
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
           AddUser auser = new AddUser();
           auser.MdiParent = this;
           auser.Show();
        }

        private void buttonViewUser_Click(object sender, EventArgs e)
        {
           ViewUser vuser = new ViewUser();
           vuser.MdiParent = this;
           vuser.Show();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            Login lin = new Login();
            lin.Show();
            Hide();
        }

        private void buttonUpdateProfile_Click(object sender, EventArgs e)
        {
            UpdateProfile up = new UpdateProfile();
            up.MdiParent = this;
            up.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
            int second = DateTime.Now.Second;
            int backUpTime = DateTime.Now.Hour;
            int backUpMinute = DateTime.Now.Minute;
            int backUpSecond = DateTime.Now.Second;

            if (backUpTime == 16 && backUpMinute == 37 && backUpSecond == 52)
            {
                string strPath = @"D:\AutometicBackUp";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
                conn.Open();
                string sql = "BACKUP DATABASE IFADPOS TO DISK = '" + strPath + "\\" + "IFADPOS" + "-" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".bak'";
                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
            }

            if (backUpTime == 16 && backUpMinute == 10 && backUpSecond == 18)
            {
                string strPath = @"D:\AutometicBackUp";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
                conn.Open();
                string sql = "BACKUP DATABASE IFADPOS TO DISK = '" + strPath + "\\" + "IFADPOS" + "-" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".bak'";
                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
            }

            if (backUpTime == 17 && backUpMinute == 30 && backUpSecond == 9)
            {
                string strPath = @"D:\AutometicBackUp";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
                conn.Open();
                string sql = "BACKUP DATABASE IFADPOS TO DISK = '" + strPath + "\\" + "IFADPOS" + "-" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".bak'";
                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
            }

            if (second >= 1 && second < 10)
                toolStripStatusLabel3.ForeColor = Color.Red;
            else if (second >= 10 && second < 20)
                toolStripStatusLabel3.ForeColor = Color.Purple;
            else if (second >= 20 && second < 30)
                toolStripStatusLabel3.ForeColor = Color.Blue;
            else if (second >= 30 && second < 40)
                toolStripStatusLabel3.ForeColor = Color.Purple;
            else if (second >= 40 && second < 50)
                toolStripStatusLabel3.ForeColor = Color.Red;
            else if (second >= 50 && second < 60)
                toolStripStatusLabel3.ForeColor = Color.Blue;
            
        }

       
        private void buttonPurchase_Click(object sender, EventArgs e)
        {
           PurchaseReport pr = new PurchaseReport();
           pr.MdiParent = this;
           pr.Show();
        }

        private void buttonAddLedger_Click(object sender, EventArgs e)
        {
           CustomerLedger cl = new CustomerLedger();
           cl.MdiParent = this;
           cl.Show();
        }

        private void buttonAddCustomer_Click(object sender, EventArgs e)
        {
           AddCustomer ac = new AddCustomer();
           ac.MdiParent = this;
           ac.Show();
        }

        private void buttonLedgerReport_Click(object sender, EventArgs e)
        {
           LedgerReport lr = new LedgerReport();
           lr.MdiParent = this;
           lr.Show();
        }

        private void buttonAddSupplier_Click(object sender, EventArgs e)
        {
           AddSupplier asp = new AddSupplier();
          asp.MdiParent = this;
          asp.Show();

        }

        private void buttonViewSupplier_Click(object sender, EventArgs e)
        {
            //CloseAllForm(this);
        }

        private void buttonWarehouse_Click(object sender, EventArgs e)
        {
          
            DatabaseBackUP awh = new DatabaseBackUP();
            awh.MdiParent = this;
            awh.Show();
        }

        private void buttonBarcodeGenerate_Click(object sender, EventArgs e)
        {
            BarcodeGenerate bg = new BarcodeGenerate();
            bg.MdiParent = this;
            bg.Show();
        }

        private void buttonDamagedReport_Click(object sender, EventArgs e)
        {
            ProductLedger pl = new ProductLedger();
           pl.MdiParent = this;
           pl.Show();
        }

        private void buttonSalesReturnReport_Click(object sender, EventArgs e)
        {
            SalesReturnReport srr = new SalesReturnReport();
            srr.MdiParent = this;
            srr.Show();
        }

        private void locationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Mouse_leave()
        {
            btnMenuGroup1.BackColor = Color.LightSeaGreen;
        }
        private void Mouse_Enter()
        {
            btnMenuGroup1.BackColor = Color.YellowGreen;
        }

        private void btnMenuGroup1_MouseLeave(object sender, EventArgs e)
        {
            Mouse_leave();
        }

        private void btnMenuGroup1_MouseEnter(object sender, EventArgs e)
        {
            Mouse_Enter();
        }

        private void btnMenuGroup2_MouseEnter(object sender, EventArgs e)
        {
            btnMenuGroup2.BackColor = Color.YellowGreen;
        }

        private void btnMenuGroup2_MouseLeave(object sender, EventArgs e)
        {
            btnMenuGroup2.BackColor = Color.LightSeaGreen;
        }

        private void btnMenuGroup3_MouseEnter(object sender, EventArgs e)
        {
            btnMenuGroup3.BackColor = Color.YellowGreen;
        }

        private void btnMenuGroup3_MouseLeave(object sender, EventArgs e)
        {
            btnMenuGroup3.BackColor = Color.LightSeaGreen;
        }

        private void btnMenuGroup5_MouseEnter(object sender, EventArgs e)
        {
            btnMenuGroup5.BackColor = Color.YellowGreen;
        }

        private void btnMenuGroup5_MouseLeave(object sender, EventArgs e)
        {
            btnMenuGroup5.BackColor = Color.LightSeaGreen;
        }

        private void btnMenuGroup6_MouseEnter(object sender, EventArgs e)
        {
            btnMenuGroup6.BackColor = Color.YellowGreen;
        }

        private void btnMenuGroup6_MouseLeave(object sender, EventArgs e)
        {
            btnMenuGroup6.BackColor = Color.LightSeaGreen;
        }

        private void btnMenuGroup8_MouseEnter(object sender, EventArgs e)
        {
            btnMenuGroup8.BackColor = Color.YellowGreen;
        }

        private void btnMenuGroup8_MouseLeave(object sender, EventArgs e)
        {
            btnMenuGroup8.BackColor = Color.LightSeaGreen;
        }

        private void btnMenuGroup7_MouseEnter(object sender, EventArgs e)
        {
            btnMenuGroup7.BackColor = Color.YellowGreen;
        }

        private void btnMenuGroup7_MouseLeave(object sender, EventArgs e)
        {
            btnMenuGroup7.BackColor = Color.LightSeaGreen;
        }

        private void btnMenuGroup9_MouseEnter(object sender, EventArgs e)
        {
            btnMenuGroup9.BackColor = Color.YellowGreen;
        }

        private void btnMenuGroup9_MouseLeave(object sender, EventArgs e)
        {
            btnMenuGroup9.BackColor = Color.LightSeaGreen;
        }

        private void btnMenuGroup10_MouseEnter(object sender, EventArgs e)
        {
            btnMenuGroup10.BackColor = Color.YellowGreen;
        }

        private void btnMenuGroup10_MouseLeave(object sender, EventArgs e)
        {
            btnMenuGroup10.BackColor = Color.LightSeaGreen;
        }

        private void btnMenuGroup11_MouseEnter(object sender, EventArgs e)
        {
            btnMenuGroup11.BackColor = Color.YellowGreen;
        }

        private void btnMenuGroup11_MouseLeave(object sender, EventArgs e)
        {
            btnMenuGroup11.BackColor = Color.LightSeaGreen;
        }

        private void btnMenuGroup12_MouseEnter(object sender, EventArgs e)
        {
            btnMenuGroup12.BackColor = Color.YellowGreen;
        }

        private void btnMenuGroup12_MouseLeave(object sender, EventArgs e)
        {
            btnMenuGroup12.BackColor = Color.LightSeaGreen;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            UserSell();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonDueList_Click(object sender, EventArgs e)
        {
           InExReport dl = new InExReport();
           dl.MdiParent = this;
           dl.Show();
        }

        private void buttonProfit_Click(object sender, EventArgs e)
        {
           Profit pro = new Profit();
           pro.MdiParent = this;
           pro.Show();
        }

        private void buttonPurchaseReturnReport_Click(object sender, EventArgs e)
        {
            PurchaseReturnReports prr = new PurchaseReturnReports();
            prr.MdiParent = this;
            prr.Show();
        }

        private void buttonSupplierList_Click(object sender, EventArgs e)
        {
            AllSupplierList allSupplierList = new AllSupplierList();
            allSupplierList.MdiParent = this;
            allSupplierList.Show();
        }

        private void buttonStockSummary_Click(object sender, EventArgs e)
        {
            StockSummary ss = new StockSummary();
            ss.MdiParent = this;
            ss.Show();
        }

        private void buttonPurchaseEdit_Click(object sender, EventArgs e)
        {
            PurchaseEdit pe = new PurchaseEdit();
            pe.MdiParent = this;
            pe.Show();
        }

        private void buttonCustomerDetails_Click(object sender, EventArgs e)
        {
            CustomerDetails cd = new CustomerDetails();
            cd.MdiParent = this;
            cd.Show();
        }

        private void buttonInvoiceOrChallanPrint_Click(object sender, EventArgs e)
        {
            InvoiceChallanPrint icp = new InvoiceChallanPrint();
            icp.MdiParent = this;
            icp.Show();
        }

        private void buttonPurchaseReturn_Click(object sender, EventArgs e)
        {
            PurchaseReturn pr = new PurchaseReturn();
            pr.MdiParent = this;
            pr.Show();
        }

        private void buttonFOCSales_Click(object sender, EventArgs e)
        {
           // SalesFOC FOCS = new SalesFOC();
            FOCSales FOCS = new FOCSales();     // Change
            FOCS.MdiParent = this;
            FOCS.Show();
        }

        private void buttonDamageProductReceive_Click(object sender, EventArgs e)
        {
            DamageProductReceive DPR = new DamageProductReceive();
            DPR.MdiParent = this;
            DPR.Show();
        }

        private void buttonDamageProductReport_Click(object sender, EventArgs e)
        {
            DamageProductReceiveReport DPRR = new DamageProductReceiveReport();
            DPRR.MdiParent = this;
            DPRR.Show();
        }

        private void lblLogOut_Click(object sender, EventArgs e)
        {
            Login DPRR = new Login();
            Hide();
            DPRR.Show();
        }

        private void buttonCustomerList_Click(object sender, EventArgs e)
        {
            AllCustomer allCustomer = new AllCustomer();
            allCustomer.MdiParent = this;
            allCustomer.Show();
        }

        private void btnPaymentReport_Click(object sender, EventArgs e)
        {
            PaymentReport paymentReport = new PaymentReport();
            paymentReport.MdiParent = this;
            paymentReport.Show();
        }

        private void btnFocSales_Click(object sender, EventArgs e)
        {
            FOCSalesReport focRpt = new FOCSalesReport();
            focRpt.MdiParent = this;
            focRpt.Show();
        }

        private void buttonSalesEdit_Click(object sender, EventArgs e)
        {
            SalesEdit se = new SalesEdit();
            se.MdiParent = this;
            se.Show();
        }

        private void buttonCustLedgerSummary_Click(object sender, EventArgs e)
        {
            AllCustomerReport se = new AllCustomerReport();
            se.MdiParent = this;
            se.Show();
        }

        private void buttonSalesSummary_Click(object sender, EventArgs e)
        {
            SalesSummery se = new SalesSummery();
            se.MdiParent = this;
            se.Show();
        }

        private void buttonProfitReport_Click(object sender, EventArgs e)
        {

        }

        private void buttonStockTransfer_Click(object sender, EventArgs e)
        {
            StockTransfer st = new StockTransfer();
            st.MdiParent = this;
            st.Show();
        }

        private void buttonTransferReport_Click(object sender, EventArgs e)
        {
            StockTransferReport str = new StockTransferReport();
            str.MdiParent = this;
            str.Show();
        }

        private void buttonTransferReturn_Click(object sender, EventArgs e)
        {
            StockTransferReturn tr = new StockTransferReturn();
            tr.MdiParent = this;
            tr.Show();
        }

        private void buttonTransferReturnReport_Click(object sender, EventArgs e)
        {
            StockTransferReturnReport strr = new StockTransferReturnReport();
            strr.MdiParent = this;
            strr.Show();
        }

        private void buttonTransferReturnEdit_Click(object sender, EventArgs e)
        {
            StockTransferReturnEdit stre = new StockTransferReturnEdit();
            stre.MdiParent = this;
            stre.Show();
        }

        private void buttontransferEdit_Click(object sender, EventArgs e)
        {
            StockTransferEdit ste = new StockTransferEdit();
            ste.MdiParent = this;
            ste.Show();
        }
    }
}




   
