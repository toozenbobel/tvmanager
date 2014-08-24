using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonContracts.Models
{
	public interface IProcessModel
	{
		void ActivatePlayer();
		void ClosePlayer();
	}
}
