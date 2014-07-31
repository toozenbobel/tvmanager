using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using HostTool.Tools;

namespace HostTool.Init
{
	public static class ServicesStartup
	{
		public static void Init()
		{
			InitServices();
		}

		private static void InitServices()
		{
			var serviceManager = IoC.Get<ServicesHostingManager>();
			serviceManager.StartServices();
		}
	}
}
