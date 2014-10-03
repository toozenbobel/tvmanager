using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LazyMovie.Entities;

namespace LazyMovie.Models.Interfaces
{
	public interface IConnectionModel
	{
		Task<bool> TryConnectToSavedHost();
		Task<bool> Connect(string host);
		Task<SavedHost> GetLastHost();
	}
}
