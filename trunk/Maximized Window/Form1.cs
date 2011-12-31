using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Maximized_Window
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			RefreshList();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Process process = (Process)listBoxProcesses.SelectedItem;

			IntPtr foundWindow = process.MainWindowHandle;
			if (foundWindow == null) return;
			UInt32 styles = Win32.GetWindowLong(foundWindow, Win32.GWL_STYLE);
			if (styles == 0) return;
			styles ^= Win32.WS_CAPTION;

			bool deflate = 0 == (styles & Win32.WS_CAPTION);
			Win32.RECT prevRect;
			Win32.GetWindowRect(foundWindow, out prevRect);

			int captionHeight = Win32.GetSystemMetrics(Win32.SystemMetric.SM_CYCAPTION);
			int borderWidth = Win32.GetSystemMetrics(Win32.SystemMetric.SM_CXDLGFRAME);
			int borderHeight = Win32.GetSystemMetrics(Win32.SystemMetric.SM_CYDLGFRAME);

			Win32.RECT newRect;

			if (deflate)
			{
				newRect.Left = 0;
				newRect.Right = prevRect.Right - prevRect.Left - (borderWidth * 2);
				newRect.Top = 0;
				newRect.Bottom = prevRect.Bottom - prevRect.Top - (borderHeight * 2) - captionHeight;
			}
			else
			{
				newRect.Left = prevRect.Left - borderWidth;
				newRect.Right = prevRect.Right + borderWidth;
				newRect.Top = prevRect.Top - (borderHeight * 2);
				newRect.Bottom = prevRect.Bottom + captionHeight;
			}

			UInt32 result = Win32.SetWindowLong(foundWindow, Win32.GWL_STYLE, styles);
			if (result == 0) return;
			Win32.SetWindowPos(foundWindow, IntPtr.Zero, newRect.Left, newRect.Top, newRect.Right - newRect.Left, newRect.Bottom - newRect.Top, Win32.SetWindowPosFlags.FrameChanged);
		}

		private void buttonRefresh_Click(object sender, EventArgs e)
		{
			RefreshList();
		}

		private void RefreshList()
		{
			Process[] processList = Process.GetProcesses();
			listBoxProcesses.Items.Clear();
			foreach (Process process in processList)
			{
				if (process.MainWindowHandle == null) continue;
				if (process.MainWindowHandle == IntPtr.Zero) continue;
				listBoxProcesses.Items.Add(process);
			}
			listBoxProcesses.Sorted = true;
			listBoxProcesses.DisplayMember = "ProcessName";
		}
	}
}
