using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;

namespace HostTool.Tools
{
	[Export]
	public class TrayIconWindowManager : WindowManager
	{
		public Window MainWindow(object rootModel, object context = null)
		{
			return CreateWindow(rootModel, false, context, null);
		}
	}
}
