using System;
using System.Runtime.InteropServices;

namespace MixFlow.Properties
{
	namespace Properties
	{
		public static class ProjectProperties
		{                                   //Project Properties
			public static string            ProjectName			{ get; }					= "MixFlow";
		}

		public static class ConfigPaths
		{                                    //OS-Specific Properties
			public static string            DirectorySpacer		{ get; }					= SetDirSpacing();
 
											//Config File Paths
			public static string			AppDataPath			{ get; }					= Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + DirectorySpacer + ProjectProperties.ProjectName + DirectorySpacer;

			public static string            ConfigDir			{ get; set; }				= AppDataPath + "config" + DirectorySpacer;
			public static string            ConfigPathMain      { get; private set; }		= ConfigDir + "Main.json";
			public static string            ConfigPathDB		{ get; private set; }		= ConfigDir + "Database.json";
			public static string			ConfigPathTest		{ get; private set; }		= ConfigDir + "Test.json";
 
 
			//Methods
			private static string			SetDirSpacing()
			{
				string spacer = null;
 
				if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
				{
					spacer = "\\";
				}
				else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
				{
					spacer = "/";
				}
 
				return spacer;
			}
		}

		public static class ConfigDatabase
		{
			public static string			DBDir				{ get; set; }		= ConfigPaths.AppDataPath + "database" + ConfigPaths.DirectorySpacer;
		}
	}
}
 