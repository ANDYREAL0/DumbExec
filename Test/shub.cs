using System;
using System.Drawing;
using System.Windows.Forms;

namespace Test
{
    public partial class shub : Form
    {
        Point lastPoint;
        public string s_hub = string.Empty;
        Form2 form;
        public shub(Form2 f)
        {
            InitializeComponent();
            this.form = f;
        }

        private void siticoneButton7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void f(Control f)
        {
            DarkHUB.BackColor = Color.FromArgb(45, 45, 45);
            Dex.BackColor = Color.FromArgb(45, 45, 45);
            IY.BackColor = Color.FromArgb(45, 45, 45);
            OwlHub.BackColor = Color.FromArgb(45, 45, 45);
            f.BackColor = Color.FromArgb(35, 35, 35);
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            if (s_hub != string.Empty)
            {
                form.exec(s_hub);
            }
            //form.msg("Script not selected!");
        }

        private void Dex_Click(object sender, EventArgs e)
        {
            f(Dex);
        }

        private void DarkHUB_Click(object sender, EventArgs e)
        {
            f(DarkHUB);
        }

        private void IY_Click(object sender, EventArgs e)
        {
            f(IY);
        }

        private void OwlHub_Click(object sender, EventArgs e)
        {
            f(OwlHub);
        }
    }
}
