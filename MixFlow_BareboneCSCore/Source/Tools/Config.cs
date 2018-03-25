using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

/// <summary>
/// Config.cs
/// Simple configuration Get/Set tool
/// Version 1.0.0
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
		public Encoding			ConfigFileEncoding		{ get; set; }	= Encoding.UTF8;

		//Variables
		private FileStream		fileStream;
		private StreamReader	streamReader;
		private StreamWriter	streamWriter;

		private string			jsonRaw					= null;

		private Dictionary<String, String> dictionary;



								//Constructors / Deconstructor
								/// <summary>
								/// Default constructor
								/// </summary>
								/// <param name="filePath">Path of the config file to access</param>
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
								/// <summary>
								/// Alternative Constructor
								/// </summary>
								/// <param name="filePath">Path of the config file to access</param>
								/// <param name="encoding">Config File Encoding (suggested UTF-8)</param>
								/// <param name="templatePath">Path of the template file, used if file initially blank/null (default : null)</param>
								/// <param name="initTemplate">Toggle for initialization by template of the config file (default : false)</param>
		public					ConfigJson(string filePath, Encoding encoding, string templatePath = null, bool initTemplate = false)
		{
			ConfigFileInfo = new FileInfo(filePath);
			if (templatePath != null)
			{
				ConfigFileTemplate = templatePath; //TODO : Template System
			}

			LoadConfig();
		}

								/// <summary>
								/// Deconstructor
								/// </summary>
								~ConfigJson()
		{
			SaveConfig();
		}



								//File Handling Methods
								/// <summary>
								/// Load the config file and deserializes it immediately.
								/// </summary>
		public void				LoadConfig()
		{
			LoadFile();
			Deserialize();
		}
								
								/// <summary>
								/// Serializes to config file and writes it immediately.
								/// </summary>
		public void				SaveConfig()
		{
			Serialize();
			SaveFile();
		}


								/// <summary>
								/// Loads the file to a JSON String (stream is cut immediately after load)
								/// </summary>
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

								/// <summary>
								/// Saves the JSON string to file (stream is cut immediately after write)
								/// </summary>
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


								/// <summary>
								/// Deserializes a JSON String to a Dictionary (or creates one if string is null
								/// </summary>
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

								/// <summary>
								/// Serializes a Dictionary to a JSON String
								/// </summary>
		protected void			Serialize()
		{
			jsonRaw = JsonConvert.SerializeObject(dictionary, Formatting.Indented);
		}



								//Checks
								/// <summary>
								/// Checks if the config file is in use by another program (aka locked)
								/// </summary>
								/// <returns>Boolean with lock status (false = unlocked, true = locked)</returns>
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

								/// <summary>
								/// Checks if a variable exists within the Deserialized dictionary
								/// </summary>
								/// <remarks>This method is designed for external use.</remarks>
								/// <param name="variable">Name of variable to check</param>
								/// <returns>Boolean with existence status (true = exists, false = doesn't)</returns>
		public bool				VarExistsInFile(string variable)
		{
			return dictionary.ContainsKey(variable);
		}



								//Get Set Methods 
								/// <summary>
								/// Gets a particular variable from the dictionary
								/// </summary>
								/// <param name="variable">Name of variable to access</param>
								/// <returns>String with variable's value on Dictionary</returns>
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
								/// <summary>
								/// Gets a particular parameter from the dictionary
								/// </summary>
								/// <param name="parameter">Parameter to get, and copy value to</param>
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

								/// <summary>
								/// Gets a particular variable from the dictionary
								/// </summary>
								/// <param name="variable">Name of variable to access</param>
								/// <returns>Int with variable's value on Dictionary</returns>
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
								/// <summary>
								/// Gets a particular parameter from the dictionary
								/// </summary>
								/// <param name="parameter">Parameter to get, and copy value to</param>
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


								/// <summary>
								/// Sets a variable on dictionary
								/// </summary>
								/// <param name="variable">Name of variable to set</param>
								/// <param name="value">Value to set</param>
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
								/// <summary>
								/// Sets a parameter on dictionary
								/// </summary>
								/// <param name="parameter">Parameter to set</param>
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

								/// <summary>
								/// Sets a variable on dictionary
								/// </summary>
								/// <param name="variable">Name of variable to set</param>
								/// <param name="value">Value to set</param>
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
								/// <summary>
								/// Sets a parameter on dictionary
								/// </summary>
								/// <param name="parameter">Parameter to set</param>
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
