using System.Diagnostics;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using BunifuAnimatorNS;
using System.Runtime.InteropServices;
using System.IO.Pipes;

namespace Test
{
    internal class Functions
    {

        public static void PopulateListBox(ListBox lsb, string Folder, string FileType)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dinfo.GetFiles(FileType);
            foreach (FileInfo file in Files)
            {
                lsb.Items.Add(file.Name);
            }
        }




    }
}