/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 06.04.2017
 * Время: 8:26
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using Aggregator.Data;
using Aggregator.Database.Local;
using Aggregator.Database.Server;

namespace Aggregator.Database.Constants
{
	/// <summary>
	/// Description of SavingConstants.
	/// </summary>
	public class SavingConstants
	{
		QueryOleDb oleDbQuery;
		QuerySqlServer sqlQuery;
				
		public SavingConstants()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				// OLEDB
				oleDbQuery = new QueryOleDb(DataConfig.localDatabase);
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				sqlQuery = new QuerySqlServer(DataConfig.serverConnection);
			}
		}
		
		public void save()
		{
			String sqlCommand;
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				// OLEDB
				sqlCommand = "UPDATE Constants SET " +
					"[name] = '" + DataConstants.ConstFirmName + "', " +
					"[email] = '" + DataConstants.ConstFirmEmail + "', " +
					"[emailPwd] = '" + DataConstants.ConstFirmPwd + "', " +
					"[smtpServer] = '" + DataConstants.ConstFirmSmtp + "', " +
					"[port] = '" + DataConstants.ConstFirmPort + "', " +
					"[EnableSsl] = " + Convert.ToInt32(DataConstants.ConstFirmEnableSsl).ToString() + ", " +
					"[caption] = '" + DataConstants.ConstFirmCaption + "', " +
					"[message] = '" + DataConstants.ConstFirmMessage + "', " +
					"[address] = '" + DataConstants.ConstFirmAddress + "', " +
					"[vat] = " + DataConstants.ConstFirmVAT.ToString() + ", " +
					"[units] = '" + DataConstants.ConstFirmUnits + "' " +
					"WHERE (id = 1)";
				oleDbQuery.SetCommand(sqlCommand);
				if(!oleDbQuery.Execute()) Utilits.Console.Log("[ОШИБКА] Не удалось сохранить константы.", false, true);
				else Utilits.Console.Log("Константы успешно сохранены.");
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				sqlCommand = "UPDATE Constants SET " +
					"[name] = '" + DataConstants.ConstFirmName + "', " +
					"[email] = '" + DataConstants.ConstFirmEmail + "', " +
					"[emailPwd] = '" + DataConstants.ConstFirmPwd + "', " +
					"[smtpServer] = '" + DataConstants.ConstFirmSmtp + "', " +
					"[port] = '" + DataConstants.ConstFirmPort + "', " +
					"[EnableSsl] = " + Convert.ToInt32(DataConstants.ConstFirmEnableSsl).ToString() + ", " +
					"[caption] = '" + DataConstants.ConstFirmCaption + "', " +
					"[message] = '" + DataConstants.ConstFirmMessage + "', " +
					"[address] = '" + DataConstants.ConstFirmAddress + "', " +
					"[vat] = " + DataConstants.ConstFirmVAT.ToString() + ", " +
					"[units] = '" + DataConstants.ConstFirmUnits + "' " +
					"WHERE (id = 1)";
				sqlQuery.SetCommand(sqlCommand);
				if(!sqlQuery.Execute()) Utilits.Console.Log("[ОШИБКА] Не удалось сохранить константы.", false, true);
				else Utilits.Console.Log("Константы успешно сохранены.");
			}
		}
		
		public void Dispose()
		{
			if(oleDbQuery != null) oleDbQuery.Dispose();
			if(sqlQuery != null) sqlQuery.Dispose();
		}
	}
}
