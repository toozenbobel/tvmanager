using System.ComponentModel;

namespace LazyMovie.Models
{
	internal static class CallbackExtenstions
	{
		public static bool IsOk(this AsyncCompletedEventArgs args)
		{
			return args != null && args.Error == null;
		}
	}
}