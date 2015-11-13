using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ObjRenderer
{
	public partial class WindowForm : Form
	{
		private List<RenderTab> renderTabs;
		
		public WindowForm()
		{
			InitializeComponent();

			renderTabs = new List<RenderTab>();
        }

		private void OpenFile(object sender, EventArgs e)
		{
			if(openFileDialog.ShowDialog() == DialogResult.OK)
			{
				Mesh newMesh = ObjLoader.Load(openFileDialog.FileName);

				renderTabs.Add(new RenderTab(newMesh, openFileDialog.FileName));
				renderTabsControl.TabPages.Add(renderTabs[renderTabs.Count - 1].tabPage);
				toolTip.SetToolTip(renderTabs[renderTabs.Count - 1].tabPage, "RenderTab");
			}
		}

		private void ExitClicked(object sender, EventArgs e)
		{
			Close();
		}
	}
}
