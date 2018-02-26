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
    public partial class CompanyInfo : Form
    {
        public CompanyInfo()
        {
            InitializeComponent();
            GetCompanyInfo();
        }
        string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();

        public void GetCompanyInfo()
        {
            SqlConnection conn = new SqlConnection(conStr);
            string query1 = "SELECT * FROM [company_info]";
            SqlCommand command1 = new SqlCommand(query1, conn);

            conn.Open();
            SqlDataReader reader1 = command1.ExecuteReader();
            
            while (reader1.Read())
            {
                textBoxName.Text = reader1["name"].ToString();
                textBoxAddress1.Text = reader1["address_1"].ToString();
                textBoxMobile1.Text = reader1["mobile_1"].ToString();
                textBoxPhone1.Text = reader1["phone_1"].ToString();
                textBoxFax1.Text = reader1["fax_1"].ToString();
                textBoxVatNo.Text = reader1["vat_no"].ToString();
                textBoxTrade.Text = reader1["trade_license"].ToString();
                textBoxTinNo.Text = reader1["tin_no"].ToString();
                textBoxEmail.Text = reader1["email"].ToString();
                textBoxWebsite.Text = reader1["website"].ToString();
            }
            reader1.Close();
            conn.Close();
        }
        public void ResetColor()
        {
            textBoxName.BackColor = Color.BlanchedAlmond;
            textBoxAddress1.BackColor = Color.BlanchedAlmond;
            textBoxMobile1.BackColor = Color.BlanchedAlmond;
            textBoxPhone1.BackColor = Color.BlanchedAlmond;
            textBoxFax1.BackColor = Color.BlanchedAlmond;
            textBoxVatNo.BackColor = Color.BlanchedAlmond;
            textBoxTrade.BackColor = Color.BlanchedAlmond;
            textBoxTinNo.BackColor = Color.BlanchedAlmond;
            textBoxEmail.BackColor = Color.BlanchedAlmond;


        }
       
        private void buttonAdd_Click(object sender, EventArgs e)
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
                else {
                    if (checkBoxAlreadyInfo.Checked) {
                        SqlConnection connection = new SqlConnection(conStr);
                        string query = "UPDATE [company_info] SET name = '" + name + "', address_1 = '" + address_1 + "',  address_2 = '" + address_2 + "',mobile_1 = '" + mobile_1 + "',mobile_2 = '" + mobile_2 + "', phone_1 = '" + phone_1 + "',phone_2 = '" + phone_2 + "',fax_1 = '" + fax_1 + "',fax_2 = '" + fax_2 + "',vat_no = '" + vat_no + "',trade_license = '" + trade_license + "',tin_no = '" + tin_no + "',email = '" + email + "',website = '" + website + "', status = 1 WHERE id=1";

                        SqlCommand command = new SqlCommand(query, connection);
                        connection.Open();
                        int rowEffict = command.ExecuteNonQuery();
                        connection.Close();
                        if (rowEffict > 0)
                        {

                            MainBody mbody = new MainBody();
                            mbody.Show();
                            Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Select \"I agree to the POS Software and Service  Agreement\"");
                    }
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

       

        private void CompanyInfo_Close(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void CompanyInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
