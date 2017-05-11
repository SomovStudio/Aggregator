/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 06.05.2017
 * Время: 12:28
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Aggregator.Data;
using Aggregator.Database.Server;

namespace Aggregator.Database
{
	/// <summary>
	/// Description of CreateDatabaseMSSQL.
	/// </summary>
	public class CreateDatabaseMSSQL
	{
		String newDBName;
		String serverName;
		String dbName;
		String userName;
		String pass;
		
		String connectionString;
		
		SqlConnection connection = null;
		SqlCommand command = null;
		
		public CreateDatabaseMSSQL(String newDatabase, String server, String database, String user, String password)
		{
			newDBName = newDatabase;
			serverName = server;
			dbName = database;
			userName = user;
			pass = password;
			connectionString = "Server=" + serverName + ";Database=" + dbName + ";User Id=" + userName + ";Password=" + pass;
			connection = new SqlConnection(connectionString);
		}
		
		public bool CreateDB()
		{
			try{
				command = new SqlCommand("CREATE DATABASE " + newDBName, connection);
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();
				
				/* Создание таблиц */
				connectionString = "Server=" + serverName + ";Database=" + newDBName + ";User Id=" + userName + ";Password=" + pass;
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
				
				Utilits.Console.Log("Базу данных " + newDBName + " создана!");
				MessageBox.Show("База данных создана!", "Сообщение");
				return true;
			}catch(Exception ex){
				connection.Close();
				Utilits.Console.Log("Не удалось создать базу данных " + newDBName, false, true);
				MessageBox.Show("Не удалось создать базу данных "+ ex.Message, "Ошибка");
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
			QuerySqlServer query;
			query = new QuerySqlServer(connectionString);
			
			sqlCommand = "CREATE TABLE Users (" +
				"[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " +
				"[name] VARCHAR(255) DEFAULT '' UNIQUE, " +
				"[pass] VARCHAR(255) DEFAULT '', " +
				"[permissions] VARCHAR(255) DEFAULT '', " +
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
			QuerySqlServer query;
			query = new QuerySqlServer(connectionString);
			
			sqlCommand = "CREATE TABLE Constants (" +
				"[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " +
				"[name] VARCHAR(255) DEFAULT '', " +
				
				"[email] VARCHAR(255) DEFAULT '', " +
				"[emailPwd] VARCHAR(255) DEFAULT '', " +
				"[smtpServer] VARCHAR(255) DEFAULT '', " +
				"[port] VARCHAR(255) DEFAULT '', " +
				"[EnableSsl] INT DEFAULT 0, " +
				"[caption] VARCHAR(255) DEFAULT '', " +
				"[message] TEXT DEFAULT '', " +
				
				"[address] VARCHAR(255) DEFAULT '', " +
				"[vat] FLOAT DEFAULT 0, " +
				"[units] VARCHAR(255) DEFAULT '' " +
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
			QuerySqlServer query;
			query = new QuerySqlServer(connectionString);
			
			sqlCommand = "CREATE TABLE Counteragents (" +
				"[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " +
				"[type] VARCHAR(255) DEFAULT '', " +
				"[name] VARCHAR(255) DEFAULT '' UNIQUE, " +
				"[organization_address] VARCHAR(255) DEFAULT '', " +
				"[organization_phone] VARCHAR(255) DEFAULT '', " +
				"[organization_site] VARCHAR(255) DEFAULT '', " +
				"[organization_email] VARCHAR(255) DEFAULT '', " +
				"[contact_fullname] VARCHAR(255) DEFAULT '', " +
				"[contact_post] VARCHAR(255) DEFAULT '', " +
				"[contact_phone] VARCHAR(255) DEFAULT '', " +
				"[contact_skype] VARCHAR(255) DEFAULT '', " +
				"[contact_email] VARCHAR(255) DEFAULT '', " +
				"[information] TEXT DEFAULT '', " +
				"[excel_filename] TEXT DEFAULT '', " +
				"[excel_date] VARCHAR(255) DEFAULT '', " +
				"[excel_column_name] INT DEFAULT 0, " +
				"[excel_column_code] INT DEFAULT 0, " +
				"[excel_column_series] INT DEFAULT 0, " +
				"[excel_column_article] INT DEFAULT 0, " +
				"[excel_column_remainder] INT DEFAULT 0, " +
				"[excel_column_manufacturer] INT DEFAULT 0, " +
				"[excel_column_price] INT DEFAULT 0, " +
				"[excel_column_discount_1] INT DEFAULT 0, " +
				"[excel_column_discount_2] INT DEFAULT 0, " +
				"[excel_column_discount_3] INT DEFAULT 0, " +
				"[excel_column_discount_4] INT DEFAULT 0, " +
				"[excel_column_term] INT DEFAULT 0, " +
				"[excel_table_id] VARCHAR(255) DEFAULT '', " +
				"[parent] VARCHAR(255) DEFAULT ''" +
				")";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы Контрагенты.", false, true);
		}
		
		void tableNomenclature()
		{
			String sqlCommand;
			QuerySqlServer query;
			query = new QuerySqlServer(connectionString);
			
			sqlCommand = "CREATE TABLE Nomenclature (" +
				"[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " +
				"[type] VARCHAR(255) DEFAULT '', " +
				"[name] VARCHAR(255) DEFAULT '', " +
				"[code] VARCHAR(255) DEFAULT '', " +
				"[series] VARCHAR(255) DEFAULT '', " +
				"[article] VARCHAR(255) DEFAULT '', " +
				"[manufacturer] VARCHAR(255) DEFAULT '', " +
				"[price] FLOAT DEFAULT 0, " +
				"[units] VARCHAR(255) DEFAULT '', " +
				"[parent] VARCHAR(255) DEFAULT ''" +
				")";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы Номенклатура.", false, true);
		}
		
		void tableUnits()
		{
			String sqlCommand;
			QuerySqlServer query;
			query = new QuerySqlServer(connectionString);
			
			sqlCommand = "CREATE TABLE Units (" +
				"[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " +
				"[name] VARCHAR(255) DEFAULT '' UNIQUE, " +
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
			QuerySqlServer query;
			query = new QuerySqlServer(connectionString);
			
			sqlCommand = "CREATE TABLE PurchasePlan (" +
				"[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " +
				"[docDate] DATETIME, " +
				"[docNumber] VARCHAR(255) DEFAULT '' UNIQUE, " +
				"[docName] VARCHAR(255) DEFAULT '', " +
				"[docAutor] VARCHAR(255) DEFAULT '', " +
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
			QuerySqlServer query;
			query = new QuerySqlServer(connectionString);
			
			sqlCommand = "CREATE TABLE PurchasePlanPriceLists (" +
				"[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " +
				"[counteragentName] VARCHAR(255) DEFAULT '', " +
				"[counteragentPricelist] VARCHAR(255) DEFAULT '', " +
				"[docID] VARCHAR(255) DEFAULT '' " +
				")";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы План закупок.", false, true);
		}
		
		void tableOrderNomenclature()
		{
			String sqlCommand;
			QuerySqlServer query;
			query = new QuerySqlServer(connectionString);
			
			sqlCommand = "CREATE TABLE OrderNomenclature (" +
				"[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " +
				"[nomenclatureID] INT DEFAULT 0, " +
				"[nomenclatureName] VARCHAR(255) DEFAULT '', " +
				"[units] VARCHAR(255) DEFAULT '', " +
				"[amount] FLOAT DEFAULT 0, " +
				"[name] VARCHAR(255) DEFAULT '', " +
				"[price] FLOAT DEFAULT 0, " +
				"[manufacturer] VARCHAR(255) DEFAULT '', " +
				"[remainder] FLOAT DEFAULT 0, " +
				"[term] DATETIME, " +
				"[discount1] FLOAT DEFAULT 0, " +
				"[discount2] FLOAT DEFAULT 0, " +
				"[discount3] FLOAT DEFAULT 0, " +
				"[discount4] FLOAT DEFAULT 0, " +
				"[code] VARCHAR(255) DEFAULT '', " +
				"[series] VARCHAR(255) DEFAULT '', " +
				"[article] VARCHAR(255) DEFAULT '', " +
				"[counteragentName] VARCHAR(255) DEFAULT '', " +
				"[counteragentPricelist] VARCHAR(255) DEFAULT '', " +
				"[docPurchasePlan] VARCHAR(255) DEFAULT '', " +
				"[docOrder] VARCHAR(255) DEFAULT '' " +
				")";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы Заказ номенклатуры.", false, true);
		}
		
		void tableOrders() // Документ: Заказ
		{
			String sqlCommand;
			QuerySqlServer query;
			query = new QuerySqlServer(connectionString);
			
			sqlCommand = "CREATE TABLE Orders (" +
				"[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " +
				"[docDate] DATETIME, " +
				"[docNumber] VARCHAR(255) DEFAULT '' UNIQUE, " +
				"[docName] VARCHAR(255) DEFAULT '', " +
				"[docCounteragent] VARCHAR(255) DEFAULT '', " +
				"[docAutor] VARCHAR(255) DEFAULT '', " +
				"[docSum] FLOAT DEFAULT 0, " +
				"[docVat] FLOAT DEFAULT 0, " +
				"[docTotal] FLOAT DEFAULT 0, " +
				"[docPurchasePlan] VARCHAR(255) DEFAULT ''" +
				")";
			query.SetCommand(sqlCommand);
			if(!query.Execute()) Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы Заказы.", false, true);
		}
		
		void tableHistory()
		{
			String sqlCommand;
			QuerySqlServer query;
			query = new QuerySqlServer(connectionString);
			
			sqlCommand = "CREATE TABLE History (" +
				"[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " +
				"[name] VARCHAR(255) DEFAULT '' UNIQUE, " +
				"[represent] VARCHAR(255) DEFAULT '', " +
				"[datetime] VARCHAR(255) DEFAULT '', " +
				"[error] VARCHAR(255) DEFAULT '', " +
				"[user] VARCHAR(255) DEFAULT ''" +
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
