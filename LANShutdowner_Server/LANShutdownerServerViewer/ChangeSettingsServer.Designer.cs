namespace LANShutdownerServerViewer
{
    partial class ChangeSettingsServer
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
            this.textBox_Settings_port = new System.Windows.Forms.TextBox();
            this.label_Settings_port = new System.Windows.Forms.Label();
            this.button_SaveSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Settings_port
            // 
            this.textBox_Settings_port.Location = new System.Drawing.Point(54, 11);
            this.textBox_Settings_port.Name = "textBox_Settings_port";
            this.textBox_Settings_port.Size = new System.Drawing.Size(100, 20);
            this.textBox_Settings_port.TabIndex = 0;
            // 
            // label_Settings_port
            // 
            this.label_Settings_port.AutoSize = true;
            this.label_Settings_port.Location = new System.Drawing.Point(13, 13);
            this.label_Settings_port.Name = "label_Settings_port";
            this.label_Settings_port.Size = new System.Drawing.Size(35, 13);
            this.label_Settings_port.TabIndex = 1;
            this.label_Settings_port.Text = "Порт:";
            // 
            // button_SaveSettings
            // 
            this.button_SaveSettings.Location = new System.Drawing.Point(79, 112);
            this.button_SaveSettings.Name = "button_SaveSettings";
            this.button_SaveSettings.Size = new System.Drawing.Size(75, 23);
            this.button_SaveSettings.TabIndex = 2;
            this.button_SaveSettings.Text = "Сохранить";
            this.button_SaveSettings.UseVisualStyleBackColor = true;
            this.button_SaveSettings.Click += new System.EventHandler(this.button_SaveSettings_Click);
            // 
            // ChangeSettingsServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 147);
            this.Controls.Add(this.button_SaveSettings);
            this.Controls.Add(this.label_Settings_port);
            this.Controls.Add(this.textBox_Settings_port);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChangeSettingsServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки UVC Monitor Server ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Settings_port;
        private System.Windows.Forms.Label label_Settings_port;
        private System.Windows.Forms.Button button_SaveSettings;
    }
}