#include "Feature_Config.h"

using namespace std;

void featureConfig()
{
	string			filepath, variable, value;

	bool			resume = true, resumeSelectBool = false, correct;
	string			optionStr;
	unsigned int	selectGetSet;
	char			resumeSelect;


	do
	{
		cout << "Get (0) or Set (1) ?\n";
		
		do
		{
			cin >> selectGetSet;

			if (selectGetSet != 0 && selectGetSet != 1)
			{
				correct = false;
				cout << "Incorrect choice. Please enter 0 for Get, or 1 for Set.\n";
			}
			else correct = true;

		} while (!correct);

		cout << "Enter filepath : (Enter 0 for default)\n";
		cin >> optionStr;

		if (optionStr == "0")
		{
			filepath = projectProperties::configPathMain;
			cout << "Blank detected. Defaulting to this filepath :\n" + filepath;
		}
		else filepath = optionStr;

		optionStr = "";


		while (optionStr == "")
		{
			cout << "Enter variable to access :";
			cin >> optionStr;
		}
		variable = optionStr;
		optionStr = "";

		
		if (selectGetSet == 0)
		{
			Config::ReadStringParameter(filepath, variable, value);
			cout << "Value of \"" + variable + "\" is \"" + value + "\".\n";
		}

		if (selectGetSet == 1)
		{
			cout << "Enter value to set :\n";
			cin >> value;

			if (value == "")
			{
				cout << "Warning : Blank value detected.\n";
			}

			Config::WriteString(filepath, variable, value);
			cout << "Value of \"" + variable + "\" set to \"" + value + "\".\n";
		}

		optionStr = "", variable = "", value = "", filepath = "";
		selectGetSet = 2;

		while (!resumeSelectBool)
		{
			cout << "More values ? (y/n)";
			resumeSelect = getchar();

			switch (tolower(resumeSelect))
			{
			case 0x79: //ASCII for "y"
				resume = true,	resumeSelectBool = true;
			case 0x6E: //ASCII for "n"
				resume = false, resumeSelectBool = true;
			default:
				resumeSelectBool = false;
			}
		}

	} while (resume);

	clearConsole();
}
