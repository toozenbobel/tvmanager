using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading.Tasks;
using Caliburn.Micro;
using CommonContracts.Data;
using CommonContracts.Data.Filesystem;
using CommonContracts.Models;
using Filesystem;
using Filesystem.Network;

namespace Service.OnlineServices
{
	public class FileService : IFileService
	{
		private readonly INetworkModel _networkModel;

		public FileService()
		{
			_networkModel = IoC.Get<INetworkModel>();
		}

		public List<string> GetRemoteSources()
		{
			var machines = _networkModel.GetLanMachines();
			if (machines != null)
				return machines.ToList();

			return null;
		}

		public List<string> GetShares(string machineName)
		{
			var sharesToRet = new List<string>();

			SharesConnector connector = new SharesConnector();
			var shares = connector.GetShares(machineName);

			sharesToRet = shares.Select(x => x.ToString()).ToList();

			return sharesToRet;
		}

		public FileListing GetFiles(string path)
		{
			var result = new FileListing();

			var directories = Directory.GetDirectories(path);
			result.Directories = directories.Select(x => new VDirectory() {Name = x}).ToArray();

			var files = Directory.GetFiles(path);
			result.Files = files.Select(VFile.FromPath).ToArray();

			return result;
		}
	}
}