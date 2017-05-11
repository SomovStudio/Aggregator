/*
 * Created by SharpDevelop.
 * User: Somov Studio
 * Date: 02.03.2017
 * Time: 7:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;
using Aggregator.Data;
using Aggregator.Database.Local;
using Aggregator.Database.Server;

namespace Aggregator.User
{
	/// <summary>
	/// Description of FormUsersEdit.
	/// </summary>
	public partial class FormUsersEdit : Form
	{
		public FormUsersEdit()
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
		
		String getPermissions(String value)
		{
			if(value == "admin") return "администратор";
			if(value == "operator") return "оператор";
			if(value == "user") return "пользователь";
			if(value == "guest") return "гость";
			return "";
		}
		
		String setPermissions(String value)
		{
			if(value == "администратор") return "admin";
			if(value == "оператор") return "operator";
			if(value == "пользователь") return "user";
			if(value == "гость") return "guest";
			return "";
		}
		
		void saveNew()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL && DataConfig.typeDatabase == DataConstants.TYPE_OLEDB){
				// OLEDB
				oleDb.oleDbCommandSelect.CommandText = "SELECT id, name, pass, permissions, info FROM Users WHERE (id = 0)";
				oleDb.ExecuteFill("Users");				
				
				DataRow newRow = oleDb.dataSet.Tables["Users"].NewRow();
				newRow["name"] = nameTextBox.Text;
				newRow["pass"] = passTextBox1.Text;
				newRow["permissions"] = setPermissions(permissionsComboBox.Text);
				newRow["info"] = infoTextBox.Text;
				oleDb.dataSet.Tables["Users"].Rows.Add(newRow);
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO Users (name, pass, permissions, info) VALUES (@name, @pass, @permissions, @info)";
				oleDb.oleDbCommandInsert.Parameters.Add("@name", OleDbType.VarChar, 255, "name");
				oleDb.oleDbCommandInsert.Parameters.Add("@pass", OleDbType.VarChar, 255, "pass");
				oleDb.oleDbCommandInsert.Parameters.Add("@permissions", OleDbType.VarChar, 255, "permissions");
				oleDb.oleDbCommandInsert.Parameters.Add("@info", OleDbType.LongVarChar, 0, "info");
				if(oleDb.ExecuteUpdate("Users")){
					DataForms.FClient.updateHistory("Users");
					Utilits.Console.Log("Создан новый пользователь.");
					Close();
				}				
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER && DataConfig.typeDatabase == DataConstants.TYPE_MSSQL){
				// MSSQL SERVER
				sqlServer.sqlCommandSelect.CommandText = "SELECT id, name, pass, permissions, info FROM Users WHERE (id = 0)";
				sqlServer.ExecuteFill("Users");
				
				DataRow newRow = sqlServer.dataSet.Tables["Users"].NewRow();
				newRow["name"] = nameTextBox.Text;
				newRow["pass"] = passTextBox1.Text;
				newRow["permissions"] = setPermissions(permissionsComboBox.Text);
				newRow["info"] = infoTextBox.Text;
				sqlServer.dataSet.Tables["Users"].Rows.Add(newRow);
				
				sqlServer.sqlCommandInsert.CommandText = "INSERT INTO Users (name, pass, permissions, info) VALUES (@name, @pass, @permissions, @info)";
				sqlServer.sqlCommandInsert.Parameters.Add("@name", SqlDbType.VarChar, 255, "name");
				sqlServer.sqlCommandInsert.Parameters.Add("@pass", SqlDbType.VarChar, 255, "pass");
				sqlServer.sqlCommandInsert.Parameters.Add("@permissions", SqlDbType.VarChar, 255, "permissions");
				sqlServer.sqlCommandInsert.Parameters.Add("@info", SqlDbType.Text, 0, "info");
				if(sqlServer.ExecuteUpdate("Users")){
					DataForms.FClient.updateHistory("Users");
					Utilits.Console.Log("Создан новый пользователь.");
					Close();
				}
			}
		}
		
		void saveEdit()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL && DataConfig.typeDatabase == DataConstants.TYPE_OLEDB){
				// OLEDB
				oleDb.dataSet.Tables["Users"].Rows[0]["name"] = nameTextBox.Text;
				oleDb.dataSet.Tables["Users"].Rows[0]["pass"] = passTextBox1.Text;
				oleDb.dataSet.Tables["Users"].Rows[0]["permissions"] = setPermissions(permissionsComboBox.Text);
				oleDb.dataSet.Tables["Users"].Rows[0]["info"] = infoTextBox.Text;
				oleDb.oleDbCommandUpdate.CommandText = "UPDATE Users SET " +
					"[name] = @name, " +
					"[pass] = @pass, " +
					"[permissions] = @permissions, " +
					"[info] = @info " +
					"WHERE ([id] = @id)";
				oleDb.oleDbCommandUpdate.Parameters.Add("@name", OleDbType.VarChar, 255, "name");
				oleDb.oleDbCommandUpdate.Parameters.Add("@pass", OleDbType.VarChar, 255, "pass");
				oleDb.oleDbCommandUpdate.Parameters.Add("@permissions", OleDbType.VarChar, 255, "permissions");
				oleDb.oleDbCommandUpdate.Parameters.Add("@info", OleDbType.LongVarChar, 0, "info");
				oleDb.oleDbCommandUpdate.Parameters.Add("@id", OleDbType.Integer, 10, "id");
				if(oleDb.ExecuteUpdate("Users")){
					DataForms.FClient.updateHistory("Users");
					Utilits.Console.Log("Изменены данные пользователя ID:" + ID);
					Close();
				}				
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER && DataConfig.typeDatabase == DataConstants.TYPE_MSSQL){
				// MSSQL SERVER
				sqlServer.dataSet.Tables["Users"].Rows[0]["name"] = nameTextBox.Text;
				sqlServer.dataSet.Tables["Users"].Rows[0]["pass"] = passTextBox1.Text;
				sqlServer.dataSet.Tables["Users"].Rows[0]["permissions"] = setPermissions(permissionsComboBox.Text);
				sqlServer.dataSet.Tables["Users"].Rows[0]["info"] = infoTextBox.Text;
				sqlServer.sqlCommandUpdate.CommandText = "UPDATE Users SET " +
					"[name] = @name, " +
					"[pass] = @pass, " +
					"[permissions] = @permissions, " +
					"[info] = @info " +
					"WHERE ([id] = @id)";
				sqlServer.sqlCommandUpdate.Parameters.Add("@name", SqlDbType.VarChar, 255, "name");
				sqlServer.sqlCommandUpdate.Parameters.Add("@pass", SqlDbType.VarChar, 255, "pass");
				sqlServer.sqlCommandUpdate.Parameters.Add("@permissions", SqlDbType.VarChar, 255, "permissions");
				sqlServer.sqlCommandUpdate.Parameters.Add("@info", SqlDbType.Text, 0, "info");
				sqlServer.sqlCommandUpdate.Parameters.Add("@id", SqlDbType.Int, 10, "id");
				if(sqlServer.ExecuteUpdate("Users")){
					DataForms.FClient.updateHistory("Users");
					Utilits.Console.Log("Изменены данные пользователя ID:" + ID);
					Close();
				}
			}
		}
		
		void open()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL && DataConfig.typeDatabase == DataConstants.TYPE_OLEDB){
				// OLEDB
				oleDb.oleDbCommandSelect.CommandText = "SELECT id, name, pass, permissions, info FROM Users WHERE (id = " + ID + ")";
				oleDb.ExecuteFill("Users");
				nameTextBox.Text = oleDb.dataSet.Tables["Users"].Rows[0]["name"].ToString();
				passTextBox1.Text = oleDb.dataSet.Tables["Users"].Rows[0]["pass"].ToString();
				passTextBox2.Text = oleDb.dataSet.Tables["Users"].Rows[0]["pass"].ToString();
				permissionsComboBox.Text = getPermissions(oleDb.dataSet.Tables["Users"].Rows[0]["permissions"].ToString());
				infoTextBox.Text = oleDb.dataSet.Tables["Users"].Rows[0]["info"].ToString();
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER && DataConfig.typeDatabase == DataConstants.TYPE_MSSQL){
				// MSSQL SERVER
				sqlServer.sqlCommandSelect.CommandText = "SELECT id, name, pass, permissions, info FROM Users WHERE (id = " + ID + ")";
				sqlServer.ExecuteFill("Users");
				nameTextBox.Text = sqlServer.dataSet.Tables["Users"].Rows[0]["name"].ToString();
				passTextBox1.Text = sqlServer.dataSet.Tables["Users"].Rows[0]["pass"].ToString();
				passTextBox2.Text = sqlServer.dataSet.Tables["Users"].Rows[0]["pass"].ToString();
				permissionsComboBox.Text = getPermissions(sqlServer.dataSet.Tables["Users"].Rows[0]["permissions"].ToString());
				infoTextBox.Text = sqlServer.dataSet.Tables["Users"].Rows[0]["info"].ToString();
			}
		}
		
		bool check()
		{
			if(nameTextBox.Text == "") return false;
			if(permissionsComboBox.Text != "администратор" 
			   && permissionsComboBox.Text != "оператор" 
			   && permissionsComboBox.Text != "пользователь" 
			   && permissionsComboBox.Text != "гость"){
				return false;
			}
			return true;
		}
		
		/* =================================================================================================
		 * РАЗДЕЛ: СОБЫТИЙ
		 * =================================================================================================
		 */
		void FormUsersEditLoad(object sender, EventArgs e)
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL) oleDb = new OleDb(DataConfig.localDatabase);
			if(DataConfig.typeConnection == DataConstants.CONNETION_SERVER) sqlServer = new SqlServer();
			if(ID == null){
				Text = "Создать";
			}else{
				Text = "Изменить";
				open();
			}
			Utilits.Console.Log(Text);
		}
		void FormUsersEditFormClosed(object sender, FormClosedEventArgs e)
		{
			
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL && oleDb != null) oleDb.Dispose();
			if(DataConfig.typeConnection == DataConstants.CONNETION_SERVER && sqlServer != null) sqlServer.Dispose();
			Utilits.Console.Log(Text + ": закрыт.");
			DataForms.FClient.messageInStatus("...");
			Dispose();
		}
		void Button1Click(object sender, EventArgs e)
		{
			nameTextBox.Clear();
		}
		void Button2Click(object sender, EventArgs e)
		{
			passTextBox1.Clear();
		}
		void Button3Click(object sender, EventArgs e)
		{
			passTextBox2.Clear();
		}
		void Button5Click(object sender, EventArgs e)
		{
			Close();
		}
		void Button4Click(object sender, EventArgs e)
		{
			if(check()){
				if(ID == null) saveNew();
				else saveEdit();
			}else{
				MessageBox.Show("Некорректно заполнены поля формы.", "Сообщение:");
			}
		}
		void PermissionsComboBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			switch(permissionsComboBox.Text){
				case "администратор": 
					checkBox1.Checked = true;
					checkBox2.Checked = true;
					checkBox3.Checked = true;
					checkBox4.Checked = true;
					checkBox5.Checked = true;
					checkBox6.Checked = true;
					break;
				case "оператор": 
					checkBox1.Checked = false;
					checkBox2.Checked = true;
					checkBox3.Checked = true;
					checkBox4.Checked = true;
					checkBox5.Checked = true;
					checkBox6.Checked = true;
					break;
				case "пользователь": 
					checkBox1.Checked = false;
					checkBox2.Checked = true;
					checkBox3.Checked = true;
					checkBox4.Checked = true;
					checkBox5.Checked = false;
					checkBox6.Checked = false;
					break;
				case "гость": 
					checkBox1.Checked = false;
					checkBox2.Checked = false;
					checkBox3.Checked = true;
					checkBox4.Checked = false;
					checkBox5.Checked = false;
					checkBox6.Checked = false;
					break;
				default:
					checkBox1.Checked = false;
					checkBox2.Checked = false;
					checkBox3.Checked = false;
					checkBox4.Checked = false;
					checkBox5.Checked = false;
					checkBox6.Checked = false;
					break;
			}
			
		}
		void FormUsersEditActivated(object sender, EventArgs e)
		{
			DataForms.FClient.messageInStatus(this.Text);
		}
		
	}
}
