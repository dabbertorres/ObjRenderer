using System;
using System.Collections.Generic;
using OpenTK;
using System.Windows.Forms;

namespace ObjRenderer
{
	public class InputHandler
	{
		public delegate void KeyPressed(Enum flags);
		public delegate void MousePressed(int x, int y);
		public delegate void MouseWheelMoved(int delta);
		public delegate void MouseMoved(int x, int y);
		public delegate void FileDropped(string file);

		public readonly Dictionary<Keys, KeyPressed> keyDownListeners;
		public readonly Dictionary<Keys, KeyPressed> keyUpListeners;

		public readonly Dictionary<MouseButtons, MousePressed> mouseDownListeners;
		public readonly Dictionary<MouseButtons, MousePressed> mouseUpListeners;

		public event MouseWheelMoved mouseWheelMoved;
		public event MouseMoved mouseMoved;
		public event FileDropped fileDropped;

		public InputHandler(GLControl glControl)
		{
			glControl.KeyDown += KeyDown;
			glControl.KeyUp += KeyUp;
			glControl.MouseDown += MouseDown;
			glControl.MouseUp += MouseUp;
			glControl.MouseWheel += MouseWheel;
			glControl.MouseMove += MouseMove;

			glControl.DragDrop += DragDrop;

			keyDownListeners = new Dictionary<Keys, KeyPressed>();
			keyUpListeners = new Dictionary<Keys, KeyPressed>();

			mouseDownListeners = new Dictionary<MouseButtons, MousePressed>();
			mouseUpListeners = new Dictionary<MouseButtons, MousePressed>();
		}

		private void KeyDown(object sender, KeyEventArgs e)
		{
			if (keyDownListeners.ContainsKey(e.KeyCode))
			{
				keyDownListeners[e.KeyCode].Invoke(e.Modifiers);
			}

			e.Handled = true;
		}

		private void KeyUp(object sender, KeyEventArgs e)
		{
			if (keyUpListeners.ContainsKey(e.KeyCode))
			{
				keyUpListeners[e.KeyCode].Invoke(e.Modifiers);
			}

			e.Handled = true;
		}

		private void MouseDown(object sender, MouseEventArgs e)
		{
			if (mouseDownListeners.ContainsKey(e.Button))
			{
				mouseDownListeners[e.Button].Invoke(e.X, e.Y);
			}
		}

		private void MouseUp(object sender, MouseEventArgs e)
		{
			if (mouseUpListeners.ContainsKey(e.Button))
			{
				mouseUpListeners[e.Button].Invoke(e.X, e.Y);
			}
		}

		private void MouseWheel(object sender, MouseEventArgs e)
		{
			if (mouseWheelMoved.GetInvocationList().Length != 0)
			{
				mouseWheelMoved.Invoke(e.Delta);
			}
		}

		private void MouseMove(object sender, MouseEventArgs e)
		{
			if(mouseMoved.GetInvocationList().Length != 0)
			{
				mouseMoved.Invoke(e.X, e.Y);
			}
		}

		private void DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				fileDropped.Invoke((string)e.Data.GetData(DataFormats.FileDrop));
			}
        }
	}
}
