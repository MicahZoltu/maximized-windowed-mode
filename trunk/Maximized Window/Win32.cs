using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Maximized_Window
{
	class Win32
	{
		public static readonly int GWL_WNDPROC = (-4);
		public static readonly int GWL_HINSTANCE = (-6);
		public static readonly int GWL_HWNDPARENT = (-8);
		public static readonly int GWL_STYLE = (-16);
		public static readonly int GWL_EXSTYLE = (-20);
		public static readonly int GWL_USERDATA = (-21);
		public static readonly int GWL_ID = (-12);

		// Window Styles 
		public const UInt32 WS_OVERLAPPED = 0;
		public const UInt32 WS_POPUP = 0x80000000;
		public const UInt32 WS_CHILD = 0x40000000;
		public const UInt32 WS_MINIMIZE = 0x20000000;
		public const UInt32 WS_VISIBLE = 0x10000000;
		public const UInt32 WS_DISABLED = 0x8000000;
		public const UInt32 WS_CLIPSIBLINGS = 0x4000000;
		public const UInt32 WS_CLIPCHILDREN = 0x2000000;
		public const UInt32 WS_MAXIMIZE = 0x1000000;
		public const UInt32 WS_CAPTION = 0xC00000;      // WS_BORDER or WS_DLGFRAME  
		public const UInt32 WS_BORDER = 0x800000;
		public const UInt32 WS_DLGFRAME = 0x400000;
		public const UInt32 WS_VSCROLL = 0x200000;
		public const UInt32 WS_HSCROLL = 0x100000;
		public const UInt32 WS_SYSMENU = 0x80000;
		public const UInt32 WS_THICKFRAME = 0x40000;
		public const UInt32 WS_GROUP = 0x20000;
		public const UInt32 WS_TABSTOP = 0x10000;
		public const UInt32 WS_MINIMIZEBOX = 0x20000;
		public const UInt32 WS_MAXIMIZEBOX = 0x10000;
		public const UInt32 WS_TILED = WS_OVERLAPPED;
		public const UInt32 WS_ICONIC = WS_MINIMIZE;
		public const UInt32 WS_SIZEBOX = WS_THICKFRAME;

		// Extended Window Styles 
		public const UInt32 WS_EX_DLGMODALFRAME = 0x0001;
		public const UInt32 WS_EX_NOPARENTNOTIFY = 0x0004;
		public const UInt32 WS_EX_TOPMOST = 0x0008;
		public const UInt32 WS_EX_ACCEPTFILES = 0x0010;
		public const UInt32 WS_EX_TRANSPARENT = 0x0020;
		public const UInt32 WS_EX_MDICHILD = 0x0040;
		public const UInt32 WS_EX_TOOLWINDOW = 0x0080;
		public const UInt32 WS_EX_WINDOWEDGE = 0x0100;
		public const UInt32 WS_EX_CLIENTEDGE = 0x0200;
		public const UInt32 WS_EX_CONTEXTHELP = 0x0400;
		public const UInt32 WS_EX_RIGHT = 0x1000;
		public const UInt32 WS_EX_LEFT = 0x0000;
		public const UInt32 WS_EX_RTLREADING = 0x2000;
		public const UInt32 WS_EX_LTRREADING = 0x0000;
		public const UInt32 WS_EX_LEFTSCROLLBAR = 0x4000;
		public const UInt32 WS_EX_RIGHTSCROLLBAR = 0x0000;
		public const UInt32 WS_EX_CONTROLPARENT = 0x10000;
		public const UInt32 WS_EX_STATICEDGE = 0x20000;
		public const UInt32 WS_EX_APPWINDOW = 0x40000;
		public const UInt32 WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE);
		public const UInt32 WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST);
		public const UInt32 WS_EX_LAYERED = 0x00080000;
		public const UInt32 WS_EX_NOINHERITLAYOUT = 0x00100000; // Disable inheritence of mirroring by children
		public const UInt32 WS_EX_LAYOUTRTL = 0x00400000; // Right to left mirroring
		public const UInt32 WS_EX_COMPOSITED = 0x02000000;
		public const UInt32 WS_EX_NOACTIVATE = 0x08000000;

		/// <summary>
		/// Flags used with the Windows API (User32.dll):GetSystemMetrics(SystemMetric smIndex)
		///   
		/// This Enum and declaration signature was written by Gabriel T. Sharp
		/// ai_productions@verizon.net or osirisgothra@hotmail.com
		/// Obtained on pinvoke.net, please contribute your code to support the wiki!
		/// </summary>
		public enum SystemMetric : int
		{
			/// <summary>
			///  Width of the screen of the primary display monitor, in pixels. This is the same values obtained by calling GetDeviceCaps as follows: GetDeviceCaps( hdcPrimaryMonitor, HORZRES).
			/// </summary>
			SM_CXSCREEN = 0,
			/// <summary>
			/// Height of the screen of the primary display monitor, in pixels. This is the same values obtained by calling GetDeviceCaps as follows: GetDeviceCaps( hdcPrimaryMonitor, VERTRES).
			/// </summary>
			SM_CYSCREEN = 1,
			/// <summary>
			/// Height of the arrow bitmap on a vertical scroll bar, in pixels.
			/// </summary>
			SM_CYVSCROLL = 20,
			/// <summary>
			/// Width of a vertical scroll bar, in pixels.
			/// </summary>
			SM_CXVSCROLL = 2,
			/// <summary>
			/// Height of a caption area, in pixels.
			/// </summary>
			SM_CYCAPTION = 4,
			/// <summary>
			/// Width of a window border, in pixels. This is equivalent to the SM_CXEDGE value for windows with the 3-D look.
			/// </summary>
			SM_CXBORDER = 5,
			/// <summary>
			/// Height of a window border, in pixels. This is equivalent to the SM_CYEDGE value for windows with the 3-D look. 
			/// </summary>
			SM_CYBORDER = 6,
			/// <summary>
			/// Thickness of the frame around the perimeter of a window that has a caption but is not sizable, in pixels. SM_CXFIXEDFRAME is the height of the horizontal border and SM_CYFIXEDFRAME is the width of the vertical border. 
			/// </summary>
			SM_CXDLGFRAME = 7,
			/// <summary>
			/// Thickness of the frame around the perimeter of a window that has a caption but is not sizable, in pixels. SM_CXFIXEDFRAME is the height of the horizontal border and SM_CYFIXEDFRAME is the width of the vertical border. 
			/// </summary>
			SM_CYDLGFRAME = 8,
			/// <summary>
			/// Height of the thumb box in a vertical scroll bar, in pixels
			/// </summary>
			SM_CYVTHUMB = 9,
			/// <summary>
			/// Width of the thumb box in a horizontal scroll bar, in pixels.
			/// </summary>
			SM_CXHTHUMB = 10,
			/// <summary>
			/// Default width of an icon, in pixels. The LoadIcon function can load only icons with the dimensions specified by SM_CXICON and SM_CYICON
			/// </summary>
			SM_CXICON = 11,
			/// <summary>
			/// Default height of an icon, in pixels. The LoadIcon function can load only icons with the dimensions SM_CXICON and SM_CYICON.
			/// </summary>
			SM_CYICON = 12,
			/// <summary>
			/// Width of a cursor, in pixels. The system cannot create cursors of other sizes.
			/// </summary>
			SM_CXCURSOR = 13,
			/// <summary>
			/// Height of a cursor, in pixels. The system cannot create cursors of other sizes.
			/// </summary>
			SM_CYCURSOR = 14,
			/// <summary>
			/// Height of a single-line menu bar, in pixels.
			/// </summary>
			SM_CYMENU = 15,
			/// <summary>
			/// Width of the client area for a full-screen window on the primary display monitor, in pixels. To get the coordinates of the portion of the screen not obscured by the system taskbar or by application desktop toolbars, call the SystemParametersInfo function with the SPI_GETWORKAREA value.
			/// </summary>
			SM_CXFULLSCREEN = 16,
			/// <summary>
			/// Height of the client area for a full-screen window on the primary display monitor, in pixels. To get the coordinates of the portion of the screen not obscured by the system taskbar or by application desktop toolbars, call the SystemParametersInfo function with the SPI_GETWORKAREA value.
			/// </summary>
			SM_CYFULLSCREEN = 17,
			/// <summary>
			/// For double byte character set versions of the system, this is the height of the Kanji window at the bottom of the screen, in pixels
			/// </summary>
			SM_CYKANJIWINDOW = 18,
			/// <summary>
			/// Nonzero if a mouse with a wheel is installed; zero otherwise
			/// </summary>
			SM_MOUSEWHEELPRESENT = 75,
			/// <summary>
			/// Height of a horizontal scroll bar, in pixels.
			/// </summary>
			SM_CYHSCROLL = 3,
			/// <summary>
			/// Width of the arrow bitmap on a horizontal scroll bar, in pixels.
			/// </summary>
			SM_CXHSCROLL = 21,
			/// <summary>
			/// Nonzero if the debug version of User.exe is installed; zero otherwise.
			/// </summary>
			SM_DEBUG = 22,
			/// <summary>
			/// Nonzero if the left and right mouse buttons are reversed; zero otherwise.
			/// </summary>
			SM_SWAPBUTTON = 23,
			/// <summary>
			/// Reserved for future use
			/// </summary>
			SM_RESERVED1 = 24,
			/// <summary>
			/// Reserved for future use
			/// </summary>
			SM_RESERVED2 = 25,
			/// <summary>
			/// Reserved for future use
			/// </summary>
			SM_RESERVED3 = 26,
			/// <summary>
			/// Reserved for future use
			/// </summary>
			SM_RESERVED4 = 27,
			/// <summary>
			/// Minimum width of a window, in pixels.
			/// </summary>
			SM_CXMIN = 28,
			/// <summary>
			/// Minimum height of a window, in pixels.
			/// </summary>
			SM_CYMIN = 29,
			/// <summary>
			/// Width of a button in a window's caption or title bar, in pixels.
			/// </summary>
			SM_CXSIZE = 30,
			/// <summary>
			/// Height of a button in a window's caption or title bar, in pixels.
			/// </summary>
			SM_CYSIZE = 31,
			/// <summary>
			/// Thickness of the sizing border around the perimeter of a window that can be resized, in pixels. SM_CXSIZEFRAME is the width of the horizontal border, and SM_CYSIZEFRAME is the height of the vertical border. 
			/// </summary>
			SM_CXFRAME = 32,
			/// <summary>
			/// Thickness of the sizing border around the perimeter of a window that can be resized, in pixels. SM_CXSIZEFRAME is the width of the horizontal border, and SM_CYSIZEFRAME is the height of the vertical border. 
			/// </summary>
			SM_CYFRAME = 33,
			/// <summary>
			/// Minimum tracking width of a window, in pixels. The user cannot drag the window frame to a size smaller than these dimensions. A window can override this value by processing the WM_GETMINMAXINFO message.
			/// </summary>
			SM_CXMINTRACK = 34,
			/// <summary>
			/// Minimum tracking height of a window, in pixels. The user cannot drag the window frame to a size smaller than these dimensions. A window can override this value by processing the WM_GETMINMAXINFO message
			/// </summary>
			SM_CYMINTRACK = 35,
			/// <summary>
			/// Width of the rectangle around the location of a first click in a double-click sequence, in pixels. The second click must occur within the rectangle defined by SM_CXDOUBLECLK and SM_CYDOUBLECLK for the system to consider the two clicks a double-click
			/// </summary>
			SM_CXDOUBLECLK = 36,
			/// <summary>
			/// Height of the rectangle around the location of a first click in a double-click sequence, in pixels. The second click must occur within the rectangle defined by SM_CXDOUBLECLK and SM_CYDOUBLECLK for the system to consider the two clicks a double-click. (The two clicks must also occur within a specified time.) 
			/// </summary>
			SM_CYDOUBLECLK = 37,
			/// <summary>
			/// Width of a grid cell for items in large icon view, in pixels. Each item fits into a rectangle of size SM_CXICONSPACING by SM_CYICONSPACING when arranged. This value is always greater than or equal to SM_CXICON
			/// </summary>
			SM_CXICONSPACING = 38,
			/// <summary>
			/// Height of a grid cell for items in large icon view, in pixels. Each item fits into a rectangle of size SM_CXICONSPACING by SM_CYICONSPACING when arranged. This value is always greater than or equal to SM_CYICON.
			/// </summary>
			SM_CYICONSPACING = 39,
			/// <summary>
			/// Nonzero if drop-down menus are right-aligned with the corresponding menu-bar item; zero if the menus are left-aligned.
			/// </summary>
			SM_MENUDROPALIGNMENT = 40,
			/// <summary>
			/// Nonzero if the Microsoft Windows for Pen computing extensions are installed; zero otherwise.
			/// </summary>
			SM_PENWINDOWS = 41,
			/// <summary>
			/// Nonzero if User32.dll supports DBCS; zero otherwise. (WinMe/95/98): Unicode
			/// </summary>
			SM_DBCSENABLED = 42,
			/// <summary>
			/// Number of buttons on mouse, or zero if no mouse is installed.
			/// </summary>
			SM_CMOUSEBUTTONS = 43,
			/// <summary>
			/// Identical Values Changed After Windows NT 4.0  
			/// </summary>
			SM_CXFIXEDFRAME = SM_CXDLGFRAME,
			/// <summary>
			/// Identical Values Changed After Windows NT 4.0
			/// </summary>
			SM_CYFIXEDFRAME = SM_CYDLGFRAME,
			/// <summary>
			/// Identical Values Changed After Windows NT 4.0
			/// </summary>
			SM_CXSIZEFRAME = SM_CXFRAME,
			/// <summary>
			/// Identical Values Changed After Windows NT 4.0
			/// </summary>
			SM_CYSIZEFRAME = SM_CYFRAME,
			/// <summary>
			/// Nonzero if security is present; zero otherwise.
			/// </summary>
			SM_SECURE = 44,
			/// <summary>
			/// Width of a 3-D border, in pixels. This is the 3-D counterpart of SM_CXBORDER
			/// </summary>
			SM_CXEDGE = 45,
			/// <summary>
			/// Height of a 3-D border, in pixels. This is the 3-D counterpart of SM_CYBORDER
			/// </summary>
			SM_CYEDGE = 46,
			/// <summary>
			/// Width of a grid cell for a minimized window, in pixels. Each minimized window fits into a rectangle this size when arranged. This value is always greater than or equal to SM_CXMINIMIZED.
			/// </summary>
			SM_CXMINSPACING = 47,
			/// <summary>
			/// Height of a grid cell for a minimized window, in pixels. Each minimized window fits into a rectangle this size when arranged. This value is always greater than or equal to SM_CYMINIMIZED.
			/// </summary>
			SM_CYMINSPACING = 48,
			/// <summary>
			/// Recommended width of a small icon, in pixels. Small icons typically appear in window captions and in small icon view
			/// </summary>
			SM_CXSMICON = 49,
			/// <summary>
			/// Recommended height of a small icon, in pixels. Small icons typically appear in window captions and in small icon view.
			/// </summary>
			SM_CYSMICON = 50,
			/// <summary>
			/// Height of a small caption, in pixels
			/// </summary>
			SM_CYSMCAPTION = 51,
			/// <summary>
			/// Width of small caption buttons, in pixels.
			/// </summary>
			SM_CXSMSIZE = 52,
			/// <summary>
			/// Height of small caption buttons, in pixels.
			/// </summary>
			SM_CYSMSIZE = 53,
			/// <summary>
			/// Width of menu bar buttons, such as the child window close button used in the multiple document interface, in pixels.
			/// </summary>
			SM_CXMENUSIZE = 54,
			/// <summary>
			/// Height of menu bar buttons, such as the child window close button used in the multiple document interface, in pixels.
			/// </summary>
			SM_CYMENUSIZE = 55,
			/// <summary>
			/// Flags specifying how the system arranged minimized windows
			/// </summary>
			SM_ARRANGE = 56,
			/// <summary>
			/// Width of a minimized window, in pixels.
			/// </summary>
			SM_CXMINIMIZED = 57,
			/// <summary>
			/// Height of a minimized window, in pixels.
			/// </summary>
			SM_CYMINIMIZED = 58,
			/// <summary>
			/// Default maximum width of a window that has a caption and sizing borders, in pixels. This metric refers to the entire desktop. The user cannot drag the window frame to a size larger than these dimensions. A window can override this value by processing the WM_GETMINMAXINFO message.
			/// </summary>
			SM_CXMAXTRACK = 59,
			/// <summary>
			/// Default maximum height of a window that has a caption and sizing borders, in pixels. This metric refers to the entire desktop. The user cannot drag the window frame to a size larger than these dimensions. A window can override this value by processing the WM_GETMINMAXINFO message.
			/// </summary>
			SM_CYMAXTRACK = 60,
			/// <summary>
			/// Default width, in pixels, of a maximized top-level window on the primary display monitor.
			/// </summary>
			SM_CXMAXIMIZED = 61,
			/// <summary>
			/// Default height, in pixels, of a maximized top-level window on the primary display monitor.
			/// </summary>
			SM_CYMAXIMIZED = 62,
			/// <summary>
			/// Least significant bit is set if a network is present; otherwise, it is cleared. The other bits are reserved for future use
			/// </summary>
			SM_NETWORK = 63,
			/// <summary>
			/// Value that specifies how the system was started: 0-normal, 1-failsafe, 2-failsafe /w net
			/// </summary>
			SM_CLEANBOOT = 67,
			/// <summary>
			/// Width of a rectangle centered on a drag point to allow for limited movement of the mouse pointer before a drag operation begins, in pixels. 
			/// </summary>
			SM_CXDRAG = 68,
			/// <summary>
			/// Height of a rectangle centered on a drag point to allow for limited movement of the mouse pointer before a drag operation begins. This value is in pixels. It allows the user to click and release the mouse button easily without unintentionally starting a drag operation.
			/// </summary>
			SM_CYDRAG = 69,
			/// <summary>
			/// Nonzero if the user requires an application to present information visually in situations where it would otherwise present the information only in audible form; zero otherwise. 
			/// </summary>
			SM_SHOWSOUNDS = 70,
			/// <summary>
			/// Width of the default menu check-mark bitmap, in pixels.
			/// </summary>
			SM_CXMENUCHECK = 71,
			/// <summary>
			/// Height of the default menu check-mark bitmap, in pixels.
			/// </summary>
			SM_CYMENUCHECK = 72,
			/// <summary>
			/// Nonzero if the computer has a low-end (slow) processor; zero otherwise
			/// </summary>
			SM_SLOWMACHINE = 73,
			/// <summary>
			/// Nonzero if the system is enabled for Hebrew and Arabic languages, zero if not.
			/// </summary>
			SM_MIDEASTENABLED = 74,
			/// <summary>
			/// Nonzero if a mouse is installed; zero otherwise. This value is rarely zero, because of support for virtual mice and because some systems detect the presence of the port instead of the presence of a mouse.
			/// </summary>
			SM_MOUSEPRESENT = 19,
			/// <summary>
			/// Windows 2000 (v5.0+) Coordinate of the top of the virtual screen
			/// </summary>
			SM_XVIRTUALSCREEN = 76,
			/// <summary>
			/// Windows 2000 (v5.0+) Coordinate of the left of the virtual screen
			/// </summary>
			SM_YVIRTUALSCREEN = 77,
			/// <summary>
			/// Windows 2000 (v5.0+) Width of the virtual screen
			/// </summary>
			SM_CXVIRTUALSCREEN = 78,
			/// <summary>
			/// Windows 2000 (v5.0+) Height of the virtual screen
			/// </summary>
			SM_CYVIRTUALSCREEN = 79,
			/// <summary>
			/// Number of display monitors on the desktop
			/// </summary>
			SM_CMONITORS = 80,
			/// <summary>
			/// Windows XP (v5.1+) Nonzero if all the display monitors have the same color format, zero otherwise. Note that two displays can have the same bit depth, but different color formats. For example, the red, green, and blue pixels can be encoded with different numbers of bits, or those bits can be located in different places in a pixel's color value. 
			/// </summary>
			SM_SAMEDISPLAYFORMAT = 81,
			/// <summary>
			/// Windows XP (v5.1+) Nonzero if Input Method Manager/Input Method Editor features are enabled; zero otherwise
			/// </summary>
			SM_IMMENABLED = 82,
			/// <summary>
			/// Windows XP (v5.1+) Width of the left and right edges of the focus rectangle drawn by DrawFocusRect. This value is in pixels. 
			/// </summary>
			SM_CXFOCUSBORDER = 83,
			/// <summary>
			/// Windows XP (v5.1+) Height of the top and bottom edges of the focus rectangle drawn by DrawFocusRect. This value is in pixels. 
			/// </summary>
			SM_CYFOCUSBORDER = 84,
			/// <summary>
			/// Nonzero if the current operating system is the Windows XP Tablet PC edition, zero if not.
			/// </summary>
			SM_TABLETPC = 86,
			/// <summary>
			/// Nonzero if the current operating system is the Windows XP, Media Center Edition, zero if not.
			/// </summary>
			SM_MEDIACENTER = 87,
			/// <summary>
			/// Metrics Other
			/// </summary>
			SM_CMETRICS_OTHER = 76,
			/// <summary>
			/// Metrics Windows 2000
			/// </summary>
			SM_CMETRICS_2000 = 83,
			/// <summary>
			/// Metrics Windows NT
			/// </summary>
			SM_CMETRICS_NT = 88,
			/// <summary>
			/// Windows XP (v5.1+) This system metric is used in a Terminal Services environment. If the calling process is associated with a Terminal Services client session, the return value is nonzero. If the calling process is associated with the Terminal Server console session, the return value is zero. The console session is not necessarily the physical console - see WTSGetActiveConsoleSessionId for more information. 
			/// </summary>
			SM_REMOTESESSION = 0x1000,
			/// <summary>
			/// Windows XP (v5.1+) Nonzero if the current session is shutting down; zero otherwise
			/// </summary>
			SM_SHUTTINGDOWN = 0x2000,
			/// <summary>
			/// Windows XP (v5.1+) This system metric is used in a Terminal Services environment. Its value is nonzero if the current session is remotely controlled; zero otherwise
			/// </summary>
			SM_REMOTECONTROL = 0x2001,
		}

		[Flags()]
		public enum SetWindowPosFlags : uint
		{
			/// <summary>If the calling thread and the thread that owns the window are attached to different input queues, 
			/// the system posts the request to the thread that owns the window. This prevents the calling thread from 
			/// blocking its execution while other threads process the request.</summary>
			/// <remarks>SWP_ASYNCWINDOWPOS</remarks>
			SynchronousWindowPosition = 0x4000,
			/// <summary>Prevents generation of the WM_SYNCPAINT message.</summary>
			/// <remarks>SWP_DEFERERASE</remarks>
			DeferErase = 0x2000,
			/// <summary>Draws a frame (defined in the window's class description) around the window.</summary>
			/// <remarks>SWP_DRAWFRAME</remarks>
			DrawFrame = 0x0020,
			/// <summary>Applies new frame styles set using the SetWindowLong function. Sends a WM_NCCALCSIZE message to 
			/// the window, even if the window's size is not being changed. If this flag is not specified, WM_NCCALCSIZE 
			/// is sent only when the window's size is being changed.</summary>
			/// <remarks>SWP_FRAMECHANGED</remarks>
			FrameChanged = 0x0020,
			/// <summary>Hides the window.</summary>
			/// <remarks>SWP_HIDEWINDOW</remarks>
			HideWindow = 0x0080,
			/// <summary>Does not activate the window. If this flag is not set, the window is activated and moved to the 
			/// top of either the topmost or non-topmost group (depending on the setting of the hWndInsertAfter 
			/// parameter).</summary>
			/// <remarks>SWP_NOACTIVATE</remarks>
			DoNotActivate = 0x0010,
			/// <summary>Discards the entire contents of the client area. If this flag is not specified, the valid 
			/// contents of the client area are saved and copied back into the client area after the window is sized or 
			/// repositioned.</summary>
			/// <remarks>SWP_NOCOPYBITS</remarks>
			DoNotCopyBits = 0x0100,
			/// <summary>Retains the current position (ignores X and Y parameters).</summary>
			/// <remarks>SWP_NOMOVE</remarks>
			IgnoreMove = 0x0002,
			/// <summary>Does not change the owner window's position in the Z order.</summary>
			/// <remarks>SWP_NOOWNERZORDER</remarks>
			DoNotChangeOwnerZOrder = 0x0200,
			/// <summary>Does not redraw changes. If this flag is set, no repainting of any kind occurs. This applies to 
			/// the client area, the nonclient area (including the title bar and scroll bars), and any part of the parent 
			/// window uncovered as a result of the window being moved. When this flag is set, the application must 
			/// explicitly invalidate or redraw any parts of the window and parent window that need redrawing.</summary>
			/// <remarks>SWP_NOREDRAW</remarks>
			DoNotRedraw = 0x0008,
			/// <summary>Same as the SWP_NOOWNERZORDER flag.</summary>
			/// <remarks>SWP_NOREPOSITION</remarks>
			DoNotReposition = 0x0200,
			/// <summary>Prevents the window from receiving the WM_WINDOWPOSCHANGING message.</summary>
			/// <remarks>SWP_NOSENDCHANGING</remarks>
			DoNotSendChangingEvent = 0x0400,
			/// <summary>Retains the current size (ignores the cx and cy parameters).</summary>
			/// <remarks>SWP_NOSIZE</remarks>
			IgnoreResize = 0x0001,
			/// <summary>Retains the current Z order (ignores the hWndInsertAfter parameter).</summary>
			/// <remarks>SWP_NOZORDER</remarks>
			IgnoreZOrder = 0x0004,
			/// <summary>Displays the window.</summary>
			/// <remarks>SWP_SHOWWINDOW</remarks>
			ShowWindow = 0x0040,
		}

		[DllImport("user32.dll", SetLastError = true)]
		public static extern UInt32 GetWindowLong(IntPtr hWnd, int nIndex);

		[DllImport("user32.dll")]
		public static extern UInt32 SetWindowLong(IntPtr hWnd, int nIndex, UInt32 dwNewLong);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetClientRect(IntPtr hwd, out RECT lpRect);

		[DllImport("user32.dll")]
		public static extern int GetSystemMetrics(SystemMetric smIndex);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public int Left;        // x position of upper-left corner
			public int Top;         // y position of upper-left corner
			public int Right;       // x position of lower-right corner
			public int Bottom;      // y position of lower-right corner
		}
	}
}
