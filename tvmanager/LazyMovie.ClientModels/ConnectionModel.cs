using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LazyMovie.Entities;
using LazyMovie.Models.Interfaces;

namespace LazyMovie.ClientModels
{
	public class ConnectionModel : IConnectionModel
	{
		private const string DEFAULT_PORT = "15000";

		private readonly IHostCacheModel _hostCacheModel;
		private readonly IManagementModel _managementModel;
		private IEnumerable<SavedHost> _hosts; 

		public ConnectionModel(IHostCacheModel hostCacheModel, IManagementModel managementModel)
		{
			_hostCacheModel = hostCacheModel;
			_managementModel = managementModel;
		}

		public async Task<bool> Connect(string host)
	    {
			var toConnect = string.Format("http://{0}:{1}/ManagementService", host, DEFAULT_PORT);

			TryAddHostToCache(host);

			var error = await _managementModel.Connect(toConnect);
			if (error == null)
			{
				var pingResult = await _managementModel.Ping();
				if (pingResult == "Pong")
				{
					return true;
				}
			}

			return false;
	    }

		public async Task<SavedHost> GetLastHost()
		{
			var hosts = await _hostCacheModel.GetHosts();
			if (hosts != null)
			{
				return hosts.LastOrDefault();
			}

			return null;
		}

		protected async Task<bool> IsHostSaved()
	    {
		    _hosts = await _hostCacheModel.GetHosts();
			return _hosts != null && _hosts.Any();
	    }

	    public async Task<bool> TryConnectToSavedHost()
	    {
			if (await IsHostSaved())
			{
				var lastHost = _hosts.Last();

				return await Connect(lastHost.Host);
			}

		    return false;
	    }

		private async void TryAddHostToCache(string hostAddress)
		{
			await _hostCacheModel.TryCacheHost(hostAddress);
		}
    }
}
