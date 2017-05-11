/*
 * Created by SharpDevelop.
 * User: Somov Studio
 * Date: 26.02.2017
 * Time: 12:36
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
	/// Description of CreateConfigTables.
	/// </summary>
	public static class CreateConfigTables
	{
		public static void TableUsers()
		{
			String sqlCommand;
			QueryOleDb query;
			query = new QueryOleDb(DataConfig.configFile);
			
			sqlCommand = "CREATE TABLE Users (" +
				"[id] COUNTER PRIMARY KEY, " +
				"[name] VARCHAR DEFAULT '' UNIQUE, " +
				"[pass] VARCHAR DEFAULT '', " +
				"[permissions] VARCHAR DEFAULT 'user'" +
				")";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы Users.", false, true);
			
			sqlCommand = "INSERT INTO Users (" +
				"[name], [pass], [permissions]) " +
				"VALUES ('Администратор', '', 'admin')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Users.", false, true);
			
			sqlCommand = "INSERT INTO Users (" +
				"[name], [pass], [permissions]) " +
				"VALUES ('Пользователь', '', 'user')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Users.", false, true);
			query.Dispose();
		}
		
		public static void TableDatabaseSettings()
		{
			DataConfig.localDatabase = DataConfig.resource + "\\database.mdb";
			DataConfig.typeConnection = DataConstants.CONNETION_LOCAL;
			DataConfig.typeDatabase = DataConstants.TYPE_OLEDB;
			DataConfig.serverConnection = "Server=***\\SQLEXPRESS;Database=***;User Id=sa;Password=***";
			
			String sqlCommand;
			QueryOleDb query;
			query = new QueryOleDb(DataConfig.configFile);
			
			sqlCommand = "CREATE TABLE DatabaseSettings (" +
				"[id] COUNTER PRIMARY KEY, " +
				"[name] VARCHAR DEFAULT '' UNIQUE, " +
				"[localDatabase] TEXT DEFAULT '', " +
				"[typeDatabase] VARCHAR DEFAULT '', " +
				"[typeConnection] VARCHAR DEFAULT '', " +
				"[serverConnection] VARCHAR DEFAULT ''" +
				")";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы DatabaseSettings.", false, true);
			
			sqlCommand = "INSERT INTO DatabaseSettings (" +
				"[name], [localDatabase], [typeDatabase], [typeConnection], " +
				"[serverConnection]) " +
				"VALUES ('database', '" + DataConfig.localDatabase + "', '" 
				+ DataConfig.typeDatabase +"', '" + DataConfig.typeConnection + "', '"
				+ DataConfig.serverConnection + "')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу DatabaseSettings.", false, true);
			query.Dispose();
		}
		
		public static void TableSettings()
		{
			String sqlCommand;
			QueryOleDb query;
			query = new QueryOleDb(DataConfig.configFile);
			
			sqlCommand = "CREATE TABLE Settings (" +
				"[id] COUNTER PRIMARY KEY, " +
				"[autoUpdate] VARCHAR(10) DEFAULT '', " +
				"[showConsole] VARCHAR(10) DEFAULT '', " +
				"[period] VARCHAR(25) DEFAULT ''" +
				")";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы Settings.", false, true);
			
			sqlCommand = "INSERT INTO Settings (" +
				"[autoUpdate], [showConsole], [period]) " +
				"VALUES ('False', 'True', 'today')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Settings.", false, true);
		}
	}
}
