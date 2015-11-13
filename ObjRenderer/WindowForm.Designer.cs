namespace ObjRenderer
{
	partial class WindowForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.menuStripFile = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStripFileOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStripFileExit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStripHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStripHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.renderTabsControl = new System.Windows.Forms.TabControl();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.menuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripFile,
            this.menuStripHelp});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(676, 24);
			this.menuStrip.TabIndex = 1;
			this.menuStrip.Text = "menuStrip";
			// 
			// menuStripFile
			// 
			this.menuStripFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripFileOpen,
            this.menuStripFileExit});
			this.menuStripFile.Name = "menuStripFile";
			this.menuStripFile.Size = new System.Drawing.Size(37, 20);
			this.menuStripFile.Text = "File";
			// 
			// menuStripFileOpen
			// 
			this.menuStripFileOpen.Name = "menuStripFileOpen";
			this.menuStripFileOpen.Size = new System.Drawing.Size(112, 22);
			this.menuStripFileOpen.Text = "Open...";
			this.menuStripFileOpen.Click += new System.EventHandler(this.OpenFile);
			// 
			// menuStripFileExit
			// 
			this.menuStripFileExit.Name = "menuStripFileExit";
			this.menuStripFileExit.Size = new System.Drawing.Size(112, 22);
			this.menuStripFileExit.Text = "Exit";
			this.menuStripFileExit.Click += new System.EventHandler(this.ExitClicked);
			// 
			// menuStripHelp
			// 
			this.menuStripHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripHelpAbout});
			this.menuStripHelp.Name = "menuStripHelp";
			this.menuStripHelp.Size = new System.Drawing.Size(44, 20);
			this.menuStripHelp.Text = "Help";
			// 
			// menuStripHelpAbout
			// 
			this.menuStripHelpAbout.Name = "menuStripHelpAbout";
			this.menuStripHelpAbout.Size = new System.Drawing.Size(107, 22);
			this.menuStripHelpAbout.Text = "About";
			// 
			// openFileDialog
			// 
			this.openFileDialog.DefaultExt = "obj";
			this.openFileDialog.FileName = "openFileDialog";
			this.openFileDialog.Filter = "OBJ files|*.obj";
			this.openFileDialog.Title = "Open OBJ File";
			// 
			// renderTabsControl
			// 
			this.renderTabsControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.renderTabsControl.HotTrack = true;
			this.renderTabsControl.ItemSize = new System.Drawing.Size(75, 18);
			this.renderTabsControl.Location = new System.Drawing.Point(0, 24);
			this.renderTabsControl.Name = "renderTabsControl";
			this.renderTabsControl.SelectedIndex = 0;
			this.renderTabsControl.Size = new System.Drawing.Size(676, 434);
			this.renderTabsControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
			this.renderTabsControl.TabIndex = 2;
			this.renderTabsControl.TabStop = false;
			// 
			// toolTip
			// 
			this.toolTip.ShowAlways = true;
			// 
			// WindowForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(676, 458);
			this.Controls.Add(this.renderTabsControl);
			this.Controls.Add(this.menuStrip);
			this.DoubleBuffered = true;
			this.MainMenuStrip = this.menuStrip;
			this.Name = "WindowForm";
			this.Text = "OBJ Renderer";
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem menuStripFile;
		private System.Windows.Forms.ToolStripMenuItem menuStripFileOpen;
		private System.Windows.Forms.ToolStripMenuItem menuStripFileExit;
		private System.Windows.Forms.ToolStripMenuItem menuStripHelp;
		private System.Windows.Forms.ToolStripMenuItem menuStripHelpAbout;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.TabControl renderTabsControl;
		private System.Windows.Forms.ToolTip toolTip;
	}
}

