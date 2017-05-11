/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 06.05.2017
 * Время: 10:19
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using Aggregator.Data;
using Aggregator.Database.Config;
using Aggregator.Database.Server;

namespace Aggregator.Admin
{
	/// <summary>
	/// Description of FormDatabase.
	/// </summary>
	public partial class FormDatabase : Form
	{
		public FormDatabase()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
			
		void FormDatabaseLoad(object sender, EventArgs e)
		{
			ReadingConfig.ReadDatabaseSettings();
			
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				localRadioButton.Checked = true;
			}else if(DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				serverRadioButton.Checked = true;
			}
			
			localDatabaseTextBox.Text = DataConfig.localDatabase;
			serverTextBox.Text = DataConfig.serverConnection;
			Utilits.Console.Log(this.Text + ": открыт");
		}
		void FormDatabaseFormClosed(object sender, FormClosedEventArgs e)
		{
			DataForms.FClient.messageInStatus("...");
			Utilits.Console.Log(this.Text + ": закрыт");
			Dispose();
			DataForms.FDatabase = null;
		}
		void FormDatabaseActivated(object sender, EventArgs e)
		{
			DataForms.FClient.messageInStatus(this.Text);
		}
		void ButtonCloseClick(object sender, EventArgs e)
		{
			Close();
		}
		void ButtonSaveClick(object sender, EventArgs e)
		{
			if(DataConfig.typeConnection != DataConstants.CONNETION_LOCAL && DataConfig.typeConnection != DataConstants.CONNETION_SERVER){
				MessageBox.Show("Указан не верный тип подключения!", "Сообщение:");
				return;
			}
			if(localRadioButton.Checked){
				DataConfig.typeConnection = DataConstants.CONNETION_LOCAL;
				DataConfig.typeDatabase = DataConstants.TYPE_OLEDB;
			}else if(serverRadioButton.Checked){
				DataConfig.typeConnection = DataConstants.CONNETION_SERVER;
				DataConfig.typeDatabase = DataConstants.TYPE_MSSQL;
			}
			DataConfig.localDatabase = localDatabaseTextBox.Text;
			DataConfig.serverConnection = serverTextBox.Text;
			SavingConfig.SaveDatabaseSettings();
			Close();
			MessageBox.Show("Чтобы изменения вступили в силу, необходимо перезапустить программу.", "Сообщение:");
			DataConfig.programClose = true;
			Application.Exit();
		}
		void Button1Click(object sender, EventArgs e)
		{
			if(openFileDialog1.ShowDialog() == DialogResult.OK){
				localDatabaseTextBox.Text = openFileDialog1.FileName;
			}
		}
		void Button4Click(object sender, EventArgs e)
		{
			OleDbConnection conn = null;
			try{
				conn = new OleDbConnection(DataConfig.oledbConnectLineBegin + localDatabaseTextBox.Text);
				conn.Open();
				MessageBox.Show("Состояние соединения: " + conn.State.ToString(), "Результат проверки");
				conn.Close();
			}catch(Exception ex){
				conn.Close();
				MessageBox.Show("Ошибка: " + ex.Message, "Результат проверки");
			}
		}
		void Button2Click(object sender, EventArgs e)
		{
			FormCreateAccessDB FCreateAccessDB = new FormCreateAccessDB();
			FCreateAccessDB.MdiParent = DataForms.FClient;
			FCreateAccessDB.Show();
		}
		void TestConnectButtonClick(object sender, EventArgs e)
		{
			SqlConnection conn = null;
			try{
				conn = new SqlConnection(serverTextBox.Text);
				conn.Open();
				MessageBox.Show("Состояние соединения: " + conn.State.ToString(), "Результат проверки");
				conn.Close();
			}catch(Exception ex){
				conn.Close();
				MessageBox.Show("Ошибка: " + ex.Message, "Результат проверки");
			}
		}
		void Button3Click(object sender, EventArgs e)
		{
			FormCreateMSSQLDB FCreateMSSQLDB = new FormCreateMSSQLDB();
			FCreateMSSQLDB.MdiParent = DataForms.FClient;
			FCreateMSSQLDB.Show();
		}
		void RadioButtonsCheckedChanged(object sender, EventArgs e)
		{
			if(localRadioButton.Checked){
				groupBox1.Enabled = true;
				groupBox2.Enabled = false;
			}else if(serverRadioButton.Checked){
				groupBox1.Enabled = false;
				groupBox2.Enabled = true;
			}
		}
		void Button5Click(object sender, EventArgs e)
		{
			/* Создание таблиц */
			if(tableUsers() == false){
				MessageBox.Show("Ошибка при создании таблицы 'Пользователи'", "Ошибка");
				return;
			}
			if(tableConstants() == false){
				MessageBox.Show("Ошибка при создании таблицы 'Константы'", "Ошибка");
				return;
			}
			if(tableCounteragents() == false){
				MessageBox.Show("Ошибка при создании таблицы 'Контрагенты'", "Ошибка");
				return;
			}
			if(tableNomenclature() == false){
				MessageBox.Show("Ошибка при создании таблицы 'Номенклатура'", "Ошибка");
				return;
			}
			if(tableUnits() == false){
				MessageBox.Show("Ошибка при создании таблицы 'Единицы измерений'", "Ошибка");
				return;
			}
			if(tablePurchasePlan() == false){
				MessageBox.Show("Ошибка при создании таблицы 'План закупок'", "Ошибка");
				return;
			}
			if(tablePurchasePlanPriceLists() == false){
				MessageBox.Show("Ошибка при создании таблицы 'Прайс-листы' для плана закупок", "Ошибка");
				return;
			}
			if(tableOrderNomenclature() == false){
				MessageBox.Show("Ошибка при создании таблицы 'Заказанная номенклатура'", "Ошибка");
				return;
			}
			if(tableOrders() == false){
				MessageBox.Show("Ошибка при создании таблицы 'Заказы'", "Ошибка");
				return;
			}
			if(tableHistory() == false){
				MessageBox.Show("Ошибка при создании таблицы 'История'", "Ошибка");
				return;
			}
			MessageBox.Show("Все таблицы успешно созданы!", "Сообщение");
		}
		
