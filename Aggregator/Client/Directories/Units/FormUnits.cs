/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 18.03.2017
 * Время: 16:03
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Aggregator.Data;
using Aggregator.Database.Local;
using Aggregator.Database.Server;

namespace Aggregator.Client.Directories
{
	/// <summary>
	/// Description of FormUnits.
	/// </summary>
	public partial class FormUnits : Form
	{
		public FormUnits()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public TextBox TextBoxReturnValue;	// объект принимаемый значение
		
		OleDb oleDb;
		SqlServer sqlServer;
		int selectTableLine = 0;		// выбранная строка в таблице
		
		public void TableRefresh()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL) {
				// OLEDB
				try{
					TableRefreshLocal();
				}catch(Exception ex){
					oleDb.Error();
					Utilits.Console.Log("[ОШИБКА]: " + ex.Message.ToString(), false, true);
				}
			} else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				try{
					TableRefreshServer();
				}catch(Exception ex){
					sqlServer.Error();
					Utilits.Console.Log("[ОШИБКА]: " + ex.Message.ToString(), false, true);
				}
			}
		}
		
		void TableRefreshLocal()
		{
			oleDb = new OleDb(DataConfig.localDatabase);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Units";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Units ORDER BY name ASC";
			if(oleDb.ExecuteFill("Units")){
				listView1.Items.Clear();
				ListViewItem ListViewItem_add;
				foreach(DataRow rowElement in oleDb.dataSet.Tables[0].Rows)
	    		{
					ListViewItem_add = new ListViewItem();
					ListViewItem_add.SubItems.Add(rowElement["name"].ToString());
					ListViewItem_add.StateImageIndex = 1;
					ListViewItem_add.SubItems.Add("");
					ListViewItem_add.SubItems.Add(rowElement["id"].ToString());
					listView1.Items.Add(ListViewItem_add);
				}
			}else{
				Utilits.Console.Log("[ОШИБКА] Ошибка выполнения запроса к таблице Единицы измерения.");
				oleDb.Error();
				return;
			}
			// ВЫБОР: выдиляем ранее выбранный элемент.
			listView1.SelectedIndices.IndexOf(selectTableLine);
		}
		
		void TableRefreshServer()
		{
			sqlServer = new SqlServer();
			sqlServer.dataSet.Clear();
			sqlServer.dataSet.DataSetName = "Units";
			sqlServer.sqlCommandSelect.CommandText = "SELECT * FROM Units ORDER BY name ASC";
			if(sqlServer.ExecuteFill("Units")){
				listView1.Items.Clear();
				ListViewItem ListViewItem_add;
				foreach(DataRow rowElement in sqlServer.dataSet.Tables[0].Rows)
	    		{
					ListViewItem_add = new ListViewItem();
					ListViewItem_add.SubItems.Add(rowElement["name"].ToString());
					ListViewItem_add.StateImageIndex = 1;
					ListViewItem_add.SubItems.Add("");
					ListViewItem_add.SubItems.Add(rowElement["id"].ToString());
					listView1.Items.Add(ListViewItem_add);
				}
			}else{
				Utilits.Console.Log("[ОШИБКА] Ошибка выполнения запроса к таблице Единицы измерения.");
				sqlServer.Error();
				return;
			}
			// ВЫБОР: выдиляем ранее выбранный элемент.
			listView1.SelectedIndices.IndexOf(selectTableLine);
		}
		
		void search()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL && DataConfig.typeDatabase == DataConstants.TYPE_OLEDB) {
				// OLEDB
				try{
					searchLocal();
					Utilits.Console.Log(this.Text + ": поиск завершен.");
				}catch(Exception ex){
					oleDb.Error();
					Utilits.Console.Log("[ОШИБКА]: " + ex.Message.ToString(), false, true);
				}
			} else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER && DataConfig.typeDatabase == DataConstants.TYPE_MSSQL){
				// MSSQL SERVER
				try{
					searchServer();
					Utilits.Console.Log(this.Text + ": поиск завершен.");
				}catch(Exception ex){
					sqlServer.Error();
					Utilits.Console.Log("[ОШИБКА]: " + ex.Message.ToString(), false, true);
				}
			}
			if(toolStripComboBox1.Text != "") toolStripComboBox1.Items.Add(toolStripComboBox1.Text);
		}
		
		void searchLocal()
		{
			oleDb = new OleDb(DataConfig.localDatabase);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Units";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Units WHERE (name LIKE '%" + toolStripComboBox1.Text + "%') ORDER BY name ASC";
			if(oleDb.ExecuteFill("Units")){
				listView1.Items.Clear();
				ListViewItem ListViewItem_add;
				foreach(DataRow rowElement in oleDb.dataSet.Tables[0].Rows)
	    		{
					ListViewItem_add = new ListViewItem();
					ListViewItem_add.SubItems.Add(rowElement["name"].ToString());
					ListViewItem_add.StateImageIndex = 1;
					ListViewItem_add.SubItems.Add("");
					ListViewItem_add.SubItems.Add(rowElement["id"].ToString());
					listView1.Items.Add(ListViewItem_add);
				}
			}else{
				Utilits.Console.Log("[ОШИБКА] Ошибка выполнения запроса к таблице Единицы измерения.");
				oleDb.Error();
				return;
			}
		}
		
		void searchServer()
		{
			sqlServer = new SqlServer();
			sqlServer.dataSet.Clear();
			sqlServer.dataSet.DataSetName = "Units";
			sqlServer.sqlCommandSelect.CommandText = "SELECT * FROM Units WHERE (name LIKE '%" + toolStripComboBox1.Text + "%') ORDER BY name ASC";
			if(sqlServer.ExecuteFill("Units")){
				listView1.Items.Clear();
				ListViewItem ListViewItem_add;
				foreach(DataRow rowElement in sqlServer.dataSet.Tables[0].Rows)
	    		{
					ListViewItem_add = new ListViewItem();
					ListViewItem_add.SubItems.Add(rowElement["name"].ToString());
					ListViewItem_add.StateImageIndex = 1;
					ListViewItem_add.SubItems.Add("");
					ListViewItem_add.SubItems.Add(rowElement["id"].ToString());
					listView1.Items.Add(ListViewItem_add);
				}
			}else{
				Utilits.Console.Log("[ОШИБКА] Ошибка выполнения запроса к таблице Единицы измерения.");
				sqlServer.Error();
				return;
			}
		}
		
		void addFile()
		{
			FormUnitsFile FUnitsFile = new FormUnitsFile();
			FUnitsFile.MdiParent = DataForms.FClient;
			FUnitsFile.ID = null;
			FUnitsFile.Show();
		}
		
		void editFile()
		{
			if(listView1.SelectedIndices.Count > 0){
				FormUnitsFile FUnitsFile = new FormUnitsFile();
				FUnitsFile.MdiParent = DataForms.FClient;
				FUnitsFile.ID = listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text.ToString();
				FUnitsFile.Show();
			}
		}
		
		void deleteFile()
		{
			if(listView1.SelectedIndices.Count > 0){
				String fileID = listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text.ToString();
				String fileName = listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString();
				
				if(MessageBox.Show("Удалить безвозвратно '" + fileName + "'?"  ,"Вопрос:", MessageBoxButtons.YesNo) == DialogResult.Yes){
					if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL) {
						// OLEDB
						QueryOleDb query = new QueryOleDb(DataConfig.localDatabase);
						query.SetCommand("DELETE FROM Units WHERE (id = " + fileID + ")");
						if(query.Execute()){
							DataForms.FClient.updateHistory("Units");
							Utilits.Console.Log("Единица измерений '" + fileName + "' успешно удалена.");
						}else{
							Utilits.Console.Log("[ОШИБКА] Единица измерений '" + fileName + "' не удалось удалить!");
						}
					} else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
						// MSSQL SERVER
						QuerySqlServer query = new QuerySqlServer(DataConfig.serverConnection);
						query.SetCommand("DELETE FROM Units WHERE (id = " + fileID + ")");
						if(query.Execute()){
							Utilits.Console.Log("Единица измерений '" + fileName + "' успешно удалена.");
							DataForms.FClient.updateHistory("Units");
						}else{
							Utilits.Console.Log("[ОШИБКА] Единица измерений '" + fileName + "' не удалось удалить!");
						}
					}
				}					
			}
		}
		
		void returnValue()
		{
			if(listView1.SelectedIndices.Count > 0){
				if(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text.ToString() != "Папка" && listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString() != ".."){
					TextBoxReturnValue.Text = listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString();
					Close();
				}
			}
		}
		
		public void ShowMenuReturnValue()
		{
			toolStripMenuItem2.Visible = true;
			выбратьЗаписьToolStripMenuItem.Visible = true;
			button1.Visible = true;
		}
		
		/* =================================================================================================
		 * РАЗДЕЛ: СОБЫТИЙ
		 * =================================================================================================
		 */	
		void FormUnitsLoad(object sender, EventArgs e)
		{
			TableRefresh(); // Загрузка данных из базы данных
			Utilits.Console.Log(this.Text + ": открыт");
		}
		void FormUnitsFormClosed(object sender, FormClosedEventArgs e)
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL && oleDb != null) oleDb.Dispose();
			if(DataConfig.typeConnection == DataConstants.CONNETION_SERVER && sqlServer != null) sqlServer.Dispose();
			DataForms.FClient.messageInStatus("...");
			Utilits.Console.Log(this.Text + ": закрыт");
			Dispose();
			DataForms.FUnits = null;
		}
		void FormUnitsActivated(object sender, EventArgs e)
		{
			DataForms.FClient.messageInStatus(this.Text);
		}
		void ButtonCloseClick(object sender, EventArgs e)
		{
			Close();
		}
		void FindButtonClick(object sender, EventArgs e)
		{
			search(); // поиск
		}
		void AddButtonClick(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			addFile();
		}
		void EditButtonClick(object sender, EventArgs e)
		{
			editFile();
		}
		void DeleteButtonClick(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest" || DataConfig.userPermissions == "user"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			deleteFile();
		}
		void RefreshButtonClick(object sender, EventArgs e)
		{
			toolStripComboBox1.Text = "";
			TableRefresh();
		}
		void Button1Click(object sender, EventArgs e)
		{
			returnValue(); // возвращает выбраные данные
		}
		void СоздатьЗаписьToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			addFile();
		}
		void ИзменитьЗаписьToolStripMenuItemClick(object sender, EventArgs e)
		{
			editFile();
		}
		void УдалитьЗаписьToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest" || DataConfig.userPermissions == "user"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			deleteFile();
		}
		void ВыбратьЗаписьToolStripMenuItemClick(object sender, EventArgs e)
		{
			returnValue(); // возвращает выбраные данные
		}
		void ToolStripButton1Click(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			addFile();
		}
		void ToolStripButton2Click(object sender, EventArgs e)
		{
			editFile();
		}
		void ToolStripButton3Click(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest" || DataConfig.userPermissions == "user"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			deleteFile();
		}
		void ToolStripComboBox1KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyData == Keys.Enter){
				search(); // поиск
			}
		}
		void ToolStripButton9Click(object sender, EventArgs e)
		{
			search(); // поиск
		}
		void ToolStripButton10Click(object sender, EventArgs e)
		{
			toolStripComboBox1.Text = "";
			TableRefresh();
		}
		
	}
}
