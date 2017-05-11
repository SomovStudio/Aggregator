/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 19.03.2017
 * Время: 10:27
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.Sql;
using System.Drawing;
using System.Windows.Forms;
using Aggregator.Client.Documents.Order;
using Aggregator.Data;
using Aggregator.Database.Local;
using Aggregator.Database.Server;
using Aggregator.Utilits;

namespace Aggregator.Client.Documents.PurchasePlan
{
	/// <summary>
	/// Description of FormPurchasePlanJournal.
	/// </summary>
	public partial class FormPurchasePlanJournal : Form
	{
		public FormPurchasePlanJournal()
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
		int selectTableLine = 0;		// выбранная строка в таблице
		
		void getPeriod()
		{
			if(DataConfig.period == DataConstants.TODAY){
				dateTimePicker1.Value = DateTime.Today.Date;
				dateTimePicker2.Value = DateTime.Today.Date;
			}else if(DataConfig.period == DataConstants.YESTERDAY){
				dateTimePicker1.Value = DateTime.Now.AddDays(-1);
				dateTimePicker2.Value = DateTime.Now.Date;
			}else if(DataConfig.period == DataConstants.WEEK){
				dateTimePicker1.Value = DateTime.Now.AddDays(-7);
				dateTimePicker2.Value = DateTime.Now.Date;
			}else if(DataConfig.period == DataConstants.MONTH){
				var yr = DateTime.Today.Year;
				var mth = DateTime.Today.Month;
				var firstDay = new DateTime(yr, mth, 1);
				var lastDay = new DateTime(yr, mth, 1).AddMonths(1).AddDays(-1);
				dateTimePicker1.Value = firstDay;
				dateTimePicker2.Value = lastDay;
			}else if(DataConfig.period == DataConstants.YEAR){
				var yr = DateTime.Today.Year;
				var firstDay = new DateTime(yr, 1, 1);
				var lastDay = new DateTime(yr+1, 1, 1).AddDays(-1);
				dateTimePicker1.Value = firstDay;
				dateTimePicker2.Value = lastDay;
			}
		}
		
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
			oleDb.dataSet.DataSetName = "PurchasePlan";
			
