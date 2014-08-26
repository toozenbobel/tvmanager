using System;
using System.IO;

namespace Filesystem.Network
{
	public class Share
	{
		#region Private data

		private string _server;
		private string _netName;
		private string _path;
		private ShareType _shareType;
		private string _remark;

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="Server"></param>
		/// <param name="shi"></param>
		public Share(string server, string netName, string path, ShareType shareType, string remark)
		{
			if (ShareType.Special == shareType && "IPC$" == netName)
			{
				shareType |= ShareType.IPC;
			}

			_server = server;
			_netName = netName;
			_path = path;
			_shareType = shareType;
			_remark = remark;
		}

		#endregion

		#region Properties

		/// <summary>
		/// The name of the computer that this share belongs to
		/// </summary>
		public string Server
		{
			get { return _server; }
		}

		/// <summary>
		/// Share name
		/// </summary>
		public string NetName
		{
			get { return _netName; }
		}

		/// <summary>
		/// Local path
		/// </summary>
		public string Path
		{
			get { return _path; }
		}

		/// <summary>
		/// Share type
		/// </summary>
		public ShareType ShareType
		{
			get { return _shareType; }
		}

		/// <summary>
		/// Comment
		/// </summary>
		public string Remark
		{
			get { return _remark; }
		}

		/// <summary>
		/// Returns true if this is a file system share
		/// </summary>
		public bool IsFileSystem
		{
			get
			{
				// Shared device
				if (0 != (_shareType & ShareType.Device)) return false;
				// IPC share
				if (0 != (_shareType & ShareType.IPC)) return false;
				// Shared printer
				if (0 != (_shareType & ShareType.Printer)) return false;

				// Standard disk share
				if (0 == (_shareType & ShareType.Special)) return true;

				// Special disk share (e.g. C$)
				if (ShareType.Special == _shareType && !string.IsNullOrEmpty(_netName))
					return true;
				else
					return false;
			}
		}

		/// <summary>
		/// Get the root of a disk-based share
		/// </summary>
		public DirectoryInfo Root
		{
			get
			{
				if (IsFileSystem)
				{
					if (string.IsNullOrEmpty(_server))
						if (string.IsNullOrEmpty(_path))
							return new DirectoryInfo(ToString());
						else
							return new DirectoryInfo(_path);
					else
						return new DirectoryInfo(ToString());
				}
				else
					return null;
			}
		}

		#endregion

		/// <summary>
		/// Returns the path to this share
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			if (string.IsNullOrEmpty(_server))
			{
				return string.Format(@"\\{0}\{1}", Environment.MachineName, _netName);
			}
			else
				return string.Format(@"\\{0}\{1}", _server, _netName);
		}

		/// <summary>
		/// Returns true if this share matches the local path
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public bool MatchesPath(string path)
		{
			if (!IsFileSystem) return false;
			if (string.IsNullOrEmpty(path)) return true;

			return path.ToLower().StartsWith(_path.ToLower());
		}
	}
}