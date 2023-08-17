namespace LANShutdowner_Client
{
    partial class LANShutdowner_Client_Form
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LANShutdowner_Client_Form));
            this.button_restart = new System.Windows.Forms.Button();
            this.button_shutdown = new System.Windows.Forms.Button();
            this.groupBox_restart = new System.Windows.Forms.GroupBox();
            this.radioButton_hardreset = new System.Windows.Forms.RadioButton();
            this.radioButton_softreset = new System.Windows.Forms.RadioButton();
            this.groupBox_shutdown = new System.Windows.Forms.GroupBox();
            this.radioButton_hardoff = new System.Windows.Forms.RadioButton();
            this.radioButton_softoff = new System.Windows.Forms.RadioButton();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader_dnsname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_ipadress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_username = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.File_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Restart_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Shutdown_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Service_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Settings_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Help_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpView_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.About_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Scan = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer_AutoScan = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip_tray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Open_UVCViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnHeader_check = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_state = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox_restart.SuspendLayout();
            this.groupBox_shutdown.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip_tray.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_restart
            // 
            this.button_restart.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_restart.Location = new System.Drawing.Point(22, 79);
            this.button_restart.Name = "button_restart";
            this.button_restart.Size = new System.Drawing.Size(96, 23);
            this.button_restart.TabIndex = 0;
            this.button_restart.Text = "Перезагрузка";
            this.button_restart.UseVisualStyleBackColor = true;
            this.button_restart.Click += new System.EventHandler(this.button_restart_Click);
            this.button_restart.MouseLeave += new System.EventHandler(this.button_restart_MouseLeave);
            this.button_restart.MouseHover += new System.EventHandler(this.button_restart_MouseHover);
            // 
            // button_shutdown
            // 
            this.button_shutdown.Location = new System.Drawing.Point(145, 79);
            this.button_shutdown.Name = "button_shutdown";
            this.button_shutdown.Size = new System.Drawing.Size(96, 23);
            this.button_shutdown.TabIndex = 1;
            this.button_shutdown.Text = "Выключение";
            this.button_shutdown.UseVisualStyleBackColor = true;
            this.button_shutdown.Click += new System.EventHandler(this.button_shutdown_Click);
            this.button_shutdown.MouseLeave += new System.EventHandler(this.button_shutdown_MouseLeave);
            this.button_shutdown.MouseHover += new System.EventHandler(this.button_shutdown_MouseHover);
            // 
            // groupBox_restart
            // 
            this.groupBox_restart.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox_restart.Controls.Add(this.radioButton_hardreset);
            this.groupBox_restart.Controls.Add(this.radioButton_softreset);
            this.groupBox_restart.Location = new System.Drawing.Point(22, 12);
            this.groupBox_restart.Name = "groupBox_restart";
            this.groupBox_restart.Size = new System.Drawing.Size(96, 57);
            this.groupBox_restart.TabIndex = 2;
            this.groupBox_restart.TabStop = false;
            this.groupBox_restart.Text = "Перезагрузка";
            // 
            // radioButton_hardreset
            // 
            this.radioButton_hardreset.AutoSize = true;
            this.radioButton_hardreset.Location = new System.Drawing.Point(11, 35);
            this.radioButton_hardreset.Name = "radioButton_hardreset";
            this.radioButton_hardreset.Size = new System.Drawing.Size(68, 17);
            this.radioButton_hardreset.TabIndex = 1;
            this.radioButton_hardreset.Text = "жёсткая";
            this.radioButton_hardreset.UseVisualStyleBackColor = true;
            // 
            // radioButton_softreset
            // 
            this.radioButton_softreset.AutoSize = true;
            this.radioButton_softreset.Checked = true;
            this.radioButton_softreset.Location = new System.Drawing.Point(11, 15);
            this.radioButton_softreset.Name = "radioButton_softreset";
            this.radioButton_softreset.Size = new System.Drawing.Size(62, 17);
            this.radioButton_softreset.TabIndex = 0;
            this.radioButton_softreset.TabStop = true;
            this.radioButton_softreset.Text = "мягкая";
            this.radioButton_softreset.UseVisualStyleBackColor = true;
            // 
            // groupBox_shutdown
            // 
            this.groupBox_shutdown.Controls.Add(this.radioButton_hardoff);
            this.groupBox_shutdown.Controls.Add(this.radioButton_softoff);
            this.groupBox_shutdown.Location = new System.Drawing.Point(145, 12);
            this.groupBox_shutdown.Name = "groupBox_shutdown";
            this.groupBox_shutdown.Size = new System.Drawing.Size(96, 57);
            this.groupBox_shutdown.TabIndex = 3;
            this.groupBox_shutdown.TabStop = false;
            this.groupBox_shutdown.Text = "Выключение";
            // 
            // radioButton_hardoff
            // 
            this.radioButton_hardoff.AutoSize = true;
            this.radioButton_hardoff.Location = new System.Drawing.Point(11, 35);
            this.radioButton_hardoff.Name = "radioButton_hardoff";
            this.radioButton_hardoff.Size = new System.Drawing.Size(68, 17);
            this.radioButton_hardoff.TabIndex = 1;
            this.radioButton_hardoff.Text = "жёсткое";
            this.radioButton_hardoff.UseVisualStyleBackColor = true;
            // 
            // radioButton_softoff
            // 
            this.radioButton_softoff.AutoSize = true;
            this.radioButton_softoff.Checked = true;
            this.radioButton_softoff.Location = new System.Drawing.Point(11, 15);
            this.radioButton_softoff.Name = "radioButton_softoff";
            this.radioButton_softoff.Size = new System.Drawing.Size(62, 17);
            this.radioButton_softoff.TabIndex = 0;
            this.radioButton_softoff.TabStop = true;
            this.radioButton_softoff.Text = "мягкое";
            this.radioButton_softoff.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_check,
            this.columnHeader_state,
            this.columnHeader_dnsname,
            this.columnHeader_ipadress,
            this.columnHeader_username});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(270, 27);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(430, 269);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            // 
            // columnHeader_dnsname
            // 
            this.columnHeader_dnsname.Text = "DNS имя";
            this.columnHeader_dnsname.Width = 98;
            // 
            // columnHeader_ipadress
            // 
            this.columnHeader_ipadress.Text = "IP-адрес";
            this.columnHeader_ipadress.Width = 102;
            // 
            // columnHeader_username
            // 
            this.columnHeader_username.Text = "Имя пользователя";
            this.columnHeader_username.Width = 120;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File_ToolStripMenuItem,
            this.Service_ToolStripMenuItem,
            this.Help_ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(698, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // File_ToolStripMenuItem
            // 
            this.File_ToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.File_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Restart_ToolStripMenuItem,
            this.Shutdown_ToolStripMenuItem,
            this.Exit_ToolStripMenuItem});
            this.File_ToolStripMenuItem.Name = "File_ToolStripMenuItem";
            this.File_ToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.File_ToolStripMenuItem.Text = "Файл";
            // 
            // Restart_ToolStripMenuItem
            // 
            this.Restart_ToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Restart_ToolStripMenuItem.Name = "Restart_ToolStripMenuItem";
            this.Restart_ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.Restart_ToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.Restart_ToolStripMenuItem.Text = "Перезагрузка";
            this.Restart_ToolStripMenuItem.Click += new System.EventHandler(this.button_restart_Click);
            // 
            // Shutdown_ToolStripMenuItem
            // 
            this.Shutdown_ToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Shutdown_ToolStripMenuItem.Name = "Shutdown_ToolStripMenuItem";
            this.Shutdown_ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.Shutdown_ToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.Shutdown_ToolStripMenuItem.Text = "Выключение";
            this.Shutdown_ToolStripMenuItem.Click += new System.EventHandler(this.button_shutdown_Click);
            // 
            // Exit_ToolStripMenuItem
            // 
            this.Exit_ToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Exit_ToolStripMenuItem.Name = "Exit_ToolStripMenuItem";
            this.Exit_ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.Exit_ToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.Exit_ToolStripMenuItem.Text = "Выход";
            this.Exit_ToolStripMenuItem.Click += new System.EventHandler(this.Exit_ToolStripMenuItem_Click);
            // 
            // Service_ToolStripMenuItem
            // 
            this.Service_ToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Service_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Settings_ToolStripMenuItem});
            this.Service_ToolStripMenuItem.Name = "Service_ToolStripMenuItem";
            this.Service_ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.Service_ToolStripMenuItem.Text = "Сервис";
            // 
            // Settings_ToolStripMenuItem
            // 
            this.Settings_ToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Settings_ToolStripMenuItem.Name = "Settings_ToolStripMenuItem";
            this.Settings_ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.Settings_ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.Settings_ToolStripMenuItem.Text = "Настройки";
            this.Settings_ToolStripMenuItem.Click += new System.EventHandler(this.Settings_ToolStripMenuItem_Click);
            // 
            // Help_ToolStripMenuItem
            // 
            this.Help_ToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Help_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpView_ToolStripMenuItem,
            this.About_ToolStripMenuItem});
            this.Help_ToolStripMenuItem.Name = "Help_ToolStripMenuItem";
            this.Help_ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.Help_ToolStripMenuItem.Text = "Справка";
            // 
            // HelpView_ToolStripMenuItem
            // 
            this.HelpView_ToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.HelpView_ToolStripMenuItem.Name = "HelpView_ToolStripMenuItem";
            this.HelpView_ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.HelpView_ToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.HelpView_ToolStripMenuItem.Text = "Просмотр справки";
            // 
            // About_ToolStripMenuItem
            // 
            this.About_ToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.About_ToolStripMenuItem.Name = "About_ToolStripMenuItem";
            this.About_ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.About_ToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.About_ToolStripMenuItem.Text = "О программе";
            this.About_ToolStripMenuItem.Click += new System.EventHandler(this.About_ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.button_Scan);
            this.panel1.Controls.Add(this.button_shutdown);
            this.panel1.Controls.Add(this.button_restart);
            this.panel1.Controls.Add(this.groupBox_shutdown);
            this.panel1.Controls.Add(this.groupBox_restart);
            this.panel1.Location = new System.Drawing.Point(8, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 260);
            this.panel1.TabIndex = 10;
            // 
            // button_Scan
            // 
            this.button_Scan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Scan.Location = new System.Drawing.Point(50, 185);
            this.button_Scan.Name = "button_Scan";
            this.button_Scan.Size = new System.Drawing.Size(153, 61);
            this.button_Scan.TabIndex = 4;
            this.button_Scan.Text = "Сканировать";
            this.button_Scan.UseVisualStyleBackColor = true;
            this.button_Scan.Click += new System.EventHandler(this.button_Scan_Click);
            // 
            // timer_AutoScan
            // 
            this.timer_AutoScan.Tick += new System.EventHandler(this.timer_AutoScan_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip_tray;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "UVC Viewer";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.Open_UVCViewerToolStripMenuItem_Click);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip_tray
            // 
            this.contextMenuStrip_tray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open_UVCViewerToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.contextMenuStrip_tray.Name = "contextMenuStrip_tray";
            this.contextMenuStrip_tray.Size = new System.Drawing.Size(250, 70);
            this.contextMenuStrip_tray.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_tray_Opening);
            // 
            // Open_UVCViewerToolStripMenuItem
            // 
            this.Open_UVCViewerToolStripMenuItem.Name = "Open_UVCViewerToolStripMenuItem";
            this.Open_UVCViewerToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.Open_UVCViewerToolStripMenuItem.Text = "Открыть LANShutdowner Viewer";
            this.Open_UVCViewerToolStripMenuItem.Click += new System.EventHandler(this.Open_UVCViewerToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.Settings_ToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.Exit_ToolStripMenuItem_Click);
            // 
            // columnHeader_check
            // 
            this.columnHeader_check.Text = "Выбор";
            this.columnHeader_check.Width = 45;
            // 
            // columnHeader_state
            // 
            this.columnHeader_state.Text = "";
            this.columnHeader_state.Width = 30;
            // 
            // LANShutdowner_Client_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(698, 295);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LANShutdowner_Client_Form";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LANShutdowner Veiwer";
            this.groupBox_restart.ResumeLayout(false);
            this.groupBox_restart.PerformLayout();
            this.groupBox_shutdown.ResumeLayout(false);
            this.groupBox_shutdown.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip_tray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_restart;
        private System.Windows.Forms.Button button_shutdown;
        private System.Windows.Forms.GroupBox groupBox_restart;
        private System.Windows.Forms.RadioButton radioButton_hardreset;
        private System.Windows.Forms.RadioButton radioButton_softreset;
        private System.Windows.Forms.GroupBox groupBox_shutdown;
        private System.Windows.Forms.RadioButton radioButton_hardoff;
        private System.Windows.Forms.RadioButton radioButton_softoff;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader_dnsname;
        private System.Windows.Forms.ColumnHeader columnHeader_ipadress;
        private System.Windows.Forms.ColumnHeader columnHeader_username;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem File_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Restart_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Shutdown_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Exit_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Service_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Settings_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Help_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpView_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem About_ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button_Scan;
        private System.Windows.Forms.Timer timer_AutoScan;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_tray;
        private System.Windows.Forms.ToolStripMenuItem Open_UVCViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader_check;
        private System.Windows.Forms.ColumnHeader columnHeader_state;
    }
}

