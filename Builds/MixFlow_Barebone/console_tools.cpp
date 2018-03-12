#include "console_tools.h"

/**
* CONSOLE_TOOLS.h
* Various Console commands for interface simulation
**/

void ClearConsole()
{
	#ifdef __unix__
	printf("\033c");

	#elif defined(WIN32) || defined(_WIN32)
	system("cls");

	#endif // __unix__
}