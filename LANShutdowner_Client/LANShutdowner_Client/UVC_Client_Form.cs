using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Net.Sockets;

namespace LANShutdowner_Client
{
    public partial class LANShutdowner_Client_Form : Form
    {
        private const string SettingsFileName = @"Settings.xml";

        private List<Group> GroupsList;
        private int Port = 4478;
        private bool RunAtStartup = false;
        private bool ScanOnStartup = false;
        private bool AutoScan = false;
        private int AutoScanTime = 0;

        //string serverName;
        ListViewGroup listviewgroups1;
        ListViewGroup listviewgroups2;
        ListViewGroup listviewgroups3;
        ListViewGroup listviewgroups4;
        ListViewGroup listviewgroups5;
        ArrayList IPList = new ArrayList(); // общий список ПК ответивших на запрос
        ArrayList ShudownIPList = new ArrayList(); //список ПК которые можно вкл./выкл.

        public LANShutdowner_Client_Form()
        {
            InitializeComponent();
            //WindowState = FormWindowState.Minimized;
            groupBox_restart.Controls.Add(radioButton_softreset);
            groupBox_restart.Controls.Add(radioButton_hardreset);
            groupBox_shutdown.Controls.Add(radioButton_softoff);
            groupBox_shutdown.Controls.Add(radioButton_hardoff);

            notifyIcon1.ShowBalloonTip(3, "", "LANShutdowner Viewer запущен", ToolTipIcon.None);

            LoadSettings();

            if(AutoScan)
            {
                int time = AutoScanTime * 1000;
                timer_AutoScan.Interval = time;
                timer_AutoScan.Start();
            }

            if(ScanOnStartup)
            {
                CreateListView();
                shearchip();
            }

            if (Settings_Viewer.Default.Setting_CheckBox_AutoScan)
            {
                int time=Settings_Viewer.Default.Setting_TimeAutoScan*1000;
                timer_AutoScan.Interval = time;
                timer_AutoScan.Start();
            }

            if (Settings_Viewer.Default.Setting_CheckBox_ScanAppStart)
            {
                CreateListView();
                shearchip();
            }
        }

        // ------------------------------------------------------------------------------------------------
        /// <summary>
        ///  Загрузка настроек
        /// </summary>
        void LoadSettings()
        {
            // загружаем данные из файла xml
            if (File.Exists(SettingsFileName))
            {
                using (Stream stream = new FileStream(SettingsFileName, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Settings));

                    Settings SettingsXML = (Settings)serializer.Deserialize(stream);

                    this.Port = SettingsXML.Port;
                    this.RunAtStartup = SettingsXML.RunAtStartup;
                    this.ScanOnStartup = SettingsXML.AutoScan;
                    this.AutoScan = SettingsXML.AutoScan;
                    this.AutoScanTime = SettingsXML.AutoScanTime;

                    GroupsList = new List<Group>();

                    foreach (Group group in SettingsXML.Groups)
                    {
                        GroupsList.Add(group);
                    }
                }
            }
        }
        void SaveSettings()
        {
            // передаем в конструктор тип класса
            XmlSerializer Serializer = new XmlSerializer(typeof(Settings));

            Settings SettingsXML = new Settings();

            SettingsXML.Port = this.Port;
            SettingsXML.RunAtStartup = this.RunAtStartup;
            SettingsXML.ScanOnStartup = this.ScanOnStartup;
            SettingsXML.AutoScan = this.AutoScan;
            SettingsXML.AutoScanTime = this.AutoScanTime;

            foreach (Group group in GroupsList)
            {
                SettingsXML.Groups = new List<Group>();
                SettingsXML.Groups.Add(group);
            }

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(SettingsFileName, FileMode.Create))
            {
                Serializer.Serialize(fs, SettingsXML);
            }
        }
        // ------------------------------------------------------------------------------------------------

        #region соединение для выключения
        private void connectionToServer(string command, string serverName)
        {
            const int bufferSize = 1024;
            byte[] requestServer = new byte[bufferSize]; // запрос серверу
            byte[] answerServer = new byte[bufferSize];  // ответ сервера
            Cursor currentCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            //serverName = UVC_Client.Settings_UVC_Viewer.Default.Setting_IPAdress;
            int port = LANShutdowner_Client.Settings_Viewer.Default.Setting_port;

            TcpClient client = new TcpClient();
            NetworkStream stream = null;
            try
            {
                client.Connect(serverName, port);
                stream = client.GetStream();
                // делаем запрос серверу
                requestServer = Encoding.Unicode.GetBytes(command); //переводим строку в байты
                stream.Write(requestServer, 0, requestServer.Length); // пишем массив с командой в соединение
                // получаем ответ сервера  
                int received = stream.Read(answerServer, 0, bufferSize);
                if (received <= 0)
                    return;

                string ansCommand = Encoding.Unicode.GetString(answerServer).Trim('\0');
                MessageBox.Show("Text: " + ansCommand);
            }
            catch (SocketException)
            { }
            finally
            {
                if (stream != null)
                    stream.Close();

                if (client.Connected)
                    client.Close();
            }
            this.Cursor = currentCursor;

        }
        //===================================================================


        private void button_restart_Click(object sender, EventArgs e)
        {
            if (radioButton_softreset.Checked)
                foreach (string serverName in ShudownIPList)
                {
                    connectionToServer("soft_reset", serverName);
                }
            if (radioButton_hardreset.Checked)
                foreach (string serverName in ShudownIPList)
                {
                    connectionToServer("hard_reset", serverName);
                }
        }

        private void button_shutdown_Click(object sender, EventArgs e)
        {
            if (radioButton_softoff.Checked)
                foreach (string serverName in ShudownIPList)
                {
                    connectionToServer("soft_off", serverName); 
                }
               
            if (radioButton_hardoff.Checked)
                foreach (string serverName in ShudownIPList)
                {
                    connectionToServer("hard_off", serverName);
                }
        }

