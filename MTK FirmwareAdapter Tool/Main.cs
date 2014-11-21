using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Ionic.Zip;

namespace MTFAT
{

    public partial class Form1 : Form
    {
           
    #region Глобальные переменные (Global)

        Point last;
        Boolean snd = false;
        string nw = "Новый проект";
        string S = null;
        int s = 0;
        int time = 5;

        string err = "Ошибка";
        string succ = "Файлы получены успешно";
        string err1 = "boot.img портируемой";
        string err2 = "прошивки не найден";
        string err3 = "boot.img вашей";
        string un_succ = "Распаковка успешна";
        string re_succ = "Перепаковка успешна";
        string repeat = "Повторите перепаковку снова";
        string sign_succ = "Zip подписан успешно";
        string build_succ = "Сборка успешна";
        string err4 = "Портируемая прошивка";
        string err5 = "не найдена";
        string err6 = "Файлы из вашей";
        string err7 = "прошивки не найдены";
        string del_succ = "Удалено успешно";
        string del_err = "Ошибка удаления";
        string temp_succ = "Временные файлы";
        string temp_succ1 = "Файлы удалены успешно";
        string ok = "Ок";
        string meta = "META-INF не найден!";
        string choose = "Указать";
        string exit = "Выход";
        string chooses = "Укажите на распакованную папку System";
        string choosem = "Укажите на распакованную папку META-INF";
        string get = "Получение списка фалов";
        string next = "Далее";
        string sa = "Выделить всё";
        string us = "Снять выделение";
        string des = "Укажите папку с вашим набором файлов для портирования\nОбязательно должна содержать в себе system!";
        string yf = "Из папки YourFiles";
        string sm = "Из другой папки";
        string mf = "Указать папку META-INF";
        string mz = "Получить META-INF из ZIP";
        string text1 = "Введите название папки или файла с расширением";
        string text2 = "Введите путь включая нужный файл или папку";

    #endregion

        public Form1()
        {
            BinInit();
            InitializeComponent();
            LangInit();
            ProjectInit();
            SoundInit();
            checkBox6.Checked = true;
            checkBox7.Checked = true;
        }

    #region Дополнительные (Additional)

        public void BinInit()
        {
            //Проекты
            if (Directory.Exists("Projects") == false)
                Directory.CreateDirectory("Projects");
            if (File.Exists("Projects\\MT6589.fat") == false)
                File.WriteAllBytes("Projects\\MT6589.fat", MFAT.Properties.Resources.MT6589);
            if (File.Exists("Projects\\MT6577.fat") == false)
                File.WriteAllBytes("Projects\\MT6577.fat", MFAT.Properties.Resources.MT6577);
            if (File.Exists("Projects\\MT6575.fat") == false)
                File.WriteAllBytes("Projects\\MT6575.fat", MFAT.Properties.Resources.MT6575);
            if (File.Exists("Projects\\IQ446_4.1.2.fat") == false)
                File.WriteAllBytes("Projects\\IQ446_4.1.2.fat", MFAT.Properties.Resources.IQ446_4_1_2);
            if (File.Exists("Projects\\IQ446_4.1.2_MIUI from_A820.fat") == false)
                File.WriteAllBytes("Projects\\IQ446_4.1.2_MIUI from_A820.fat", MFAT.Properties.Resources.IQ446_4_1_2_MIUI_from_A820);
            if (File.Exists("Projects\\IQ446_4.2.1.fat") == false)
                File.WriteAllBytes("Projects\\IQ446_4.2.1.fat", MFAT.Properties.Resources.IQ446_4_2_1);
            if (File.Exists("Projects\\IQ446_4.2.1_BaiduYIOS_from_N828.fat") == false)
                File.WriteAllBytes("Projects\\IQ446_4.2.1_BaiduYIOS_from_N828.fat", MFAT.Properties.Resources.IQ446_4_2_1_BaiduYIOS_from_N828);
            if (File.Exists("Projects\\IQ446_4.2.1_StockROM_from_Acer_E2.fat") == false)
                File.WriteAllBytes("Projects\\IQ446_4.2.1_StockROM_from_Acer_E2.fat", MFAT.Properties.Resources.IQ446_4_2_1_StockROM_from_Acer_E2);

            //Projects by Users
            if (File.Exists("Projects\\LewaOS_5.1_no crash browsers.IQ446_4.2.1_by_Galaxy_Ace_ICS.fat") == false)
                File.WriteAllBytes("Projects\\LewaOS_5.1_no crash browsers.IQ446_4.2.1_by_Galaxy_Ace_ICS.fat", MFAT.Properties.Resources.LewaOS_5_1_no_crash_browsers_IQ446_4_2_1_by_Galaxy_Ace_ICS);

            //Языки
            if (Directory.Exists("Langs") == false)
                Directory.CreateDirectory("Langs");
            if (File.Exists("Langs\\English.ini") == false)
                File.WriteAllBytes("Langs\\English.ini", MFAT.Properties.Resources.English_ini);
            if (File.Exists("Langs\\Czech.ini") == false)
                File.WriteAllBytes("Langs\\Czech.ini", MFAT.Properties.Resources.Czech_ini);
            //Библиотеки
            if (Directory.Exists("Bin") == false)
                Directory.CreateDirectory("Bin");
            if (File.Exists("Bin\\7z.dll") == false)
                File.WriteAllBytes("Bin\\7z.dll", MFAT.Properties.Resources._7z);
            if (File.Exists("Bin\\7z.exe") == false)
                File.WriteAllBytes("Bin\\7z.exe", MFAT.Properties.Resources._7z1);
            if (File.Exists("Bin\\adb.exe") == false)
                File.WriteAllBytes("Bin\\adb.exe", MFAT.Properties.Resources.adb);
            if (File.Exists("Bin\\AdbWinApi.dll") == false)
                File.WriteAllBytes("Bin\\AdbWinApi.dll", MFAT.Properties.Resources.AdbWinApi);
            if (File.Exists("Bin\\AdbWinUsbApi.dll") == false)
                File.WriteAllBytes("Bin\\AdbWinUsbApi.dll", MFAT.Properties.Resources.AdbWinUsbApi);
            if (File.Exists("Bin\\chmod.exe") == false)
                File.WriteAllBytes("Bin\\chmod.exe", MFAT.Properties.Resources.chmod);
            if (File.Exists("Bin\\config.ini") == false)
                File.WriteAllBytes("Bin\\config.ini", MFAT.Properties.Resources.config_ini);
            if (File.Exists("Bin\\cpio.dll") == false)
                File.WriteAllBytes("Bin\\cpio.dll", MFAT.Properties.Resources.cpio);
            if (File.Exists("Bin\\cpio.exe") == false)
                File.WriteAllBytes("Bin\\cpio.exe", MFAT.Properties.Resources.cpio1);
            if (File.Exists("Bin\\cpio.txt") == false)
                File.WriteAllBytes("Bin\\cpio.txt", MFAT.Properties.Resources.cpio_txt);
            if (File.Exists("Bin\\cpio_set0") == false)
                File.WriteAllBytes("Bin\\cpio_set0", MFAT.Properties.Resources.cpio_set0);
            if (File.Exists("Bin\\cyggcc_s-1.dll") == false)
                File.WriteAllBytes("Bin\\cyggcc_s-1.dll", MFAT.Properties.Resources.cyggcc_s_1);
            if (File.Exists("Bin\\cygiconv-2.dll") == false)
                File.WriteAllBytes("Bin\\cygiconv-2.dll", MFAT.Properties.Resources.cygiconv_2);
            if (File.Exists("Bin\\cygintl-8.dll") == false)
                File.WriteAllBytes("Bin\\cygintl-8.dll", MFAT.Properties.Resources.cygintl_8);
            if (File.Exists("Bin\\cygwin1.dll") == false)
                File.WriteAllBytes("Bin\\cygwin1.dll", MFAT.Properties.Resources.cygwin1);
            if (File.Exists("Bin\\dd.exe") == false)
                File.WriteAllBytes("Bin\\dd.exe", MFAT.Properties.Resources.dd);
            if (File.Exists("Bin\\Ext4Extractor.exe") == false)
                File.WriteAllBytes("Bin\\Ext4Extractor.exe", MFAT.Properties.Resources.Ext4Extractor);
            if (File.Exists("Bin\\find.dll") == false)
                File.WriteAllBytes("Bin\\find.dll", MFAT.Properties.Resources.find);
            if (File.Exists("Bin\\find.exe") == false)
                File.WriteAllBytes("Bin\\find.exe", MFAT.Properties.Resources.find1);
            if (File.Exists("Bin\\find.txt") == false)
                File.WriteAllBytes("Bin\\find.txt", MFAT.Properties.Resources.find_txt);
            if (File.Exists("Bin\\gzip.exe") == false)
                File.WriteAllBytes("Bin\\gzip.exe", MFAT.Properties.Resources.gzip);
            if (File.Exists("Bin\\imgpack.cmd") == false)
                File.WriteAllBytes("Bin\\imgpack.cmd", MFAT.Properties.Resources.imgpack_cmd);
            if (File.Exists("Bin\\imgunpack.cmd") == false)
                File.WriteAllBytes("Bin\\imgunpack.cmd", MFAT.Properties.Resources.imgunpack_cmd);
            if (File.Exists("Bin\\Ionic.Zip.dll") == false)
                File.WriteAllBytes("Bin\\Ionic.Zip.dll", MFAT.Properties.Resources.Ionic_Zip);
            if (File.Exists("Bin\\mkbootimg.exe") == false)
                File.WriteAllBytes("Bin\\mkbootimg.exe", MFAT.Properties.Resources.mkbootimg);
            if (File.Exists("Bin\\sfk166.exe") == false)
                File.WriteAllBytes("Bin\\sfk166.exe", MFAT.Properties.Resources.sfk166);
            if (File.Exists("Bin\\signapk.cmd") == false)
                File.WriteAllBytes("Bin\\signapk.cmd", MFAT.Properties.Resources.signapk_cmd);
            if (File.Exists("Bin\\signapk.jar") == false)
                File.WriteAllBytes("Bin\\signapk.jar", MFAT.Properties.Resources.signapk);
            if (File.Exists("Bin\\testkey.pk8") == false)
                File.WriteAllBytes("Bin\\testkey.pk8", MFAT.Properties.Resources.testkey);
            if (File.Exists("Bin\\testkey.x509.pem") == false)
                File.WriteAllBytes("Bin\\testkey.x509.pem", MFAT.Properties.Resources.testkey_x509);
            //Рабочая директория
            if (Directory.Exists("WorkDIR") == false)
                Directory.CreateDirectory("WorkDIR");
        }

        public void ProjectInit()
        {
            var dir = new System.IO.DirectoryInfo("Projects");
            FileInfo[] files = dir.GetFiles("*.*");
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(files);
            comboBox1.Items.Add(nw);

            for (int i = 0; i < (comboBox1.Items.Count - 1); i++)
            {
                if (Convert.ToString(comboBox1.Items[i]).EndsWith(".fat") == true)
                {
                    comboBox1.Items[i] = Convert.ToString(comboBox1.Items[i]).Replace(".fat", "");
                }
            }
            if (File.Exists("Bin/config.ini"))
            {
                IniFile loc = new IniFile(Directory.GetCurrentDirectory() + "/Bin/config.ini");
                if (loc.ReadString("Others", "last") != "") 
                {
                    if (loc.ReadString("Others", "last") != "") { comboBox1.SelectedItem = loc.ReadString("Others", "last"); }
                }

                try
                {
                    if (loc.ReadString("message", "Time") != "") { time = Convert.ToInt32(loc.ReadString("message", "Time")); }
                }
                catch (Exception)
                {
                    checkBox1.Checked = false;
                }
            }
        }

        public void SoundInit()
        {
            if (File.Exists("Bin/config.ini"))
            {
                IniFile loc = new IniFile(Directory.GetCurrentDirectory() + "/Bin/config.ini");
                try
                {
                    if (loc.ReadString("sound", "Notification") != "") { snd = Convert.ToBoolean(loc.ReadString("sound", "Notification")); }
                }
                catch (Exception)
                {
                    snd = false;
                }
            }
        }

