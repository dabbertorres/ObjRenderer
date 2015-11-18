using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjRenderer
{
	public static class MtlLoader
	{
		public static List<Material> Load(string path)
		{
			List<Material> mtls = new List<Material>();
			
			if(!File.Exists(path))
			{
				throw new FileNotFoundException("Unable to open \"" + path + "\", does not exist.");
			}

			using(StreamReader streamReader = new StreamReader(path))
			{
				while(!streamReader.EndOfStream)
				{
					string[] words = streamReader.ReadLine().Split(' ');
					switch(words[0])
					{
						case "newmtl":
							mtls.Add(new Material(words[1]));
							break;

						case "Ka":
							break;

						default:
							break;
					}
				}
			}

			return mtls;
		}
	}
}
