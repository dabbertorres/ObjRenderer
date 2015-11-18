using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ObjRenderer
{
	public class RenderTab
	{
		private const float nearPlane = 1f;
		private const float farPlane = 10f;

		// 72 degrees in radians
		private const float verticalFoV = 72f * (float)Math.PI / 180f;

		private Vector3 frustumCenter;
		
		private bool glLoaded = false;

		private GLControl glControl;

		private InputHandler inputHandler;
		private bool mouseLeftDown = false;
		private bool mouseRightDown = false;
		private bool mouseMiddleDown = false;
		private int mouseLastX = -1;
		private int mouseLastY = -1;
		private float scale = 1f;

		private Mesh mesh;

		private List<Rotation> rotations;

		public readonly TabPage tabPage;

		public RenderTab(Mesh mesh, string filename)
		{
			tabPage = new TabPage(Path.GetFileNameWithoutExtension(filename));
			tabPage.AllowDrop = true;
			tabPage.ToolTipText = Path.GetFullPath(filename);

			glControl = new GLControl();
			glControl.Parent = tabPage;
			glControl.Dock = DockStyle.Fill;
			glControl.VSync = false;
			glControl.TabStop = false;
			
			// doesn't work at the moment... (OpenTK bug)
			glControl.Load += Load;

			glControl.Resize += Resize;
			glControl.Paint += Paint;

			inputHandler = new InputHandler(glControl);
			inputHandler.mouseDownListeners.Add(MouseButtons.Left, (x, y) => mouseLeftDown = true);
			inputHandler.mouseDownListeners.Add(MouseButtons.Right, (x, y) => mouseRightDown = true);
			inputHandler.mouseDownListeners.Add(MouseButtons.Middle, (x, y) => mouseMiddleDown = true);

			inputHandler.mouseUpListeners.Add(MouseButtons.Left, (x, y) => mouseLeftDown = false);
			inputHandler.mouseUpListeners.Add(MouseButtons.Right, (x, y) => mouseRightDown = false);
			inputHandler.mouseUpListeners.Add(MouseButtons.Middle, (x, y) => mouseMiddleDown = false);

			inputHandler.mouseMoved += (int x, int y) =>
			{
				if (mouseLastX != -1 && mouseLastY != -1)
				{
					if (mouseLeftDown)
					{
						int moveX = x - mouseLastX;
						int moveY = y - mouseLastY;

						float mag = (float)Math.Sqrt(moveX * moveX + moveY * moveY) / 2f;

						// vector (x, y) perpendicular to another vector is (y, x)
						rotations.Add(new Rotation(-mag, -moveY, -moveX, 0));

						glControl.Invalidate();
					}
				}

				mouseLastX = x;
				mouseLastY = y;
			};

			inputHandler.mouseWheelMoved += (int delta) =>
			{
				scale += delta / SystemInformation.MouseWheelScrollDelta * 0.1f;

				// keep scale between 0.1 - 10
				scale = Math.Min(10f, Math.Max(0.1f, scale));

				glControl.Invalidate();
			};

			this.mesh = mesh;

			rotations = new List<Rotation>();
        }

		private void Load(object sender, EventArgs e)
		{
			glLoaded = true;

			frustumCenter = new Vector3();

			Resize(sender, e);
		}

		private void Paint(object sender, PaintEventArgs e)
		{
			if (!glLoaded)
			{
				Load(sender, e);
			}

			// activate this context if it isn't already
			glControl.MakeCurrent();

			GL.ClearColor(0f, 0f, 0f, 1f);
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			// transformations
			GL.MatrixMode(MatrixMode.Modelview);
			GL.LoadIdentity();

			GL.Scale(scale, scale, 1);
			GL.Translate(0, 0, scale);

			GL.Translate(frustumCenter);
			//GL.Translate(mesh.boundingBox.center);

			foreach (Rotation rot in rotations)
			{
				GL.Rotate(rot.angle, rot.axis);
			}

			GL.EnableClientState(ArrayCap.VertexArray);

			// draw mesh
			var meshVertices = mesh.vertices.ToArray();
			GL.VertexPointer(3, VertexPointerType.Float, 0, meshVertices);
			GL.Color4(0.5f, 0.5f, 0.5f, 1f);

			var meshVertexIndices = mesh.vertexIndices.ToArray();
            GL.DrawElements(PrimitiveType.Triangles, mesh.vertexIndices.Count, DrawElementsType.UnsignedInt, meshVertexIndices);

			// draw bounding box
			var bbVertices = mesh.boundingBox.vertices.ToArray();
			GL.VertexPointer(3, VertexPointerType.Float, 0, bbVertices);
			GL.Color4(BoundingBox.drawColor);
			
			var bbVertexIndices = mesh.vertexIndices.ToArray();
			GL.DrawElements(PrimitiveType.Lines, mesh.boundingBox.indices.Count, DrawElementsType.UnsignedInt, bbVertexIndices);

			// cleanup
			GL.DisableClientState(ArrayCap.VertexArray);

			// we're double-buffered
			glControl.SwapBuffers();
		}

		private void Resize(object sender, EventArgs e)
		{
			if (!glLoaded)
			{
				return;
			}

			glControl.MakeCurrent();
			GL.Viewport(0, 0, glControl.Width, glControl.Height);

			GL.MatrixMode(MatrixMode.Projection);
			GL.LoadIdentity();

			float tangent = (float)Math.Tan(verticalFoV / 2f);
			float aspect = (float)glControl.Width / glControl.Height;

			float height = nearPlane * tangent;
			float width = height * aspect;
			
			GL.Frustum(-width, width, -height, height, nearPlane, farPlane + mesh.boundingBox.Length);

			frustumCenter.Z = -(farPlane - nearPlane) / 2f - nearPlane;

			glControl.Invalidate();
        }
	}
}
