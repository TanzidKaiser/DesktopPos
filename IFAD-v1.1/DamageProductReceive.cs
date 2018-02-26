﻿using System;
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
    public partial class DamageProductReceive : Form
    {
        public DamageProductReceive()
        {
            InitializeComponent();
            textBoxQuantity.KeyPress += new KeyPressEventHandler(Quantity_KeyPress);
            textBoxProductSearch.KeyDown += new KeyEventHandler(textBoxProductSearch_KeyDown);
            textBoxQuantity.KeyDown += new KeyEventHandler(textBoxQuantity_KeyDown);
            ShowTreeViewItem();

        }
       
        public void ShowTreeViewItem()
        {
            treeViewPurchaseItem.Nodes.Clear();
            string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection connection = new SqlConnection(conStr);
            string query = "SELECT * FROM CategoryMain";
            SqlCommand command1 = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command1.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                treeViewPurchaseItem.Nodes.Add(reader["MaincategoryName"].ToString());
                FirstChild(Convert.ToInt32(reader["MainCategoryID"]), i);
                i++;
            }
            treeViewPurchaseItem.TabStop = false;
            reader.Close();
            connection.Close();
        }

        string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();

        public void FirstChild(int mainID, int i)
        {
            string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection connection1 = new SqlConnection(conStr);
            string query1 = "SELECT * FROM Category WHERE MaincategoryID = '" + mainID + "'";
            SqlCommand command11 = new SqlCommand(query1, connection1);

            connection1.Open();
            SqlDataReader reader1 = command11.ExecuteReader();
            int j = 0;
            while (reader1.Read())
            {
                treeViewPurchaseItem.Nodes[i].Nodes.Add(reader1["CategoryName"].ToString());
                SecondChild(Convert.ToInt32(reader1["CategoryID"]), i, j);
                j++;
            }
            reader1.Close();
            connection1.Close();
        }

        public void SecondChild(int catID, int i, int j)
        {
            string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection connection12 = new SqlConnection(conStr);
            string query12 = "SELECT * FROM CategorySub WHERE CategoryID = '" + catID + "'";
            SqlCommand command112 = new SqlCommand(query12, connection12);

            connection12.Open();
            SqlDataReader reader12 = command112.ExecuteReader();
            int k = 0;
            while (reader12.Read())
            {
                treeViewPurchaseItem.Nodes[i].Nodes[j].Nodes.Add(reader12["SubCategoryName"].ToString());
                ThirdChild(Convert.ToInt32(reader12["SubCategoryID"]), i, j, k);
                k++;
            }
            reader12.Close();
            connection12.Close();
        }
        public void ThirdChild(int SubcatID, int i, int j, int k)
        {
            string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection connection12 = new SqlConnection(conStr);
            string query12 = "SELECT * FROM Product WHERE SubCategoryID = '" + SubcatID + "'";
            SqlCommand command112 = new SqlCommand(query12, connection12);

            connection12.Open();
            SqlDataReader reader12 = command112.ExecuteReader();

            while (reader12.Read())
            {

                TreeNode tn = new TreeNode();
                tn.Tag = reader12["ID"];
                tn.Text = reader12["Name"].ToString();
                treeViewPurchaseItem.Nodes[i].Nodes[j].Nodes[k].Nodes.Add(tn);

            }
            reader12.Close();
            connection12.Close();
        }

        private void treeViewPurchaseItem_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
            try
            {
                textBoxPdoductCode.Text = "";
                textBoxUnitType.Text = "";
                textBoxPdoductCode.Text = treeViewPurchaseItem.SelectedNode.Tag.ToString();
                textBoxProductName.Text = "";
                int pro_id =Convert.ToInt32(textBoxPdoductCode.Text);
                string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
                SqlConnection connection12 = new SqlConnection(conStr);
                string query12 = "SELECT * FROM Product WHERE ID = '" + pro_id + "'";
                SqlCommand command112 = new SqlCommand(query12, connection12);

                connection12.Open();
                SqlDataReader reader12 = command112.ExecuteReader();

                while (reader12.Read())
                {
                    textBoxProductName.Text = reader12["Name"].ToString();    
                }
                reader12.Close();
                connection12.Close();
                //unit name
                string conStr11 = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
                SqlConnection connection1211 = new SqlConnection(conStr11);
                string query1211 = "SELECT * FROM Product WHERE ID = '" + pro_id + "'";
                SqlCommand command11211 = new SqlCommand(query1211, connection1211);

                connection1211.Open();
                SqlDataReader reader1211 = command11211.ExecuteReader();

                while (reader1211.Read())
                {
                    textBoxPrice.Text = reader1211["PurchasePrice"].ToString();
                    int unit_id =Convert.ToInt32(reader1211["UnitID"]);
                    GetUnitName(unit_id);
                }
                reader1211.Close();
                connection1211.Close();

                //See Currently Stock

                string conStrPross = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
                SqlConnection connectionPross = new SqlConnection(conStrPross);
                string queryPross = "SELECT * FROM Product WHERE ID = '" + Convert.ToInt32(textBoxPdoductCode.Text) + "'";
                SqlCommand commandPross = new SqlCommand(queryPross, connectionPross);
                connectionPross.Open();
                SqlDataReader readerPross = commandPross.ExecuteReader();

                while (readerPross.Read())
                {
                    textBoxCurrentStock.Text = readerPross["Stock"].ToString();
                }
                readerPross.Close();
                connectionPross.Close();

                // End Currently Stock
            }
            catch (Exception)
            {
                textBoxPdoductCode.Text = "";
                textBoxProductName.Text = "";
                textBoxPrice.Text = "";
                textBoxUnitType.Text = "";
                textBoxQuantity.Text = "";
                textBoxSupplierInvoiceNo.Text = "";
                MessageBox.Show("Please Select the Product First..");
            }
        }
        public void GetUnitName(int unit_id)
        {
            string conStr111 = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection connection12111 = new SqlConnection(conStr111);
            string query12111 = "SELECT * FROM Unit WHERE UnitID = '" + unit_id + "'";
            SqlCommand command112111 = new SqlCommand(query12111, connection12111);

            connection12111.Open();
            SqlDataReader reader12111 = command112111.ExecuteReader();

            while (reader12111.Read())
            {
                textBoxUnitType.Text = reader12111["UnitValue"].ToString();
            }
            reader12111.Close();
            connection12111.Close();
        }
        private void Form_Load()
        {
            DateTime now = DateTime.Now;
            textBoxDate.Text = now.ToString("yyyy-MM-dd");
            textBoxDate.ReadOnly = true;
            textBoxTime.Text = now.ToLongTimeString();
            textBoxTime.ReadOnly = true;
            textBoxPurchaseNo.Text = "DPN"+DateTime.Now.ToString("yyyyMMddhhmmssf");
        }
        private void FormPurchaseItemBody_Load(object sender, EventArgs e)
        {
            FormPurchaseClosed();
            Form_Load(); 
            Auto_Complete();
            Auto_Complete_Invoice_No();
            this.ActiveControl = textBoxSupplierInvoiceNo;
           
        }
        private void Auto_Complete()
        {
            //Auto Complete search
            textBoxProductSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxProductSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
            textBoxProductSearch.AutoCompleteCustomSource = col;
            conSS.Close();
        }
        private void Auto_Complete_Invoice_No()
        {
            //Auto Complete search
            textBoxSupplierInvoiceNo.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxSupplierInvoiceNo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection conSS = new SqlConnection(conStr);
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            col.Clear();
            conSS.Open();
            string sql = "SELECT SalesNo FROM Sales";
            SqlCommand cmd = new SqlCommand(sql, conSS);
            SqlDataReader sdr = null;
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                col.Add(sdr["SalesNo"].ToString());
            }
            sdr.Close();
            conSS.Close();

            conSS.Open();
            sql = "SELECT PurchaseSupplierInvoiceNo FROM Purchase";
            cmd = new SqlCommand(sql, conSS);
            sdr = null;
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                col.Add(sdr["PurchaseSupplierInvoiceNo"].ToString());
            }
            sdr.Close();
            conSS.Close();
            textBoxSupplierInvoiceNo.AutoCompleteCustomSource = col;
        }
        public void FormPurchaseClosed()
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sql = @"TRUNCATE TABLE TempDamageProductReceive";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
       

        public void TempPurchase(int pro_id, string name, double qantity, double price, string purchase_no, double price_total)
        {
            SqlConnection connection = new SqlConnection(conStr);
            string query = "INSERT INTO TempDamageProductReceive(CompanyID,DamageProductProductID,DamageProductProductName,DamageProductQuantity,DamageProductPrice,DamageProductInvoiceNo,DamageProductTotal,DamageProductReceiveDate) VALUES(1,'" + pro_id + "','" + name + "','" + qantity + "','" + price + "','" + purchase_no + "','" + price_total + "','" + textBoxDate.Text + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowEffict = command.ExecuteNonQuery();
            connection.Close();
            
        }
        
        public double Temp_PreviousStock(int productcode)
        {
            double total_quantity = 0;
            string conStrCalq = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection connectionCalq = new SqlConnection(conStrCalq);
            string queryCalq = "SELECT * FROM TempDamageProductReceive WHERE DamageProductProductID = '" + productcode + "'";
            SqlCommand commandCalq = new SqlCommand(queryCalq, connectionCalq);
            connectionCalq.Open();
            SqlDataReader readerCalq = commandCalq.ExecuteReader();

            while (readerCalq.Read())
            {
                total_quantity = Convert.ToDouble(readerCalq["DamageProductQuantity"]);
            }
            readerCalq.Close();
            connectionCalq.Close();
            return total_quantity;
        }
        

        public void DataGrid()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT DamageProductID as 'ID', DamageProductProductID as 'ProductID', DamageProductProductName as 'Product Name', DamageProductQuantity as 'Quantity', DamageProductPrice as 'Price', DamageProductInvoiceNo as 'Purchase No', DamageProductTotal as 'Total' FROM TempDamageProductReceive";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewPurchase.DataSource = dt;
            con.Close();
        }
        public void UpdateTemp_ProductStock(double total_quantity,double total, int pro_id)
        {
            SqlConnection connection1 = new SqlConnection(conStr);
            string query1 = "UPDATE TempDamageProductReceive SET DamageProductQuantity = '" + total_quantity + "', DamageProductTotal = '" + total + "' WHERE DamageProductProductID = '" + pro_id + "'";
            SqlCommand command1 = new SqlCommand(query1, connection1);
            connection1.Open();
            int rowEffict1 = command1.ExecuteNonQuery();
            connection1.Close();
            if (rowEffict1 > 0)
            {
                DataGrid();
            }
        }
        public void Display_Three_Item()
        {
            double ProTotal = 0;
            double AmountTotal = 0;
            int i = 0;
            string conStrs = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection connections = new SqlConnection(conStrs);
            string querys = "SELECT * FROM TempDamageProductReceive";
            SqlCommand commands = new SqlCommand(querys, connections);
            connections.Open();
            SqlDataReader readers = commands.ExecuteReader();

            while (readers.Read())
            {
                ProTotal = ProTotal + Convert.ToDouble(readers["DamageProductQuantity"]);
                AmountTotal = AmountTotal + Convert.ToDouble(readers["DamageProductTotal"]);
                i++;
            }
            readers.Close();
            connections.Close();
            textBoxItemTotal.Text = i.ToString();
            textBoxProductTotal.Text = ProTotal.ToString();
            textBoxInvoiceTotalAmount.Text = AmountTotal.ToString();
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {

            if (textBoxSupplierInvoiceNo.Text == "")
            {
                MessageBox.Show("Please Fill the Supplier Invoice No..");
            }
            else if (textBoxPdoductCode.Text == "")
            {
                MessageBox.Show("Please Select a Product on Data Tree view..!!");
            }
            else if (textBoxQuantity.Text == "")
            {
                MessageBox.Show("Please Fill the quantity..");
            }

            else
            {
                // For Purchase
                int supplier_id=0;
                
               
                //Temp Purchase
                int temp_pro_id = Convert.ToInt32(textBoxPdoductCode.Text);
                string temp_name = textBoxProductName.Text;
                double temp_quantity = Convert.ToDouble(textBoxQuantity.Text);
                double temp_price = Convert.ToDouble(textBoxPrice.Text);
                string temp_purchase_no = textBoxPurchaseNo.Text;
                double temp_purchase_total = Convert.ToDouble(textBoxQuantity.Text) * Convert.ToDouble(textBoxPrice.Text);
                double temp_stock = Temp_PreviousStock(temp_pro_id);
                if (temp_stock > 0.0)
                {
                    double Quantity_total = temp_stock + temp_quantity;
                    double total = Quantity_total * temp_price;
                    UpdateTemp_ProductStock(Quantity_total, total, temp_pro_id);
                }

                else
                {
                    TempPurchase(temp_pro_id, temp_name, temp_quantity, temp_price, temp_purchase_no, temp_purchase_total);
                    DataGrid();
                   
                }
                Display_Three_Item();
                string hide=textBoxPdoductCode.Text;
                textBoxProductName.Text = textBoxQuantity.Text = textBoxPrice.Text = textBoxUnitType.Text = textBoxProductSearch.Text= textBoxCurrentStock.Text= "";
                textBoxPdoductCode.Text=hide;
                this.ActiveControl = textBoxProductSearch;
            }

        }
       
        private void FromPurchaseClosed(object sender, FormClosedEventArgs e)
        {
            FormPurchaseClosed();
        }

        //Validation only for numeric number
        private void Quantity_KeyPress(object sender, KeyPressEventArgs e)
        {

            if(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar <= '.' || e.KeyChar == (char)Keys.Back) //The  character represents a backspace
              {
                e.Handled = false; //Do not reject the input
              }
            else
                {
                  e.Handled = true; //Reject the input
               }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxSupplierInvoiceNo.Text == "")
            {
                MessageBox.Show("Please Fill the Supplier Invoice No..");
            }
            else if (textBoxPdoductCode.Text == "")
            {
                MessageBox.Show("Please Select a Product on Data Tree view..!!");
            }
            else if (textBoxQuantity.Text == "")
            {
                MessageBox.Show("Please Fill the quantity..");
            }

            else
            {
                //Temp Purchase
                int temp_pro_id = Convert.ToInt32(textBoxPdoductCode.Text);
                double temp_quantity = Convert.ToInt32(textBoxQuantity.Text);
                if(temp_quantity < 0.99)
                {
                    MessageBox.Show("Quantity can not be zero!!!..");
                }
                else
                {
                    double temp_price = Convert.ToDouble(textBoxPrice.Text);
                    double total = temp_quantity * temp_price;
                    SqlConnection connection1 = new SqlConnection(conStr);
                    string query1 = "UPDATE TempDamageProductReceive SET DamageProductQuantity = '" + temp_quantity + "', DamageProductTotal = '" + total + "' WHERE DamageProductProductID = '" + temp_pro_id + "'";
                    SqlCommand command1 = new SqlCommand(query1, connection1);
                    connection1.Open();
                    int rowEffict1 = command1.ExecuteNonQuery();
                    connection1.Close();
                    if (rowEffict1 > 0)
                    {
                        DataGrid();
                        Display_Three_Item();

                    }

                }
                
            }
            }
        private void dataGridViewPurchase_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBoxPdoductCode.Text = textBoxProductName.Text = textBoxQuantity.Text = textBoxPrice.Text = textBoxUnitType.Text = "";
            textBoxPdoductCode.Text = dataGridViewPurchase.SelectedRows[0].Cells[1].Value.ToString();
            textBoxProductName.Text = dataGridViewPurchase.SelectedRows[0].Cells[2].Value.ToString();
            textBoxQuantity.Text = dataGridViewPurchase.SelectedRows[0].Cells[3].Value.ToString();
            textBoxPrice.Text = dataGridViewPurchase.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
             if (textBoxPdoductCode.Text == "")
            {
                MessageBox.Show("Please Select a Product in DataGrid...!!");
            }
            else
            {
                try
                {
                    SqlConnection connection1 = new SqlConnection(conStr);
                    string query1 = @"DELETE FROM TempDamageProductReceive WHERE  DamageProductProductID = '" + textBoxPdoductCode.Text + "'; ";
                    SqlCommand command1 = new SqlCommand(query1, connection1);
                    connection1.Open();
                    int rowEffict1 = command1.ExecuteNonQuery();
                    connection1.Close();
                    DataGrid();
                    Display_Three_Item();
                    textBoxPdoductCode.Text = textBoxProductName.Text = textBoxQuantity.Text = textBoxPrice.Text = textBoxUnitType.Text = textBoxSupplierInvoiceNo.Text = "";

                }
                catch (Exception)
                {
                    MessageBox.Show("Please Select a Product in DataGrid...!!");
                }
            }
        }
        private void Purchase_Details_Insert()
        {
            string purchase_no = textBoxPurchaseNo.Text;
            string remarks = "Na";
            int supplier_id=0;
            foreach (DataGridViewRow row in dataGridViewPurchase.Rows)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO DamageProductReceive(DamageProductNo,CompanyID,DamageProductDate,SupplierID,InvoiceNo,DamageProductRemarks,DamageProductProductID,DamageProductPrice,DamageProductQuantity,DamageProductTotal) VALUES('" + purchase_no + "', 1, '" + textBoxDate.Text + "','"+ supplier_id + "','"+textBoxSupplierInvoiceNo.Text+"','" + remarks + "',@ProductID,@Price,@Quantity,@Total)", con))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", row.Cells["ProductID"].Value);
                        cmd.Parameters.AddWithValue("@Price", row.Cells["Price"].Value);
                        cmd.Parameters.AddWithValue("@Quantity", row.Cells["Quantity"].Value);
                        cmd.Parameters.AddWithValue("@Total", row.Cells["Total"].Value);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
          
        }
        public void Clear_All_Last()
        {
            textBoxPdoductCode.Text = textBoxProductName.Text = textBoxInvoiceTotalAmount.Text = "";
        }
        private void Purchase_Insert()
        {
            if (textBoxPdoductCode.Text == "")
            {
                MessageBox.Show("Please Select a Product in Tree View....!!!");
            }
            else
            {
                try
                {
                    //SqlConnection connection = new SqlConnection(conStr);
                    //string query = "INSERT INTO purchase VALUES('" + textBoxPurchaseNo.Text + "','" + textBoxDate.Text + "','1','" + textBoxSupplierInvoiceNo.Text + "','Na','" + textBoxInvoiceTotalAmount.Text + "')";
                    //SqlCommand command = new SqlCommand(query, connection);
                    //connection.Open();
                    //int rowEffict = command.ExecuteNonQuery();
                    //connection.Close();
                    Clear_All_Last();
                    FormPurchaseClosed();
                    DataGrid();
                   // Dispose();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void Update_Product_Stock()
        {
            
            foreach (DataGridViewRow row in dataGridViewPurchase.Rows)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE Product SET Stock =(SELECT Stock FROM Product WHERE ID = @ProductID) + @Quantity  WHERE ID = @ProductID", con))
                    {
                        
                        cmd.Parameters.AddWithValue("@ProductID", Convert.ToDouble(row.Cells["ProductID"].Value));
                        cmd.Parameters.AddWithValue("@Quantity", Convert.ToDouble(row.Cells["Quantity"].Value));
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }
        private void buttonPurchase_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure, you will Receive these Damage Product?", "Receive Damage Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return;
            }
            else
            {
                try
                {
                        Purchase_Details_Insert();
                        //Update_Product_Stock();
                        Purchase_Insert();
                        DataGrid();
                        Form_Load();
                        textBoxSupplierInvoiceNo.Text = "";
                        MessageBox.Show("Receive Successfully....!!!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            }

        private bool IsNumeric(string input)
        {
            int test;
            return int.TryParse(input, out test);
        }
        private double Currently_Stock()
        {
            double stock = 0.0;
            string conStrPross = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection connectionPross = new SqlConnection(conStrPross);
            string queryPross = "SELECT * FROM Product WHERE ID = '" + Convert.ToInt32(textBoxPdoductCode.Text) + "'";
            SqlCommand commandPross = new SqlCommand(queryPross, connectionPross);
            connectionPross.Open();
            SqlDataReader readerPross = commandPross.ExecuteReader();

            while (readerPross.Read())
            {
                stock = Convert.ToDouble(readerPross["Stock"]);
            }

            readerPross.Close();
            connectionPross.Close();
            return stock;
        }
        private void textBoxProductSearch_TextChanged(object sender, EventArgs e)
        {
            string spro_id = textBoxProductSearch.Text;
            
                SqlConnection conww = new SqlConnection(conStr);
                conww.Open();
                string sqlww = "SELECT * FROM Product WHERE Name='" + textBoxProductSearch.Text + "'OR Code='" + textBoxProductSearch.Text + "'";
                SqlCommand cmdww = new SqlCommand(sqlww, conww);
                SqlDataReader sdrww = null;
                sdrww = cmdww.ExecuteReader();
                while (sdrww.Read())
                {
                    spro_id = sdrww["ID"].ToString();
                }
                sdrww.Close();
                conww.Close();
            
            try
            {
                textBoxPdoductCode.Text = "";
                textBoxPdoductCode.Text = spro_id;
                int pro_id = Convert.ToInt32(textBoxPdoductCode.Text);
                textBoxProductName.Text = "";
                SqlConnection connection12 = new SqlConnection(conStr);
                string query12 = "SELECT * FROM Product WHERE ID = '" + pro_id + "'";
                SqlCommand command112 = new SqlCommand(query12, connection12);

                connection12.Open();
                SqlDataReader reader12 = command112.ExecuteReader();

                while (reader12.Read())
                {

                    textBoxProductName.Text = reader12["Name"].ToString();
                }
                reader12.Close();
                connection12.Close();

                //unit name
                string conStr11 = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
                SqlConnection connection1211 = new SqlConnection(conStr11);
                string query1211 = "SELECT * FROM Product WHERE ID = '" + pro_id + "'";
                SqlCommand command11211 = new SqlCommand(query1211, connection1211);

                connection1211.Open();
                SqlDataReader reader1211 = command11211.ExecuteReader();

                while (reader1211.Read())
                {
                    textBoxPrice.Text = reader1211["PurchasePrice"].ToString();
                    int unit_id = Convert.ToInt32(reader1211["UnitID"]);
                    GetUnitName(unit_id);
                }
                reader1211.Close();
                connection1211.Close();

                //See Currently Stock
                textBoxCurrentStock.Text = Currently_Stock().ToString();

            }
            catch (Exception)
            {
                textBoxPdoductCode.Text = "";
                textBoxProductName.Text = "";
                textBoxPrice.Text = "";
                textBoxCurrentStock.Text = "";
                textBoxUnitType.Text = "";
            }

      
        //
    }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBoxQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = buttonAdd;
            }
        }

        private void textBoxProductSearch_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = textBoxQuantity;
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.ActiveControl = buttonPurchase;
            }
        }

        private void buttonPurchase_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void buttonPurchase_MouseEnter(object sender, EventArgs e)
        {
            buttonPurchase.BackColor = Color.YellowGreen;
        }

        private void textBoxSupplierInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = textBoxProductSearch;
            }
        }
    }
}
