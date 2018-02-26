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
    public partial class AddUserEdit : Form
    {
        public AddUserEdit()
        {
            InitializeComponent();
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
            string query11 = "UPDATE UserAccessAreaNew SET A1='" + c1 + "',A2='" + c2 + "',A3='" + c3 + "',A4='" + c4 + "',A5='" + c5 + "',A6='" + c6 + "',A7='" + c7 + "',A8='" + c8 + "',A9='" + c9 + "',A10='" + c10 + "',A11='" + c11 + "',A12='" + c12 + "',A13='" + c13 + "',A14='" + c14 + "',A15='" + c15 + "',A16='" + c16 + "',A17='" + c17 + "',A18='" + c18 + "',A19='" + c19 + "',A20='" + c20 + "',A21='" + c21 + "',A22='" + c22 + "',A23='" + c23 + "',A24='" + c24 + "',A25='" + c25 + "',A26='" + c26 + "',A27='" + c27 + "',A28='" + c28 + "',A29='" + c29 + "',A30='" + c30 + "',A31='" + c31 + "',A32='" + c32 + "',A33='" + c33 + "',A34='" + c34 + "',A35='" + c35 + "',A36='" + c36 + "',A37='" + c37 + "',A38='" + c38 + "',A39='" + c39 + "',A40='" + c40 + "',A41='" + c41 + "',A42='" + c42 + "',A43='" + c43 + "' WHERE UserID='"+ UserId + "'";
            SqlCommand command = new SqlCommand(query11, connection);
            connection.Open();
            int rowEffict11 = command.ExecuteNonQuery();
            connection.Close();


        }

        public void fillCombo(ComboBox combo, string query, string displayMember, string valueMember)
        {
            SqlCommand command;
            SqlDataAdapter adapter;
            DataTable table;
            SqlConnection conss = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
            command = new SqlCommand(query, conss);
            adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            combo.DataSource = table;
            combo.DisplayMember = displayMember;
            combo.ValueMember = valueMember;

        }
        private void AddUserNew_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM [User] WHERE ID > 1";
            fillCombo(comboBoxUserName, query, "UserName", "ID");
        }

        private void comboBoxUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            a1.Checked = false;
            a2.Checked = false;
            a3.Checked = false;
            a4.Checked = false;
            a5.Checked = false;
            a6.Checked = false;
            a7.Checked = false;
            a8.Checked = false;
            a9.Checked = false;
            a10.Checked = false;
            a11.Checked = false;
            a12.Checked = false;
            a13.Checked = false;
            a14.Checked = false;
            a15.Checked = false;
            a16.Checked = false;
            a17.Checked = false;
            a18.Checked = false;
            a19.Checked = false;
            a20.Checked = false;
            a21.Checked = false;
            a22.Checked = false;
            a23.Checked = false;
            a24.Checked = false;
            a25.Checked = false;
            a26.Checked = false;
            a27.Checked = false;
            a28.Checked = false;
            a29.Checked = false;
            a30.Checked = false;
            a31.Checked = false;
            a32.Checked = false;
            a33.Checked = false;
            a34.Checked = false;
            a35.Checked = false;
            a36.Checked = false;
            a37.Checked = false;
            a38.Checked = false;
            a39.Checked = false;
            a40.Checked = false;
            a41.Checked = false;
            a42.Checked = false;
            a43.Checked = false;
            int ID;
            Int32.TryParse(comboBoxUserName.SelectedValue.ToString(), out ID);

            int c1 = 0; int c2 = 0; int c3 = 0; int c4 = 0; int c5 = 0; int c6 = 0; int c7 = 0;
            int c8 = 0; int c9 = 0; int c10 = 0; int c11 = 0; int c12 = 0; int c13 = 0; int c14 = 0;
            int c15 = 0; int c16 = 0; int c17 = 0; int c18 = 0; int c19 = 0; int c20 = 0; int c21 = 0;
            int c22 = 0; int c23 = 0; int c24 = 0; int c25 = 0; int c26 = 0; int c27 = 0; int c28 = 0;
            int c29 = 0; int c30 = 0; int c31 = 0; int c32 = 0; int c33 = 0; int c34 = 0; int c35 = 0;
            int c36 = 0; int c37 = 0; int c38 = 0; int c39 = 0; int c40 = 0; int c41 = 0; int c42 = 0;
            int c43 = 0;

          
            string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection con = new SqlConnection(conStr);
            string query = "SELECT * FROM UserAccessAreaNew WHERE UserID = " + ID;
            SqlCommand command112 = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader12 = command112.ExecuteReader();
            while (reader12.Read())
            {
                c1 = Convert.ToInt32(reader12["A1"]);
                c2 = Convert.ToInt32(reader12["A2"]);
                c3 = Convert.ToInt32(reader12["A3"]);
                c4 = Convert.ToInt32(reader12["A4"]);
                c5 = Convert.ToInt32(reader12["A5"]);
                c6 = Convert.ToInt32(reader12["A6"]);
                c7 = Convert.ToInt32(reader12["A7"]);
                c8 = Convert.ToInt32(reader12["A8"]);
                c9 = Convert.ToInt32(reader12["A9"]);
                c10 = Convert.ToInt32(reader12["A10"]);
                c11 = Convert.ToInt32(reader12["A11"]);
                c12 = Convert.ToInt32(reader12["A12"]);
                c13 = Convert.ToInt32(reader12["A13"]);
                c14 = Convert.ToInt32(reader12["A14"]);
                c15 = Convert.ToInt32(reader12["A15"]);
                c16 = Convert.ToInt32(reader12["A16"]);
                c17 = Convert.ToInt32(reader12["A17"]);
                c18 = Convert.ToInt32(reader12["A18"]);
                c19 = Convert.ToInt32(reader12["A19"]);
                c20 = Convert.ToInt32(reader12["A20"]);
                c21 = Convert.ToInt32(reader12["A21"]);
                c22 = Convert.ToInt32(reader12["A22"]);
                c23 = Convert.ToInt32(reader12["A23"]);
                c24 = Convert.ToInt32(reader12["A24"]);
                c25 = Convert.ToInt32(reader12["A25"]);
                c26 = Convert.ToInt32(reader12["A26"]);
                c27 = Convert.ToInt32(reader12["A27"]);
                c28 = Convert.ToInt32(reader12["A28"]);
                c29 = Convert.ToInt32(reader12["A29"]);
                c30 = Convert.ToInt32(reader12["A30"]);
                c31 = Convert.ToInt32(reader12["A31"]);
                c32 = Convert.ToInt32(reader12["A32"]);
                c33 = Convert.ToInt32(reader12["A33"]);
                c34 = Convert.ToInt32(reader12["A34"]);
                c35 = Convert.ToInt32(reader12["A35"]);
                c36 = Convert.ToInt32(reader12["A36"]);
                c37 = Convert.ToInt32(reader12["A37"]);
                c38 = Convert.ToInt32(reader12["A38"]);
                c39 = Convert.ToInt32(reader12["A39"]);
                c40 = Convert.ToInt32(reader12["A40"]);
                c41 = Convert.ToInt32(reader12["A41"]);
                c42 = Convert.ToInt32(reader12["A42"]);
                c43 = Convert.ToInt32(reader12["A43"]);

            }
            reader12.Close();
            con.Close();

            if (c1 == 1)
            {
                a1.Checked=true;
            }
            if (c2 == 1)
            {
                a2.Checked = true;
            }
            if (c3 == 1)
            {
                a3.Checked = true;
            }
            if (c4 == 1)
            {
                a4.Checked = true;
            }
            if (c5 == 1)
            {
                a5.Checked = true;
            }
            if (c6 == 1)
            {
                a6.Checked = true;
            }
            if (c7 == 1)
            {
                a7.Checked = true;
            }
            if (c8 == 1)
            {
                a8.Checked = true;
            }
            if (c9 == 1)
            {
                a9.Checked = true;
            }
            if (c10 == 1)
            {
                a10.Checked = true;
            }
            if (c11 == 1)
            {
                a11.Checked = true;
            }
            if (c12 == 1)
            {
                a12.Checked = true;
            }
            if (c13 == 1)
            {
                a13.Checked = true;
            }
            if (c14 == 1)
            {
                a14.Checked = true;
            }
            if (c15 == 1)
            {
                a15.Checked = true;
            }
            if (c16 == 1)
            {
                a16.Checked = true;
            }
            if (c17 == 1)
            {
                a17.Checked = true;
            }
            if (c18 == 1)
            {
                a18.Checked = true;
            }
            if (c19 == 1)
            {
                a19.Checked = true;
            }
            if (c20 == 1)
            {
                a20.Checked = true;
            }
            if (c21 == 1)
            {
                a21.Checked = true;
            }
            if (c22 == 1)
            {
                a22.Checked = true;
            }
            if (c23 == 1)
            {
                a23.Checked = true;
            }
            if (c24 == 1)
            {
                a24.Checked = true;
            }
            if (c25 == 1)
            {
                a25.Checked = true;
            }
            if (c26 == 1)
            {
                a26.Checked = true;
            }
            if (c27 == 1)
            {
                a27.Checked = true;
            }
            if (c28 == 1)
            {
                a28.Checked = true;
            }
            if (c29 == 1)
            {
                a29.Checked = true; 
            }
            if (c30 == 1)
            {
                a30.Checked = true;
            }
            if (c31 == 1)
            {
                a31.Checked = true;
            }
            if (c32 == 1)
            {
                a32.Checked = true;
            }
            if (c33 == 1)
            {
                a33.Checked = true;
            }
            if (c34 == 1)
            {
                a34.Checked = true;
            }
            if (c35 == 1)
            {
                a35.Checked = true;
            }
            if (c36 == 1)
            {
                a36.Checked = true;
            }
            if (c37 == 1)
            {
                a37.Checked = true;
            }
            if (c38 == 1)
            {
                a38.Checked = true;
            }
            if (c39 == 1)
            {
                a39.Checked = true;
            }
            if (c40 == 1)
            {
                a40.Checked = true;
            }
            if (c41 == 1)
            {
                a41.Checked = true;
            }
            if (c42 == 1)
            {
                a42.Checked = true;
            }
            if (c43 == 1)
            {
                a43.Checked = true;
            }
            

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int ID;
            Int32.TryParse(comboBoxUserName.SelectedValue.ToString(), out ID);
            AccessArea(ID);
            MessageBox.Show("Update Successfully.....!!!!");
        }
    }
}
