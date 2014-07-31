using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using Service.OnlineServices;

namespace HostTool.Tools
{
	public class ServicesHostingManager
	{
		readonly List<ServiceHost> _hosts = new List<ServiceHost>();

		public ServicesHostingManager()
		{
			RegisterManagementService();
		}

		private void RegisterManagementService()
		{
			Uri baseAddress = new Uri("http://scylla:15000/ManagementService");

			var host = new ServiceHost(typeof(ManagementService), baseAddress);
			// Enable metadata publishing.
			ServiceMetadataBehavior smb = new ServiceMetadataBehavior();

			smb.HttpGetEnabled = true;
			smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
			host.Description.Behaviors.Add(smb);

			_hosts.Add(host);
		}

		public void StartServices()
		{
			_hosts.ForEach(x => x.Open());
		}

		public void StopServices()
		{
			_hosts.ForEach(x => x.Close());
		}
	}
}
