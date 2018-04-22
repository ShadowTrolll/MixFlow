using System.IO;
using System.Data.SQLite;

namespace MixFlow.SQLite_Handle
{
	public interface I_SQLiteHandle
	{
		string DatabasePath { get; set; }


		void OpenDatabase(FileMode fileMode = FileMode.OpenOrCreate);

		void Transaction(string transactionNonQuery);
		void Transaction(string transactionQuery, out SQLiteDataReader dataOut);
	}
}
