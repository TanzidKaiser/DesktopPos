using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace IFAD_v1._1
{
    public partial class WarehouseSettings : Form
    {
        public WarehouseSettings()
        {
            InitializeComponent();
            string query = "SELECT * FROM LocationMain";
            fillCombo(comboBoxWarehouseNameInRack, query, "LocationMainName", "LocationMainID");
            fillCombo(comboBoxWarehouseNameInCell, query, "LocationMainName", "LocationMainID");


            FillCateMainCate();
            //Sub Category state
            FillSubMainCategory();
        }

        private void FillCateMainCate()
        {
            string query12 = "SELECT * FROM LocationMain";
            fillCombo(comboBoxEditRackWarehouse, query12, "LocationMainName", "LocationMainID");
        }
        private void FillSubMainCategory()
        {
            string query12 = "SELECT * FROM LocationMain";
            fillCombo(comboBoxEditCellWarehouse, query12, "LocationMainName", "LocationMainID");
        }

        public void DataGridWareHouse()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT LocationMainName as 'Name',  LocationMainID as 'ID' FROM LocationMain";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewWarehouse.DataSource = dt;
            con.Close();
        }
        string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable table;
        public void fillCombo(ComboBox combo, string query, string displayMember, string valueMember)
        {
            command = new SqlCommand(query, con);
            adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            combo.DataSource = table;
            combo.DisplayMember = displayMember;
            combo.ValueMember = valueMember;

        }

        private int Get_WarehouseName(string name)
        {
            int exist = 0;
            SqlConnection con = new SqlConnection(conStr);
            string query = "SELECT * FROM LocationMain WHERE LocationMainName ='" + name + "'";
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                exist = Convert.ToInt32(reader["LocationMainID"]);
            }

            reader.Close();
            con.Close();
            return exist;
        }

        private int Get_RackName(int LocationMainID, string name)
        {
            int exist = 0;
            SqlConnection con = new SqlConnection(conStr);
            string query = "SELECT * FROM Location WHERE LocationName='" + name + "' AND LocationMainID ='" + LocationMainID + "'";
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                exist = Convert.ToInt32(reader["LocationID"]);
            }

            reader.Close();
            con.Close();
            return exist;
        }

        private int Get_CellName(int val2, string name)
        {
            int exist = 0;
            SqlConnection con = new SqlConnection(conStr);
            string query = "SELECT * FROM LocationSub WHERE LocationSubName='" + name + "' AND LocationID='" + val2 + "'";
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                exist = Convert.ToInt32(reader["LocationSubID"]);
            }

            reader.Close();
            con.Close();
            return exist;
        }
        private void AddWarehouseButton_Click(object sender, EventArgs e)
        {
            if (textBoxAddWarehouse.Text == "")
            {
                MessageBox.Show("Please type Warehouse Name");
            }
            else if (Get_WarehouseName(textBoxAddWarehouse.Text) > 0)
            {
                textBoxAddWarehouse.Text = "";
                MessageBox.Show("**********Warehouse name is Already Exits!!!***********");

            }
            else
            {
                string addWarehouseName = textBoxAddWarehouse.Text;
                SqlConnection connection = new SqlConnection(conStr);
                string query = "INSERT INTO LocationMain (LocationMainName) VALUES('" + addWarehouseName + "')";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                int rowEffict = command.ExecuteNonQuery();
                connection.Close();
                if (rowEffict > 0)
                {
                    textBoxAddWarehouse.Text = string.Empty;
                    string query11 = "SELECT * FROM LocationMain";
                    fillCombo(comboBoxWarehouseNameInRack, query11, "LocationMainName", "LocationMainID");
                    fillCombo(comboBoxWarehouseNameInCell, query11, "LocationMainName", "LocationMainID");
                    MessageBox.Show("Warehouse Name Added Successfully !");
                }
            }
        }

        private void buttonAddRack_Click(object sender, EventArgs e)
        {
            int val;
            Int32.TryParse(comboBoxWarehouseNameInRack.SelectedValue.ToString(), out val);
            if (textBoxAddRack.Text == "" && comboBoxWarehouseNameInRack.SelectedText == "")
            {
                MessageBox.Show("Please fill the textbox..");
            }
            else if (Get_RackName(val, textBoxAddRack.Text) > 0)
            {
                textBoxAddRack.Text = "";
                MessageBox.Show("**********This Rack Name is Already Exits!!!***********");
            }
            else
            {

                string addRack = textBoxAddRack.Text;
                SqlConnection connection = new SqlConnection(conStr);
                string query = "INSERT INTO Location VALUES('" + val + "','" + addRack + "')";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                int rowEffict = command.ExecuteNonQuery();
                connection.Close();
                if (rowEffict > 0)
                {
                    textBoxAddRack.Text = string.Empty;
                    string query11 = "SELECT * FROM LocationMain";
                    fillCombo(comboBoxWarehouseNameInCell, query11, "LocationMainName", "LocationMainID");
                    MessageBox.Show("New Rack Added Successfully !");
                }
            }
        }

        private void buttonAddCell_Click(object sender, EventArgs e)
        {
            try
            {
                int val2;
                Int32.TryParse(comboBoxRackNameInCell.SelectedValue.ToString(), out val2);

                if (textBoxAddCell.Text == "")
                {
                    MessageBox.Show("Please Fill all information....");
                }
                else if (Get_CellName(val2, textBoxAddCell.Text) > 0)
                {
                    textBoxAddCell.Text = "";
                    MessageBox.Show("**********This Cell Name is Already Exits!!!***********");

                }
                else
                {
                    int val1;
                    Int32.TryParse(comboBoxWarehouseNameInCell.SelectedValue.ToString(), out val1);



                    string addCellName = textBoxAddCell.Text;
                    string conStr = ConfigurationManager.ConnectionStrings["PosConString"].ToString();
                    SqlConnection connection = new SqlConnection(conStr);
                    string query11 = "INSERT INTO LocationSub VALUES('" + val1 + "','" + val2 + "','" + addCellName + "')";
                    SqlCommand command = new SqlCommand(query11, connection);
                    connection.Open();
                    int rowEffict = command.ExecuteNonQuery();
                    connection.Close();
                    if (rowEffict > 0)
                    {
                        //string query1111 = "SELECT * FROM maincategory";
                        //fillCombo(comboBoxAddMainCateS4, query1111, "maincate_name", "maincate_id");
                        textBoxAddCell.Text = string.Empty;
                        MessageBox.Show("New Cell Added Successfully !");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxWarehouseNameInCell_SelectedIndexChanged(object sender, EventArgs e)
        {
            int val;
            Int32.TryParse(comboBoxWarehouseNameInCell.SelectedValue.ToString(), out val);
            string query = "SELECT * FROM Location WHERE LocationMainID = " + val;

            fillCombo(comboBoxRackNameInCell, query, "LocationName", "LocationID");
        }

        private void WarehouseSettings_Load(object sender, EventArgs e)
        {
            DataGridWareHouse();
        }
        public void DataGridRack(int id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT LocationName as 'Name',  LocationID as 'ID' FROM Location WHERE LocationMainID='"+id+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewRack.DataSource = dt;
            con.Close();
        }
        private void comboBoxEditRackWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            Int32.TryParse(comboBoxEditRackWarehouse.SelectedValue.ToString(), out id);
            DataGridRack(id);
        }

        private void comboBoxEditCellWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            Int32.TryParse(comboBoxEditCellWarehouse.SelectedValue.ToString(), out id);

            string query12 = "SELECT * FROM Location WHERE LocationMainID='"+id+"'";
            fillCombo(comboBoxEditCellRack, query12, "LocationName", "LocationID");
        }
        public void DataGridCell(int id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosConString"].ToString());
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT LocationSubName as 'Name',  LocationSubID as 'ID' FROM LocationSub WHERE LocationID='" + id + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewCell.DataSource = dt;
            con.Close();
        }
        private void comboBoxEditCellRack_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            Int32.TryParse(comboBoxEditCellRack.SelectedValue.ToString(), out id);
            DataGridCell(id);
        }

        private void dataGridViewWarehouse_DoubleClick(object sender, EventArgs e)
        {
            textBoxWarehouse.Text = textBoxWarehouseID.Text = "";
            textBoxWarehouse.Text = dataGridViewWarehouse.SelectedRows[0].Cells[0].Value.ToString();
            textBoxWarehouseID.Text = dataGridViewWarehouse.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void buttonUpdateWarehouse_Click(object sender, EventArgs e)
        {
            if (textBoxWarehouse.Text == "")
            {
                MessageBox.Show("Please Double Click in Data Grid View...");
            }
            else if (textBoxWarehouseID.Text == "")
            {
                MessageBox.Show("Please Double Click in Data Grid View...");
            }
            else
            {
                try
                {
                    string main_cate_name = textBoxWarehouse.Text;
                    int main_cate_id = Convert.ToInt32(textBoxWarehouseID.Text);
                    SqlConnection connection1 = new SqlConnection(conStr);
                    string query1 = "UPDATE LocationMain SET LocationMainName = '" + main_cate_name + "' WHERE LocationMainID = '" + main_cate_id + "'";
                    SqlCommand command1 = new SqlCommand(query1, connection1);
                    connection1.Open();
                    int rowEffict1 = command1.ExecuteNonQuery();
                    connection1.Close();
                    if (rowEffict1 > 0)
                    {
                        DataGridWareHouse();
                        FillCateMainCate();
                        textBoxWarehouse.Text = textBoxWarehouseID.Text = "";
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridViewRack_DoubleClick(object sender, EventArgs e)
        {
            textBoxRack.Text = textBoxRackID.Text = "";
            textBoxRack.Text = dataGridViewRack.SelectedRows[0].Cells[0].Value.ToString();
            textBoxRackID.Text = dataGridViewRack.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void buttonUpdateRack_Click(object sender, EventArgs e)
        {
            if (textBoxRack.Text == "")
            {
                MessageBox.Show("Please Double Click in Data Grid View...");
            }
            else if (textBoxRackID.Text == "")
            {
                MessageBox.Show("Please Double Click in Data Grid View...");
            }
            else
            {
                try
                {
                    string main_cate_name = textBoxRack.Text;
                    int main_cate_id = Convert.ToInt32(textBoxRackID.Text);
                    SqlConnection connection1 = new SqlConnection(conStr);
                    string query1 = "UPDATE Location SET LocationName = '" + main_cate_name + "' WHERE LocationID = '" + main_cate_id + "'";
                    SqlCommand command1 = new SqlCommand(query1, connection1);
                    connection1.Open();
                    int rowEffict1 = command1.ExecuteNonQuery();
                    connection1.Close();
                    if (rowEffict1 > 0)
                    {
                        DataGridRack(main_cate_id);
                        FillSubMainCategory();
                        textBoxRack.Text = textBoxRackID.Text = "";
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridViewCell_DoubleClick(object sender, EventArgs e)
        {
            textBoxCell.Text = textBoxCellID.Text = "";
            textBoxCell.Text = dataGridViewCell.SelectedRows[0].Cells[0].Value.ToString();
            textBoxCellID.Text = dataGridViewCell.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void buttonUpdateCell_Click(object sender, EventArgs e)
        {
            if (textBoxCell.Text == "")
            {
                MessageBox.Show("Please Double Click in Data Grid View...");
            }
            else if (textBoxCellID.Text == "")
            {
                MessageBox.Show("Please Double Click in Data Grid View...");
            }
            else
            {
                try
                {
                    string main_cate_name = textBoxCell.Text;
                    int main_cate_id = Convert.ToInt32(textBoxCellID.Text);
                    SqlConnection connection1 = new SqlConnection(conStr);
                    string query1 = "UPDATE LocationSub SET LocationSubName = '" + main_cate_name + "' WHERE LocationSubID = '" + main_cate_id + "'";
                    SqlCommand command1 = new SqlCommand(query1, connection1);
                    connection1.Open();
                    int rowEffict1 = command1.ExecuteNonQuery();
                    connection1.Close();
                    if (rowEffict1 > 0)
                    {
                        DataGridCell(main_cate_id);
                        FillSubMainCategory();
                        textBoxCell.Text = textBoxCellID.Text = "";
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
