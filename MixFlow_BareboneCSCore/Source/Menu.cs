using System;


namespace MixFlow_BareboneCSCore.Source.Menu
{

	static class Menu
	{

		

		public static void DisplaySplash()
		{
			string versionLine = "||                                                             v";

			versionLine = versionLine.Remove(3, (Program.version.ToString().Length)); //Removes excess whitespace for version number.

			Console.Write(
				"===================================================================\n" +
				versionLine + Program.version +									" ||\n" +
				"||                                                               ||\n" +
				"||                                                               ||\n" +
				"||                            MixFlow                            ||\n" +
				"||                                                               ||\n" +
				"|| By Nodsoft ES                               Copyright Control ||\n" +
				"|| nodsoft.net                               All Rights Reserved ||\n" +
				"===================================================================\n"
				);
		}

		public static void DisplayMainMenu()
		{
			Console.Write(
				"===================================================================\n" +
				"|| 1. Check Song Database                            S. Settings ||\n" +
				"|| 2. Import Song(s) to DB                                       ||\n" +
				"|| 3. Config Test                                                ||\n" +
				"||                                                               ||\n" +
				"||                                                               ||\n" +
				"||                                                   A. About    ||\n" +
				"||                                                   Q. Quit     ||\n" +
				"===================================================================\n"
				);


		}

		public static void DisplayMessageWIP()
		{
			Console.WriteLine("Feature currently in Work in Progress.");
			Console.ReadKey(false);
		}

		public static byte SelectFromMainMenu()
		{
			byte featureSelected = 0;
			char selection;

			while (featureSelected == 0)
			{
				selection = Console.ReadKey(true).KeyChar;
				Console.WriteLine();

				switch (selection.ToString().ToLower())
				{
					case "q":
						featureSelected = 255;
						break;

					case "s":
						featureSelected = 101;
						break;

					case "a":
						featureSelected = 102;
						break;

					case "1":
						featureSelected = 1;
						break;

					case "2":
						featureSelected = 2;
						break;

					case "3":
						featureSelected = 3;
						break;

					default:
						break;
				}
			}

			return featureSelected;
		}
	}
}