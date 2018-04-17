using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MixFlow_BareboneCSCore.Source.Meta.ID3v2
{
    class ID3v2_Meta
    {
											//ID3v2 Tags / Frames
		public Dictionary<string, object>	FramesDictionary	= new Dictionary<string, object>();


											//Music File
		public FileInfo						MusicFileInfo { get; private set; }



		public ID3v2_Meta(string filePath)
		{
			
		}
		public ID3v2_Meta(FileInfo filePath)
		{

		}
		public ID3v2_Meta(int databaseID)
		{

		}
	}
}
