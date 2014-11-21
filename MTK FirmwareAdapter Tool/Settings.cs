using System;
using System.Windows.Forms;
using System.IO;

namespace MTFAT
{
    public partial class Settings : Form
    {
        string ok = "Сохранить";
        string cancel = "Отмена";
        string lang = "Язык";
        string sound = "Звуковые уведомления";
        string mtime = "Время показа сообщений";

        public Settings()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Russian");

            if (Directory.Exists("Langs"))
            {
                var dir = new System.IO.DirectoryInfo("Langs");
                FileInfo[] files = dir.GetFiles("*.*");

                comboBox1.Items.AddRange(files);
            }

            for (int i = 0; i < (comboBox1.Items.Count); i++)
            {
                if (Convert.ToString(comboBox1.Items[i]).EndsWith(".ini") == true)
                {
                    comboBox1.Items[i] = Convert.ToString(comboBox1.Items[i]).Replace(".ini", "");
                }
            }
            if (File.Exists("Bin/config.ini"))
            {
                IniFile loc = new IniFile(Directory.GetCurrentDirectory() + "/Bin/config.ini");
                if (loc.ReadString("language", "Language") != "") { comboBox1.SelectedItem = loc.ReadString("language", "Language"); }
                try
                {
                    if (loc.ReadString("sound", "Notification") != "") { checkBox1.Checked = Convert.ToBoolean(loc.ReadString("sound", "Notification")); }
                }
                catch (Exception)
                {
                    checkBox1.Checked = false;
                }
                try
                {
                    if (loc.ReadString("message", "Time") != "") { numericUpDown1.Value = Convert.ToInt32(loc.ReadString("message", "Time")); }
                }
                catch (Exception)
                {
                    checkBox1.Checked = false;
                }
            }

            if (File.Exists("Langs\\" + comboBox1.SelectedItem + ".ini"))
            {
                IniFile l = new IniFile(Directory.GetCurrentDirectory() + "/Langs/" + comboBox1.SelectedItem + ".ini");
                if (l.ReadString("settings", "Lang") != "") { lang = label1.Text = l.ReadString("settings", "Lang");}
                if (l.ReadString("settings", "Cancel") != "") { cancel = button1.Text = l.ReadString("settings", "Cancel"); }
                if (l.ReadString("settings", "Ok") != "") {ok = button2.Text = l.ReadString("settings", "Ok"); }
                if (l.ReadString("settings", "Sound") != "") { sound = checkBox1.Text = l.ReadString("settings", "Sound"); }
                if (l.ReadString("settings", "Mes_time") != "") { mtime = label2.Text = l.ReadString("settings", "Mes_time"); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IniFile loc = new IniFile(Directory.GetCurrentDirectory() + "/Bin/config.ini");
            loc.IniWriteValue("language", "Language", Convert.ToString(comboBox1.SelectedItem));
            loc.IniWriteValue("sound", "Notification", Convert.ToString(checkBox1.Checked));
            loc.IniWriteValue("message", "Time", Convert.ToString(numericUpDown1.Value));
            Application.Restart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (File.Exists("Langs\\" + comboBox1.SelectedItem + ".ini"))
            {
                IniFile l = new IniFile(Directory.GetCurrentDirectory() + "/Langs/" + comboBox1.SelectedItem + ".ini");
                if (l.ReadString("settings", "Lang") != "") { label1.Text = l.ReadString("settings", "Lang"); }
                if (l.ReadString("settings", "Cancel") != "") { button1.Text = l.ReadString("settings", "Cancel"); }
                if (l.ReadString("settings", "Ok") != "") { button2.Text = l.ReadString("settings", "Ok"); }
                if (l.ReadString("settings", "Sound") != "") { checkBox1.Text = l.ReadString("settings", "Sound"); }
                if (l.ReadString("settings", "Mes_time") != "") { mtime = label2.Text = l.ReadString("settings", "Mes_time"); }
            }
            else
            {
                if (comboBox1.SelectedItem.ToString() == "Russian")
                {
                    label1.Text = "Язык";
                    button1.Text = "Отмена";
                    button2.Text = "Сохранить";
                    checkBox1.Text = "Звуковые уведомления";
                    label2.Text = "Время показа сообщений";
                }
                else
                {
                    label1.Text = lang;
                    button1.Text = cancel;
                    button2.Text = ok;
                    checkBox1.Text = sound;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.Copy(openFileDialog1.FileName, "Bin\\Notify.wav", true);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            File.Delete("Bin\\Notify.wav");

            if (File.Exists("Bin\\Notify.wav") == false)
                File.WriteAllBytes("Bin\\Notify.wav", MFAT.Properties.Resources.notify_wav);
        }
    }
}
