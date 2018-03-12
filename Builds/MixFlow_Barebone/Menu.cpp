#include "Menu.h"

using namespace std;

void DisplaySplash()
{
	cout <<	"===================================================================\n"
			"||                                                      v" << AssemblyInfo::versionDisplay << " ||\n"
			"||                                                               ||\n"
			"||                                                               ||\n"
			"||                            MixFlow                            ||\n"
			"||                                                               ||\n"
			"|| By Nodsoft ES                               Copyright Control ||\n"
			"|| nodsoft.net                               All Rights Reserved ||\n"
			"===================================================================\n";
}

void DisplayMainMenu()
{
	cout << "===================================================================\n"
			"|| 1. Check Song Database                            S. Settings ||\n"
			"|| 2. Import Song(s) to DB                                       ||\n"
			"||                                                               ||\n"
			"||                                                               ||\n"
			"||                                                               ||\n"
			"||                                                               ||\n"
			"||                                                   A. About    ||\n"
			"===================================================================\n";
}

char SelectFromMainMenu()
{
	char	selection = NULL;
	bool	selected = false;

	cout << "\nPlease select an option : ";

	 while (!selected)
	 {
		 selection = getchar();

		 switch (selection)
		 {
		 case 0x53:	//ASCII for "S"
			 selected = true;
			 return -1;
		 case 0x73:	//ASCII for "s"
			 selected = true;
			 return -1;
		 case 0x41:	//ASCII for "A"
			 selected = true;
			 return -2;
		 case 0x61:	//ASCII for "a"
			 selected = true;
			 return -2;

		 case 0x31:	//ASCII for "1"
			 selected = true;
			 return 1;
		 case 0x32:	//ASCII for "2"
			 selected = false;
			 return 2;

		 case 0:
			 cout << "No selection. Please select an option.";
			 break;

		 default:
			 cout << "Invalid selection. Please try again.";
			 break;
		 }
	 }
}
