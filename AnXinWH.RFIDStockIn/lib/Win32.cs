using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace AnXinWH.RFIDStockIn
{
    public class Win32
    {
        #region window
        //[DllImport("coredll.dll")]
        //public static extern IntPtr FindWindow([MarshalAs(UnmanagedType.LPWStr)]string lpClassName, [MarshalAs(UnmanagedType.LPWStr)]string lpWindowName);

        //[DllImport("coredll.dll")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("coredll.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);


        public const int ERROR_ALREADY_EXISTS = 183;
        [DllImport("coredll.dll", EntryPoint = "CreateMutex", SetLastError = true)]
        public static extern IntPtr CreateMutex(IntPtr lpMutexAttributes, bool bInitiaOwner, string lpName);
        [DllImport("coredll.dll", SetLastError = true)]
        public static extern int ReleaseMutex(IntPtr hMutex);

        /// <summary>
        /// A callback to a Win32 window procedure (wndproc)
        /// </summary>
        /// <param name="hwnd">The handle of the window receiving a message</param>
        /// <param name="msg">The message</param>
        /// <param name="wParam">The message's parameters (part 1)</param>
        /// <param name="lParam">The message's parameters (part 2)</param>
        /// <returns>A integer as described for the given message in MSDN</returns>
        public delegate int WndProc(IntPtr hwnd, uint msg, uint wParam, int lParam);

        [DllImport("coredll.dll")]
        public extern static int DefWindowProc(IntPtr hwnd, uint msg, uint wParam, int lParam);

        [DllImport("coredll.dll")]
        public extern static IntPtr SetWindowLong(IntPtr hwnd, int nIndex, IntPtr dwNewLong);

        public const int GWL_WNDPROC = -4;

        [DllImport("coredll.dll")]
        public extern static int CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hwnd, uint msg, uint wParam, int lParam);


        public const uint WM_NOTIFY = 0x4E;

        public const uint NM_CLICK = 0xFFFFFFFE;
        public const uint NM_DBLCLK = 0xFFFFFFFD;
        public const uint NM_RCLICK = 0xFFFFFFFB;
        public const uint NM_RDBLCLK = 0xFFFFFFFA;


        public const uint TV_FIRST = 0x1100;
        public const uint TVM_HITTEST = TV_FIRST + 17;

        public const uint TVHT_NOWHERE = 0x0001;
        public const uint TVHT_ONITEMICON = 0x0002;
        public const uint TVHT_ONITEMLABEL = 0x0004;
        public const uint TVHT_ONITEM = (TVHT_ONITEMICON | TVHT_ONITEMLABEL | TVHT_ONITEMSTATEICON);
        public const uint TVHT_ONITEMINDENT = 0x0008;
        public const uint TVHT_ONITEMBUTTON = 0x0010;
        public const uint TVHT_ONITEMRIGHT = 0x0020;
        public const uint TVHT_ONITEMSTATEICON = 0x0040;
        public const uint TVHT_ABOVE = 0x0100;
        public const uint TVHT_BELOW = 0x0200;
        public const uint TVHT_TORIGHT = 0x0400;
        public const uint TVHT_TOLEFT = 0x0800;

        [System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
        public class NMHDR
        {
            public IntPtr hwndFrom;
            public uint idFrom;
            public uint code;
        }

        public struct TVHITTESTINFO
        {
            public POINT pt;
            public uint flags;
            public IntPtr hItem;
        }

        /// <summary>
        /// Helper function to convert a Windows lParam into a Point
        /// </summary>
        /// <param name="lParam">The parameter to convert</param>
        /// <returns>A Point where X is the low 16 bits and Y is the
        /// high 16 bits of the value passed in</returns>
        public static Point LParamToPoint(int lParam)
        {
            uint ulParam = (uint)lParam;
            return new Point(
                (int)(ulParam & 0x0000ffff),
                (int)((ulParam & 0xffff0000) >> 16));
        }

        [DllImport("coredll.dll")]
        public extern static uint GetMessagePos();

        [DllImport("coredll.dll")]
        public extern static int SendMessage(IntPtr hwnd, uint msg, uint wParam, ref TVHITTESTINFO lParam);


        public const uint LVM_FIRST = 0x1000;     // ListView messages
        public const uint LVM_HITTEST = (LVM_FIRST + 18);
        public const uint LVM_SUBITEMHITTEST = (LVM_FIRST + 57);


        public const uint LVHT_NOWHERE = 0x00000001;
        public const uint LVHT_ONITEMICON = 0x00000002;
        public const uint LVHT_ONITEMLABEL = 0x00000004;
        public const uint LVHT_ONITEMSTATEICON = 0x00000008;
        public const uint LVHT_ONITEM = (LVHT_ONITEMICON | LVHT_ONITEMLABEL | LVHT_ONITEMSTATEICON);

        public const uint LVHT_ABOVE = 0x00000008;
        public const uint LVHT_BELOW = 0x00000010;
        public const uint LVHT_TORIGHT = 0x00000020;
        public const uint LVHT_TOLEFT = 0x00000040;

        public struct LVHITTESTINFO
        {
            public POINT pt;
            public uint flags;
            public int iItem;
            public int iSubItem;
        }

        [DllImport("coredll.dll")]
        public extern static int SendMessage(IntPtr hwnd, uint msg, uint wParam, ref LVHITTESTINFO lParam);
        #endregion

        #region keyboard
        public const uint WM_KEYFIRST = 0x0100;
        public const uint WM_KEYDOWN = 0x0100;
        public const uint WM_KEYUP = 0x0101;
        public const uint WM_KEYLAST = 0x0108;

        public const int WM_HOTKEY = 0x0312;

        public const uint MOD_ALT = 1;
        public const uint MOD_CONTROL = 2;
        public const uint MOD_KEYUP = 0x1000;
        public const uint MOD_SHIFT = 4;
        public const uint MOD_WIN = 8;

        public const uint VK_NUMPAD0 = 0x60;
        public const uint VK_NUMPAD1 = 0x61;
        public const uint VK_NUMPAD2 = 0x62;
        public const uint VK_NUMPAD3 = 0x63;
        public const uint VK_NUMPAD4 = 0x64;
        public const uint VK_NUMPAD5 = 0x65;
        public const uint VK_NUMPAD6 = 0x66;
        public const uint VK_NUMPAD7 = 0x67;
        public const uint VK_NUMPAD8 = 0x68;
        public const uint VK_NUMPAD9 = 0x69;

        public const uint VK_F1 = 0x70;
        public const uint VK_F2 = 0x71;
        public const uint VK_F3 = 0x72;
        public const uint VK_F4 = 0x73;
        public const uint VK_F5 = 0x74;
        public const uint VK_F6 = 0x75;
        public const uint VK_F7 = 0x76;
        public const uint VK_F8 = 0x77;
        public const uint VK_F9 = 0x78;

        public const uint VK_F23 = 0x86;
        public const uint VK_F24 = 0x87;

        public const uint VK_ESCAPE = 0x1B;
        public const uint VK_RETURN = 0x0D;
        public const uint VK_CAPITAL = 0x14;
        public const uint VK_NUMBER = 0x0B;

        [DllImport("coredll.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("coredll.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("coredll.dll")]
        public static extern short GetKeyState(int nVirtKey);

        #endregion

        #region event

        public const uint WAIT_TIMEOUT = 0x102;
        public const uint WAIT_FAILED = 0xffffffffu;
        public const uint INFINITE = 0xffffffffu;

        [DllImport("coredll.dll")]
        public static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

        [DllImport("coredll.dll")]
        public static extern uint WaitForMultipleObjects(uint nCount, IntPtr[] lpHandles, [MarshalAs(UnmanagedType.Bool)]bool fWaitAll, uint dwMilliseconds);

        [DllImport("coredll.dll")]
        public static extern IntPtr CreateEvent(IntPtr lpEventAttributes, [MarshalAs(UnmanagedType.Bool)]bool bManualReset, [MarshalAs(UnmanagedType.Bool)]bool bInitialState, [MarshalAs(UnmanagedType.LPWStr)]string lpName);


        public const uint EVENT_PULSE = 1;
        public const uint EVENT_RESET = 2;
        public const uint EVENT_SET = 3;

        [DllImport("coredll.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EventModify(IntPtr hEvent, uint func);

        [DllImport("coredll.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);


        [StructLayout(LayoutKind.Sequential)]
        public class MSGQUEUEOPTIONS
        {
            public uint dwSize;
            public uint dwFlags;
            public uint dwMaxMessages;
            public uint cbMaxMessage;
            public bool bReadAccess;
        }

        [DllImport("coredll.dll")]
        public static extern IntPtr CreateMsgQueue([MarshalAs(UnmanagedType.LPWStr)]string lpszName, MSGQUEUEOPTIONS lpOptions);

        [DllImport("coredll.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseMsgQueue(IntPtr hMsgQ);


        [DllImport("coredll.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadMsgQueue(IntPtr hMsgQ, [MarshalAs(UnmanagedType.AsAny)]out object lpBuffer, uint cbBufferSize, out uint lpNumberOfBytesRead, uint dwTimeout, out uint pdwFlags);

        [StructLayout(LayoutKind.Sequential)]
        public struct POWER_BROADCAST_POWER_INFO
        {
            public uint dwNumLevels;
            public uint dwBatteryLifeTime;
            public uint dwBatteryFullLifeTime;
            public uint dwBackupBatteryLifeTime;
            public uint dwBackupBatteryFullLifeTime;
            public byte bACLineStatus;
            public byte bBatteryFlag;
            public byte bBatteryLifePercent;
            public byte bBackupBatteryFlag;
            public byte bBackupBatteryLifePercent;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POWER_BROADCAST
        {
            public uint Message;    // one of PBT_Xxx
            public uint Flags;      // one of POWER_STATE_Xxx
            public uint Length;     // byte count of data starting at SystemPowerStateName
            public POWER_BROADCAST_POWER_INFO PI;
        }

        [DllImport("coredll.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadMsgQueue(IntPtr hMsgQ, out POWER_BROADCAST BroadCast, uint cbBufferSize, out uint lpNumberOfBytesRead, uint dwTimeout, out uint pdwFlags);

        #endregion

        #region hook
        public delegate int HOOKPROC(int code, uint wParam, KBDLLHOOKSTRUCT lParam);


        public const int WH_JOURNALRECORD = 0;
        public const int WH_JOURNALPLAYBACK = 1;
        public const int WH_KEYBOARD_LL = 20;

        public const int HC_ACTION = 0;

        [DllImport("coredll.dll", EntryPoint = "SetWindowsHookExW")]
        public static extern IntPtr SetWindowsHookEx(int idHook, [MarshalAs(UnmanagedType.FunctionPtr)]HOOKPROC lpfn, IntPtr hmod, uint dwThreadId);

        [DllImport("coredll.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("coredll.dll")]
        public static extern int CallNextHookEx(IntPtr hhk, int nCode, uint wParam, KBDLLHOOKSTRUCT lParam);

        public const uint SND_ALIAS = 0x00010000;   // name is a WIN.INI [sounds] entry
        public const uint SND_FILENAME = 0x00020000;   // name is a file name

        public const uint SND_SYNC = 0x00000000;   // play synchronously (default)
        public const uint SND_ASYNC = 0x00000001;   // play asynchronously
        public const uint SND_NODEFAULT = 0x00000002;   // silence not default, if sound not found
        public const uint SND_MEMORY = 0x00000004;   // lpszSoundName points to a memory file
        public const uint SND_LOOP = 0x00000008;   // loop the sound until next sndPlaySound
        public const uint SND_NOSTOP = 0x00000010;   // don't stop any currently playing sound
        #endregion

        #region powermgr
        public const uint PBT_TRANSITION = 0x00000001;  // broadcast specifying system power state transition
        public const uint PBT_RESUME = 0x00000002;  // broadcast notifying a resume, specifies previous state
        public const uint PBT_POWERSTATUSCHANGE = 0x00000004;  // power supply switched to/from AC/DC
        public const uint PBT_POWERINFOCHANGE = 0x00000008;  // some system power status field has changed


        [DllImport("coredll.dll")]
        public static extern IntPtr RequestPowerNotifications(IntPtr hMsgQ, uint Flags);

        [DllImport("coredll.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool StopPowerNotifications(IntPtr hMsgQ);

        [StructLayout(LayoutKind.Sequential)]
        public class SYSTEM_POWER_STATUS_EX2
        {
            public byte ACLineStatus;
            public byte BatteryFlag;
            public byte BatteryLifePercent;
            public byte Reserved1;
            public uint BatteryLifeTime;
            public uint BatteryFullLifeTime;
            public byte Reserved2;
            public byte BackupBatteryFlag;
            public byte BackupBatteryLifePercent;
            public byte Reserved3;
            public uint BackupBatteryLifeTime;
            public uint BackupBatteryFullLifeTime;
            public uint BatteryVoltage;
            public uint BatteryCurrent;
            public uint BatteryAverageCurrent;
            public uint BatteryAverageInterval;
            public uint BatterymAHourConsumed;
            public uint BatteryTemperature;
            public uint BackupBatteryVoltage;
            public byte BatteryChemistry;
        }

        [DllImport("coredll.dll")]
        public static extern uint GetSystemPowerStatusEx2(SYSTEM_POWER_STATUS_EX2 pSystemPowerStatusEx2, uint dwLen, [MarshalAs(UnmanagedType.Bool)]bool fUpdate);

        public const uint POWER_STATE_ON = 0x00010000u;        // on state
        public const uint POWER_STATE_OFF = 0x00020000u;        // no power, full off
        public const uint POWER_STATE_CRITICAL = 0x00040000u;        // critical off
        public const uint POWER_STATE_BOOT = 0x00080000u;        // boot state
        public const uint POWER_STATE_IDLE = 0x00100000u;        // idle state
        public const uint POWER_STATE_SUSPEND = 0x00200000u;        // suspend state
        public const uint POWER_STATE_RESET = 0x00800000u;        // reset state

        public const uint POWER_FORCE = 0x00001000u;


        [DllImport("coredll.dll")]
        public static extern uint SetSystemPowerState([MarshalAs(UnmanagedType.LPWStr)]string psState, uint StateFlags, uint Options);


        #endregion

        #region system

        // defines
        public const int IDC_WAIT = 32514;

        // functions
        [DllImport("coredll.dll")]
        public static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

        [DllImport("coredll.dll")]
        public static extern IntPtr SetCursor(IntPtr hCursor);


        [DllImport("coredll.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, int pvParam, uint fWinIni);


        [DllImport("coredll.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool sndPlaySound(byte[] lpszSoundName, uint fuSound);


        [StructLayout(LayoutKind.Sequential)]
        public class SYSTEMTIME
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;

            public SYSTEMTIME(DateTime datetime)
            {
                this.wYear = (ushort)datetime.Year;
                this.wMonth = (ushort)datetime.Month;
                this.wDay = (ushort)datetime.Day;
                this.wHour = (ushort)datetime.Hour;
                this.wMinute = (ushort)datetime.Minute;
                this.wSecond = (ushort)datetime.Second;
                this.wMilliseconds = (ushort)datetime.Millisecond;
            }
        }

        [DllImport("coredll.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetLocalTime(SYSTEMTIME lpSystemTime);

        [DllImport("coredll.dll")]
        public static extern uint GetTickCount();
        #endregion

        #region gdi

        [DllImport("coredll.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("coredll.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("coredll.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("coredll.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteDC(IntPtr hDC);

        [DllImport("coredll.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);

        [DllImport("coredll.dll")]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hgdiobj);

        [DllImport("coredll.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject(IntPtr hgdiobj);


        public const uint SRCCOPY = 0x00CC0020u; /* dest = source                   */
        public const uint SRCPAINT = 0x00EE0086u; /* dest = source OR dest           */
        public const uint SRCAND = 0x008800C6u; /* dest = source AND dest          */
        public const uint SRCINVERT = 0x00660046u; /* dest = source XOR dest          */
        public const uint SRCERASE = 0x00440328u; /* dest = source AND (NOT dest )   */
        public const uint NOTSRCCOPY = 0x00330008u; /* dest = (NOT source)             */
        public const uint NOTSRCERASE = 0x001100A6u; /* dest = (NOT src) AND (NOT dest) */
        public const uint MERGECOPY = 0x00C000CAu; /* dest = (source AND pattern)     */
        public const uint MERGEPAINT = 0x00BB0226u; /* dest = (NOT source) OR dest     */
        public const uint PATCOPY = 0x00F00021u; /* dest = pattern                  */
        public const uint PATPAINT = 0x00FB0A09u; /* dest = DPSnoo                   */
        public const uint PATINVERT = 0x005A0049u; /* dest = pattern XOR dest         */
        public const uint DSTINVERT = 0x00550009u; /* dest = (NOT dest)               */
        public const uint BLACKNESS = 0x00000042u; /* dest = BLACK                    */
        public const uint WHITENESS = 0x00FF0062u; /* dest = WHITE                    */

        [DllImport("coredll.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);


        public struct TRIVERTEX
        {
            public int x;
            public int y;
            public ushort Red;
            public ushort Green;
            public ushort Blue;
            public ushort Alpha;

            public TRIVERTEX(int x, int y, ushort red, ushort green, ushort blue, ushort alpha)
            {
                this.x = x;
                this.y = y;
                this.Red = (ushort)(red << 8);
                this.Green = (ushort)(green << 8);
                this.Blue = (ushort)(blue << 8);
                this.Alpha = (ushort)(alpha << 8);
            }
        }

        public struct GRADIENT_RECT
        {
            public uint UpperLeft;
            public uint LowerRight;

            public GRADIENT_RECT(uint ul, uint lr)
            {
                this.UpperLeft = ul;
                this.LowerRight = lr;
            }
        }

        public const int GRADIENT_FILL_RECT_H = 0x00000000;
        public const int GRADIENT_FILL_RECT_V = 0x00000001;

        [DllImport("coredll.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public extern static bool GradientFill(IntPtr hdc, TRIVERTEX[] pVertex, uint dwNumVertex, GRADIENT_RECT[] pMesh, uint dwNumMesh, uint dwMode);

        [DllImport("coredll.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RoundRect(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidth, int nHeight);


        public const int WHITE_BRUSH = 0;
        public const int LTGRAY_BRUSH = 1;
        public const int GRAY_BRUSH = 2;
        public const int DKGRAY_BRUSH = 3;
        public const int BLACK_BRUSH = 4;
        public const int NULL_BRUSH = 5;
        public const int HOLLOW_BRUSH = 5;
        public const int WHITE_PEN = 6;
        public const int BLACK_PEN = 7;
        public const int NULL_PEN = 8;
        public const int SYSTEM_FONT = 13;
        public const int DEFAULT_PALETTE = 15;
        public const int BORDERX_PEN = 32;
        public const int BORDERY_PEN = 33;


        [DllImport("coredll.dll")]
        public static extern IntPtr GetStockObject(int fnObject);

        public const int PS_SOLID = 0;
        public const int PS_DASH = 1;
        public const int PS_NULL = 5;

        public static uint RGB(byte r, byte g, byte b)
        {
            return (uint)r | (uint)((uint)g << 8) | (uint)((uint)b << 16);
        }

        [DllImport("coredll.dll")]
        public static extern IntPtr CreatePen(int fnPenStyle, int nWidth, uint crColor);

        [DllImport("coredll.dll")]
        public static extern IntPtr CreateSolidBrush(uint crColor);


        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }
        }

        public struct POINT
        {
            public int X;
            public int Y;
        }



        [DllImport("coredll.dll")]
        public static extern int FillRect(IntPtr hDC, ref RECT lprc, IntPtr hbr);

        public const uint BI_RGB = 0;

        public const uint DIB_RGB_COLORS = 0; /* color table in RGBs */
        public const uint DIB_PAL_COLORS = 1; /* color table in palette indices */


        public struct BITMAPINFOHEADER
        {
            public uint biSize;
            public int biWidth;
            public int biHeight;
            public ushort biPlanes;
            public ushort biBitCount;
            public uint biCompression;
            public uint biSizeImage;
            public int biXPelsPerMeter;
            public int biYPelsPerMeter;
            public uint biClrUsed;
            public uint biClrImportant;
        }

        public struct RGBQUAD
        {
            public byte rgbBlue;
            public byte rgbGreen;
            public byte rgbRed;
            public byte rgbReserved;
        }

        public struct BITMAPINFO
        {
            public BITMAPINFOHEADER bmiHeader;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public RGBQUAD[] bmiColors;
        }



        [DllImport("coredll.dll")]
        public static extern IntPtr CreateDIBSection(IntPtr hdc, ref BITMAPINFO pbmi, uint iUsage, out IntPtr ppvBits, IntPtr hSection, uint dwOffset);


        public struct BITMAPFILEHEADER
        {
            public ushort bfType;
            public uint bfSize;
            public ushort bfReserved1;
            public ushort bfReserved2;
            public uint bfOffBits;
        }

        public static uint BYTESPERLINE(uint Width, uint BPP)
        {
            return (uint)((ushort)(((Width * BPP + 31) >> 5)) << 2);
        }



        [StructLayout(LayoutKind.Sequential)]
        public class KBDLLHOOKSTRUCT
        {
            public uint vkCode;  // virtual key code 
            public uint scanCode;  // scan code 
            public uint flags;  // flags 
            public uint time;   // time stamp for this message 
            public uint dwExtraInfo; // extra info from the driver or keybd_event 

        }
        #endregion

        [DllImport("Coredll.dll")]
        private extern static int KernelIoControl(int dwIoControlCode, IntPtr lpInBuf, int nInBufSize, IntPtr lpOutBuf, int nOutBufSize, ref int lpBytesReturned);

        [DllImport("Coredll.dll")]
        extern static void SetCleanRebootFlag();

        public const int KEYEVENTF_KEYUP = 0x0002;

        [DllImport("coredll.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        //    模拟键盘我们用Keybd_event这个api函数，模拟鼠标按键用mouse_event函数。在VC里调用api函数是既简单又方便不过的事了。
        //  首先介绍一下Keybd_event函数。Keybd_event能触发一个按键事件，也就是说回产生一个WM_KEYDOWN或WM_KEYUP消息。当然也可以用产生这两个消息来模拟按键，但是没有直接用这个函数方便。Keybd_event共有四个参数，第一个为按键的虚拟键值，如回车键为vk_return, tab键为vk_tab。第二个参数为扫描码，一般不用设置，用0代替就行第三个参数为选项标志，如果为keydown则置0即可，如果为keyup则设成“KEYEVENTF_KEYUP”，第四个参数一般也是置0即可。用如下代码即可实现模拟按下键，其中的XX表示XX键的虚拟键值，在这里也就是各键对应的键码，如’A’=65 
        //keybd_event(65,0,0,0); 
        //keybd_event(9,0,0,0);  //模拟Table键
        //keybd_event(65,0,KEYEVENTF_KEYUP,0); ...


        /// <summary>
        /// 系统关机
        /// </summary>
        public static void ShutDown()
        {
            int IOCTL_HAL_SHUTDOWN = 0x1012000;//关机
            int bytesReturned = 0;

            byte VK_OFF = 0xdf;
            byte KEYEVENTF_KEYUP = 2;

            KernelIoControl(IOCTL_HAL_SHUTDOWN, IntPtr.Zero, 0, IntPtr.Zero, 0, ref bytesReturned);

            keybd_event(VK_OFF, 0, 0, 0);
            keybd_event(VK_OFF, 0, KEYEVENTF_KEYUP, 0);//关机
        }

        //重启机器
        public static void HardReset()
        {
            int IOCTL_HAL_REBOOT = 0x101003C;
            int bytesReturned = 0;
            SetCleanRebootFlag();
            KernelIoControl(IOCTL_HAL_REBOOT, IntPtr.Zero, 0, IntPtr.Zero, 0, ref bytesReturned);
        }


        //public const int SW_SHOW = 5; //显示窗口常量
        //public const int SW_HIDE = 0; //隐藏窗口常量

        //public static void HideTaskBar()
        //{
        //    IntPtr Hwnd = FindWindow("HHTaskBar", null);
        //    if (Hwnd != IntPtr.Zero)
        //    {
        //        ShowWindow(Hwnd, SW_HIDE); //隐藏任务栏

        //    }
        //}

        //public static void ShowTaskBar()
        //{
        //    IntPtr Hwnd = FindWindow("HHTaskBar", null);
        //    if (Hwnd != IntPtr.Zero)
        //    {
        //        ShowWindow(Hwnd, SW_SHOW); //显示任务栏

        //    }
        //}


        //public const uint POWER_FORCE = 0x00001000u;
        //public const uint POWER_STATE_RESET = 0x00800000u;        // reset state

        //[DllImport("coredll.dll")]
        //public static extern uint SetSystemPowerState([MarshalAs(UnmanagedType.LPWStr)]string psState, uint StateFlags, uint Options);

        [DllImport("coredll.dll", EntryPoint = "FindWindow")]
        public static extern int FindWindow(string lpWindowName, string lpClassName);

        [DllImport("coredll.dll", EntryPoint = "ShowWindow")]
        public static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);

        [DllImport("coredll.dll", EntryPoint = "SystemParametersInfo")]
        public static extern int SystemParametersInfo(int uAction, int uParam, ref Rectangle lpvParam, int fuWinIni);

        public const int SPI_SETWORKAREA = 47;
        public const int SPI_GETWORKAREA = 48;

        public const int SW_HIDE = 0x00;
        public const int SW_SHOW = 0x0001;
        public const int SPIF_UPDATEINIFILE = 0x01;

        public static bool SetFullScreen(bool fullscreen, ref Rectangle rectOld)
        {
            int Hwnd = 0;
            Hwnd = Win32.FindWindow("HHTaskBar", null);
            if (Hwnd == 0) return false;
            if (fullscreen)
            {
                ShowWindow((IntPtr)Hwnd, Win32.SW_HIDE);
                Rectangle rectFull = Screen.PrimaryScreen.Bounds;
                Win32.SystemParametersInfo(Win32.SPI_GETWORKAREA, 0, ref rectOld, Win32.SPIF_UPDATEINIFILE);//get
                Win32.SystemParametersInfo(Win32.SPI_SETWORKAREA, 0, ref rectFull, Win32.SPIF_UPDATEINIFILE);//set
            }
            else
            {
                Win32.ShowWindow((IntPtr)Hwnd, Win32.SW_SHOW);
                Win32.SystemParametersInfo(Win32.SPI_SETWORKAREA, 0, ref rectOld, Win32.SPIF_UPDATEINIFILE);
            }
            return true;
        }


        ////Rectangle rectangle = Screen.PrimaryScreen.Bounds;
        ////Win32.SetFullScreen(true, ref rectangle);//false为恢复状态栏

        public enum Flags
        {
            SND_SYNC = 0x0000,  /* play synchronously (default) */
            SND_ASYNC = 0x0001,  /* play asynchronously */
            SND_NODEFAULT = 0x0002,  /* silence (!default) if sound not found */
            SND_MEMORY = 0x0004,  /* pszSound points to a memory file */
            SND_LOOP = 0x0008,  /* loop the sound until next sndPlaySound */
            SND_NOSTOP = 0x0010,  /* don't stop any currently playing sound */
            SND_NOWAIT = 0x00002000, /* don't wait if the driver is busy */
            SND_ALIAS = 0x00010000, /* name is a registry alias */
            SND_ALIAS_ID = 0x00110000, /* alias is a predefined ID */
            SND_FILENAME = 0x00020000, /* name is file name */
            SND_RESOURCE = 0x00040004  /* name is resource name or atom */
        }
        [DllImport("CoreDll.DLL", EntryPoint = "PlaySound", SetLastError = true)]
        public extern static int WCE_PlaySound(string szSound, IntPtr hMod, int flags);


        /// <summary>
        /// 同步播放声音文件
        /// </summary>
        /// <param name="filename"></param>
        public static void PlaySYNCSound(string filename)
        {
            if (!string.IsNullOrEmpty(filename))
            {
                if (System.IO.File.Exists(filename))
                {
                    WCE_PlaySound(filename, IntPtr.Zero, (int)(Flags.SND_SYNC | Flags.SND_FILENAME));
                }
            }
        }

        /// <summary>
        /// 异步播放声音文件
        /// </summary>
        /// <param name="filename"></param>
        public static void PlaySound(string filename)
        {
            if (!string.IsNullOrEmpty(filename))
            {
                if (System.IO.File.Exists(filename))
                {
                    WCE_PlaySound(filename, IntPtr.Zero, (int)(Flags.SND_ASYNC | Flags.SND_FILENAME));
                }
            }
        }
    }

}