			// Дата в формате: BETWEEN #месяц/день/год# AND #месяц/день/год#
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM PurchasePlan WHERE (docDate BETWEEN #" + 
				dateTimePicker1.Value.ToString("MM.dd.yyyy").Replace(".", "/") + "# AND #" + 
				dateTimePicker2.Value.ToString("MM.dd.yyyy").Replace(".", "/") + "#) " +
				"AND (docNumber LIKE '%" + toolStripComboBox1.Text + 
				"%' OR docTotal LIKE '%" + toolStripComboBox1.Text + 
				"%' OR docAutor LIKE '%" + toolStripComboBox1.Text +
				"%') ORDER BY docDate DESC";
			
			if(oleDb.ExecuteFill("PurchasePlan")){
				listView1.Items.Clear();
				DateTime dt;
				ListViewItem ListViewItem_add;
				foreach(DataRow rowElement in oleDb.dataSet.Tables[0].Rows)
	    		{
					ListViewItem_add = new ListViewItem();
					dt = new DateTime();
					DateTime.TryParse(rowElement["docDate"].ToString(), out dt);
					ListViewItem_add.SubItems.Add(dt.ToString("dd.MM.yyyy"));
					ListViewItem_add.StateImageIndex = 0;
					ListViewItem_add.SubItems.Add(rowElement["docNumber"].ToString());
					ListViewItem_add.SubItems.Add(rowElement["docName"].ToString());
					ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(rowElement["docSum"].ToString()).ToString()));
					ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(rowElement["docVat"].ToString()).ToString()));
					ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(rowElement["docTotal"].ToString()).ToString()));
					ListViewItem_add.SubItems.Add(rowElement["docAutor"].ToString());
					ListViewItem_add.SubItems.Add(rowElement["id"].ToString());
					listView1.Items.Add(ListViewItem_add);
				}
			}else{
				Utilits.Console.Log("[ОШИБКА] Ошибка выполнения запроса к таблице План закупок.");
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
			sqlServer.dataSet.DataSetName = "PurchasePlan";
			sqlServer.sqlCommandSelect.CommandText = "SELECT * FROM PurchasePlan WHERE (docDate BETWEEN '" + 
				dateTimePicker1.Text + "' AND '" + dateTimePicker2.Text + 
				"' AND (docNumber LIKE '%" + toolStripComboBox1.Text + "%' OR docTotal LIKE '%" + toolStripComboBox1.Text + "%' OR docAutor LIKE '%" + toolStripComboBox1.Text + 
				"%')) ORDER BY docDate DESC";
			
			if(sqlServer.ExecuteFill("PurchasePlan")){
				listView1.Items.Clear();
				DateTime dt;
				ListViewItem ListViewItem_add;
				foreach(DataRow rowElement in sqlServer.dataSet.Tables[0].Rows)
	    		{
					ListViewItem_add = new ListViewItem();
					dt = new DateTime();
					DateTime.TryParse(rowElement["docDate"].ToString(), out dt);
					ListViewItem_add.SubItems.Add(dt.ToString("dd.MM.yyyy"));
					ListViewItem_add.StateImageIndex = 0;
					ListViewItem_add.SubItems.Add(rowElement["docNumber"].ToString());
					ListViewItem_add.SubItems.Add(rowElement["docName"].ToString());
					ListViewItem_add.SubItems.Add(rowElement["docSum"].ToString());
					ListViewItem_add.SubItems.Add(rowElement["docVat"].ToString());
					ListViewItem_add.SubItems.Add(rowElement["docTotal"].ToString());
					ListViewItem_add.SubItems.Add(rowElement["docAutor"].ToString());
					ListViewItem_add.SubItems.Add(rowElement["id"].ToString());
					listView1.Items.Add(ListViewItem_add);
				}
			}else{
				Utilits.Console.Log("[ОШИБКА] Ошибка выполнения запроса к таблице План закупок.");
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
					TableRefreshLocal();
					Utilits.Console.Log(this.Text + ": поиск завершен.");
				}catch(Exception ex){
					oleDb.Error();
					Utilits.Console.Log("[ОШИБКА]: " + ex.Message.ToString(), false, true);
				}
			} else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER && DataConfig.typeDatabase == DataConstants.TYPE_MSSQL){
				// MSSQL SERVER
				try{
					TableRefreshServer();
					Utilits.Console.Log(this.Text + ": поиск завершен.");
				}catch(Exception ex){
					sqlServer.Error();
					Utilits.Console.Log("[ОШИБКА]: " + ex.Message.ToString(), false, true);
				}
			}
			if(toolStripComboBox1.Text != "")  toolStripComboBox1.Items.Add(toolStripComboBox1.Text);
		}
		
		void addFile()
		{
			FormPurchasePlanDoc FPurchasePlanDoc = new FormPurchasePlanDoc();
			FPurchasePlanDoc.MdiParent = DataForms.FClient;
			FPurchasePlanDoc.ID = null;
			FPurchasePlanDoc.Show();
		}
		
		void editFile()
		{
			if(listView1.SelectedIndices.Count > 0){
				FormPurchasePlanDoc FPurchasePlanDoc = new FormPurchasePlanDoc();
				FPurchasePlanDoc.MdiParent = DataForms.FClient;
				FPurchasePlanDoc.ID = listView1.Items[listView1.SelectedIndices[0]].SubItems[8].Text;
				FPurchasePlanDoc.Show();
			}
		}
		
		void deleteFile()
		{
			if(listView1.SelectedIndices.Count > 0){
				String docID = listView1.Items[listView1.SelectedIndices[0]].SubItems[8].Text;
				String docName = listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text;
				
				if(MessageBox.Show("Удалить документ План закупок №" + docName + Environment.NewLine + " и связанные с ним Заказы ?"  ,"Вопрос:", MessageBoxButtons.YesNo) == DialogResult.Yes){
					if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL) {
						// OLEDB
						QueryOleDb query;
						
						query = new QueryOleDb(DataConfig.localDatabase);
						query.SetCommand("DELETE FROM Orders WHERE (docPurchasePlan = '" + docName + "')");
						if(!query.Execute()){
							Utilits.Console.Log("[ОШИБКА] Не удалось удалить заказы привязанные к Плану закупок №" + docName, false, true);
							return;
						}
						
						query = new QueryOleDb(DataConfig.localDatabase);
						query.SetCommand("DELETE FROM OrderNomenclature WHERE (docPurchasePlan = '" + docName + "')");
						if(!query.Execute()){
							Utilits.Console.Log("[ОШИБКА] Документ план закупок №" + docName + " не удалось удалить перечень номенклатуры!", false, true);
							return;
						}
						
						query = new QueryOleDb(DataConfig.localDatabase);
						query.SetCommand("DELETE FROM PurchasePlanPriceLists WHERE (docID = '" + docName + "')");
						if(!query.Execute()){
							Utilits.Console.Log("[ОШИБКА] Документ план закупок №" + docName + " не удалось удалить перечень прайс-листов!", false, true);
							return;
						}
						
						query = new QueryOleDb(DataConfig.localDatabase);
						query.SetCommand("DELETE FROM PurchasePlan WHERE (id = " + docID + ")");
						if(!query.Execute()){
							Utilits.Console.Log("[ОШИБКА] Документ план закупок №" + docName + " не получилось удалить!", false, true);
							return;
						}
						
						Utilits.Console.Log("Документ план закупок №" + docName + " успешно удален.");
						DataForms.FClient.updateHistory("Orders");
						DataForms.FClient.updateHistory("PurchasePlan");
						
											
					} else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
						// MSSQL SERVER
						QuerySqlServer query;
						
						query = new QuerySqlServer(DataConfig.serverConnection);
						query.SetCommand("DELETE FROM Orders WHERE (docPurchasePlan = '" + docName + "')");
						if(!query.Execute()){
							Utilits.Console.Log("[ОШИБКА] Не удалось удалить заказы привязанные к Плану закупок №" + docName, false, true);
							return;
						}
						
						query = new QuerySqlServer(DataConfig.serverConnection);
						query.SetCommand("DELETE FROM OrderNomenclature WHERE (docPurchasePlan = '" + docName + "')");
						if(!query.Execute()){
							Utilits.Console.Log("[ОШИБКА] Документ план закупок №" + docName + " не удалось удалить перечень номенклатуры!", false, true);
							return;
						}
						
						query = new QuerySqlServer(DataConfig.serverConnection);
						query.SetCommand("DELETE FROM PurchasePlanPriceLists WHERE (docID = '" + docName + "')");
						if(!query.Execute()){
							Utilits.Console.Log("[ОШИБКА] Документ план закупок №" + docName + " не удалось удалить перечень прайс-листов!", false, true);
							return;
						}
						
						query = new QuerySqlServer(DataConfig.serverConnection);
						query.SetCommand("DELETE FROM PurchasePlan WHERE (id = " + docID + ")");
						if(!query.Execute()){
							Utilits.Console.Log("[ОШИБКА] Документ план закупок №" + docName + " не получилось удалить!", false, true);
							return;
						}
						
						Utilits.Console.Log("Документ план закупок №" + docName + " успешно удален.");
						DataForms.FClient.updateHistory("Orders");
						DataForms.FClient.updateHistory("PurchasePlan");
						
					}
				}			
			}
		}
		
				
		/* =================================================================================================
		 * РАЗДЕЛ: СОБЫТИЙ
		 * =================================================================================================
		 */	
		void FormPurchasePlanJournalLoad(object sender, EventArgs e)
		{
			getPeriod();
			TableRefresh(); // Загрузка данных из базы данных
			Utilits.Console.Log(this.Text + ": открыт");
		}
		void FormPurchasePlanJournalFormClosed(object sender, FormClosedEventArgs e)
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL && oleDb != null) oleDb.Dispose();
			if(DataConfig.typeConnection == DataConstants.CONNETION_SERVER && sqlServer != null) sqlServer.Dispose();
			DataForms.FClient.messageInStatus("...");
			Utilits.Console.Log(this.Text + ": закрыт");
			Dispose();
			DataForms.FPurchasePlanJournal = null;
		}
		void FindButtonClick(object sender, EventArgs e)
		{
			search();
		}
		void RefreshButtonClick(object sender, EventArgs e)
		{
			toolStripComboBox1.Text = "";
			TableRefresh();
		}
		void DateButtonClick(object sender, EventArgs e)
		{
			TableRefresh();
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
		void СоздатьПланЗакупокToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			addFile();
		}
		void ИзменитьПланЗакупокToolStripMenuItemClick(object sender, EventArgs e)
		{
			editFile();
		}
		void УдалитьПланЗакупокToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest" || DataConfig.userPermissions == "user"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			deleteFile();
		}
		void ОбновитьToolStripMenuItemClick(object sender, EventArgs e)
		{
			toolStripComboBox1.Text = "";
			TableRefresh();
		}
		void ЗаказToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest" || DataConfig.userPermissions == "user"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			if(listView1.SelectedIndices.Count > 0){
				InputToOrder inputToOrder = new InputToOrder(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text);
				inputToOrder.Execute();
			}
		}
		void ButtonCloseClick(object sender, EventArgs e)
		{
			Close();
		}
		void ComboBox1KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyData == Keys.Enter){
				search(); // поиск
			}
		}
		void FormPurchasePlanJournalActivated(object sender, EventArgs e)
		{
			DataForms.FClient.messageInStatus(this.Text);
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
			search();
		}
		void ToolStripButton10Click(object sender, EventArgs e)
		{
			toolStripComboBox1.Text = "";
			TableRefresh();
		}
		
	}
}
