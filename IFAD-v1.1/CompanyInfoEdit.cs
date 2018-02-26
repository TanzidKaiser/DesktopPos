using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFAD_v1._1
{
    public partial class CompanyInfoEdit : Form
    {
        public CompanyInfoEdit()
        {
            InitializeComponent();
           
        }
        string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
        private void CompanyInfoEdit_Load(object sender, EventArgs e)
        {
            GetCompanyInfo();
        }
        public void GetCompanyInfo()
        {
            SqlConnection conn = new SqlConnection(conStr);
            string query1 = "SELECT * FROM [CompanyInformation] WHERE CompanyID=1";
            SqlCommand command1 = new SqlCommand(query1, conn);

            conn.Open();
            SqlDataReader reader1 = command1.ExecuteReader();

            while (reader1.Read())
            {
                textBoxName.Text = reader1["Name"].ToString();
                textBoxAddress1.Text = reader1["Address"].ToString();
                textBoxMobile1.Text = reader1["Mobile"].ToString();
                textBoxPhone1.Text = reader1["Phone"].ToString();
                textBoxFax1.Text = reader1["Fax"].ToString();
                textBoxVatNo.Text = reader1["VatNo"].ToString();
                textBoxTrade.Text = reader1["TradeLicense"].ToString();
                textBoxTinNo.Text = reader1["TinNo"].ToString();
                textBoxEmail.Text = reader1["Email"].ToString();
                textBoxWebsite.Text = reader1["Website"].ToString();
                textBoxVatRate.Text = reader1["VatRate"].ToString();
                byte [] img = (byte [])reader1["Image"];
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
        
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBoxName.Text;
                string address_1 = textBoxAddress1.Text;
                string address_2 = textBoxAddress2.Text;
                string mobile_1 = textBoxMobile1.Text;
                string mobile_2 = textBoxMobile2.Text;
                string phone_1 = textBoxPhone1.Text;
                string phone_2 = textBoxPhone2.Text;
                string fax_1 = textBoxFax1.Text;
                string fax_2 = textBoxFax2.Text;
                string vat_no = textBoxVatNo.Text;
                string trade_license = textBoxTrade.Text;
                string tin_no = textBoxTinNo.Text;
                string email = textBoxEmail.Text;
                string website = textBoxWebsite.Text;
                double vat_rate = Convert.ToDouble(textBoxVatRate.Text);

               

                if (name == "")
                {
                    textBoxName.BackColor = Color.Plum;
                    MessageBox.Show("Please input Name");

                }

                else if (address_1 == "")
                {
                    textBoxAddress1.BackColor = Color.Plum;
                    MessageBox.Show("Please input Address 1");
                }
                else if (mobile_1 == "")
                {
                    textBoxMobile1.BackColor = Color.Plum;
                    MessageBox.Show("Please input Mobile 1");
                }
                else if (phone_1 == "")
                {
                    textBoxPhone1.BackColor = Color.Plum;
                    MessageBox.Show("Please input Phone 1");
                }
                else if (fax_1 == "")
                {
                    textBoxFax1.BackColor = Color.Plum;
                    MessageBox.Show("Please input Fax 1");
                }
                else if (vat_no == "")
                {
                    textBoxVatNo.BackColor = Color.Plum;
                    MessageBox.Show("Please input VAT NO");
                }
                else if (trade_license == "")
                {
                    textBoxTrade.BackColor = Color.Plum;
                    MessageBox.Show("Please input Trade License");
                }
                else if (tin_no == "")
                {
                    textBoxTinNo.BackColor = Color.Plum;
                    MessageBox.Show("Please input TIN NO");
                }
                else if (email == "")
                {
                    textBoxEmail.BackColor = Color.Plum;
                    MessageBox.Show("Please input Email");
                }
                else if (textBoxVatRate.Text == "")
                {
                    textBoxEmail.BackColor = Color.Plum;
                    MessageBox.Show("Please input VAT Rate");
                }
                else
                {
                        SqlConnection connection = new SqlConnection(conStr);
                        string query = "UPDATE [CompanyInformation] SET Name = '" + name + "', Address = '" + address_1 + "',  AddressOptional = '" + address_2 + "',Mobile = '" + mobile_1 + "',MobileOptional = '" + mobile_2 + "', Phone = '" + phone_1 + "',PhoneOptional = '" + phone_2 + "',Fax = '" + fax_1 + "',FaxOptional = '" + fax_2 + "',VatNo = '" + vat_no + "',TradeLicense = '" + trade_license + "',TinNo = '" + tin_no + "',Email = '" + email + "',Website = '" + website + "', VatRate = '" + vat_rate+ "', Status = 1 WHERE CompanyID=1";

                        SqlCommand command = new SqlCommand(query, connection);
                        connection.Open();
                       
                        int rowEffict = command.ExecuteNonQuery();
                        connection.Close();
                        if (rowEffict > 0)
                        {
                            labelUpdate.Text = "Company Information Update Successfully...!";
                        }
                    
                    
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        string imgLoc = "";
        

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|All Files (*.*)|*.*";
                ofd.Title = "Company Image Browse";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = ofd.FileName.ToString();
                    pictureBox1.ImageLocation = imgLoc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonUpdateImage_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] img = null;
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);

                    SqlConnection connection = new SqlConnection(conStr);
                    string query = "UPDATE [CompanyInformation] SET Image = @img WHERE CompanyID=1";

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    command.Parameters.Add(new SqlParameter("@img", img));
                    int rowEffict = command.ExecuteNonQuery();
                    connection.Close();
                    if (rowEffict > 0)
                    {
                        MessageBox.Show("Update Image Successfully...!!!");
                    }
                
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        ReportDocument cryRpt = new ReportDocument();
        public string ReportPaths = ReportPath.rPath;
        private void tabControlCompanyInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            string rPath = ReportPaths + "CrystalReportCompanyInformation.rpt";
            cryRpt.Load(rPath);
            crConnectionInfo.ServerName = ConfigurationManager.ConnectionStrings["cryServer"].ToString();
            crConnectionInfo.DatabaseName = ConfigurationManager.ConnectionStrings["cryDatabase"].ToString();
            crConnectionInfo.UserID = ConfigurationManager.ConnectionStrings["cryUserID"].ToString();
            crConnectionInfo.Password = ConfigurationManager.ConnectionStrings["cryPass"].ToString();
            foreach (Table CrTable in cryRpt.Database.Tables)
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
