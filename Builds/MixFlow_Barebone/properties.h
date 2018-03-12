#pragma once
#include <string>

/**	<summary>
* properties.h
* Contains properties of project, to change upon build or version change.
*
* Copyright (c) 2018 Nodsoft ES, All Rights Reserved
</summary> **/

using namespace std;

namespace projectProperties
{
#define PROJECT_NAME "MixFlow"


	extern string			configPath		= "%APPDATA%/MixFlow/Config/",
							configPathMain	= projectProperties::configPath + "config.json",
							configPathDB	= projectProperties::configPath + "database.json";
}
