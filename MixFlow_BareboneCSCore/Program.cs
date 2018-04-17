using System;
using System.Reflection;
using MixFlow_BareboneCSCore.Source.Properties;
using MixFlow_BareboneCSCore.Source.Tools;
using MixFlow_BareboneCSCore.Source.Menu;


namespace MixFlow_BareboneCSCore
{
	class Program
	{
		public static Version version = Assembly.GetExecutingAssembly().GetName().Version;

		static int Main(string[] args)
		{
			#region initSubsystems

			//Config
			ConfigJson configMain = new ConfigJson(ConfigPaths.ConfigPathMain);

			#endregion //initSubsystems

			bool resume = true;
			byte feature;


			Menu.DisplaySplash();

			while (resume)
			{
				Menu.DisplayMainMenu();

				feature = Menu.SelectFromMainMenu();

				switch (feature)
				{
					case 255:
						resume = false;

						break;
					case 101:
						Menu.DisplayMessageWIP();
						break;
					case 102:
						Menu.DisplayMessageWIP();
						break;

					case 1:
						Menu.DisplayMessageWIP();
						break;
					case 2:
						Menu.DisplayMessageWIP();
						break;
					case 3:
						Source.Features.Features.FeatureConfig();
						break;
				}
				Console.Clear();
			}

			Console.ReadKey(true);
			return 0;
		}
	}
}