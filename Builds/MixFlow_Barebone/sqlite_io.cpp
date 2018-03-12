#include "sqlite_io.h"

/**
* SQLite_IO.cpp
* Simple SQLite IO Controller
* Copyright (c) 2018 Nodsoft ES, All Rights Reserved
**/

void SQLite_IO::InitDB()
{
	SQLite::Database db(DBFilePath);
}

void SQLite_IO::CloseDB()
{

}
