using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LANShutdowner_Client
{
    [Serializable]
    public class Settings
    {
        public int Port;
        public bool RunAtStartup;
        public bool ScanOnStartup;
        public bool AutoScan;
        public int AutoScanTime;
        public List<Group> Groups;
    }

    [Serializable]
    public class Group
    {
        public string Name;
        public string IPList;

        public Group()
        {
            this.Name = "Name";
            this.IPList = "";
    }
        public Group(string name)
        {
            this.Name = name;
            this.IPList = "";
        }
    }
}
