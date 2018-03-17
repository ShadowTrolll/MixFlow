#pragma once
#include <string>
#include "config.h"

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


	extern string			configPath = Config.setDefaultConfigPath(),
							configPathMain	= configPath + "config.json",
							configPathDB	= configPath + "database.json";
}
