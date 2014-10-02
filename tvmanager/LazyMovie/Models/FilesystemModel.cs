using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;
using LazyMovie.Models.Interfaces;

namespace LazyMovie.Models
{
	internal class FilesystemModel : IFilesystemModel
	{
		public async Task WriteTextToFile(string filename, string text, bool replaceExisting = true)
		{
			StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;

			var file = await local.CreateFileAsync(filename,
				replaceExisting ? CreationCollisionOption.ReplaceExisting : CreationCollisionOption.OpenIfExists);

			using (var fstream = await file.OpenStreamForWriteAsync())
			using (var writer = new StreamWriter(fstream))
			{
				await writer.WriteAsync(text);
			}
		}

		public async Task<string> ReadTextFromFile(string filename)
		{
			StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;


			if (!File.Exists(string.Format(@"{0}\{1}", ApplicationData.Current.LocalFolder.Path, filename)))
			{
				return null;
			}

			using (var fstream = await local.OpenStreamForReadAsync(filename))
			using (var reader = new StreamReader(fstream))
			{

				return await reader.ReadToEndAsync();
			}
		}
	}
}
