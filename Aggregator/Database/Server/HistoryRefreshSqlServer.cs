/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 14.03.2017
 * Время: 9:46
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using Aggregator.Data;

namespace Aggregator.Database.Server
{
	/// <summary>
	/// Description of HistoryRefreshSqlServer.
	/// </summary>
	public struct Table {
			public String name;
			public String represent;
			public String datetime;
			public String error;
			public String user;
	}
	
	public class HistoryRefreshSqlServer
	{
		SqlServer sqlServer;
		SqlConnection sqlConnection;
		SqlCommand sqlCommand;
		SqlDataReader sqlDataReader;
		
		List<Table> tables;
		
		public HistoryRefreshSqlServer()
		{
			tables = new List<Table>();
			Table table;
			
			sqlConnection = new SqlConnection(DataConfig.serverConnection);
			sqlCommand = new SqlCommand("SELECT [id], [name], [represent], [datetime], [error], [user] FROM History", sqlConnection);
			
			try{
				sqlConnection.Open();
				sqlDataReader = sqlCommand.ExecuteReader();
				while (sqlDataReader.Read())
		        {
					table.name = sqlDataReader["name"].ToString();
					table.represent = sqlDataReader["represent"].ToString();
					table.datetime = sqlDataReader["datetime"].ToString();
					table.error = sqlDataReader["error"].ToString();
					table.user = sqlDataReader["user"].ToString();
					tables.Add(table);
				}
				sqlDataReader.Close();
				sqlConnection.Close();
			}catch(Exception ex){
				Utilits.Console.Log("[МОНИТОРИНГ:ОШИБКА] " + ex.Message, false, true);
				if(sqlDataReader != null) sqlDataReader.Close();
				if(sqlConnection != null) sqlConnection.Close();
				return;
			}
			
			sqlServer = new SqlServer();
			sqlServer.sqlCommandSelect.CommandText = "SELECT [id], [name], [represent], [datetime], [error], [user] FROM History";
			sqlServer.sqlCommandUpdate.CommandText = "UPDATE History SET " +
					"[name] = @name, " +
					"[represent] = @represent, " +
					"[datetime] = @datetime, " +
					"[error] = @error, " +
					"[user] = @user " +
					"WHERE ([id] = @id)";
			sqlServer.sqlCommandUpdate.Parameters.Add("@name", SqlDbType.VarChar, 255, "name");
			sqlServer.sqlCommandUpdate.Parameters.Add("@represent", SqlDbType.VarChar, 255, "represent");
			sqlServer.sqlCommandUpdate.Parameters.Add("@datetime", SqlDbType.VarChar, 255, "datetime");
			sqlServer.sqlCommandUpdate.Parameters.Add("@error", SqlDbType.VarChar, 255, "error");
			sqlServer.sqlCommandUpdate.Parameters.Add("@user", SqlDbType.VarChar, 255, "user");
			sqlServer.sqlCommandUpdate.Parameters.Add("@id", SqlDbType.Int, 10, "id");
			if(!sqlServer.ExecuteFill("History")){
				Utilits.Console.Log("[МОНИТОРИНГ:ПРЕДУПРЕЖДЕНИЕ] История обновлений базы данных не загружена!", false, true);
			}
			Utilits.Console.Log("[МОНИТОРИНГ] Подготовка завершена.");
		}
		
		public void MonitoringRun()
		{
			if(sqlServer.dataSet.Tables.Count == 0){
				Utilits.Console.Log("[МОНИТОРИНГ:ПРЕДУПРЕЖДЕНИЕ] Мониторинг обновлений базы данных не удалось запустить!", false, true);
				DataForms.FClient.indicator(false);
				return;
			}
			
			try{
				SqlDependency.Stop(DataConfig.serverConnection);
				SqlDependency.Start(DataConfig.serverConnection);
	        	monitoringProcess();
	        	DataForms.FClient.indicator(true);
	        	Utilits.Console.Log("[МОНИТОРИНГ] Процесс успешно запущен.");
        	}catch(Exception ex){
				DataForms.FClient.indicator(false);
				Utilits.Console.Log("[МОНИТОРИНГ:ОШИБКА] " + ex.Message, false, true);
			}
		}
		
		void monitoringProcess()
		{
			using (SqlConnection connection = new SqlConnection(DataConfig.serverConnection))
	        {
	            connection.Open();
	            try{
		            using (var command = new SqlCommand(
		                "SELECT [id], [name], [represent], [datetime], [error], [user] FROM dbo.History", connection))
		            {
		                var sqlDependency = new SqlDependency(command);
		                sqlDependency.OnChange += new OnChangeEventHandler(onDependencyChange);
		                command.ExecuteReader();
		                Utilits.Console.Log("[МОНИТОРИНГ] Запуск события.");
		            }
	            	DataForms.FClient.indicator(true);
	            }catch(Exception ex){
					Utilits.Console.Log("[МОНИТОРИНГ:ОШИБКА] " + ex.Message, false, true);
					if(connection != null) connection.Close();
					DataForms.FClient.indicator(false);
					MonitoringStop();
					return;
				}
	        }
		}
		
