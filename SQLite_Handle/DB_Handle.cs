using System;
using System.Collections.Generic;
using System.Text;
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

	public class DBHandle : I_SQLiteHandle
	{
		//Variables
		public string DatabasePath { get; set; }
		protected SQLiteConnection DBConnection;

		//(De-)Constructors
		public DBHandle(string dbPath, FileMode fileMode = FileMode.OpenOrCreate, int version = 3)
		{
			DBConnection = new SQLiteConnection("Data source :" + dbPath + "; version=" + version + ";");
			OpenDatabase(fileMode);
		}

		//Methods

		public void OpenDatabase(FileMode fileMode = FileMode.OpenOrCreate)
		{
			bool dbExists = File.Exists(DatabasePath);

			if (fileMode == FileMode.OpenOrCreate)
			{
				if (!dbExists)
				{
					SQLiteConnection.CreateFile(DatabasePath);
				}

				DBConnection.Open();
			}
			else if (fileMode == FileMode.Create)
			{
				File.Create(DatabasePath);
			}
			else if (fileMode == FileMode.Open)
			{
				try
				{
					DBConnection.Open();
				}
				catch (FileNotFoundException e)
				{
					Utilities.Utilities.ExceptionHandle("Please check file availability, or change FileMode. File : " + DatabasePath, e);
#if DEBUG
					OpenDatabase(FileMode.OpenOrCreate);
		#else
							throw;
#endif
				}

			}
			else if (fileMode == FileMode.CreateNew)
			{
				if (dbExists)
				{
					throw new NotImplementedException();
				}
				else
				{
					SQLiteConnection.CreateFile(DatabasePath);
				}
			}
		}

		public void Transaction(string transactionNonQuery)
		{

			SQLiteCommand command = new SQLiteCommand(transactionNonQuery, DBConnection);
			try
			{
				command.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				Utilities.Utilities.ExceptionHandle(e);
				throw;
			}

		}
		public void Transaction(SQLiteCommand commandNonQuery)
		{
			commandNonQuery.ExecuteNonQuery();
		}
		public void Transaction(string transactionQuery, out SQLiteDataReader dataOut)
		{
			SQLiteCommand command = new SQLiteCommand(transactionQuery, DBConnection);
			dataOut = command.ExecuteReader();
		}
		public void Transaction(SQLiteCommand commandQuery, out SQLiteDataReader dataOut)
		{
			dataOut = commandQuery.ExecuteReader();
		}
	}
}
