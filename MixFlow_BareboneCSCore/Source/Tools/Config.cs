using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

/// <summary>
/// Config.cs
/// Simple configuration Get/Set tool
/// Copyright (c) Nodsoft ES - All Rights Reserved
/// </summary>


namespace MixFlow_BareboneCSCore.Source.Tools
{
    class ConfigJson
	{
		//Properties
		public string FilePath { get; set; }
		public string Template { get; set; }

		//Variables
		FileStream fileStream;
		private string jsonRaw = null;
		private Dictionary<String, String> dictionaryStr;

		//Constructors / Deconstructor
		ConfigJson(string fileName)
		{
			FilePath = fileName;

			LoadConfig();
		}
		ConfigJson(string fileName, string template)
		{
			FilePath = fileName;
			template = Template; //@TODO : Template System

			LoadConfig();
		}
		~ConfigJson()
		{
			SaveConfig();
			CloseFile();
		}


		//File Handling Methods
		public void LoadConfig()
		{
			LoadFile();
			Deserialize();
		}
		public void SaveConfig()
		{
			Serialize();
			SaveFile();
		}

		protected void LoadFile()
		{
			try
			{
				fileStream = File.Open(FilePath, FileMode.OpenOrCreate);
				jsonRaw = File.ReadAllText(@FilePath);
			}
			catch (Exception e)
			{
				System.Console.Error.WriteLine("Exception caught on {0}() : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, e);
			}
		}
		protected void SaveFile()
		{
			try
			{
				File.WriteAllText(@FilePath, jsonRaw);
			}
			catch (Exception e)
			{
				System.Console.Error.WriteLine("Exception caught on {0}() : {3}", System.Reflection.MethodBase.GetCurrentMethod().Name, e);
			}
		}

		protected void CloseFile()
		{
			fileStream.Close();
		}

		private void Deserialize()
		{
			dictionaryStr = JsonConvert.DeserializeObject<Dictionary<String, String>>(jsonRaw);
		}
		protected Dictionary<String, String> deserialize(string json)
		{
			Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<String, String>>(json);
			return dictionary;
		}
		private void Serialize()
		{
			jsonRaw = JsonConvert.SerializeObject(dictionaryStr, Formatting.Indented);
		}


			//Get Set Methods 
		public string GetStr(string variable)
		{
			string str = dictionaryStr[variable];
			return str;
		}
		public void GetStr(ref string parameter)
		{
			try {
			parameter = dictionaryStr[nameof(parameter)];
			}
			catch (Exception e) {
				System.Console.Error.WriteLine("Exception caught on {0}({1}) : {2}", System.Reflection.MethodBase.GetCurrentMethod().Name, parameter, e);
			}
		}

		public Int32 GetInt(string variable)
		{
			Int32 value = 0;
			try {
				value = Int32.Parse(dictionaryStr[variable]);
			}
			catch (Exception e) {
				System.Console.Error.WriteLine("Exception caught on {0}({1}) : {2}", System.Reflection.MethodBase.GetCurrentMethod().Name, variable, e);
			}
			return value;
		}
		public void GetInt(ref Int32 parameter)
		{
			try {
				parameter = Int32.Parse(dictionaryStr[nameof(parameter)]);
			}
			catch (Exception e) {
				System.Console.Error.WriteLine("Exception caught on {0}({1}) : {2}", System.Reflection.MethodBase.GetCurrentMethod().Name, parameter, e);
			}
		}

		public void SetStr(string variable, string value)
		{
			try {
				dictionaryStr[variable] = value;
			}
			catch (Exception e)
			{
				System.Console.Error.WriteLine("Exception caught on {0}({1},{2}) : {3}", System.Reflection.MethodBase.GetCurrentMethod().Name, variable, value, e);
			}
		}
		public void SetStr(ref string parameter)
		{
			try {
				dictionaryStr[nameof(parameter)] = parameter;
			}
			catch (Exception e)
			{
				System.Console.Error.WriteLine("Exception caught on {0}({1}) : {2}", System.Reflection.MethodBase.GetCurrentMethod().Name, parameter, e);
			}
		}

		public void SetInt(string variable, int value)
		{
			try {
				dictionaryStr[variable] = value.ToString();
			}
			catch (Exception e)
			{
				System.Console.Error.WriteLine("Exception caught on {0}({1},{2}) : {3}", System.Reflection.MethodBase.GetCurrentMethod().Name, variable, value, e);
			}
		}
		public void SetInt(ref int parameter)
		{
			try {
				dictionaryStr[nameof(parameter)] = parameter.ToString();
			}
			catch (Exception e)
			{
				System.Console.Error.WriteLine("Exception caught on {0}({1}) : {2}", System.Reflection.MethodBase.GetCurrentMethod().Name, parameter, e);
			}

		}
	}
}
