using OpenTK;
using OpenTK.Graphics;

namespace ObjRenderer
{
	public class BoundingBox
	{
		public static readonly Color4 drawColor = new Color4(1f, 0f, 0f, 1f);

		// order: left-bottom-back, right-bottom-back, left-top-back, right-top-back
		//		  left-bottom-front, right-bottom-front, left-top-front, right-top-front
		// using OpenGL coordinates: x -> right, y -> up, z -> out of screen
		public readonly Vector3[] vertices;
		public readonly uint[] indices;

		public readonly Vector3 center;

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

		public BoundingBox(Vector3 min, Vector3 max)
		{
			// 12 pairs of vertices to make a cube
			vertices = new Vector3[8];
			indices = new uint[24]
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

			Vector3 diag;
			Vector3.Subtract(ref max, ref min, out diag);

			Vector3 xd = new Vector3(diag.X, 0, 0);
			Vector3 yd = new Vector3(0, diag.Y, 0);
			Vector3 zd = new Vector3(0, 0, diag.Z);

			vertices[0] = min;

			Vector3.Add(ref min, ref xd, out vertices[1]);
			Vector3.Add(ref min, ref yd, out vertices[2]);
			Vector3.Subtract(ref max, ref zd, out vertices[3]);
			Vector3.Add(ref min, ref zd, out vertices[4]);
			Vector3.Subtract(ref max, ref yd, out vertices[5]);
			Vector3.Subtract(ref max, ref xd, out vertices[6]);

			vertices[7] = max;

			Vector3 temp;
			Vector3.Divide(ref diag, 2, out temp);
            Vector3.Add(ref min, ref temp, out center);
		}
	}
}
