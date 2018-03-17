#include "config.h"



/**	<summary>
* config.cpp
* Simple config file utility
* Copyright (c) 2018 Nodsoft ES, All Rights Reserved
</summary> **/


string Config::setDefaultConfigPath()
{

#if defined(__unix__)
	const string configPathDefault = "$HOME/.config/";

#elif defined(WIN32) || defined (_WIN32)
	const string configPathDefault = "%APPDATA%\\";

#endif // __unix__

	return configPathDefault + PROJECT_NAME + "\\config\\";
}


inline std::string to_string(const json &j)
{
	if (j.type() == json::value_t::string) {
		return j.get<std::string>();
	}

	return j.dump();
}


/*
int Config::ReadInt(const string &path, const string parameter)
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

string Config::ReadString(const string &path, const string parameter)
{
	string value;
	json j = ReadFile(path);

	try 
	{ 
		value = to_string(j[parameter]); 
	}
	catch (const std::exception& e)
	{
		throw string("Error in ReadString(" + path + ", " + parameter + ") :") + e.what();
	}

	return value;
}
*/

void Config::ReadStringParameter(const string &path, const string parameterName, string &parameter)
{
	json j = ReadFile(path);

	try
	{
		parameter = j[parameter].get<string>();
	}
	catch (const std::exception& e)
	{
		throw string("Error in ReadString(" + path + ", " + parameter + ") :") + e.what();
	}
}

void Config::WriteInt(const string &path, const string parameter, int value)
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

void Config::WriteString(const string &path, const string parameter, string value)
{
	json j = ReadFile(path);

	//try
	{
		j[parameter] = value;

		std::ofstream o;
		o.open(path);
		o << std::setw(4) << j << std::endl;
	}
	//catch (const std::exception e)
	{
	//	throw "Error in WriteInt(" + path + ", " + parameter + ", " + value + ") :" + e.what();
	}
}

json Config::ReadFile(string path)
{
	json j;

	//try
	{
		std::ifstream i;
		i.open(path);
		i >> j;
	}
	//catch (const std::exception e)
	{
	//	throw string("Error in ReadFile(" + path + ") :") + e.what();
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
	catch (const std::exception e)
	{
		throw string("Error in WriteFile(" + path + "%FILESTREAM%) :") + e.what();
	}
}
