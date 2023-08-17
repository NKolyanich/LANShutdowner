using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;
using WinServices;


namespace LANShutdownerService
{
    public partial class LANShutdowner_Service : ServiceBase
    {
        private LANShutdowner_Server ShutdowServer;
        public LANShutdowner_Service()
        {
            InitializeComponent();
        } 

        protected override void OnStart(string[] args)
        {
            ShutdowServer = new LANShutdowner_Server("4478");
            ShutdowServer.Start();
        }

        protected override void OnStop()
        {
            ShutdowServer.Stop();
        }

        protected override void OnContinue()
        {
            base.OnContinue();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        public const int commandRefresh = 128;
        protected override void OnCustomCommand(int command)
        {
            switch (command)
            {
                case commandRefresh:
                    ShutdowServer.RefreshQuotes();
                    break;

                default:
                    break;
            }

        }

    }
}
