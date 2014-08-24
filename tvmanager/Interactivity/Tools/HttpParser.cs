using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Interactivity.Tools
{
	public class MpcVariables
	{
		public string FilePath { get; set; }
		public int State { get; set; }
		public string StateString { get; set; }
		public long Position { get; set; }
		public string PositionString { get; set; }
		public long Duration { get; set; }
		public string DurationStrging { get; set; }
		public int VolumeLevel { get; set; }
		public int Muted { get; set; }
	}

	internal class HttpParser
	{
		private void FillVariable<T>(out T variable, HtmlNode node, Func<string, T> converter)
		{
			variable = node != null ? converter(node.InnerText) : default(T);
		}

		public void ParseVariables(string responseString)
		{
			MpcVariables result = new MpcVariables();

			HtmlDocument document = new HtmlDocument();
			document.LoadHtml(responseString);

			string filePath;
			FillVariable(out filePath, document.GetElementbyId("filepath"), x => x);

		}
	}
}