		/* =========================================================================================
		 * Создание таблиц в базе данных 
		 * =========================================================================================
		 */
		bool tableUsers()
		{
			String sqlCommand;
			QuerySqlServer query;
			query = new QuerySqlServer(serverTextBox.Text);
			
			sqlCommand = "CREATE TABLE Users (" +
				"[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " +
				"[name] VARCHAR(255) DEFAULT '' UNIQUE, " +
				"[pass] VARCHAR(255) DEFAULT '', " +
				"[permissions] VARCHAR(255) DEFAULT '', " +
				"[info] TEXT" +
				")";
			query.SetCommand(sqlCommand);
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы Пользователи.", false, true);
				return false;
			}
			
			sqlCommand = "INSERT INTO Users (" +
				"[name], [pass], [permissions], [info]) " +
				"VALUES ('Администратор', '', 'admin', '')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Пользователи.", false, true);
				return false;
			}
			
			sqlCommand = "INSERT INTO Users (" +
				"[name], [pass], [permissions], [info]) " +
				"VALUES ('Оператор', '', 'operator', '')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Пользователи.", false, true);
				return false;
			}
			
			sqlCommand = "INSERT INTO Users (" +
				"[name], [pass], [permissions], [info]) " +
				"VALUES ('Пользователь', '', 'user', '')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Пользователи.", false, true);
				return false;
			}
			
			sqlCommand = "INSERT INTO Users (" +
				"[name], [pass], [permissions], [info]) " +
				"VALUES ('Гость', '', 'guest', '')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Пользователи.", false, true);
				return false;
			}
			
			query.Dispose();
			return true;
		}
		
		bool tableConstants()
		{
			String sqlCommand;
			QuerySqlServer query;
			query = new QuerySqlServer(serverTextBox.Text);
			
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
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы Константы.", false, true);
				return false;
			}
			
			sqlCommand = "INSERT INTO Constants (" +
				"[name], [email], [emailPwd], [smtpServer], [port], [EnableSsl], [caption], [message], [address], [vat], [units]) " +
				"VALUES ('Наша Фирма', 'mymail@gmail.com', '0000', 'smtp.gmail.com', '587', 1, 'Тема письма', 'Сообщение письма', 'Страна, Город, Улица, Дом', 20, 'шт.')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Константы.", false, true);
				return false;
			}
			
			query.Dispose();
			return true;
		}
		
		bool tableCounteragents()
		{
			String sqlCommand;
			QuerySqlServer query;
			query = new QuerySqlServer(serverTextBox.Text);
			
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
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы Контрагенты.", false, true);
				return false;
			}
			return true;
		}
		
		bool tableNomenclature()
		{
			String sqlCommand;
			QuerySqlServer query;
			query = new QuerySqlServer(serverTextBox.Text);
			
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
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы Номенклатура.", false, true);
				return false;
			}
			return true;
		}
		
		bool tableUnits()
		{
			String sqlCommand;
			QuerySqlServer query;
			query = new QuerySqlServer(serverTextBox.Text);
			
			sqlCommand = "CREATE TABLE Units (" +
				"[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " +
				"[name] VARCHAR(255) DEFAULT '' UNIQUE, " +
				"[info] TEXT" +
				")";
			query.SetCommand(sqlCommand);
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы Единицы измерения.", false, true);
				return false;
			}
			
			sqlCommand = "INSERT INTO Units (" +
				"[name], [info]) " +
				"VALUES ('г.', 'Граммы.')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Единицы измерения.", false, true);
				return false;
			}
			
			sqlCommand = "INSERT INTO Units (" +
				"[name], [info]) " +
				"VALUES ('кг.', 'Килограммы.')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Единицы измерения.", false, true);
				return false;
			}
			
			sqlCommand = "INSERT INTO Units (" +
				"[name], [info]) " +
				"VALUES ('л.', 'Литры.')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Единицы измерения.", false, true);
				return false;
			}
			
			sqlCommand = "INSERT INTO Units (" +
				"[name], [info]) " +
				"VALUES ('м.', 'Метры.')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Единицы измерения.", false, true);
				return false;
			}
			
			sqlCommand = "INSERT INTO Units (" +
				"[name], [info]) " +
				"VALUES ('см.', 'Сантиметры.')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Единицы измерения.", false, true);
				return false;
			}
			
			sqlCommand = "INSERT INTO Units (" +
				"[name], [info]) " +
				"VALUES ('шт.', 'Штуки.')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Единицы измерения.", false, true);
				return false;
			}
			
			sqlCommand = "INSERT INTO Units (" +
				"[name], [info]) " +
				"VALUES ('уп.', 'Упаковки.')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Единицы измерения.", false, true);
				return false;
			}
			
			sqlCommand = "INSERT INTO Units (" +
				"[name], [info]) " +
				"VALUES ('ящ.', 'Ящики.')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу Единицы измерения.", false, true);
				return false;
			}
			return true;
		}
		
		bool tablePurchasePlan() //	Документ: План закупок
		{
			String sqlCommand;
			QuerySqlServer query;
			query = new QuerySqlServer(serverTextBox.Text);
			
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
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы План закупок.", false, true);
				return false;
			}
			return true;
		}
		
		bool tablePurchasePlanPriceLists()
		{
			String sqlCommand;
			QuerySqlServer query;
			query = new QuerySqlServer(serverTextBox.Text);
			
			sqlCommand = "CREATE TABLE PurchasePlanPriceLists (" +
				"[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " +
				"[counteragentName] VARCHAR(255) DEFAULT '', " +
				"[counteragentPricelist] VARCHAR(255) DEFAULT '', " +
				"[docID] VARCHAR(255) DEFAULT '' " +
				")";
			query.SetCommand(sqlCommand);
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы План закупок.", false, true);
				return false;
			}
			return true;
		}
		
		bool tableOrderNomenclature()
		{
			String sqlCommand;
			QuerySqlServer query;
			query = new QuerySqlServer(serverTextBox.Text);
			
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
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы Заказ номенклатуры.", false, true);
				return false;
			}
			return true;
		}
		
		bool tableOrders() // Документ: Заказ
		{
			String sqlCommand;
			QuerySqlServer query;
			query = new QuerySqlServer(serverTextBox.Text);
			
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
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы Заказы.", false, true);
				return false;
			}
			return true;
		}
		
		bool tableHistory()
		{
			String sqlCommand;
			QuerySqlServer query;
			query = new QuerySqlServer(serverTextBox.Text);
			
			sqlCommand = "CREATE TABLE History (" +
				"[id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " +
				"[name] VARCHAR(255) DEFAULT '' UNIQUE, " +
				"[represent] VARCHAR(255) DEFAULT '', " +
				"[datetime] VARCHAR(255) DEFAULT '', " +
				"[error] VARCHAR(255) DEFAULT '', " +
				"[user] VARCHAR(255) DEFAULT ''" +
				")";
			query.SetCommand(sqlCommand);
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка создания таблицы История.", false, true);
				return false;
			}
			
			sqlCommand = "INSERT INTO History (" +
				"[name], [represent], [datetime], [error], [user]) " +
				"VALUES ('Users', 'Пользователи', '" + DateTime.Now.ToString() + "', '', '" + DataConfig.userName + "')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу История.", false, true);
				return false;
			}
			
			sqlCommand = "INSERT INTO History (" +
				"[name], [represent], [datetime], [error], [user]) " +
				"VALUES ('Counteragents', 'Контрагенты', '" + DateTime.Now.ToString() + "', '', '" + DataConfig.userName + "')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу История.", false, true);
				return false;
			}
			
			sqlCommand = "INSERT INTO History (" +
				"[name], [represent], [datetime], [error], [user]) " +
				"VALUES ('Nomenclature', 'Номенклатура', '" + DateTime.Now.ToString() + "', '', '" + DataConfig.userName + "')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу История.", false, true);
				return false;
			}
			
			sqlCommand = "INSERT INTO History (" +
				"[name], [represent], [datetime], [error], [user]) " +
				"VALUES ('Units', 'Единицы измерения', '" + DateTime.Now.ToString() + "', '', '" + DataConfig.userName + "')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу История.", false, true);
				return false;
			}
			
			sqlCommand = "INSERT INTO History (" +
				"[name], [represent], [datetime], [error], [user]) " +
				"VALUES ('PurchasePlan', 'План закупок', '" + DateTime.Now.ToString() + "', '', '" + DataConfig.userName + "')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу История.", false, true);
				return false;
			}
			
			sqlCommand = "INSERT INTO History (" +
				"[name], [represent], [datetime], [error], [user]) " +
				"VALUES ('Orders', 'Заказы', '" + DateTime.Now.ToString() + "', '', '" + DataConfig.userName + "')";
			query.SetCommand(sqlCommand);
			if(!query.Execute()){
				Utilits.Console.Log("[ОШИБКА] ошибка добавления данных в таблицу История.", false, true);
				return false;
			}
			return true;
		}
	}
}
