using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using System.Management;
using System.ComponentModel;
using System.Net.NetworkInformation;

namespace WinServices
{
    public class LANShutdowner_Server
    {
        private TcpListener listener;
        private int port;
        private Thread listenerThread;

        public LANShutdowner_Server()
            : this(4478)
        {
        }
        public LANShutdowner_Server(int port)
        {
            this.port = port;
        }

        public void Start()
        {
            listenerThread = new Thread(ListenerThread);
            listenerThread.IsBackground = true;
            listenerThread.Name = "LANShutdownerServerDLL";
            listenerThread.Start();
        }
//-------------------------------------------------------------------
        private bool WinSoftReset()
        {
            if (0 != StationManage.halt(true, false)) // ������ ������������
                return true;
            return false;
        }
        private bool WinHardReset()
        {
            if( 0 != StationManage.halt(true, true)) // ������ ������������
                return true;
            return false;
        }
        private bool WinSoftOff()
        {
            if (0 != StationManage.halt(false, false)) // ������ ����������
                return true;
            return false;
        }
        private bool WinHardOff()
        {
            if (0 != StationManage.halt(false, true)) // ������� ����������
                return true;
            return false;
        }
        private bool WinLock()
        {
            if (0 != StationManage.Lock()) // ����������
                return true;
            return false;
        }
        private bool WinLogoff()
        {
            if (0 != StationManage.Exit()) // ����� ������������
                return true;
            return false;
        }

        protected void ListenerThread()
        {
            const int bufferSize = 1024;
            byte[] data = new byte[bufferSize];
            try
            {
               // IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                listener = new TcpListener(this.port);
                listener.Start();
                while (true)
                {
                    Socket clientSocket = listener.AcceptSocket();

                    clientSocket.Receive(data, 0, bufferSize, SocketFlags.None); // �������� ������ �������
                    string requestServer = Encoding.Unicode.GetString(data).Trim('\0');    // ��������� ����� � ������
                    string answerServer=null;
                    switch (requestServer)
                    {
                        case "soft_reset": 
                            {
                                if (WinSoftReset())
                                    answerServer="ok";
                                break; 
                            }
                        case "hard_reset":
                            { 
                                if(WinHardReset())
                                    answerServer="ok";
                                break;
                            }
                        case "soft_off":
                            {
                                if(WinSoftOff())
                                    answerServer="ok";
                                break;
                            }
                        case "hard_off":
                            {
                                if(WinHardOff())
                                    answerServer="ok";
                                break;
                            }
                        case "lock":
                            {
                                if (WinLock())
                                    answerServer = "ok";
                                break;
                            }
                        case "logoff":
                            {
                                if (WinLogoff())
                                    answerServer = "ok";
                                break;
                            }
                        case "getInfo":
                            {
                                // ��������� DNS-�����
                                IPHostEntry iphost = Dns.GetHostEntry("localhost");
                                string dnsname = iphost.HostName;

                                // ��������� ��������� ����� ��
                                string domain = Environment.UserDomainName;

                                // ��������� ����� ������������
                                string username = UserName.getUserName();
                                                    
                                // ��������� IP-������
                                IPAddress ipadress = IPAddress.Parse(((IPEndPoint)clientSocket.LocalEndPoint).Address.ToString());

                                // ��������� MAC-������
                                string MAC = "";
                                foreach (NetworkInterface netinterface in NetworkInterface.GetAllNetworkInterfaces())
                                {
                                    if (netinterface.OperationalStatus == OperationalStatus.Up && netinterface.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                                    {
                                        UnicastIPAddressInformationCollection unicastAddresses = netinterface.GetIPProperties().UnicastAddresses;
                                        if ((unicastAddresses != null) && (unicastAddresses.Count > 0))
                                        {
                                            for (int i = 0; i < unicastAddresses.Count; i++)
                                                if (unicastAddresses[i].Address.Equals(ipadress))
                                                    MAC = netinterface.GetPhysicalAddress().ToString();
                                        }
                                    }
                                }
                                
                                // ������������ ������ �������
                                answerServer = dnsname + "|" + ipadress + "|" + domain+"/"+username + "|" + MAC;
                                break;
                            }
                            
                    }
                    UnicodeEncoding encoder = new UnicodeEncoding();
                    byte[] buffer = encoder.GetBytes(answerServer);
                    clientSocket.Send(buffer, buffer.Length, 0);
                   
                    clientSocket.Close();
                 }
            }
            catch (SocketException ex)
            {
                Trace.TraceError(String.Format("LANShutdownerServerDLL {0}", ex.Message));
            }
        }

        public void Stop()
        {
            listener.Stop();
        }
        public void Suspend()
        {
            listener.Stop();
        }
        public void Resume()
        {
            Start();
        }

        public void RefreshQuotes()
        {
            
        }
    }

/* �������� ������������/����������
halt(true, false) //������ ������������
halt(true, true) //������� ������������
halt(false, false) //������ ����������
halt(false, true) //������� ����������
*/
    //========================================================================
    #region getUserName
    enum WTSInfoClass
    {
        WTSInitialProgram,
        WTSApplicationName,
        WTSWorkingDirectory,
        WTSOEMId,
        WTSSessionId,
        WTSUserName,
        WTSWinStationName,
        WTSDomainName,
        WTSConnectState,
        WTSClientBuildNumber,
        WTSClientName,
        WTSClientDirectory,
        WTSClientProductId,
        WTSClientHardwareId,
        WTSClientAddress,
        WTSClientDisplay,
        WTSClientProtocolType,
        WTSIdleTime,
        WTSLogonTime,
        WTSIncomingBytes,
        WTSOutgoingBytes,
        WTSIncomingFrames,
        WTSOutgoingFrames,
        WTSClientInfo,
        WTSSessionInfo
    }

