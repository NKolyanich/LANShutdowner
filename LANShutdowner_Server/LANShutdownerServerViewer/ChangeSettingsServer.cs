using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LANShutdownerServerViewer
{
    public partial class ChangeSettingsServer : Form
    {
        public ChangeSettingsServer()
        {
            InitializeComponent();
            textBox_Settings_port.Text = Convert.ToString(SettingsServer.Default.Setting_port);
        }

        private void button_SaveSettings_Click(object sender, EventArgs e)
        {
            SettingsServer.Default.Setting_port = Convert.ToInt32(textBox_Settings_port.Text);

            SettingsServer.Default.Save();
            Close();
        }
    }
}
