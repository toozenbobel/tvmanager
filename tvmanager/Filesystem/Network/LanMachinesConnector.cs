using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Filesystem.Network
{
	public class LanMachinesConnector
	{
		public const UInt32 SUCCESS = 0;
		public const UInt32 FAIL = 234;
		public const UInt32 MAX_PREFERRED_LENGTH = 0xFFFFFFFF;

		enum ServerTypes : uint
		{
			WorkStation = 0x00000001,
			Server = 0x00000002
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct MachineInfo
		{
			[MarshalAs(UnmanagedType.U4)]
			public UInt32 platformId;

			[MarshalAs(UnmanagedType.LPWStr)]
			public String serverName;
		}

		public enum Platform
		{
// ReSharper disable InconsistentNaming
			PLATFORM_ID_DOS = 300,
			PLATFORM_ID_OS2 = 400,
			PLATFORM_ID_NT = 500,
			PLATFORM_ID_OSF = 600,
			PLATFORM_ID_VMS = 700
// ReSharper restore InconsistentNaming
		}

		public IEnumerable<string> GetMachines()
		{
			try
			{
				List<string> toRet = new List<string>();

				IntPtr buffer = new IntPtr();
				int totalEntries = 0;
				int entriesRead = 0;
				int result;

				result = NetworkApi.NetServerEnum(null, 100, out buffer, MAX_PREFERRED_LENGTH, ref entriesRead, ref totalEntries, (uint)ServerTypes.WorkStation, null, IntPtr.Zero);

				MachineInfo machineInfo;

				if (result != FAIL)
				{
					for (int i = 0; i < entriesRead; ++i)
					{
						machineInfo = (MachineInfo)Marshal.PtrToStructure(buffer, typeof(MachineInfo));

						toRet.Add(machineInfo.serverName);
						buffer = (IntPtr)((ulong)buffer + (ulong)Marshal.SizeOf(machineInfo));
					}

//					NetworkApi.NetApiBufferFree(buffer);
				}

				return toRet;

			}
			catch (Exception e)
			{
				return null;
			}

		}
	}
}