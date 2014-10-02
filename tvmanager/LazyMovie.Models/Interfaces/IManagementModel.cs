using System;
using System.Threading.Tasks;

namespace LazyMovie.Models.Interfaces
{
	public interface IManagementModel
	{
		Task<Exception> Connect(string hostAddress);
		Task<string> Ping();
	}
}