using System;
using System.Runtime.InteropServices;

namespace MixFlow_BareboneCSCore.Source
{
	namespace Properties
	{
		public static class Project
        {                                   //Project Properties
            public static string            ProjectName { get; } = "MixFlow";
        }
            public static class Config
        {                                    //OS-Specific Properties
            public static string            DirectorySpacer        { get; }			= SetDirSpacing();
 
                                            //Config File Paths
            public static string            ConfigPathDefault   { get; }			= Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + DirectorySpacer + Project.ProjectName + DirectorySpacer + "config" + DirectorySpacer;
            public static string            ConfigPathMain      { get; set; }		= ConfigPathDefault + "Main.json";
            public static string            ConfigPathDB		{ get; set; }		= ConfigPathDefault + "database.json";
 
 
            //Methods
            private static string SetDirSpacing()
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
    }
}
 