		void onDependencyChange(object sender, SqlNotificationEventArgs args)
		{
			SqlNotificationInfo info = args.Info;
        	if (SqlNotificationInfo.Insert.Equals(info) 
			    || SqlNotificationInfo.Update.Equals(info)
            	|| SqlNotificationInfo.Delete.Equals(info))
        	{
				Utilits.Console.Log("[МОНИТОРИНГ] Получены новые данные с сервера.");
				
				Table table;
				int i = 0;
				
				try{
					sqlConnection = new SqlConnection(DataConfig.serverConnection);
					sqlCommand = new SqlCommand("SELECT [id], [name], [represent], [datetime], [error], [user] FROM History", sqlConnection);
					sqlConnection.Open();
					sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
			        {
						table.name = sqlDataReader["name"].ToString();
						table.represent = sqlDataReader["represent"].ToString();
						table.datetime = sqlDataReader["datetime"].ToString();
						table.error = sqlDataReader["error"].ToString();
						table.user = sqlDataReader["user"].ToString();

						if(tables[i].datetime != table.datetime){
							refresh(tables[i].name, tables[i].represent);
							tables[i] = table;
						}
						i++;
					}
					sqlDataReader.Close();
					sqlConnection.Close();
					DataForms.FClient.indicator(true);
				}catch(Exception ex){
					Utilits.Console.Log("[МОНИТОРИНГ:ОШИБКА] " + ex.Message, false, true);
					if(sqlDataReader != null) sqlDataReader.Close();
					if(sqlConnection != null) sqlConnection.Close();
					DataForms.FClient.indicator(false);
				}
        	}
			monitoringProcess();
		}

		public void MonitoringStop()
		{
			SqlDependency.Stop(DataConfig.serverConnection);
			Utilits.Console.Log("[МОНИТОРИНГ:ПРЕДУПРЕЖДЕНИЕ] Остановка процесса!", false, true);
			DataForms.FClient.indicator(false);
		}
		
		/* Обновить таблицы новыми данными */
		public void refresh(String tableName, String tableRepresent)
		{
			try{
				if(tableName == "Users" && DataForms.FUsers != null) DataForms.FUsers.TableRefresh();
				if(tableName == "Counteragents" && DataForms.FCounteragents != null) DataForms.FCounteragents.TableRefresh();
				if(tableName == "Nomenclature" && DataForms.FNomenclature != null) DataForms.FNomenclature.TableRefresh();
				if(tableName == "Units" && DataForms.FUnits != null) DataForms.FUnits.TableRefresh();
				if(tableName == "PurchasePlan" && DataForms.FPurchasePlanJournal != null) DataForms.FPurchasePlanJournal.TableRefresh();
				if(tableName == "PurchasePlan" && DataForms.FFullJournal != null) DataForms.FFullJournal.TableRefresh();
				if(tableName == "Orders" && DataForms.FOrderJournal != null) DataForms.FOrderJournal.TableRefresh();
				if(tableName == "Orders" && DataForms.FFullJournal != null) DataForms.FFullJournal.TableRefresh();
				
				Utilits.Console.Log("[МОНИТОРИНГ] Таблица '" + tableRepresent + "' была успешно обновлена.");
			}catch(Exception ex){
				Utilits.Console.Log("[МОНИТОРИНГ:ОШИБКА] Обновление таблицы '"+ tableRepresent + "' " + ex.Message.ToString(), false, true);
			}
		}
		
		/* Обновить */
		public void update(String tableName)
		{
			if(sqlServer.dataSet.Tables.Count == 0){
				Utilits.Console.Log("[МОНИТОРИНГ:ПРЕДУПРЕЖДЕНИЕ] Мониторинг не запущен! Не удалось обновить историю!", false, true);
				return;
			}
			
			try{
				sqlServer.dataSet.Tables["History"].Rows[getTableIndex(tableName)]["user"] = DataConfig.userName;
				sqlServer.dataSet.Tables["History"].Rows[getTableIndex(tableName)]["datetime"] = DateTime.Now.ToString();
				
				if(!sqlServer.ExecuteUpdate("History")) Utilits.Console.Log("[МОНИТОРИНГ:ОШИБКА] ошибка обновления данных.", false, true);
			}catch(Exception ex){
				sqlServer.Error();
				Utilits.Console.Log("[МОНИТОРИНГ:ОШИБКА] " + ex.Message.ToString(), false, true);
			}
		}
		
		int getTableIndex(String tableName)
		{
			if(tableName == "Users") return 0;
			if(tableName == "Counteragents") return 1;
			if(tableName == "Nomenclature") return 2;
			if(tableName == "Units") return 3;
			if(tableName == "PurchasePlan") return 4;
			if(tableName == "Orders") return 5;
			return -1;
		}
		
		public void Dispose()
		{
			if(sqlServer != null) sqlServer.Dispose();
			if(sqlDataReader != null) sqlDataReader.Close();
			if(sqlCommand != null) sqlCommand.Dispose();
			if(sqlConnection != null){
				sqlConnection.Close();
				sqlConnection.Dispose();
			}
			if(tables != null) {
				tables.Clear();
				tables = null;
			}
		}
		
	}
}
