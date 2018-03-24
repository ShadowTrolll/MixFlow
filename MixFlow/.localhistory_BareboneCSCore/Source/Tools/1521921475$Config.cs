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
		public FileInfo			ConfigFileInfo			{ get; set; }
		public DirectoryInfo	ConfigDirectoryInfo		{ get; set; }	
		public string			ConfigFileTemplate		{ get; set; }
		public Encoding			ConfigFileEncoding		{ get; set; }

		//Variables
		private FileStream		fileStream;
		private StreamReader	streamReader;
		private StreamWriter	streamWriter;

		private string			jsonRaw					= null;

		private Dictionary<String, String> dictionary;



								//Constructors / Deconstructor
		public					ConfigJson(string filePath)
		{
			ConfigFileInfo = new FileInfo(filePath);
			ConfigDirectoryInfo = new DirectoryInfo(ConfigFileInfo.DirectoryName);

			if (!ConfigDirectoryInfo.Exists)
			{
				ConfigDirectoryInfo.Create();
			}


			LoadConfig();
		}
		public					ConfigJson(string filePath, Encoding encoding, string templatePath = null, bool initTemplate = false)
		{
			ConfigFileInfo = new FileInfo(filePath);
			if (templatePath != null)
			{
				ConfigFileTemplate = templatePath; //TODO : Template System
			}

			LoadConfig();
		}

								~ConfigJson()
		{
			SaveConfig();
		}


								//File Handling Methods
		public void				LoadConfig()
		{
			LoadFile();
			Deserialize();
		}

		public void				SaveConfig()
		{
			Serialize();
			SaveFile();
		}


		protected void			LoadFile()
		{
			try
			{
				if (!IsFileLocked())
				{
					if (ConfigFileInfo.Length != 0)
					{
						using (FileStream fileStream = new FileStream(ConfigFileInfo.FullName, mode: FileMode.OpenOrCreate))
						{
							using (StreamReader streamReader = new StreamReader(fileStream, ConfigFileEncoding))
							{
								jsonRaw = streamReader.ReadToEnd();
								streamReader.Close();
							}
							fileStream.Close();
						}
					}
				}
			}
			catch (Exception e)
			{
				Console.Error.WriteLine("Exception caught on {0}() : {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, e);
			}
		}

		protected void			SaveFile()
		{
			try
			{
				if (!IsFileLocked())
				{
					using (FileStream fileStream = new FileStream(ConfigFileInfo.FullName, mode: FileMode.OpenOrCreate))
					{
						using (StreamWriter streamWriter = new StreamWriter(fileStream, ConfigFileEncoding))
						{
							streamWriter.Write(jsonRaw);
							streamWriter.Close();
						}
						fileStream.Close();
					}
				}
			}
			catch (Exception e)
			{
				Console.Error.WriteLine("Exception caught on {0}() : {3}", System.Reflection.MethodBase.GetCurrentMethod().Name, e);
			}
		}


		protected void			Deserialize()
		{
			if (jsonRaw != null && jsonRaw != "")
			{
				dictionary = JsonConvert.DeserializeObject<Dictionary<String, String>>(jsonRaw);
			}
			if (dictionary == null)
			{
				dictionary = new Dictionary<string, string>();
			}
		}

		protected void			Serialize()
		{
			jsonRaw = JsonConvert.SerializeObject(dictionary, Formatting.Indented);
		}


								//Checks
		protected bool			IsFileLocked() //http://dotnet-assembly.blogspot.fr/2012/10/c-check-file-is-being-used-by-another.html
		{
			FileStream stream = null;

			try
			{
				//Don't change FileAccess to ReadWrite, 
				//because if a file is in readOnly, it fails.
				stream = ConfigFileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.None);
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
				if (stream != null) stream.Close();
			}

			//file is not locked
			return false;
		}

		public bool				VarExistsInFile(string variable)
		{
			return dictionary.ContainsKey(variable);
		}


								//Get Set Methods 
		public string			GetStr(string variable)
		{
			try
			{
				if (!dictionary.ContainsKey(variable))
				{
					dictionary.Add(variable, null);
				}
			}
			catch (Exception e)
			{
				Console.Error.WriteLine("Exception caught on {0}({1}) : {2}", System.Reflection.MethodBase.GetCurrentMethod().Name, nameof(variable), e);
			}

			return dictionary[variable];
		}
		public void				GetStr(ref string parameter)
		{
			try
			{
				if (!dictionary.ContainsKey(nameof(parameter)))
				{
					dictionary.Add(nameof(parameter), null);
				}
				parameter = dictionary[nameof(parameter)];
			}
			catch (Exception e) {
				Console.Error.WriteLine("Exception caught on {0}(ref {1}) : {2}", System.Reflection.MethodBase.GetCurrentMethod().Name, nameof(parameter), e);
			}
		}

		public int				GetInt(string variable)
		{
			Int32 value = 0;
			try
			{
				if (!dictionary.ContainsKey(variable))
				{
					dictionary.Add(variable, value.ToString());
				}
				Int32.TryParse(dictionary[variable], out value);
			}
			catch (Exception e) {
				Console.Error.WriteLine("Exception caught on {0}({1}) : {2}", System.Reflection.MethodBase.GetCurrentMethod().Name, variable, e);
			}
			return value;
		}
		public void				GetInt(ref Int32 parameter)
		{
			try {
				if (!dictionary.ContainsKey(nameof(parameter)))
				{
					dictionary.Add(nameof(parameter), parameter.ToString());
				}
				Int32.TryParse(dictionary[nameof(parameter)], out parameter);
			}
			catch (Exception e) {
				Console.Error.WriteLine("Exception caught on {0}({1}) : {2}", System.Reflection.MethodBase.GetCurrentMethod().Name, parameter, e);
			}
		}

		public void				SetStr(string variable, string value)
		{
			try
			{
				if (!dictionary.ContainsKey(nameof(variable))) dictionary.Add(nameof(variable), variable);
				else dictionary[nameof(variable)] = variable;
			}
			catch (Exception e)
			{
				Console.Error.WriteLine("Exception caught on {0}({1},{2}) : {3}", System.Reflection.MethodBase.GetCurrentMethod().Name, nameof(variable), value, e);
			}
		}
		public void				SetStr(ref string parameter)
		{
			try {
				if (!dictionary.ContainsKey(nameof(parameter))) dictionary.Add(nameof(parameter), parameter);
				else dictionary[nameof(parameter)] = parameter;
			}
			catch (Exception e)
			{
				Console.Error.WriteLine("Exception caught on {0}(ref {1}) : {2}", System.Reflection.MethodBase.GetCurrentMethod().Name, nameof(parameter), e);
			}
		}

		public void				SetInt(string variable, int value)
		{
			try {
				if (!dictionary.ContainsKey(variable)) dictionary.Add(variable, value.ToString());
				else dictionary[variable] = value.ToString();
			}
			catch (Exception e)
			{
				Console.Error.WriteLine("Exception caught on {0}({1},{2}) : {3}", System.Reflection.MethodBase.GetCurrentMethod().Name, variable, value, e);
			}
		}
		public void				SetInt(ref int parameter)
		{
			try {
				if (!dictionary.ContainsKey(nameof(parameter))) dictionary.Add(nameof(parameter), parameter.ToString());
				else dictionary[nameof(parameter)] = parameter.ToString();
			}
			catch (Exception e)
			{
				Console.Error.WriteLine("Exception caught on {0}({1}) : {2}", System.Reflection.MethodBase.GetCurrentMethod().Name, parameter, e);
			}

		}
	}
}