#endregion
        //=======================================================================
#region // создаем список
        void CreateListView()
        {
            // создаём группу
            listviewgroups1 = new ListViewGroup(LANShutdowner_Client.Settings_Viewer.Default.Setting_group_name1, HorizontalAlignment.Left);
            listviewgroups1.Header = LANShutdowner_Client.Settings_Viewer.Default.Setting_group_name1;
            listviewgroups1.Name = "group_name1";
            listviewgroups2 = new ListViewGroup(LANShutdowner_Client.Settings_Viewer.Default.Setting_group_name2, HorizontalAlignment.Left);
            listviewgroups2.Header = LANShutdowner_Client.Settings_Viewer.Default.Setting_group_name2;
            listviewgroups2.Name = "group_name2";
            listviewgroups3 = new ListViewGroup(LANShutdowner_Client.Settings_Viewer.Default.Setting_group_name3, HorizontalAlignment.Left);
            listviewgroups3.Header = LANShutdowner_Client.Settings_Viewer.Default.Setting_group_name3;
            listviewgroups3.Name = "group_name3";
            listviewgroups4 = new ListViewGroup(LANShutdowner_Client.Settings_Viewer.Default.Setting_group_name4, HorizontalAlignment.Left);
            listviewgroups4.Header = LANShutdowner_Client.Settings_Viewer.Default.Setting_group_name4;
            listviewgroups4.Name = "group_name4";
            listviewgroups5 = new ListViewGroup(LANShutdowner_Client.Settings_Viewer.Default.Setting_group_name5, HorizontalAlignment.Left);
            listviewgroups4.Header = LANShutdowner_Client.Settings_Viewer.Default.Setting_group_name5;
            listviewgroups4.Name = "group_name5";
            // добавляем группы
            listView1.Groups.Add(listviewgroups1);
            listView1.Groups.Add(listviewgroups2);
            listView1.Groups.Add(listviewgroups3);
            listView1.Groups.Add(listviewgroups4);
            listView1.Groups.Add(listviewgroups5);
        }

        public void ListView_ItemAdd(string dnsname, string ip, string username)
        {
            // создаём элемент
            ListViewItem listviewitem1 = new ListViewItem();
            // параметры элемента
            listviewitem1.Name = "listitem_name1";
            listviewitem1.Text = dnsname;
            // добавляем элемент в группу ?
            switch (СompareInRange(ip))
            {
                case 1: listviewitem1.Group = listviewgroups1; break;
                case 2: listviewitem1.Group = listviewgroups2; break;
                case 3: listviewitem1.Group = listviewgroups3; break;
                case 4: listviewitem1.Group = listviewgroups4; break;
                case 5: listviewitem1.Group = listviewgroups5; break;
                default: break;
            }

            // создаём подэлемент
            ListViewItem.ListViewSubItem lvsubitem1 = new ListViewItem.ListViewSubItem(listviewitem1, ip);
            listviewitem1.SubItems.Add(lvsubitem1);
            ListViewItem.ListViewSubItem lvsubitem2 = new ListViewItem.ListViewSubItem(listviewitem1, username);
            listviewitem1.SubItems.Add(lvsubitem2);
            //ListViewItem.ListViewSubItem lvsubitem3 = new ListViewItem.ListViewSubItem(listviewitem1, username);
            //listviewitem1.SubItems.Add(lvsubitem3);

            // добавляем элемент в список
            listView1.Items.Add(listviewitem1);
            IPListAddItem(ip);
        }


        #region // в какой диапазон входит ip

        int СompareInRange(string CompareValue)
        {   // входит ли ip в диапазон
            ulong BeginOfRange = 0;
            ulong EndOfRange = 0;
            ulong value = 0;

            value = Convert.ToUInt64(CompareValue.Replace(".", ""));
            // 1-я группа
            BeginOfRange = Convert.ToUInt64(LANShutdowner_Client.Settings_Viewer.Default.Setting_gr1_ipbegin.Replace(".", ""));

            EndOfRange = Convert.ToUInt64(LANShutdowner_Client.Settings_Viewer.Default.Setting_gr1_ipend.Replace(".", ""));
            if ((BeginOfRange <= value) && (value <= EndOfRange))
            {
                return 1;
            }
            else
                // 2-я группа
                BeginOfRange = Convert.ToUInt64(LANShutdowner_Client.Settings_Viewer.Default.Setting_gr2_ipbegin.Replace(".", ""));
            EndOfRange = Convert.ToUInt64(LANShutdowner_Client.Settings_Viewer.Default.Setting_gr2_ipend.Replace(".", ""));
            if ((BeginOfRange <= value) && (value <= EndOfRange))
            {
                return 2;
            }
            else
                // 3-я группа
                BeginOfRange = Convert.ToUInt64(LANShutdowner_Client.Settings_Viewer.Default.Setting_gr3_ipbegin.Replace(".", ""));
            EndOfRange = Convert.ToUInt64(LANShutdowner_Client.Settings_Viewer.Default.Setting_gr3_ipend.Replace(".", ""));
            if ((BeginOfRange <= value) && (value <= EndOfRange))
            {
                return 3;
            }
            else
                // 4-я группа
                BeginOfRange = Convert.ToUInt64(LANShutdowner_Client.Settings_Viewer.Default.Setting_gr4_ipbegin.Replace(".", ""));
            EndOfRange = Convert.ToUInt64(LANShutdowner_Client.Settings_Viewer.Default.Setting_gr4_ipend.Replace(".", ""));
            if ((BeginOfRange <= value) && (value <= EndOfRange))
            {
                return 4;
            }
            else
                // 5-я группа
                BeginOfRange = Convert.ToUInt64(LANShutdowner_Client.Settings_Viewer.Default.Setting_gr5_ipbegin.Replace(".", ""));
            EndOfRange = Convert.ToUInt64(LANShutdowner_Client.Settings_Viewer.Default.Setting_gr5_ipend.Replace(".", ""));
            if ((BeginOfRange <= value) && (value <= EndOfRange))
            {
                return 5;
            }
            // не входит ни в один диапазон
            return 0;
        }
        #endregion

        // добавляем в список ip компа который ответил
        void IPListAddItem(string str)
        {
            IPList.Add(str);
        }



 #endregion

        //=========================================================================================================
