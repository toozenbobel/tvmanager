using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactivity
{
    public interface ICommunicationService
    {
	    Task<DefaultResponse> PostCommand(int commandId);
	    void Initialize(string targetHost, int targetPort);
    }
}
