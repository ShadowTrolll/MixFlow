#pragma once

#include <iostream>
#include <string>
#include <ios>
#include <fstream>

using namespace std;

/**	<summary>
* config.h
* Simple config file utility
* Copyright (c) 2018 Nodsoft ES, All Rights Reserved
	</summary> **/


namespace Config
{
	/*
	* Config::ReadValue();
	* Reads the value of a parameter in a config file.
	*
	* Usage of variables : 
	* string path - Path & Filename of the config file.
	* string category - Category to access, in specified file (leave blank for default).
	* string parameter - Parameter to read, in specified category.
	*/
	int ReadInt(string path, string category, string parameter);
	string ReadString(string path, string category, string parameter);

	/*
	* Config::WriteValue();
	* Reads the value of a parameter in a config file.
	*
	* Usage of variables :
	* string path - Path & Filename of the config file.
	* string category - Category to access, in specified file (leave blank for default).
	* string parameter - Parameter to write, in specified category.
	* value value - Value to write for specified parameter.
	*/
	void WriteInt(string path, string category, string parameter, int value);
	void WriteString(string path, string category, string parameter, string value);
}