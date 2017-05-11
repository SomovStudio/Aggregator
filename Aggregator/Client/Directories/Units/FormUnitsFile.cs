/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 19.03.2017
 * Время: 9:00
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.Sql;
using System.Drawing;
using System.Windows.Forms;
using Aggregator.Data;
using Aggregator.Database.Local;
using Aggregator.Database.Server;

namespace Aggregator.Client.Directories
{
	/// <summary>
	/// Description of FormUnitsFile.
	/// </summary>
	public partial class FormUnitsFile : Form
	{
		public FormUnitsFile()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public String ID;
		OleDb oleDb;
		SqlServer sqlServer;
		
		void saveNew()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				// OLEDB
				oleDb.oleDbCommandSelect.CommandText = "SELECT id, name, info FROM Units WHERE (id = 0)";
				oleDb.ExecuteFill("Units");				
				
				DataRow newRow = oleDb.dataSet.Tables["Units"].NewRow();
				newRow["name"] = nameTextBox.Text;
				newRow["info"] = infoTextBox.Text;
				oleDb.dataSet.Tables["Units"].Rows.Add(newRow);
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO Units (name, info) VALUES (@name, @info)";
				oleDb.oleDbCommandInsert.Parameters.Add("@name", OleDbType.VarChar, 255, "name");
				oleDb.oleDbCommandInsert.Parameters.Add("@info", OleDbType.LongVarChar, 0, "info");
				if(oleDb.ExecuteUpdate("Units")){
					DataForms.FClient.updateHistory("Units");
					Utilits.Console.Log("Создана новая единица измерения.");
					Close();
				}
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				sqlServer.sqlCommandSelect.CommandText = "SELECT id, name, info FROM Units WHERE (id = 0)";
				sqlServer.ExecuteFill("Units");				
				
				DataRow newRow = sqlServer.dataSet.Tables["Units"].NewRow();
				newRow["name"] = nameTextBox.Text;
				newRow["info"] = infoTextBox.Text;
				sqlServer.dataSet.Tables["Units"].Rows.Add(newRow);
				
				sqlServer.sqlCommandInsert.CommandText = "INSERT INTO Units (name, info) VALUES (@name, @info)";
				sqlServer.sqlCommandInsert.Parameters.Add("@name", SqlDbType.VarChar, 255, "name");
				sqlServer.sqlCommandInsert.Parameters.Add("@info", SqlDbType.Text, 0, "info");
				if(sqlServer.ExecuteUpdate("Units")){
					DataForms.FClient.updateHistory("Units");
					Utilits.Console.Log("Создана новая единица измерения.");
					Close();
				}
			}
		}
		
		void saveEdit()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				// OLEDB
				oleDb.dataSet.Tables["Units"].Rows[0]["name"] = nameTextBox.Text;
				oleDb.dataSet.Tables["Units"].Rows[0]["info"] = infoTextBox.Text;
				oleDb.oleDbCommandUpdate.CommandText = "UPDATE Units SET " +
					"[name] = @name, [info] = @info " +
					"WHERE ([id] = @id)";
				oleDb.oleDbCommandUpdate.Parameters.Add("@name", OleDbType.VarChar, 255, "name");
				oleDb.oleDbCommandUpdate.Parameters.Add("@info", OleDbType.LongVarChar, 0, "info");
				oleDb.oleDbCommandUpdate.Parameters.Add("@id", OleDbType.Integer, 10, "id");
				if(oleDb.ExecuteUpdate("Units")){
					DataForms.FClient.updateHistory("Units");					
					Utilits.Console.Log("Изменения единицы измерения успешно сохранены.");
					Close();
				}				
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				sqlServer.dataSet.Tables["Units"].Rows[0]["name"] = nameTextBox.Text;
				sqlServer.dataSet.Tables["Units"].Rows[0]["info"] = infoTextBox.Text;
				sqlServer.sqlCommandUpdate.CommandText = "UPDATE Units SET " +
					"[name] = @name, [info] = @info " +
					"WHERE ([id] = @id)";
				sqlServer.sqlCommandUpdate.Parameters.Add("@name", SqlDbType.VarChar, 255, "name");
				sqlServer.sqlCommandUpdate.Parameters.Add("@info", SqlDbType.Text, 0, "info");
				sqlServer.sqlCommandUpdate.Parameters.Add("@id", SqlDbType.Int, 10, "id");
				if(sqlServer.ExecuteUpdate("Units")){
					DataForms.FClient.updateHistory("Units");					
					Utilits.Console.Log("Изменения единицы измерения успешно сохранены.");
					Close();
				}
			}
		}
		
		void open()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				// OLEDB
				oleDb.oleDbCommandSelect.CommandText = "SELECT id, name, info FROM Units WHERE (id = " + ID + ")";
				oleDb.ExecuteFill("Units");
				codeTextBox.Text = oleDb.dataSet.Tables["Units"].Rows[0]["id"].ToString();
				nameTextBox.Text = oleDb.dataSet.Tables["Units"].Rows[0]["name"].ToString();
				infoTextBox.Text = oleDb.dataSet.Tables["Units"].Rows[0]["info"].ToString();
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				sqlServer.sqlCommandSelect.CommandText = "SELECT id, name, info FROM Units WHERE (id = " + ID + ")";
				sqlServer.ExecuteFill("Units");
				codeTextBox.Text = sqlServer.dataSet.Tables["Units"].Rows[0]["id"].ToString();
				nameTextBox.Text = sqlServer.dataSet.Tables["Units"].Rows[0]["name"].ToString();
				infoTextBox.Text = sqlServer.dataSet.Tables["Units"].Rows[0]["info"].ToString();
			}
		}
		
		bool check()
		{
			if(nameTextBox.Text == "") return false;
			return true;
		}
		
		/* =================================================================================================
		 * РАЗДЕЛ: СОБЫТИЙ
		 * =================================================================================================
		 */	
		void FormUnitsFileLoad(object sender, EventArgs e)
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL) oleDb = new OleDb(DataConfig.localDatabase);
			if(DataConfig.typeConnection == DataConstants.CONNETION_SERVER) sqlServer = new SqlServer();
			if(ID == null){
				Text = "Единица измерения: Создать";
			}else{
				Text = "Единица измерения: Изменить";
				open();
			}
			Utilits.Console.Log(Text);
		}
		void FormUnitsFileFormClosed(object sender, FormClosedEventArgs e)
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL && oleDb != null) oleDb.Dispose();
			if(DataConfig.typeConnection == DataConstants.CONNETION_SERVER && sqlServer != null) sqlServer.Dispose();
			DataForms.FClient.messageInStatus("...");
			Utilits.Console.Log(Text + ": закрыт.");
			Dispose();
		}
		void ButtonCancelClick(object sender, EventArgs e)
		{
			Close();
		}
		void Button2Click(object sender, EventArgs e)
		{
			nameTextBox.Clear();
		}
		void ButtonSaveClick(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			if(check()){
				if(ID == null) saveNew();
				else saveEdit();
			}else{
				MessageBox.Show("Некорректно заполнены поля формы.", "Сообщение:");
			}
		}
		void FormUnitsFileActivated(object sender, EventArgs e)
		{
			DataForms.FClient.messageInStatus(this.Text);
		}
		
		
	}
}
