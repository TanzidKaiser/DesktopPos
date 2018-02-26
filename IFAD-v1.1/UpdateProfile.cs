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
    public partial class UpdateProfile : Form
    {
        public UpdateProfile()
        {
            InitializeComponent();
           
        }
        public string currentuser = Login.loguser;
        public void Initial_Data()
        {
            string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection connection1 = new SqlConnection(conStr);
            string query1 = "SELECT * FROM [user] WHERE UserName = '"+ currentuser+ "'";
            SqlCommand command11 = new SqlCommand(query1, connection1);
            string gender = "";
            connection1.Open();
            SqlDataReader reader1 = command11.ExecuteReader();
            while (reader1.Read())
            {
                textBoxUserName.Text = reader1["UserName"].ToString();
                textBoxName.Text = reader1["Name"].ToString();
                textBoxAddress.Text = reader1["Address"].ToString();
                textBoxMobile.Text = reader1["Mobile"].ToString();
                textBoxEmail.Text = reader1["Email"].ToString();
                gender = reader1["Gender"].ToString();

            }
            reader1.Close();
            connection1.Close();
            if (IsPasswordsEqual(gender, "Male")==true)
            {
                radioButton1.Checked = true;
            }
            else if (IsPasswordsEqual(gender, "Female") == true)
            {
                radioButton2.Checked = true;
            }
            else if (IsPasswordsEqual(gender, "Other") == true)
            {
                radioButton3.Checked = true;
            }
        }
        public void GetImage()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
            string query1 = "SELECT Image FROM [user] WHERE UserName = '"+ currentuser + "'";
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
        private void UpdateProfile_Load(object sender, EventArgs e)
        {
           
            GetImage();
            pictureBox1.ImageLocation = "";
            Initial_Data();
        }
        public bool IsPasswordsEqual(string Password1, string Password2)
        {
            if (Password1.Equals(Password2))
            {
                return true;
            }

            return false;
        }
        private int CheckPassword(string pass)
        {
            string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection connection1 = new SqlConnection(conStr);
            string query1 = "SELECT * FROM [user] WHERE UserName = '" + currentuser + "' AND Password = '" + pass + "'";
            SqlCommand command11 = new SqlCommand(query1, connection1);
            int already = 0;
            connection1.Open();
            SqlDataReader reader1 = command11.ExecuteReader();
            while (reader1.Read())
            {
                already++;

            }
            reader1.Close();
            connection1.Close();
            return already;
        }
        string imgLoc = "";
        private void buttonUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                string Gender = "";
                if (radioButton1.Checked)
                {
                    Gender = "Male";
                }
                if (radioButton2.Checked)
                {
                    Gender = "Female";
                }
                if (radioButton3.Checked)
                {
                    Gender = "Other";
                }

                if (textBoxName.Text == "")
                {
                    MessageBox.Show("Name is not Empty...!!!!");
                }
                else if (textBoxAddress.Text == "")
                {
                    MessageBox.Show("Address is not Empty...!!!!");
                }
                else if (textBoxMobile.Text == "")
                {
                    MessageBox.Show("Mobile is not Empty...!!!!");
                }
                else if (textBoxEmail.Text == "")
                {
                    MessageBox.Show("Email is not Empty...!!!!");
                }
                else if (textBoxOldPassword.Text == "")
                {
                    MessageBox.Show("Old Password is not Empty...!!!!");
                }
                else if (CheckPassword(textBoxOldPassword.Text)==0)
                {
                    MessageBox.Show("Old Password is not Correct...!!!!");
                    textBoxOldPassword.Text = "";
                }

                else if (textBoxNewPassword1.Text == "")
                {
                    MessageBox.Show("New Password is not Empty...!!!!");
                }
                else if (textBoxNewPassword2.Text == "")
                {
                    MessageBox.Show("Confirm Password is not Empty...!!!!");
                }
                else if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Please Select a Image...!!!!");
                }
                else if (!IsPasswordsEqual(textBoxNewPassword1.Text, textBoxNewPassword2.Text))
                {
                    labelWrongPassword.Text = "Password did not match...";
                    textBoxNewPassword1.Text = textBoxNewPassword2.Text = "";
                }
                else
                {
                   
                        string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
                        SqlConnection connection = new SqlConnection(conStr);
                        string query11 = "UPDATE [user] SET Name='" + textBoxName.Text + "', Address='" + textBoxAddress.Text + "', Mobile='" + textBoxMobile.Text + "', Email='" + textBoxEmail.Text + "', Gender='" + Gender + "',  Password='" + textBoxNewPassword2.Text + "' WHERE UserName='" + currentuser + "'";
                        SqlCommand command = new SqlCommand(query11, connection);
                        connection.Open();
                        
                        int rowEffict11 = command.ExecuteNonQuery();
                        connection.Close();
                        if (rowEffict11 > 0)
                        {
                            Initial_Data();
                            textBoxOldPassword.Text = textBoxNewPassword1.Text = textBoxNewPassword2.Text = "";
                            MessageBox.Show("Update Profile Successfully !");
                        }
                    

                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        

        private void buttonImageUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] img = null;
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);

                
                        string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
                        SqlConnection connection = new SqlConnection(conStr);
                        string query11 = "UPDATE [user] SET Image = @img WHERE UserName='" + currentuser + "'";
                        SqlCommand command = new SqlCommand(query11, connection);
                        connection.Open();
                        command.Parameters.Add(new SqlParameter("@img", img));
                        int rowEffict11 = command.ExecuteNonQuery();
                        connection.Close();
                        if (rowEffict11 > 0)
                        {
                            MessageBox.Show("Update Image Successfully !");
                        }  
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonBrowse_Click_1(object sender, EventArgs e)
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
    }
}
