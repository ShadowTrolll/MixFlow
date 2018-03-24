using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

/// <summary>
/// Config.cs
/// Simple configuration Get/Set tool
/// Copyright (c) Nodsoft ES - All Rights Reserved
/// </summary>


namespace MixFlow_BareboneCSCore.Source.Tools
{
    public class ConfigJson
	{
		//Properties
		public FileInfo FileInfo { get; set; }
		public string Template { get; set; }

		//Variables
		FileStream fileStream;
		StreamReader streamReader;
		StreamWriter streamWriter;

		private string jsonRaw = null;
		private Dictionary<String, String> dictionaryStr;



		//Constructors / Deconstructor
		public ConfigJson(string fileName)
		{
			FilePath = @fileName;
			FileInfo = new FileInfo(FilePath);

			LoadConfig();
		}
		public ConfigJson(string fileName, string template)
		{
			FilePath = @fileName;
			template = Template; //@TODO : Template System
			FileInfo = new FileInfo(FilePath);

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
				if (!File.Exists(FilePath))
				{
					fileStream = new FileStream(FilePath, FileMode.CreateNew, FileAccess.Write, FileShare.None);
					fileStream.Close();
				}
				if (!IsFileLocked())
				{
					fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.ReadWrite);
				}
				else
				{
					fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
				}

				using (streamReader = new StreamReader(fileStream))
				{
					jsonRaw = streamReader.ReadToEnd();
				}
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
				if (!IsFileLocked())
				{
					using (streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
					{
						streamWriter.Write(jsonRaw);
					}
				}
				else
				{
					throw new FileLoadException(("File locked ! Path : " + FilePath));
				}
			}
			catch (Exception e)
			{
				System.Console.Error.WriteLine("Exception caught on {0}() : {3}", System.Reflection.MethodBase.GetCurrentMethod().Name, e);
			}
		}

		protected void Deserialize()
		{
			if (FileInfo.Length != 0)
			{
				dictionaryStr = JsonConvert.DeserializeObject<Dictionary<String, String>>(jsonRaw);
			}
		}
		protected Dictionary<String, String> Deserialize(string json)
		{
			Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<String, String>>(json);
			return dictionary;
		}
		protected void Serialize()
		{
			jsonRaw = JsonConvert.SerializeObject(dictionaryStr, Formatting.Indented);
		}

		public void CleanFiles()
		{
			if (Directory.Exists("FOLDER_PATH"))
			{
				var directory = new DirectoryInfo("FOLDER_PATH");
				foreach (FileInfo file in directory.GetFiles())
				{
					if (!IsFileLocked())
					{
						file.Delete();
					}
				}
			}
		}

		//Checks
		private bool IsFileLocked() ///http://dotnet-assembly.blogspot.fr/2012/10/c-check-file-is-being-used-by-another.html
		{
			FileStream stream = null;

			try
			{
					//Don't change FileAccess to ReadWrite, 
					//because if a file is in readOnly, it fails.
					stream = FileInfo.Open
					(
						FileMode.Open,
						FileAccess.Read,
						FileShare.None
					);
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
