using KeePass.Plugins;

namespace PatternPass
{
	/// <summary>
	/// Wraps some of the KeePass interface functions so they are more easily accessible and branded with the plugin info.
	/// </summary>
	public static class Interface
	{
		private static IPluginHost _host;

		private static bool Initialized { get; set; }

		public static void Init(IPluginHost host)
		{
			if (Initialized) return;

			_host = host;

			Initialized = true;
		}

		/// <summary>
		/// Updates the UI status along the bottom of the window in KeePass with <paramref name="message" />.
		/// </summary>
		/// <param name="message">The message to update the status with.</param>
		public static void UpdateStatus(string message)
		{
			_host.MainWindow.SetStatusEx("PatternPass: " + message);
		}
	}
}