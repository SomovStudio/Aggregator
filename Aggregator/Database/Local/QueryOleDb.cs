/*
 * Created by SharpDevelop.
 * User: Somov Studio
 * Date: 25.02.2017
 * Time: 15:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data.OleDb;
using Aggregator.Data;

namespace Aggregator.Database.Local
{
	/// <summary>
	/// Description of QueryOleDb.
	/// </summary>
	public class QueryOleDb
	{
		OleDbConnection oleDbConnection;
		OleDbCommand oleDbCommand;
		
		public QueryOleDb(String fileBase)
		{
			oleDbConnection = new OleDbConnection();
			oleDbConnection.ConnectionString = DataConfig.oledbConnectLineBegin + fileBase + DataConfig.oledbConnectLineEnd + DataConfig.oledbConnectPass;
		}
		
		public void SetCommand(String sqlCommand)
		{
			oleDbCommand = new OleDbCommand(sqlCommand, oleDbConnection);
		}
		
		public bool Execute()
		{
			try{
				oleDbConnection.Open();
				oleDbCommand.ExecuteNonQuery();	//выполнение запроса				
				oleDbConnection.Close();
				return true;
			}catch(Exception ex){
				oleDbConnection.Close();
				Utilits.Console.Log(oleDbCommand.CommandText);
				Utilits.Console.Log("[ОШИБКА] " + ex.Message.ToString(), false, true);
				return false;
			}
		}
		
		public void Dispose()
		{
			if(oleDbCommand != null) oleDbCommand.Dispose();
			if(oleDbConnection != null) oleDbConnection.Dispose();
		}
		
	}
}
