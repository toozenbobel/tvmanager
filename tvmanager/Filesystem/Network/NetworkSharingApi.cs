using System;
using System.Runtime.InteropServices;

namespace Filesystem.Network
{
	internal class NetworkSharingApi
	{
		/// <summary>Enumerate shares (NT)</summary>
		[DllImport("netapi32", CharSet = CharSet.Unicode)]
		public static extern int NetShareEnum(string lpServerName, int dwLevel,
			out IntPtr lpBuffer, int dwPrefMaxLen, out int entriesRead,
			out int totalEntries, ref int hResume);

		/// <summary>Maximum path length</summary>
		public const int MAX_PATH = 260;
		/// <summary>No error</summary>
		public const int NO_ERROR = 0;
		/// <summary>Access denied</summary>
		public const int ERROR_ACCESS_DENIED = 5;
		/// <summary>Access denied</summary>
		public const int ERROR_WRONG_LEVEL = 124;
		/// <summary>More data available</summary>
		public const int ERROR_MORE_DATA = 234;
		/// <summary>Not connected</summary>
		public const int ERROR_NOT_CONNECTED = 2250;
		/// <summary>Level 1</summary>
		public const int UNIVERSAL_NAME_INFO_LEVEL = 1;
		/// <summary>Max extries (9x)</summary>
		public const int MAX_SI50_ENTRIES = 20;

		/// <summary>Share information, NT, level 2</summary>
		/// <remarks>
		/// Requires admin rights to work. 
		/// </remarks>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct SHARE_INFO_2
		{
			[MarshalAs(UnmanagedType.LPWStr)]
			public string NetName;
			public ShareType ShareType;
			[MarshalAs(UnmanagedType.LPWStr)]
			public string Remark;
			public int Permissions;
			public int MaxUsers;
			public int CurrentUsers;
			[MarshalAs(UnmanagedType.LPWStr)]
			public string Path;
			[MarshalAs(UnmanagedType.LPWStr)]
			public string Password;
		}

		/// <summary>Share information, NT, level 1</summary>
		/// <remarks>
		/// Fallback when no admin rights.
		/// </remarks>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct SHARE_INFO_1
		{
			[MarshalAs(UnmanagedType.LPWStr)]
			public string NetName;
			public ShareType ShareType;
			[MarshalAs(UnmanagedType.LPWStr)]
			public string Remark;
		}

		[DllImport("netapi32")]
		public static extern int NetApiBufferFree(IntPtr lpBuffer);
	}
}