using System.Collections.Generic;
using OpenTK;

namespace ObjRenderer
{
	public class Mesh
	{
		public readonly List<Vector4> vertices;
		public readonly List<Vector3> textureVertices;
		public readonly List<Vector3> normals;
		public readonly List<uint> vertexIndices;
		public readonly List<uint> textureIndices;
		public readonly List<uint> normalIndices;

		public readonly BoundingBox boundingBox;

		public Mesh(List<Vector4> vertices, List<Vector3> textureVertices, List<Vector3> normals,
					List<uint> vertexIndices, List<uint> textureIndices, List<uint> normalIndices)
		{
			this.vertices = vertices;
			this.textureVertices = textureVertices;
			this.normals = normals;
			this.vertexIndices = vertexIndices;
			this.textureIndices = textureIndices;
			this.normalIndices = normalIndices;

			Vector4 min = vertices[0];
			Vector4 max = vertices[0];
			
			foreach (Vector4 v in vertices)
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
