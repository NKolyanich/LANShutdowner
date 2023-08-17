using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;

namespace LANShutdownerServerViewer
{
    public partial class LANShutdownerServerViewer : Form
    {
        public LANShutdownerServerViewer()
        {
            InitializeComponent();
            ServiceController sc = new ServiceController("LANShutdownerServer");
            if (sc.Status == ServiceControllerStatus.Stopped)
            {
                sc.Start();
            }
        }

        private void Settings_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeSettingsServer settServer = new ChangeSettingsServer();
            settServer.Show();
        }

        private void About_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.Show();
        }

        private void StopServer_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceController sc = new ServiceController("LANShutdownerServer");
            if (sc.Status == ServiceControllerStatus.Running)
            {
                sc.Stop();
            }
            Close();
        }

    }
}
