/*
 * Created by SharpDevelop.
 * User: Somov Studio
 * Date: 25.02.2017
 * Time: 13:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data.OleDb;
using Aggregator.Data;
using Aggregator.Database.Local;

namespace Aggregator.Database.Config
{
	/// <summary>
	/// Description of SavingConfig.
	/// </summary>
	public static class SavingConfig
	{
		public static bool SaveDatabaseSettings()
		{
			DataConfig.oledbConnectLineBegin = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
			DataConfig.oledbConnectLineEnd = ";Jet OLEDB:Database Password=";
			DataConfig.oledbConnectPass = "12345";
			
			OleDb oleDb;
			oleDb = new OleDb(DataConfig.configFile);
			try{
				oleDb.oleDbCommandSelect.CommandText = "SELECT [id], [name], [localDatabase], [typeDatabase], [typeConnection], [serverConnection] FROM DatabaseSettings";
				oleDb.oleDbCommandUpdate.CommandText = "UPDATE DatabaseSettings SET " +
					"[name] = @name, " +
					"[localDatabase] = @localDatabase, " +
					"[typeDatabase] = @typeDatabase, " +
					"[typeConnection] = @typeConnection, " +
					"[serverConnection] = @serverConnection " +
					"WHERE ([id] = @id)";
				oleDb.oleDbCommandUpdate.Parameters.Add("@name", OleDbType.VarChar, 255, "name");
				oleDb.oleDbCommandUpdate.Parameters.Add("@localDatabase", OleDbType.VarChar, 255, "localDatabase");
				oleDb.oleDbCommandUpdate.Parameters.Add("@typeDatabase", OleDbType.VarChar, 255, "typeDatabase");
				oleDb.oleDbCommandUpdate.Parameters.Add("@typeConnection", OleDbType.VarChar, 255, "typeConnection");
				oleDb.oleDbCommandUpdate.Parameters.Add("@serverConnection", OleDbType.VarChar, 255, "serverConnection");
				oleDb.oleDbCommandUpdate.Parameters.Add("@id", OleDbType.Integer, 10, "id");
				oleDb.ExecuteFill("DatabaseSettings");
				
				oleDb.dataSet.Tables["DatabaseSettings"].Rows[0]["localDatabase"] = DataConfig.localDatabase;
				oleDb.dataSet.Tables["DatabaseSettings"].Rows[0]["typeDatabase"] = DataConfig.typeDatabase;
				oleDb.dataSet.Tables["DatabaseSettings"].Rows[0]["typeConnection"] = DataConfig.typeConnection;
				oleDb.dataSet.Tables["DatabaseSettings"].Rows[0]["serverConnection"] = DataConfig.serverConnection;
				oleDb.ExecuteUpdate("DatabaseSettings");
				
				oleDb.Dispose();
				Utilits.Console.Log("Сохранение настроек соединения с базой данных прошло успешно.");
				
				DataConfig.oledbConnectLineBegin = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
				DataConfig.oledbConnectLineEnd = "";
				DataConfig.oledbConnectPass = "";
				
				return true;
			}catch(Exception ex){
				oleDb.Error();
				Utilits.Console.Log("[ОШИБКА] Сохранение настроек соединения с базой данных. " + ex.Message.ToString(), false, true);
				
				DataConfig.oledbConnectLineBegin = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
				DataConfig.oledbConnectLineEnd = "";
				DataConfig.oledbConnectPass = "";
				
				return false;
			}
		}
		
		public static bool SaveSettings()
		{
			DataConfig.oledbConnectLineBegin = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
			DataConfig.oledbConnectLineEnd = ";Jet OLEDB:Database Password=";
			DataConfig.oledbConnectPass = "12345";
			
			OleDb oleDb;
			oleDb = new OleDb(DataConfig.configFile);
			try{
				oleDb.oleDbCommandSelect.CommandText = "SELECT [id], [autoUpdate], [showConsole], [period] FROM Settings";
				oleDb.oleDbCommandUpdate.CommandText = "UPDATE Settings SET " +
					"[autoUpdate] = @autoUpdate, " +
					"[showConsole] = @showConsole, " +
					"[period] = @period " +
					"WHERE ([id] = @id)";
				oleDb.oleDbCommandUpdate.Parameters.Add("@autoUpdate", OleDbType.VarChar, 255, "autoUpdate");
				oleDb.oleDbCommandUpdate.Parameters.Add("@showConsole", OleDbType.VarChar, 255, "showConsole");
				oleDb.oleDbCommandUpdate.Parameters.Add("@period", OleDbType.VarChar, 255, "period");
				oleDb.oleDbCommandUpdate.Parameters.Add("@id", OleDbType.Integer, 10, "id");
				oleDb.ExecuteFill("Settings");
				
				oleDb.dataSet.Tables["Settings"].Rows[0]["autoUpdate"] = DataConfig.autoUpdate.ToString();
				oleDb.dataSet.Tables["Settings"].Rows[0]["showConsole"] = DataConfig.showConsole.ToString();
				oleDb.dataSet.Tables["Settings"].Rows[0]["period"] = DataConfig.period;
				
				if(oleDb.ExecuteUpdate("Settings")){
					oleDb.Dispose();
					Utilits.Console.Log("Сохранение настроек программы прошло успешно.");
					
					DataConfig.oledbConnectLineBegin = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
					DataConfig.oledbConnectLineEnd = "";
					DataConfig.oledbConnectPass = "";
					
					return true;
				}else{
					oleDb.Error();
					Utilits.Console.Log("[ОШИБКА] Настройки программы не сохранены.", false, true);
					
					DataConfig.oledbConnectLineBegin = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
					DataConfig.oledbConnectLineEnd = "";
					DataConfig.oledbConnectPass = "";
					
					return false;
				}
			}catch(Exception ex){
				oleDb.Error();
				Utilits.Console.Log("[ОШИБКА] " + ex.Message.ToString(), false, true);
				
				DataConfig.oledbConnectLineBegin = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
				DataConfig.oledbConnectLineEnd = "";
				DataConfig.oledbConnectPass = "";
				
				return false;
			}
		}
	}
}