        public void SoundPlay()
        {
            if (snd == true)
            {
                if (File.Exists("Bin\\Notify.wav") == false)
                    File.WriteAllBytes("Bin\\Notify.wav", MFAT.Properties.Resources.notify_wav);
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = Directory.GetCurrentDirectory() + "\\bin\\Notify.wav";
                player.Load();
                player.Play();
            }
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
                //Сообщения
                if (l.ReadString("main", "err") != "") { err = l.ReadString("main", "err"); }
                if (l.ReadString("main", "succ") != "") { succ = l.ReadString("main", "succ"); }
                if (l.ReadString("main", "err1") != "") { err1 = l.ReadString("main", "err1"); }
                if (l.ReadString("main", "err2") != "") { err2 = l.ReadString("main", "err2"); }
                if (l.ReadString("main", "err3") != "") { err3 = l.ReadString("main", "err3"); }
                if (l.ReadString("main", "un_succ") != "") { un_succ = l.ReadString("main", "un_succ"); }
                if (l.ReadString("main", "re_succ") != "") { re_succ = l.ReadString("main", "re_succ"); }
                if (l.ReadString("main", "build_succ") != "") { build_succ = l.ReadString("main", "build_succ"); }
                if (l.ReadString("main", "repeat") != "") { repeat = l.ReadString("main", "repeat"); }
                if (l.ReadString("main", "sign_succ") != "") { sign_succ = l.ReadString("main", "sign_succ"); }
                if (l.ReadString("main", "err4") != "") { err4 = l.ReadString("main", "err4"); }
                if (l.ReadString("main", "err5") != "") { err5 = l.ReadString("main", "err5"); }
                if (l.ReadString("main", "err6") != "") { err6 = l.ReadString("main", "err6"); }
                if (l.ReadString("main", "err7") != "") { err7 = l.ReadString("main", "err7"); }
                if (l.ReadString("main", "del_succ") != "") { del_succ = l.ReadString("main", "del_succ"); }
                if (l.ReadString("main", "del_err") != "") { del_err = l.ReadString("main", "del_err"); }
                if (l.ReadString("main", "temp_succ") != "") { temp_succ = l.ReadString("main", "temp_succ"); }
                if (l.ReadString("main", "temp_succ1") != "") { temp_succ1 = l.ReadString("main", "temp_succ1"); }
                if (l.ReadString("main", "ok") != "") { ok = l.ReadString("main", "ok"); }
                if (l.ReadString("main", "nw") != "") { nw = l.ReadString("main", "nw"); }
                if (l.ReadString("main", "choose") != "") { choose = l.ReadString("main", "choose"); }
                if (l.ReadString("main", "exit") != "") { exit = l.ReadString("main", "exit"); }
                if (l.ReadString("main", "meta") != "") { meta = l.ReadString("main", "meta"); }
                if (l.ReadString("main", "choosem") != "") { choosem = l.ReadString("main", "choosem"); }
                if (l.ReadString("main", "chooses") != "") { chooses = l.ReadString("main", "chooses"); }
                if (l.ReadString("main", "get") != "") { get = l.ReadString("main", "get"); }
                if (l.ReadString("main", "next") != "") { next = l.ReadString("main", "next"); }
                if (l.ReadString("main", "sa") != "") { sa = l.ReadString("main", "sa"); }
                if (l.ReadString("main", "us") != "") { us = l.ReadString("main", "us"); }
                if (l.ReadString("main", "des") != "") { des = l.ReadString("main", "des"); }
                if (l.ReadString("main", "yf") != "") { yf = l.ReadString("main", "yf"); }
                if (l.ReadString("main", "sm") != "") { sm = l.ReadString("main", "sm"); }
                if (l.ReadString("main", "mf") != "") { mf = l.ReadString("main", "mf"); }
                if (l.ReadString("main", "mz") != "") { mz = l.ReadString("main", "mz"); }
                //Группы
                if (l.ReadString("main", "group1") != "") { groupBox7.Text = l.ReadString("main", "group1"); }
                if (l.ReadString("main", "group2") != "") { groupBox8.Text = l.ReadString("main", "group2"); }
                if (l.ReadString("main", "group3") != "") { groupBox6.Text = l.ReadString("main", "group3"); }
                if (l.ReadString("main", "group4") != "") { groupBox1.Text = l.ReadString("main", "group4"); }
                if (l.ReadString("main", "group5") != "") { groupBox2.Text = l.ReadString("main", "group5"); }
                if (l.ReadString("main", "group6") != "") { groupBox4.Text = l.ReadString("main", "group6"); }
                if (l.ReadString("main", "group7") != "") { groupBox5.Text = l.ReadString("main", "group7"); }
                //Чекки
                if (l.ReadString("main", "check1") != "") { checkBox1.Text = l.ReadString("main", "check1"); }
                if (l.ReadString("main", "check2") != "") { checkBox2.Text = l.ReadString("main", "check2"); }
                if (l.ReadString("main", "check3") != "") { checkBox5.Text = l.ReadString("main", "check3"); }
                if (l.ReadString("main", "check4") != "") { checkBox6.Text = l.ReadString("main", "check4"); }
                if (l.ReadString("main", "check5") != "") { checkBox7.Text = l.ReadString("main", "check5"); }
                if (l.ReadString("main", "check6") != "") { checkBox8.Text = l.ReadString("main", "check6"); }
                //Текстовые поля
                if (l.ReadString("main", "text1") != "") { textBox1.Text = text1 = l.ReadString("main", "text1"); }
                if (l.ReadString("main", "text2") != "") { textBox2.Text = text2 = l.ReadString("main", "text2"); }
                //Список
                if (l.ReadString("main", "box1") != "") { comboBox4.Items[0] = comboBox5.Items[0] = Convert.ToString(l.ReadString("main", "box1")); }
                if (l.ReadString("main", "box2") != "") { comboBox4.Items[1] = comboBox5.Items[1] = Convert.ToString(l.ReadString("main", "box2")); }
                if (l.ReadString("main", "box3") != "") { comboBox4.Items[2] = comboBox5.Items[2] = Convert.ToString(l.ReadString("main", "box3")); }
                if (l.ReadString("main", "box4") != "") { comboBox4.Items[3] = comboBox5.Items[3] = Convert.ToString(l.ReadString("main", "box4")); }
                //Заголовки
                if (l.ReadString("main", "tab1") != "") { tabPage1.Text = l.ReadString("main", "tab1"); }
                if (l.ReadString("main", "tab2") != "") { tabPage2.Text = l.ReadString("main", "tab2"); }
                if (l.ReadString("main", "tab3") != "") { tabPage3.Text = l.ReadString("main", "tab3"); }
                if (l.ReadString("main", "tab4") != "") { tabPage4.Text = l.ReadString("main", "tab4"); }
                //Кнопки
                if (l.ReadString("main", "button1") != "") { button21.Text = l.ReadString("main", "button1"); }
                if (l.ReadString("main", "button2") != "") { button24.Text = l.ReadString("main", "button2"); }
                if (l.ReadString("main", "button3") != "") { button26.Text = l.ReadString("main", "button3"); }
                if (l.ReadString("main", "button4") != "") { button27.Text = button19.Text = l.ReadString("main", "button4"); }
                if (l.ReadString("main", "button5") != "") { button5.Text = l.ReadString("main", "button5"); }
                if (l.ReadString("main", "button6") != "") { button6.Text = l.ReadString("main", "button6"); }
                if (l.ReadString("main", "button7") != "") { button11.Text = l.ReadString("main", "button7"); }
                if (l.ReadString("main", "button8") != "") { button4.Text = l.ReadString("main", "button8"); }
                if (l.ReadString("main", "button9") != "") { button29.Text = button30.Text = l.ReadString("main", "button9"); }
                if (l.ReadString("main", "button10") != "") { button7.Text = button13.Text = l.ReadString("main", "button10"); }
                if (l.ReadString("main", "button11") != "") { button8.Text = button12.Text = l.ReadString("main", "button11"); }
                if (l.ReadString("main", "button12") != "") { button9.Text = button10.Text = l.ReadString("main", "button12"); }
                if (l.ReadString("main", "button13") != "") { button14.Text = l.ReadString("main", "button13"); }
                if (l.ReadString("main", "button14") != "") { button15.Text = l.ReadString("main", "button14"); }
                if (l.ReadString("main", "button15") != "") { button16.Text = l.ReadString("main", "button15"); }
                if (l.ReadString("main", "button16") != "") { button17.Text = l.ReadString("main", "button16"); }
                if (l.ReadString("main", "button17") != "") { button18.Text = l.ReadString("main", "button17"); }
                if (l.ReadString("main", "button18") != "") { button20.Text = l.ReadString("main", "button18"); }
                if (l.ReadString("main", "button22") != "") { button22.Text = l.ReadString("main", "button22"); }
                if (l.ReadString("main", "button33") != "") { button33.Text = l.ReadString("main", "button33"); }
                //Контекст
                if (l.ReadString("main", "dc") != "") { toolStripMenuItem1.Text = l.ReadString("main", "dc"); }
                if (l.ReadString("main", "da") != "") { toolStripMenuItem2.Text = l.ReadString("main", "da"); }
            }
        }

