/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 15.03.2017
 * Время: 10:40
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
using Aggregator.Utilits;

namespace Aggregator.Client.Directories
{
	/// <summary>
	/// Description of FormNomenclature.
	/// </summary>
	public partial class FormNomenclature : Form
	{
		public FormNomenclature()
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
		public ListView ListViewReturnValue;
		public String TypeReturnValue;		// тип возвращаемого значения: file, folder
		
		OleDb oleDb;
		SqlServer sqlServer;
		DataTable foldersTable;			// папки
		DataTable filesTable; 			// файлы
		String openFolder = ""; 		// открытая папка
		bool folderExplore = true; 		// флаг отображения элементов в папках
		int selectTableLine = 0;		// выбранная строка в таблице
		
		
		public void TableRefresh(String actionFolder = null)
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL) {
				// OLEDB
				try{
					if(actionFolder == null) TableRefreshLocal(openFolder);
					else TableRefreshLocal(actionFolder);
				}catch(Exception ex){
					oleDb.Error();
					Utilits.Console.Log("[ОШИБКА]: " + ex.Message.ToString(), false, true);
				}
			} else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				try{
					if(actionFolder == null) TableRefreshServer(openFolder);
					else TableRefreshServer(actionFolder);
				}catch(Exception ex){
					sqlServer.Error();
					Utilits.Console.Log("[ОШИБКА]: " + ex.Message.ToString(), false, true);
				}
			}
		}
		
		void TableRefreshLocal(String actionFolder)
		{
			listView1.Items.Clear();
			// Папки
			oleDb = new OleDb(DataConfig.localDatabase);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Nomenclature";
			if(actionFolder == "") {
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Nomenclature WHERE (type = 'folder') ORDER BY name ASC";
			}else{
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Nomenclature WHERE (type = 'folder' AND name = '" + actionFolder + "') ORDER BY name ASC";
			}
			if(oleDb.ExecuteFill("Nomenclature")){
				foldersTable = oleDb.dataSet.Tables["Nomenclature"].Copy();
			}else{
				Utilits.Console.Log("[ОШИБКА] Ошибка выполнения запроса к таблице Номенклатура при отборе папок.");
				oleDb.Error();
				return;
			}
			// Файлы			
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Nomenclature";
			if(actionFolder == "" && folderExplore == true) {
				oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Nomenclature WHERE (type = 'file' AND parent = '') ORDER BY name ASC";
			}else{
				if(folderExplore == false) oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Nomenclature WHERE (type = 'file') ORDER BY name ASC";
				else oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Nomenclature WHERE (type = 'file' AND parent = '" + actionFolder + "') ORDER BY name ASC";
			}
			if(oleDb.ExecuteFill("Nomenclature")){
				filesTable = oleDb.dataSet.Tables["Nomenclature"].Copy();
			}else{
				Utilits.Console.Log("[ОШИБКА] Ошибка выполнения запроса к таблице Номенклатура при отборе файлов.");
				oleDb.Error();
				return;
			}
			// ОТОБРАЖЕНИЕ: "Папок"
			ListViewItem ListViewItem_add;
			foreach(DataRow rowFolder in foldersTable.Rows)
    		{
				ListViewItem_add = new ListViewItem();
				if(actionFolder == "") ListViewItem_add.SubItems.Add(rowFolder["name"].ToString());
				else ListViewItem_add.SubItems.Add("..");
				ListViewItem_add.StateImageIndex = 0;
				ListViewItem_add.SubItems.Add("Папка");
				ListViewItem_add.SubItems.Add(rowFolder["id"].ToString());
				ListViewItem_add.SubItems.Add(rowFolder["units"].ToString());
				ListViewItem_add.SubItems.Add(rowFolder["price"].ToString());
				listView1.Items.Add(ListViewItem_add);
			}
			// ОТОБРАЖЕНИЕ "Файлов"
			foreach(DataRow rowElement in filesTable.Rows)
    		{
				ListViewItem_add = new ListViewItem();
				ListViewItem_add.SubItems.Add(rowElement["name"].ToString());
				ListViewItem_add.StateImageIndex = 1;
				ListViewItem_add.SubItems.Add("");
				ListViewItem_add.SubItems.Add(rowElement["id"].ToString());
				ListViewItem_add.SubItems.Add(rowElement["units"].ToString());
				ListViewItem_add.SubItems.Add(rowElement["price"].ToString());
				listView1.Items.Add(ListViewItem_add);
			}
			// ВЫБОР: выдиляем ранее выбранный элемент.
			listView1.SelectedIndices.IndexOf(selectTableLine);
		}
		
		void TableRefreshServer(String actionFolder)
		{
			listView1.Items.Clear();
			// Папки
			sqlServer = new SqlServer();
			sqlServer.dataSet.Clear();
			sqlServer.dataSet.DataSetName = "Nomenclature";
			if(actionFolder == "") {
				sqlServer.sqlCommandSelect.CommandText = "SELECT * FROM Nomenclature WHERE (type = 'folder') ORDER BY name ASC";
			}else{
				sqlServer.sqlCommandSelect.CommandText = "SELECT * FROM Nomenclature WHERE (type = 'folder' AND name = '" + actionFolder + "') ORDER BY name ASC";
			}
			if(sqlServer.ExecuteFill("Nomenclature")){
				foldersTable = sqlServer.dataSet.Tables["Nomenclature"].Copy();
			}else{
				Utilits.Console.Log("[ОШИБКА] Ошибка выполнения запроса к таблице Номенклатура при отборе папок.");
				sqlServer.Error();
				return;
			}
			// Файлы			
			sqlServer.dataSet.Clear();
			sqlServer.dataSet.DataSetName = "Nomenclature";
			if(actionFolder == "" && folderExplore == true) {
				sqlServer.sqlCommandSelect.CommandText = "SELECT * FROM Nomenclature WHERE (type = 'file' AND parent = '') ORDER BY name ASC";
			}else{
				if(folderExplore == false) sqlServer.sqlCommandSelect.CommandText = "SELECT * FROM Nomenclature WHERE (type = 'file') ORDER BY name ASC";
				else sqlServer.sqlCommandSelect.CommandText = "SELECT * FROM Nomenclature WHERE (type = 'file' AND parent = '" + actionFolder + "') ORDER BY name ASC";
			}
			if(sqlServer.ExecuteFill("Nomenclature")){
				filesTable = sqlServer.dataSet.Tables["Nomenclature"].Copy();
			}else{
				Utilits.Console.Log("[ОШИБКА] Ошибка выполнения запроса к таблице Номенклатура при отборе файлов.");
				sqlServer.Error();
				return;
			}
			// ОТОБРАЖЕНИЕ: "Папок"
			ListViewItem ListViewItem_add;
			foreach(DataRow rowFolder in foldersTable.Rows)
    		{
				ListViewItem_add = new ListViewItem();
				if(actionFolder == "") ListViewItem_add.SubItems.Add(rowFolder["name"].ToString());
				else ListViewItem_add.SubItems.Add("..");
				ListViewItem_add.StateImageIndex = 0;
				ListViewItem_add.SubItems.Add("Папка");
				ListViewItem_add.SubItems.Add(rowFolder["id"].ToString());
				ListViewItem_add.SubItems.Add(rowFolder["units"].ToString());
				ListViewItem_add.SubItems.Add(rowFolder["price"].ToString());
				listView1.Items.Add(ListViewItem_add);
			}
			// ОТОБРАЖЕНИЕ "Файлов"
			foreach(DataRow rowElement in filesTable.Rows)
    		{
				ListViewItem_add = new ListViewItem();
				ListViewItem_add.SubItems.Add(rowElement["name"].ToString());
				ListViewItem_add.StateImageIndex = 1;
				ListViewItem_add.SubItems.Add("");
				ListViewItem_add.SubItems.Add(rowElement["id"].ToString());
				ListViewItem_add.SubItems.Add(rowElement["units"].ToString());
				ListViewItem_add.SubItems.Add(rowElement["price"].ToString());
				listView1.Items.Add(ListViewItem_add);
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
			DataTable table;
			oleDb = new OleDb(DataConfig.localDatabase);
			oleDb.dataSet.Clear();
			oleDb.dataSet.DataSetName = "Nomenclature";
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Nomenclature WHERE (name LIKE '%" + toolStripComboBox1.Text + "%') ORDER BY name ASC";
			if(oleDb.ExecuteFill("Nomenclature")){
				table = oleDb.dataSet.Tables["Nomenclature"];
			}else{
				Utilits.Console.Log("[ОШИБКА] Ошибка поиска.");
				oleDb.Error();
				return;
			}
			listView1.Items.Clear();
			ListViewItem ListViewItem_add;
			foreach(DataRow row in table.Rows)
        	{
				ListViewItem_add = new ListViewItem();
				ListViewItem_add.SubItems.Add(row["name"].ToString());
				if(row["type"].ToString() == "folder"){
					ListViewItem_add.StateImageIndex = 0;
					ListViewItem_add.SubItems.Add("Папка");
				}else{
					ListViewItem_add.StateImageIndex = 1;
					ListViewItem_add.SubItems.Add("");
				}
				ListViewItem_add.SubItems.Add(row["id"].ToString());
				ListViewItem_add.SubItems.Add(row["units"].ToString());
				listView1.Items.Add(ListViewItem_add);
			}
		}
		
		void searchServer()
		{
			DataTable table;
			sqlServer = new SqlServer();
			sqlServer.dataSet.Clear();
			sqlServer.dataSet.DataSetName = "Nomenclature";
			sqlServer.sqlCommandSelect.CommandText = "SELECT * FROM Nomenclature WHERE (name LIKE '%" + toolStripComboBox1.Text + "%') ORDER BY name ASC";
			if(sqlServer.ExecuteFill("Nomenclature")){
				table = sqlServer.dataSet.Tables["Nomenclature"];
			}else{
				Utilits.Console.Log("[ОШИБКА] Ошибка поиска.");
				sqlServer.Error();
				return;
			}
			listView1.Items.Clear();
			ListViewItem ListViewItem_add;
			foreach(DataRow row in table.Rows)
        	{
				ListViewItem_add = new ListViewItem();
				ListViewItem_add.SubItems.Add(row["name"].ToString());
				if(row["type"].ToString() == "folder"){
					ListViewItem_add.StateImageIndex = 0;
					ListViewItem_add.SubItems.Add("Папка");
				}else{
					ListViewItem_add.StateImageIndex = 1;
					ListViewItem_add.SubItems.Add("");
				}
				ListViewItem_add.SubItems.Add(row["id"].ToString());
				ListViewItem_add.SubItems.Add(row["units"].ToString());
				listView1.Items.Add(ListViewItem_add);
			}
		}
		
		void hierarchy() // иерархическое отображение
		{
			if(folderExplore){
				folderExplore = false;
				Utilits.Console.Log("Номенклатура: группирование отключено.");
				TableRefresh(""); // отображается всё содержимое
			}else{
				folderExplore = true;
				Utilits.Console.Log("Номенклатура: группирование включено.");
				TableRefresh(openFolder); //возвращаемся в последнюю активную папку.
			}
		}
		
		void showOpenCloseFolder() // показать открытую папку
		{
			if(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text.ToString() == "Папка" && folderExplore){
				if(listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString() != ".."){
					openFolder = listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString();
					TableRefresh(openFolder);
				}else {
					openFolder = "";
					TableRefresh(openFolder);
				}
			}	
		}
		
		void addFile()
		{
			FormNomenclatureFile FNomenclatureFile = new FormNomenclatureFile();
			FNomenclatureFile.MdiParent = DataForms.FClient;
			FNomenclatureFile.ID = null;
			FNomenclatureFile.ParentFolder = openFolder;
			FNomenclatureFile.Show();
		}
		
		void editFile()
		{
			if(listView1.SelectedIndices.Count > 0){
				if(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text.ToString() == "" 
				   && listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString() != ".." 
				   && listView1.SelectedItems[0].StateImageIndex == 1){
					FormNomenclatureFile FNomenclatureFile = new FormNomenclatureFile();
					FNomenclatureFile.MdiParent = DataForms.FClient;
					FNomenclatureFile.ID = listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text.ToString();
					FNomenclatureFile.ParentFolder = openFolder;
					FNomenclatureFile.Show();
				}
			}
		}
		
		void deleteFile()
		{
			if(listView1.SelectedIndices.Count > 0){
				if(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text.ToString() == "" 
				   && listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString() != ".." 
				   && listView1.SelectedItems[0].StateImageIndex == 1){
					
					String fileID = listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text.ToString();
					String fileName = listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString();
					
					if(MessageBox.Show("Удалить безвозвратно '" + fileName + "'?"  ,"Вопрос:", MessageBoxButtons.YesNo) == DialogResult.Yes){
						if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL) {
							// OLEDB
							QueryOleDb query = new QueryOleDb(DataConfig.localDatabase);
							query.SetCommand("DELETE FROM Nomenclature WHERE (id = " + fileID + ")");
							if(query.Execute()){
								DataForms.FClient.updateHistory("Nomenclature");
								Utilits.Console.Log("Номенклатура '" + fileName + "' успешно удалена.");
							}else{
								Utilits.Console.Log("[ОШИБКА] Номенклатура '" + fileName + "' не удалось удалить!");
							}
						} else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
							// MSSQL SERVER
							QuerySqlServer query = new QuerySqlServer(DataConfig.serverConnection);
							query.SetCommand("DELETE FROM Nomenclature WHERE (id = " + fileID + ")");
							if(query.Execute()){
								Utilits.Console.Log("Номенклатура '" + fileName + "' успешно удалена.");
								DataForms.FClient.updateHistory("Nomenclature");
							}else{
								Utilits.Console.Log("[ОШИБКА] Номенклатура '" + fileName + "' не удалось удалить!");
							}
						}
					}					
				}
			}
		}
		
		void addFolder()
		{
			FormNomenclatureFolder FNomenclatureFolder = new FormNomenclatureFolder();
			FNomenclatureFolder.MdiParent = DataForms.FClient;
			FNomenclatureFolder.ID = null;
			FNomenclatureFolder.Show();
		}
		
		void editFolder()
		{
			if(listView1.SelectedIndices.Count > 0){
				if(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text.ToString() == "Папка" 
				   && listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString() != ".." 
				   && listView1.SelectedItems[0].StateImageIndex == 0){
					FormNomenclatureFolder FNomenclatureFolder = new FormNomenclatureFolder();
					FNomenclatureFolder.MdiParent = DataForms.FClient;
					FNomenclatureFolder.ID = listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text.ToString();
					FNomenclatureFolder.Show();
				}
			}
		}
		
		void deleteFolder()
		{
			if(listView1.SelectedIndices.Count > 0){
				if(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text.ToString() == "Папка" 
				   && listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString() != ".." 
				   && listView1.SelectedItems[0].StateImageIndex == 0){
					String folderID = listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text.ToString();
					String folderName = listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text.ToString();
					
					if(MessageBox.Show("Удалить безвозвратно папку '" + folderName + "' и всё её содержимое ?"  ,"Вопрос:", MessageBoxButtons.YesNo) == DialogResult.Yes){
						
						if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL) {
							// OLEDB
							QueryOleDb query = new QueryOleDb(DataConfig.localDatabase);
							query = new QueryOleDb(DataConfig.localDatabase);
							query.SetCommand("DELETE FROM Nomenclature WHERE (parent ='" + folderName +"')");
							if(query.Execute()){
								query = new QueryOleDb(DataConfig.localDatabase);
								query.SetCommand("DELETE FROM Nomenclature WHERE (id = " + folderID +")");
								if(query.Execute()){
									DataForms.FClient.updateHistory("Nomenclature");
									query.Dispose();
									Utilits.Console.Log("Удаление папки '" + folderName + "' прошло успешно.");
								}else{
									query.Dispose();
									Utilits.Console.Log("Папку '" + folderName + "' не удалось удалить!", false, true);
								}
							}else{
								query.Dispose();
								Utilits.Console.Log("[ОШИБКА] Ошибка удаления файлов в папке '" + folderName + "'", false, true);
							}
							
						}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
							// MSSQL SERVER
							QuerySqlServer query = new QuerySqlServer(DataConfig.serverConnection);
							query = new QuerySqlServer(DataConfig.serverConnection);
							query.SetCommand("DELETE FROM Nomenclature WHERE (parent ='" + folderName +"')");
							if(query.Execute()){
								query = new QuerySqlServer(DataConfig.serverConnection);
								query.SetCommand("DELETE FROM Nomenclature WHERE (id = " + folderID +")");
								if(query.Execute()){
									DataForms.FClient.updateHistory("Nomenclature");
									query.Dispose();
									Utilits.Console.Log("Удаление папки '" + folderName + "' прошло успешно.");
								}else{
									query.Dispose();
									Utilits.Console.Log("Папку '" + folderName + "' не удалось удалить!", false, true);
								}
							}else{
								query.Dispose();
								Utilits.Console.Log("[ОШИБКА] Ошибка удаления файлов в папке '" + folderName + "'", false, true);
							}
						}
					}
				}
			}
		}
		
		void returnValue()
		{
			if(TypeReturnValue.Remove(6) == "folder" && openFolder != ""){
				int count = listView1.Items.Count;
				if(count <= 1){
					MessageBox.Show("Папка пустая.", "Сообщение");
					return;
				}
				if(TypeReturnValue == "folder&PurchasePlan"){
					ListViewItem ListViewItem_add;
					for(int i = 1; i < count; i++){
						ListViewItem_add = new ListViewItem();
						ListViewItem_add.SubItems.Add(listView1.Items[i].SubItems[3].Text);
						ListViewItem_add.StateImageIndex = 0;
						ListViewItem_add.SubItems.Add(listView1.Items[i].SubItems[1].Text);
						ListViewItem_add.SubItems.Add(listView1.Items[i].SubItems[4].Text);
						ListViewItem_add.SubItems.Add("0,00");
						ListViewItem_add.SubItems.Add("-->");
						ListViewItem_add.SubItems.Add("");
						ListViewItem_add.SubItems.Add("");
						ListViewItem_add.SubItems.Add("");
						ListViewItem_add.SubItems.Add("");
						ListViewItem_add.SubItems.Add("");
						ListViewItem_add.SubItems.Add("");
						ListViewItem_add.SubItems.Add("");
						ListViewItem_add.SubItems.Add("");
						ListViewItem_add.SubItems.Add("");
						ListViewItem_add.SubItems.Add("");
						ListViewItem_add.SubItems.Add("");
						ListViewItem_add.SubItems.Add("");
						ListViewItem_add.SubItems.Add("");
						ListViewItem_add.SubItems.Add("");
						ListViewItem_add.SubItems.Add("");
						ListViewReturnValue.Items.Add(ListViewItem_add);
					}
				}
				if(TypeReturnValue == "folder&CalcCostRealization"){
					ListViewItem ListViewItem_add;
					for(int i = 1; i < count; i++){
						ListViewItem_add = new ListViewItem();
						ListViewItem_add.SubItems.Add(listView1.Items[i].SubItems[1].Text);
						ListViewItem_add.StateImageIndex = 0;
						ListViewItem_add.SubItems.Add(listView1.Items[i].SubItems[4].Text);
						ListViewItem_add.SubItems.Add("0,00");
						ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(listView1.Items[i].SubItems[5].Text).ToString()));
						ListViewItem_add.SubItems.Add("0,00");
						ListViewReturnValue.Items.Add(ListViewItem_add);
					}
				}
				Close();
			}else if(TypeReturnValue.Remove(6) == "folder" && openFolder == ""){
				MessageBox.Show("Вы не открыли папку с номенклатурой.", "Сообщение");
				
			}else if(TypeReturnValue.Remove(6) != "folder"){
				if(listView1.SelectedIndices.Count > 0){
					if(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text != "Папка" && listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text != ".."){
						if(TypeReturnValue == "id") TextBoxReturnValue.Text = listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text;
						if(TypeReturnValue == "name") TextBoxReturnValue.Text = listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text;
						if(TypeReturnValue == "file&PurchasePlan"){
							ListViewItem ListViewItem_add = new ListViewItem();
							ListViewItem_add.SubItems.Add(listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text);
							ListViewItem_add.StateImageIndex = 0;
							ListViewItem_add.SubItems.Add(listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text);
							ListViewItem_add.SubItems.Add(listView1.Items[listView1.SelectedIndices[0]].SubItems[4].Text);
							ListViewItem_add.SubItems.Add("0,00");
							ListViewItem_add.SubItems.Add("-->");
							ListViewItem_add.SubItems.Add("");
							ListViewItem_add.SubItems.Add("");
							ListViewItem_add.SubItems.Add("");
							ListViewItem_add.SubItems.Add("");
							ListViewItem_add.SubItems.Add("");
							ListViewItem_add.SubItems.Add("");
							ListViewItem_add.SubItems.Add("");
							ListViewItem_add.SubItems.Add("");
							ListViewItem_add.SubItems.Add("");
							ListViewItem_add.SubItems.Add("");
							ListViewItem_add.SubItems.Add("");
							ListViewItem_add.SubItems.Add("");
							ListViewItem_add.SubItems.Add("");
							ListViewItem_add.SubItems.Add("");
							ListViewItem_add.SubItems.Add("");
							ListViewReturnValue.Items.Add(ListViewItem_add);
						}
						if(TypeReturnValue == "name&units&amount&price&sum"){
							ListViewItem ListViewItem_add = new ListViewItem();
							ListViewItem_add.SubItems.Add(listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text);
							ListViewItem_add.StateImageIndex = 0;
							ListViewItem_add.SubItems.Add(listView1.Items[listView1.SelectedIndices[0]].SubItems[4].Text);
							ListViewItem_add.SubItems.Add("0,00");
							ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(listView1.Items[listView1.SelectedIndices[0]].SubItems[5].Text).ToString()));
							ListViewItem_add.SubItems.Add("0,00");
							ListViewReturnValue.Items.Add(ListViewItem_add);
						}
						Close();
					}
				}
			}
		}
		
		void loadFileExcel()
		{
			FormNomenclatureLoadExcel FNomenclatureLoadExcel = new FormNomenclatureLoadExcel();
			FNomenclatureLoadExcel.MdiParent = DataForms.FClient;
			FNomenclatureLoadExcel.ParentFolder = openFolder;
			FNomenclatureLoadExcel.Show();
		}
		
		void loadPriceList()
		{
			FormNomenclatureLoadPrice FNomenclatureLoadPrice = new FormNomenclatureLoadPrice();
			FNomenclatureLoadPrice.MdiParent = DataForms.FClient;
			FNomenclatureLoadPrice.ParentFolder = openFolder;
			FNomenclatureLoadPrice.Show();
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
		void FormNomenclatureLoad(object sender, EventArgs e)
		{
			TableRefresh(""); // Загрузка данных из базы данных
			Utilits.Console.Log(this.Text + ": открыт");
		}
		void FormNomenclatureFormClosed(object sender, FormClosedEventArgs e)
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL && oleDb != null) oleDb.Dispose();
			if(DataConfig.typeConnection == DataConstants.CONNETION_SERVER && sqlServer != null) sqlServer.Dispose();
			DataForms.FClient.messageInStatus("...");
			Utilits.Console.Log(this.Text + ": закрыт");
			Dispose();
			DataForms.FNomenclature = null;
		}
		void FormNomenclatureActivated(object sender, EventArgs e)
		{
			DataForms.FClient.messageInStatus(this.Text);
		}
		void AddButtonClick(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			addFile();
		}
		void AddFolderButtonClick(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			addFolder();
		}
		void EditFolderButtonClick(object sender, EventArgs e)
		{
			editFolder();
		}
		void ButtonCloseClick(object sender, EventArgs e)
		{
			Close();
		}
		void ViewButtonClick(object sender, EventArgs e)
		{
			hierarchy();  // иерархическое отображение
		}
		void ListView1DoubleClick(object sender, EventArgs e)
		{
			showOpenCloseFolder(); // показать открытую папку
		}
		void ListView1SelectedIndexChanged(object sender, EventArgs e)
		{
			// выбранная строка таблицы
			if(listView1.SelectedItems.Count > 0) selectTableLine = listView1.SelectedItems[0].Index; // индекс выбраной строки
		}
		void FindButtonClick(object sender, EventArgs e)
		{
			openFolder = "";
			search(); // поиск
		}
		void ComboBox1KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyData == Keys.Enter){
				openFolder = "";
				search(); // поиск
			}
		}
		void Button1Click(object sender, EventArgs e)
		{
			returnValue(); // возвращает выбраные данные
		}
		void RefreshButtonClick(object sender, EventArgs e)
		{
			toolStripComboBox1.Text = "";
			TableRefresh(openFolder);
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
		void DeleteFolderButtonClick(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest" || DataConfig.userPermissions == "user"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			deleteFolder();
		}
		void СоздатьПапкуToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			addFolder();
		}
		void ИзменитьПапкуToolStripMenuItemClick(object sender, EventArgs e)
		{
			editFolder();
		}
		void УдалитьПапкуToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest" || DataConfig.userPermissions == "user"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			deleteFolder();
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
		void ИзПрайслистовКонтрагентовToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			loadPriceList();
		}
		void ИзТабличногоФайлаExcelToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			loadFileExcel();
		}
		void ВыбратьЗаписьToolStripMenuItemClick(object sender, EventArgs e)
		{
			returnValue();
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
		void ToolStripButton4Click(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			addFolder();
		}
		void ToolStripButton5Click(object sender, EventArgs e)
		{
			editFolder();
		}
		void ToolStripButton6Click(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest" || DataConfig.userPermissions == "user"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			deleteFolder();
		}
		void ToolStripButton7Click(object sender, EventArgs e)
		{
			hierarchy();  // иерархическое отображение
		}
		void ИзПрайслистаКонтрагентаToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			loadPriceList();
		}
		void ИзТабличногоФайлаExcelToolStripMenuItem1Click(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			loadFileExcel();
		}
		void ToolStripComboBox1KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyData == Keys.Enter){
				openFolder = "";
				search(); // поиск
			}
		}
		void ToolStripButton9Click(object sender, EventArgs e)
		{
			openFolder = "";
			search(); // поиск
		}
		void ToolStripButton10Click(object sender, EventArgs e)
		{
			toolStripComboBox1.Text = "";
			TableRefresh(openFolder);
		}
		
	}
}
