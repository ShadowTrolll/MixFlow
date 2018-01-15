#include "sql_io.h"

/**
* SQL_IO.cpp
* Simple MySQL IO Controller
* Copyright (c) 2018 Nodsoft ES, All Rights Reserved
**/

SQL_IO::SQL_IO() //Constructor, inits MySQL
{
	bool initSuccess = mysql_init(&mysql);
	if (!initSuccess)
	{
		cerr << "Failed to initialize MySQL module.";
	}
}

SQL_IO::~SQL_IO()
{
	CloseConnection();
	mysql_close(&mysql);
}

void SQL_IO::InitConnection()
{
	mysql_real_connect(&mysql, settingsHostname, settingsUsername, settingsPassword, settingsDatabaseName, 0, NULL, 0);
	connectedToSQL = true;
}

void SQL_IO::CloseConnection()
{
	
	connectedToSQL = false;
}
