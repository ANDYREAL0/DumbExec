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

namespace Test
{
    public partial class InjectDialog : Form
    {
        public InjectDialog()
        {
            InitializeComponent();
        }

        private void siticoneButton9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        Point lastPoint;

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void siticoneButton6_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            siticoneComboBox2.Items.Clear();
            foreach (Process processes in Process.GetProcessesByName("RobloxPlayerBeta"))
            {
                siticoneComboBox2.Items.Add(processes.ProcessName+ " (WEB)");
            }
            foreach (Process processes in Process.GetProcessesByName("Roblox"))
            {
                siticoneComboBox2.Items.Add(processes.ProcessName+" (UWP)");
            }
        }
    }
}
