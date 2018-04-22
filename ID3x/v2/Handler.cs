using System;
using System.Collections.Generic;
using System.IO;
using static MixFlow.Utilities.Utilities;
using ID3;
using MixFlow.Utilities;

namespace MixFlow.ID3v2
{
	class Handle : I_ID3Driver, I_ID3Handle
	{
		//ID3v2 Tags / Frames
		public Dictionary<string, object> FramesDictionary { get; set; } = new Dictionary<string, object>();


		//Music File
		public FileInfo MusicFileInfo { get; private set; }
		protected ID3Info MusicID3Info { get; private set; }

		//Database ID
		public int DatabaseTrackID { get; set; }

		public Handle(string filePath, bool loadFrames = true)
		{
			try
			{
				MusicFileInfo = new FileInfo(filePath);
				if (!MusicFileInfo.Exists)
				{
					throw new FileNotFoundException();
				}
				MusicID3Info = new ID3Info(MusicFileInfo.FullName, true);

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
				if (MusicID3Info.ID3v2Info.GetTextFrame(frameName) == "" || MusicID3Info.ID3v2Info.GetTextFrame(frameName) == null)
				{
					continue;
				}
				else
				{
					FramesDictionary.Add(frameName, MusicID3Info.ID3v2Info.GetTextFrame(frameName));
				}
			}
		}

		public Dictionary<string, object> ExportFramesToDictionary()
		{
			Dictionary<string, object> _framesDictionary = new Dictionary<string, object>();

			foreach (string frameName in FrameList.list)
			{
				if (MusicID3Info.ID3v2Info.GetTextFrame(frameName) == "" || MusicID3Info.ID3v2Info.GetTextFrame(frameName) == null)
				{
					continue;
				}
				else
				{
					_framesDictionary.Add(frameName, MusicID3Info.ID3v2Info.GetTextFrame(frameName));
				}
			}

			return _framesDictionary;
		}

		public object ReadFrame(string frame)
		{
			if (FrameList.list.Contains(frame))
			{
				return MusicID3Info.ID3v2Info.GetTextFrame(frame);
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
					value = MusicID3Info.ID3v2Info.GetTextFrame(frame);
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

		public void SaveFrame(string frame, object value)
		{
			if (!FramesDictionary.ContainsKey(frame))
			{
				FramesDictionary.Add(frame, value);
			}
			else FramesDictionary[frame] = value;
		}
		public void SaveFrame(Frame frame)
		{
			if (!FramesDictionary.ContainsKey(frame.FrameName))
			{
				FramesDictionary.Add(frame.FrameName, frame.FrameValue);
			}
			else FramesDictionary[frame.FrameName] = frame.FrameValue;
		}

		public void ImportFramesFromDictionary(Dictionary<string, object> _framesDictionary)
		{
			foreach (string frame in _framesDictionary.Keys)
			{
				if (_framesDictionary.ContainsKey(frame))
				{
					if (_framesDictionary[frame] != FramesDictionary[frame])
					{
						FramesDictionary[frame] = _framesDictionary[frame];
					}
				}
				else
				{
					FramesDictionary.Add(frame, _framesDictionary[frame]);
				}
			}
		}

		public void PushFramesToFile(FileHandleModes fileHandleMode = FileHandleModes.appendOverwrite)
		{
			if (fileHandleMode == FileHandleModes.rewrite)
			{
				foreach (string frame in FrameList.list)
				{
					if (MusicID3Info.ID3v2Info.GetTextFrame(frame).Length != 0)
					{
						MusicID3Info.ID3v2Info.SetTextFrame(frame, null);
					}
					if (FramesDictionary.ContainsKey(frame))
					{
						MusicID3Info.ID3v2Info.SetTextFrame(frame, FramesDictionary[frame].ToString());
					}
				}
			}
			else
			{
				foreach (string frame in FramesDictionary.Keys)
				{
					bool write = false;

					if (fileHandleMode == FileHandleModes.appendOverwrite)
					{
						write = true;
					}
					else if (fileHandleMode == FileHandleModes.appendEmptyOnly)
					{
						if (!FramesDictionary.ContainsKey(frame))
						{
							write = true;
						}
					}
					if (write)
					{
						MusicID3Info.ID3v2Info.SetTextFrame(frame, FramesDictionary[frame].ToString());
					}
				}
			}
		}

		public void PullFramesFromFile(FileHandleModes fileHandleMode = FileHandleModes.appendOverwrite)
		{
			if (fileHandleMode == FileHandleModes.rewrite)
			{
				FramesDictionary.Clear();
			}

			foreach (string frame in FrameList.list)
			{
				bool read = false;
				if (MusicID3Info.ID3v2Info.GetTextFrame(frame) == "" || MusicID3Info.ID3v2Info.GetTextFrame(frame) == null)
				{
					continue;
				}
				if (fileHandleMode == FileHandleModes.appendOverwrite)
				{
					read = true;
				}
				if (fileHandleMode == FileHandleModes.appendEmptyOnly && !FramesDictionary.ContainsKey(frame))
				{
						read = true;

				}
				if (read)
				{
					if (FramesDictionary.ContainsKey(frame))
					{
						FramesDictionary[frame] = MusicID3Info.ID3v2Info.GetTextFrame(frame);
					}
					else
					{
						FramesDictionary.Add(frame, MusicID3Info.ID3v2Info.GetTextFrame(frame));
					}
				}
			}
		}
	}
}
