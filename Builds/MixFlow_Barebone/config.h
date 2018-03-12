#pragma once

#include <iostream>
#include <string>
#include <ios>
#include <fstream>
#include "lib/json.hpp"
#include "properties.h"

using json = nlohmann::json;
using namespace std;

/**	<summary>
* config.h
* Simple config file utility
* Copyright (c) 2018 Nodsoft ES, All Rights Reserved
	</summary> **/


namespace Config
{
	/*
	* Config::setDefaultConfigPath
	* @brief Sets the default config path in accordance to system (Windows or Unix)
	*
	* Windows	: %APPDATA%/ProjectName/Config/
	* Unix		: $HOME/.config/ProjectName/Config/
	*/
	void setDefaultConfigPath();

	/*
	* Config::ReadValue();
	* @brief Reads the value of a parameter in a config file.
	*
	* Usage of variables : 
	* string path - Path & Filename of the config file.
	* string parameter - Parameter to read, in specified category.
	*/
	int ReadInt(string path, string parameter);
	string ReadString(string path, string parameter);

	/*
	* Config::WriteValue();
	* @brief Reads the value of a parameter in a config file.
	*
	* Usage of variables :
	* string path - Path & Filename of the config file.
	* string parameter - Parameter to write, in specified category.
	* value value - Value to write for specified parameter.
	*/
	void WriteInt(string path, string parameter, int value);
	void WriteString(string path, string parameter, string value);


	/*
	* Config::ReadFile();
	* @brief Reads entirely the JSON file into a nlohmann::json data type.
	*
	* Usage of variables :
	* string path - Path & Filename of the config file
	*/
	json ReadFile(string path);

	/*
	* Config::WriteFile();
	* @brief Writes/Overwrites entirely the JSON file into a nlohmann::json data type.
	*
	* Usage of variables :
	* string path - Path & Filename of the config file
	* json jstream - JSON stream of config file (read with Config::ReadFile())
	*/
	void WriteFile(string path, json jstream);
}