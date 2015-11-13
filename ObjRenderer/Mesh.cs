using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;

namespace ObjRenderer
{
	public class Mesh
	{
		public readonly Vector3[] vertices;
		public readonly Color4[] colors;
		public readonly uint[] indices;

		public readonly BoundingBox boundingBox;

		public Mesh(List<Vector3> vertices, List<Color4> colors, List<uint> indices)
		{
			this.vertices = vertices.ToArray();
			this.colors = colors.ToArray();
			this.indices = indices.ToArray();

			Vector3 min = vertices[0];
			Vector3 max = vertices[0];
			
			foreach (Vector3 v in vertices)
			{
				if (v.X <= min.X)
				{
					min.X = v.X;
				}
				else if (v.X >= max.X)
				{
					max.X = v.X;
				}
				
				if (v.Y <= min.Y)
				{
					min.Y = v.Y;
				}
				else if (v.Y >= max.Y)
				{
					max.Y = v.Y;
				}

				if (v.Z <= min.Z)
				{
					min.Z = v.Z;
				}
				else if (v.Z >= max.Z)
				{
					max.Z = v.Z;
				}
			}

			boundingBox = new BoundingBox(min, max);
        }
	}
}
