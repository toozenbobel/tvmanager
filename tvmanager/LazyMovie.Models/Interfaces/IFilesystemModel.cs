using System.Threading.Tasks;

namespace LazyMovie.Models.Interfaces
{
	public interface IFilesystemModel
	{
		Task WriteTextToFile(string filename, string text, bool replaceExisting = true);
		Task<string> ReadTextFromFile(string filename);
	}
}