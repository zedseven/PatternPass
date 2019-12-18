using System;
using KeePass.Plugins;
using PatternPass.Properties;
using System.Drawing;
using System.Windows.Forms;
using KeePass.Util;

namespace PatternPass
{
	/// <summary>
	/// A KeePass plugin that allows storage and viewing of pattern-based passwords (like the Android lock-screen).
	/// </summary>
	public sealed class PatternPassExt : Plugin
	{
		private IPluginHost _host;

		public override Image SmallIcon { get { return Resources.MenuIcon; } }

		public override string UpdateUrl { get { return "https://ztdp.ca/utility/keepass-plugins-ztdp.txt.gz"; } }

		public override bool Initialize(IPluginHost host)
		{
			if (host == null) return false;

			_host = host;

			//Set the version information file signature
			UpdateCheckEx.SetFileSigKey(UpdateUrl, Resources.PatternPassExt_UpdateCheckFileSigKey);

			Interface.Init(_host);

			return true;
		}

		public override void Terminate()
		{
		}

		public override ToolStripMenuItem GetMenuItem(PluginMenuType t)
		{
			if (t != PluginMenuType.Entry)
				return null;

			ToolStripMenuItem tsmi = new ToolStripMenuItem
			{
				Text = Resources.PatternPassExt_GetMenuItem_PatternPass_Plugin,
				Image = Resources.MenuIcon
			};

			ToolStripMenuItem tsmiSetup = new ToolStripMenuItem
			{
				Text = Resources.PatternPassExt_GetMenuItem_Setup_Pattern
			};
			tsmiSetup.Click += OnEntrySetupClick;

			ToolStripMenuItem tsmiDisplay = new ToolStripMenuItem
			{
				Text = Resources.PatternPassExt_GetMenuItem_Show_Pattern,
				//Enabled = _host.MainWindow.GetSelectedEntriesCount() == 1 && _host.MainWindow.GetSelectedEntry(true).Strings.Get(Constants.PatternStringName) != null
			};
			tsmiDisplay.Click += OnEntryDisplayClick;

			tsmi.DropDownItems.Add(tsmiSetup);
			tsmi.DropDownItems.Add(tsmiDisplay);

			return tsmi;
		}

		private void OnEntrySetupClick(object sender, EventArgs e)
		{
			if (_host.MainWindow.GetSelectedEntriesCount() != 1)
				return;

			PatternSetupForm patternSetupForm = new PatternSetupForm(_host.MainWindow.GetSelectedEntry(true));
			patternSetupForm.ShowDialog();
			_host.MainWindow.RefreshEntriesList();
		}

		private void OnEntryDisplayClick(object sender, EventArgs e)
		{
			if (_host.MainWindow.GetSelectedEntriesCount() != 1)
				return;

			PatternDisplayForm patternDisplayForm = new PatternDisplayForm(_host.MainWindow.GetSelectedEntry(true));
			patternDisplayForm.ShowDialog();
			_host.MainWindow.RefreshEntriesList();
		}
	}
}
