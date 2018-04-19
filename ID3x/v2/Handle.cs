using System;
using System.Collections.Generic;
using System.IO;
using static MixFlow.Utilities.Utilities;
using ID3;

namespace MixFlow.ID3v2
{
	class Handle
	{
		//ID3v2 Tags / Frames
		public Dictionary<string, object> FramesDictionary = new Dictionary<string, object>();


		//Music File
		public FileInfo MusicFileInfo { get; private set; }
		protected ID3Info MusicFileID3 { get; private set; }

		//Database ID
		public int DatabaseID { get; set; }

		public Handle(string filePath, bool loadFrames = true)
		{
			try
			{
				MusicFileInfo = new FileInfo(filePath);
				if (!MusicFileInfo.Exists)
				{
					throw new FileNotFoundException();
				}
				MusicFileID3 = new ID3Info(MusicFileInfo.FullName, true);

				if (loadFrames)
				{
					LoadAllTextFramesFromFile();
				}
			}
			catch (Exception e)
			{
				ExceptionHandle(e);
				throw;
			}
		}
		public Handle(FileInfo filePath)
		{

		}
		public Handle(int databaseID)
		{

		}

		public void LoadAllTextFramesFromFile()
		{
			foreach (string frameName in FrameList.list)
			{
				if (MusicFileID3.ID3v2Info.GetTextFrame(frameName) == "" || MusicFileID3.ID3v2Info.GetTextFrame(frameName) == null)
				{
					continue;
				}
				else
				{
					FramesDictionary.Add(frameName, MusicFileID3.ID3v2Info.GetTextFrame(frameName));
				}
			}
		}

		public object ReadFrame(string frame)
		{
			if (FrameList.list.Contains(frame))
			{
				return MusicFileID3.ID3v2Info.GetTextFrame(frame);
			}
			else throw new NotImplementedException();
		}

		public void LoadFrame(string frame)
		{
			if (FrameList.list.Contains(frame))
			{
				object value = null;

				try
				{
					value = MusicFileID3.ID3v2Info.GetTextFrame(frame);
					if (!FramesDictionary.ContainsKey(frame))
					{
						FramesDictionary.Add(frame, value);
					}
					else FramesDictionary[frame] = value;
				}
				catch (Exception e)
				{
					ExceptionHandle(e);
					throw;
				}
			}
			else throw new NotImplementedException();
		}

		public void SaveFrameToDictionary(string frame, object value)
		{
			if (!FramesDictionary.ContainsKey(frame))
			{
				FramesDictionary.Add(frame, value);
			}
			else FramesDictionary[frame] = value;
		}
		public void SaveFrameToDictionary(Frame frame)
		{
			if (!FramesDictionary.ContainsKey(frame.FrameName))
			{
				FramesDictionary.Add(frame.FrameName, frame.FrameValue);
			}
			else FramesDictionary[frame.FrameName] = frame.FrameValue;
		}
	}

	static class ID3_Types
	{

	}
}
