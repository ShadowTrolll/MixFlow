using System.Collections.Generic;

namespace MixFlow_BareboneCSCore.Source.Meta.ID3v2
{
	public class ID3v2_Frame
	{
									//Variables
		public string				FrameName				{ get; private set; }	= null;
		public object				FrameValue				{ get; set; }			= null;

		public string				FrameVersion			{ get; private set; }
		public const string			FrameLatestVersion								= "2.4.0";


							//Methods
		public				ID3v2_Frame(string name, object value, string version = FrameLatestVersion)
		{
			FrameName	= name;
			FrameValue	= value;
		}
	}

	public static class ID3v2_FrameList
	{
		private static readonly string[]		FrameArray							= new string[]
			{
				"AENC",	//Audio encryption
				"ASPI", //Audio seek point index
				"APIC", //Attached picture
				"COMM", //Comments
				"COMR", //Commercial frame
				"ENCR", //Encryption method registration
				"EQU2", //Equalization
				"ETCO", //Event timing codes
				"GEOB", //General encapsulated object
				"GRID", //Group identification registration
				"TIPL", //Involved people list
				"LINK", //Linked information
				"MCDI", //Music CD identifier
				"MLLT", //MPEG location lookup table
				"OWNE", //Ownership frame
				"PRIV", //Private frame
				"PCNT", //Play counter
				"POPM", //Popularimeter
				"POSS", //Position synchronisation frame
				"RBUF", //Recommended buffer size
				"RVA2", //Relative volume adjustment
				"RVRB", //Reverb
				"SEEK", //Seek frame
				"SIGN", //Signature frame
				"SYLT", //Synchronized lyric/text
				"SYTC", //Synchronized tempo codes

				"TALB", //Album title
				"TBPM", //Beats per Minute (BPM)
				"TCOM", //Composer
				"TCON", //Content type
				"TCOP", //Copyright message
				"TDEN", //Encoding time
				"TDLY", //Playlist delay
				"TDRL", //Release time
				"TDTG", //Tagging time
				"TENC", //Encoded by
				"TEXT", //Lyricist/Text writer
				"TFLT", //File type
				"TDRC", //Time
				"TIT1", //Content group description
				"TIT2", //Title/songname/content description
				"TIT3", //Subtitle/Description refinement
				"TKEY", //Initial key
				"TLAN", //Languages
				"TLEN", //Length
				"TMCL", //Musician credits list
				"TMED", //Media type
				"TMOO", //Mood
				"TOAL", //Original album/movie/show title
				"TOFN", //Original filename
				"TOLY", //Original lyricist(s)/text writer(s)
				"TOPE", //Original artist(s)/performer(s)
				"TDOR", //Original release year
				"TOWN", //File owner/licensee
				"TPE1", //Lead performer(s)/Soloist(s)
				"TPE2", //Band/orchestra/accompaniment
				"TPE3", //Conductor/performer refinement
				"TPE4", //Interpreted, remixed, or otherwise modified by
				"TPOS", //Part of a set
				"TPRO", //Produced notice
				"TPUB", //Publisher
				"TRCK", //Track number/Position in set
				"TRSN", //Internet radio station name
				"TRSO", //Internet radio station owner
				"TSOA", //Album sort order
				"TSOP", //Performer sort order
				"TSOT", //Title sort order
				"TSRC", //International Standard Recording Code (ISRC)
				"TSSE", //Software/Hardware and settings used for encoding
				"TSST", //Set subtitle

				"UFID", //Unique file identifier
				"USER", //Terms of use
				"USLT", //Unsynchronized lyric/text transcription

				"WCOM", //Commercial information
				"WCOP", //Copyright/Legal information
				"WOAF", //Official audio file webpage
				"WOAR", //Official artist/performer webpage
				"WOAS", //Official audio source webpage
				"WORS", //Official internet radio station homepage
				"WPAY", //Payment
				"WPUB", //Publishers official webpage


				"TXXX", //User defined text information frame
				"WXXX", //User defined URL link frame
			};

		public static readonly List<string>		FrameList							= new List<string>(FrameArray);
	}
}

/* Documentation :
 * https://en.wikipedia.org/wiki/ID3#ID3v2_frame_specification
 * 
 * http://id3.org/id3v2.3.0
 * http://id3.org/Developer%20Information
 */
