#include "config.h"



/**	<summary>
* config.cpp
* Simple config file utility
* Copyright (c) 2018 Nodsoft ES, All Rights Reserved
</summary> **/


void Config::setDefaultConfigPath()
{

#if defined(__unix__)
	const string configPathDefault = "$HOME/.config/";

#elif defined(WIN32) || defined (_WIN32)
	const string configPathDefault = "%APPDATA%/";

#endif // __unix__

	projectProperties::configPath = configPathDefault + PROJECT_NAME + "/config/";
}



int Config::ReadInt(string path, string parameter)
{
	int value;
	json j = ReadFile(path);

	try	{ value = int( j[parameter] ); }
	catch (const std::exception& e)
	{
		throw string("Error in ReadInt("+ path + ", " + parameter + ") :") + e.what();
	}

	return value;
}

string Config::ReadString(string path, string parameter)
{
	string value;
	json j = ReadFile(path);

	try { value = string( j[parameter] ); }
	catch (const std::exception& e)
	{
		throw string("Error in ReadString(" + path + ", " + parameter + ") :") + e.what();
	}

	return value;
}

void Config::WriteInt(string path, string parameter, int value)
{
	json j = ReadFile(path);

	try
	{
		j[parameter] = value;

		std::ofstream o(path);
		o << std::setw(4) << j << std::endl;
	}
	catch (const std::exception& e)
	{
		throw "Error in WriteInt(" + path + ", " + parameter + ", " + std::to_string(value) + ") :" + e.what();
	}

}

void Config::WriteString(string path, string parameter, string value)
{
	json j = ReadFile(path);

	try
	{
		j[parameter] = value;

		std::ofstream o(path);
		o << std::setw(4) << j << std::endl;
	}
	catch (const std::exception& e)
	{
		throw "Error in WriteInt(" + path + ", " + parameter + ", " + value + ") :" + e.what();
	}
}

json Config::ReadFile(string path)
{
	json j;

	try
	{
		std::ifstream i(path);
		i >> j;
	}
	catch (const std::exception& e)
	{
		throw string("Error in ReadFile(" + path + ") :") + e.what();
	}

	return json();
}

void Config::WriteFile(string path, json jstream)
{
	try
	{
		std::ofstream o(path);
		o << std::setw(4) << jstream << std::endl;
	}
	catch (const std::exception& e)
	{
		throw string("Error in WriteFile(" + path + "%FILESTREAM%) :") + e.what();
	}
}
