namespace LANShutdowner_Client
{
    partial class SettingsDialog_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label_port = new System.Windows.Forms.Label();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.button_General_SaveSettings = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.textBox_iplist = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkBox_ScanInStart = new System.Windows.Forms.CheckBox();
            this.checkBox_AutoScan = new System.Windows.Forms.CheckBox();
            this.textBox_TimeAutoScan = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox_AutoStart = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Group_SaveSettings = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_GroupDel = new System.Windows.Forms.Button();
            this.button_GroupAdd = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader_Number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(94, 36);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(32, 13);
            this.label_port.TabIndex = 2;
            this.label_port.Text = "Порт";
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(53, 57);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(123, 20);
            this.textBox_port.TabIndex = 3;
            // 
            // button_General_SaveSettings
            // 
            this.button_General_SaveSettings.Location = new System.Drawing.Point(201, 5);
            this.button_General_SaveSettings.Name = "button_General_SaveSettings";
            this.button_General_SaveSettings.Size = new System.Drawing.Size(113, 23);
            this.button_General_SaveSettings.TabIndex = 4;
            this.button_General_SaveSettings.Text = "Сохранить";
            this.button_General_SaveSettings.UseVisualStyleBackColor = true;
            this.button_General_SaveSettings.Click += new System.EventHandler(this.button_SaveSettings_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-3, -2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(533, 283);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage1.Controls.Add(this.panel6);
            this.tabPage1.Controls.Add(this.panel5);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(525, 257);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Общие";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel6.Controls.Add(this.textBox_iplist);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Location = new System.Drawing.Point(232, 6);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(287, 207);
            this.panel6.TabIndex = 7;
            // 
            // textBox_iplist
            // 
            this.textBox_iplist.Location = new System.Drawing.Point(14, 30);
            this.textBox_iplist.Multiline = true;
            this.textBox_iplist.Name = "textBox_iplist";
            this.textBox_iplist.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_iplist.Size = new System.Drawing.Size(257, 164);
            this.textBox_iplist.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(92, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Список ip-адресов";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel5.Controls.Add(this.button_General_SaveSettings);
            this.panel5.Location = new System.Drawing.Point(6, 219);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(513, 32);
            this.panel5.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel4.Controls.Add(this.checkBox_ScanInStart);
            this.panel4.Controls.Add(this.checkBox_AutoScan);
            this.panel4.Controls.Add(this.textBox_TimeAutoScan);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.checkBox_AutoStart);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label_port);
            this.panel4.Controls.Add(this.textBox_port);
            this.panel4.Location = new System.Drawing.Point(6, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(220, 207);
            this.panel4.TabIndex = 5;
            // 
            // checkBox_ScanInStart
            // 
            this.checkBox_ScanInStart.AutoSize = true;
            this.checkBox_ScanInStart.Location = new System.Drawing.Point(15, 103);
            this.checkBox_ScanInStart.Name = "checkBox_ScanInStart";
            this.checkBox_ScanInStart.Size = new System.Drawing.Size(150, 17);
            this.checkBox_ScanInStart.TabIndex = 9;
            this.checkBox_ScanInStart.Text = "Сканировать при старте";
            this.checkBox_ScanInStart.UseVisualStyleBackColor = true;
            // 
            // checkBox_AutoScan
            // 
            this.checkBox_AutoScan.AutoSize = true;
            this.checkBox_AutoScan.Location = new System.Drawing.Point(15, 123);
            this.checkBox_AutoScan.Name = "checkBox_AutoScan";
            this.checkBox_AutoScan.Size = new System.Drawing.Size(172, 17);
            this.checkBox_AutoScan.TabIndex = 8;
            this.checkBox_AutoScan.Text = "Сканировать автоматически";
            this.checkBox_AutoScan.UseVisualStyleBackColor = true;
            // 
            // textBox_TimeAutoScan
            // 
            this.textBox_TimeAutoScan.Location = new System.Drawing.Point(52, 175);
            this.textBox_TimeAutoScan.Name = "textBox_TimeAutoScan";
            this.textBox_TimeAutoScan.Size = new System.Drawing.Size(123, 20);
            this.textBox_TimeAutoScan.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(176, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Период автосканирования (сек.):";
            // 
            // checkBox_AutoStart
            // 
            this.checkBox_AutoStart.AutoSize = true;
            this.checkBox_AutoStart.Location = new System.Drawing.Point(15, 84);
            this.checkBox_AutoStart.Name = "checkBox_AutoStart";
            this.checkBox_AutoStart.Size = new System.Drawing.Size(185, 17);
            this.checkBox_AutoStart.TabIndex = 5;
            this.checkBox_AutoStart.Text = "Запускать при старте системы";
            this.checkBox_AutoStart.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(50, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "Общие настройки";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(525, 257);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Группы";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel3.Controls.Add(this.button_Cancel);
            this.panel3.Controls.Add(this.button_Group_SaveSettings);
            this.panel3.Location = new System.Drawing.Point(6, 221);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(513, 33);
            this.panel3.TabIndex = 8;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(420, 5);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 1;
            this.button_Cancel.Text = "Отмена";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_Group_SaveSettings
            // 
            this.button_Group_SaveSettings.Location = new System.Drawing.Point(330, 5);
            this.button_Group_SaveSettings.Name = "button_Group_SaveSettings";
            this.button_Group_SaveSettings.Size = new System.Drawing.Size(75, 23);
            this.button_Group_SaveSettings.TabIndex = 0;
            this.button_Group_SaveSettings.Text = "Сохранить";
            this.button_Group_SaveSettings.UseVisualStyleBackColor = true;
            this.button_Group_SaveSettings.Click += new System.EventHandler(this.button_SaveSettings_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(269, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 208);
            this.panel2.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(5, 5);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.RowHeadersWidth = 100;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(240, 197);
            this.dataGridView1.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Параметр";
            this.Column1.Name = "Column1";
            this.Column1.Width = 137;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Значение";
            this.Column2.Name = "Column2";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.button_GroupDel);
            this.panel1.Controls.Add(this.button_GroupAdd);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 208);
            this.panel1.TabIndex = 6;
            // 
            // button_GroupDel
            // 
            this.button_GroupDel.Location = new System.Drawing.Point(162, 181);
            this.button_GroupDel.Name = "button_GroupDel";
            this.button_GroupDel.Size = new System.Drawing.Size(75, 23);
            this.button_GroupDel.TabIndex = 8;
            this.button_GroupDel.Text = "Удалить";
            this.button_GroupDel.UseVisualStyleBackColor = true;
            this.button_GroupDel.Click += new System.EventHandler(this.button_GroupDel_Click);
            // 
            // button_GroupAdd
            // 
            this.button_GroupAdd.Location = new System.Drawing.Point(72, 181);
            this.button_GroupAdd.Name = "button_GroupAdd";
            this.button_GroupAdd.Size = new System.Drawing.Size(75, 23);
            this.button_GroupAdd.TabIndex = 7;
            this.button_GroupAdd.Text = "Добавить";
            this.button_GroupAdd.UseVisualStyleBackColor = true;
            this.button_GroupAdd.Click += new System.EventHandler(this.button_GroupAdd_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Number,
            this.columnHeader_Name});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 25);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(244, 154);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_Number
            // 
            this.columnHeader_Number.Text = "№";
            this.columnHeader_Number.Width = 50;
            // 
            // columnHeader_Name
            // 
            this.columnHeader_Name.Text = "Название";
            this.columnHeader_Name.Width = 170;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Группы ПК";
            // 
            // SettingsDialog_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 277);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsDialog_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Button button_General_SaveSettings;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button_Group_SaveSettings;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBox_iplist;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox_AutoScan;
        private System.Windows.Forms.TextBox textBox_TimeAutoScan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox_AutoStart;
        private System.Windows.Forms.CheckBox checkBox_ScanInStart;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_GroupDel;
        private System.Windows.Forms.Button button_GroupAdd;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.ColumnHeader columnHeader_Number;
        private System.Windows.Forms.ColumnHeader columnHeader_Name;
    }
}