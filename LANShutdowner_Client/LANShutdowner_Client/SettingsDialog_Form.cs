using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace LANShutdowner_Client
{
    public partial class SettingsDialog_Form : Form
    {
        private const string SettingsFileName = @"Settings.xml";

        private List<Group> GroupsList;
        private int Port = 4478;
        private bool RunAtStartup = false;
        private bool ScanOnStartup = false;
        private bool AutoScan = false;
        private int AutoScanTime = 0;

        public SettingsDialog_Form()
        {
            InitializeComponent();

            tabControl1.SelectedIndex = 1;

            this.dataGridView1.RowHeadersDefaultCellStyle.Padding =
                    new Padding(this.dataGridView1.RowHeadersWidth);
            dataGridView1.RowPostPaint +=
                new DataGridViewRowPostPaintEventHandler(dataGridView1_RowPostPaint);

            DataGridViewRow dataGridRow1 = new DataGridViewRow();
            dataGridRow1.HeaderCell.Value = "Название";
            DataGridViewCell firstCell1 = new DataGridViewTextBoxCell();
            firstCell1.Value = "Название";
            //DataGridViewCell firstCell2 = new DataGridViewTextBoxCell();
            //firstCell1.Value = "Общая";
            dataGridRow1.Cells.Add(firstCell1);
            //dataGridRow1.Cells.Add(firstCell2);
            dataGridView1.Rows.Add(dataGridRow1);
            //firstCell1.ReadOnly = true;

            DataGridViewRow dataGridRow2 = new DataGridViewRow();
            dataGridRow2.HeaderCell.Value = "Список IP-адресов";
            DataGridViewCell firstCell3 = new DataGridViewTextBoxCell();
            firstCell3.Value = "Список IP-адресов";
            //DataGridViewCell firstCell4 = new DataGridViewTextBoxCell();
            //firstCell2.Value = "127.0.0.1";
            dataGridRow2.Height = 100;
            dataGridRow2.Cells.Add(firstCell3);
            //dataGridRow2.Cells.Add(firstCell4);
            dataGridView1.Rows.Add(dataGridRow2);
            //firstCell3.ReadOnly = true;

            LoadSettings();

            textBox_port.Text = this.Port.ToString();
            checkBox_AutoStart.Checked = this.RunAtStartup;
            checkBox_ScanInStart.Checked = this.ScanOnStartup;
            checkBox_AutoScan.Checked = this.AutoScan;
            textBox_TimeAutoScan.Text = AutoScanTime.ToString();


            foreach(Group group in GroupsList)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Name = "group_" + listView1.Items.Count;
                listViewItem.Text = (listView1.Items.Count + 1).ToString();
                listViewItem.SubItems.AddRange(new string[] { group.Name, "0" });
                listView1.Items.Add(listViewItem); // принимаем результат с 2ой формы в текстбокс1
            }

        }

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

            SettingsXML.Groups = new List<Group>();
            foreach (Group group in GroupsList)
            {
                SettingsXML.Groups.Add(group);
            }

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(SettingsFileName, FileMode.Create))
            {
                Serializer.Serialize(fs, SettingsXML);
            }
        }
        // ------------------------------------------------------------------------------------------------


        void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            object o = dataGridView1.Rows[e.RowIndex].HeaderCell.Value;

            e.Graphics.DrawString(
                o != null ? o.ToString() : "",
                dataGridView1.Font,
                new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor),
                new PointF((float)e.RowBounds.Left + 2, (float)e.RowBounds.Top + 4));
        }

        private void button_SaveSettings_Click(object sender, EventArgs e)
        {
            if( !this.RunAtStartup )
            {
                RegistryKey key_run = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run",true);
                key_run.DeleteValue("LANShutdowner_Viewer", false);
            }
            else if ( this.RunAtStartup )
            {
                RegistryKey key_run=null;
                key_run = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                key_run.SetValue("LANShutdowner_Viewer", Application.ExecutablePath, RegistryValueKind.String);
                key_run.Close();                
            }

            if (checkBox_AutoScan.Checked && (textBox_TimeAutoScan.Text.Length == 0))
            {
                MessageBox.Show("Включено автосканирование, но не введено время интервала сканирования!");
            }
            else
            {
                SaveSettings();
                Close();
            }
        }

        private void button_GroupAdd_Click(object sender, EventArgs e)
        {
            GroupNameInput nameDlg = new GroupNameInput();
            nameDlg.ShowDialog();
            if (nameDlg.DialogResult == DialogResult.OK)
            {
                string Name = nameDlg.ReturnData();
                GroupsList.Add(new Group(Name));
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Name = "group_" + listView1.Items.Count;
                listViewItem.Text = (listView1.Items.Count+1).ToString();
                listViewItem.SubItems.AddRange(new string[] { Name, "0" });
                listView1.Items.Add(listViewItem); // принимаем результат с 2ой формы в текстбокс1
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_GroupDel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить элемент?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dialogResult == DialogResult.Yes)
            {
                GroupsList.RemoveAt(listView1.SelectedIndices[0]);
                listView1.SelectedIndices.Remove(listView1.SelectedIndices[0]);
            }
        }
    }
}
