using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFAD_v1._1
{
    public partial class ServerTime : Form
    {
        public ServerTime()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string machineName = "Kamrul-pc";
                Process proc = new Process();
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.FileName = "net";
                proc.StartInfo.Arguments = @"time \\" + machineName;
                proc.Start();
                proc.WaitForExit();

                List<string> results = new List<string>();

                while (!proc.StandardOutput.EndOfStream)
                {
                    string currentline = proc.StandardOutput.ReadLine();

                    if (!string.IsNullOrEmpty(currentline))
                    {
                        results.Add(currentline);
                    }
                }

                string currentTime = string.Empty;

                if (results.Count > 0 && results[0].ToLower().StartsWith(@"current time at \\" + machineName.ToLower() + " is "))
                {
                    currentTime = results[0].Substring((@"current time at \\" +
                                  machineName.ToLower() + " is ").Length);

                    //Console.WriteLine(DateTime.Parse(currentTime));
                    //Console.ReadLine();
                    label2.Text = "Server Time Is : "+currentTime;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private void ServerTime_Load(object sender, EventArgs e)
        {
            label1.Text="Local Time is : "+DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        }
    }
}
