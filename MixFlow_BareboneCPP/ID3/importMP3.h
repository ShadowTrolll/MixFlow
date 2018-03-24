#pragma once
#include <taglib\taglib.h>
#include <taglib\mpegfile.h>
#include <taglib\fileref.h>

using namespace TagLib;

TagLib::FileRef fileMP3("Resources_Test/DJ Daemonix - Axiom (Original Mix).mp3");
TagLib::String artist = fileMP3.tag()->artist();
