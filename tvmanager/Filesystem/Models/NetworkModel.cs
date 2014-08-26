using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CommonContracts.Models;
using Filesystem.Network;

namespace Filesystem.Models
{
	public class NetworkModel : INetworkModel
	{
		private List<string> _lanMachines = new List<string>();

		public IEnumerable<string> GetLanMachines()
		{
			return _lanMachines;
		}

		public async void RefreshLanMachines()
		{
			await InitLanCache();
		}

		public async void Init()
		{
			await InitLanCache();
		}

		private async Task InitLanCache()
		{
			await Task.Factory.StartNew(() =>
			{
				var connector = new LanMachinesConnector();
				var machines = connector.GetMachines();

				_lanMachines = machines.ToList();
			});
		}
	}
}