        public void ProjectEditRM()
        {
            int lastIndex = checkedListBox1.Items.Count - 1;
            for (int i = lastIndex; i >= 0; i--)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                {
                    string D = null;
                    D = Convert.ToString(checkedListBox1.Items[i]);
                    if (D.EndsWith("/") == true)
                    {
                        D = D.Remove(D.Length - 1);
                        D = D.Replace("/", "\\");
                        try
                        {
                            if (Directory.Exists("Projects\\" + comboBox1.SelectedItem + "\\" + "YourFiles\\" + D) == true)
                            {
                                Directory.Delete("Projects\\" + comboBox1.SelectedItem + "\\" + "YourFiles\\" + D, true);
                            }
                        }
                        catch (Exception)
                        {
                            
                        }
                    }
                    else
                    {
                        D = D.Replace("/", "\\");
                        if (File.Exists("Projects\\" + comboBox1.SelectedItem + "\\" + "Temp\\" + D) == true)
                        {
                            File.Delete("Projects\\" + comboBox1.SelectedItem + "\\" + "YourFiles\\" + D);
                        }

                    }
                    checkedListBox1.Items.RemoveAt(i);
                }
            }
            if (checkedListBox1.Items.Count == -1)
            {
                if (checkBox1.Checked == true)
                {
                    checkBox1.Checked = false;
                    checkBox1.Text = sa;
                }
            }
        }

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

    #endregion

    #region Работа с файлами (Files)

        public void CopyDirectory(string strSource, string strDestination)
        {
            if (!Directory.Exists(strDestination))
            {
                Directory.CreateDirectory(strDestination);
            }
            DirectoryInfo dirInfo = new DirectoryInfo(strSource);
            FileInfo[] files = dirInfo.GetFiles();
            foreach (FileInfo tempfile in files)
            {
                if (File.Exists(strDestination + "\\" + tempfile.Name) == false)
                {
                    tempfile.CopyTo(Path.Combine(strDestination, tempfile.Name));
                }
                else
                {
                    File.Delete(strDestination + "\\" + tempfile.Name);
                    tempfile.CopyTo(Path.Combine(strDestination, tempfile.Name));
                }
            }
            DirectoryInfo[] dirctororys = dirInfo.GetDirectories();
            foreach (DirectoryInfo tempdir in dirctororys)
            {
                CopyDirectory(Path.Combine(strSource, tempdir.Name), Path.Combine(strDestination, tempdir.Name));
            }

        }

        public void ZIPunpack(String L, bool C)
        {
            try
            {
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {

                    if (Directory.Exists("WorkDIR\\" + comboBox1.SelectedItem + "\\Temp"))
                        Directory.Delete("WorkDIR\\" + comboBox1.SelectedItem + "\\Temp", true);

                    this.Cursor = Cursors.WaitCursor;
                    if (Directory.Exists("WorkDIR/" + comboBox1.SelectedItem + "/" + L) == true)
                    {
                        Directory.Delete("WorkDIR/" + comboBox1.SelectedItem + "/" + L, true);
                    }
                    try
                    {
                        using (ZipFile zip = ZipFile.Read(openFileDialog2.FileName))
                        {
                            zip.ExtractAll("WorkDIR\\" + comboBox1.SelectedItem + "\\" + "Temp", ExtractExistingFileAction.OverwriteSilently);
                        }
                    }
                    catch (Exception)
                    {
                        if (Directory.Exists("WorkDIR\\" + comboBox1.SelectedItem + "\\Temp"))
                            Directory.Delete("WorkDIR\\" + comboBox1.SelectedItem + "\\Temp", true);

                        string Patch0 = Directory.GetCurrentDirectory() + @"\Bin\trace.bat";
                        StreamWriter BatFile0 = new StreamWriter(Patch0, false, Encoding.GetEncoding(866));
                        BatFile0.WriteLine("@echo off");
                        BatFile0.WriteLine("cd /d " + Directory.GetCurrentDirectory() + @"\Bin");
                        BatFile0.WriteLine("7z.exe x " + "\"" + openFileDialog2.FileName.ToString() + "\" -o\"" + Directory.GetCurrentDirectory() + "\\WorkDIR\\" + comboBox1.SelectedItem + "\\Temp\" -y");
                        BatFile0.Close();

                        Process wing = new Process();
                        wing.StartInfo.CreateNoWindow = true;
                        wing.StartInfo.ErrorDialog = false;
                        wing.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        wing.StartInfo.FileName = @"Bin\trace.bat";
                        this.Cursor = Cursors.WaitCursor;
                        wing.Start();
                        wing.WaitForExit();
                        this.Cursor = Cursors.Default;
                        if (File.Exists(@"Bin\trace.bat"))
                            File.Delete(@"Bin\trace.bat");
                    }

                    if (Directory.Exists("WorkDIR\\" + comboBox1.SelectedItem + "\\Temp"))
                    {
                        string Patch = Directory.GetCurrentDirectory() + "\\WorkDIR\\" + comboBox1.SelectedItem + "\\Temp\\atrs.bat";
                        StreamWriter BatFile = new StreamWriter(Patch, false, Encoding.GetEncoding(866));
                        BatFile.WriteLine("@echo off");
                        BatFile.WriteLine("attrib -s -h -r -a /s /d");
                        BatFile.WriteLine("DEL /Q atrs.bat");
                        BatFile.Close();

                        if (File.Exists(Directory.GetCurrentDirectory() + "\\WorkDIR\\" + comboBox1.SelectedItem + "\\Temp\\atrs.bat"))
                        {
                            Process winh = new Process();
                            winh.StartInfo.CreateNoWindow = true;
                            winh.StartInfo.ErrorDialog = false;
                            winh.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            winh.StartInfo.FileName = Patch;
                            this.Cursor = Cursors.WaitCursor;
                            winh.Start();
                            winh.WaitForExit();
                            this.Cursor = Cursors.Default;
                        }

                        if (File.Exists(Directory.GetCurrentDirectory() + "\\WorkDIR\\" + comboBox1.SelectedItem + "\\Temp\\atrs.bat"))
                            File.Delete(Directory.GetCurrentDirectory() + "\\WorkDIR\\" + comboBox1.SelectedItem + "\\Temp\\atrs.bat");


                        if (L == "YourFiles")
                        {
                            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                            {

                                {
                                    string D2 = null;
                                    string D = null;
                                    D = Convert.ToString(checkedListBox1.Items[i]);
                                    D = D.Replace("/", "\\");
                                    try
                                    {
                                        if (Directory.Exists("WorkDIR\\" + comboBox1.SelectedItem + "\\" + "Temp\\" + D) == true)
                                        {
                                            CopyDirectory("WorkDIR\\" + comboBox1.SelectedItem + "\\" + "Temp\\" + D, "WorkDIR\\" + comboBox1.SelectedItem + "\\" + L + "\\" + D);
                                        }
                                        else
                                            if (File.Exists("WorkDIR\\" + comboBox1.SelectedItem + "\\" + "Temp\\" + D) == true)
                                            {
                                                if (D.LastIndexOf("\\") >= 0)
                                                {
                                                    D2 = D.Remove(D.LastIndexOf("\\"));
                                                }
                                                Directory.CreateDirectory("WorkDIR\\" + comboBox1.SelectedItem + "\\" + L + "\\" + D2);
                                                File.Copy("WorkDIR\\" + comboBox1.SelectedItem + "\\" + "Temp\\" + D, "WorkDIR\\" + comboBox1.SelectedItem + "\\" + L + "\\" + D, true);
                                            }
                                        if (C == true)
                                        {
                                            if (Directory.Exists("WorkDIR\\" + comboBox1.SelectedItem + "\\" + "Temp\\META-INF") == true)
                                            {
                                                CopyDirectory("WorkDIR\\" + comboBox1.SelectedItem + "\\" + "Temp\\META-INF", "WorkDIR\\" + comboBox1.SelectedItem + "\\" + L + "\\META-INF");
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Message M = new Message(err, ex.Message, null, ok, null, null, null, 1, time);
                                        M.SetDesktopLocation(this.Location.X + (this.Width / 2) - (M.Width / 2), this.Location.Y + (this.Height / 2) - (M.Height / 2));
                                        M.ShowDialog();
                                    }
                                }
                            }
                        }
                        else
                        {
                            Directory.Move("WorkDIR\\" + comboBox1.SelectedItem + "\\" + "Temp", "WorkDIR/" + comboBox1.SelectedItem + "/" + L);
                            if (C == false)
                            {
                                if (Directory.Exists("WorkDIR\\" + comboBox1.SelectedItem + "\\" + L + "\\META-INF") == true)
                                {
                                    Directory.Delete("WorkDIR\\" + comboBox1.SelectedItem + "\\" + L + "\\META-INF", true);
                                }
                            }
                        }
                        SoundPlay();
                        Message MS = new Message(null, succ, null, ok, null, null, null, 1, time);
                        MS.SetDesktopLocation(this.Location.X + (this.Width / 2) - (MS.Width / 2), this.Location.Y + (this.Height / 2) - (MS.Height / 2));
                        MS.ShowDialog();
                        try
                        {
                            if (Directory.Exists("WorkDIR\\" + comboBox1.SelectedItem + "\\" + "Temp") == true)
                                Directory.Delete("WorkDIR\\" + comboBox1.SelectedItem + "\\" + "Temp", true);
                        }
                        catch (Exception)
                        {

                        }
                    }
                    else
                    {
                        Message M = new Message(err, null, null, ok, null, null, null, 1, time);
                        M.SetDesktopLocation(this.Location.X + (this.Width / 2) - (M.Width / 2), this.Location.Y + (this.Height / 2) - (M.Height / 2));
                        M.ShowDialog();
                    }
                }
                else
                    return;
            }
            finally
            {

            }
        }

        public void FTUnpack(string L)
        {
            openFileDialog1.Filter = "System Image File |*system*.img";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Process win = new Process();
                    win.StartInfo.FileName = Directory.GetCurrentDirectory() + "//Bin//Ext4Extractor.exe";

                    if (Directory.Exists("WorkDIR/" + comboBox1.SelectedItem + "/" + L) == true)
                    {
                        Directory.Delete("WorkDIR/" + comboBox1.SelectedItem + "/" + L, true);
                    }
                    if (Directory.Exists("WorkDIR/" + comboBox1.SelectedItem + "/Temp"))
                        Directory.Delete("WorkDIR/" + comboBox1.SelectedItem + "/Temp", true);

                    Directory.CreateDirectory("WorkDIR/" + comboBox1.SelectedItem + "/Temp");

                    win.StartInfo.Arguments = "\"" + openFileDialog1.FileName + "\"" + " \"WorkDIR\\" + comboBox1.SelectedItem + "\\Temp\\system\"";
                    win.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    win.StartInfo.ErrorDialog = false;
                    this.Cursor = Cursors.WaitCursor;
                    win.Start();
                    win.WaitForExit();
                    this.Cursor = Cursors.Default;

                }
                finally
                {

                    if (L == "YourFiles")
                    {
                        for (int i = 0; i < checkedListBox1.Items.Count; i++)
                        {

                            {
                                string D2 = null;
                                string D = null;
                                D = Convert.ToString(checkedListBox1.Items[i]);
                                D = D.Replace("/", "\\");
                                try
                                {
                                    if (Directory.Exists("WorkDIR\\" + comboBox1.SelectedItem + "\\" + "Temp\\" + D) == true)
                                    {
                                        CopyDirectory("WorkDIR\\" + comboBox1.SelectedItem + "\\" + "Temp\\" + D, "WorkDIR\\" + comboBox1.SelectedItem + "\\" + L + "\\" + D);
                                    }
                                    else
                                        if (File.Exists("WorkDIR\\" + comboBox1.SelectedItem + "\\" + "Temp\\" + D) == true)
                                        {
                                            if (D.LastIndexOf("\\") >= 0)
                                            {
                                                D2 = D.Remove(D.LastIndexOf("\\"));
                                            }
                                            Directory.CreateDirectory("WorkDIR\\" + comboBox1.SelectedItem + "\\" + L + "\\" + D2);
                                            File.Copy("WorkDIR\\" + comboBox1.SelectedItem + "\\" + "Temp\\" + D, "WorkDIR\\" + comboBox1.SelectedItem + "\\" + L + "\\" + D, true);
                                        }
                                }
                                catch (Exception ex)
                                {
                                    Message M = new Message(err, ex.Message, null, ok, null, null, null, 1, time);
                                    M.SetDesktopLocation(this.Location.X + (this.Width / 2) - (M.Width / 2), this.Location.Y + (this.Height / 2) - (M.Height / 2));
                                    M.ShowDialog();
                                }
                            }
                        }
                    }
                    else
                    {
                        Directory.Move("WorkDIR\\" + comboBox1.SelectedItem + "\\" + "Temp", "WorkDIR/" + comboBox1.SelectedItem + "/" + L);
                    }


                    openFileDialog1.Filter = "Boot Image File |*boot*.img";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        if (Directory.Exists("WorkDIR/" + comboBox1.SelectedItem + "/" + L) == false)
                            Directory.CreateDirectory("WorkDIR/" + comboBox1.SelectedItem + "/" + L);
                        File.Copy(openFileDialog1.FileName, "WorkDIR/" + comboBox1.SelectedItem + "/" + L + "/boot.img", true);
                    }

                    if (Directory.Exists(@"WorkDIR\" + comboBox1.SelectedItem + @"\YourFiles\system") == true)
                    {
                        SoundPlay();
                        Message MS = new Message(null, succ, null, ok, null, null, null, 1, time);
                        MS.SetDesktopLocation(this.Location.X + (this.Width / 2) - (MS.Width / 2), this.Location.Y + (this.Height / 2) - (MS.Height / 2));
                        MS.ShowDialog();
                    }
                }

                try
                {
                    if (Directory.Exists("WorkDIR\\" + comboBox1.SelectedItem + "\\" + "Temp") == true)
                        Directory.Delete("WorkDIR\\" + comboBox1.SelectedItem + "\\" + "Temp", true);
                }
                catch (Exception)
                {
                    
                }
            }
            else return;
        }

        public void Unpacked(string L, bool C)
        {
            folderBrowserDialog1.Description = chooses;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists("WorkDIR/" + comboBox1.SelectedItem + "/" + L + "/system") == true)
                    Directory.Delete("WorkDIR/" + comboBox1.SelectedItem + "/" + L + "/system", true);

                if (Directory.Exists("WorkDIR/" + comboBox1.SelectedItem + "/Temp"))
                    Directory.Delete("WorkDIR/" + comboBox1.SelectedItem + "/Temp", true);

                CopyDirectory(folderBrowserDialog1.SelectedPath, "WorkDIR/" + comboBox1.SelectedItem + "/Temp/system");
            }
            else
                return;

            if (L == "YourFiles")
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {

                    {
                        string D2 = null;
                        string D = null;
                        D = Convert.ToString(checkedListBox1.Items[i]);
                        D = D.Replace("/", "\\");
                        try
                        {
                            if (Directory.Exists("WorkDIR\\" + comboBox1.SelectedItem + "\\" + "Temp\\" + D) == true)
                            {
                                CopyDirectory("WorkDIR\\" + comboBox1.SelectedItem + "\\" + "Temp\\" + D, "WorkDIR\\" + comboBox1.SelectedItem + "\\" + L + "\\" + D);
                            }
                            else
                                if (File.Exists("WorkDIR\\" + comboBox1.SelectedItem + "\\" + "Temp\\" + D) == true)
                                {
                                    if (D.LastIndexOf("\\") >= 0)
                                    {
                                        D2 = D.Remove(D.LastIndexOf("\\"));
                                    }
                                    Directory.CreateDirectory("WorkDIR\\" + comboBox1.SelectedItem + "\\" + L + "\\" + D2);
                                    File.Copy("WorkDIR\\" + comboBox1.SelectedItem + "\\" + "Temp\\" + D, "WorkDIR\\" + comboBox1.SelectedItem + "\\" + L + "\\" + D, true);
                                }

                            if (Directory.Exists("WorkDIR/" + comboBox1.SelectedItem + "/Temp"))
                                Directory.Delete("WorkDIR/" + comboBox1.SelectedItem + "/Temp", true);
                        }
                        catch (Exception ex)
                        {
                            Message M = new Message(err, ex.Message, null, ok, null, null, null, 1, time);
                            M.SetDesktopLocation(this.Location.X + (this.Width / 2) - (M.Width / 2), this.Location.Y + (this.Height / 2) - (M.Height / 2));
                            M.ShowDialog();
                        }
                    }
                }
            }
            else
            {
                Directory.Move("WorkDIR\\" + comboBox1.SelectedItem + "\\" + "Temp", "WorkDIR/" + comboBox1.SelectedItem + "/" + L);
            }

            openFileDialog1.Filter = "Boot Image File |*boot*.img";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists("WorkDIR/" + comboBox1.SelectedItem + "/" + L) == false)
                    Directory.CreateDirectory("WorkDIR/" + comboBox1.SelectedItem + "/" + L);
                File.Copy(openFileDialog1.FileName, "WorkDIR/" + comboBox1.SelectedItem + "/" + L + "/boot.img", true);
            }

            if (C == true)
            {
                folderBrowserDialog1.Description = choosem;
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    CopyDirectory(folderBrowserDialog1.SelectedPath, @"WorkDIR\" + comboBox1.SelectedItem + @"\YourFiles\META-INF");
                }
            }
            SoundPlay();
            Message MS = new Message(null, succ, null, ok, null, null, null, 1, time);
            MS.SetDesktopLocation(this.Location.X + (this.Width / 2) - (MS.Width / 2), this.Location.Y + (this.Height / 2) - (MS.Height / 2));
            MS.ShowDialog();
        }

        public void FromPhone(String L)
        {
            if (Directory.Exists("WorkDIR/" + comboBox1.SelectedItem + "/" + L) == true)
                Directory.Delete("WorkDIR/" + comboBox1.SelectedItem + "/" + L, true);

            string Patch = Directory.GetCurrentDirectory() + @"\trace.bat";
            StreamWriter BatFile = new StreamWriter(Patch, false, Encoding.GetEncoding(866));
            BatFile.WriteLine("@echo off");
            BatFile.WriteLine("echo Starting ADB...");
            BatFile.WriteLine("adb start-server");
            BatFile.WriteLine("echo connect phone...");
            BatFile.WriteLine("rem adb wait-for-device");
            BatFile.WriteLine("echo Gett files from phone...");

            if (L == "YourFiles")
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    string D = null;
                    D = Convert.ToString(checkedListBox1.Items[i]);
                    switch (D)
                    {
                        default:
                            {
                                BatFile.WriteLine("adb pull /" + D + " \"WorkDIR/" + comboBox1.SelectedItem + "/" + L + "/" + D + "\"");
                                break;
                            }
                        case "boot.img":
                            {
                                BatFile.WriteLine("adb remount");
                                BatFile.WriteLine("adb shell su -c \"mkdir /data/tmp/\"");
                                BatFile.WriteLine("adb shell su -c \"dd if=/dev/bootimg of=/data/tmp/boot.img bs=6291456c count=1\"");
                                BatFile.WriteLine("adb pull /data/tmp/boot.img " + " \"WorkDIR/" + comboBox1.SelectedItem + "/" + L + "/" + D + "\"");
                                BatFile.WriteLine("adb shell su -c \"rm /data/tmp/boot.img\"");
                                break;
                            }
                        case "uboot.bin":
                            {
                                BatFile.WriteLine("adb remount");
                                BatFile.WriteLine("adb shell su -c \"mkdir /data/tmp/\"");
                                BatFile.WriteLine("adb shell su -c \"dd if=/dev/uboot of=/data/tmp/uboot.bin bs=393216c count=1\"");
                                BatFile.WriteLine("adb pull /data/tmp/uboot.bin " + " \"WorkDIR/" + comboBox1.SelectedItem + "/" + L + "/" + D + "\"");
                                BatFile.WriteLine("adb shell su -c \"rm /data/tmp/uboot.bin\"");
                                break;
                            }
                        case "logo.bin":
                            {
                                BatFile.WriteLine("adb remount");
                                BatFile.WriteLine("adb shell su -c \"mkdir /data/tmp/\"");
                                BatFile.WriteLine("adb shell su -c \"dd if=/dev/uboot of=/data/tmp/lk.bin bs=3145728c count=1\"");
                                BatFile.WriteLine("adb pull /data/tmp/lk.bin " + " \"WorkDIR/" + comboBox1.SelectedItem + "/" + L + "/" + D + "\"");
                                BatFile.WriteLine("adb shell su -c \"rm /data/tmp/lk.bin\"");
                                break;
                            }
                        case "lk.bin":
                            {
                                BatFile.WriteLine("adb remount");
                                BatFile.WriteLine("adb shell su -c \"mkdir /data/tmp/\"");
                                BatFile.WriteLine("adb shell su -c \"dd if=/dev/uboot of=/data/tmp/lk.bin bs=393216c count=1\"");
                                BatFile.WriteLine("adb pull /data/tmp/lk.bin " + " \"WorkDIR/" + comboBox1.SelectedItem + "/" + L + "/" + D + "\"");
                                BatFile.WriteLine("adb shell su -c \"rm /data/tmp/lk.bin\"");
                                break;
                            }

                    }
                }
            }
            else
            {
                BatFile.WriteLine("adb pull /system \"WorkDIR/" + comboBox1.SelectedItem + "/" + L + "/system\"");
                BatFile.WriteLine("adb remount");
                BatFile.WriteLine("adb shell su -c \"mkdir /data/tmp/\"");
                BatFile.WriteLine("adb shell su -c \"dd if=/dev/bootimg of=/data/tmp/boot.img bs=6291456c count=1\"");
                BatFile.WriteLine("adb pull /data/tmp/boot.img " + " \"WorkDIR/" + comboBox1.SelectedItem + "/" + L + "/boot.img\"");
                BatFile.WriteLine("adb shell su -c \"rm /data/tmp/boot.img\"");
            }

            BatFile.WriteLine("taskkill /F /IM adb.exe");
            BatFile.Close();

            Process win = new Process();
            win.StartInfo.ErrorDialog = true;
            win.StartInfo.FileName = "trace.bat";
            win.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            this.Cursor = Cursors.WaitCursor;
            win.Start();
            win.WaitForExit();
            this.Cursor = Cursors.Default;
            File.Delete("trace.bat");
            SoundPlay();
            Message MS = new Message(null, succ, null, ok, null, null, null, 1, time);
            MS.SetDesktopLocation(this.Location.X + (this.Width / 2) - (MS.Width / 2), this.Location.Y + (this.Height / 2) - (MS.Height / 2));
            MS.ShowDialog();
        }

        public void BootUnpack()
        {
            if (Directory.Exists("WorkDIR\\Images") == true)
                Directory.Delete("WorkDIR\\Images", true);

            Directory.CreateDirectory("WorkDIR\\Images");

            Process win = new Process();
            if (File.Exists(@"WorkDIR\" + comboBox1.SelectedItem + @"\ROMtoPort\boot.img") == true)
            {
                File.Copy(@"WorkDIR\" + comboBox1.SelectedItem + @"\ROMtoPort\boot.img", Directory.GetCurrentDirectory() + "\\Bin\\bootP.img", true);
            }
            else
            {
                Message M = new Message(err, err1, err2, ok, null, null, null, 1, time);
                M.SetDesktopLocation(this.Location.X + (this.Width / 2) - (M.Width / 2), this.Location.Y + (this.Height / 2) - (M.Height / 2));
                M.ShowDialog();
                return;
            }

            if (File.Exists(@"WorkDIR\" + comboBox1.SelectedItem + @"\YourFiles\boot.img") == false)
            {
                Message M = new Message(err, err3, err2, ok, null, null, null, 1, time);
                M.SetDesktopLocation(this.Location.X + (this.Width / 2) - (M.Width / 2), this.Location.Y + (this.Height / 2) - (M.Height / 2));
                M.ShowDialog();
                return;
            }
            else
            {
                File.Copy(@"WorkDIR\" + comboBox1.SelectedItem + @"\YourFiles\boot.img", Directory.GetCurrentDirectory() + "\\Bin\\bootO.img", true);
            }

            win.StartInfo.FileName = "Bin\\imgunpack.cmd";
            win.StartInfo.Arguments = "bootO.img";
            win.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            this.Cursor = Cursors.WaitCursor;
            win.Start();
            win.WaitForExit();
            this.Cursor = Cursors.Default;

            string Patch2 = Directory.GetCurrentDirectory() + @"\Bin\trace2.bat";
            StreamWriter perm = new StreamWriter(Patch2, false, Encoding.GetEncoding(866));
            perm.WriteLine("cmd.exe /c takeown /f \"" + Directory.GetCurrentDirectory() + "\\Bin\\bootO" + "\"" + "  /r /d y && icacls  \"" + Directory.GetCurrentDirectory() + "\\Bin\\bootO" + "\"" + " /grant %username%:F /t");
            //perm.WriteLine("cmd.exe /c takeown /f \"" + Directory.GetCurrentDirectory() + "\\Bin\\bootO" + "\"" + " && icacls /\"" + Directory.GetCurrentDirectory() + "\\Bin\\bootO" + "\"" + " /grant все:F");
            perm.WriteLine("cmd.exe /c takeown /f \"" + Directory.GetCurrentDirectory() + "\\Bin\\bootO" + "\"" + "  /r /d y && icacls  \"" + Directory.GetCurrentDirectory() + "\\Bin\\bootO" + "\"" + " /grant все:F /t");
            //perm.WriteLine("cmd.exe /c takeown /f \"" + Directory.GetCurrentDirectory() + "\\Bin\\bootO" + "\"" + " && icacls /\"" + Directory.GetCurrentDirectory() + "\\Bin\\bootO" + "\"" + " /grant all:F");
            perm.WriteLine("cmd.exe /c takeown /f \"" + Directory.GetCurrentDirectory() + "\\Bin\\bootO" + "\"" + "  /r /d y && icacls  \"" + Directory.GetCurrentDirectory() + "\\Bin\\bootO" + "\"" + " /grant all:F /t");
            //perm.WriteLine("cmd.exe /c takeown /f \"" + Directory.GetCurrentDirectory() + "\\Bin\\bootO" + "\"" + " && icacls /\"" + Directory.GetCurrentDirectory() + "\\Bin\\bootO" + "\"" + " /grant %username%:F");
            perm.Close();

            win.StartInfo.ErrorDialog = true;
            win.StartInfo.FileName = Patch2;
            this.Cursor = Cursors.WaitCursor;
            win.Start();
            win.WaitForExit();
            this.Cursor = Cursors.Default;

            if (Directory.Exists("Bin\\bootO"))
            {
                if (Directory.Exists("WorkDIR\\Images\\bootO"))
                    Directory.Delete("WorkDIR\\Images\\bootO");
                Directory.Move("Bin\\bootO","WorkDIR\\Images\\bootO");
            }

            Process winc = new Process();
            winc.StartInfo.FileName = "Bin\\imgunpack.cmd";
            winc.StartInfo.Arguments = "bootP.img";
            winc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            this.Cursor = Cursors.WaitCursor;
            winc.Start();
            winc.WaitForExit();
            this.Cursor = Cursors.Default;

            StreamWriter per = new StreamWriter(Patch2, false, Encoding.GetEncoding(866));
            per.WriteLine("cmd.exe /c takeown /f \"" + Directory.GetCurrentDirectory() + "\\Bin\\bootP" + "\"" + " && icacls /\"" + Directory.GetCurrentDirectory() + "\\Bin\\bootP" + "\"" + " /grant все:F");
            per.WriteLine("cmd.exe /c takeown /f \"" + Directory.GetCurrentDirectory() + "\\Bin\\bootP" + "\"" + "  /r /d y && icacls  \"" + Directory.GetCurrentDirectory() + "\\Bin\\bootP" + "\"" + " /grant все:F /t");
            per.WriteLine("cmd.exe /c takeown /f \"" + Directory.GetCurrentDirectory() + "\\Bin\\bootP" + "\"" + " && icacls /\"" + Directory.GetCurrentDirectory() + "\\Bin\\bootP" + "\"" + " /grant all:F");
            per.WriteLine("cmd.exe /c takeown /f \"" + Directory.GetCurrentDirectory() + "\\Bin\\bootP" + "\"" + "  /r /d y && icacls  \"" + Directory.GetCurrentDirectory() + "\\Bin\\bootP" + "\"" + " /grant all:F /t");
            per.WriteLine("cmd.exe /c takeown /f \"" + Directory.GetCurrentDirectory() + "\\Bin\\bootP" + "\"" + " && icacls /\"" + Directory.GetCurrentDirectory() + "\\Bin\\bootP" + "\"" + " /grant %username%:F");
            per.WriteLine("cmd.exe /c takeown /f \"" + Directory.GetCurrentDirectory() + "\\Bin\\bootP" + "\"" + "  /r /d y && icacls  \"" + Directory.GetCurrentDirectory() + "\\Bin\\bootP" + "\"" + " /grant %username%:F /t");
            per.Close();

            winc.StartInfo.ErrorDialog = true;
            winc.StartInfo.FileName = Patch2;
            this.Cursor = Cursors.WaitCursor;
            winc.Start();
            winc.WaitForExit();
            this.Cursor = Cursors.Default;

            if (Directory.Exists("Bin\\bootP"))
            {
                if (Directory.Exists("WorkDIR\\Images\\bootP"))
                    Directory.Delete("WorkDIR\\Images\\bootP");
                Directory.Move("Bin\\bootP", "WorkDIR\\Images\\bootP");
            }

            File.Delete("Bin\\bootP.img");
            File.Delete("Bin\\bootO.img");

            button15.Enabled = true;

            Message MF = new Message(null, un_succ, null, ok, null, null, null, 1, time);
            MF.SetDesktopLocation(this.Location.X + (this.Width / 2) - (MF.Width / 2), this.Location.Y + (this.Height / 2) - (MF.Height / 2));
            MF.ShowDialog();
        }

        public void BootPack()
        {
            if (Directory.Exists("WorkDIR\\Images\\bootP"))
                CopyDirectory("WorkDIR\\Images\\bootP", "Bin\\boot");
            if (File.Exists("WorkDIR\\Images\\bootO\\kernel"))
                File.Copy("WorkDIR\\Images\\bootO\\kernel","Bin\\boot\\kernel", true);
            if (File.Exists("WorkDIR\\Images\\bootO\\kernel_header"))
                File.Copy("WorkDIR\\Images\\bootO\\kernel_header","Bin\\boot\\kernel_header", true);

            Process wind = new Process();
            wind.StartInfo.FileName = "Bin\\imgpack.cmd";
            wind.StartInfo.Arguments = "boot";
            wind.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            this.Cursor = Cursors.WaitCursor;
            wind.StartInfo.WorkingDirectory = "\"" + Directory.GetCurrentDirectory() + "\\Bin\"";
            wind.Start();
            wind.WaitForExit();
            this.Cursor = Cursors.Default;

            if (File.Exists("Bin\\new_image.img"))
            {
                if (File.Exists(@"WorkDIR\" + comboBox1.SelectedItem + @"\Pack\boot.img"))
                    File.Delete(@"WorkDIR\" + comboBox1.SelectedItem + @"\Pack\boot.img");
                File.Move("Bin\\new_image.img", @"WorkDIR\" + comboBox1.SelectedItem + @"\boot.img");
                Directory.Delete("WorkDIR\\Images", true);
                Directory.Delete("Bin\\boot", true);

                Message MF = new Message(null, re_succ, null, ok, null, null, null, 1, time);
                MF.SetDesktopLocation(this.Location.X + (this.Width / 2) - (MF.Width / 2), this.Location.Y + (this.Height / 2) - (MF.Height / 2));
                MF.ShowDialog();
            }
            else
            {
                Message MD = new Message(err, repeat, null, ok, null, null, null, 1, time);
                MD.SetDesktopLocation(this.Location.X + (this.Width / 2) - (MD.Width / 2), this.Location.Y + (this.Height / 2) - (MD.Height / 2));
                MD.ShowDialog();
            }
        }

        public void SignROM()
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                Directory.CreateDirectory("WorkDIR/AdaptedROMS");
                string Patch = Directory.GetCurrentDirectory() + @"\Bin\trace.bat";
                StreamWriter BatFile = new StreamWriter(Patch, false, Encoding.GetEncoding(866));
                BatFile.WriteLine("@echo off");
                BatFile.WriteLine("cd /d " + Directory.GetCurrentDirectory() + @"\Bin");
                BatFile.WriteLine("signapk.cmd " + "\"" + openFileDialog2.FileName + "\"");
                BatFile.Close();
                try
                {
                    Process win = new Process();
                    win.StartInfo.ErrorDialog = true;
                    win.StartInfo.FileName = Patch;
                    win.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    this.Cursor = Cursors.WaitCursor;
                    win.Start();
                    win.WaitForExit();
                    this.Cursor = Cursors.Default;

                    if (File.Exists("WorkDIR/AdaptedROMS\\" + Path.GetFileName(openFileDialog2.FileName)))
                        File.Delete("WorkDIR/AdaptedROMS\\" + Path.GetFileName(openFileDialog2.FileName));
                    File.Move(Directory.GetCurrentDirectory() + "\\Bin\\" + Path.GetFileNameWithoutExtension(openFileDialog2.FileName) + "_signed.zip", "WorkDIR/AdaptedROMS\\" + Path.GetFileName(openFileDialog2.FileName));
                }

                finally
                {
                    SoundPlay();

                    Message MS = new Message(null, sign_succ, null, ok, null, null, null, 1, time);
                    MS.SetDesktopLocation(this.Location.X + (this.Width / 2) - (MS.Width / 2), this.Location.Y + (this.Height / 2) - (MS.Height / 2));
                    MS.ShowDialog();

                    ProcessStartInfo startInfo = null;
                    if (File.Exists("WorkDIR/AdaptedROMS\\" + Path.GetFileName(openFileDialog2.FileName)) == true)
                    {
                        startInfo = new ProcessStartInfo("Explorer");
                        startInfo.UseShellExecute = false;
                        startInfo.Arguments = @"/select," + "\"" + Directory.GetCurrentDirectory() + "\\WorkDIR\\AdaptedROMS\\" + Path.GetFileName(openFileDialog2.FileName) + "\"";
                        Process.Start(startInfo);
                    }

                    if (File.Exists("Bin\\trace.bat"))
                        File.Delete("Bin\\trace.bat");
                }
            }
        }

        public void BuildROM()
        {
            if (Directory.Exists(@"WorkDIR\" + comboBox1.SelectedItem + @"\ROMtoPORT\system") == false)
            {
                Message M = new Message(err, err4, err5, ok, null, null, null, 1, time);
                M.SetDesktopLocation(this.Location.X + (this.Width / 2) - (M.Width / 2), this.Location.Y + (this.Height / 2) - (M.Height / 2));
                M.ShowDialog();
                return;
            }

            if (Directory.Exists(@"WorkDIR\" + comboBox1.SelectedItem + @"\YourFiles\system") == false)
            {
                Message M = new Message(err, err6, err7, ok, null, null, null, 1, time);
                M.SetDesktopLocation(this.Location.X + (this.Width / 2) - (M.Width / 2), this.Location.Y + (this.Height / 2) - (M.Height / 2));
                M.ShowDialog();
                return;
            }
            if (checkBox6.Checked == true)
            {
                Process win = new Process();
                if (File.Exists(@"WorkDIR\" + comboBox1.SelectedItem + @"\ROMtoPort\boot.img") == true)
                {
                    File.Copy(@"WorkDIR\" + comboBox1.SelectedItem + @"\ROMtoPort\boot.img", Directory.GetCurrentDirectory() + "\\Bin\\bootP.img", true);
                }
                else
                {
                    Message M = new Message(err, err1, err2, ok, null, null, null, 1, time);
                    M.SetDesktopLocation(this.Location.X + (this.Width / 2) - (M.Width / 2), this.Location.Y + (this.Height / 2) - (M.Height / 2));
                    M.ShowDialog();
                    return;
                }

                if (File.Exists(@"WorkDIR\" + comboBox1.SelectedItem + @"\YourFiles\boot.img") == false)
                {
                    Message M = new Message(err, err3, err2, ok, null, null, null, 1, time);
                    M.SetDesktopLocation(this.Location.X + (this.Width / 2) - (M.Width / 2), this.Location.Y + (this.Height / 2) - (M.Height / 2));
                    M.ShowDialog();
                    return;
                }
                else
                {
                    File.Copy(@"WorkDIR\" + comboBox1.SelectedItem + @"\YourFiles\boot.img", Directory.GetCurrentDirectory() + "\\Bin\\bootO.img", true);
                }

                win.StartInfo.FileName = "Bin\\imgunpack.cmd";
                win.StartInfo.Arguments = "bootO.img";
                win.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                this.Cursor = Cursors.WaitCursor;
                win.Start();
                win.WaitForExit();
                this.Cursor = Cursors.Default;

                Process winc = new Process();
                winc.StartInfo.FileName = "Bin\\imgunpack.cmd";
                winc.StartInfo.Arguments = "bootP.img";
                winc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                this.Cursor = Cursors.WaitCursor;
                winc.Start();
                winc.WaitForExit();
                this.Cursor = Cursors.Default;

                if (Directory.Exists("Bin\\bootP"))
                    CopyDirectory("Bin\\bootP", "Bin\\boot");

                if (File.Exists("Bin\\bootO\\kernel"))
                    File.Copy("Bin\\bootO\\kernel", "Bin\\boot\\kernel", true);
                if (File.Exists("Bin\\bootO\\kernel_header"))
                    File.Copy("Bin\\bootO\\kernel_header", "Bin\\boot\\kernel_header", true);

                File.Delete("Bin\\bootP.img");
                File.Delete("Bin\\bootO.img");
                Directory.Delete("Bin\\bootO",true);
                Directory.Delete("Bin\\bootP",true);

                Process wind = new Process();
                wind.StartInfo.FileName = "Bin\\imgpack.cmd";
                wind.StartInfo.Arguments = "boot";
                wind.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                this.Cursor = Cursors.WaitCursor;
                wind.StartInfo.WorkingDirectory = "\"" + Directory.GetCurrentDirectory() + "\\Bin\"";
                wind.Start();
                wind.WaitForExit();
                this.Cursor = Cursors.Default;

                if (File.Exists("Bin\\new_image.img"))
                {
                    if (File.Exists(@"WorkDIR\" + comboBox1.SelectedItem + @"\boot.img"))
                        File.Delete(@"WorkDIR\" + comboBox1.SelectedItem + @"\boot.img");

                    File.Move("Bin\\new_image.img", @"WorkDIR\" + comboBox1.SelectedItem + @"\boot.img");
                    Directory.Delete("Bin\\boot", true);
                }
            }

            /*if (radioButton1.Checked == true)
            {*/

                using (ZipFile zip = new ZipFile())
                {
                    if (Directory.Exists(@"WorkDIR\" + comboBox1.SelectedItem + @"\YourFiles\META-INF") == false && Directory.Exists(@"WorkDIR\" + comboBox1.SelectedItem + @"\ROMtoPort\META-INF") == false)
                    {
                        Message M = new Message(err, meta, null, exit, choose, null, null, 2, 0);
                        M.SetDesktopLocation(this.Location.X + (this.Width / 2) - (M.Width / 2), this.Location.Y + (this.Height / 2) - (M.Height / 2));
                        M.ShowDialog();
                        if (M.fk == 1)
                            return;
                        else
                        {
                            folderBrowserDialog1.Description = choosem;
                            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                            {
                                CopyDirectory(folderBrowserDialog1.SelectedPath, @"WorkDIR\" + comboBox1.SelectedItem + @"\Pack\META-INF");
                            }
                            else
                                return;
                        }
                    }
                    else
                    {
                        if (Directory.Exists(@"WorkDIR\" + comboBox1.SelectedItem + @"\YourFiles\META-INF") == true || Directory.Exists(@"WorkDIR\" + comboBox1.SelectedItem + @"\Pack\META-INF") == true)
                        {
                            if (Directory.Exists(@"WorkDIR\" + comboBox1.SelectedItem + @"\Pack\META-INF"))
                                Directory.Delete(@"WorkDIR\" + comboBox1.SelectedItem + @"\Pack\META-INF", true);
                        }
                    }

                    string h = null;
                    CopyDirectory(@"WorkDIR\" + comboBox1.SelectedItem + @"\ROMtoPort", @"WorkDIR\" + comboBox1.SelectedItem + @"\Pack");
                    CopyDirectory(@"WorkDIR\" + comboBox1.SelectedItem + @"\YourFiles", @"WorkDIR\" + comboBox1.SelectedItem + @"\Pack");


                    if (File.Exists(@"WorkDIR\" + comboBox1.SelectedItem + @"\boot.img") == true)
                    {
                        File.Copy(@"WorkDIR\" + comboBox1.SelectedItem + @"\boot.img", @"WorkDIR\" + comboBox1.SelectedItem + @"\Pack\boot.img", true);
                        File.Delete(@"WorkDIR\" + comboBox1.SelectedItem + @"\boot.img");
                    }
                    if (File.Exists(@"WorkDIR\" + comboBox1.SelectedItem + @"\Pack\system\build.prop") == true)
                    {
                        using (StreamWriter sw = new StreamWriter(@"WorkDIR\" + comboBox1.SelectedItem + @"\Pack\system\build.prop", true, Encoding.ASCII))
                        {
                            sw.WriteLine();
                            sw.WriteLine("# Ported with MTK FirmwareAdapter Tool");
                            sw.WriteLine("persist.service.adb.enable=1");
                            sw.WriteLine("persist.adb.notify=0");
                            sw.Close();
                        }
                    }
                    if (Directory.Exists(@"WorkDIR\" + comboBox1.SelectedItem + @"\Pack\system\data") == false)
                        Directory.CreateDirectory(@"WorkDIR\" + comboBox1.SelectedItem + @"\Pack\system\data");
                    System.IO.StreamWriter swr = new System.IO.StreamWriter(@"WorkDIR\" + comboBox1.SelectedItem + @"\Pack\system\data\PortProgect.fat");
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        swr.WriteLine(checkedListBox1.Items[i]);
                    }
                    swr.Close();
                    zip.AddDirectory(@"WorkDIR\" + comboBox1.SelectedItem + @"\Pack");

                    if (Directory.Exists("WorkDIR\\AdaptedROMS") == false)
                    {
                        Directory.CreateDirectory("WorkDIR\\AdaptedROMS");
                    }
                    if (checkBox5.Checked == false)
                    {
                        string k = "_" + DateTime.Now.ToString("dd.MM.yy_HH-mm-ss");
                        h = Convert.ToString(comboBox1.SelectedItem + k + ".zip");
                    }
                    else
                    {
                        if (textBox3.Text == "" || textBox3.Text == null)
                        {
                            string k = "_" + DateTime.Now.ToString("dd.MM.yy_HH-mm-ss");
                            h = Convert.ToString(comboBox1.SelectedItem + k + ".zip");
                        }
                        else
                            h = textBox3.Text + ".zip";
                    }
                    zip.Save("WorkDIR\\AdaptedROMS\\" + h);
                    Directory.Delete(@"WorkDIR\" + comboBox1.SelectedItem + @"\Pack", true);

                    if (checkBox7.Checked == true)
                    {
                        string Patch = Directory.GetCurrentDirectory() + @"\Bin\trace.bat";
                        StreamWriter BatFile = new StreamWriter(Patch, false, Encoding.GetEncoding(866));
                        BatFile.WriteLine("@echo off");
                        BatFile.WriteLine("cd /d " + Directory.GetCurrentDirectory() + @"\Bin");
                        BatFile.WriteLine("signapk.cmd " + "\"" + Directory.GetCurrentDirectory() + "\\WorkDIR\\AdaptedROMS\\" + h + "\"");
                        BatFile.Close();
                        try
                        {
                            Process win = new Process();
                            win.StartInfo.ErrorDialog = true;
                            win.StartInfo.FileName = Patch;
                            win.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            this.Cursor = Cursors.WaitCursor;
                            win.Start();
                            win.WaitForExit();
                            this.Cursor = Cursors.Default;

                            if (File.Exists("WorkDIR/AdaptedROMS\\" + Path.GetFileName(h)))
                                File.Delete("WorkDIR/AdaptedROMS\\" + Path.GetFileName(h));

                            if (File.Exists(@"Bin\trace.bat"))
                                File.Delete(@"Bin\trace.bat");
                        }
                        finally
                        {
                            File.Move(Directory.GetCurrentDirectory() + "\\Bin\\" + Path.GetFileNameWithoutExtension(h) + "_signed.zip", "WorkDIR/AdaptedROMS\\" + h);
                        }
                    }

                    if (File.Exists(@"Projects\" + comboBox1.SelectedItem + @"\boot.img") == true)
                        File.Delete(@"Projects\" + comboBox1.SelectedItem + @"\boot.img");

                    SoundPlay();

                    Message MS = new Message(null, build_succ, null, ok, null, null, null, 1, time);
                    MS.SetDesktopLocation(this.Location.X + (this.Width / 2) - (MS.Width / 2), this.Location.Y + (this.Height / 2) - (MS.Height / 2));
                    MS.ShowDialog();

                    ProcessStartInfo startInfo = null;
                    startInfo = new ProcessStartInfo("Explorer");
                    startInfo.UseShellExecute = false;
                    startInfo.Arguments = @"/select," + "\"" + Directory.GetCurrentDirectory() + "\\WorkDIR\\AdaptedROMS\\" + h + "\"";
                    Process.Start(startInfo);
                }
            /*}
            else
            {
                string h;
                if (checkBox5.Checked == false)
                    {
                        string k = "_" + DateTime.Now.ToString("dd.MM.yy_HH-mm-ss");
                        h = Convert.ToString(comboBox1.SelectedItem + k);
                    }
                    else
                    {
                        if (textBox3.Text == "" || textBox3.Text == null)
                        {
                            string k = "_" + DateTime.Now.ToString("dd.MM.yy_HH-mm-ss");
                            h = Convert.ToString(comboBox1.SelectedItem + k);
                        }
                        else
                            h = textBox3.Text;
                    }

                if (Directory.Exists(Directory.GetCurrentDirectory() + "WorkDIR\\AdaptedROMS\\" + h) == false)
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "WorkDIR\\AdaptedROMS\\" + h);
                else
                {
                    Directory.Delete(Directory.GetCurrentDirectory() + "WorkDIR\\AdaptedROMS\\" + h, true);
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "WorkDIR\\AdaptedROMS\\" + h);
                }

                CopyDirectory(@"WorkDIR\" + comboBox1.SelectedItem + @"\ROMtoPort\system", @"WorkDIR\Pack\system");
                CopyDirectory(@"WorkDIR\" + comboBox1.SelectedItem + @"\YourFiles\system", @"WorkDIR\Pack\system");

                if (File.Exists(@"WorkDIR\" + comboBox1.SelectedItem + @"\boot.img") == true)
                    File.Copy(@"WorkDIR\" + comboBox1.SelectedItem + @"\boot.img", "WorkDIR\\AdaptedROMS\\" + h + @"\boot.img", true);

                if (File.Exists(@"WorkDIR\Pack\system\build.prop") == true)
                {
                    using (StreamWriter sw = new StreamWriter(@"WorkDIR\Pack\system\build.prop", true, Encoding.ASCII))
                    {
                        sw.WriteLine();
                        sw.WriteLine("# Ported with MTK FirmwareAdapter Tool");
                        sw.WriteLine("persist.service.adb.enable=1");
                        sw.WriteLine("persist.adb.notify=0");
                        sw.Close();
                    }
                }
                if (Directory.Exists(@"WorkDIR\Pack\system\data") == false)
                    Directory.CreateDirectory(@"WorkDIR\Pack\system\data");
                System.IO.StreamWriter swr = new System.IO.StreamWriter(@"WorkDIR\Pack\system\data\PortProgect.fat");
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    swr.WriteLine(checkedListBox1.Items[i]);
                }
                swr.Close();

                if (Directory.Exists("WorkDIR/AdaptedROMS\\" + h) == true)
                    Directory.Delete("WorkDIR/AdaptedROMS\\" + h,true);

                if (Directory.Exists("Bin\\Pack") == true)
                    Directory.Delete("Bin\\Pack", true);

                Directory.Move("WorkDIR\\Pack","Bin\\Pack");

                string Patch = Directory.GetCurrentDirectory() + @"\Bin\pack_ext4.bat";
                Process win = new Process();
                win.StartInfo.ErrorDialog = true;
                win.StartInfo.FileName = Patch;
                win.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + @"\Bin";
                win.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                this.Cursor = Cursors.WaitCursor;
                win.Start();
                win.WaitForExit();
                this.Cursor = Cursors.Default;

                if (Directory.Exists("Bin\\Pack") == true)
                    Directory.Delete("Bin\\Pack", true);

                Directory.CreateDirectory("WorkDIR\\AdaptedROMS\\" + h);
                File.Move("WorkDIR\\system.img", "WorkDIR\\AdaptedROMS\\" + h + "\\system.img");
                File.Delete("WorkDIR\\system.info");

                Process.Start("WorkDIR\\AdaptedROMS\\" + h);
                
            }*/
        }

        public void adbw(int t)
        {
            if (t != -1)
            {
                Process winс = new Process();
                winс.StartInfo.FileName = "taskkill";
                winс.StartInfo.Arguments = "/F /IM adb.exe";
                winс.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                this.Cursor = Cursors.WaitCursor;
                winс.Start();
                winс.WaitForExit();
                this.Cursor = Cursors.Default;

                string Patch = Directory.GetCurrentDirectory() + "\\Bin\\trace.bat";
                StreamWriter BatFile = new StreamWriter(Patch, false, Encoding.GetEncoding(866));
                BatFile.WriteLine("@echo off");
                BatFile.WriteLine("cd /d \"" + Directory.GetCurrentDirectory() + "\\Bin");
                BatFile.WriteLine("echo Starting ADB...");
                BatFile.WriteLine("adb start-server");
                BatFile.WriteLine("echo connect phone...");
                BatFile.WriteLine("rem adb wait-for-device");

                Process win = new Process();
                win.StartInfo.ErrorDialog = true;
                win.StartInfo.FileName = Patch;
                switch (t)
                {
                    default:
                        {
                            return;
                        }
                    case 0:
                        {

                            BatFile.WriteLine("adb shell");
                            win.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                            break;
                        }

                    case 1:
                        {
                            BatFile.WriteLine("adb reboot now");
                            win.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            break;
                        }
                    case 2:
                        {
                            BatFile.WriteLine("adb reboot recovery");
                            win.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            break;
                        }
                    case 3:
                        {
                            BatFile.WriteLine("adb shell busybox killall system_server");
                            win.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            break;
                        }
                }

                BatFile.WriteLine("taskkill /F /IM adb.exe");
                BatFile.Close();

                this.Cursor = Cursors.WaitCursor;
                win.Start();
                win.WaitForExit();
                this.Cursor = Cursors.Default;
                File.Delete("Bin\\trace.bat");
            }
            else return;
        }

        public void adblog()
        {
            Process winс = new Process();
            winс.StartInfo.FileName = "taskkill";
            winс.StartInfo.Arguments = "/F /IM adb.exe";
            winс.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            this.Cursor = Cursors.WaitCursor;
            winс.Start();
            winс.WaitForExit();
            this.Cursor = Cursors.Default;

            string pol = "";
            switch (domainUpDown1.SelectedIndex)
            {
                case 0:
                    {
                        pol += " *:v";
                        break;
                    }
                case 1:
                    {
                        pol += " *:d";
                        break;
                    }
                case 2:
                    {
                        pol += " *:i";
                        break;
                    }
                case 3:
                    {
                        pol += " *:w";
                        break;
                    }
                case 4:
                    {
                        pol += " *:e";
                        break;
                    }
                case 5:
                    {
                        pol += " *:f";
                        break;
                    }
                default:
                    break;
            }
            string Patch = Directory.GetCurrentDirectory() + "\\Bin\\trace.bat";
            StreamWriter BatFile = new StreamWriter(Patch, false, Encoding.GetEncoding(866));
            BatFile.WriteLine("@echo off");
            BatFile.WriteLine("cd /d \"" + Directory.GetCurrentDirectory() + "\\Bin");
            BatFile.WriteLine("echo Starting ADB...");
            BatFile.WriteLine("adb start-server");
            BatFile.WriteLine("echo connect phone...");
            BatFile.WriteLine("rem adb wait-for-device");
            BatFile.WriteLine("echo Reading logcat...");
            BatFile.WriteLine("start adb logcat" + pol);
            BatFile.WriteLine("adb logcat" + pol + " > \"" + Directory.GetCurrentDirectory() + "\\Utilits\\logcat.txt\"");
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
        }

    #endregion

    #region Кнопки (Buttons)

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
            Settings F3 = new Settings();
            F3.SetDesktopLocation(this.Location.X + (this.Width / 2) - (F3.Width / 2), this.Location.Y + (this.Height / 2) - (F3.Height / 2));
            F3.ShowDialog();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.SetDesktopLocation(this.Location.X + (this.Width / 2) - (ab.Width / 2), this.Location.Y + (this.Height / 2) - (ab.Height / 2));
            ab.ShowDialog();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            string ths = "YourFiles";
            bool c = checkBox3.Checked;
            int D = comboBox4.SelectedIndex;
            switch (D)
            {
                default:
                    {
                        return;
                    }
                case 0:
                    {
                        ZIPunpack(ths, c);
                        break;
                    }
                case 1:
                    {
                        FTUnpack(ths);
                        break;
                    }
                case 2:
                    {
                        Unpacked(ths,c);
                        break;
                    }
                case 3:
                    {
                        FromPhone(ths);
                        break;
                    }
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (ImportProject.ShowDialog() == DialogResult.OK)
            {
                File.Copy(ImportProject.FileName,"Projects//" + Path.GetFileName(ImportProject.FileName),true);
                ProjectInit();
                comboBox1.SelectedItem = Path.GetFileNameWithoutExtension(ImportProject.FileName);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveProject.FileName = comboBox1.SelectedItem.ToString();
            if (SaveProject.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(SaveProject.FileName);
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    sw.WriteLine(checkedListBox1.Items[i]);
                }
                sw.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                checkedListBox1.Items.Add(S);
                S = null;
                s = 0;
                button4.Enabled = false;
            }
            else
                checkedListBox1.Items.Add(textBox2.Text);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            bool c = checkBox4.Checked;
            string ths = "ROMtoPort";
            int D = comboBox5.SelectedIndex;
            switch (D)
            {
                default:
                    {
                        return;
                    }
                case 0:
                    {
                        ZIPunpack(ths, c);
                        break;
                    }
                case 1:
                    {
                        FTUnpack(ths);
                        break;
                    }
                case 2:
                    {
                        Unpacked(ths,c);
                        break;
                    }
                case 3:
                    {
                        FromPhone(ths);
                        break;
                    }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string R = null;
            if (File.Exists(@"WorkDIR\" + comboBox1.SelectedItem + @"\YourFiles\system\build.prop") == true) R = @"WorkDIR\" + comboBox1.SelectedItem + @"\YourFiles\system\build.prop";
            else return;
            Editor Ed = new Editor(R);
            Ed.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string R = null;
            if (File.Exists(@"WorkDIR\" + comboBox1.SelectedItem + @"\ROMtoPort\system\build.prop") == true) R = @"WorkDIR\" + comboBox1.SelectedItem + @"\ROMtoPort\system\build.prop";
            else return;
            Editor Ed = new Editor(R);
            Ed.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string R = null;
            if (File.Exists(@"WorkDIR\" + comboBox1.SelectedItem + @"\YourFiles\META-INF\com\google\android\updater-script") == true) R = @"WorkDIR\" + comboBox1.SelectedItem + @"\YourFiles\META-INF\com\google\android\updater-script";
            else return;
            Editor Ed = new Editor(R);
            Ed.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string R = null;
            if (File.Exists(@"WorkDIR\" + comboBox1.SelectedItem + @"\ROMtoPort\META-INF\com\google\android\updater-script") == true) R = @"WorkDIR\" + comboBox1.SelectedItem + @"\ROMtoPort\META-INF\com\google\android\updater-script";
            else return;
            Editor Ed = new Editor(R);
            Ed.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(@"WorkDIR\" + comboBox1.SelectedItem + @"\YourFiles") == true)
                Process.Start(@"WorkDIR\" + comboBox1.SelectedItem + @"\YourFiles");
            else return;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(@"WorkDIR\" + comboBox1.SelectedItem + @"\ROMtoPORT") == true)
                Process.Start(@"WorkDIR\" + comboBox1.SelectedItem + @"\ROMtoPORT");
            else return;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(@"WorkDIR\\AdaptedROMS") == true)
                Process.Start(@"WorkDIR\\AdaptedROMS");
            else return;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists("WorkDIR\\" + comboBox1.SelectedItem) == true)
                {
                    if (Directory.Exists("boot\\" + comboBox1.SelectedItem) == true)
                        Directory.Delete("boot\\" + comboBox1.SelectedItem, true);

                    Directory.Delete("WorkDIR\\" + comboBox1.SelectedItem, true);
                    Message M = new Message(null, del_succ, null, ok, null, null, null, 1, time);
                    M.SetDesktopLocation(this.Location.X + (this.Width / 2) - (M.Width / 2), this.Location.Y + (this.Height / 2) - (M.Height / 2));
                    M.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Message M = new Message(del_err, ex.Message, null, ok, null, null, null, 1, time);
                M.SetDesktopLocation(this.Location.X + (this.Width / 2) - (M.Width / 2), this.Location.Y + (this.Height / 2) - (M.Height / 2));
                M.ShowDialog();
            }
            finally
            {

            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            string R = null;
            if (File.Exists(Directory.GetCurrentDirectory() + "\\Utilits\\prop") == false)
            {
                if (Directory.Exists(Directory.GetCurrentDirectory() + "\\Utilits") == false)
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Utilits");
                string Patch = Directory.GetCurrentDirectory() + "\\Bin\\trace.bat";
                StreamWriter BatFile = new StreamWriter(Patch, false, Encoding.GetEncoding(866));
                BatFile.WriteLine("@echo off");

                BatFile.WriteLine("echo Starting ADB...");
                BatFile.WriteLine("cd /d \"" + Directory.GetCurrentDirectory() + "\\Bin");
                BatFile.WriteLine("adb start-server");
                BatFile.WriteLine("echo connect phone...");
                BatFile.WriteLine("rem adb wait-for-device");
                BatFile.WriteLine("echo Gett files from phone...");
                BatFile.WriteLine("adb pull /system/build.prop " + "\"" + Directory.GetCurrentDirectory() + "\\Utilits\\prop\"");
                BatFile.Close();


                Process win = new Process();
                win.StartInfo.ErrorDialog = true;
                win.StartInfo.FileName = Directory.GetCurrentDirectory() + "\\Bin\\trace.bat";
                win.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                this.Cursor = Cursors.WaitCursor;
                win.Start();
                win.WaitForExit();
                this.Cursor = Cursors.Default;

                File.Delete("Bin\\trace.bat");

                Process winс = new Process();
                winс.StartInfo.FileName = "taskkill";
                winс.StartInfo.Arguments = "/F /IM adb.exe";
                winс.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                this.Cursor = Cursors.WaitCursor;
                winс.Start();
                winс.WaitForExit();
                this.Cursor = Cursors.Default;
            }

            if (File.Exists("Utilits\\prop") == true)
            {
                R = Directory.GetCurrentDirectory() + "\\Utilits\\prop";
                Editor f2 = new Editor(R);
                f2.Owner = this;
                f2.Show();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            BootUnpack();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            BootPack();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(@"WorkDIR\\Images") == true)
                Process.Start(@"WorkDIR\\Images");
            else return;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            SignROM();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            BuildROM();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            adbw(comboBox7.SelectedIndex);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            SignROM();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            BR_repack f2 = new BR_repack(true);
            f2.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            adblog();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (File.Exists("Utilits\\prop") == true || File.Exists("Utilits\\logcat.txt") == true)
            {
                if (File.Exists("Utilits\\prop") == true)
                    File.Delete("Utilits\\prop");
                if (File.Exists("Utilits\\logcat.txt") == true)
                    File.Delete("Utilits\\logcat.txt");
            }
            else return;

            Message MS = new Message(null, temp_succ, temp_succ1, ok, null, null, null, 1, time);
            MS.SetDesktopLocation(this.Location.X + (this.Width / 2) - (MS.Width / 2), this.Location.Y + (this.Height / 2) - (MS.Height / 2));
            MS.ShowDialog();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"Utilits\logcat.txt") == true)
            {
                Process.Start(@"Utilits\logcat.txt");
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Message M = new Message(get, null, null, exit, next, null, null, 2, 0);
            M.SetDesktopLocation(this.Location.X + (this.Width / 2) - (M.Width / 2), this.Location.Y + (this.Height / 2) - (M.Height / 2));
            M.groupBox7.Visible = true;
            M.radioButton1.Text = yf;
            M.radioButton2.Text = sm;
            M.ShowDialog();
            if (M.fk == 1)
            {
                return;
            }
            else
            {
                if (M.radioButton1.Checked == true)
                {
                    if (Directory.Exists(@"WorkDIR\" + comboBox1.SelectedItem + @"\YourFiles\system") == false)
                    {
                        if (checkBox8.Checked)
                        {
                            int lastIndex = checkedListBox1.Items.Count - 1;
                            for (int i = lastIndex; i >= 0; i--)
                                checkedListBox1.Items.RemoveAt(i);
                            checkBox1.Text = sa;
                        }

                        var dir = new DirectoryInfo(@"WorkDIR\" + comboBox1.SelectedItem + @"\YourFiles");
                        foreach (FileInfo file in dir.GetFiles("*", SearchOption.AllDirectories))
                        {
                            if (file.FullName.IndexOf("META-INF") < 1)
                                checkedListBox1.Items.Add(file.FullName.Replace(@"WorkDIR\" + comboBox1.SelectedItem + @"\YourFiles" + "\\", "").Replace(@"\", "/"));
                        }
                    }
                    else
                        return;
                }
                else
                {
                    ImportList.Description = des;
                    if (ImportList.ShowDialog() == DialogResult.OK)
                    {
                        int lastIndex = checkedListBox1.Items.Count - 1;
                        for (int i = lastIndex; i >= 0; i--)
                            checkedListBox1.Items.RemoveAt(i);
                        checkBox1.Text = sa;

                        var dir = new DirectoryInfo(ImportList.SelectedPath);
                        foreach (FileInfo file in dir.GetFiles("*", SearchOption.AllDirectories))
                        {
                            if (file.FullName.IndexOf("META-INF") < 1)
                                if (file.FullName.IndexOf("system") < 1)
                                    if (ImportList.SelectedPath.EndsWith("app") || ImportList.SelectedPath.EndsWith("bin") || ImportList.SelectedPath.EndsWith("mobile_toolkit") || ImportList.SelectedPath.EndsWith("etc") || ImportList.SelectedPath.EndsWith("fonts") || ImportList.SelectedPath.EndsWith("framework") || ImportList.SelectedPath.EndsWith("lib") || ImportList.SelectedPath.EndsWith("data") || ImportList.SelectedPath.EndsWith("media") || ImportList.SelectedPath.EndsWith("usr") || ImportList.SelectedPath.EndsWith("vendor") || ImportList.SelectedPath.EndsWith("xbin"))
                                    {
                                        if (ImportList.SelectedPath.EndsWith("app"))
                                            checkedListBox1.Items.Add("system/app" + file.FullName.Replace(ImportList.SelectedPath, "").Replace(@"\", "/"));
                                        if (ImportList.SelectedPath.EndsWith("bin"))
                                            checkedListBox1.Items.Add("system/bin" + file.FullName.Replace(ImportList.SelectedPath, "").Replace(@"\", "/"));
                                        if (ImportList.SelectedPath.EndsWith("etc"))
                                            checkedListBox1.Items.Add("system/etc" + file.FullName.Replace(ImportList.SelectedPath, "").Replace(@"\", "/"));
                                        if (ImportList.SelectedPath.EndsWith("fonts"))
                                            checkedListBox1.Items.Add("system/fonts" + file.FullName.Replace(ImportList.SelectedPath, "").Replace(@"\", "/"));
                                        if (ImportList.SelectedPath.EndsWith("framework"))
                                            checkedListBox1.Items.Add("system/framework" + file.FullName.Replace(ImportList.SelectedPath, "").Replace(@"\", "/"));
                                        if (ImportList.SelectedPath.EndsWith("lib"))
                                            checkedListBox1.Items.Add("system/lib" + file.FullName.Replace(ImportList.SelectedPath, "").Replace(@"\", "/"));
                                        if (ImportList.SelectedPath.EndsWith("data"))
                                            checkedListBox1.Items.Add("system/data" + file.FullName.Replace(ImportList.SelectedPath, "").Replace(@"\", "/"));
                                        if (ImportList.SelectedPath.EndsWith("media"))
                                            checkedListBox1.Items.Add("system/media" + file.FullName.Replace(ImportList.SelectedPath, "").Replace(@"\", "/"));
                                        if (ImportList.SelectedPath.EndsWith("mobile_toolkit"))
                                            checkedListBox1.Items.Add("system/mobile_toolkit" + file.FullName.Replace(ImportList.SelectedPath, "").Replace(@"\", "/"));
                                        if (ImportList.SelectedPath.EndsWith("usr"))
                                            checkedListBox1.Items.Add("system/usr" + file.FullName.Replace(ImportList.SelectedPath, "").Replace(@"\", "/"));
                                        if (ImportList.SelectedPath.EndsWith("vendor"))
                                            checkedListBox1.Items.Add("system/vendor" + file.FullName.Replace(ImportList.SelectedPath, "").Replace(@"\", "/"));
                                        if (ImportList.SelectedPath.EndsWith("xbin"))
                                            checkedListBox1.Items.Add("system/xbin" + file.FullName.Replace(ImportList.SelectedPath, "").Replace(@"\", "/"));
                                    }
                                    else
                                        checkedListBox1.Items.Add("system" + file.FullName.Replace(ImportList.SelectedPath, "").Replace(@"\", "/"));
                                else
                                    if (ImportList.SelectedPath.EndsWith("system"))
                                    {
                                        checkedListBox1.Items.Add("system" + file.FullName.Replace(ImportList.SelectedPath, "").Replace(@"\", "/"));
                                    }
                                    else
                                    {
                                        if (ImportList.SelectedPath.EndsWith("app") || ImportList.SelectedPath.EndsWith("bin") || ImportList.SelectedPath.EndsWith("mobile_toolkit") || ImportList.SelectedPath.EndsWith("etc") || ImportList.SelectedPath.EndsWith("fonts") || ImportList.SelectedPath.EndsWith("framework") || ImportList.SelectedPath.EndsWith("lib") || ImportList.SelectedPath.EndsWith("data") || ImportList.SelectedPath.EndsWith("media") || ImportList.SelectedPath.EndsWith("usr") || ImportList.SelectedPath.EndsWith("vendor") || ImportList.SelectedPath.EndsWith("xbin"))
                                        {
                                            if (ImportList.SelectedPath.EndsWith("app"))
                                                checkedListBox1.Items.Add("system/app" + file.FullName.Replace(ImportList.SelectedPath, "").Replace(@"\", "/"));
                                            if (ImportList.SelectedPath.EndsWith("bin"))
                                                checkedListBox1.Items.Add("system/bin" + file.FullName.Replace(ImportList.SelectedPath, "").Replace(@"\", "/"));
                                            if (ImportList.SelectedPath.EndsWith("etc"))
                                                checkedListBox1.Items.Add("system/etc" + file.FullName.Replace(ImportList.SelectedPath, "").Replace(@"\", "/"));
                                            if (ImportList.SelectedPath.EndsWith("fonts"))
                                                checkedListBox1.Items.Add("system/fonts" + file.FullName.Replace(ImportList.SelectedPath, "").Replace(@"\", "/"));
                                            if (ImportList.SelectedPath.EndsWith("framework"))
                                                checkedListBox1.Items.Add("system/framework" + file.FullName.Replace(ImportList.SelectedPath, "").Replace(@"\", "/"));
                                            if (ImportList.SelectedPath.EndsWith("lib"))
                                                checkedListBox1.Items.Add("system/lib" + file.FullName.Replace(ImportList.SelectedPath, "").Replace(@"\", "/"));
                                            if (ImportList.SelectedPath.EndsWith("data"))
                                                checkedListBox1.Items.Add("system/data" + file.FullName.Replace(ImportList.SelectedPath, "").Replace(@"\", "/"));
                                            if (ImportList.SelectedPath.EndsWith("media"))
                                                checkedListBox1.Items.Add("system/media" + file.FullName.Replace(ImportList.SelectedPath, "").Replace(@"\", "/"));
                                            if (ImportList.SelectedPath.EndsWith("mobile_toolkit"))
                                                checkedListBox1.Items.Add("system/mobile_toolkit" + file.FullName.Replace(ImportList.SelectedPath, "").Replace(@"\", "/"));
                                            if (ImportList.SelectedPath.EndsWith("usr"))
                                                checkedListBox1.Items.Add("system/usr" + file.FullName.Replace(ImportList.SelectedPath, "").Replace(@"\", "/"));
                                            if (ImportList.SelectedPath.EndsWith("vendor"))
                                                checkedListBox1.Items.Add("system/vendor" + file.FullName.Replace(ImportList.SelectedPath, "").Replace(@"\", "/"));
                                            if (ImportList.SelectedPath.EndsWith("xbin"))
                                                checkedListBox1.Items.Add("system/xbin" + file.FullName.Replace(ImportList.SelectedPath, "").Replace(@"\", "/"));
                                        }
                                        else
                                            checkedListBox1.Items.Add(file.FullName.Replace(ImportList.SelectedPath + "\\", "").Replace(@"\", "/"));
                                    }
                        }
                    }
                    else
                        return;
                }

            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "System Image File |*system*.img";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Process win = new Process();
                    win.StartInfo.FileName = Directory.GetCurrentDirectory() + "//Bin//Ext4Extractor.exe";

                    if (Directory.Exists("Utilits\\Temp") == true)
                    {
                        Directory.Delete("Utilits\\Temp", true);
                    }

                    Directory.CreateDirectory("Utilits\\Temp");

                    win.StartInfo.Arguments = "\"" + openFileDialog1.FileName + "\"" + " \"Utilits\\Temp\\system\"";
                    win.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    win.StartInfo.ErrorDialog = false;
                    this.Cursor = Cursors.WaitCursor;
                    win.Start();
                    win.WaitForExit();
                    this.Cursor = Cursors.Default;

                }
                finally
                {
                    openFileDialog1.Filter = "Boot Image File |*boot*.img";
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        File.Copy(openFileDialog1.FileName, "Utilits\\Temp\\boot.img", true);
                    }
                }

                Message M = new Message("META-INF", null, null, next, null, null, null, 1, 0);
                M.SetDesktopLocation(this.Location.X + (this.Width / 2) - (M.Width / 2), this.Location.Y + (this.Height / 2) - (M.Height / 2));
                M.groupBox7.Visible = true;
                M.radioButton1.Text = mz;
                M.radioButton2.Text = mf;
                M.ShowDialog();

                if (M.radioButton1.Checked == true)
                {
                    if (openFileDialog2.ShowDialog() == DialogResult.OK)
                    {
                        string Patch0 = Directory.GetCurrentDirectory() + @"\Bin\trace.bat";
                        StreamWriter BatFile0 = new StreamWriter(Patch0, false, Encoding.GetEncoding(866));
                        BatFile0.WriteLine("@echo off");
                        BatFile0.WriteLine("cd /d " + Directory.GetCurrentDirectory() + @"\Bin");
                        BatFile0.WriteLine("7z.exe x " + "\"" + openFileDialog2.FileName.ToString() + "\" -o\"" + Directory.GetCurrentDirectory() + "\\Utilits\\Temp\" META-INF -r -y");
                        BatFile0.Close();

                        Process wing = new Process();
                        wing.StartInfo.CreateNoWindow = true;
                        wing.StartInfo.ErrorDialog = false;
                        wing.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        wing.StartInfo.FileName = @"Bin\trace.bat";
                        this.Cursor = Cursors.WaitCursor;
                        wing.Start();
                        wing.WaitForExit();
                        this.Cursor = Cursors.Default;
                        if (File.Exists(@"Bin\trace.bat"))
                            File.Delete(@"Bin\trace.bat");
                    }
                    else
                        return;
                }
                else
                {
                    folderBrowserDialog1.Description = choosem;
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        CopyDirectory(folderBrowserDialog1.SelectedPath, "Utilits/Temp");
                    }
                    else
                        return;
                }
                string tmp = DateTime.Now.ToString("dd.MM.yy_HH-mm-ss");
                if (Directory.Exists("Utilits/Temp"))
                    using (ZipFile zip = new ZipFile())
                    {
                        this.Cursor = Cursors.WaitCursor;
                        zip.AddDirectory("Utilits/Temp");
                        zip.Save("Utilits/FTtoZIP" + "_" + tmp + ".zip");
                        Directory.Delete("Utilits/Temp", true);
                        this.Cursor = Cursors.Default;
                    }
                else
                    return;

                SoundPlay();

                ProcessStartInfo startInfo = null;
                startInfo = new ProcessStartInfo("Explorer");
                startInfo.UseShellExecute = false;
                startInfo.Arguments = @"/select," + "\"Utilits\\FTtoZIP" + "_" + tmp + ".zip\"";
                Process.Start(startInfo);

            }
            else
                return;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("WorkDIR\\Temp.fat");
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                sw.WriteLine(checkedListBox1.Items[i]);
            }
            sw.Close();

            string R = null;
            if (File.Exists("WorkDIR\\Temp.fat") == true) R = "WorkDIR\\Temp.fat";
            else return;
            Editor Ed = new Editor(R);
            Ed.Owner = this;
            Ed.Show();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"Projects\\" + comboBox1.SelectedItem + ".fat") == true)
            {
                Process.Start(@"Explorer", @"/select," + "\"" + Directory.GetCurrentDirectory() + "\\Projects\\" + comboBox1.SelectedItem + ".fat\"");
            }
            else
                if (Directory.Exists(@"Projects") == true)
                    Process.Start(@"Projects");
                else
                    return;
        }

        private void button35_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.youtube.com/watch?v=aY0gnwONZbY");
        }

    #endregion

    #region ToolStrip

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int lastIndex = checkedListBox1.Items.Count - 1;
            for (int i = lastIndex; i >= 0; i--)
                checkedListBox1.Items.RemoveAt(i);
            checkBox1.Text = sa;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProjectEditRM();
        }

    #endregion

    #region CheckBoxes

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox1.Text = us;
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    checkedListBox1.SetItemChecked(i, true);
            }
            if (checkBox1.Checked == false)
            {
                checkBox1.Text = sa;
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = true;
            }
            else
            {
                comboBox2.Enabled = true;
                textBox2.Enabled = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                textBox3.Visible = true;
                textBox3.Text = comboBox1.SelectedItem + "_" + DateTime.Now.ToString("dd.MM.yy_HH-mm-ss");
            }
            else
                textBox3.Visible = false;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                groupBox3.Visible = false;
                groupBox4.Top = 144;
                groupBox5.Top = 298;
            }
            else
            {
                groupBox3.Visible = true;
                groupBox4.Top = 275;
                groupBox5.Top = 402;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == false)
                checkBox4.Checked = true;
            else
                checkBox4.Checked = false;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == false)
                checkBox3.Checked = true;
            else
                checkBox3.Checked = false;
        }

    #endregion

    #region TextBoxes

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите название папки или файла с расширением" || textBox1.Text == text1 || textBox1.Text == null) ;
            else
            {
                if (s == 0) S = comboBox2.SelectedItem.ToString() + "/" + comboBox3.SelectedItem.ToString();
                button4.Enabled = true;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == text1 || textBox1.Text == null) ; else S += "/" + textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите путь включая нужный файл или папку" || textBox1.Text == text2 || textBox1.Text == null) ;
            else
            {
                button4.Enabled = true;
            }
        }

    #endregion

    #region ComboBoxes

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int lastIndex = checkedListBox1.Items.Count - 1;
            for (int i = lastIndex; i >= 0; i--)
            {
                checkedListBox1.Items.RemoveAt(i);
            }

            if (comboBox1.SelectedItem.ToString() != nw)
            {
                if (File.Exists("Projects//" + comboBox1.SelectedItem + ".fat"))
                {
                    StreamReader SR = new StreamReader("Projects//" + comboBox1.SelectedItem + ".fat");
                    while (SR.EndOfStream == false)
                    {
                        checkedListBox1.Items.Add(SR.ReadLine());
                    }
                    SR.Close();
                }
            }

            label1.Text = "Project: " + Convert.ToString(comboBox1.SelectedItem);

            IniFile loc = new IniFile(Directory.GetCurrentDirectory() + "/Bin/config.ini");
            loc.IniWriteValue("Others", "last", Convert.ToString(comboBox1.SelectedItem));
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            s = 1;
            int n = comboBox2.SelectedIndex;
            S = comboBox2.SelectedItem.ToString();
            button4.Enabled = true;
            if (textBox1.Text == "Введите название папки или файла с расширением" || textBox1.Text == "Input folder or file name with expansion") ; else textBox1.Text = null;
            if (n == 0)
            {
                comboBox3.Enabled = true;
                textBox1.Enabled = false;
            }
            else
            {
                comboBox3.Enabled = false;
                textBox1.Enabled = false;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            button4.Enabled = true;
            int n = comboBox3.SelectedIndex;
            if (s == 0) S = comboBox2.SelectedItem.ToString();
            s = 1;
            S += "/" + comboBox3.SelectedItem.ToString();
            if (textBox1.Text == text1) ; else textBox1.Text = null;
            if (n == 11)
            {
                textBox1.Enabled = false;
            }
            else
            {
                textBox1.Enabled = true;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == 0 || comboBox4.SelectedIndex == 2)
            {
                checkBox3.Enabled = true;
                checkBox3.Checked = true;
            }
            else
            {
                checkBox3.Enabled = false;
                checkBox3.Checked = false;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex == 0 || comboBox5.SelectedIndex == 2)
                checkBox4.Enabled = true;
            else
                checkBox4.Enabled = false;
        }

    #endregion

    #region DragAndDrop

        private void checkedListBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void checkedListBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (checkBox8.Checked)
            {
                int lastIndex = checkedListBox1.Items.Count - 1;
                for (int i = lastIndex; i >= 0; i--)
                    checkedListBox1.Items.RemoveAt(i);
                checkBox1.Text = sa;
            }

            string[] s = (string[]) e.Data.GetData(DataFormats.FileDrop, false);
	        int f;
            for (f = 0; f < s.Length; f++)
            {
                if (Directory.Exists(s[f]))
                {
                    var dir = new DirectoryInfo(s[f]);
                    foreach (FileInfo file in dir.GetFiles("*", SearchOption.AllDirectories))
                    {
                        if (file.FullName.IndexOf("system") < 1)
                            if (s[f].EndsWith("app")||s[f].EndsWith("bin")|| s[f].EndsWith("mobile_toolkit") || s[f].EndsWith("etc")||s[f].EndsWith("fonts")||s[f].EndsWith("framework")||s[f].EndsWith("lib")||s[f].EndsWith("data")||s[f].EndsWith("media")||s[f].EndsWith("usr")||s[f].EndsWith("vendor")||s[f].EndsWith("xbin"))
                            {
                                if (s[f].EndsWith("app"))
                                    checkedListBox1.Items.Add("system/app" + file.FullName.Replace(s[f], "").Replace(@"\", "/"));
                                if (s[f].EndsWith("bin"))
                                    checkedListBox1.Items.Add("system/bin" + file.FullName.Replace(s[f], "").Replace(@"\", "/"));
                                if (s[f].EndsWith("etc"))
                                    checkedListBox1.Items.Add("system/etc" + file.FullName.Replace(s[f], "").Replace(@"\", "/"));
                                if (s[f].EndsWith("fonts"))
                                    checkedListBox1.Items.Add("system/fonts" + file.FullName.Replace(s[f], "").Replace(@"\", "/"));
                                if (s[f].EndsWith("framework"))
                                    checkedListBox1.Items.Add("system/framework" + file.FullName.Replace(s[f], "").Replace(@"\", "/"));
                                if (s[f].EndsWith("lib"))
                                    checkedListBox1.Items.Add("system/lib" + file.FullName.Replace(s[f], "").Replace(@"\", "/"));
                                if (s[f].EndsWith("data"))
                                    checkedListBox1.Items.Add("system/data" + file.FullName.Replace(s[f], "").Replace(@"\", "/"));
                                if (s[f].EndsWith("media"))
                                    checkedListBox1.Items.Add("system/media" + file.FullName.Replace(s[f], "").Replace(@"\", "/"));
                                if (s[f].EndsWith("mobile_toolkit"))
                                    checkedListBox1.Items.Add("system/mobile_toolkit" + file.FullName.Replace(s[f], "").Replace(@"\", "/"));
                                if (s[f].EndsWith("usr"))
                                    checkedListBox1.Items.Add("system/usr" + file.FullName.Replace(s[f], "").Replace(@"\", "/"));
                                if (s[f].EndsWith("vendor"))
                                    checkedListBox1.Items.Add("system/vendor" + file.FullName.Replace(s[f], "").Replace(@"\", "/"));
                                if (s[f].EndsWith("xbin"))
                                    checkedListBox1.Items.Add("system/xbin" + file.FullName.Replace(s[f], "").Replace(@"\", "/"));
                            }
                            else
                                checkedListBox1.Items.Add("system" + file.FullName.Replace(s[f], "").Replace(@"\", "/"));
                        else
                            if (s[f].EndsWith("system"))
                                checkedListBox1.Items.Add("system" + file.FullName.Replace(s[f], "").Replace(@"\", "/"));
                            else
                                if (s[f].EndsWith("app") || s[f].EndsWith("bin") || s[f].EndsWith("etc")|| s[f].EndsWith("mobile_toolkit") || s[f].EndsWith("fonts") || s[f].EndsWith("framework") || s[f].EndsWith("lib") || s[f].EndsWith("data") || s[f].EndsWith("media") || s[f].EndsWith("usr") || s[f].EndsWith("vendor") || s[f].EndsWith("xbin"))
                                {
                                    if (s[f].EndsWith("app"))
                                        checkedListBox1.Items.Add("system/app" + file.FullName.Replace(s[f], "").Replace(@"\", "/"));
                                    if (s[f].EndsWith("bin"))
                                        checkedListBox1.Items.Add("system/bin" + file.FullName.Replace(s[f], "").Replace(@"\", "/"));
                                    if (s[f].EndsWith("etc"))
                                        checkedListBox1.Items.Add("system/etc" + file.FullName.Replace(s[f], "").Replace(@"\", "/"));
                                    if (s[f].EndsWith("fonts"))
                                        checkedListBox1.Items.Add("system/fonts" + file.FullName.Replace(s[f], "").Replace(@"\", "/"));
                                    if (s[f].EndsWith("framework"))
                                        checkedListBox1.Items.Add("system/framework" + file.FullName.Replace(s[f], "").Replace(@"\", "/"));
                                    if (s[f].EndsWith("lib"))
                                        checkedListBox1.Items.Add("system/lib" + file.FullName.Replace(s[f], "").Replace(@"\", "/"));
                                    if (s[f].EndsWith("data"))
                                        checkedListBox1.Items.Add("system/data" + file.FullName.Replace(s[f], "").Replace(@"\", "/"));
                                    if (s[f].EndsWith("media"))
                                        checkedListBox1.Items.Add("system/media" + file.FullName.Replace(s[f], "").Replace(@"\", "/"));
                                    if (s[f].EndsWith("mobile_toolkit"))
                                        checkedListBox1.Items.Add("system/mobile_toolkit" + file.FullName.Replace(s[f], "").Replace(@"\", "/"));
                                    if (s[f].EndsWith("usr"))
                                        checkedListBox1.Items.Add("system/usr" + file.FullName.Replace(s[f], "").Replace(@"\", "/"));
                                    if (s[f].EndsWith("vendor"))
                                        checkedListBox1.Items.Add("system/vendor" + file.FullName.Replace(s[f], "").Replace(@"\", "/"));
                                    if (s[f].EndsWith("xbin"))
                                        checkedListBox1.Items.Add("system/xbin" + file.FullName.Replace(s[f], "").Replace(@"\", "/"));
                                }
                                else
                                    checkedListBox1.Items.Add(file.FullName.Replace(s[f] + "\\", "").Replace(@"\", "/"));
                    }
                }
                else
                {
                    if (s[f].IndexOf(".zip") < 0)
                    {
                        var file = new FileInfo(s[f]);
                        checkedListBox1.Items.Add(file.Name);
                    }
                    else
                        try
                        {
                            using (ZipFile zipFile = new ZipFile(s[f]))
                            {
                                ICollection<ZipEntry> files = zipFile.Entries;
                                foreach (ZipEntry entry in files)
                                    if (!entry.IsDirectory)
                                        if (entry.FileName.IndexOf("META-INF") < 0)
                                            checkedListBox1.Items.Add(entry.FileName);
                            }
                        }
                        catch (Exception)
                        {
                            return;
                        }
                }
            }
        }

    #endregion

    }
}
