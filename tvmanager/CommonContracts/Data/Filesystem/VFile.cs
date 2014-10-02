using System;
using System.IO;
using System.Runtime.Serialization;

namespace CommonContracts.Data.Filesystem
{
	[DataContract]
	public class VFile
	{
		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public DateTime Created { get; set; }

		[DataMember]
		public long Size { get; set; }

		[DataMember]
		public string Path { get; set; }

		[DataMember]
		public string Extension { get; set; }

		public static VFile FromPath(string path)
		{
			var result = new VFile();

			var info = new FileInfo(path);
			result.Created = info.CreationTime;
			result.Size = info.Length;
			result.Name = info.Name;
			result.Path = path;
			result.Extension = info.Extension;

			return result;
		}
	}
}