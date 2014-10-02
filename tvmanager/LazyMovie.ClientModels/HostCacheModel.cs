using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using LazyMovie.Entities;
using LazyMovie.Models.Interfaces;
using Newtonsoft.Json;

namespace LazyMovie.ClientModels
{
	public class HostCacheModel : IHostCacheModel
	{
		private readonly IFilesystemModel _filesystemModel;
		private const string HOSTS_FILENAME = "hosts.json";

		public HostCacheModel(IFilesystemModel filesystemModel)
		{
			_filesystemModel = filesystemModel;
		}

		public async Task<IEnumerable<SavedHost>> GetHosts()
		{
			var data = await _filesystemModel.ReadTextFromFile(HOSTS_FILENAME);
			if (data != null)
			{
				try
				{
					var result = JsonConvert.DeserializeObject<IEnumerable<SavedHost>>(data);

					return result;
				}
				catch (Exception e)
				{
					Debug.WriteLine("ERROR: Failed to parse hosts.\n {0}", e.Message);
					return null;
				}
			}

			return null;
		}

		public async Task SaveHosts(IEnumerable<SavedHost> hosts)
		{
			string json = JsonConvert.SerializeObject(hosts);
			await _filesystemModel.WriteTextToFile(HOSTS_FILENAME, json);
		}
	}
}