    class UserName
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern uint WTSGetActiveConsoleSessionId();

        [DllImport("Wtsapi32.dll", SetLastError = true)]
        static extern bool WTSQuerySessionInformation(
            IntPtr hServer,
            uint sessionId,
            WTSInfoClass wtsInfoClass,
            out IntPtr ppBuffer,
            out uint pBytesReturned);

        [DllImport("wtsapi32.dll", SetLastError = true)]
        static extern void WTSFreeMemory(IntPtr memory);

       public unsafe static string getUserName()
        {
            var sessionId = WTSGetActiveConsoleSessionId();
            IntPtr pUserName;
            uint bytesReturned;
            if (!WTSQuerySessionInformation(IntPtr.Zero, sessionId, WTSInfoClass.WTSUserName, out pUserName, out bytesReturned))
                throw new Win32Exception();
            string username = new string((sbyte*)pUserName.ToPointer());
            WTSFreeMemory(pUserName);
            return username;
        }
    }
#endregion
    //========================================================================
    #region ����� ����������
    public static class StationManage
    {
        //����������� API ������� InitiateSystemShutdown
        [DllImport("advapi32.dll", EntryPoint = "InitiateSystemShutdownEx")]
        static extern int InitiateSystemShutdown(string lpMachineName, string lpMessage, int dwTimeout, bool bForceAppsClosed, bool bRebootAfterShutdown);
        //����������� API ������� AdjustTokenPrivileges
        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall,
        ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen);
        //����������� API ������� GetCurrentProcess
        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GetCurrentProcess();
        //����������� API ������� OpenProcessToken
        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool OpenProcessToken(IntPtr h, int acc, ref IntPtr phtok);
        //����������� API ������� LookupPrivilegeValue
        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern bool LookupPrivilegeValue(string host, string name, ref long pluid);
        //����������� API ������� LockWorkStation
        [DllImport("user32.dll", EntryPoint = "LockWorkStation")]
        static extern bool LockWorkStation();
        // ����������� API ������� ExitWindowsEx
        [DllImport("user32.dll", EntryPoint = "ExitWindowsEx")]
        static extern bool ExitWindowsEx(UInt32 uFlags,  UInt32 dwReason);

        // ��� ������� ���������� - ������������.
        internal const int SHTDN_REASON_MINOR_MAINTENANCE = 0x00000001;

        //��������� ��������� TokPriv1Luid ��� ������ � ������������
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct TokPriv1Luid
        {
            public int Count;
            public long Luid;
            public int Attr;
        }
        //��������� �����������, ��� API �������, ���������� ��������, �������� MSDN
        internal const int SE_PRIVILEGE_ENABLED = 0x00000002;
        internal const int TOKEN_QUERY = 0x00000008;
        internal const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
        internal const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";
        //������� SetPriv ��� ��������� ���������� ��������
        private static void SetPriv()
        {
            TokPriv1Luid tkp; //��������� ��������� TokPriv1Luid 
            IntPtr htok = IntPtr.Zero;
            //��������� "���������" ������� ��� ������ ��������
            if (OpenProcessToken(GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, ref htok))
            {
                //��������� ���� ���������
                tkp.Count = 1;
                tkp.Attr = SE_PRIVILEGE_ENABLED;
                tkp.Luid = 0;
                //�������� ��������� ������������� ����������� ��� ����������
                LookupPrivilegeValue(null, SE_SHUTDOWN_NAME, ref tkp.Luid);
                //������� ����������� ������ ��������
                AdjustTokenPrivileges(htok, false, ref tkp, 0, IntPtr.Zero, IntPtr.Zero);
            }
        }
        //��������� ����� ��� ������������/���������� ������
        public static int halt(bool RSh, bool Force)
        {
            SetPriv(); //�������� ����������
            //�������� ������� InitiateSystemShutdown, ��������� �� ����������� ���������
            return InitiateSystemShutdown(null, null, 0, Force, RSh);
        }
        //��������� ����� ��� ���������� ������������ �������
        public static int Lock()
        {
            if (LockWorkStation())
                return 1;
            else
                return 0;
        }

        public static int Exit()
        {
            UInt32 EWX_LOGOFF = 0;
            /* ��������� ������ ���� ���������, ���������� � ������ ����� � ������� ��������,
             * ���������� ������� ExitWindowsEx.
             * ����� �� ������� ������������ �� �������.
             */
            if (ExitWindowsEx(EWX_LOGOFF, SHTDN_REASON_MINOR_MAINTENANCE))
                return 1;
            else
                return 0;
        }
    }
#endregion
}
