using System.Globalization;

namespace salkodev.hiddendata
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			//Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
			//Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");

			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			Application.Run(new FormMain());
		}
	}
}