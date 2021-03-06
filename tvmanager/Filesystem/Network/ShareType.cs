using System;

namespace Filesystem.Network
{
	[Flags]
	public enum ShareType
	{
		/// <summary>Disk share</summary>
		Disk = 0,
		/// <summary>Printer share</summary>
		Printer = 1,
		/// <summary>Device share</summary>
		Device = 2,
		/// <summary>IPC share</summary>
		IPC = 3,
		/// <summary>Special share</summary>
		Special = -2147483648, // 0x80000000,
	}
}