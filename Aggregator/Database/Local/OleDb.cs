/*
 * Created by SharpDevelop.
 * User: Somov Studio
 * Date: 26.02.2017
 * Time: 9:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Data.OleDb;
using Aggregator.Data;

namespace Aggregator.Database.Local
{
	/// <summary>
	/// Description of OleDb.
	/// </summary>
	public class OleDb
	{
		public OleDbCommand oleDbCommandSelect;
		public OleDbCommand oleDbCommandInsert;
		public OleDbCommand oleDbCommandUpdate;
		public OleDbCommand oleDbCommandDelete;
		public DataSet dataSet;
		
		OleDbConnection oleDbConnection;
		OleDbDataAdapter oleDbDataAdapter;
				
		public OleDb(String databaseFile)
		{
			oleDbConnection = new OleDbConnection();
			oleDbConnection.ConnectionString = DataConfig.oledbConnectLineBegin + databaseFile + DataConfig.oledbConnectLineEnd + DataConfig.oledbConnectPass;
			oleDbCommandSelect = new OleDbCommand("", oleDbConnection);
			oleDbCommandInsert = new OleDbCommand("", oleDbConnection);
			oleDbCommandUpdate = new OleDbCommand("", oleDbConnection);
			oleDbCommandDelete = new OleDbCommand("", oleDbConnection);
			oleDbDataAdapter = new OleDbDataAdapter();
			dataSet = new DataSet();
		}
		
		public bool ExecuteFill(String tableName){
			oleDbDataAdapter.SelectCommand = oleDbCommandSelect;
			oleDbDataAdapter.InsertCommand = oleDbCommandInsert;
			oleDbDataAdapter.UpdateCommand = oleDbCommandUpdate;
			oleDbDataAdapter.DeleteCommand = oleDbCommandDelete;
			try{
				oleDbConnection.Open();
				oleDbDataAdapter.Fill(dataSet, tableName);
				oleDbConnection.Close();
				return true;
			}catch(Exception ex){
				oleDbConnection.Close();
				Utilits.Console.Log("[ОШИБКА] " + ex.Message.ToString(), false, true);
				return false;
			}
		}
		
		public bool ExecuteUpdate(String tableName){
			oleDbDataAdapter.SelectCommand = oleDbCommandSelect;
			oleDbDataAdapter.InsertCommand = oleDbCommandInsert;
			oleDbDataAdapter.UpdateCommand = oleDbCommandUpdate;
			oleDbDataAdapter.DeleteCommand = oleDbCommandDelete;
			try{
				oleDbConnection.Open();
				oleDbDataAdapter.Update(dataSet, tableName);
				oleDbConnection.Close();
				return true;
			}catch(Exception ex){
				oleDbConnection.Close();
				//Utilits.Console.Log("[ОШИБКА] " + ex.Message.ToString(), false, true);
				Utilits.Console.Log("[ОШИБКА] " + ex.ToString(), false, true);
				return false;
			}
		} 
		
		public void Error()
		{
			Dispose();
		}
		
		public void Dispose()
		{
			if(oleDbConnection != null) {
				oleDbConnection.Close();
				oleDbConnection.Dispose();
			}
			if(oleDbCommandSelect != null) oleDbCommandSelect.Dispose();
			if(oleDbCommandDelete != null) oleDbCommandDelete.Dispose();
			if(oleDbCommandUpdate != null) oleDbCommandUpdate.Dispose();
			if(oleDbCommandInsert != null) oleDbCommandInsert.Dispose();
			if(oleDbDataAdapter != null) oleDbDataAdapter.Dispose();
			if(dataSet != null){
				dataSet.Clear();
				dataSet.Dispose();
			}
		}
		
	}
}
