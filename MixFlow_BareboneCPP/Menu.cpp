#include "Menu.h"

using namespace std;

void DisplaySplash()
{
	cout <<	"===================================================================\n"
			"||                                                      v0.0.0.1 ||\n"
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
			"|| 3. Config Test                                                ||\n"
			"||                                                               ||\n"
			"||                                                               ||\n"
			"||                                                   A. About    ||\n"
			"||                                                   Q. Quit     ||\n"
			"===================================================================\n";
}

void DisplayWIP()
{
	cout << "Feature under construction.\n";
	getchar();
}

short SelectFromMainMenu()
{
	char	selection = NULL;
	bool	selected = false;

	cout << "\nPlease select an option : ";

	 while (!selected)
	 {
		 selection = getchar();

		 switch (tolower(selection))
		 {
		 case 0x73:	//ASCII for "s"
			 selected = true;
			 return -1;
		 case 0x61:	//ASCII for "a"
			 selected = true;
			 return -2;
		 case 0x71: //ASCII for "q"
			 selected = true;
			 exit(0);

		 case 0x31:	//ASCII for "1"
			 selected = false;
			 return 1;
		 case 0x32:	//ASCII for "2"
			 selected = false;
			 return 2;
		 case 0x33: //ASCII for "3"
			 selected = true;
			 return 3;

		 case 0:
			 cout << "No selection. Please select an option.\n";
			 break;

		 default:
			 cout << "Invalid selection. Please try again.\n";
			 break;

		 }	//switch
	 }	//while

	 clearConsole();
}
