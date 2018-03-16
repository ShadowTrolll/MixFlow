using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mixflow_BareboneCS.Source.Features
{
	static class Features
	{
		public static void FeatureConfig()
		{
			string accessMode, filePath, variable, value;

			string	userInput = "";
			bool	inputValid = false;


#region accessMode
			Console.WriteLine("Get or Set ?");
			while (!inputValid)
			{
				userInput = Console.ReadLine();
				userInput = userInput.ToLower();

				if (userInput != "get" || userInput!= "set")
				{
					inputValid = false;
					Console.WriteLine("Incorrect input. Please enter \"Get\" or \"Set\" (Case insensitive).");
				}
				else
				{
					inputValid = true;
				}
			}
			accessMode = userInput;
			userInput = "";
			inputValid = false;
#endregion //accessMode


#region filepath
			Console.WriteLine("Enter filepath : (Enter 0 for default)");
			while (!inputValid)
			{
				userInput = Console.ReadLine();

				if (String.IsNullOrWhiteSpace(userInput))
				{
					inputValid = false;
					Console.WriteLine("Incorrect input. Try again.");
				}
				else
				{
					inputValid = true;
				}
			}
			filePath = userInput;
			userInput = "";
			inputValid = false;
#endregion //filepath


#region variable
			Console.WriteLine("Enter variable to access :");
			while (!inputValid)
			{
				userInput = Console.ReadLine();

				if (String.IsNullOrWhiteSpace(userInput))
				{
					inputValid = false;
					Console.WriteLine("Incorrect input. Try again.");
				}
				else
				{
					inputValid = true;
				}
			}

			variable = userInput;
			userInput = "";
			inputValid = false;
			#endregion //variable


#region value
			if (accessMode == "set")
			{
				Console.WriteLine("Enter value to write");
				while (!inputValid)
				{
					userInput = Console.ReadLine();

					if (String.IsNullOrWhiteSpace(userInput))
					{
						inputValid = false;
						Console.WriteLine("Incorrect input. Try again.");
					}
					else
					{
						inputValid = true;

					}
				}

				value = userInput;
				userInput = "";
			}
#endregion //value


		}
	}
}
