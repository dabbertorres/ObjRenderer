using System.Collections.Generic;
using System.IO;
using OpenTK;
using OpenTK.Graphics;

namespace ObjRenderer
{
	public static class ObjLoader
	{
		public static Mesh Load(string path)
		{
			List<Vector3> vertices = new List<Vector3>();
			List<Color4> colors = new List<Color4>();
			List<uint> indices = new List<uint>();

            if (!File.Exists(path))
			{
				throw new FileNotFoundException("Unable to open \"" + path + "\", does not exist.");
			}

			using (StreamReader streamReader = new StreamReader(path))
			{
				while (!streamReader.EndOfStream)
				{
					string[] words = streamReader.ReadLine().ToLower().Split(' ');
					switch (words[0])
					{
						// vertex
						case "v":
							vertices.Add(new Vector3(float.Parse(words[1]), float.Parse(words[2]), float.Parse(words[3])));
							break;
						
						// face
						case "f":
							// subtract 1 - vertex indices start from 1, not 0
							indices.Add(uint.Parse(words[1]) - 1);
							indices.Add(uint.Parse(words[2]) - 1);
							indices.Add(uint.Parse(words[3]) - 1);
							break;
						
						// color
						case "c":
							if (words.Length > 4)
							{
								// rgba
								colors.Add(new Color4(float.Parse(words[1]), float.Parse(words[2]), float.Parse(words[3]), float.Parse(words[4])));
							}
							else
							{
								// rgb
								colors.Add(new Color4(float.Parse(words[1]), float.Parse(words[2]), float.Parse(words[3]), 1f));
							}
							break;

						default:
							break;
					}
				}
			}

			return new Mesh(vertices, colors, indices);
		}
	}
}
