using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Filesystem.Network
{
	public class SharesConnector
	{
		public List<Share> GetShares(string machineName)
		{
			if (machineName == null)
				return null;

			machineName = machineName.ToUpper();

			return GetSharesList(machineName);
		}

		private List<Share> GetSharesList(string machineName)
		{
			List<Share> toRet = new List<Share>();

			int level = 2;
			IntPtr pBuffer = IntPtr.Zero;
			int entriesRead, totalEntries, hResume = 0;

			try
			{
				int netShareEnumResult = NetworkSharingApi.NetShareEnum(machineName, level, out pBuffer, -1, out entriesRead,
					out totalEntries, ref hResume);

				if (netShareEnumResult == NetworkSharingApi.ERROR_ACCESS_DENIED)
				{
					//Need admin for level 2, drop to level 1
					level = 1;
					netShareEnumResult = NetworkSharingApi.NetShareEnum(machineName, level, out pBuffer, -1, out entriesRead,
						out totalEntries, ref hResume);
				}

				if (netShareEnumResult == NetworkSharingApi.NO_ERROR && entriesRead > 0)
				{
					Type sharingType = level == 2 ? typeof (NetworkSharingApi.SHARE_INFO_2) : typeof (NetworkSharingApi.SHARE_INFO_1);
					int offset = Marshal.SizeOf(sharingType);

					for (int iShare = 0, lpItem = pBuffer.ToInt32(); iShare < entriesRead; iShare++, lpItem += offset)
					{
						IntPtr pItem = new IntPtr(lpItem);

						if (level == 1)
						{
							var si = (NetworkSharingApi.SHARE_INFO_1) Marshal.PtrToStructure(pItem, sharingType);
							toRet.Add(new Share(machineName, si.NetName, string.Empty, si.ShareType, si.Remark));
						}
						else
						{
							var si = (NetworkSharingApi.SHARE_INFO_2) Marshal.PtrToStructure(pItem, sharingType);
							toRet.Add(new Share(machineName, si.NetName, si.Path, si.ShareType, si.Remark));
						}
					}
				}
			}
			finally
			{
				// Clean up buffer allocated by system
				if (IntPtr.Zero != pBuffer)
					NetworkSharingApi.NetApiBufferFree(pBuffer);
			}

			return toRet;
		}
	}
}
