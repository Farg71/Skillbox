using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public static class MyTools
    {
		public static async Task<string> LoadTextAsync(string filename)
		{
			//var path = CreatePathToFile(filename);
			using (StreamReader sr = System.IO.File.OpenText(filename))
				return await sr.ReadToEndAsync();
		}

	}
}
