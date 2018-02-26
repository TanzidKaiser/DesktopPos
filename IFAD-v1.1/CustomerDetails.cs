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
    public partial class CustomerDetails : Form
    {
        public CustomerDetails()
        {
            InitializeComponent();

            ShowTreeViewItem();

            string query = "SELECT * FROM [Group]";
            fillCombo(comboBoxCompany, query, "GroupName", "GroupID");
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
        public void ShowTreeViewItem()
        {
            treeViewALL.Nodes.Clear();
            string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection connection = new SqlConnection(conStr);
            string query = "SELECT * FROM [Group]";
            SqlCommand command1 = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command1.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                treeViewALL.Nodes.Add(reader["GroupName"].ToString());
                FirstChild(Convert.ToInt32(reader["GroupID"]), i);
                i++;


            }
            treeViewALL.TabStop = false;
            reader.Close();
            connection.Close();

        }
        public void FirstChild(int ComID, int i)
        {
            string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection connection1 = new SqlConnection(conStr);
            string query1 = "SELECT * FROM [Company] WHERE GroupID = '" + ComID + "'";
            SqlCommand command11 = new SqlCommand(query1, connection1);

            connection1.Open();
            SqlDataReader reader1 = command11.ExecuteReader();
            while (reader1.Read())
            {
                treeViewALL.Nodes[i].Nodes.Add(reader1["CompanyName"].ToString());
            }
            reader1.Close();
            connection1.Close();
        }
        private void CustomerDetails_Load(object sender, EventArgs e)
        {

        }
        private int GetCompany(string name)
        {
            int exist = 0;
            string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection con = new SqlConnection(conStr);
            string query = "SELECT * FROM [Group] WHERE GroupName='" + name + "'";
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                exist = Convert.ToInt32(reader["GroupID"]);
            }

            reader.Close();
            con.Close();
            return exist;
        }
        private void buttonAddCompany_Click(object sender, EventArgs e)
        {
            if (textBoxAddCompany.Text == "")
            {
                MessageBox.Show("Please fill the textbox..");
            }
            else if (GetCompany(textBoxAddCompany.Text) > 0)
            {
                textBoxAddCompany.Text = "";
                MessageBox.Show("**********Group Name is Already Exits!!!***********");

            }
            else
            {
                string Company = textBoxAddCompany.Text;
                string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
                SqlConnection connection = new SqlConnection(conStr);
                string query = "INSERT INTO [Group](GroupName) VALUES('" + Company + "')";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                int rowEffict = command.ExecuteNonQuery();
                connection.Close();
                if (rowEffict > 0)
                {
                    textBoxAddCompany.Text = string.Empty;
                    string query11 = "SELECT * FROM [Group]";
                    fillCombo(comboBoxCompany, query11, "GroupName", "GroupID");
                    ShowTreeViewItem();
                    MessageBox.Show("Group Insert Successfully !");
                }
            }
        }
        private int GetGroup(int CompanyID, string name)
        {
            int exist = 0;
            string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
            SqlConnection con = new SqlConnection(conStr);
            string query = "SELECT * FROM [Company] WHERE CompanyName='" + name + "' AND GroupID ='" + CompanyID + "'";
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                exist = Convert.ToInt32(reader["GroupID"]);
            }

            reader.Close();
            con.Close();
            return exist;
        }
        private void buttonAddGroup_Click(object sender, EventArgs e)
        {
            int val;
            Int32.TryParse(comboBoxCompany.SelectedValue.ToString(), out val);
            if (textBoxAddGroup.Text == "" && comboBoxCompany.SelectedText == "")
            {
                MessageBox.Show("Please fill the textbox..");
            }
            else if (GetGroup(val, textBoxAddGroup.Text) > 0)
            {
                textBoxAddGroup.Text = "";
                MessageBox.Show("**********Company Name is Already Exits!!!***********");

            }
            else
            {

                string Group = textBoxAddGroup.Text;
                string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
                SqlConnection connection = new SqlConnection(conStr);
                string query = "INSERT INTO [Company](GroupID,CompanyName) VALUES('" + val + "','" + Group + "')";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                int rowEffict = command.ExecuteNonQuery();
                connection.Close();
                if (rowEffict > 0)
                {
                    textBoxAddGroup.Text = string.Empty;
                    ShowTreeViewItem();
                    MessageBox.Show("Company Insert Successfully !");
                }
            }
        }
    }
}
