namespace LANShutdownerServerViewer
{
    partial class LANShutdownerServerViewer
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LANShutdownerServerViewer));
            this.notifyIcon_Viewer = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip_nIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Settings_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.About_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.StopServer_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_nIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon_Viewer
            // 
            this.notifyIcon_Viewer.ContextMenuStrip = this.contextMenuStrip_nIcon;
            this.notifyIcon_Viewer.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_Viewer.Icon")));
            this.notifyIcon_Viewer.Text = "UVC Monitor Server";
            this.notifyIcon_Viewer.Visible = true;
            // 
            // contextMenuStrip_nIcon
            // 
            this.contextMenuStrip_nIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Settings_ToolStripMenuItem,
            this.About_ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.StopServer_ToolStripMenuItem});
            this.contextMenuStrip_nIcon.Name = "contextMenuStrip_nIcon";
            this.contextMenuStrip_nIcon.Size = new System.Drawing.Size(180, 76);
            // 
            // Settings_ToolStripMenuItem
            // 
            this.Settings_ToolStripMenuItem.Name = "Settings_ToolStripMenuItem";
            this.Settings_ToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.Settings_ToolStripMenuItem.Text = "Настройки";
            this.Settings_ToolStripMenuItem.Click += new System.EventHandler(this.Settings_ToolStripMenuItem_Click);
            // 
            // About_ToolStripMenuItem
            // 
            this.About_ToolStripMenuItem.Name = "About_ToolStripMenuItem";
            this.About_ToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.About_ToolStripMenuItem.Text = "О программе";
            this.About_ToolStripMenuItem.Click += new System.EventHandler(this.About_ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(176, 6);
            // 
            // StopServer_ToolStripMenuItem
            // 
            this.StopServer_ToolStripMenuItem.Name = "StopServer_ToolStripMenuItem";
            this.StopServer_ToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.StopServer_ToolStripMenuItem.Text = "Остановить сервер";
            this.StopServer_ToolStripMenuItem.Click += new System.EventHandler(this.StopServer_ToolStripMenuItem_Click);
            // 
            // UVCServerViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Enabled = false;
            this.Name = "UVCServerViewer";
            this.ShowInTaskbar = false;
            this.Text = "UVC Monitor Server";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.contextMenuStrip_nIcon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon_Viewer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_nIcon;
        private System.Windows.Forms.ToolStripMenuItem Settings_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem About_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StopServer_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}