#region  // здесь будем опрашивать компы, для создания списка
        int strCount(string str)
        {
            int count = 0;
            int eof = str.Length;
            for (int i = 0; i < eof; i++)
            {
                if (i < str.IndexOf("; ", i))
                {
                    i = str.IndexOf("; ", i);
                    count++;
                }
            }
            return count;
        }


        private void shearchip()
        {
           string[] ar ={"; ", ";"};
           string[] iparray = Settings_Viewer.Default.Setting_ip_list.Split( ar, StringSplitOptions.RemoveEmptyEntries);
           int count = strCount(Settings_Viewer.Default.Setting_ip_list);
            string ip = null;
            for (int i = 0; i < count; i++)
            {
                ip = iparray[i];
                LoadServerList(ip);
            }
        }

        //--------------------------------------
        private static string getDNSNameInString(string str)
        {   // получаем dns-имя из общей строки
            int index = str.IndexOf("|");
            string str2 = str.Substring(0, index);
            return str2;
        }

        private static string getIPInString(string str)
        {   // получаем ip-адрес из общей строки
            int index = str.IndexOf("|");
            string str1 = str.Substring(index + 1);
            int index2 = str1.IndexOf("|");
            string str2 = str1.Substring(0, index2);
            return str2;
        }

        private static string getUserNameInString(string str)
        {  // получаем имя пользователя из общей строки
            int index = str.IndexOf("|");
            string str1 = str.Substring(index + 1);
            int index2 = str1.IndexOf("|");
            string str3 = str1.Substring(index2 + 1);
            int index3 = str3.IndexOf("|");
            string str2 = str3.Substring(0, index3);
            return str2;
        }

        private static string getMACInString(string str)
        {  // получаем MAC-адрес из общей строки
            int index = str.LastIndexOf("|");
            string str2 = str.Substring(index + 1);
            return str2;
        }

        private void LoadServerList(string serverName)
        {
            const int bufferSize = 2048;
            byte[] requestServer = new byte[bufferSize]; // запрос серверу
            byte[] answerServer = new byte[bufferSize];  // ответ сервера

            string command = "getInfo";
            int port = LANShutdowner_Client.Settings_Viewer.Default.Setting_port;

            TcpClient client = new TcpClient(AddressFamily.InterNetwork);
            NetworkStream stream = null;
            try
            {
                client.Connect(serverName, port);
                stream = client.GetStream();
                // делаем запрос серверу
                requestServer = Encoding.Unicode.GetBytes(command); //переводим строку в байты
                stream.Write(requestServer, 0, requestServer.Length); // пишем массив с командой в соединение
                // получаем ответ сервера  
                int received = stream.Read(answerServer, 0, bufferSize);
                if (received <= 0)
                    return;

                string ansCommand = Encoding.Unicode.GetString(answerServer).Trim('\0');

                string DNSname = getDNSNameInString(ansCommand);
                string ip_adress = getIPInString(ansCommand);
                string username = getUserNameInString(ansCommand);
                string mac = getMACInString(ansCommand);
                MessageBox.Show("MessageBox: \n" + DNSname + "  " + ip_adress + "   " + username+"    "+ mac);
                if (serverName == ip_adress)
                {
                    ListView_ItemAdd(DNSname, ip_adress, username);
                   // MessageBox.Show("MessageBox: \n" + DNSname + "  " + ip_adress + "   " + username);
                }

            }
            catch (SocketException e)
            {
                MessageBox.Show("error: \n"+e.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Close();

                if (client.Connected)
                    client.Close();
            }

        }
#endregion

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked)
                ShudownIPList.Add(IPList[e.Item.Index]);
            
                if (!e.Item.Checked && !(ShudownIPList.Count==0))
                    ShudownIPList.Remove(IPList[e.Item.Index]);
        }

        private void Exit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Settings_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsDialog_Form settform = new SettingsDialog_Form();
            settform.Show();
        }


        private void button_restart_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Перезагрузка отмеченных ПК из списка.", this.button_restart);
        }

        private void button_restart_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(this.button_restart);
        }

        private void button_shutdown_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Выключение отмеченных ПК из списка.", this.button_shutdown);
        }

        private void button_shutdown_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(this.button_shutdown);
        }

        private void button_Scan_Click(object sender, EventArgs e)
        {
            if (!(listView1.Items.Count == 0))
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    listView1.Items.RemoveAt(i);
                }

                IPList.Clear();
                ShudownIPList.Clear();
            }
            CreateListView();
            shearchip();
        }

        private void timer_AutoScan_Tick(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;
        }

        private void contextMenuStrip_tray_Opening(object sender, CancelEventArgs e)
        {
            if ( WindowState == FormWindowState.Normal)
                Open_UVCViewerToolStripMenuItem.Text = "Скрыть LANShutdowner Viewer";
            else if( WindowState == FormWindowState.Minimized)
                Open_UVCViewerToolStripMenuItem.Text = "Открыть LANShutdowner Viewer";
              
        }

        private void Open_UVCViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;
            else
                if (WindowState == FormWindowState.Normal)
                    WindowState = FormWindowState.Minimized;

        }

        private void About_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();
        }

       
    }
}

/* команды сервера
 * *************
 * getInfo
 * **********
 * soft_reset
 * hard_reset
 * soft_off
 * hard_off
 * ********
 * Win_Lock
*/
