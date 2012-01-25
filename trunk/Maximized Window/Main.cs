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
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();

			// refresh the window list and start a timer to refresh again every 0.5 seconds
			RefreshList(null, null);
			Timer refreshTimer = new Timer();
			refreshTimer.Tick += new EventHandler(RefreshList);
			refreshTimer.Interval = 500;
			refreshTimer.Start();
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			Properties.Settings.Default.Save();

			base.OnClosing(e);
		}

		private void buttonMaximize_Click(object sender, EventArgs e)
		{
			// clicking the button without an item selected does nothing
			if (listBoxProcesses.SelectedItem == null)
			{
				MessageBox.Show("Error: No process selected.");
				return;
			}
			
			Process process = (Process)listBoxProcesses.SelectedItem;

			// get the window style for the main window for this application
			IntPtr foundWindow = process.MainWindowHandle;
			if (foundWindow == null)
			{
				MessageBox.Show("Error: No window handle found for selected process.");
				return;
			}
			UInt32 styles = Win32.GetWindowLong(foundWindow, Win32.GWL_STYLE);
			if (styles == 0)
			{
				MessageBox.Show("Error: Selected window has no style.");
				return;
			}

			// if the window has a caption then we are maximizing
			bool maximizing = ((styles & Win32.WS_CAPTION) != 0);

			// toggle the caption style
			styles ^= Win32.WS_CAPTION;

			// get the previous window rectangle
			Win32.RECT prevWindowRect;
			Win32.GetWindowRect(foundWindow, out prevWindowRect);
			Win32.RECT prevClientRect;
			Win32.GetClientRect(foundWindow, out prevClientRect);

			// find out the dimensions of the window borders
			int captionHeight = SystemInformation.CaptionHeight;
			int borderWidth = SystemInformation.FixedFrameBorderSize.Width;
			int borderHeight = SystemInformation.FixedFrameBorderSize.Height;

			// calculate the new window rectangle
			Win32.RECT newRect;
			if (maximizing)
			{
				Rectangle containingRectangle = MoveWindow();

				int renderWidth = prevClientRect.Right;
				int renderHeight = prevClientRect.Bottom;

				int horizontalCenter = containingRectangle.Left + (containingRectangle.Width / 2);
				int verticalCenter = containingRectangle.Top + (containingRectangle.Height / 2) - captionHeight;

				newRect.Left =  horizontalCenter - (renderWidth / 2);
				newRect.Right = newRect.Left + renderWidth;
				newRect.Top = verticalCenter - (renderHeight / 2);
				newRect.Bottom = newRect.Top + renderHeight;
			}
			else
			{
				newRect.Left = prevWindowRect.Left - borderWidth;
				newRect.Right = prevWindowRect.Right + borderWidth;
				newRect.Top = prevWindowRect.Top - captionHeight - borderHeight;
				newRect.Bottom = prevWindowRect.Bottom + borderHeight;
			}

			// set the new window style
			UInt32 result = Win32.SetWindowLong(foundWindow, Win32.GWL_STYLE, styles);
			if (result == 0) return;

			// set the new window rectangle
			Win32.SetWindowPos(foundWindow, IntPtr.Zero, newRect.Left, newRect.Top, newRect.Right - newRect.Left, newRect.Bottom - newRect.Top, Win32.SetWindowPosFlags.FrameChanged);
		}

		private void RefreshList(Object o, EventArgs e)
		{
			// get the selected item so we can reselect it after the refresh
			Process previouslySelectedProcess = (Process)listBoxProcesses.SelectedItem;

			// refresh the list
			Process[] processList = Process.GetProcesses();
			listBoxProcesses.Items.Clear();
			foreach (Process process in processList)
			{
				if (process.MainWindowHandle == null || process.MainWindowHandle == IntPtr.Zero) continue;
				if (process.MainWindowTitle == null || process.MainWindowTitle == "") continue;
				listBoxProcesses.Items.Add(process);
			}
			listBoxProcesses.Sorted = true;
			listBoxProcesses.DisplayMember = "MainWindowTitle";

			// reselect the previously selected item (if it still exists)
			if (previouslySelectedProcess == null) return;
			foreach (object item in listBoxProcesses.Items)
			{
				Process process = (Process)item;
				if (process.MainWindowHandle == previouslySelectedProcess.MainWindowHandle)
				{
					listBoxProcesses.SelectedItem = process;
					return;
				}
			}

			if (listBoxProcesses.SelectedIndex == -1) buttonMaximize.Enabled = false;
		}

		private Rectangle MoveWindow()
		{
			Rectangle windowRectangle = new Rectangle();

			// show the placeholder window
			PlaceholderWindow placeholderWindow = new PlaceholderWindow();
			placeholderWindow.ShowDialog();

			// calculate the placeholder window's position/size
			if (placeholderWindow.WindowState == FormWindowState.Maximized)
			{
				int borderWidth = (placeholderWindow.DesktopBounds.Width - placeholderWindow.ClientSize.Width) / 2;
				int borderHeight = (placeholderWindow.DesktopBounds.Height - placeholderWindow.ClientSize.Height + SystemInformation.CaptionHeight) / 2;

				windowRectangle.X = placeholderWindow.DesktopBounds.X + borderWidth;
				windowRectangle.Y = placeholderWindow.DesktopBounds.Y + borderHeight;
				windowRectangle.Width = placeholderWindow.ClientSize.Width;
				windowRectangle.Height = placeholderWindow.ClientSize.Height + SystemInformation.CaptionHeight;
			}
			else
			{
				windowRectangle = placeholderWindow.DesktopBounds;
			}

			return windowRectangle;
		}

		private void listBoxProcesses_SelectedIndexChanged(object sender, EventArgs e)
		{
			// disable the button if nothing is selected, enable it otherwise
			if (listBoxProcesses.SelectedIndex == -1)
			{
				buttonMaximize.Enabled = false;
				return;
			}
			buttonMaximize.Enabled = true;

			// change the button text depending on whether the selected window will be maximized or unmaximized
			Process process = (Process)listBoxProcesses.SelectedItem;

			// get the window style for the main window for this application
			IntPtr foundWindow = process.MainWindowHandle;
			if (foundWindow == null)
			{
				MessageBox.Show("Error: No window handle found for selected process.");
				return;
			}
			UInt32 styles = Win32.GetWindowLong(foundWindow, Win32.GWL_STYLE);
			if (styles == 0)
			{
				MessageBox.Show("Error: Selected window has no style.");
				return;
			}

			// if the window has a caption then we are maximizing
			bool maximizing = ((styles & Win32.WS_CAPTION) != 0);

			if (maximizing) buttonMaximize.Text = "Maximize";
			else buttonMaximize.Text = "Unmaximize";
		}
	}
}
