using System.Runtime.Serialization;

namespace CommonContracts.Data.Filesystem
{
	[DataContract]
	public class FileListing
	{
		[DataMember]
		public VFile[] Files { get; set; }

		[DataMember]
		public VDirectory[] Directories { get; set; }
	}
}