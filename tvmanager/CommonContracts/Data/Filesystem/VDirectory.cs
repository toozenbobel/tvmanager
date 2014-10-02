using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CommonContracts.Data.Filesystem
{
	[DataContract]
	public class VDirectory
	{
		[DataMember]
		public string Name { get; set; }
	}
}
