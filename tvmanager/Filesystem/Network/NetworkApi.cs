using System;
using System.Runtime.InteropServices;

namespace Filesystem.Network
{
	public class NetworkApi
	{
		[DllImport("Netapi32.dll", EntryPoint = "NetServerEnum")]
		public static extern Int32 NetServerEnum(
			[MarshalAs(UnmanagedType.LPWStr)] String serverName,
			Int32 level,
			out IntPtr bufferPtr,
			UInt32 prefMaxLen,
			ref Int32 entriesRead,
			ref Int32 totalEntries,
			UInt32 serverType,
			[MarshalAs(UnmanagedType.LPWStr)] String domain,
			IntPtr handle);

		[DllImport("Netapi32.dll", EntryPoint = "NetApiBufferFree")]
		public static extern UInt32 NetApiBufferFree(IntPtr buffer);
	}
}
