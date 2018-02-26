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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }
        private int CheckUserName(string User_Name)
        {
            string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection connection = new SqlConnection(conStr);
            string query = "SELECT * FROM [User] WHERE UserName = '" + User_Name + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            int rowEffict = Convert.ToInt32(reader.Read());
            connection.Close();

            return rowEffict;

        }
        private void AccessArea(int UserId)
        {
            int c1 = 0; int c2 = 0; int c3 = 0; int c4 = 0; int c5 = 0; int c6 = 0; int c7 = 0;
            int c8 = 0; int c9 = 0; int c10 = 0; int c11 = 0; int c12 = 0; int c13 = 0; int c14 = 0;
            int c15 = 0; int c16 = 0; int c17 = 0; int c18 = 0; int c19 = 0; int c20 = 0; int c21 = 0;
            int c22 = 0; int c23 = 0; int c24 = 0; int c25 = 0; int c26 = 0; int c27 = 0; int c28 = 0;
            int c29 = 0; int c30 = 0; int c31 = 0; int c32 = 0; int c33 = 0; int c34 = 0; int c35 = 0;
            int c36 = 0; int c37 = 0; int c38 = 0; int c39 = 0; int c40 = 0; int c41 = 0; int c42 = 0;
            int c43 = 0;
            if (a1.Checked)
            {
                c1 = 1;
            }
            if (a2.Checked)
            {
                c2 = 1;
            }
            if (a3.Checked)
            {
                c3 = 1;
            }
            if (a4.Checked)
            {
                c4 = 1;
            }
            if (a5.Checked)
            {
                c5 = 1;
            }
            if (a6.Checked)
            {
                c6 = 1;
            }
            if (a7.Checked)
            {
                c7 = 1;
            }
            if (a8.Checked)
            {
                c8 = 1;
            }
            if (a9.Checked)
            {
                c9 = 1;
            }
            if (a10.Checked)
            {
                c10 = 1;
            }
            if (a11.Checked)
            {
                c11 = 1;
            }
            if (a12.Checked)
            {
                c12 = 1;
            }
            if (a13.Checked)
            {
                c13 = 1;
            }
            if (a14.Checked)
            {
                c14 = 1;
            }
            if (a15.Checked)
            {
                c15 = 1;
            }
            if (a16.Checked)
            {
                c16 = 1;
            }
            if (a17.Checked)
            {
                c17 = 1;
            }
            if (a18.Checked)
            {
                c18 = 1;
            }
            if (a19.Checked)
            {
                c19 = 1;
            }
            if (a20.Checked)
            {
                c20 = 1;
            }
            if (a21.Checked)
            {
                c21 = 1;
            }
            if (a22.Checked)
            {
                c22 = 1;
            }
            if (a23.Checked)
            {
                c23 = 1;
            }
            if (a24.Checked)
            {
                c24 = 1;
            }
            if (a25.Checked)
            {
                c25 = 1;
            }
            if (a26.Checked)
            {
                c26 = 1;
            }
            if (a27.Checked)
            {
                c27 = 1;
            }
            if (a28.Checked)
            {
                c28 = 1;
            }
            if (a29.Checked)
            {
                c29 = 1;
            }
            if (a30.Checked)
            {
                c30 = 1;
            }
            if (a31.Checked)
            {
                c31 = 1;
            }
            if (a32.Checked)
            {
                c32 = 1;
            }
            if (a33.Checked)
            {
                c33 = 1;
            }
            if (a34.Checked)
            {
                c34 = 1;
            }
            if (a35.Checked)
            {
                c35 = 1;
            }
            if (a36.Checked)
            {
                c36 = 1;
            }
            if (a37.Checked)
            {
                c37 = 1;
            }
            if (a38.Checked)
            {
                c38 = 1;
            }
            if (a39.Checked)
            {
                c39 = 1;
            }
            if (a40.Checked)
            {
                c40 = 1;
            }
            if (a41.Checked)
            {
                c41 = 1;
            }
            if (a42.Checked)
            {
                c42 = 1;
            }
            if (a43.Checked)
            {
                c43 = 1;
            }
            string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection connection = new SqlConnection(conStr);
            string query11 = "INSERT INTO [UserAccessAreaNew] VALUES('" + UserId + "','" + c1 + "','" + c2 + "','" + c3 + "','" + c4 + "','" + c5 + "','" + c6 + "','" + c7 + "','" + c8 + "','" + c9 + "','" + c10 + "','" + c11 + "','" + c12 + "','" + c13 + "','" + c14 + "','" + c15 + "','" + c16 + "','" + c17 + "','" + c18 + "','" + c19 + "','" + c20 + "','" + c21 + "','" + c22 + "','" + c23 + "','" + c24 + "','" + c25 + "','" + c26 + "','" + c27 + "','" + c28 + "','" + c29 + "','" + c30 + "','" + c31 + "','" + c32 + "','" + c33 + "','" + c34 + "','" + c35 + "','" + c36 + "','" + c37 + "','" + c38 + "','" + c39 + "','" + c40 + "','" + c41 + "','" + c42 + "','" + c43 + "')";
            SqlCommand command = new SqlCommand(query11, connection);
            connection.Open();
            int rowEffict11 = command.ExecuteNonQuery();
            connection.Close();


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
        private void btnAddUser_Click(object sender, EventArgs e)
        {
           if(imgLoc=="")
            {
                imgLoc = @"C:\IFAD-Reports\default.png";
            }
            byte[] img = null;
            FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            img = br.ReadBytes((int)fs.Length);


            string Date = textBoxDate.Text;
            string Name = textBoxName.Text;
            string Address = textBoxAddress.Text;
            string Mobile = textBoxMobile.Text;
            string Email = textBoxEmail.Text;

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


            string User_Name = textBoxUserName.Text;

            int Role = 0;
            if (radioButtonSales.Checked)
            {
                Role = 2;
            }
            if (radioButtonPurchase.Checked)
            {
                Role = 3;
            }
            if (radioButtonOther.Checked)
            {
                Role = 4;
            }

            string Password1 = textBoxPassword1.Text;
            string Password2 = textBoxPassword2.Text;

            try
            {
                if (textBoxName.Text == "")
                {
                    MessageBox.Show("Please fill Name...");
                }
                else if (Address == "")
                {
                    MessageBox.Show("Please fill Address...");
                }
                else if (textBoxMobile.Text == "")
                {
                    MessageBox.Show("Please fill Mobile...");
                }
                else if (textBoxEmail.Text == "")
                {
                    MessageBox.Show("Please fill Email...");
                }
                else if (Gender == "")
                {
                    MessageBox.Show("Please select Gender...");
                }
                else if (User_Name == "")
                {
                    MessageBox.Show("Please fill User Name...");
                }
                else if (CheckUserName(User_Name) > 0)
                {
                    labelUserName.Text = "User Name Already Exist...";
                    textBoxUserName.Text = "";
                }
                else if (Role == 0)
                {
                    MessageBox.Show("Please Select User Type...");
                }
                else if (textBoxPassword1.Text == "")
                {
                    MessageBox.Show("Please fill Password...");
                }
                else if (textBoxPassword2.Text == "")
                {
                    MessageBox.Show("Please fill Confirm Password...");
                }

                else if (!IsPasswordsEqual(textBoxPassword1.Text, textBoxPassword2.Text))
                {
                    labelPasswordError.Text = "Password did not match...";
                    textBoxPassword1.Text = textBoxPassword2.Text = "";
                }
                else
                {
                    string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
                    SqlConnection connection = new SqlConnection(conStr);
                    string query11 = "INSERT INTO [User] OUTPUT INSERTED.ID VALUES(1,'" + Date + "','" + Name + "','" + Address + "','" + Mobile + "','" + Email + "','" + Gender + "','" + User_Name + "','" + Password1 + "','" + Role + "',@img)";
                    SqlCommand command = new SqlCommand(query11, connection);
                    connection.Open();
                    command.Parameters.Add(new SqlParameter("@img", img));
                    int UserId = (Int32)command.ExecuteScalar();
                    connection.Close();
                    if (UserId > 0)
                    {
                        AccessArea(UserId);
                        Clear_All();
                        MessageBox.Show("User Add Successfully !");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddUserNew_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            textBoxDate.Text = now.ToString("yyyy-MM-dd");
        }
        public bool IsPasswordsEqual(string Password1, string Password2)
        {
            if (Password1.Equals(Password2))
            {
                return true;
            }

            return false;
        }
        private void Clear_All()
        {
            textBoxName.Text = textBoxAddress.Text = textBoxMobile.Text = textBoxEmail.Text = "";
            radioButton1.Checked = radioButton2.Checked = radioButton3.Checked = false;
            textBoxUserName.Text = textBoxPassword1.Text = textBoxPassword2.Text = "";
            radioButtonSales.Checked = radioButtonPurchase.Checked = false;


        }

       
    }
}
