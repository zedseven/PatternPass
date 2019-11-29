using KeePass.Plugins;
using PatternPass.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace PatternPass
{
	/// <summary>
	/// A KeePass plugin that allows storage and viewing of pattern-based passwords (like the Android lock-screen).
	/// </summary>
	public sealed class PatternPassExt : Plugin
	{
		private IPluginHost _host;

		public override Image SmallIcon
		{
			get { return Resources.MenuIcon; }
		}

		public override bool Initialize(IPluginHost host)
		{
			if (host == null) return false;

			_host = host;

			return true;
		}

		public override void Terminate()
		{
		}

		public override ToolStripMenuItem GetMenuItem(PluginMenuType t)
		{
			switch (t)
			{
				case PluginMenuType.Main:
				{
					ToolStripMenuItem tsmi = new ToolStripMenuItem
					{
						Text = "PatternPass Options",
						Image = Resources.MenuIcon
					};

					return tsmi;
				}

				case PluginMenuType.Entry:
				{
					ToolStripMenuItem tsmi = new ToolStripMenuItem
					{
						Text = "PatternPass Options",
						Image = Resources.MenuIcon
					};

					return tsmi;
				}

				default:
					return null;
			}
		}
	}
}
