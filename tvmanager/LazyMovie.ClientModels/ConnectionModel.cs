using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LazyMovie.Models.Interfaces;

namespace LazyMovie.ClientModels
{
    public class ConnectionModel : IConnectionModel
    {
	    public Task Connect(string host)
	    {
		    
	    }

	    protected Task<bool> IsHostSaved()
	    {
		    
	    }

	    public async Task<bool> TryConnectToSavedHost()
	    {
			if (await IsHostSaved())
		    {
			    
		    }
			else
			{
				return false;
			}
	    }
    }
}
