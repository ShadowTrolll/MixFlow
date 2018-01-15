#pragma once

#include <iostream>
#include <string>
#include <winsock.h>
#include <MYSQL/mysql.h>

using namespace std;

/**
* SQL_IO.h
* Simple MySQL IO Controller
* Copyright (c) 2018 Nodsoft ES, All Rights Reserved
**/


class SQL_IO
{
public:
	SQL_IO();
	~SQL_IO();

	void InitConnection();	// Opens a connection to a MySQL database.
	void CloseConnection(); // Closes an existing MySQL connection.

private:

	bool			connectedToSQL			= false;

	const char		*settingsHostname		= "93.7.85.33",
					*settingsUsername		= "mixflow",
					*settingsPassword		= "M9U6rxS8JFPEhHNk",
					*settingsDatabaseName	= "mixflow";
	unsigned short	settingsPort;

	MYSQL mysql;

};