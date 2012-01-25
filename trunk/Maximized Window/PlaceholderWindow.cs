using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Maximized_Window
{
	public partial class PlaceholderWindow : Form
	{
		private const int WM_NCHITTEST = 0x84;
		private const int HTCLIENT = 0x1;
		private const int HTCAPTION = 0x2;

		public PlaceholderWindow()
		{
			InitializeComponent();
		}

		protected override void WndProc(ref Message message)
		{
			base.WndProc(ref message);

			if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
			{
				message.Result = (IntPtr)HTCAPTION;
			}
		}
	}
}
