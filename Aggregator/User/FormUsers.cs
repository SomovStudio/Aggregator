/*
 * Created by SharpDevelop.
 * User: Somov Studio
 * Date: 26.02.2017
 * Time: 16:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Sql;
using Aggregator.Data;
using Aggregator.Database.Local;
using Aggregator.Database.Server;

namespace Aggregator.User
{
	/// <summary>
	/// Description of FormUsers.
	/// </summary>
	public partial class FormUsers : Form
	{
		public FormUsers()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		OleDb oleDb;
		SqlServer sqlServer;
		
		public void TableRefresh()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				// OLEDB
				oleDb = new OleDb(DataConfig.localDatabase);
				oleDb.dataSet.Clear();
				oleDb.oleDbCommandSelect.CommandText = "SELECT id, name, pass, permissions FROM Users";
				oleDb.oleDbCommandDelete.CommandText = "DELETE FROM Users WHERE (id = @id)";
				oleDb.oleDbCommandDelete.Parameters.Add("@id", OleDbType.Integer, 10, "id");
				if(oleDb.ExecuteFill("Users")){
					listView1.Items.Clear();
					foreach(DataRow row in oleDb.dataSet.Tables["Users"].Rows)
		        	{
						ListViewItem listViewItem = new ListViewItem();
						listViewItem.SubItems.Add(row["name"].ToString());
						listViewItem.SubItems.Add(getPermissions(row["permissions"].ToString()));
						listViewItem.SubItems.Add(row["id"].ToString());
						listViewItem.StateImageIndex = 0;
						listView1.Items.Add(listViewItem);
					}
				}
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				sqlServer = new SqlServer();
				sqlServer.dataSet.Clear();
				sqlServer.sqlCommandSelect.CommandText = "SELECT id, name, pass, permissions FROM Users";
				sqlServer.sqlCommandDelete.CommandText = "DELETE FROM Users WHERE (id = @id)";
				sqlServer.sqlCommandDelete.Parameters.Add("@id", SqlDbType.Int, 10, "id");
				if(sqlServer.ExecuteFill("Users")){
					listView1.Items.Clear();
					foreach(DataRow row in sqlServer.dataSet.Tables["Users"].Rows)
		        	{
						ListViewItem listViewItem = new ListViewItem();
						listViewItem.SubItems.Add(row["name"].ToString());
						listViewItem.SubItems.Add(getPermissions(row["permissions"].ToString()));
						listViewItem.SubItems.Add(row["id"].ToString());
						listViewItem.StateImageIndex = 0;
						listView1.Items.Add(listViewItem);
					}
				}
			}
		}
		
		String getPermissions(String value)
		{
			if(value == "admin") return "администратор";
			if(value == "operator") return "оператор";
			if(value == "user") return "пользователь";
			if(value == "guest") return "гость";
			return "";
		}
		
		void addUser()
		{
			FormUsersEdit FUserEdit = new FormUsersEdit();
			FUserEdit.MdiParent = DataForms.FClient;
			FUserEdit.ID = null;
			FUserEdit.Show();
		}
		
		void editUser()
		{
			if(listView1.SelectedIndices.Count > 0){
				FormUsersEdit FUserEdit = new FormUsersEdit();
				FUserEdit.MdiParent = DataForms.FClient;
				FUserEdit.ID = listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text.ToString();
				FUserEdit.Show();
			}
		}
		
		void deleteUser()
		{
			if(listView1.SelectedIndices.Count > 0){
				if(listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString() == "Администратор") {
					MessageBox.Show("Администратора нельзя удалить из системы.");
					return;
				}
				if(MessageBox.Show("Удалить пользователя " + listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString() + " безвозвратно?" , "Вопрос", MessageBoxButtons.YesNo) == DialogResult.Yes){
					if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
						// OLEDB
						oleDb.dataSet.Tables["Users"].Rows[listView1.SelectedIndices[0]].Delete();
						if(oleDb.ExecuteUpdate("Users")){
							Utilits.Console.Log("Пользователь был успешно удалён.");
							DataForms.FClient.updateHistory("Users");
						}else{
							Utilits.Console.Log("[ОШИБКА] Произошла ошибка при удалении пользователя.");
						}
					}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
						// MSSQL SERVER
						sqlServer.dataSet.Tables["Users"].Rows[listView1.SelectedIndices[0]].Delete();
						if(sqlServer.ExecuteUpdate("Users")){
							Utilits.Console.Log("Пользователь был успешно удалён.");
							DataForms.FClient.updateHistory("Users");
						}else{
							Utilits.Console.Log("[ОШИБКА] Произошла ошибка при удалении пользователя.");
						}
					}
				}
			}
		}
		
				
		/* =================================================================================================
		 * РАЗДЕЛ: СОБЫТИЙ
		 * =================================================================================================
		 */	
		void FormUsersLoad(object sender, EventArgs e)
		{
			TableRefresh();
			Utilits.Console.Log(Text + ": открыт.");
		}
		void FormUsersFormClosed(object sender, FormClosedEventArgs e)
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL && oleDb != null) oleDb.Dispose();
			if(DataConfig.typeConnection == DataConstants.CONNETION_SERVER && sqlServer != null) sqlServer.Dispose();
			DataForms.FClient.messageInStatus("...");
			Utilits.Console.Log(Text + ": закрыт.");
			Dispose();
			DataForms.FUsers = null;
		}
		void ButtonCloseClick(object sender, EventArgs e)
		{
			Close();
		}
		void ButtonRefreshClick(object sender, EventArgs e)
		{
			TableRefresh();
		}
		void AddButtonClick(object sender, EventArgs e)
		{
			addUser();
		}
		void EditButtonClick(object sender, EventArgs e)
		{
			editUser();
		}
		void DeleteButtonClick(object sender, EventArgs e)
		{
			deleteUser();
		}
		void FormUsersActivated(object sender, EventArgs e)
		{
			DataForms.FClient.messageInStatus(this.Text);
		}
		void ToolStripButton1Click(object sender, EventArgs e)
		{
			addUser();
		}
		void ToolStripButton2Click(object sender, EventArgs e)
		{
			editUser();
		}
		void ToolStripButton3Click(object sender, EventArgs e)
		{
			deleteUser();
		}
		void ToolStripButton4Click(object sender, EventArgs e)
		{
			TableRefresh();
		}
		void ДобавитьПользователяToolStripMenuItemClick(object sender, EventArgs e)
		{
			addUser();
		}
		void ИзменитьПользователяToolStripMenuItemClick(object sender, EventArgs e)
		{
			editUser();
		}
		void УдалитьПользователяToolStripMenuItemClick(object sender, EventArgs e)
		{
			deleteUser();
		}
		
		
		
	}
}
