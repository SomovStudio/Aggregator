/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 09.04.2017
 * Время: 13:43
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

namespace Aggregator.Client.Documents.Order
{
	/// <summary>
	/// Description of FormOrderJournal.
	/// </summary>
	public partial class FormOrderJournal : Form
	{
		public FormOrderJournal()
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
			oleDb.dataSet.DataSetName = "Orders";
			
			// Дата в формате: BETWEEN #месяц/день/год# AND #месяц/день/год#
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
			
			if(oleDb.ExecuteFill("Orders")){
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
					ListViewItem_add.SubItems.Add(rowElement["docCounteragent"].ToString());
					ListViewItem_add.SubItems.Add(rowElement["docAutor"].ToString());
					ListViewItem_add.SubItems.Add(rowElement["docPurchasePlan"].ToString());
					ListViewItem_add.SubItems.Add(rowElement["id"].ToString());
					listView1.Items.Add(ListViewItem_add);
				}
			}else{
				Utilits.Console.Log("[ОШИБКА] Ошибка выполнения запроса к таблице Заказы.");
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
			sqlServer.dataSet.DataSetName = "Orders";
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
			
			if(sqlServer.ExecuteFill("Orders")){
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
					ListViewItem_add.SubItems.Add(rowElement["docCounteragent"].ToString());
					ListViewItem_add.SubItems.Add(rowElement["docAutor"].ToString());
					ListViewItem_add.SubItems.Add(rowElement["docPurchasePlan"].ToString());
					ListViewItem_add.SubItems.Add(rowElement["id"].ToString());
					listView1.Items.Add(ListViewItem_add);
				}
			}else{
				Utilits.Console.Log("[ОШИБКА] Ошибка выполнения запроса к таблице Заказы.");
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
			FormOrderDoc FOrderDoc = new FormOrderDoc();
			FOrderDoc.MdiParent = DataForms.FClient;
			FOrderDoc.ID = null;
			FOrderDoc.Show();
		}
		
		void editFile()
		{
			if(listView1.SelectedIndices.Count > 0){
				FormOrderDoc FOrderDoc = new FormOrderDoc();
				FOrderDoc.MdiParent = DataForms.FClient;
				FOrderDoc.ID = listView1.Items[listView1.SelectedIndices[0]].SubItems[10].Text;
				FOrderDoc.ParentDoc = listView1.Items[listView1.SelectedIndices[0]].SubItems[9].Text;
				FOrderDoc.Show();
			}
		}
		
		void deleteFile()
		{
			if(listView1.SelectedIndices.Count > 0){
				String docID = listView1.Items[listView1.SelectedIndices[0]].SubItems[10].Text;
				String docNumber = listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text;
				String docPurchasePlan = listView1.Items[listView1.SelectedIndices[0]].SubItems[9].Text;
				
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
		
		
		/* =================================================================================================
		 * РАЗДЕЛ: СОБЫТИЙ
		 * =================================================================================================
		 */
		void FormOrderJournalLoad(object sender, EventArgs e)
		{
			getPeriod();
			TableRefresh(); // Загрузка данных из базы данных
			Utilits.Console.Log(this.Text + ": открыт");
		}
		void FormOrderJournalFormClosed(object sender, FormClosedEventArgs e)
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL && oleDb != null) oleDb.Dispose();
			if(DataConfig.typeConnection == DataConstants.CONNETION_SERVER && sqlServer != null) sqlServer.Dispose();
			DataForms.FClient.messageInStatus("...");
			Utilits.Console.Log(this.Text + ": закрыт");
			Dispose();
			DataForms.FOrderJournal = null;
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
		void ОбновитьToolStripMenuItemClick(object sender, EventArgs e)
		{
			toolStripComboBox1.Text = "";
			TableRefresh();
		}
		void DateButtonClick(object sender, EventArgs e)
		{
			TableRefresh();
		}
		void FindButtonClick(object sender, EventArgs e)
		{
			search();
		}
		void СоздатьПланЗакупокToolStripMenuItemClick(object sender, EventArgs e)
		{
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
		void FormOrderJournalActivated(object sender, EventArgs e)
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
