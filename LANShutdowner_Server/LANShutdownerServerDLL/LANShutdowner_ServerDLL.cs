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
            if (0 != StationManage.halt(true, false)) // мягкая перезагрузка
                return true;
            return false;
        }
        private bool WinHardReset()
        {
            if( 0 != StationManage.halt(true, true)) // жёсткая перезагрузка
                return true;
            return false;
        }
        private bool WinSoftOff()
        {
            if (0 != StationManage.halt(false, false)) // мягкое выключение
                return true;
            return false;
        }
        private bool WinHardOff()
        {
            if (0 != StationManage.halt(false, true)) // жесткое выключение
                return true;
            return false;
        }
        private bool WinLock()
        {
            if (0 != StationManage.Lock()) // Блокировка
                return true;
            return false;
        }
        private bool WinLogoff()
        {
            if (0 != StationManage.Exit()) // Выход пользователя
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

                    clientSocket.Receive(data, 0, bufferSize, SocketFlags.None); // получаем запрос серверу
                    string requestServer = Encoding.Unicode.GetString(data).Trim('\0');    // переводим байты в строку
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
                                // Получение DNS-имени
                                IPHostEntry iphost = Dns.GetHostEntry("localhost");
                                string dnsname = iphost.HostName;

                                // Получение доменного имени ПК
                                string domain = Environment.UserDomainName;

                                // Получение имени пользователя
                                string username = UserName.getUserName();
                                                    
                                // Получение IP-адреса
                                IPAddress ipadress = IPAddress.Parse(((IPEndPoint)clientSocket.LocalEndPoint).Address.ToString());

                                // Получение MAC-адреса
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
                                
                                // формирование ответа сервера
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

/* варианты перезагрузки/выключения
halt(true, false) //мягкая перезагрузка
halt(true, true) //жесткая перезагрузка
halt(false, false) //мягкое выключение
halt(false, true) //жесткое выключение
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
    #region класс выключения
    public static class StationManage
    {
        //импортируем API функцию InitiateSystemShutdown
        [DllImport("advapi32.dll", EntryPoint = "InitiateSystemShutdownEx")]
        static extern int InitiateSystemShutdown(string lpMachineName, string lpMessage, int dwTimeout, bool bForceAppsClosed, bool bRebootAfterShutdown);
        //импортируем API функцию AdjustTokenPrivileges
        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall,
        ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen);
        //импортируем API функцию GetCurrentProcess
        [DllImport("kernel32.dll", ExactSpelling = true)]
        internal static extern IntPtr GetCurrentProcess();
        //импортируем API функцию OpenProcessToken
        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool OpenProcessToken(IntPtr h, int acc, ref IntPtr phtok);
        //импортируем API функцию LookupPrivilegeValue
        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern bool LookupPrivilegeValue(string host, string name, ref long pluid);
        //импортируем API функцию LockWorkStation
        [DllImport("user32.dll", EntryPoint = "LockWorkStation")]
        static extern bool LockWorkStation();
        // импортируем API функцию ExitWindowsEx
        [DllImport("user32.dll", EntryPoint = "ExitWindowsEx")]
        static extern bool ExitWindowsEx(UInt32 uFlags,  UInt32 dwReason);

        // Код причины выключения - обслуживание.
        internal const int SHTDN_REASON_MINOR_MAINTENANCE = 0x00000001;

        //объявляем структуру TokPriv1Luid для работы с привилегиями
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct TokPriv1Luid
        {
            public int Count;
            public long Luid;
            public int Attr;
        }
        //объявляем необходимые, для API функций, константые значения, согласно MSDN
        internal const int SE_PRIVILEGE_ENABLED = 0x00000002;
        internal const int TOKEN_QUERY = 0x00000008;
        internal const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
        internal const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";
        //функция SetPriv для повышения привилегий процесса
        private static void SetPriv()
        {
            TokPriv1Luid tkp; //экземпляр структуры TokPriv1Luid 
            IntPtr htok = IntPtr.Zero;
            //открываем "интерфейс" доступа для своего процесса
            if (OpenProcessToken(GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, ref htok))
            {
                //заполняем поля структуры
                tkp.Count = 1;
                tkp.Attr = SE_PRIVILEGE_ENABLED;
                tkp.Luid = 0;
                //получаем системный идентификатор необходимой нам привилегии
                LookupPrivilegeValue(null, SE_SHUTDOWN_NAME, ref tkp.Luid);
                //повышем привилигеию своему процессу
                AdjustTokenPrivileges(htok, false, ref tkp, 0, IntPtr.Zero, IntPtr.Zero);
            }
        }
        //публичный метод для перезагрузки/выключения машины
        public static int halt(bool RSh, bool Force)
        {
            SetPriv(); //получаем привилегию
            //вызываем функцию InitiateSystemShutdown, передавая ей необходимые параметры
            return InitiateSystemShutdown(null, null, 0, Force, RSh);
        }
        //публичный метод для блокировки операционной системы
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
            /* Завершает работу всех процессов, запущенных в сеансе входа в систему процесса,
             * вызвавшего функцию ExitWindowsEx.
             * Затем он выводит пользователя из системы.
             */
            if (ExitWindowsEx(EWX_LOGOFF, SHTDN_REASON_MINOR_MAINTENANCE))
                return 1;
            else
                return 0;
        }
    }
#endregion
}
