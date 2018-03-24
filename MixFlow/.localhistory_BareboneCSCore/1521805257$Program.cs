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

			FileInfo fileInfo = new FileInfo(testFilePath);

			//Init
			LoadFile(ref jsonRaw, ref fileInfo);
			Deserialize(ref jsonRaw, ref dictionary);
			

			//Begin
			Console.WriteLine("Hello World !");
			SetStr(nameof(Config.ConfigPathDB), Config.ConfigPathDB, ref dictionary);
			SetStr("testVar", "testVal", ref dictionary)


			Console.ReadKey();

			Serialize(ref dictionary, ref jsonRaw);
			WriteFile(ref jsonRaw, ref fileInfo);

			Console.ReadKey();

			return 0;
		}

		public static void		GetStr(ref string variable, ref Dictionary <string, string> dictionary)
		{
			if (!dictionary.ContainsKey(nameof(variable))) {
				dictionary.Add(nameof(variable), null);
			}
			variable = dictionary[nameof(variable)];
		}
		public static string	GetStr(string variable, ref Dictionary<string, string> dictionary)
		{
			if (!dictionary.ContainsKey(variable))
			{
				dictionary.Add(variable, null);
			}
			return dictionary[variable];
		}
		public static void		GetStr(ref Parameter parameter, ref Dictionary<string, string> dictionary)
		{
			if (!dictionary.ContainsKey(parameter.parameterName))
			{
				dictionary.Add(parameter.parameterName, parameter.parameterValue);
			}
			parameter.parameterValue = dictionary[parameter.parameterName];
		}

		public static void		SetStr(ref string variable, ref Dictionary <string, string> dictionary)
		{
			if (!dictionary.ContainsKey(nameof(variable))) dictionary.Add(nameof(variable), variable);
			else dictionary[nameof(variable)] = variable;
		}
		public static void		SetStr(string variable, string value, ref Dictionary<string, string> dictionary)
		{
			if (dictionary.Count != 0)
			{
				if (!dictionary.ContainsKey(variable)) dictionary.Add(variable, value);
				else dictionary[variable] = value;
			}
		}
		public static void		SetStr(ref Parameter parameter, ref Dictionary<string, string> dictionary)
		{
			if (!dictionary.ContainsKey(parameter.parameterName)) dictionary.Add(parameter.parameterName, parameter.parameterValue);
			else dictionary[parameter.parameterName] = parameter.parameterValue;
		}


		public static void		Deserialize(ref string json, ref Dictionary<string, string> dictionary)
		{
			if (json != null) {
				dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
			}
			if (dictionary == null)
			{
				dictionary = new Dictionary<string, string>();
			}
		}

		public static void		Serialize(ref Dictionary<string,string> dictionary, ref string json)
		{
			if (dictionary.Count != 0)
			{
				json = JsonConvert.SerializeObject(dictionary, Formatting.Indented);
			}

#if DEBUG
            System.Diagnostics.Debug.WriteLine("[DEBUG] Json output :");
			System.Diagnostics.Debug.WriteLine(json);
#endif
		}


		public static void		LoadFile(ref string json, ref FileInfo fileInfo)
		{
			if (!IsFileLocked(fileInfo))
			{
				if (fileInfo.Length != 0)
				{
					using (FileStream fileStream = new FileStream(fileInfo.FullName, mode: FileMode.OpenOrCreate))
					{
						using (StreamReader streamReader = new StreamReader(fileStream, Config.ConfigFileEncode))
						{
							json = streamReader.ReadToEnd();
							streamReader.Close();
						}
						fileStream.Close();
					}
				}
			}
		}

		public static void		WriteFile(ref string json, ref FileInfo fileInfo)
		{
			if (!IsFileLocked(fileInfo))
			{
				using (FileStream fileStream = new FileStream(fileInfo.FullName, mode: FileMode.OpenOrCreate))
				{
					using (StreamWriter streamWriter = new StreamWriter(fileStream, Config.ConfigFileEncode))
					{
						streamWriter.Write(json);
						streamWriter.Close();
					}
					fileStream.Close();
				}
			}
		}

		public static bool		IsFileLocked(FileInfo file)
		{
			FileStream stream = null;

			try
			{
				stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
			}
			catch (IOException)
			{
				//the file is unavailable because it is:
				//still being written to
				//or being processed by another thread
				//or does not exist (has already been processed)
				return true;
			}
			finally
			{
				if (stream != null)
					stream.Close();
			}

			//file is not locked
			return false;
		}
	}
} 