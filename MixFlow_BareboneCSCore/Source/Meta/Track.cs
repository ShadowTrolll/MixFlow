using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ID3;

namespace MixFlow_BareboneCSCore.Source.Tags
{
    class Track
    {

		public struct			ID3v2Frame
		{
			public object		FrameValue		{ get; set; }
			public string		FrameName		{ get; private set; }

			public ID3v2Frame(object value, string frameID)
			{
				FrameName	= frameID;
				FrameValue	= value; 
			}
		}

		protected int			trackID;
		protected int			artistID;
		protected int			albumID;

		private	int				ID3e_Version;

		public enum				ObjectStatusEnum : byte
		{
			@new, valid, deleted, missingFile, noFile, errored, outdatedTags, fileTagsMismatch
		}
		public ObjectStatusEnum ObjectStatus { get; protected set; }

		public FileInfo			trackFileInfo;

		ID3Info					File;

		#region ID3v2
		//ID3v2 Tags
		public ID3v2Frame		TrackName			{ get; set; } = new ID3v2Frame(null, "TIT2");
		public ID3v2Frame		ArtistName			{ get; set; } = new ID3v2Frame(null, "TPE1");
		public ID3v2Frame		AlbumName			{ get; set; } = new ID3v2Frame(null, "TALB");
		public ID3v2Frame		AlbumArtistName		{ get; set; } = new ID3v2Frame(null, "TPE1");
		public ID3v2Frame		TrackGenre			{ get; set; } = new ID3v2Frame(null, "TCON");
		public ID3v2Frame		ComposerName		{ get; set; } = new ID3v2Frame(null, "TCOM");
		#endregion	
		
		#region ID3e
								//ID3e Tags
									//Fields		
		public string			RemixerName			{ get; set; } = null;

									//Meters
		public byte?			KlayMeter			{ get; set; } = null;
		public byte?			PopularityMeter		{ get; set; } = null;

									[Flags]
		public enum				MoodFlags
		{
			
		}
		#endregion


		public Track(string filePath)
		{
			//Assigns
			trackFileInfo = new FileInfo(filePath);
			File = new ID3Info(trackFileInfo.FullName, false);

			//Existence check
			if (!trackFileInfo.Exists) ObjectStatus = ObjectStatusEnum.noFile;
			else ObjectStatus = ObjectStatusEnum.@new;

			//Open File
			ImportAllTagsFromFile();
			//Get Values
			//Close File
		}
		public Track(int TrackDatabaseID)
		{
			trackID = TrackDatabaseID;

			//Open Database
			//Get Values
			//Open File
			//Check File
		}

		public void AssignTrackID()
		{
			//Check Database for ID List
			//Find the First deleted object, or first empty
			//Clear Object if deleted
			//Assign ID
		}

		public void AssignArtistID()
		{
			//Check Database for ID List
			//Find the First deleted object, or first empty
			//Clear Object if deleted
			//Assign ID
		}

		public void AssignAlbumID()
		{
			//Check Database for ID List
			//Find the First deleted object, or first empty
			//Clear Object if deleted
			//Assign ID
		}


		public void GetTextFrame(ref ID3v2Frame frame)
		{
			if (File.ID3v2Info.GetTextFrame(frame.FrameName) == "" || File.ID3v2Info.GetTextFrame(frame.FrameName) == null)
			{
				frame.FrameValue = null;
			}
			else frame.FrameValue = File.ID3v2Info.GetTextFrame(frame.FrameName);
		}

		public void SetTextFrame(ref ID3v2Frame frame)
		{
			File.ID3v2Info.SetTextFrame(frame.FrameName, frame.FrameValue.ToString());
		}

		public void ImportAllTagsFromFile()
		{
			File.Load();
		}
	}
}
