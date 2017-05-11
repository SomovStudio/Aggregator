/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 17.03.2017
 * Время: 9:53
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
	/// Description of FormNomenclatureFolder.
	/// </summary>
	public partial class FormNomenclatureFolder : Form
	{
		public FormNomenclatureFolder()
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
		String folderName;
		
		void saveNew()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				// OLEDB
				oleDb.oleDbCommandSelect.CommandText = "SELECT id, name, type FROM Nomenclature WHERE (id = 0)";
				oleDb.ExecuteFill("Nomenclature");				
				
				DataRow newRow = oleDb.dataSet.Tables["Nomenclature"].NewRow();
				newRow["name"] = nameTextBox.Text;
				newRow["type"] = DataConstants.FOLDER;
				oleDb.dataSet.Tables["Nomenclature"].Rows.Add(newRow);
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO Nomenclature (name, type) VALUES (@name, @type)";
				oleDb.oleDbCommandInsert.Parameters.Add("@name", OleDbType.VarChar, 255, "name");
				oleDb.oleDbCommandInsert.Parameters.Add("@type", OleDbType.VarChar, 255, "type");
				if(oleDb.ExecuteUpdate("Nomenclature")){
					DataForms.FClient.updateHistory("Nomenclature");
					Utilits.Console.Log("Создана новая папка.");
					Close();
				}
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				sqlServer.sqlCommandSelect.CommandText = "SELECT id, name, type FROM Nomenclature WHERE (id = 0)";
				sqlServer.ExecuteFill("Nomenclature");				
				
				DataRow newRow = sqlServer.dataSet.Tables["Nomenclature"].NewRow();
				newRow["name"] = nameTextBox.Text;
				newRow["type"] = "folder";
				sqlServer.dataSet.Tables["Nomenclature"].Rows.Add(newRow);
				
				sqlServer.sqlCommandInsert.CommandText = "INSERT INTO Nomenclature (name, type) VALUES (@name, @type)";
				sqlServer.sqlCommandInsert.Parameters.Add("@name", SqlDbType.VarChar, 255, "name");
				sqlServer.sqlCommandInsert.Parameters.Add("@type", SqlDbType.VarChar, 255, "type");
				if(sqlServer.ExecuteUpdate("Nomenclature")){
					DataForms.FClient.updateHistory("Nomenclature");
					Utilits.Console.Log("Создана новая папка.");
					Close();
				}
			}
		}
		
		void saveEdit()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				// OLEDB
				oleDb.dataSet.Tables["Nomenclature"].Rows[0]["name"] = nameTextBox.Text;
				oleDb.oleDbCommandUpdate.CommandText = "UPDATE Nomenclature SET " +
					"[name] = @name " +
					"WHERE ([id] = @id)";
				oleDb.oleDbCommandUpdate.Parameters.Add("@name", OleDbType.VarChar, 255, "name");
				oleDb.oleDbCommandUpdate.Parameters.Add("@id", OleDbType.Integer, 10, "id");
				if(oleDb.ExecuteUpdate("Nomenclature")){
					moveFilesInRenameFolder();
					DataForms.FClient.updateHistory("Nomenclature");					
					Utilits.Console.Log("Папка успешно переименована.");
					Close();
				}				
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				sqlServer.dataSet.Tables["Nomenclature"].Rows[0]["name"] = nameTextBox.Text;
				sqlServer.sqlCommandUpdate.CommandText = "UPDATE Nomenclature SET " +
					"[name] = @name " +
					"WHERE ([id] = @id)";
				sqlServer.sqlCommandUpdate.Parameters.Add("@name", SqlDbType.VarChar, 255, "name");
				sqlServer.sqlCommandUpdate.Parameters.Add("@id", SqlDbType.Int, 10, "id");
				if(sqlServer.ExecuteUpdate("Nomenclature")){
					moveFilesInRenameFolder();
					DataForms.FClient.updateHistory("Nomenclature");					
					Utilits.Console.Log("Папка успешно переименована.");
					Close();
				}
			}
		}
		
		void moveFilesInRenameFolder()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				// OLEDB
				QueryOleDb query = new QueryOleDb(DataConfig.localDatabase);
				query.SetCommand("UPDATE Nomenclature SET parent='" + nameTextBox.Text + "' WHERE(parent = '" + folderName + "')");
				query.Execute();
				query.Dispose();
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				QuerySqlServer query = new QuerySqlServer(DataConfig.serverConnection);
				query.SetCommand("UPDATE Nomenclature SET parent='" + nameTextBox.Text + "' WHERE(parent = '" + folderName + "')");
				query.Execute();
				query.Dispose();
			}
		}
		
		void open()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				// OLEDB
				oleDb.oleDbCommandSelect.CommandText = "SELECT id, name, type FROM Nomenclature WHERE (id = " + ID + ")";
				oleDb.ExecuteFill("Nomenclature");
				codeTextBox.Text = oleDb.dataSet.Tables["Nomenclature"].Rows[0]["id"].ToString();
				nameTextBox.Text = oleDb.dataSet.Tables["Nomenclature"].Rows[0]["name"].ToString();
				folderName = oleDb.dataSet.Tables["Nomenclature"].Rows[0]["name"].ToString();
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				sqlServer.sqlCommandSelect.CommandText = "SELECT id, name, type FROM Nomenclature WHERE (id = " + ID + ")";
				sqlServer.ExecuteFill("Nomenclature");
				codeTextBox.Text = sqlServer.dataSet.Tables["Nomenclature"].Rows[0]["id"].ToString();
				nameTextBox.Text = sqlServer.dataSet.Tables["Nomenclature"].Rows[0]["name"].ToString();
				folderName = sqlServer.dataSet.Tables["Nomenclature"].Rows[0]["name"].ToString();
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
		void FormNomenclatureFolderLoad(object sender, EventArgs e)
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL) oleDb = new OleDb(DataConfig.localDatabase);
			if(DataConfig.typeConnection == DataConstants.CONNETION_SERVER) sqlServer = new SqlServer();
			if(ID == null){
				Text = "Папка: Создать";
			}else{
				Text = "Папка: Изменить";
				open();
			}
			Utilits.Console.Log(Text);
		}
		void FormNomenclatureFolderFormClosed(object sender, FormClosedEventArgs e)
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL && oleDb != null) oleDb.Dispose();
			if(DataConfig.typeConnection == DataConstants.CONNETION_SERVER && sqlServer != null) sqlServer.Dispose();
			Utilits.Console.Log(this.Text + ": закрыт");
			DataForms.FClient.messageInStatus("...");
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
		void FormNomenclatureFolderActivated(object sender, EventArgs e)
		{
			DataForms.FClient.messageInStatus(this.Text);
		}
	}
}
