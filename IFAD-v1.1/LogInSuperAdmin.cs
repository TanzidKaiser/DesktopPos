using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFAD_v1._1
{
    public partial class LogInSuperAdmin : Form
    {
        public LogInSuperAdmin()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxUser.Text=="")
                {
                    MessageBox.Show("User Name Cann't Empty..");
                }
                else if (textBoxPassword.Text == "")
                {
                    MessageBox.Show("User Password Cann't Empty..");
                }
                else if (textBoxUser.Text != "superadmin")
                {
                    MessageBox.Show("Wrong User Name..");
                }
                else if (textBoxPassword.Text != "@sonali123")
                {
                    MessageBox.Show("Wrong Password..");
                }
                else
                {
                    SuperAdmin sa = new SuperAdmin();
                    sa.Show();
                    //Hide();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonUserLogIn_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            Close();
        }
    }
}
