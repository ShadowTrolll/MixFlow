#pragma once

#include <string>
#include <iostream>
#include "properties.h"

namespace AssemblyInfo
{
#define VERSION_RELEASE	0
#define VERSION_MAJOR	0
#define VERSION_MINOR	0
#define VERSON_PATCH	0


	string versionDisplay = std::to_string(VERSION_RELEASE) + "." + std::to_string(VERSION_MAJOR) + "." + std::to_string(VERSION_MINOR) + "." + std::to_string(VERSON_PATCH);
}