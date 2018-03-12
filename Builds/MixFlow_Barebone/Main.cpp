#include "Main.h"
#include "sqlite_io.h"

/**
* MixFlow Prototype (Proof of Concept)
* Copyright (c) 2018 Nodsoft ES, ALL RIGHTS RESERVED
**/

using namespace std;

int main(int argc, const char* argv[])
{
	SQLite_IO::InitDB();


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