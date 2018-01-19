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


class SQLite_IO
{
public:
	SQLite_IO();
	~SQLite_IO();

	void InitDB();	// Opens a SQLite database.
	void CloseDB(); // Closes an existing SQLite connection.

private:
};