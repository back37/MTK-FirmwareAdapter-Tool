using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace MTFAT
{
    public partial class About : Form
    {
       public About()
        {
            InitializeComponent();
            LangInit();
        }

        public void LangInit()
        {
           string ts=null;
           if (File.Exists("Bin/config.ini"))
           {
               IniFile loc = new IniFile(Directory.GetCurrentDirectory() + "/Bin/config.ini");
               if (loc.ReadString("language", "Language") != "") { ts = loc.ReadString("language", "Language"); }
           }

           if (File.Exists("Langs\\" + ts + ".ini"))
           {
               IniFile l = new IniFile(Directory.GetCurrentDirectory() + "/Langs/" + ts + ".ini");
               if (l.ReadString("about", "group") != "") { groupBox2.Text = l.ReadString("about", "group"); }
               if (l.ReadString("about", "author") != "") { label1.Text = l.ReadString("about", "author") + " Back37"; }
               if (l.ReadString("about", "4pd") != "") { label2.Text = l.ReadString("about", "4pd"); }
               if (l.ReadString("about", "ch") != "") { label3.Text = l.ReadString("about", "ch"); }
               if (l.ReadString("about", "xda") != "") { label4.Text = l.ReadString("about", "xda"); }
           }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("http://4pda.ru/forum/index.php?showuser=397491");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel2.LinkVisited = true;
            System.Diagnostics.Process.Start("http://forum.china-iphone.ru/member97433.html");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel3.LinkVisited = true;
            System.Diagnostics.Process.Start("http://forum.xda-developers.com/member.php?u=4745100");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel4.LinkVisited = true;
            System.Diagnostics.Process.Start("http://iambackx5@gmail.com");
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel5.LinkVisited = true;
            System.Diagnostics.Process.Start("http://4pda.ru/forum/index.php?showtopic=465994");
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel6.LinkVisited = true;
            System.Diagnostics.Process.Start("http://forum.china-iphone.ru/nuansi-portirovaniya-proshivok-t25594.html");
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel7.LinkVisited = true;
            System.Diagnostics.Process.Start("http://forum.xda-developers.com/showthread.php?t=2123239");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel8.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/back37/MTK-FirmwareAdapter-Tool");
        }

    }
}
