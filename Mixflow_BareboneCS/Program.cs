using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mixflow_BareboneCS.Source;

namespace Mixflow_BareboneCS
{
	static class Program
	{
		static void Main(string[] args)
		{
		//Variables Set
		#region ProgramVariables

		#endregion

		//Init Systems
		#region ConfigManager

		Configuration configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
		KeyValueConfigurationCollection configCollection = configManager.AppSettings.Settings;

		#endregion //ConfigManager

			Menu.DisplaySplash();
			Menu.DisplayMainMenu();

		}

		static void Init()
		{

		}
	}
}
