#include "config.h"



/**	<summary>
* config.cpp
* Simple config file utility
* Copyright (c) 2018 Nodsoft ES, All Rights Reserved
</summary> **/


int Config::ReadInt(string path, string category, string parameter)
{
	int value;
	
	ifstream cfgFile(path, ifstream::in);

}

string Config::ReadString(string path, string category, string parameter)
{
	string value;

	return string();
}

void Config::WriteInt(string path, string category, string parameter, int value)
{
		ofstream cfgFile(path, ofstream::out);

		if (cfgFile.is_open())
		{
			while (!cfgFile.eof())
			{

			}
		}
		else cerr << "Unable to open File \"" + path + "\".";
}

void Config::WriteString(string path, string category, string parameter, string value)
{
		ofstream cfgFile(path, ofstream::out);
}