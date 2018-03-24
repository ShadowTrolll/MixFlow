#define DEBUG

using System;
using System.Runtime;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MixFlow_BareboneCSCore.Source.Properties;
using MixFlow_BareboneCSCore.Source.Tools;

///<summary>
///Program.cs
///Testing Purposes Only
///</summary>


namespace MixFlow_BareboneCSCore
{

	struct Parameter
	{
		Parameter(string value)
		{
			parameterName = typeof(Parameter).Name;
			parameterValue = value;
		}
		Parameter(ref string variable)
		{
			parameterName = nameof(variable);
			parameterValue = variable;
		}

		public string parameterName;
		public string parameterValue;
	};

	class Program
	{
		static int Main(string[] args)
		{

			//Variables
			string testFilePath = Config.ConfigPathDefault + "test.json";
			string jsonRaw = null;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();

			FileStream fileStream  = new FileStream(Config.ConfigPathMain, FileMode.OpenOrCreate);
			StreamWriter streamWriter;

			//Init
			using (fileStream)
			{
				using (streamWriter = new StreamWriter(fileStream, Config.ConfigFileEncode))
				{
					streamWriter.Write(jsonRaw);
				}	
			}

			SetStr(Config.ConfigPathDB, dictionary: ref dictionary);

			//Begin
			Console.WriteLine("Hello World !");
			SetStr()


			Console.ReadKey();
			return 0;
		}

		public void GetStr(ref string variable, ref Dictionary <string, string> dictionary)
		{
			if (!dictionary.ContainsKey(nameof(variable))) {
				dictionary.Add(nameof(variable), null);
			}
			variable = dictionary[nameof(variable)];
		}
		public void GetStr(ref Parameter parameter, ref Dictionary<string, string> dictionary)
		{
			if (!dictionary.ContainsKey(parameter.parameterName))
			{
				dictionary.Add(parameter.parameterName, parameter.parameterValue);
			}
			parameter.parameterValue = dictionary[parameter.parameterName];
		}

		public static void SetStr(ref string variable, ref Dictionary <string, string> dictionary)
		{
			if (!dictionary.ContainsKey(nameof(variable))) dictionary.Add(nameof(variable), variable);
			else dictionary[nameof(variable)] = variable;
		}
		public static void SetStr(ref Parameter parameter, ref Dictionary<string, string> dictionary)
		{
			if (!dictionary.ContainsKey(parameter.parameterName)) dictionary.Add(parameter.parameterName, parameter.parameterValue);
			else dictionary[parameter.parameterName] = parameter.parameterValue;
		}

		public void Deserialize(ref string json, ref Dictionary<string, string> dictionary)
		{
			if (json != null) {
				dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
			}
		}

		public void Serialize(ref Dictionary<string,string> dictionary, ref string json)
		{
			if (dictionary.Count == 0)
			{
				json = JsonConvert.SerializeObject(dictionary, Formatting.Indented);
			}

#if DEBUG
            System.Diagnostics.Debug.WriteLine("[DEBUG] Json output :\n" + json);
#endif
		}
	}
} 