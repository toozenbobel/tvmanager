using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using CommonContracts.Data.Filesystem;

namespace Service.OnlineServices
{
	[ServiceContract]
	public interface IFileService
	{
		[OperationContract]
		List<string> GetRemoteSources();

		[OperationContract]
		FileListing GetFiles(string path);

		[OperationContract]
		List<string> GetShares(string machineName);
	}
}
