using System.Collections.Generic;
using System.IO;
using static MixFlow.Utilities.Utilities;

namespace MixFlow.ID3v2
{
	interface I_ID3Driver
	{
		//Properties
		FileInfo MusicFileInfo { get; }

		Dictionary<string, object> FramesDictionary { get; set; }


		//Methods
			//Frame Ops
		object ReadFrame(string frame);

		void SaveFrame(string frame, object value);
		void SaveFrame(Frame frame);

		void ImportFramesFromDictionary(Dictionary<string, object> framesDictionary);

		Dictionary<string, object> ExportFramesToDictionary();

		//File Ops
		void PushFramesToFile(FileHandleModes fileHandleModes);
		void PullFramesFromFile(FileHandleModes fileHandleModes);
	}
}
