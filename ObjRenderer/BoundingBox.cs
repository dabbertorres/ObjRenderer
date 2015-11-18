using OpenTK;
using OpenTK.Graphics;

using System.Collections.Generic;

namespace ObjRenderer
{
	public class BoundingBox
	{
		public static readonly Color4 drawColor = new Color4(1f, 0f, 0f, 1f);

		// order: left-bottom-back, right-bottom-back, left-top-back, right-top-back
		//		  left-bottom-front, right-bottom-front, left-top-front, right-top-front
		// using OpenGL coordinates: x -> right, y -> up, z -> out of screen
		public readonly List<Vector4> vertices;
		public readonly List<uint> indices;

		public readonly Vector4 center;

		public float Length
		{
			get { return vertices[7].Z - vertices[0].Z; }
		}

		public float Width
		{
			get { return vertices[7].X - vertices[0].X; }
		}

		public float Height
		{
			get { return vertices[7].Y - vertices[0].Y; }
		}

		public BoundingBox(Vector4 min, Vector4 max)
		{
			// 12 pairs of vertices to make a cube
			vertices = new List<Vector4>(new Vector4[8]);
			indices = new List<uint>(24)
			{
				// from left-bottom-back
				0, 1,
				0, 2,
				0, 4,
				// from right-top-front
				7, 3,
				7, 6,
				7, 5,
				// from right-bottom-back
				1, 5,
				1, 3,
				// from left-top-back
				2, 3,
				2, 6,
				// from left-bottom-front
				4, 5,
				4, 6,
			};

			Vector4 diag;
			Vector4.Subtract(ref max, ref min, out diag);

			Vector4 xd = new Vector4(diag.X, 0, 0, 1);
			Vector4 yd = new Vector4(0, diag.Y, 0, 1);
			Vector4 zd = new Vector4(0, 0, diag.Z, 1);

			vertices[0] = min;

			Vector4 temp;
			Vector4.Add(ref min, ref xd, out temp);
			vertices[1] = temp;

            Vector4.Add(ref min, ref yd, out temp);
			vertices[2] = temp;

            Vector4.Subtract(ref max, ref zd, out temp);
			vertices[3] = temp;

            Vector4.Add(ref min, ref zd, out temp);
			vertices[4] = temp;

            Vector4.Subtract(ref max, ref yd, out temp);
			vertices[5] = temp;

            Vector4.Subtract(ref max, ref xd, out temp);
			vertices[6] = temp;

			vertices[7] = max;
			
			Vector4.Divide(ref diag, 2, out temp);
            Vector4.Add(ref min, ref temp, out center);
		}
	}
}
