namespace Test
{
    partial class shub
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.siticoneButton1 = new Siticone.UI.WinForms.SiticoneButton();
            this.siticoneButton7 = new Siticone.UI.WinForms.SiticoneButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Dex = new System.Windows.Forms.PictureBox();
            this.DarkHUB = new System.Windows.Forms.PictureBox();
            this.IY = new System.Windows.Forms.PictureBox();
            this.OwlHub = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DarkHUB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OwlHub)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.panel1.Controls.Add(this.siticoneButton1);
            this.panel1.Controls.Add(this.siticoneButton7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 35);
            this.panel1.TabIndex = 3;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // siticoneButton1
            // 
            this.siticoneButton1.CheckedState.Parent = this.siticoneButton1;
            this.siticoneButton1.CustomImages.Parent = this.siticoneButton1;
            this.siticoneButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.siticoneButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.siticoneButton1.ForeColor = System.Drawing.Color.White;
            this.siticoneButton1.HoveredState.Parent = this.siticoneButton1;
            this.siticoneButton1.Location = new System.Drawing.Point(154, 3);
            this.siticoneButton1.Name = "siticoneButton1";
            this.siticoneButton1.ShadowDecoration.Parent = this.siticoneButton1;
            this.siticoneButton1.Size = new System.Drawing.Size(73, 28);
            this.siticoneButton1.TabIndex = 8;
            this.siticoneButton1.Text = "Execute";
            this.siticoneButton1.Click += new System.EventHandler(this.siticoneButton1_Click);
            // 
            // siticoneButton7
            // 
            this.siticoneButton7.CheckedState.Parent = this.siticoneButton7;
            this.siticoneButton7.CustomImages.Parent = this.siticoneButton7;
            this.siticoneButton7.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.siticoneButton7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.siticoneButton7.ForeColor = System.Drawing.Color.White;
            this.siticoneButton7.HoveredState.Parent = this.siticoneButton7;
            this.siticoneButton7.Location = new System.Drawing.Point(233, 3);
            this.siticoneButton7.Name = "siticoneButton7";
            this.siticoneButton7.ShadowDecoration.Parent = this.siticoneButton7;
            this.siticoneButton7.Size = new System.Drawing.Size(29, 28);
            this.siticoneButton7.TabIndex = 7;
            this.siticoneButton7.Text = "X";
            this.siticoneButton7.Click += new System.EventHandler(this.siticoneButton7_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel2.Controls.Add(this.OwlHub);
            this.panel2.Controls.Add(this.IY);
            this.panel2.Controls.Add(this.DarkHUB);
            this.panel2.Controls.Add(this.Dex);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(265, 230);
            this.panel2.TabIndex = 4;
            // 
            // Dex
            // 
            this.Dex.Image = global::Test.Properties.Resources.Dark_Dex;
            this.Dex.Location = new System.Drawing.Point(12, 6);
            this.Dex.Name = "Dex";
            this.Dex.Size = new System.Drawing.Size(225, 124);
            this.Dex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Dex.TabIndex = 2;
            this.Dex.TabStop = false;
            this.Dex.Click += new System.EventHandler(this.Dex_Click);
            // 
            // DarkHUB
            // 
            this.DarkHUB.Image = global::Test.Properties.Resources.DarkHubLogo;
            this.DarkHUB.Location = new System.Drawing.Point(12, 136);
            this.DarkHUB.Name = "DarkHUB";
            this.DarkHUB.Size = new System.Drawing.Size(225, 124);
            this.DarkHUB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DarkHUB.TabIndex = 3;
            this.DarkHUB.TabStop = false;
            this.DarkHUB.Click += new System.EventHandler(this.DarkHUB_Click);
            // 
            // IY
            // 
            this.IY.Image = global::Test.Properties.Resources.InfiniteYield;
            this.IY.Location = new System.Drawing.Point(12, 265);
            this.IY.Name = "IY";
            this.IY.Size = new System.Drawing.Size(225, 121);
            this.IY.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IY.TabIndex = 5;
            this.IY.TabStop = false;
            this.IY.Click += new System.EventHandler(this.IY_Click);
            // 
            // OwlHub
            // 
            this.OwlHub.Image = global::Test.Properties.Resources.OwlHubWide;
            this.OwlHub.Location = new System.Drawing.Point(12, 395);
            this.OwlHub.Name = "OwlHub";
            this.OwlHub.Size = new System.Drawing.Size(225, 121);
            this.OwlHub.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OwlHub.TabIndex = 6;
            this.OwlHub.TabStop = false;
            this.OwlHub.Click += new System.EventHandler(this.OwlHub_Click);
            // 
            // shub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 265);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "shub";
            this.Text = "shub";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DarkHUB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OwlHub)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private Siticone.UI.WinForms.SiticoneButton siticoneButton7;
        private Siticone.UI.WinForms.SiticoneButton siticoneButton1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox OwlHub;
        private System.Windows.Forms.PictureBox IY;
        private System.Windows.Forms.PictureBox DarkHUB;
        private System.Windows.Forms.PictureBox Dex;
    }
}