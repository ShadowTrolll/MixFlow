#include "Main.h"

/**
* MixFlow Prototype (Proof of Concept)
* Copyright (c) 2018 Nodsoft ES, ALL RIGHTS RESERVED
**/

using namespace std;

int main(int argc, const char* argv[])
{
	//init
	//Config::setDefaultConfigPath();

	DisplaySplash();
	short programOption;

	while (true)
	{
		DisplayMainMenu();
		programOption = SelectFromMainMenu();
		switch (programOption)
		{
		case 1:
			DisplayWIP();
		case 2:
			DisplayWIP();
		case 3:
			featureConfig();

		case -1:
			DisplayWIP();
		case -2:
			DisplayWIP();

		default:
			cerr << "ERROR : selectFromMainMenu() triggered unknown option.";
		}
	}


	


    return 0;
}

void init(int argc, const char* argv[])
{
	if (argc != 1)
	{
		Config::setDefaultConfigPath();
	}
}

void close()
{

}