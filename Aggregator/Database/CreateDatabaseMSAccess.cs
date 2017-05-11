/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 06.05.2017
 * Время: 12:27
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using ADOX;
using Aggregator.Data;
using Aggregator.Database.Local;

namespace Aggregator.Database
{
	/// <summary>
	/// Description of CreateDatabaseMSAccess.
	/// </summary>
	public class CreateDatabaseMSAccess
	{
		Catalog ADOXCatalog;
		String fileName;
		String strConnection;
		
		public CreateDatabaseMSAccess(String baseFileName)
		{
			fileName = baseFileName;
		}
		
		public bool CreateDB()
		{
			strConnection = DataConfig.oledbConnectLineBegin + fileName + DataConfig.oledbConnectLineEnd + DataConfig.oledbConnectPass;
			
			ADOXCatalog = new Catalog();
			ADOXCatalog.Create(strConnection);
			if(File.Exists(fileName)){
				
				/* Создание таблиц */
				tableUsers();
				tableConstants();
				tableCounteragents();
				tableNomenclature();
				tableUnits();
				tablePurchasePlan();
				tablePurchasePlanPriceLists();
				tableOrderNomenclature();
				tableOrders();
				tableHistory();
				
				Utilits.Console.Log("Базу данных " + fileName + " успешно создана!");
				MessageBox.Show("База данных успешно создана!", "Сообщение");
				return true;
			}else{
				Utilits.Console.Log("Не удалось создать базу данных " + fileName, false, true);
				MessageBox.Show("Не удалось создать базу данных!", "Ошибка");
				return false;
			}
		}
		
		
		/* =========================================================================================
		 * Создание таблиц в базе данных 
		 * =========================================================================================
		 */
		void tableUsers()
		{
			String sqlCommand;
			QueryOleDb query;
			query = new QueryOleDb(strConnection);
			
			sqlCommand = "CREATE TABLE Users (" +
				"[id] COUNTER PRIMARY KEY, " +
				"[name] VARCHAR DEFAULT '' UNIQUE, " +
				"[pass] VARCHAR DEFAULT '', " +
				"[permissions] VARCHAR DEFAULT '', " +
				"[info] TEXT" +
				")";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы Пользователи.", false, true);
			
			sqlCommand = "INSERT INTO Users (" +
				"[name], [pass], [permissions], [info]) " +
				"VALUES ('Администратор', '', 'admin', '')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Пользователи.", false, true);
			
			sqlCommand = "INSERT INTO Users (" +
				"[name], [pass], [permissions], [info]) " +
				"VALUES ('Оператор', '', 'operator', '')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Пользователи.", false, true);
			
