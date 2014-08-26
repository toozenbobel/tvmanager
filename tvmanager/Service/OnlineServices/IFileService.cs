using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Service.OnlineServices
{
	[ServiceContract]
	public interface IFileService
	{
		[OperationContract]
		List<string> GetRemoteSources();

		[OperationContract]
		List<string> GetFiles(string path);

		[OperationContract]
		List<string> GetShares(string machineName);
	}
}
