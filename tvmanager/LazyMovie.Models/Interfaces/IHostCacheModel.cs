using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LazyMovie.Entities;

namespace LazyMovie.Models.Interfaces
{
	public interface IHostCacheModel
	{
		Task<IEnumerable<SavedHost>> GetHosts();
		Task SaveHosts(IEnumerable<SavedHost> hosts);
	}
}
