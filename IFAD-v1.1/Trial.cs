﻿using System;
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
    public partial class Trial : Form
    {
        public Trial()
        {
            InitializeComponent();
        }

        private void Trial_FormClosed(object sender, FormClosedEventArgs e)
        {

            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
            Close();
        }

        private void Trial_Load(object sender, EventArgs e)
        {

        }
    }
}
