#pragma once

#include <iostream>
#include <string>
#include <sqlitecpp\database.h>
#include "config.h"

using namespace std;

/**
* SQLite_IO.h
* Simple SQLite IO Controller
* Copyright (c) 2018 Nodsoft ES, All Rights Reserved
**/


namespace SQLite_IO
{	
	bool	DBConnected = false; //Status indicatior for DB connection

	//string	DBFilePath = Config::ReadString(projectProperties::configPathDB, "DBFilePath"); //Placeholder


};