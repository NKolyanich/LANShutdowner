using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LANShutdowner_Client
{
    public partial class GroupNameInput : Form
    {
        public GroupNameInput()
        {
            InitializeComponent();
        }

        public string ReturnData()
        {
            return textBox_GroupName.Text;
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