			sqlCommand = "INSERT INTO Users (" +
				"[name], [pass], [permissions], [info]) " +
				"VALUES ('Пользователь', '', 'user', '')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Пользователи.", false, true);
			
			sqlCommand = "INSERT INTO Users (" +
				"[name], [pass], [permissions], [info]) " +
				"VALUES ('Гость', '', 'guest', '')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Пользователи.", false, true);
			
			query.Dispose();
		}
		
		void tableConstants()
		{
			String sqlCommand;
			QueryOleDb query;
			query = new QueryOleDb(strConnection);
			
			sqlCommand = "CREATE TABLE Constants (" +
				"[id] COUNTER PRIMARY KEY, " +
				"[name] VARCHAR DEFAULT '', " +
				
				"[email] VARCHAR DEFAULT '', " +
				"[emailPwd] VARCHAR DEFAULT '', " +
				"[smtpServer] VARCHAR DEFAULT '', " +
				"[port] VARCHAR DEFAULT '', " +
				"[EnableSsl] INTEGER DEFAULT 0, " +
				"[caption] VARCHAR DEFAULT '', " +
				"[message] TEXT DEFAULT '', " +
				
				"[address] VARCHAR DEFAULT '', " +
				"[vat] FLOAT DEFAULT 0, " +
				"[units] VARCHAR DEFAULT '' " +
				")";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы Константы.", false, true);
			
			sqlCommand = "INSERT INTO Constants (" +
				"[name], [email], [emailPwd], [smtpServer], [port], [EnableSsl], [caption], [message], [address], [vat], [units]) " +
				"VALUES ('Наша Фирма', 'mymail@gmail.com', '0000', 'smtp.gmail.com', '587', 1, 'Тема письма', 'Сообщение письма', 'Страна, Город, Улица, Дом', 20, 'шт.')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Константы.", false, true);
			
			query.Dispose();
		}
		
		void tableCounteragents()
		{
			String sqlCommand;
			QueryOleDb query;
			query = new QueryOleDb(strConnection);
			
			sqlCommand = "CREATE TABLE Counteragents (" +
				"[id] COUNTER PRIMARY KEY, " +
				"[type] VARCHAR DEFAULT '', " +
				"[name] VARCHAR DEFAULT '' UNIQUE, " +
				"[organization_address] VARCHAR DEFAULT '', " +
				"[organization_phone] VARCHAR DEFAULT '', " +
				"[organization_site] VARCHAR DEFAULT '', " +
				"[organization_email] VARCHAR DEFAULT '', " +
				"[contact_fullname] VARCHAR DEFAULT '', " +
				"[contact_post] VARCHAR DEFAULT '', " +
				"[contact_phone] VARCHAR DEFAULT '', " +
				"[contact_skype] VARCHAR DEFAULT '', " +
				"[contact_email] VARCHAR DEFAULT '', " +
				"[information] TEXT DEFAULT '', " +
				"[excel_filename] TEXT DEFAULT '', " +
				"[excel_date] VARCHAR DEFAULT '', " +
				"[excel_column_name] INTEGER DEFAULT 0, " +
				"[excel_column_code] INTEGER DEFAULT 0, " +
				"[excel_column_series] INTEGER DEFAULT 0, " +
				"[excel_column_article] INTEGER DEFAULT 0, " +
				"[excel_column_remainder] INTEGER DEFAULT 0, " +
				"[excel_column_manufacturer] INTEGER DEFAULT 0, " +
				"[excel_column_price] INTEGER DEFAULT 0, " +
				"[excel_column_discount_1] INTEGER DEFAULT 0, " +
				"[excel_column_discount_2] INTEGER DEFAULT 0, " +
				"[excel_column_discount_3] INTEGER DEFAULT 0, " +
				"[excel_column_discount_4] INTEGER DEFAULT 0, " +
				"[excel_column_term] INTEGER DEFAULT 0, " +
				"[excel_table_id] VARCHAR DEFAULT '', " +
				"[parent] VARCHAR DEFAULT ''" +
				")";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы Контрагенты.", false, true);
		}
		
		void tableNomenclature()
		{
			String sqlCommand;
			QueryOleDb query;
			query = new QueryOleDb(strConnection);
			
			sqlCommand = "CREATE TABLE Nomenclature (" +
				"[id] COUNTER PRIMARY KEY, " +
				"[type] VARCHAR DEFAULT '', " +
				"[name] VARCHAR DEFAULT '', " +
				"[code] VARCHAR DEFAULT '', " +
				"[series] VARCHAR DEFAULT '', " +
				"[article] VARCHAR DEFAULT '', " +
				"[manufacturer] VARCHAR DEFAULT '', " +
				"[price] FLOAT DEFAULT 0, " +
				"[units] VARCHAR DEFAULT '', " +
				"[parent] VARCHAR DEFAULT ''" +
				")";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы Номенклатура.", false, true);
		}
		
		void tableUnits()
		{
			String sqlCommand;
			QueryOleDb query;
			query = new QueryOleDb(strConnection);
			
			sqlCommand = "CREATE TABLE Units (" +
				"[id] COUNTER PRIMARY KEY, " +
				"[name] VARCHAR DEFAULT '' UNIQUE, " +
				"[info] TEXT" +
				")";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы Единицы измерения.", false, true);
			
			sqlCommand = "INSERT INTO Units (" +
				"[name], [info]) " +
				"VALUES ('г.', 'Граммы.')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Единицы измерения.", false, true);
			
			sqlCommand = "INSERT INTO Units (" +
				"[name], [info]) " +
				"VALUES ('кг.', 'Килограммы.')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Единицы измерения.", false, true);
			
			sqlCommand = "INSERT INTO Units (" +
				"[name], [info]) " +
				"VALUES ('л.', 'Литры.')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Единицы измерения.", false, true);
			
			sqlCommand = "INSERT INTO Units (" +
				"[name], [info]) " +
				"VALUES ('м.', 'Метры.')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Единицы измерения.", false, true);
			
			sqlCommand = "INSERT INTO Units (" +
				"[name], [info]) " +
				"VALUES ('см.', 'Сантиметры.')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Единицы измерения.", false, true);
			
			sqlCommand = "INSERT INTO Units (" +
				"[name], [info]) " +
				"VALUES ('шт.', 'Штуки.')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Единицы измерения.", false, true);
			
			sqlCommand = "INSERT INTO Units (" +
				"[name], [info]) " +
				"VALUES ('уп.', 'Упаковки.')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Единицы измерения.", false, true);
			
			sqlCommand = "INSERT INTO Units (" +
				"[name], [info]) " +
				"VALUES ('ящ.', 'Ящики.')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Единицы измерения.", false, true);
		}
				
		void tablePurchasePlan() //	Документ: План закупок
		{
			String sqlCommand;
			QueryOleDb query;
			query = new QueryOleDb(strConnection);
			
			sqlCommand = "CREATE TABLE PurchasePlan (" +
				"[id] COUNTER PRIMARY KEY, " +
				"[docDate] DATETIME, " +
				"[docNumber] VARCHAR DEFAULT '' UNIQUE, " +
				"[docName] VARCHAR DEFAULT '', " +
				"[docAutor] VARCHAR DEFAULT '', " +
				"[docSum] FLOAT DEFAULT 0, " +
				"[docVat] FLOAT DEFAULT 0, " +
				"[docTotal] FLOAT DEFAULT 0" +
				")";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы План закупок.", false, true);
		}
		
		void tablePurchasePlanPriceLists()
		{
			String sqlCommand;
			QueryOleDb query;
			query = new QueryOleDb(strConnection);
			
			sqlCommand = "CREATE TABLE PurchasePlanPriceLists (" +
				"[id] COUNTER PRIMARY KEY, " +
				"[counteragentName] VARCHAR DEFAULT '', " +
				"[counteragentPricelist] VARCHAR DEFAULT '', " +
				"[docID] VARCHAR DEFAULT '' " +
				")";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы План закупок.", false, true);
		}
		
		void tableOrderNomenclature()
		{
			String sqlCommand;
			QueryOleDb query;
			query = new QueryOleDb(strConnection);
			
			sqlCommand = "CREATE TABLE OrderNomenclature (" +
				"[id] COUNTER PRIMARY KEY, " +
				"[nomenclatureID] INTEGER DEFAULT 0, " +
				"[nomenclatureName] VARCHAR DEFAULT '', " +
				"[units] VARCHAR DEFAULT '', " +
				"[amount] FLOAT DEFAULT 0, " +
				"[name] VARCHAR DEFAULT '', " +
				"[price] FLOAT DEFAULT 0, " +
				"[manufacturer] VARCHAR DEFAULT '', " +
				"[remainder] FLOAT DEFAULT 0, " +
				"[term] DATETIME, " +
				"[discount1] FLOAT DEFAULT 0, " +
				"[discount2] FLOAT DEFAULT 0, " +
				"[discount3] FLOAT DEFAULT 0, " +
				"[discount4] FLOAT DEFAULT 0, " +
				"[code] VARCHAR DEFAULT '', " +
				"[series] VARCHAR DEFAULT '', " +
				"[article] VARCHAR DEFAULT '', " +
				"[counteragentName] VARCHAR DEFAULT '', " +
				"[counteragentPricelist] VARCHAR DEFAULT '', " +
				"[docPurchasePlan] VARCHAR DEFAULT '', " +
				"[docOrder] VARCHAR DEFAULT '' " +
				")";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы Заказ номенклатуры.", false, true);
		}
		
		void tableOrders() // Документ: Заказ
		{
			String sqlCommand;
			QueryOleDb query;
			query = new QueryOleDb(strConnection);
			
			sqlCommand = "CREATE TABLE Orders (" +
				"[id] COUNTER PRIMARY KEY, " +
				"[docDate] DATETIME, " +
				"[docNumber] VARCHAR DEFAULT '' UNIQUE, " +
				"[docName] VARCHAR DEFAULT '', " +
				"[docCounteragent] VARCHAR DEFAULT '', " +
				"[docAutor] VARCHAR DEFAULT '', " +
				"[docSum] FLOAT DEFAULT 0, " +
				"[docVat] FLOAT DEFAULT 0, " +
				"[docTotal] FLOAT DEFAULT 0, " +
				"[docPurchasePlan] VARCHAR DEFAULT ''" +
				")";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы Заказы.", false, true);
		}
		
		void tableHistory()
		{
			String sqlCommand;
			QueryOleDb query;
			query = new QueryOleDb(strConnection);
			
			sqlCommand = "CREATE TABLE History (" +
				"[id] COUNTER PRIMARY KEY, " +
				"[name] VARCHAR DEFAULT '' UNIQUE, " +
				"[represent] VARCHAR DEFAULT '', " +
				"[datetime] VARCHAR DEFAULT '', " +
				"[error] VARCHAR DEFAULT '', " +
				"[user] VARCHAR DEFAULT ''" +
				")";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы История.", false, true);
			
			sqlCommand = "INSERT INTO History (" +
				"[name], [represent], [datetime], [error], [user]) " +
				"VALUES ('Users', 'Пользователи', '" + DateTime.Now.ToString() + "', '', '" + DataConfig.userName + "')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу История.", false, true);
			
			sqlCommand = "INSERT INTO History (" +
				"[name], [represent], [datetime], [error], [user]) " +
				"VALUES ('Counteragents', 'Контрагенты', '" + DateTime.Now.ToString() + "', '', '" + DataConfig.userName + "')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу История.", false, true);
			
			sqlCommand = "INSERT INTO History (" +
				"[name], [represent], [datetime], [error], [user]) " +
				"VALUES ('Nomenclature', 'Номенклатура', '" + DateTime.Now.ToString() + "', '', '" + DataConfig.userName + "')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу История.", false, true);
			
			sqlCommand = "INSERT INTO History (" +
				"[name], [represent], [datetime], [error], [user]) " +
				"VALUES ('Units', 'Единицы измерения', '" + DateTime.Now.ToString() + "', '', '" + DataConfig.userName + "')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу История.", false, true);
			
			sqlCommand = "INSERT INTO History (" +
				"[name], [represent], [datetime], [error], [user]) " +
				"VALUES ('PurchasePlan', 'План закупок', '" + DateTime.Now.ToString() + "', '', '" + DataConfig.userName + "')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу История.", false, true);
			
			sqlCommand = "INSERT INTO History (" +
				"[name], [represent], [datetime], [error], [user]) " +
				"VALUES ('Orders', 'Заказы', '" + DateTime.Now.ToString() + "', '', '" + DataConfig.userName + "')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу История.", false, true);
		}
		
	}
}
