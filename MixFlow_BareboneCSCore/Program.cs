using System;
using System.Runtime;
using MixFlow_BareboneCSCore.Source.Properties;
using MixFlow_BareboneCSCore.Source.Tools;


namespace MixFlow_BareboneCSCore
{
	class Program
	{
		static int Main(string[] args)
		{
			
			#region initSubsystems
			//Config
			if (!System.IO.Directory.Exists(Config.ConfigPathDefault))
			{
				System.IO.Directory.CreateDirectory(Config.ConfigPathDefault);
			}

			ConfigJson configMain = new ConfigJson(Config.ConfigPathMain);
	
			string testVar = "testVal";

			#endregion //initSubsystems
			

			Console.WriteLine("Hello World!");
			Console.WriteLine(Config.ConfigPathDefault);

			
			configMain.SetStr(nameof(testVar), testVar);
			configMain.SaveConfig();
			Console.WriteLine(configMain.GetStr(testVar));
			

			Console.ReadKey(true);
			return 0;
		}
	}
}