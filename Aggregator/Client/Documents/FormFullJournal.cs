/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 08.05.2017
 * Время: 5:53
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Aggregator.Client.Documents.Order;
using Aggregator.Client.Documents.PurchasePlan;
using Aggregator.Data;
using Aggregator.Database.Local;
using Aggregator.Database.Server;
using Aggregator.Utilits;

namespace Aggregator.Client.Documents
{
	/// <summary>
	/// Description of FormFullJournal.
	/// </summary>
	public partial class FormFullJournal : Form
	{
		public FormFullJournal()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		/*
		OleDbConnection oleDbConnection;
		OleDbCommand oleDbCommandSelect;
		OleDbDataAdapter oleDbDataAdapter;
		
		SqlConnection sqlConnection;
		SqlCommand sqlCommandSelect;
		SqlDataAdapter sqlDataAdapter;
		
		DataSet dataSet;
		*/
		
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
					disposeDb();
					Utilits.Console.Log("[ОШИБКА]: " + ex.Message, false, true);
				}
			} else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				try{
					TableRefreshServer();
				}catch(Exception ex){
					disposeDb();
					Utilits.Console.Log("[ОШИБКА]: " + ex.Message, false, true);
				}
			}
		}
		
		void TableRefreshLocal()
		{
			oleDb = new OleDb(DataConfig.localDatabase);
			oleDb.dataSet.Clear();
			
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM PurchasePlan WHERE (docDate BETWEEN #" + 
				dateTimePicker1.Value.ToString("MM.dd.yyyy").Replace(".", "/") + "# AND #" + 
				dateTimePicker2.Value.ToString("MM.dd.yyyy").Replace(".", "/") + "#) " +
				"AND (docNumber LIKE '%" + toolStripComboBox1.Text + 
				"%' OR docTotal LIKE '%" + toolStripComboBox1.Text + 
				"%' OR docAutor LIKE '%" + toolStripComboBox1.Text +
				"%') ORDER BY docDate DESC";
			oleDb.ExecuteFill("PurchasePlan");
			
			oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Orders WHERE (docDate BETWEEN #" + 
				dateTimePicker1.Value.ToString("MM.dd.yyyy").Replace(".", "/") + "# AND #" + 
				dateTimePicker2.Value.ToString("MM.dd.yyyy").Replace(".", "/") + "#) " +
				"AND (docNumber LIKE '%" + toolStripComboBox1.Text + 
				"%' OR docSum LIKE '%" + toolStripComboBox1.Text + 
				"%' OR docVat LIKE '%" + toolStripComboBox1.Text + 
				"%' OR docTotal LIKE '%" + toolStripComboBox1.Text + 
				"%' OR docAutor LIKE '%" + toolStripComboBox1.Text +
				"%' OR docCounteragent LIKE '%" + toolStripComboBox1.Text +
				"%') ORDER BY docDate DESC";
			oleDb.ExecuteFill("Orders");
			
			if(oleDb.dataSet.Tables.Count > 0){
				listView1.Items.Clear();
				DateTime dt;
				ListViewItem listViewItemAdd;
				
				DataSet dataSet = new DataSet();
				oleDb.dataSet.Tables[0].DefaultView.Sort = "docDate DESC";
				if(oleDb.dataSet.Tables.Count > 1) oleDb.dataSet.Tables[0].Merge(oleDb.dataSet.Tables[1]);	
				dataSet.Tables.Add(oleDb.dataSet.Tables[0].DefaultView.ToTable());
				
				foreach(DataRow row in dataSet.Tables[0].Rows)
	    		{
					listViewItemAdd = new ListViewItem();
					dt = new DateTime();
					DateTime.TryParse(row["docDate"].ToString(), out dt);
					listViewItemAdd.SubItems.Add(dt.ToString("dd.MM.yyyy"));
					
					if(row["docName"].ToString() == "План закупок") listViewItemAdd.StateImageIndex = 1;
					else if(row["docName"].ToString() == "Заказ") listViewItemAdd.StateImageIndex = 0;
					
					listViewItemAdd.SubItems.Add(row["docNumber"].ToString());
					listViewItemAdd.SubItems.Add(row["docName"].ToString());
					listViewItemAdd.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(row["docTotal"].ToString()).ToString()));
					
					if(row["docName"].ToString() == "Заказ"){
						listViewItemAdd.SubItems.Add(row["docCounteragent"].ToString());
						listViewItemAdd.SubItems.Add(row["docPurchasePlan"].ToString());
					}else if(row["docName"].ToString() == "План закупок"){
						listViewItemAdd.SubItems.Add("...");
						listViewItemAdd.SubItems.Add("");
					}
					
					listViewItemAdd.SubItems.Add(row["docAutor"].ToString());
					listViewItemAdd.SubItems.Add(row["id"].ToString());
					listView1.Items.Add(listViewItemAdd);
				}
				
				listView1.SelectedIndices.IndexOf(selectTableLine);
			}
		}
		
		void TableRefreshServer()
		{
			sqlServer = new SqlServer();
			sqlServer.dataSet.Clear();
			
			sqlServer.sqlCommandSelect.CommandText = "SELECT * FROM PurchasePlan WHERE (docDate BETWEEN '" + 
				dateTimePicker1.Text + "' AND '" + 
				dateTimePicker2.Text +
				"' AND (docNumber LIKE '%" + toolStripComboBox1.Text + 
				"%' OR docTotal LIKE '%" + toolStripComboBox1.Text + 
				"%' OR docAutor LIKE '%" + toolStripComboBox1.Text +
				"%')) ORDER BY docDate DESC";
			sqlServer.ExecuteFill("PurchasePlan");
			
			sqlServer.sqlCommandSelect.CommandText = "SELECT * FROM Orders WHERE (docDate BETWEEN '" + 
				dateTimePicker1.Text + "' AND '" + 
				dateTimePicker2.Text + "') " +
				"AND (docNumber LIKE '%" + toolStripComboBox1.Text + 
				"%' OR docSum LIKE '%" + toolStripComboBox1.Text + 
				"%' OR docVat LIKE '%" + toolStripComboBox1.Text + 
				"%' OR docTotal LIKE '%" + toolStripComboBox1.Text + 
				"%' OR docAutor LIKE '%" + toolStripComboBox1.Text +
				"%' OR docCounteragent LIKE '%" + toolStripComboBox1.Text +
				"%') ORDER BY docDate DESC";
			sqlServer.ExecuteFill("Orders");
			
			if(sqlServer.dataSet.Tables.Count > 0){
				listView1.Items.Clear();
				DateTime dt;
				ListViewItem listViewItemAdd;
				
				DataSet dataSet = new DataSet();
				sqlServer.dataSet.Tables[0].DefaultView.Sort = "docDate DESC";
				if(sqlServer.dataSet.Tables.Count > 1) sqlServer.dataSet.Tables[0].Merge(sqlServer.dataSet.Tables[1]);	
				dataSet.Tables.Add(sqlServer.dataSet.Tables[0].DefaultView.ToTable());
				
				foreach(DataRow row in dataSet.Tables[0].Rows)
	    		{
					listViewItemAdd = new ListViewItem();
					dt = new DateTime();
					DateTime.TryParse(row["docDate"].ToString(), out dt);
					listViewItemAdd.SubItems.Add(dt.ToString("dd.MM.yyyy"));
					
					if(row["docName"].ToString() == "План закупок") listViewItemAdd.StateImageIndex = 1;
					else if(row["docName"].ToString() == "Заказ") listViewItemAdd.StateImageIndex = 0;
					
					listViewItemAdd.SubItems.Add(row["docNumber"].ToString());
					listViewItemAdd.SubItems.Add(row["docName"].ToString());
					listViewItemAdd.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(row["docTotal"].ToString()).ToString()));
					
					if(row["docName"].ToString() == "Заказ"){
						listViewItemAdd.SubItems.Add(row["docCounteragent"].ToString());
						listViewItemAdd.SubItems.Add(row["docPurchasePlan"].ToString());
					}else if(row["docName"].ToString() == "План закупок"){
						listViewItemAdd.SubItems.Add("...");
						listViewItemAdd.SubItems.Add("");
					}
					
					listViewItemAdd.SubItems.Add(row["docAutor"].ToString());
					listViewItemAdd.SubItems.Add(row["id"].ToString());
					listView1.Items.Add(listViewItemAdd);
				}
				
				listView1.SelectedIndices.IndexOf(selectTableLine);
			}
		}
		
		void disposeDb()
		{
			if(oleDb != null) oleDb.Dispose();
			if(sqlServer != null) sqlServer.Dispose();
		}
		
		void search()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL && DataConfig.typeDatabase == DataConstants.TYPE_OLEDB) {
				// OLEDB
				try{
					TableRefreshLocal();
					Utilits.Console.Log(this.Text + ": поиск завершен.");
				}catch(Exception ex){
					disposeDb();
					Utilits.Console.Log("[ОШИБКА]: " + ex.Message.ToString(), false, true);
				}
			} else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER && DataConfig.typeDatabase == DataConstants.TYPE_MSSQL){
				// MSSQL SERVER
				try{
					TableRefreshServer();
					Utilits.Console.Log(this.Text + ": поиск завершен.");
				}catch(Exception ex){
					disposeDb();
					Utilits.Console.Log("[ОШИБКА]: " + ex.Message.ToString(), false, true);
				}
			}
			if(toolStripComboBox1.Text != "")  toolStripComboBox1.Items.Add(toolStripComboBox1.Text);
		}
		
		/* -- ORDER --------------------------------------------------------------------------------------- */
		void addOrder()
		{
			FormOrderDoc FOrderDoc = new FormOrderDoc();
			FOrderDoc.MdiParent = DataForms.FClient;
			FOrderDoc.ID = null;
			FOrderDoc.Show();
		}
		
		void editOrder()
		{
			if(listView1.SelectedIndices.Count > 0){
				FormOrderDoc FOrderDoc = new FormOrderDoc();
				FOrderDoc.MdiParent = DataForms.FClient;
				FOrderDoc.ID = listView1.Items[listView1.SelectedIndices[0]].SubItems[8].Text;
				FOrderDoc.ParentDoc = listView1.Items[listView1.SelectedIndices[0]].SubItems[6].Text;
				FOrderDoc.Show();
			}
		}
		
		void deleteOrder()
		{
			if(listView1.SelectedIndices.Count > 0){
				String docID = listView1.Items[listView1.SelectedIndices[0]].SubItems[8].Text;
				String docNumber = listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text;
				String docPurchasePlan = listView1.Items[listView1.SelectedIndices[0]].SubItems[6].Text;
				
				if(docPurchasePlan != ""){
					if(MessageBox.Show("Удалить документ Заказ №" + docNumber + Environment.NewLine + 
								"который связан с докуметном План закупок №" + docPurchasePlan + " ?",
								"Вопрос:", MessageBoxButtons.YesNo) == DialogResult.No){
						return;
					}
				}else{
					if(MessageBox.Show("Удалить документ Заказ №" + docNumber + Environment.NewLine + 
								"который не связан с докуметном план закупок ?",
								"Вопрос:", MessageBoxButtons.YesNo) == DialogResult.No){
						return;
					}
				}
				
				if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL) {
					// OLEDB
					QueryOleDb query;
					query = new QueryOleDb(DataConfig.localDatabase);
					query.SetCommand("UPDATE OrderNomenclature SET docOrder = '' WHERE (docOrder = '" + docNumber + "')");
					if(query.Execute()){
						query = new QueryOleDb(DataConfig.localDatabase);
						query.SetCommand("DELETE FROM Orders WHERE (id = " + docID + ")");
						if(query.Execute()){
							DataForms.FClient.updateHistory("Orders");
							Utilits.Console.Log("Документ Заказ №" + docNumber + " успешно удален.");
						}else{
							Utilits.Console.Log("[ОШИБКА] Документ Заказ №" + docNumber + " не удалось удалить!", false, true);
						}
					}else{
						Utilits.Console.Log("[ОШИБКА] Документ План закупок №" + docPurchasePlan + " не удалось обновить!", false, true);
					}					
					
				} else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
					// MSSQL SERVER
					QuerySqlServer query;
					query = new QuerySqlServer(DataConfig.serverConnection);
					query.SetCommand("UPDATE OrderNomenclature SET docOrder = '' WHERE (docOrder = '" + docNumber + "')");
					if(query.Execute()){
						query = new QuerySqlServer(DataConfig.serverConnection);
						query.SetCommand("DELETE FROM Orders WHERE (id = " + docID + ")");
						if(query.Execute()){
							DataForms.FClient.updateHistory("Orders");
							Utilits.Console.Log("Документ Заказ №" + docNumber + " успешно удален.");
						}else{
							Utilits.Console.Log("[ОШИБКА] Документ Заказ №" + docNumber + " не удалось удалить!", false, true);
						}
					}else{
						Utilits.Console.Log("[ОШИБКА] Документ План закупок №" + docPurchasePlan + " не удалось обновить!", false, true);
					}	
				}
			}
		}
		
		/* -- ORDER --------------------------------------------------------------------------------------- */
		
		/* -- PURCHASE PLAN ------------------------------------------------------------------------------- */
		void addPPlan()
		{
			FormPurchasePlanDoc FPurchasePlanDoc = new FormPurchasePlanDoc();
			FPurchasePlanDoc.MdiParent = DataForms.FClient;
			FPurchasePlanDoc.ID = null;
			FPurchasePlanDoc.Show();
		}
		
		void editPPlan()
		{
			if(listView1.SelectedIndices.Count > 0){
				FormPurchasePlanDoc FPurchasePlanDoc = new FormPurchasePlanDoc();
				FPurchasePlanDoc.MdiParent = DataForms.FClient;
				FPurchasePlanDoc.ID = listView1.Items[listView1.SelectedIndices[0]].SubItems[8].Text;
				FPurchasePlanDoc.Show();
			}
		}
		
		void deletePPlan()
		{
			if(listView1.SelectedIndices.Count > 0){
				String docID = listView1.Items[listView1.SelectedIndices[0]].SubItems[8].Text;
				String docNumber = listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text;
				
				if(MessageBox.Show("Удалить документ План закупок №" + docNumber + Environment.NewLine + " и связанные с ним Заказы ?"  ,"Вопрос:", MessageBoxButtons.YesNo) == DialogResult.Yes){
					if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL) {
						// OLEDB
						QueryOleDb query;
						
						query = new QueryOleDb(DataConfig.localDatabase);
						query.SetCommand("DELETE FROM Orders WHERE (docPurchasePlan = '" + docNumber + "')");
						if(!query.Execute()){
							Utilits.Console.Log("[ОШИБКА] Не удалось удалить заказы привязанные к Плану закупок №" + docNumber, false, true);
							return;
						}
						
						query = new QueryOleDb(DataConfig.localDatabase);
						query.SetCommand("DELETE FROM OrderNomenclature WHERE (docPurchasePlan = '" + docNumber + "')");
						if(!query.Execute()){
							Utilits.Console.Log("[ОШИБКА] Документ план закупок №" + docNumber + " не удалось удалить перечень номенклатуры!", false, true);
							return;
						}
						
						query = new QueryOleDb(DataConfig.localDatabase);
						query.SetCommand("DELETE FROM PurchasePlanPriceLists WHERE (docID = '" + docNumber + "')");
						if(!query.Execute()){
							Utilits.Console.Log("[ОШИБКА] Документ план закупок №" + docNumber + " не удалось удалить перечень прайс-листов!", false, true);
							return;
						}
						
						query = new QueryOleDb(DataConfig.localDatabase);
						query.SetCommand("DELETE FROM PurchasePlan WHERE (id = " + docID + ")");
						if(!query.Execute()){
							Utilits.Console.Log("[ОШИБКА] Документ план закупок №" + docNumber + " не получилось удалить!", false, true);
							return;
						}
						
						Utilits.Console.Log("Документ план закупок №" + docNumber + " успешно удален.");
						DataForms.FClient.updateHistory("Orders");
						DataForms.FClient.updateHistory("PurchasePlan");
						
											
					} else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
						// MSSQL SERVER
						QuerySqlServer query;
						
						query = new QuerySqlServer(DataConfig.serverConnection);
						query.SetCommand("DELETE FROM Orders WHERE (docPurchasePlan = '" + docNumber + "')");
						if(!query.Execute()){
							Utilits.Console.Log("[ОШИБКА] Не удалось удалить заказы привязанные к Плану закупок №" + docNumber, false, true);
							return;
						}
						
						query = new QuerySqlServer(DataConfig.serverConnection);
						query.SetCommand("DELETE FROM OrderNomenclature WHERE (docPurchasePlan = '" + docNumber + "')");
						if(!query.Execute()){
							Utilits.Console.Log("[ОШИБКА] Документ план закупок №" + docNumber + " не удалось удалить перечень номенклатуры!", false, true);
							return;
						}
						
						query = new QuerySqlServer(DataConfig.serverConnection);
						query.SetCommand("DELETE FROM PurchasePlanPriceLists WHERE (docID = '" + docNumber + "')");
						if(!query.Execute()){
							Utilits.Console.Log("[ОШИБКА] Документ план закупок №" + docNumber + " не удалось удалить перечень прайс-листов!", false, true);
							return;
						}
						
						query = new QuerySqlServer(DataConfig.serverConnection);
						query.SetCommand("DELETE FROM PurchasePlan WHERE (id = " + docID + ")");
						if(!query.Execute()){
							Utilits.Console.Log("[ОШИБКА] Документ план закупок №" + docNumber + " не получилось удалить!", false, true);
							return;
						}
						
						Utilits.Console.Log("Документ план закупок №" + docNumber + " успешно удален.");
						DataForms.FClient.updateHistory("Orders");
						DataForms.FClient.updateHistory("PurchasePlan");
						
					}
				}			
			}
		}		
		/* -- PURCHASE PLAN ------------------------------------------------------------------------------- */
		
		/* =================================================================================================
		 * РАЗДЕЛ: СОБЫТИЙ
		 * =================================================================================================
		 */
		void FormFullJournalLoad(object sender, EventArgs e)
		{
			getPeriod();
			TableRefresh(); // Загрузка данных из базы данных
			Utilits.Console.Log(this.Text + ": открыт");
		}
		void FormFullJournalFormClosed(object sender, FormClosedEventArgs e)
		{
			disposeDb();
			DataForms.FClient.messageInStatus("...");
			Utilits.Console.Log(this.Text + ": закрыт");
			Dispose();
			DataForms.FFullJournal = null;
		}
		void FormFullJournalActivated(object sender, EventArgs e)
		{
			DataForms.FClient.messageInStatus(this.Text);
		}
		void ЗаказToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			addOrder();
		}
		void ПланЗакупокToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			addPPlan();
		}
		void ToolStripButton2Click(object sender, EventArgs e)
		{
			String docName = listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text;
			if(docName == "План закупок") editPPlan();
			else if(docName == "Заказ") editOrder();
		}
		void ToolStripButton3Click(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest" || DataConfig.userPermissions == "user"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			String docName = listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text;
			if(docName == "План закупок") deletePPlan();
			else if(docName == "Заказ") deleteOrder();
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
		void DateButtonClick(object sender, EventArgs e)
		{
			TableRefresh();
		}
		void ButtonCloseClick(object sender, EventArgs e)
		{
			Close();
		}
		void ЗаказToolStripMenuItem1Click(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			addOrder();
		}
		void ПланЗакупокToolStripMenuItem1Click(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			addPPlan();
		}
		void РедактироватьДокументToolStripMenuItemClick(object sender, EventArgs e)
		{
			String docName = listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text;
			if(docName == "План закупок") editPPlan();
			else if(docName == "Заказ") editOrder();
		}
		void УдалитьДокументToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest" || DataConfig.userPermissions == "user"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			String docName = listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text;
			if(docName == "План закупок") deletePPlan();
			else if(docName == "Заказ") deleteOrder();
		}
		void ЗаказToolStripMenuItem2Click(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest" || DataConfig.userPermissions == "user"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
						
			if(listView1.SelectedIndices.Count > 0){
				String docName = listView1.Items[listView1.SelectedIndices[0]].SubItems[3].Text;
				if(docName == "План закупок") {
					InputToOrder inputToOrder = new InputToOrder(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text);
					inputToOrder.Execute();
				}else if(docName == "Заказ"){
					MessageBox.Show("Выберите документ План закупок чтобы создать на основании него Заказы.", "Сообщение");
				}
			}
		}
		void ОбновитьToolStripMenuItemClick(object sender, EventArgs e)
		{
			toolStripComboBox1.Text = "";
			TableRefresh();
		}
	}
}
