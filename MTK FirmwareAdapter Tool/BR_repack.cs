using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace MTFAT
{
    public partial class BR_repack : Form
    {
        Point last;
        public int f = 0;
        string succ = "получен успешно";
        string attention = "Внимание!";
        string str = "Проверьте работоспособность";
        string str1 = "Если всё работает, нажмите Да";
        string str2 = "Иначе, нажмите Нет";
        string no = "Нет";
        string yes = "Да";
        string build = "Был успешно собран";
        string ok = "Ок";

        public void glassTabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                last = MousePosition;
            }
        }

        public void glassTabControl1_MouseMove(object sender, MouseEventArgs e)
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

        public BR_repack(bool d)
        {
            InitializeComponent();

            comboBox1.SelectedIndex = 0;

            if (Directory.Exists("Utilits\\IMGRepack") == false)
                Directory.CreateDirectory("Utilits\\IMGRepack");

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
                if (l.ReadString("repacker", "choosepc1") != "") { button1.Text = l.ReadString("repacker", "choosepc1") + " " + comboBox1.SelectedItem; }
                if (l.ReadString("repacker", "choosepc2") != "") { button1.Text += "\n" + l.ReadString("repacker", "choosepc2"); }
                if (l.ReadString("repacker", "choosep1") != "") { button2.Text = l.ReadString("repacker", "choosep1") + " " + comboBox1.SelectedItem; }
                if (l.ReadString("repacker", "choosep2") != "") { button2.Text += "\n" + l.ReadString("repacker", "choosep2"); }
                if (l.ReadString("repacker", "open") != "") { button3.Text = l.ReadString("repacker", "open") + " " + comboBox1.SelectedItem; }
                if (l.ReadString("repacker", "build") != "") { button4.Text = l.ReadString("repacker", "build") + " " + comboBox1.SelectedItem; }
                if (l.ReadString("repacker", "open1") != "") { button5.Text = l.ReadString("repacker", "open1"); }
                if (l.ReadString("repacker", "open2") != "") { button5.Text += "\n" + l.ReadString("repacker", "open2") + " " + comboBox1.SelectedItem; }
                if (l.ReadString("repacker", "sent1") != "") { button6.Text = l.ReadString("repacker", "sent1"); }
                if (l.ReadString("repacker", "sent2") != "") { button6.Text +="\n" + comboBox1.SelectedItem + " " + l.ReadString("repacker", "sent2"); }
                if (l.ReadString("repacker", "succ") != "") { succ = l.ReadString("repacker", "succ"); }
                if (l.ReadString("repacker", "attention") != "") { attention = l.ReadString("repacker", "attention"); }
                if (l.ReadString("repacker", "str") != "") { str = l.ReadString("repacker", "str"); }
                if (l.ReadString("repacker", "str1") != "") { str1 = l.ReadString("repacker", "str1"); }
                if (l.ReadString("repacker", "str2") != "") { str2 = l.ReadString("repacker", "str2"); }
                if (l.ReadString("repacker", "no") != "") { no = l.ReadString("repacker", "no"); }
                if (l.ReadString("repacker", "yes") != "") { yes = l.ReadString("repacker", "yes"); }
                if (l.ReadString("repacker", "build") != "") { build = l.ReadString("repacker", "build"); }
                if (l.ReadString("repacker", "ok") != "") { ok = l.ReadString("repacker", "ok"); }
            }
            else
            {
                button1.Text = "Указать " + comboBox1.SelectedItem + "\nна компьютере";
                button2.Text = "Получить " + comboBox1.SelectedItem + "\nс телефона";
                button3.Text = "Открыть папку с распакованным " + comboBox1.SelectedItem;
                button4.Text = "Собрать отредактированный " + comboBox1.SelectedItem;
                button5.Text = "Открыть папку с\nновым " + comboBox1.SelectedItem;
                button6.Text = "Послать " + comboBox1.SelectedItem + "\nна телефон";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process[] ps1 = System.Diagnostics.Process.GetProcessesByName("adb");
            foreach (Process p1 in ps1)
            {
                p1.Kill();
            }

            string Patch = Directory.GetCurrentDirectory() + @"\Bin\trace.bat";
            StreamWriter BatFile = new StreamWriter(Patch, false, Encoding.GetEncoding(866));
            BatFile.WriteLine("@echo off");
            BatFile.WriteLine("echo Starting ADB...");
            BatFile.WriteLine("adb start-server");
            BatFile.WriteLine("echo connect phone...");
            BatFile.WriteLine("rem adb wait-for-device");
            BatFile.WriteLine("echo Gett files from phone...");
            BatFile.WriteLine("adb remount");
            BatFile.WriteLine("adb shell su -c \"mkdir /data/tmp/\"");
            if (comboBox1.SelectedIndex == 0)
            {
                BatFile.WriteLine("adb shell su -c \"dd if=/dev/bootimg of=/data/tmp/boot.img bs=6291456c count=1\"");
                BatFile.WriteLine("adb pull /data/tmp/boot.img " + "boot.img");
                BatFile.WriteLine("adb shell su -c \"rm /data/tmp/boot.img\"");
            }
            else
            {
                BatFile.WriteLine("adb shell su -c \"dd if=/dev/recovery of=/data/tmp/recovery.img bs=6291456c count=1\"");
                BatFile.WriteLine("adb pull /data/tmp/recovery.img " + "recovery.img");
                BatFile.WriteLine("adb shell su -c \"rm /data/tmp/recovery.img\"");
            }
            BatFile.WriteLine("taskkill /F /IM adb.exe");
            BatFile.Close();

            Process win = new Process();
            win.StartInfo.ErrorDialog = true;
            win.StartInfo.FileName = Patch;
            win.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            this.Cursor = Cursors.WaitCursor;
            win.Start();
            win.WaitForExit();
            this.Cursor = Cursors.Default;
            File.Delete("Bin\\trace.bat");
// Начало распаковки
            if (Directory.Exists("Utilits\\IMGRepack") == true)
                Directory.Delete("Utilits\\IMGRepack", true);
            Directory.CreateDirectory("Utilits\\IMGRepack");

            string Patch1 = Directory.GetCurrentDirectory() + @"\Bin\trace1.bat";
            StreamWriter BatFile1 = new StreamWriter(Patch1, false, Encoding.GetEncoding(866));
            BatFile1.WriteLine("cd /d \"" + Directory.GetCurrentDirectory() + "\\Bin\"");
            if (comboBox1.SelectedIndex == 0)
            {
                BatFile1.WriteLine("imgunpack.cmd boot.img");
            }
            else
            {
                BatFile1.WriteLine("imgunpack.cmd recovery.img");
            }
            BatFile1.Close();

            Process winc = new Process();
            winc.StartInfo.ErrorDialog = true;
            winc.StartInfo.FileName = Patch;
            winc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            this.Cursor = Cursors.WaitCursor;
            winc.Start();
            winc.WaitForExit();
            this.Cursor = Cursors.Default;

            File.Delete("Bin\\trace1.bat");
            File.Delete("Bin\\"+ comboBox1.SelectedItem);

            Process win1 = new Process();
            string Patch2 = Directory.GetCurrentDirectory() + @"\Bin\trace2.bat";
            StreamWriter perm = new StreamWriter(Patch2, false, Encoding.GetEncoding(866));
            perm.WriteLine("cmd.exe /c takeown /f \"" + Directory.GetCurrentDirectory() + "\\Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()) + "\"" + "  /r /d y && icacls  \"" + Directory.GetCurrentDirectory() + "\\Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()) + "\"" + " /grant %username%:F /t");
            //perm.WriteLine("cmd.exe /c takeown /f \"" + Directory.GetCurrentDirectory() + "\\Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()) + "\"" + " && icacls /\"" + Directory.GetCurrentDirectory() + "\\Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()) + "\"" + " /grant все:F");
            perm.WriteLine("cmd.exe /c takeown /f \"" + Directory.GetCurrentDirectory() + "\\Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()) + "\"" + "  /r /d y && icacls  \"" + Directory.GetCurrentDirectory() + "\\Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()) + "\"" + " /grant все:F /t");
            //perm.WriteLine("cmd.exe /c takeown /f \"" + Directory.GetCurrentDirectory() + "\\Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()) + "\"" + " && icacls /\"" + Directory.GetCurrentDirectory() + "\\Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()) + "\"" + " /grant all:F");
            perm.WriteLine("cmd.exe /c takeown /f \"" + Directory.GetCurrentDirectory() + "\\Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()) + "\"" + "  /r /d y && icacls  \"" + Directory.GetCurrentDirectory() + "\\Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()) + "\"" + " /grant all:F /t");
            //perm.WriteLine("cmd.exe /c takeown /f \"" + Directory.GetCurrentDirectory() + "\\Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()) + "\"" + " && icacls /\"" + Directory.GetCurrentDirectory() + "\\Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()) + "\"" + " /grant %username%:F");
            perm.Close();
            win1.StartInfo.ErrorDialog = true;
            win1.StartInfo.FileName = Patch2;
            this.Cursor = Cursors.WaitCursor;
            win1.Start();
            win1.WaitForExit();
            this.Cursor = Cursors.Default;

            if (Directory.Exists("Bin\\boot"))
            {
                if (Directory.Exists("Utilits\\IMGRepack\\boot"))
                    Directory.Delete("Utilits\\IMGRepack\\boot", true);
                Directory.Move("Bin\\boot", "Utilits\\IMGRepack\\boot");
            }

            if (Directory.Exists("Bin\\recovery"))
            {
                if (Directory.Exists("Utilits\\IMGRepack\\recovery"))
                    Directory.Delete("Utilits\\IMGRepack\\recovery", true);
                Directory.Move("Bin\\recovery", "Utilits\\IMGRepack\\recovery");
            }

            Message MS = new Message(null, comboBox1.SelectedItem + " " + succ, null, ok, null, null, null, 1, 5);
            MS.SetDesktopLocation(this.Location.X + (this.Width / 2) - (MS.Width / 2), this.Location.Y + (this.Height / 2) - (MS.Height / 2));
            MS.ShowDialog();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string Patch = Directory.GetCurrentDirectory() + @"\trace.bat";
            StreamWriter BatFile = new StreamWriter(Patch, false, Encoding.GetEncoding(866));
            if (File.Exists("Utilits\\IMGRepack\\" + comboBox1.SelectedItem) == false)
                return;
            else
            {
                BatFile.WriteLine("@echo off");
                BatFile.WriteLine("echo Starting ADB...");
                BatFile.WriteLine("adb start-server");
                BatFile.WriteLine("echo connect phone...");
                BatFile.WriteLine("rem adb wait-for-device");
                BatFile.WriteLine("echo Gett files from phone...");
                BatFile.WriteLine("adb remount");
                BatFile.WriteLine("adb shell su -c \"mkdir /data/tmp/\"");
                if (comboBox1.SelectedIndex == 0)
                {
                    BatFile.WriteLine("adb shell su -c \"dd if=/dev/bootimg of=/data/tmp/boot.img bs=6291456c count=1\"");
                    BatFile.WriteLine("adb pull /data/tmp/boot.img " + "Utilits\\IMGRepack\\bootO.img");
                    BatFile.WriteLine("adb shell su -c \"rm /data/tmp/boot.img\"");
                }
                else
                {
                    BatFile.WriteLine("adb shell su -c \"dd if=/dev/recovery of=/data/tmp/recovery.img bs=6291456c count=1\"");
                    BatFile.WriteLine("adb pull /data/tmp/recovery.img " + "Utilits\\IMGRepack\\recoveryO.img");
                    BatFile.WriteLine("adb shell su -c \"rm /data/tmp/recovery.img\"");
                }
                BatFile.WriteLine("taskkill /F /IM adb.exe");
                BatFile.WriteLine("adb remount");
                BatFile.WriteLine("adb shell su -c \"mkdir /data/tmp/\"");

                if (comboBox1.SelectedIndex == 0)
                {
                    BatFile.WriteLine("adb push Utilits\\IMGRepack\\boot.img " + "/data/tmp/boot.img");
                    BatFile.WriteLine("adb shell su -c \"dd if=/data/tmp/boot.img of=/dev/bootimg bs=6291456c count=1\"");
                    BatFile.WriteLine("adb shell su -c \"rm /data/tmp/boot.img\"");
                }
                else
                {
                    BatFile.WriteLine("adb push Utilits\\IMGRepack\\recovery.img " + "/data/tmp/recovery.img");
                    BatFile.WriteLine("adb shell su -c \"dd if=/data/tmp/recovery.img of=/dev/recovery bs=6291456c count=1\"");
                    BatFile.WriteLine("adb shell su -c \"rm /data/tmp/recovery.img\"");
                }
                BatFile.WriteLine("taskkill /F /IM adb.exe");
                BatFile.Close();

                Process win = new Process();
                win.StartInfo.ErrorDialog = true;
                win.StartInfo.FileName = Patch;
                win.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                this.Cursor = Cursors.WaitCursor;
                win.Start();
                win.WaitForExit();
                this.Cursor = Cursors.Default;
                File.Delete("Bin\\trace.bat");

                Message MS = new Message(attention, str, str1 + "\n" + str2, no, yes, null, null, 2, 0);
                MS.SetDesktopLocation(this.Location.X + (this.Width / 2) - (MS.Width / 2), this.Location.Y + (this.Height / 2) - (MS.Height / 2));
                MS.ShowDialog();
                this.f = MS.fk;

                if (f == 1)
                {
                    string Patch1 = Directory.GetCurrentDirectory() + @"\trace1.bat";
                    StreamWriter BatFile1 = new StreamWriter(Patch1, false, Encoding.GetEncoding(866));
                    BatFile1.WriteLine("@echo off");
                    BatFile1.WriteLine("echo Starting ADB...");
                    BatFile1.WriteLine("adb start-server");
                    BatFile1.WriteLine("echo connect phone...");
                    BatFile1.WriteLine("rem adb wait-for-device");
                    BatFile1.WriteLine("echo Gett files from phone...");
                    BatFile1.WriteLine("adb remount");
                    BatFile1.WriteLine("adb shell su -c \"mkdir /data/tmp/\"");

                    if (comboBox1.SelectedIndex == 0)
                    {
                        BatFile1.WriteLine("adb push Utilits\\IMGRepack\\bootO.img " + "/data/tmp/boot.img");
                        BatFile1.WriteLine("adb shell su -c \"dd if=/data/tmp/boot.img of=/dev/bootimg bs=6291456c count=1\"");
                        BatFile1.WriteLine("adb shell su -c \"rm /data/tmp/boot.img\"");
                    }
                    else
                    {
                        BatFile1.WriteLine("adb push Utilits\\IMGRepack\\recoveryO.img " + "/data/tmp/recovery.img");
                        BatFile1.WriteLine("adb shell su -c \"dd if=/data/tmp/recovery.img of=/dev/recovery bs=6291456c count=1\"");
                        BatFile1.WriteLine("adb shell su -c \"rm /data/tmp/recovery.img\"");
                    }
                    BatFile1.WriteLine("taskkill /F /IM adb.exe");
                    BatFile1.Close();

                    Process win1 = new Process();
                    win1.StartInfo.ErrorDialog = true;
                    win1.StartInfo.FileName = "trace1.bat";
                    win1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    this.Cursor = Cursors.WaitCursor;
                    win1.Start();
                    win1.WaitForExit();
                    this.Cursor = Cursors.Default;
                    File.Delete("Bin\\trace1.bat");
                }

                if (File.Exists("Utilits\\IMGRepack\\bootO.img"))
                    File.Delete("Utilits\\IMGRepack\\bootO.img");
                if (File.Exists("Utilits\\IMGRepack\\recoveryO.img"))
                    File.Delete("Utilits\\IMGRepack\\recoveryO.img");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists("Utilits\\IMGRepack\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString())))
                    Directory.Move("Utilits\\IMGRepack\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()), "Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()));
                else return;
            }
            catch (Exception)
            {
                return;
            }

            Process win = new Process();
            if (comboBox1.SelectedIndex == 0)
            {
                string Patch1 = Directory.GetCurrentDirectory() + "\\Bin\\trace2.bat";
                StreamWriter BatFile1 = new StreamWriter(Patch1, false, Encoding.GetEncoding(866));
                BatFile1.WriteLine("cd /d \"" + Directory.GetCurrentDirectory() + "\\Bin\\\"");
                BatFile1.WriteLine("imgpack.cmd " + "boot");
                BatFile1.Close();
                win.StartInfo.FileName = Patch1;
                win.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                this.Cursor = Cursors.WaitCursor;
                win.Start();
                win.WaitForExit();
                this.Cursor = Cursors.Default;
                File.Delete("Bin\\trace2.bat");
            }
            else
            {
                string Patch1 = Directory.GetCurrentDirectory() + "\\Bin\\trace2.bat";
                StreamWriter BatFile1 = new StreamWriter(Patch1, false, Encoding.GetEncoding(866));
                BatFile1.WriteLine("cd /d \"" + Directory.GetCurrentDirectory() + "\\Bin\\\"");
                BatFile1.WriteLine("imgpack.cmd " + "recovery");
                BatFile1.Close();
                win.StartInfo.FileName = Patch1;
                win.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                this.Cursor = Cursors.WaitCursor;
                win.Start();
                win.WaitForExit();
                this.Cursor = Cursors.Default;
                File.Delete("Bin\\trace2.bat");
            }

            if (File.Exists("Bin\\new_image.img"))
            {
                if (File.Exists("Utilits\\IMGRepack\\" + comboBox1.SelectedItem.ToString()))
                    File.Move("Bin\\new_image.img", "Utilits\\IMGRepack\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()) + DateTime.Now.ToString("_dd.MM.yy_HH-mm-ss") + ".img");
                else
                    File.Move("Bin\\new_image.img", "Utilits\\IMGRepack\\" + comboBox1.SelectedItem.ToString());
            }
            try
            {
                if (Directory.Exists("Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString())))
                    Directory.Delete("Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()),true);
            }
            catch (Exception)
            {
            }

            finally
            {

            }

            Message MS = new Message(null, build, comboBox1.SelectedItem.ToString(), ok, null, null, null, 1, 5);
            MS.SetDesktopLocation(this.Location.X + (this.Width / 2) - (MS.Width / 2), this.Location.Y + (this.Height / 2) - (MS.Height / 2));
            MS.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.Copy(openFileDialog1.FileName, "Bin\\" + comboBox1.SelectedItem,true);
                Process win1 = new Process();
                string Patch1 = Directory.GetCurrentDirectory() + @"\Bin\trace.bat";
                StreamWriter BatFile1 = new StreamWriter(Patch1, false, Encoding.GetEncoding(866));
                BatFile1.WriteLine("cd /d \"" + Directory.GetCurrentDirectory() + "\\Bin\\\"");
                BatFile1.WriteLine("imgunpack.cmd " + comboBox1.SelectedItem);
                BatFile1.Close();
                win1.StartInfo.ErrorDialog = true;
                win1.StartInfo.FileName = Patch1;
                win1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                this.Cursor = Cursors.WaitCursor;
                win1.Start();
                win1.WaitForExit();
                this.Cursor = Cursors.Default;

                File.Delete("Bin\\trace.bat");

                string Patch2 = Directory.GetCurrentDirectory() + @"\Bin\trace2.bat";
                StreamWriter perm = new StreamWriter(Patch2, false, Encoding.GetEncoding(866));
                perm.WriteLine("cmd.exe /c takeown /f \"" + Directory.GetCurrentDirectory() + "\\Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()) + "\"" + "  /r /d y && icacls  \"" + Directory.GetCurrentDirectory() + "\\Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()) + "\"" + " /grant %username%:F /t");
                //perm.WriteLine("cmd.exe /c takeown /f \"" + Directory.GetCurrentDirectory() + "\\Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()) + "\"" + " && icacls /\"" + Directory.GetCurrentDirectory() + "\\Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()) + "\"" + " /grant все:F");
                perm.WriteLine("cmd.exe /c takeown /f \"" + Directory.GetCurrentDirectory() + "\\Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()) + "\"" + "  /r /d y && icacls  \"" + Directory.GetCurrentDirectory() + "\\Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()) + "\"" + " /grant все:F /t");
                //perm.WriteLine("cmd.exe /c takeown /f \"" + Directory.GetCurrentDirectory() + "\\Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()) + "\"" + " && icacls /\"" + Directory.GetCurrentDirectory() + "\\Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()) + "\"" + " /grant all:F");
                perm.WriteLine("cmd.exe /c takeown /f \"" + Directory.GetCurrentDirectory() + "\\Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()) + "\"" + "  /r /d y && icacls  \"" + Directory.GetCurrentDirectory() + "\\Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()) + "\"" + " /grant all:F /t");
                //perm.WriteLine("cmd.exe /c takeown /f \"" + Directory.GetCurrentDirectory() + "\\Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()) + "\"" + " && icacls /\"" + Directory.GetCurrentDirectory() + "\\Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()) + "\"" + " /grant %username%:F");
                perm.Close();
                win1.StartInfo.ErrorDialog = true;
                win1.StartInfo.FileName = Patch2;
                this.Cursor = Cursors.WaitCursor;
                win1.Start();
                win1.WaitForExit();
                this.Cursor = Cursors.Default;

                if (Directory.Exists("Utilits\\IMGRepack\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString())))
                    Directory.Delete("Utilits\\IMGRepack\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()),true);
                Directory.Move("Bin\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()), "Utilits\\IMGRepack\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()));
                if (File.Exists("Bin\\" + comboBox1.SelectedItem))
                    File.Delete("Bin\\" + comboBox1.SelectedItem);

                Message MS = new Message(null, succ, null, ok, null, null, null, 1, 5);
                MS.SetDesktopLocation(this.Location.X + (this.Width / 2) - (MS.Width / 2), this.Location.Y + (this.Height / 2) - (MS.Height / 2));
                MS.ShowDialog();
            }
            else
                return;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                openFileDialog1.Filter = "Firmware Images|*boot*.img";
                openFileDialog1.FileName = "*boot*.img";
            }
            else
            {
                openFileDialog1.Filter = "Firmware Images|*recovery*.img";
                openFileDialog1.FileName = "*recovery*.img";
            }
            LangInit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("Utilits\\IMGRepack\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString())) == true)
                Process.Start("Utilits\\IMGRepack\\" + Path.GetFileNameWithoutExtension(comboBox1.SelectedItem.ToString()));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("Utilits\\IMGRepack") == true)
                Process.Start("Utilits\\IMGRepack");
            else return;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.Top = MousePosition.Y - 280;
            this.Left = MousePosition.X - 250;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
