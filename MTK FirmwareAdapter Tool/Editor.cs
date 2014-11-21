using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace MTFAT
{
    public partial class Editor : Form
    {
        Point last;
        int y = 0;
        string f = null;
        string str = "Сохранить изменения?";
        string yes = "Да";
        string no = "Нет";
        string canc = "Отмена";

        public Editor(string d)
        {
            InitializeComponent();
            f = d;
        }
        public static int g = 0;

        private void Form4_Load(object sender, EventArgs e)
        {

            System.IO.StreamReader streamReader;
            streamReader = new System.IO.StreamReader(f, Encoding.ASCII, true);
            while (streamReader.EndOfStream == false)
            {
                richTextBox1.Text = streamReader.ReadToEnd();
            }
            streamReader.Close();
            файлToolStripMenuItem.Text = "Файл";
            toolStripMenuItem1.Text = "Правка";
            выходToolStripMenuItem.Text = "Выход";
            toolStripMenuItem2.Text = "Сохранить";
            toolStripMenuItem3.Text = toolStripMenuItem5.Text = "Отменить";
            toolStripMenuItem4.Text = toolStripMenuItem6.Text = "Повторить";
            вырезатьToolStripMenuItem1.Text = вырезатьToolStripMenuItem.Text = "Вырезать";
            копироватьToolStripMenuItem.Text = копироватьToolStripMenuItem1.Text = "Копировать";
            toolStripMenuItem8.Text = toolStripMenuItem7.Text = "Удалить";
            вставитьToolStripMenuItem.Text = вставитьToolStripMenuItem1.Text = "Вставить";
            выделитьВсёToolStripMenuItem.Text = выделитьВсёToolStripMenuItem1.Text = "Выделить всё";

            LangInit();

        }

        public void LangInit()
        {
            string ts = null;

            if (File.Exists("Bin/config.ini"))
            {
                IniFile loc = new IniFile(Directory.GetCurrentDirectory() + "/Bin/config.ini");
                if (loc.ReadString("language", "Language") != "") { ts = loc.ReadString("language", "Language"); }
            }

            if (File.Exists("Langs\\" + ts + ".ini"))
            {
                IniFile l = new IniFile(Directory.GetCurrentDirectory() + "/Langs/" + ts + ".ini");
                if (l.ReadString("editor", "file") != "") { файлToolStripMenuItem.Text = l.ReadString("editor", "file"); }
                if (l.ReadString("editor", "edit") != "") { toolStripMenuItem1.Text = l.ReadString("editor", "edit"); }
                if (l.ReadString("editor", "exit") != "") { выходToolStripMenuItem.Text = l.ReadString("editor", "exit"); }
                if (l.ReadString("editor", "save") != "") { toolStripMenuItem2.Text = l.ReadString("editor", "save"); }
                if (l.ReadString("editor", "undo") != "") { toolStripMenuItem3.Text = toolStripMenuItem5.Text = l.ReadString("editor", "undo"); }
                if (l.ReadString("editor", "redo") != "") { toolStripMenuItem4.Text = toolStripMenuItem6.Text = l.ReadString("editor", "redo"); }
                if (l.ReadString("editor", "cut") != "") { вырезатьToolStripMenuItem1.Text = вырезатьToolStripMenuItem.Text = l.ReadString("editor", "cut"); }
                if (l.ReadString("editor", "copy") != "") { копироватьToolStripMenuItem.Text = копироватьToolStripMenuItem1.Text = l.ReadString("editor", "copy"); }
                if (l.ReadString("editor", "del") != "") { toolStripMenuItem8.Text = toolStripMenuItem7.Text = l.ReadString("editor", "del"); }
                if (l.ReadString("editor", "paste") != "") { вставитьToolStripMenuItem.Text = вставитьToolStripMenuItem1.Text = l.ReadString("editor", "paste"); }
                if (l.ReadString("editor", "checkall") != "") { выделитьВсёToolStripMenuItem.Text = выделитьВсёToolStripMenuItem1.Text = l.ReadString("editor", "checkall"); }
                if (l.ReadString("editor", "str") != "") { str = l.ReadString("editor", "str"); }
                if (l.ReadString("editor", "yes") != "") { yes = l.ReadString("editor", "yes"); }
                if (l.ReadString("editor", "no") != "") { no = l.ReadString("editor", "no"); }
                if (l.ReadString("editor", "canc") != "") { canc = l.ReadString("editor", "canc"); }
            }
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void выделитьВсёToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                richTextBox1.Copy();
            }
            if (e.Control && e.KeyCode == Keys.X)
            {
                richTextBox1.Cut();
            }
            if (e.Control && e.KeyCode == Keys.V)
            {
                richTextBox1.Cut();
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{DEL}");
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (richTextBox1.Modified == true)
            {
                Message MS = new Message(null, str, null, canc, no, yes, null, 3, 0);
                MS.SetDesktopLocation(this.Location.X + (this.Width / 2) - (MS.Width / 2), this.Location.Y + (this.Height / 2) - (MS.Height / 2));
                MS.ShowDialog();
                int l = MS.fk;

                switch (l)
                {
                    case 3:
                        {
                            using (StreamWriter sw = new StreamWriter(f, false, Encoding.ASCII))
                            {
                                if (f.EndsWith("\\prop") == true)
                                {
                                    sw.Write(richTextBox1.Text);
                                    sw.Close();
                                    string Patch = Directory.GetCurrentDirectory() + "\\Bin\\trace.bat";
                                    StreamWriter BatFile = new StreamWriter(Patch, false, Encoding.GetEncoding(1250));
                                    BatFile.WriteLine("@echo off");
                                    BatFile.WriteLine("echo Starting ADB...");
                                    BatFile.WriteLine("cd /d \"" + Directory.GetCurrentDirectory() + "\\Bin");
                                    BatFile.WriteLine("adb start-server");
                                    BatFile.WriteLine("echo connect phone...");
                                    BatFile.WriteLine("rem adb wait-for-device");
                                    BatFile.WriteLine("adb shell su mount -o rw,remount /system");
                                    BatFile.WriteLine("echo Gett files from phone...");
                                    BatFile.WriteLine("adb remount");
                                    BatFile.WriteLine("adb push " + "\"" + Directory.GetCurrentDirectory() + "\\Utilits\\prop\"" + " /system/build.prop");
                                    BatFile.WriteLine("adb -d shell su -c \"chmod 0644 system/build.prop\"");
                                    BatFile.Close();


                                    Process win = new Process();
                                    win.StartInfo.ErrorDialog = true;
                                    win.StartInfo.FileName = Directory.GetCurrentDirectory() + "\\Bin\\trace.bat";
                                    win.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                    this.Cursor = Cursors.WaitCursor;
                                    win.Start();
                                    win.WaitForExit();
                                    this.Cursor = Cursors.Default;

                                    Process winс = new Process();
                                    winс.StartInfo.FileName = "taskkill";
                                    winс.StartInfo.Arguments = "/F /IM adb.exe";
                                    winс.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                    this.Cursor = Cursors.WaitCursor;
                                    winс.Start();
                                    winс.WaitForExit();
                                    this.Cursor = Cursors.Default;

                                    File.Delete("Bin\\trace.bat");
                                    File.Delete("Utilits\\prop");
                                }
                                else
                                {
                                    if (f.EndsWith(".fat"))
                                    {
                                        sw.Write(richTextBox1.Text);
                                        sw.Close();

                                        Form1 main = this.Owner as Form1;

                                        StreamReader SR = new StreamReader("WorkDIR\\Temp.fat");
                                        main.checkedListBox1.Items.Clear();
                                        while (SR.EndOfStream == false)
                                        {
                                            main.checkedListBox1.Items.Add(SR.ReadLine());
                                        }
                                        SR.Close();

                                        File.Delete("WorkDIR\\Temp.fat");
                                    }
                                    else
                                    {
                                        sw.Write(richTextBox1.Text);
                                        sw.Close();
                                    }
                                }
                            }
                            break;
                        }
                    case 1:
                        {
                            e.Cancel = true;
                            break;
                        }
                    case 2:
                        {
                            return;
                        }
                }
            }
            else
                if (File.Exists("WorkDIR\\Temp.fat"))
                    File.Delete("WorkDIR\\Temp.fat");

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(f, false, Encoding.ASCII))
            {
                sw.Write(richTextBox1.Text);
                sw.Close();
            }
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (y == 0)
            {
                this.WindowState = FormWindowState.Maximized;
                y++;
                button2.Image = MFAT.Properties.Resources.Maxi;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                y--;
                button2.Image = MFAT.Properties.Resources.Normal;
            }

        }

        private void Editor_Resize(object sender, EventArgs e)
        {
            button1.Left = this.Width - 48;
            button2.Left = this.Width - 82;
            button3.Left = this.Width - 116;
        }

        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                last = MousePosition;
            }
        }

        private void richTextBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point cur = MousePosition;
                int dx = cur.X - last.X;
                int dy = cur.Y - last.Y;
                Point loc = new Point(Location.X + dx, Location.Y + dy);
                Location = loc;
                last = cur;
            }
        }
    }
}
