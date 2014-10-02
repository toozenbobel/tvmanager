using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyMovie.Models.Interfaces
{
	public interface IConnectionModel
	{
		Task<bool> TryConnectToSavedHost();
	}
}
