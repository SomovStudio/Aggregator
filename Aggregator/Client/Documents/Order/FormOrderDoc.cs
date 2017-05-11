/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 09.04.2017
 * Время: 15:00
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Aggregator.Data;
using Aggregator.Database.Local;
using Aggregator.Database.Server;
using Aggregator.Client.Directories;
using Aggregator.Utilits;
using ExcelLibrary.SpreadSheet;

namespace Aggregator.Client.Documents.Order
{
	/// <summary>
	/// Description of FormOrderDoc.
	/// </summary>
	public partial class FormOrderDoc : Form
	{
		public FormOrderDoc()
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
		public String ParentDoc;
		OleDb oleDb;
		SqlServer sqlServer;
		String docNumber;
		int selectTableLine = -1;		// выбранная строка в таблице
		String priceDate;
		
		String getDocNumber()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL) {
				// OLEDB
				OleDbConnection oleDbConnection = new OleDbConnection();
				oleDbConnection.ConnectionString = DataConfig.oledbConnectLineBegin + DataConfig.localDatabase + DataConfig.oledbConnectLineEnd + DataConfig.oledbConnectPass;
				try{
					
					OleDbCommand oleDbCommand = new OleDbCommand("SELECT MAX(id) FROM Orders", oleDbConnection);
					oleDbConnection.Open();
					var order_id = oleDbCommand.ExecuteScalar();
					oleDbConnection.Close();
					
					int num;
					if (order_id.ToString() == "") num = 1;
					else num = (int)order_id + 1;
					String idStr = num.ToString();
					String numStr = "ЗА-0000000";
					numStr = numStr.Remove((numStr.Length - idStr.Length));
					numStr += idStr;
					return numStr;
				}catch(Exception ex){
					oleDbConnection.Close();
					Utilits.Console.Log("[ОШИБКА]: " + ex.Message, false, true);
				}
			} else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				SqlConnection sqlConnection = new SqlConnection(DataConfig.serverConnection);
				try{
					SqlCommand sqlCommand = new SqlCommand("SELECT MAX(id) FROM Orders", sqlConnection);
					sqlConnection.Open();
					var order_id = sqlCommand.ExecuteScalar();
					sqlConnection.Close();
					
					int num;
					if (order_id.ToString() == "") num = 1;
					else num = (int)order_id + 1;
					String idStr = num.ToString();
					String numStr = "ЗА-0000000";
					numStr = numStr.Remove((numStr.Length - idStr.Length));
					numStr += idStr;
					return numStr;
				}catch(Exception ex){
					sqlConnection.Close();
					Utilits.Console.Log("[ОШИБКА]: " + ex.Message, false, true);
				}
			}
			return null;
		}
		
		void listViewClear()
		{
			while(listViewNomenclature.Items.Count > 0){
				listViewNomenclature.Items[0].Remove();
			}
			selectTableLine = -1;
			calculate();
		}
		
		void calculate()
		{
			if(listViewNomenclature.Items.Count > 0){
				double sum = 0;
				double amount = 0;
				double price = 0;
				double vat = 0;
				double total = 0;
				int count = listViewNomenclature.Items.Count;
				for(int i = 0; i < count; i++){
					if(listViewNomenclature.Items[i].SubItems[3].Text != "") amount = Conversion.StringToDouble(listViewNomenclature.Items[i].SubItems[3].Text);
					else amount = 0;
					if(listViewNomenclature.Items[i].SubItems[4].Text != "") price = Conversion.StringToDouble(listViewNomenclature.Items[i].SubItems[4].Text);
					else price = 0;
					sum += (price * amount);
					
					vat = Math.Round(price * amount, 2) * DataConstants.ConstFirmVAT / 100;
					vat = Math.Round(vat, 2);
					listViewNomenclature.Items[i].SubItems[5].Text = Conversion.StringToMoney(Conversion.StringToDouble(vat.ToString()).ToString());
					total = Math.Round(price * amount, 2) + vat;
					listViewNomenclature.Items[i].SubItems[6].Text = Conversion.StringToMoney(Conversion.StringToDouble(total.ToString()).ToString());
				}
				sum = Math.Round(sum, 2);
				vat = sum * DataConstants.ConstFirmVAT / 100;
				vat = Math.Round(vat, 2);
				total = sum + vat;
				total = Math.Round(total, 2);
				
				sumTextBox.Text = Conversion.StringToMoney(Conversion.StringToDouble(sum.ToString()).ToString());
				vatTextBox.Text = Conversion.StringToMoney(Conversion.StringToDouble(vat.ToString()).ToString());
				totalTextBox.Text = Conversion.StringToMoney(Conversion.StringToDouble(total.ToString()).ToString());
			}else{
				sumTextBox.Text = "0,00";
				vatTextBox.Text = "0,00";
				totalTextBox.Text = "0,00";
			}
		}
		
		void search()
		{
			String str;
			for(int i = 0; i < listViewNomenclature.Items.Count; i++){
				str = listViewNomenclature.Items[i].SubItems[1].Text;
				if(str.Contains(comboBox1.Text)){
					listViewNomenclature.FocusedItem = listViewNomenclature.Items[i];
					listViewNomenclature.Items[i].Selected = true;
					listViewNomenclature.Select();
					listViewNomenclature.EnsureVisible(i);
					break;
				}
			}
		}
		
		void addAllNomenclatures()
		{
			DateTime dt;
			ListViewItem ListViewItem_add;
			String priceName = "";
			
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL) {
				// OLEDB
				OleDbConnection oleDbConnection = new OleDbConnection();
				oleDbConnection.ConnectionString = DataConfig.oledbConnectLineBegin + 
													DataConfig.localDatabase + 
													DataConfig.oledbConnectLineEnd + 
													DataConfig.oledbConnectPass;
				oleDbConnection.Open();
				OleDbCommand oleDbCommand = new OleDbCommand("SELECT * FROM Counteragents WHERE (name = '" + counteragentTextBox.Text + "')", oleDbConnection);
				OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
				if(oleDbDataReader.Read()){
					priceName = oleDbDataReader["excel_table_id"].ToString();
				}else{
					MessageBox.Show("Контрагент " + "\"" + counteragentTextBox.Text + "\"" + " не существует в справочнике контрагентов.", "Сообщение");
				}
				oleDbDataReader.Close();
				
				if(priceName != ""){
					oleDbCommand = new OleDbCommand("SELECT * FROM " + priceName + " ", oleDbConnection);
					oleDbDataReader = oleDbCommand.ExecuteReader();
					while (oleDbDataReader.Read())
		        	{
						ListViewItem_add = new ListViewItem();
						ListViewItem_add.SubItems.Add(oleDbDataReader["name"].ToString());
						ListViewItem_add.StateImageIndex = 0;
						ListViewItem_add.SubItems.Add(DataConstants.ConstFirmUnits);
						ListViewItem_add.SubItems.Add("0,00");
						ListViewItem_add.SubItems.Add(oleDbDataReader["price"].ToString());
						ListViewItem_add.SubItems.Add("0,00");
						ListViewItem_add.SubItems.Add("0,00");
						ListViewItem_add.SubItems.Add(oleDbDataReader["manufacturer"].ToString());
						ListViewItem_add.SubItems.Add(oleDbDataReader["remainder"].ToString());
						dt = new DateTime();
						DateTime.TryParse(oleDbDataReader["term"].ToString(), out dt);
						ListViewItem_add.SubItems.Add(dt.ToString("dd.MM.yyyy"));
						ListViewItem_add.SubItems.Add(oleDbDataReader["discount1"].ToString());
						ListViewItem_add.SubItems.Add(oleDbDataReader["discount2"].ToString());
						ListViewItem_add.SubItems.Add(oleDbDataReader["discount3"].ToString());
						ListViewItem_add.SubItems.Add(oleDbDataReader["discount4"].ToString());
						ListViewItem_add.SubItems.Add(oleDbDataReader["code"].ToString());
						ListViewItem_add.SubItems.Add(oleDbDataReader["series"].ToString());
						ListViewItem_add.SubItems.Add(oleDbDataReader["article"].ToString());
						ListViewItem_add.SubItems.Add(counteragentTextBox.Text);
						ListViewItem_add.SubItems.Add(priceName);
						listViewNomenclature.Items.Add(ListViewItem_add);
					}
					oleDbDataReader.Close();
				}else{
					MessageBox.Show("Контрагент " + counteragentTextBox.Text + " не содержит прайс-листа.", "Сообщение");
				}
				oleDbConnection.Close();
				
			} else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				SqlConnection sqlConnection;
				SqlCommand sqlCommand;
				SqlDataReader sqlDataReader;
				
				sqlConnection = new SqlConnection(DataConfig.serverConnection);
				sqlConnection.Open();
				
				sqlCommand = new SqlCommand("SELECT * FROM Counteragents WHERE (name = '" + counteragentTextBox.Text + "')", sqlConnection);
				sqlDataReader = sqlCommand.ExecuteReader();
				if(sqlDataReader.Read()){
					priceName = sqlDataReader["excel_table_id"].ToString();
				}else{
					MessageBox.Show("Контрагент " + "\"" + counteragentTextBox.Text + "\"" + " не существует в справочнике контрагентов.", "Сообщение");
				}
				sqlDataReader.Close();
				
				if(priceName != ""){
					sqlCommand = new SqlCommand("SELECT * FROM " + priceName + " ", sqlConnection);
					sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
		        	{
						ListViewItem_add = new ListViewItem();
						ListViewItem_add.SubItems.Add(sqlDataReader["name"].ToString());
						ListViewItem_add.StateImageIndex = 0;
						ListViewItem_add.SubItems.Add(DataConstants.ConstFirmUnits);
						ListViewItem_add.SubItems.Add("0,00");
						ListViewItem_add.SubItems.Add(sqlDataReader["price"].ToString());
						ListViewItem_add.SubItems.Add("0,00");
						ListViewItem_add.SubItems.Add("0,00");
						ListViewItem_add.SubItems.Add(sqlDataReader["manufacturer"].ToString());
						ListViewItem_add.SubItems.Add(sqlDataReader["remainder"].ToString());
						dt = new DateTime();
						DateTime.TryParse(sqlDataReader["term"].ToString(), out dt);
						ListViewItem_add.SubItems.Add(dt.ToString("dd.MM.yyyy"));
						ListViewItem_add.SubItems.Add(sqlDataReader["discount1"].ToString());
						ListViewItem_add.SubItems.Add(sqlDataReader["discount2"].ToString());
						ListViewItem_add.SubItems.Add(sqlDataReader["discount3"].ToString());
						ListViewItem_add.SubItems.Add(sqlDataReader["discount4"].ToString());
						ListViewItem_add.SubItems.Add(sqlDataReader["code"].ToString());
						ListViewItem_add.SubItems.Add(sqlDataReader["series"].ToString());
						ListViewItem_add.SubItems.Add(sqlDataReader["article"].ToString());
						ListViewItem_add.SubItems.Add(counteragentTextBox.Text);
						ListViewItem_add.SubItems.Add(priceName);
						listViewNomenclature.Items.Add(ListViewItem_add);
					}
					sqlDataReader.Close();
				}else{
					MessageBox.Show("Контрагент " + counteragentTextBox.Text + " не содержит прайс-листа.", "Сообщение");
				}				
				sqlConnection.Close();
			}
		}
		
		bool check()
		{
			if(counteragentTextBox.Text == ""){
				MessageBox.Show("Вы не выбрали контрагента.", "Сообщение");
				return false;
			}
			if(listViewNomenclature.Items.Count == 0){
				MessageBox.Show("Вы не добавили номенклатуру.", "Сообщение");
				return false;
			}
			return true;
		}
		
		void saveNew()
		{
			docNumber = getDocNumber();
			if(docNumber == null) {
				Utilits.Console.Log("[ОШИБКА] автонумерация не смогла назначить номер для документа.", false, true);
				return;
			}
			
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				// OLEDB
				oleDb = new OleDb(DataConfig.localDatabase);
				oleDb.oleDbCommandSelect.CommandText = "SELECT id, docDate, docNumber, docName, docCounteragent, docAutor, docSum, docVat, docTotal, docPurchasePlan FROM Orders WHERE (id = 0)";
				oleDb.ExecuteFill("Orders");
				
				DataRow newRow = oleDb.dataSet.Tables["Orders"].NewRow();
				newRow["docDate"] = dateTimePicker1.Value;
				newRow["docNumber"] = docNumber;
				newRow["docName"] = "Заказ";
				newRow["docCounteragent"] = counteragentTextBox.Text;
				newRow["docAutor"] = DataConfig.userName;
				newRow["docSum"] = sumTextBox.Text;
				newRow["docVat"] = vatTextBox.Text;
				newRow["docTotal"] = totalTextBox.Text;
				newRow["docPurchasePlan"] = "";
				oleDb.dataSet.Tables["Orders"].Rows.Add(newRow);
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO Orders (docDate, docNumber, docName, docCounteragent, docAutor, docSum, docVat, docTotal, docPurchasePlan) " +
					"VALUES (@docDate, @docNumber, @docName, @docCounteragent, @docAutor, @docSum, @docVat, @docTotal, @docPurchasePlan)";
				oleDb.oleDbCommandInsert.Parameters.Add("@docDate", OleDbType.Date, 255, "docDate");
				oleDb.oleDbCommandInsert.Parameters.Add("@docNumber", OleDbType.VarChar, 255, "docNumber");
				oleDb.oleDbCommandInsert.Parameters.Add("@docName", OleDbType.VarChar, 255, "docName");
				oleDb.oleDbCommandInsert.Parameters.Add("@docCounteragent", OleDbType.VarChar, 255, "docCounteragent");
				oleDb.oleDbCommandInsert.Parameters.Add("@docAutor", OleDbType.VarChar, 255, "docAutor");
				oleDb.oleDbCommandInsert.Parameters.Add("@docSum", OleDbType.Double, 15, "docSum");
				oleDb.oleDbCommandInsert.Parameters.Add("@docVat", OleDbType.Double, 15, "docVat");
				oleDb.oleDbCommandInsert.Parameters.Add("@docTotal", OleDbType.Double, 15, "docTotal");
				oleDb.oleDbCommandInsert.Parameters.Add("@docPurchasePlan", OleDbType.VarChar, 255, "docPurchasePlan");
				if(oleDb.ExecuteUpdate("Orders")){
					DataForms.FClient.updateHistory("Orders");
					if(saveNewOrderNomenclature() == false){
						Utilits.Console.Log("[ПРЕДУПРЕЖДЕНИЕ] Документ Заказ №" + docNumber + ": не удалось сохранить список выбранной номенклатуры.", false, true);
						return;
					}
					Utilits.Console.Log("Документ Заказ №" + docNumber + ": успешно создан.");
					Close();
				}
				
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				sqlServer = new SqlServer();
				sqlServer.sqlCommandSelect.CommandText = "SELECT id, docDate, docNumber, docName, docCounteragent, docAutor, docSum, docVat, docTotal, docPurchasePlan FROM Orders WHERE (id = 0)";
				sqlServer.ExecuteFill("Orders");
				
				DataRow newRow = sqlServer.dataSet.Tables["Orders"].NewRow();
				newRow["docDate"] = dateTimePicker1.Value;
				newRow["docNumber"] = docNumber;
				newRow["docName"] = "Заказ";
				newRow["docCounteragent"] = counteragentTextBox.Text;
				newRow["docAutor"] = DataConfig.userName;
				newRow["docSum"] = sumTextBox.Text;
				newRow["docVat"] = vatTextBox.Text;
				newRow["docTotal"] = totalTextBox.Text;
				newRow["docPurchasePlan"] = "";
				sqlServer.dataSet.Tables["Orders"].Rows.Add(newRow);
				
				sqlServer.sqlCommandInsert.CommandText = "INSERT INTO Orders (docDate, docNumber, docName, docCounteragent, docAutor, docSum, docVat, docTotal, docPurchasePlan) " +
					"VALUES (@docDate, @docNumber, @docName, @docCounteragent, @docAutor, @docSum, @docVat, @docTotal, @docPurchasePlan)";
				sqlServer.sqlCommandInsert.Parameters.Add("@docDate", SqlDbType.Date, 255, "docDate");
				sqlServer.sqlCommandInsert.Parameters.Add("@docNumber", SqlDbType.VarChar, 255, "docNumber");
				sqlServer.sqlCommandInsert.Parameters.Add("@docName", SqlDbType.VarChar, 255, "docName");
				sqlServer.sqlCommandInsert.Parameters.Add("@docCounteragent", SqlDbType.VarChar, 255, "docCounteragent");
				sqlServer.sqlCommandInsert.Parameters.Add("@docAutor", SqlDbType.VarChar, 255, "docAutor");
				sqlServer.sqlCommandInsert.Parameters.Add("@docSum", SqlDbType.Float, 15, "docSum");
				sqlServer.sqlCommandInsert.Parameters.Add("@docVat", SqlDbType.Float, 15, "docVat");
				sqlServer.sqlCommandInsert.Parameters.Add("@docTotal", SqlDbType.Float, 15, "docTotal");
				sqlServer.sqlCommandInsert.Parameters.Add("@docPurchasePlan", SqlDbType.VarChar, 255, "docPurchasePlan");
				if(sqlServer.ExecuteUpdate("Orders")){
					DataForms.FClient.updateHistory("Orders");
					if(saveNewOrderNomenclature() == false){
						Utilits.Console.Log("[ПРЕДУПРЕЖДЕНИЕ] Документ Заказ №" + docNumber + ": не удалось сохранить список выбранной номенклатуры.", false, true);
						return;
					}
					Utilits.Console.Log("Документ Заказ №" + docNumber + ": успешно создан.");
					Close();
				}
				
			}
		}
		
		bool saveNewOrderNomenclature()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				// OLEDB
				oleDb = new OleDb(DataConfig.localDatabase);
				oleDb.oleDbCommandSelect.CommandText = "SELECT id, " +
					"nomenclatureID, nomenclatureName, units, amount, " +
					"name, price, manufacturer, remainder, term, discount1, discount2, discount3, discount4, code, series, article, " +
					"counteragentName, counteragentPricelist, " +
					"docPurchasePlan, docOrder " + 
					"FROM OrderNomenclature WHERE (id = 0)";
				oleDb.ExecuteFill("OrderNomenclature");
				
				DataRow newRow = null;
				for(int i = 0; i < listViewNomenclature.Items.Count; i++){
					newRow = oleDb.dataSet.Tables["OrderNomenclature"].NewRow();
					newRow["nomenclatureID"] = 0;
					newRow["nomenclatureName"] = "";
					newRow["name"] = listViewNomenclature.Items[i].SubItems[1].Text;
					newRow["units"] = listViewNomenclature.Items[i].SubItems[2].Text;
					newRow["amount"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[3].Text);
					newRow["price"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[4].Text);
					newRow["manufacturer"] = listViewNomenclature.Items[i].SubItems[7].Text;
					newRow["remainder"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[8].Text);
					newRow["term"] = listViewNomenclature.Items[i].SubItems[9].Text;
					newRow["discount1"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[10].Text);
					newRow["discount2"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[11].Text);
					newRow["discount3"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[12].Text);
					newRow["discount4"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[13].Text);
					newRow["code"] = listViewNomenclature.Items[i].SubItems[14].Text;
					newRow["series"] = listViewNomenclature.Items[i].SubItems[15].Text;
					newRow["article"] = listViewNomenclature.Items[i].SubItems[16].Text;
					newRow["counteragentName"] = listViewNomenclature.Items[i].SubItems[17].Text;
					newRow["counteragentPricelist"] = listViewNomenclature.Items[i].SubItems[18].Text;
					newRow["docPurchasePlan"] = "";
					newRow["docOrder"] = docNumber;
					oleDb.dataSet.Tables["OrderNomenclature"].Rows.Add(newRow);
				}
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO OrderNomenclature (" +
					"nomenclatureID, nomenclatureName, units, amount, " +
					"name, price, manufacturer, remainder, term, discount1, discount2, discount3, discount4, code, series, article, " +
					"counteragentName, counteragentPricelist, " +
					"docPurchasePlan, docOrder " + 
					") VALUES (" +
					"@nomenclatureID, @nomenclatureName, @units, @amount, " +
					"@name, @price, @manufacturer, @remainder, @term, @discount1, @discount2, @discount3, @discount4, @code, @series, @article, " +
					"@counteragentName, @counteragentPricelist, " +
					"@docPurchasePlan, @docOrder " + 
					")";
				oleDb.oleDbCommandInsert.Parameters.Add("@nomenclatureID", OleDbType.Integer, 10, "nomenclatureID");
				oleDb.oleDbCommandInsert.Parameters.Add("@nomenclatureName", OleDbType.VarChar, 255, "nomenclatureName");
				oleDb.oleDbCommandInsert.Parameters.Add("@units", OleDbType.VarChar, 255, "units");
				oleDb.oleDbCommandInsert.Parameters.Add("@amount", OleDbType.Double, 15, "amount");
				oleDb.oleDbCommandInsert.Parameters.Add("@name", OleDbType.VarChar, 255, "name");
				oleDb.oleDbCommandInsert.Parameters.Add("@price", OleDbType.Double, 15, "price");
				oleDb.oleDbCommandInsert.Parameters.Add("@manufacturer", OleDbType.VarChar, 255, "manufacturer");
				oleDb.oleDbCommandInsert.Parameters.Add("@remainder", OleDbType.Double, 15, "remainder");
				oleDb.oleDbCommandInsert.Parameters.Add("@term", OleDbType.Date, 15, "term");
				oleDb.oleDbCommandInsert.Parameters.Add("@discount1", OleDbType.Double, 15, "discount1");
				oleDb.oleDbCommandInsert.Parameters.Add("@discount2", OleDbType.Double, 15, "discount2");
				oleDb.oleDbCommandInsert.Parameters.Add("@discount3", OleDbType.Double, 15, "discount3");
				oleDb.oleDbCommandInsert.Parameters.Add("@discount4", OleDbType.Double, 15, "discount4");
				oleDb.oleDbCommandInsert.Parameters.Add("@code", OleDbType.VarChar, 255, "code");
				oleDb.oleDbCommandInsert.Parameters.Add("@series", OleDbType.VarChar, 255, "series");
				oleDb.oleDbCommandInsert.Parameters.Add("@article", OleDbType.VarChar, 255, "article");
				oleDb.oleDbCommandInsert.Parameters.Add("@counteragentName", OleDbType.VarChar, 255, "counteragentName");
				oleDb.oleDbCommandInsert.Parameters.Add("@counteragentPricelist", OleDbType.VarChar, 255, "counteragentPricelist");
				oleDb.oleDbCommandInsert.Parameters.Add("@docPurchasePlan", OleDbType.VarChar, 255, "docPurchasePlan");
				oleDb.oleDbCommandInsert.Parameters.Add("@docOrder", OleDbType.VarChar, 255, "docOrder");
				if(oleDb.ExecuteUpdate("OrderNomenclature")){
					return true;
				}else{
					return false;
				}
				
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				sqlServer = new SqlServer();
				sqlServer.sqlCommandSelect.CommandText = "SELECT id, " +
					"nomenclatureID, nomenclatureName, units, amount, " +
					"name, price, manufacturer, remainder, term, discount1, discount2, discount3, discount4, code, series, article, " +
					"counteragentName, counteragentPricelist, " +
					"docPurchasePlan, docOrder " + 
					"FROM OrderNomenclature WHERE (id = 0)";
				sqlServer.ExecuteFill("OrderNomenclature");
				
				DataRow newRow = null;
				for(int i = 0; i < listViewNomenclature.Items.Count; i++){
					newRow = sqlServer.dataSet.Tables["OrderNomenclature"].NewRow();
					newRow["nomenclatureID"] = 0;
					newRow["nomenclatureName"] = "";
					newRow["name"] = listViewNomenclature.Items[i].SubItems[1].Text;
					newRow["units"] = listViewNomenclature.Items[i].SubItems[2].Text;
					newRow["amount"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[3].Text);
					newRow["price"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[4].Text);
					newRow["manufacturer"] = listViewNomenclature.Items[i].SubItems[7].Text;
					newRow["remainder"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[8].Text);
					newRow["term"] = listViewNomenclature.Items[i].SubItems[9].Text;
					newRow["discount1"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[10].Text);
					newRow["discount2"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[11].Text);
					newRow["discount3"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[12].Text);
					newRow["discount4"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[13].Text);
					newRow["code"] = listViewNomenclature.Items[i].SubItems[14].Text;
					newRow["series"] = listViewNomenclature.Items[i].SubItems[15].Text;
					newRow["article"] = listViewNomenclature.Items[i].SubItems[16].Text;
					newRow["counteragentName"] = listViewNomenclature.Items[i].SubItems[17].Text;
					newRow["counteragentPricelist"] = listViewNomenclature.Items[i].SubItems[18].Text;
					newRow["docPurchasePlan"] = "";
					newRow["docOrder"] = docNumber;
					sqlServer.dataSet.Tables["OrderNomenclature"].Rows.Add(newRow);
				}
				
				sqlServer.sqlCommandInsert.CommandText = "INSERT INTO OrderNomenclature (" +
					"nomenclatureID, nomenclatureName, units, amount, " +
					"name, price, manufacturer, remainder, term, discount1, discount2, discount3, discount4, code, series, article, " +
					"counteragentName, counteragentPricelist, " +
					"docPurchasePlan, docOrder " + 
					") VALUES (" +
					"@nomenclatureID, @nomenclatureName, @units, @amount, " +
					"@name, @price, @manufacturer, @remainder, @term, @discount1, @discount2, @discount3, @discount4, @code, @series, @article, " +
					"@counteragentName, @counteragentPricelist, " +
					"@docPurchasePlan, @docOrder " + 
					")";
				sqlServer.sqlCommandInsert.Parameters.Add("@nomenclatureID", SqlDbType.Int, 10, "nomenclatureID");
				sqlServer.sqlCommandInsert.Parameters.Add("@nomenclatureName", SqlDbType.VarChar, 255, "nomenclatureName");
				sqlServer.sqlCommandInsert.Parameters.Add("@units", SqlDbType.VarChar, 255, "units");
				sqlServer.sqlCommandInsert.Parameters.Add("@amount", SqlDbType.Float, 15, "amount");
				sqlServer.sqlCommandInsert.Parameters.Add("@name", SqlDbType.VarChar, 255, "name");
				sqlServer.sqlCommandInsert.Parameters.Add("@price", SqlDbType.Float, 15, "price");
				sqlServer.sqlCommandInsert.Parameters.Add("@manufacturer", SqlDbType.VarChar, 255, "manufacturer");
				sqlServer.sqlCommandInsert.Parameters.Add("@remainder", SqlDbType.Float, 15, "remainder");
				sqlServer.sqlCommandInsert.Parameters.Add("@term", SqlDbType.Date, 15, "term");
				sqlServer.sqlCommandInsert.Parameters.Add("@discount1", SqlDbType.Float, 15, "discount1");
				sqlServer.sqlCommandInsert.Parameters.Add("@discount2", SqlDbType.Float, 15, "discount2");
				sqlServer.sqlCommandInsert.Parameters.Add("@discount3", SqlDbType.Float, 15, "discount3");
				sqlServer.sqlCommandInsert.Parameters.Add("@discount4", SqlDbType.Float, 15, "discount4");
				sqlServer.sqlCommandInsert.Parameters.Add("@code", SqlDbType.VarChar, 255, "code");
				sqlServer.sqlCommandInsert.Parameters.Add("@series", SqlDbType.VarChar, 255, "series");
				sqlServer.sqlCommandInsert.Parameters.Add("@article", SqlDbType.VarChar, 255, "article");
				sqlServer.sqlCommandInsert.Parameters.Add("@counteragentName", SqlDbType.VarChar, 255, "counteragentName");
				sqlServer.sqlCommandInsert.Parameters.Add("@counteragentPricelist", SqlDbType.VarChar, 255, "counteragentPricelist");
				sqlServer.sqlCommandInsert.Parameters.Add("@docPurchasePlan", SqlDbType.VarChar, 255, "docPurchasePlan");
				sqlServer.sqlCommandInsert.Parameters.Add("@docOrder", SqlDbType.VarChar, 255, "docOrder");
				if(sqlServer.ExecuteUpdate("OrderNomenclature")){
					return true;
				}else{
					return false;
				}
				
			}
			return false;
		}
		
		void open()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				// OLEDB
				oleDb = new OleDb(DataConfig.localDatabase);
				oleDb.oleDbCommandSelect.CommandText = "SELECT id, docDate, docNumber, docName, docCounteragent, docAutor, docSum, docVat, docTotal, docPurchasePlan FROM Orders WHERE (id = " + ID + ")";
				if(oleDb.ExecuteFill("Orders")){
					docNumber = oleDb.dataSet.Tables["Orders"].Rows[0]["docNumber"].ToString();
					docNumberTextBox.Text = docNumber;
					dateTimePicker1.Value = (DateTime)oleDb.dataSet.Tables["Orders"].Rows[0]["docDate"];
					autorLabel.Text = "Автор: " + oleDb.dataSet.Tables["Orders"].Rows[0]["docAutor"].ToString();
					counteragentTextBox.Text = oleDb.dataSet.Tables["Orders"].Rows[0]["docCounteragent"].ToString();
					sumTextBox.Text = oleDb.dataSet.Tables["Orders"].Rows[0]["docSum"].ToString();
					vatTextBox.Text = oleDb.dataSet.Tables["Orders"].Rows[0]["docVat"].ToString();
					totalTextBox.Text = oleDb.dataSet.Tables["Orders"].Rows[0]["docTotal"].ToString();
					openOrderNomenclature();
					calculate();
				}else{
					Utilits.Console.Log("[ОШИБКА] программа не смогла открыть документ заказ.", false, true);
				}
				
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				sqlServer= new SqlServer();
				sqlServer.sqlCommandSelect.CommandText = "SELECT id, docDate, docNumber, docName, docCounteragent, docAutor, docSum, docVat, docTotal, docPurchasePlan FROM Orders WHERE (id = " + ID + ")";
				if(sqlServer.ExecuteFill("Orders")){
					docNumber = sqlServer.dataSet.Tables["Orders"].Rows[0]["docNumber"].ToString();
					docNumberTextBox.Text = docNumber;
					dateTimePicker1.Value = (DateTime)sqlServer.dataSet.Tables["Orders"].Rows[0]["docDate"];
					autorLabel.Text = "Автор: " + sqlServer.dataSet.Tables["Orders"].Rows[0]["docAutor"].ToString();
					counteragentTextBox.Text = sqlServer.dataSet.Tables["Orders"].Rows[0]["docCounteragent"].ToString();
					sumTextBox.Text = sqlServer.dataSet.Tables["Orders"].Rows[0]["docSum"].ToString();
					vatTextBox.Text = sqlServer.dataSet.Tables["Orders"].Rows[0]["docVat"].ToString();
					totalTextBox.Text = sqlServer.dataSet.Tables["Orders"].Rows[0]["docTotal"].ToString();
					openOrderNomenclature();
					calculate();
				}else{
					Utilits.Console.Log("[ОШИБКА] программа не смогла открыть документ заказ.", false, true);
				}
			}
		}
		
		void openOrderNomenclature()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL) {
				// OLEDB
				oleDb = new OleDb(DataConfig.localDatabase);
				oleDb.oleDbCommandSelect.CommandText = "SELECT " +
					"id, nomenclatureID, nomenclatureName, units, amount, " +
					"name, price, manufacturer, remainder, term, discount1, discount2, discount3, discount4, code, series, article, " +
					"counteragentName, counteragentPricelist, " +
					"docPurchasePlan, docOrder " +
					"FROM OrderNomenclature WHERE (docOrder = '" + docNumber + "')";
				if(oleDb.ExecuteFill("OrderNomenclature")){
					DateTime dt;
					ListViewItem ListViewItem_add;
					foreach(DataRow row in oleDb.dataSet.Tables["OrderNomenclature"].Rows){
						ListViewItem_add = new ListViewItem();
						ListViewItem_add.SubItems.Add(row["name"].ToString());
						ListViewItem_add.StateImageIndex = 0;
						ListViewItem_add.SubItems.Add(row["units"].ToString());
						ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(row["amount"].ToString()).ToString()));
						ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(row["price"].ToString()).ToString()));
						ListViewItem_add.SubItems.Add("0,00");
						ListViewItem_add.SubItems.Add("0,00");
						ListViewItem_add.SubItems.Add(row["manufacturer"].ToString());
						ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(row["remainder"].ToString()).ToString()));
						dt = new DateTime();
						DateTime.TryParse(row["term"].ToString(), out dt);
						ListViewItem_add.SubItems.Add(dt.ToString("dd.MM.yyyy"));
						ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(row["discount1"].ToString()).ToString()));
						ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(row["discount2"].ToString()).ToString()));
						ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(row["discount3"].ToString()).ToString()));
						ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(row["discount4"].ToString()).ToString()));
						ListViewItem_add.SubItems.Add(row["code"].ToString());
						ListViewItem_add.SubItems.Add(row["series"].ToString());
						ListViewItem_add.SubItems.Add(row["article"].ToString());
						ListViewItem_add.SubItems.Add(row["counteragentName"].ToString());
						ListViewItem_add.SubItems.Add(row["counteragentPricelist"].ToString());
						ListViewItem_add.SubItems.Add(row["id"].ToString());
						listViewNomenclature.Items.Add(ListViewItem_add);
					}
				}else{
					Utilits.Console.Log("[ПРЕДУПРЕЖДЕНИЕ] программа не смогла загрузить перечень номенклатуры из документа план закупок №" + docNumber, false, true);
				}
				
			} else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				sqlServer = new SqlServer();
				sqlServer.sqlCommandSelect.CommandText = "SELECT " +
					"id, nomenclatureID, nomenclatureName, units, amount, " +
					"name, price, manufacturer, remainder, term, discount1, discount2, discount3, discount4, code, series, article, " +
					"counteragentName, counteragentPricelist, " +
					"docPurchasePlan, docOrder " +
					"FROM OrderNomenclature WHERE (docOrder = '" + docNumber + "')";
				if(sqlServer.ExecuteFill("OrderNomenclature")){
					DateTime dt;
					ListViewItem ListViewItem_add;
					foreach(DataRow row in sqlServer.dataSet.Tables["OrderNomenclature"].Rows){
						ListViewItem_add = new ListViewItem();
						ListViewItem_add.SubItems.Add(row["name"].ToString());
						ListViewItem_add.StateImageIndex = 0;
						ListViewItem_add.SubItems.Add(row["units"].ToString());
						ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(row["amount"].ToString()).ToString()));
						ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(row["price"].ToString()).ToString()));
						ListViewItem_add.SubItems.Add("0,00");
						ListViewItem_add.SubItems.Add("0,00");
						ListViewItem_add.SubItems.Add(row["manufacturer"].ToString());
						ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(row["remainder"].ToString()).ToString()));
						dt = new DateTime();
						DateTime.TryParse(row["term"].ToString(), out dt);
						ListViewItem_add.SubItems.Add(dt.ToString("dd.MM.yyyy"));
						ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(row["discount1"].ToString()).ToString()));
						ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(row["discount2"].ToString()).ToString()));
						ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(row["discount3"].ToString()).ToString()));
						ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(row["discount4"].ToString()).ToString()));
						ListViewItem_add.SubItems.Add(row["code"].ToString());
						ListViewItem_add.SubItems.Add(row["series"].ToString());
						ListViewItem_add.SubItems.Add(row["article"].ToString());
						ListViewItem_add.SubItems.Add(row["counteragentName"].ToString());
						ListViewItem_add.SubItems.Add(row["counteragentPricelist"].ToString());
						ListViewItem_add.SubItems.Add(row["id"].ToString());
						listViewNomenclature.Items.Add(ListViewItem_add);
					}
				}else{
					Utilits.Console.Log("[ПРЕДУПРЕЖДЕНИЕ] программа не смогла загрузить перечень номенклатуры из документа план закупок №" + docNumber, false, true);
				}
			}
		}
		
		bool saveEdit()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				// OLEDB
				oleDb = new OleDb(DataConfig.localDatabase);
				oleDb.oleDbCommandSelect.CommandText = "SELECT id, docDate, docNumber, docName, docCounteragent, docAutor, docSum, docVat, docTotal, docPurchasePlan FROM Orders WHERE (id = " + ID + ")";
				if(oleDb.ExecuteFill("Orders")){
					
					oleDb.dataSet.Tables["Orders"].Rows[0]["docDate"] = dateTimePicker1.Value;
					oleDb.dataSet.Tables["Orders"].Rows[0]["docCounteragent"] = counteragentTextBox.Text;
					oleDb.dataSet.Tables["Orders"].Rows[0]["docAutor"] = DataConfig.userName;
					oleDb.dataSet.Tables["Orders"].Rows[0]["docSum"] = sumTextBox.Text;
					oleDb.dataSet.Tables["Orders"].Rows[0]["docVat"] = vatTextBox.Text;
					oleDb.dataSet.Tables["Orders"].Rows[0]["docTotal"] = totalTextBox.Text;
					
					oleDb.oleDbCommandUpdate.CommandText = "UPDATE Orders SET " +
						"[docDate] = @docDate, [docNumber] = @docNumber, [docName] = @docName, " +
						"[docCounteragent] = @docCounteragent, [docAutor] = @docAutor, " +
						"[docSum] = @docSum, [docVat] = @docVat, [docTotal] = @docTotal, " +
						"[docPurchasePlan] = @docPurchasePlan " +
						"WHERE ([id] = @id)";
					oleDb.oleDbCommandUpdate.Parameters.Add("@docDate", OleDbType.Date, 255, "docDate");
					oleDb.oleDbCommandUpdate.Parameters.Add("@docNumber", OleDbType.VarChar, 255, "docNumber");
					oleDb.oleDbCommandUpdate.Parameters.Add("@docName", OleDbType.VarChar, 255, "docName");
					oleDb.oleDbCommandUpdate.Parameters.Add("@docCounteragent", OleDbType.VarChar, 255, "docCounteragent");
					oleDb.oleDbCommandUpdate.Parameters.Add("@docAutor", OleDbType.VarChar, 255, "docAutor");
					oleDb.oleDbCommandUpdate.Parameters.Add("@docSum", OleDbType.Double, 15, "docSum");
					oleDb.oleDbCommandUpdate.Parameters.Add("@docVat", OleDbType.Double, 15, "docVat");
					oleDb.oleDbCommandUpdate.Parameters.Add("@docTotal", OleDbType.Double, 15, "docTotal");
					oleDb.oleDbCommandUpdate.Parameters.Add("@docPurchasePlan", OleDbType.VarChar, 255, "docPurchasePlan");
					oleDb.oleDbCommandUpdate.Parameters.Add("@id", OleDbType.Integer, 10, "id");
					
					if(oleDb.ExecuteUpdate("Orders")){
						return true;
					}else{
						Utilits.Console.Log("[ОШИБКА] программа не смогла сохранить основные данные документа Заказ №" + docNumber, false, true);
					}
				}else{
					Utilits.Console.Log("[ОШИБКА] программа не смогла загрузить данные документа Заказ №" + docNumber, false, true);
				}	
								
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				sqlServer = new SqlServer();
				sqlServer.sqlCommandSelect.CommandText = "SELECT id, docDate, docNumber, docName, docCounteragent, docAutor, docSum, docVat, docTotal, docPurchasePlan FROM Orders WHERE (id = " + ID + ")";
				if(sqlServer.ExecuteFill("Orders")){
					
					sqlServer.dataSet.Tables["Orders"].Rows[0]["docDate"] = dateTimePicker1.Value;
					sqlServer.dataSet.Tables["Orders"].Rows[0]["docCounteragent"] = counteragentTextBox.Text;
					sqlServer.dataSet.Tables["Orders"].Rows[0]["docAutor"] = DataConfig.userName;
					sqlServer.dataSet.Tables["Orders"].Rows[0]["docSum"] = sumTextBox.Text;
					sqlServer.dataSet.Tables["Orders"].Rows[0]["docVat"] = vatTextBox.Text;
					sqlServer.dataSet.Tables["Orders"].Rows[0]["docTotal"] = totalTextBox.Text;
					
					sqlServer.sqlCommandUpdate.CommandText = "UPDATE Orders SET " +
						"[docDate] = @docDate, [docNumber] = @docNumber, [docName] = @docName, " +
						"[docCounteragent] = @docCounteragent, [docAutor] = @docAutor, " +
						"[docSum] = @docSum, [docVat] = @docVat, [docTotal] = @docTotal, " +
						"[docPurchasePlan] = @docPurchasePlan " +
						"WHERE ([id] = @id)";
					sqlServer.sqlCommandUpdate.Parameters.Add("@docDate", SqlDbType.Date, 255, "docDate");
					sqlServer.sqlCommandUpdate.Parameters.Add("@docNumber", SqlDbType.VarChar, 255, "docNumber");
					sqlServer.sqlCommandUpdate.Parameters.Add("@docName", SqlDbType.VarChar, 255, "docName");
					sqlServer.sqlCommandUpdate.Parameters.Add("@docCounteragent", SqlDbType.VarChar, 255, "docCounteragent");
					sqlServer.sqlCommandUpdate.Parameters.Add("@docAutor", SqlDbType.VarChar, 255, "docAutor");
					sqlServer.sqlCommandUpdate.Parameters.Add("@docSum", SqlDbType.Float, 15, "docSum");
					sqlServer.sqlCommandUpdate.Parameters.Add("@docVat", SqlDbType.Float, 15, "docVat");
					sqlServer.sqlCommandUpdate.Parameters.Add("@docTotal", SqlDbType.Float, 15, "docTotal");
					sqlServer.sqlCommandUpdate.Parameters.Add("@docPurchasePlan", SqlDbType.VarChar, 255, "docPurchasePlan");
					sqlServer.sqlCommandUpdate.Parameters.Add("@id", SqlDbType.Int, 10, "id");
					
					if(sqlServer.ExecuteUpdate("Orders")){
						return true;
					}else{
						Utilits.Console.Log("[ОШИБКА] программа не смогла сохранить основные данные документа Заказ №" + docNumber, false, true);
					}
				}else{
					Utilits.Console.Log("[ОШИБКА] программа не смогла загрузить данные документа Заказ №" + docNumber, false, true);
				}
				
			}
			return false;
		}
		
		bool saveEditOrderNomenclature()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL) {
				// OLEDB
				oleDb = new OleDb(DataConfig.localDatabase);
				oleDb.oleDbCommandSelect.CommandText = "SELECT " +
					"id, nomenclatureID, nomenclatureName, units, amount, " +
					"name, price, manufacturer, remainder, term, discount1, discount2, discount3, discount4, code, series, article, " +
					"counteragentName, counteragentPricelist, " +
					"docPurchasePlan, docOrder " +
					"FROM OrderNomenclature WHERE (docOrder = '" + docNumber + "')";
				oleDb.ExecuteFill("OrderNomenclature");
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO OrderNomenclature (" +
					"nomenclatureID, nomenclatureName, units, amount, " +
					"name, price, manufacturer, remainder, term, discount1, discount2, discount3, discount4, code, series, article, " +
					"counteragentName, counteragentPricelist, " +
					"docPurchasePlan, docOrder " + 
					") VALUES (" +
					"@nomenclatureID, @nomenclatureName, @units, @amount, " +
					"@name, @price, @manufacturer, @remainder, @term, @discount1, @discount2, @discount3, @discount4, @code, @series, @article, " +
					"@counteragentName, @counteragentPricelist, " +
					"@docPurchasePlan, @docOrder " + 
					")";
				oleDb.oleDbCommandInsert.Parameters.Add("@nomenclatureID", OleDbType.Integer, 10, "nomenclatureID");
				oleDb.oleDbCommandInsert.Parameters.Add("@nomenclatureName", OleDbType.VarChar, 255, "nomenclatureName");
				oleDb.oleDbCommandInsert.Parameters.Add("@units", OleDbType.VarChar, 255, "units");
				oleDb.oleDbCommandInsert.Parameters.Add("@amount", OleDbType.Double, 15, "amount");
				oleDb.oleDbCommandInsert.Parameters.Add("@name", OleDbType.VarChar, 255, "name");
				oleDb.oleDbCommandInsert.Parameters.Add("@price", OleDbType.Double, 15, "price");
				oleDb.oleDbCommandInsert.Parameters.Add("@manufacturer", OleDbType.VarChar, 255, "manufacturer");
				oleDb.oleDbCommandInsert.Parameters.Add("@remainder", OleDbType.Double, 15, "remainder");
				oleDb.oleDbCommandInsert.Parameters.Add("@term", OleDbType.Date, 15, "term");
				oleDb.oleDbCommandInsert.Parameters.Add("@discount1", OleDbType.Double, 15, "discount1");
				oleDb.oleDbCommandInsert.Parameters.Add("@discount2", OleDbType.Double, 15, "discount2");
				oleDb.oleDbCommandInsert.Parameters.Add("@discount3", OleDbType.Double, 15, "discount3");
				oleDb.oleDbCommandInsert.Parameters.Add("@discount4", OleDbType.Double, 15, "discount4");
				oleDb.oleDbCommandInsert.Parameters.Add("@code", OleDbType.VarChar, 255, "code");
				oleDb.oleDbCommandInsert.Parameters.Add("@series", OleDbType.VarChar, 255, "series");
				oleDb.oleDbCommandInsert.Parameters.Add("@article", OleDbType.VarChar, 255, "article");
				oleDb.oleDbCommandInsert.Parameters.Add("@counteragentName", OleDbType.VarChar, 255, "counteragentName");
				oleDb.oleDbCommandInsert.Parameters.Add("@counteragentPricelist", OleDbType.VarChar, 255, "counteragentPricelist");
				oleDb.oleDbCommandInsert.Parameters.Add("@docPurchasePlan", OleDbType.VarChar, 255, "docPurchasePlan");
				oleDb.oleDbCommandInsert.Parameters.Add("@docOrder", OleDbType.VarChar, 255, "docOrder");
				
				oleDb.oleDbCommandUpdate.CommandText = "UPDATE OrderNomenclature SET " +
					"nomenclatureID = @nomenclatureID, nomenclatureName = @nomenclatureName, units = @units, amount = @amount, " +
					"name = @name, price = @price, manufacturer = @manufacturer, remainder = @remainder, term = @term, " +
					"discount1 = @discount1, discount2 = @discount2, discount3 = @discount3, discount4 = @discount4, " +
					"code = @code, series = @series, article = @article, " +
					"counteragentName = @counteragentName, counteragentPricelist = @counteragentPricelist, " +
					"docPurchasePlan = @docPurchasePlan, docOrder = @docOrder " +
					"WHERE ([id] = @id)";
				oleDb.oleDbCommandUpdate.Parameters.Add("@nomenclatureID", OleDbType.Integer, 10, "nomenclatureID");
				oleDb.oleDbCommandUpdate.Parameters.Add("@nomenclatureName", OleDbType.VarChar, 255, "nomenclatureName");
				oleDb.oleDbCommandUpdate.Parameters.Add("@units", OleDbType.VarChar, 255, "units");
				oleDb.oleDbCommandUpdate.Parameters.Add("@amount", OleDbType.Double, 15, "amount");
				oleDb.oleDbCommandUpdate.Parameters.Add("@name", OleDbType.VarChar, 255, "name");
				oleDb.oleDbCommandUpdate.Parameters.Add("@price", OleDbType.Double, 15, "price");
				oleDb.oleDbCommandUpdate.Parameters.Add("@manufacturer", OleDbType.VarChar, 255, "manufacturer");
				oleDb.oleDbCommandUpdate.Parameters.Add("@remainder", OleDbType.Double, 15, "remainder");
				oleDb.oleDbCommandUpdate.Parameters.Add("@term", OleDbType.Date, 15, "term");
				oleDb.oleDbCommandUpdate.Parameters.Add("@discount1", OleDbType.Double, 15, "discount1");
				oleDb.oleDbCommandUpdate.Parameters.Add("@discount2", OleDbType.Double, 15, "discount2");
				oleDb.oleDbCommandUpdate.Parameters.Add("@discount3", OleDbType.Double, 15, "discount3");
				oleDb.oleDbCommandUpdate.Parameters.Add("@discount4", OleDbType.Double, 15, "discount4");
				oleDb.oleDbCommandUpdate.Parameters.Add("@code", OleDbType.VarChar, 255, "code");
				oleDb.oleDbCommandUpdate.Parameters.Add("@series", OleDbType.VarChar, 255, "series");
				oleDb.oleDbCommandUpdate.Parameters.Add("@article", OleDbType.VarChar, 255, "article");
				oleDb.oleDbCommandUpdate.Parameters.Add("@counteragentName", OleDbType.VarChar, 255, "counteragentName");
				oleDb.oleDbCommandUpdate.Parameters.Add("@counteragentPricelist", OleDbType.VarChar, 255, "counteragentPricelist");
				oleDb.oleDbCommandUpdate.Parameters.Add("@docPurchasePlan", OleDbType.VarChar, 255, "docPurchasePlan");
				oleDb.oleDbCommandUpdate.Parameters.Add("@docOrder", OleDbType.VarChar, 255, "docOrder");
				oleDb.oleDbCommandUpdate.Parameters.Add("@id", OleDbType.Integer, 10, "id");
				
				oleDb.oleDbCommandDelete.CommandText = "DELETE * FROM OrderNomenclature WHERE ([id] = @id)";
				oleDb.oleDbCommandDelete.Parameters.Add("@id", OleDbType.Integer, 10, "id").SourceVersion = DataRowVersion.Original;
								
				ListViewItem item;
				foreach(DataRow row in oleDb.dataSet.Tables["OrderNomenclature"].Rows){
					item = checkRemoveRow(row["id"].ToString());
					if(item == null){
						row.Delete();
					}else{
						row["nomenclatureID"] = 0;
						row["nomenclatureName"] = "";
						row["name"] = item.SubItems[1].Text;
						row["units"] = item.SubItems[2].Text;
						row["amount"] = Convert.ToDouble(item.SubItems[3].Text);
						row["price"] = Convert.ToDouble(item.SubItems[4].Text);
						row["manufacturer"] = item.SubItems[7].Text;
						row["remainder"] = Convert.ToDouble(item.SubItems[8].Text);
						row["term"] = item.SubItems[9].Text;
						row["discount1"] = Convert.ToDouble(item.SubItems[10].Text);
						row["discount2"] = Convert.ToDouble(item.SubItems[11].Text);
						row["discount3"] = Convert.ToDouble(item.SubItems[12].Text);
						row["discount4"] = Convert.ToDouble(item.SubItems[13].Text);
						row["code"] = item.SubItems[14].Text;
						row["series"] = item.SubItems[15].Text;
						row["article"] = item.SubItems[16].Text;
						row["counteragentName"] = item.SubItems[17].Text;
						row["counteragentPricelist"] = item.SubItems[18].Text;
						if(ParentDoc == null) row["docPurchasePlan"] = "";
						else row["docPurchasePlan"] = ParentDoc;
						row["docOrder"] = docNumber;
					}
				}
				
				DataRow newRow;
				foreach(ListViewItem itemLV in listViewNomenclature.Items){
					if(itemLV.SubItems[19].Text == ""){
						newRow = oleDb.dataSet.Tables["OrderNomenclature"].NewRow();
						newRow["nomenclatureID"] = 0;
						newRow["nomenclatureName"] = "";
						newRow["name"] = itemLV.SubItems[1].Text;
						newRow["units"] = itemLV.SubItems[2].Text;
						newRow["amount"] = Convert.ToDouble(itemLV.SubItems[3].Text);
						newRow["price"] = Convert.ToDouble(itemLV.SubItems[4].Text);
						newRow["manufacturer"] = itemLV.SubItems[7].Text;
						newRow["remainder"] = Convert.ToDouble(itemLV.SubItems[8].Text);
						newRow["term"] = itemLV.SubItems[9].Text;
						newRow["discount1"] = Convert.ToDouble(itemLV.SubItems[10].Text);
						newRow["discount2"] = Convert.ToDouble(itemLV.SubItems[11].Text);
						newRow["discount3"] = Convert.ToDouble(itemLV.SubItems[12].Text);
						newRow["discount4"] = Convert.ToDouble(itemLV.SubItems[13].Text);
						newRow["code"] = itemLV.SubItems[14].Text;
						newRow["series"] = itemLV.SubItems[15].Text;
						newRow["article"] = itemLV.SubItems[16].Text;
						newRow["counteragentName"] = itemLV.SubItems[17].Text;
						newRow["counteragentPricelist"] = itemLV.SubItems[18].Text;
						newRow["docPurchasePlan"] = "";
						newRow["docOrder"] = docNumber;
						oleDb.dataSet.Tables["OrderNomenclature"].Rows.Add(newRow);
					}
				}
				
				if(oleDb.ExecuteUpdate("OrderNomenclature")){
					return true;
				}else{
					return false;
				}
				
			} else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				sqlServer = new SqlServer();
				sqlServer.sqlCommandSelect.CommandText = "SELECT " +
					"id, nomenclatureID, nomenclatureName, units, amount, " +
					"name, price, manufacturer, remainder, term, discount1, discount2, discount3, discount4, code, series, article, " +
					"counteragentName, counteragentPricelist, " +
					"docPurchasePlan, docOrder " +
					"FROM OrderNomenclature WHERE (docOrder = '" + docNumber + "')";
				sqlServer.ExecuteFill("OrderNomenclature");
				
				sqlServer.sqlCommandInsert.CommandText = "INSERT INTO OrderNomenclature (" +
					"nomenclatureID, nomenclatureName, units, amount, " +
					"name, price, manufacturer, remainder, term, discount1, discount2, discount3, discount4, code, series, article, " +
					"counteragentName, counteragentPricelist, " +
					"docPurchasePlan, docOrder " + 
					") VALUES (" +
					"@nomenclatureID, @nomenclatureName, @units, @amount, " +
					"@name, @price, @manufacturer, @remainder, @term, @discount1, @discount2, @discount3, @discount4, @code, @series, @article, " +
					"@counteragentName, @counteragentPricelist, " +
					"@docPurchasePlan, @docOrder " + 
					")";
				sqlServer.sqlCommandInsert.Parameters.Add("@nomenclatureID", SqlDbType.Int, 10, "nomenclatureID");
				sqlServer.sqlCommandInsert.Parameters.Add("@nomenclatureName", SqlDbType.VarChar, 255, "nomenclatureName");
				sqlServer.sqlCommandInsert.Parameters.Add("@units", SqlDbType.VarChar, 255, "units");
				sqlServer.sqlCommandInsert.Parameters.Add("@amount", SqlDbType.Float, 15, "amount");
				sqlServer.sqlCommandInsert.Parameters.Add("@name", SqlDbType.VarChar, 255, "name");
				sqlServer.sqlCommandInsert.Parameters.Add("@price", SqlDbType.Float, 15, "price");
				sqlServer.sqlCommandInsert.Parameters.Add("@manufacturer", SqlDbType.VarChar, 255, "manufacturer");
				sqlServer.sqlCommandInsert.Parameters.Add("@remainder", SqlDbType.Float, 15, "remainder");
				sqlServer.sqlCommandInsert.Parameters.Add("@term", SqlDbType.Date, 15, "term");
				sqlServer.sqlCommandInsert.Parameters.Add("@discount1", SqlDbType.Float, 15, "discount1");
				sqlServer.sqlCommandInsert.Parameters.Add("@discount2", SqlDbType.Float, 15, "discount2");
				sqlServer.sqlCommandInsert.Parameters.Add("@discount3", SqlDbType.Float, 15, "discount3");
				sqlServer.sqlCommandInsert.Parameters.Add("@discount4", SqlDbType.Float, 15, "discount4");
				sqlServer.sqlCommandInsert.Parameters.Add("@code", SqlDbType.VarChar, 255, "code");
				sqlServer.sqlCommandInsert.Parameters.Add("@series", SqlDbType.VarChar, 255, "series");
				sqlServer.sqlCommandInsert.Parameters.Add("@article", SqlDbType.VarChar, 255, "article");
				sqlServer.sqlCommandInsert.Parameters.Add("@counteragentName", SqlDbType.VarChar, 255, "counteragentName");
				sqlServer.sqlCommandInsert.Parameters.Add("@counteragentPricelist", SqlDbType.VarChar, 255, "counteragentPricelist");
				sqlServer.sqlCommandInsert.Parameters.Add("@docPurchasePlan", SqlDbType.VarChar, 255, "docPurchasePlan");
				sqlServer.sqlCommandInsert.Parameters.Add("@docOrder", SqlDbType.VarChar, 255, "docOrder");
				
				sqlServer.sqlCommandUpdate.CommandText = "UPDATE OrderNomenclature SET " +
					"nomenclatureID = @nomenclatureID, nomenclatureName = @nomenclatureName, units = @units, amount = @amount, " +
					"name = @name, price = @price, manufacturer = @manufacturer, remainder = @remainder, term = @term, " +
					"discount1 = @discount1, discount2 = @discount2, discount3 = @discount3, discount4 = @discount4, " +
					"code = @code, series = @series, article = @article, " +
					"counteragentName = @counteragentName, counteragentPricelist = @counteragentPricelist, " +
					"docPurchasePlan = @docPurchasePlan, docOrder = @docOrder " +
					"WHERE ([id] = @id)";
				sqlServer.sqlCommandUpdate.Parameters.Add("@nomenclatureID", SqlDbType.Int, 10, "nomenclatureID");
				sqlServer.sqlCommandUpdate.Parameters.Add("@nomenclatureName", SqlDbType.VarChar, 255, "nomenclatureName");
				sqlServer.sqlCommandUpdate.Parameters.Add("@units", SqlDbType.VarChar, 255, "units");
				sqlServer.sqlCommandUpdate.Parameters.Add("@amount", SqlDbType.Float, 15, "amount");
				sqlServer.sqlCommandUpdate.Parameters.Add("@name", SqlDbType.VarChar, 255, "name");
				sqlServer.sqlCommandUpdate.Parameters.Add("@price", SqlDbType.Float, 15, "price");
				sqlServer.sqlCommandUpdate.Parameters.Add("@manufacturer", SqlDbType.VarChar, 255, "manufacturer");
				sqlServer.sqlCommandUpdate.Parameters.Add("@remainder", SqlDbType.Float, 15, "remainder");
				sqlServer.sqlCommandUpdate.Parameters.Add("@term", SqlDbType.Date, 15, "term");
				sqlServer.sqlCommandUpdate.Parameters.Add("@discount1", SqlDbType.Float, 15, "discount1");
				sqlServer.sqlCommandUpdate.Parameters.Add("@discount2", SqlDbType.Float, 15, "discount2");
				sqlServer.sqlCommandUpdate.Parameters.Add("@discount3", SqlDbType.Float, 15, "discount3");
				sqlServer.sqlCommandUpdate.Parameters.Add("@discount4", SqlDbType.Float, 15, "discount4");
				sqlServer.sqlCommandUpdate.Parameters.Add("@code", SqlDbType.VarChar, 255, "code");
				sqlServer.sqlCommandUpdate.Parameters.Add("@series", SqlDbType.VarChar, 255, "series");
				sqlServer.sqlCommandUpdate.Parameters.Add("@article", SqlDbType.VarChar, 255, "article");
				sqlServer.sqlCommandUpdate.Parameters.Add("@counteragentName", SqlDbType.VarChar, 255, "counteragentName");
				sqlServer.sqlCommandUpdate.Parameters.Add("@counteragentPricelist", SqlDbType.VarChar, 255, "counteragentPricelist");
				sqlServer.sqlCommandUpdate.Parameters.Add("@docPurchasePlan", SqlDbType.VarChar, 255, "docPurchasePlan");
				sqlServer.sqlCommandUpdate.Parameters.Add("@docOrder", SqlDbType.VarChar, 255, "docOrder");
				sqlServer.sqlCommandUpdate.Parameters.Add("@id", SqlDbType.Int, 10, "id");
				
				sqlServer.sqlCommandDelete.CommandText = "DELETE FROM OrderNomenclature WHERE ([id] = @id)";
				sqlServer.sqlCommandDelete.Parameters.Add("@id", SqlDbType.Int, 10, "id").SourceVersion = DataRowVersion.Original;
				
				ListViewItem item;
				foreach(DataRow row in sqlServer.dataSet.Tables["OrderNomenclature"].Rows){
					item = checkRemoveRow(row["id"].ToString());
					if(item == null){
						row.Delete();
					}else{
						row["nomenclatureID"] = 0;
						row["nomenclatureName"] = "";
						row["name"] = item.SubItems[1].Text;
						row["units"] = item.SubItems[2].Text;
						row["amount"] = Convert.ToDouble(item.SubItems[3].Text);
						row["price"] = Convert.ToDouble(item.SubItems[4].Text);
						row["manufacturer"] = item.SubItems[7].Text;
						row["remainder"] = Convert.ToDouble(item.SubItems[8].Text);
						row["term"] = item.SubItems[9].Text;
						row["discount1"] = Convert.ToDouble(item.SubItems[10].Text);
						row["discount2"] = Convert.ToDouble(item.SubItems[11].Text);
						row["discount3"] = Convert.ToDouble(item.SubItems[12].Text);
						row["discount4"] = Convert.ToDouble(item.SubItems[13].Text);
						row["code"] = item.SubItems[14].Text;
						row["series"] = item.SubItems[15].Text;
						row["article"] = item.SubItems[16].Text;
						row["counteragentName"] = item.SubItems[17].Text;
						row["counteragentPricelist"] = item.SubItems[18].Text;
						if(ParentDoc == null) row["docPurchasePlan"] = "";
						else row["docPurchasePlan"] = ParentDoc;
						row["docOrder"] = docNumber;
					}
				}
				
				DataRow newRow;
				foreach(ListViewItem itemLV in listViewNomenclature.Items){
					if(itemLV.SubItems[19].Text == ""){
						newRow = sqlServer.dataSet.Tables["OrderNomenclature"].NewRow();
						newRow["nomenclatureID"] = 0;
						newRow["nomenclatureName"] = "";
						newRow["name"] = itemLV.SubItems[1].Text;
						newRow["units"] = itemLV.SubItems[2].Text;
						newRow["amount"] = Convert.ToDouble(itemLV.SubItems[3].Text);
						newRow["price"] = Convert.ToDouble(itemLV.SubItems[4].Text);
						newRow["manufacturer"] = itemLV.SubItems[7].Text;
						newRow["remainder"] = Convert.ToDouble(itemLV.SubItems[8].Text);
						newRow["term"] = itemLV.SubItems[9].Text;
						newRow["discount1"] = Convert.ToDouble(itemLV.SubItems[10].Text);
						newRow["discount2"] = Convert.ToDouble(itemLV.SubItems[11].Text);
						newRow["discount3"] = Convert.ToDouble(itemLV.SubItems[12].Text);
						newRow["discount4"] = Convert.ToDouble(itemLV.SubItems[13].Text);
						newRow["code"] = itemLV.SubItems[14].Text;
						newRow["series"] = itemLV.SubItems[15].Text;
						newRow["article"] = itemLV.SubItems[16].Text;
						newRow["counteragentName"] = itemLV.SubItems[17].Text;
						newRow["counteragentPricelist"] = itemLV.SubItems[18].Text;
						newRow["docPurchasePlan"] = "";
						newRow["docOrder"] = docNumber;
						sqlServer.dataSet.Tables["OrderNomenclature"].Rows.Add(newRow);
					}
				}
				
				if(sqlServer.ExecuteUpdate("OrderNomenclature")){
					return true;
				}else{
					return false;
				}
			}
			
			return false;
		}
		
		ListViewItem checkRemoveRow(String id)
		{
			int i = 0;
			int count = listViewNomenclature.Items.Count;
			for(i = 0; i < count; i++){
				if(id == listViewNomenclature.Items[i].SubItems[19].Text){
					return listViewNomenclature.Items[i];
				}
			}
			return null;
		}
		
		void tuneMail()
		{
			if(counteragentTextBox.Text != ""){
				
				if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
					// OLEDB
					OleDbConnection oleDbConnection;
					OleDbCommand oleDbCommand;
					OleDbDataReader oleDbDataReader;
					oleDbConnection = new OleDbConnection(DataConfig.oledbConnectLineBegin + DataConfig.localDatabase + DataConfig.oledbConnectLineEnd + DataConfig.oledbConnectPass);
					try{
						oleDbConnection.Open();
						oleDbCommand = new OleDbCommand("SELECT [id], [name], [organization_email], [excel_date] FROM Counteragents WHERE (name = '" + counteragentTextBox.Text + "')", oleDbConnection);
						oleDbDataReader = oleDbCommand.ExecuteReader();
						while(oleDbDataReader.Read()){
							mailtoTextBox.Text = oleDbDataReader["organization_email"].ToString();
							priceDate = oleDbDataReader["excel_date"].ToString();
						}
						oleDbDataReader.Close();
						oleDbConnection.Close();
					}catch(Exception ex){
						oleDbConnection.Close();
						Utilits.Console.Log("[ОШИБКА] " + ex.Message, false, true);
					}
				}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
					// MSSQL SERVER
					SqlConnection sqlConnection;
					SqlCommand sqlCommand;
					SqlDataReader sqlDataReader;
					sqlConnection = new SqlConnection(DataConfig.serverConnection);
					try{
						sqlConnection.Open();
						sqlCommand = new SqlCommand("SELECT [id], [name], [organization_email], [excel_date] FROM Counteragents WHERE (name = '" + counteragentTextBox.Text + "')", sqlConnection);
						sqlDataReader = sqlCommand.ExecuteReader();
						while(sqlDataReader.Read()) {
							mailtoTextBox.Text = sqlDataReader["organization_email"].ToString();
							priceDate = sqlDataReader["excel_date"].ToString();
						}
						sqlDataReader.Close();
						sqlConnection.Close();
					}catch(Exception ex){
						sqlConnection.Close();
						Utilits.Console.Log("[ОШИБКА] " + ex.Message, false, true);
					}
				}
			}else{
				mailtoTextBox.Text = "";
			}
			
			mailfromTextBox.Text = DataConstants.ConstFirmEmail;
			captionTextBox.Text = DataConstants.ConstFirmCaption;
			messageTextBox.Text = DataConstants.ConstFirmMessage;
			fileNameTextBox.Text = DataConstants.ConstFirmName + "-Заказ-" + docNumberTextBox.Text + ".xls";
			pathFileTextBox.Text = DataConfig.resource + "\\";
		}
		
		/* =================================================================================================
		 * РАЗДЕЛ: СОБЫТИЙ
		 * =================================================================================================
		 */	
		void FormOrderDocLoad(object sender, EventArgs e)
		{
			if(ID == null){
				Text = "Заказ: Создать";
				dateTimePicker1.Value = DateTime.Today.Date;
				autorLabel.Text = "Автор: " + DataConfig.userName;
			}else{
				Text = "Заказ: Изменить";
				open();
			}
			tuneMail();
			Utilits.Console.Log(Text);
		}
		void FormOrderDocFormClosed(object sender, FormClosedEventArgs e)
		{
			DataForms.FClient.messageInStatus("...");
			Utilits.Console.Log(Text + ": закрыт.");
			Dispose();
		}
		void Button1Click(object sender, EventArgs e)
		{
			if(listViewNomenclature.Items.Count > 0){
				MessageBox.Show("Вы не можите сменить контрагента пока не очистите таблицу номенклатуры.", "Сообщение");
				return;
			}
			
			if(ID != null && ParentDoc != null){
				MessageBox.Show("Вы не можите сменить контрагента по скольку" + Environment.NewLine + 
				                "данный Заказ привязан к документу План закупок №" + ParentDoc, "Сообщение");
				return;
			}
			
			if(DataForms.FCounteragents != null) DataForms.FCounteragents.Close();
			if(DataForms.FCounteragents == null) {
				DataForms.FCounteragents = new FormCounteragents();
				DataForms.FCounteragents.MdiParent = DataForms.FClient;
				DataForms.FCounteragents.TextBoxReturnValue = counteragentTextBox;
				DataForms.FCounteragents.TypeReturnValue = "name";
				DataForms.FCounteragents.ShowMenuReturnValue();
				DataForms.FCounteragents.Show();
			}
		}
		void Button2Click(object sender, EventArgs e)
		{
			counteragentTextBox.Clear();
			listViewClear();
		}
		void CounteragentTextBoxTextChanged(object sender, EventArgs e)
		{
			listViewClear();
		}
		void ButtonNomenclatureAddClick(object sender, EventArgs e)
		{
			FormOrderNomenclature FOrderNomenclature = new FormOrderNomenclature();
			FOrderNomenclature.MdiParent = DataForms.FClient;
			FOrderNomenclature.ListViewReturnValue = listViewNomenclature;
			FOrderNomenclature.Counteragent = counteragentTextBox.Text;
			FOrderNomenclature.loadNomenclature();
			FOrderNomenclature.Show();
		}
		void ButtonNomenclaturesAddClick(object sender, EventArgs e)
		{
			addAllNomenclatures();
		}
		void ButtonNomenclatureDeleteClick(object sender, EventArgs e)
		{
			if(listViewNomenclature.SelectedItems.Count > 0) listViewNomenclature.Items[listViewNomenclature.SelectedItems[0].Index].Remove();
			selectTableLine = -1;
			groupBox1.Text = "...";
			unitsTextBox.Clear();
			amountTextBox.Text = "0,00";
			priceTextBox.Text = "0,00";
			calculate();
		}
		void ButtonNomenclaturesDeleteClick(object sender, EventArgs e)
		{
			listViewClear();
			selectTableLine = -1;
			groupBox1.Text = "...";
			unitsTextBox.Clear();
			amountTextBox.Text = "0,00";
			priceTextBox.Text = "0,00";
			calculate();
		}
		void ComboBox1KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyData == Keys.Enter){
				if(comboBox1.Text != "") comboBox1.Items.Add(comboBox1.Text);
				search();
			}
		}
		void FindButtonClick(object sender, EventArgs e)
		{
			if(comboBox1.Text != "") comboBox1.Items.Add(comboBox1.Text);
			search();
		}
		void ListViewNomenclatureSelectedIndexChanged(object sender, EventArgs e)
		{
			if(listViewNomenclature.SelectedItems.Count > 0){
				selectTableLine = listViewNomenclature.SelectedItems[0].Index;
				groupBox1.Text = listViewNomenclature.Items[selectTableLine].SubItems[1].Text;
				if(groupBox1.Text.Length > 40) groupBox1.Text = groupBox1.Text.Remove(40) + "...";
				unitsTextBox.Text = listViewNomenclature.Items[selectTableLine].SubItems[2].Text;
				amountTextBox.Text = listViewNomenclature.Items[selectTableLine].SubItems[3].Text;
				priceTextBox.Text = listViewNomenclature.Items[selectTableLine].SubItems[4].Text;
			}
		}
		void UnitsTextBoxTextChanged(object sender, EventArgs e)
		{
			if(listViewNomenclature.Items.Count > 0 && selectTableLine > -1){
				listViewNomenclature.Items[selectTableLine].SubItems[2].Text = unitsTextBox.Text;
			}
		}
		void Button8Click(object sender, EventArgs e)
		{
			if(DataForms.FUnits != null) DataForms.FUnits.Close();
			if(DataForms.FUnits == null) {
				DataForms.FUnits = new FormUnits();
				DataForms.FUnits.MdiParent = DataForms.FClient;
				DataForms.FUnits.TextBoxReturnValue = unitsTextBox;
				DataForms.FUnits.ShowMenuReturnValue();
				DataForms.FUnits.Show();
			}
		}
		void Button9Click(object sender, EventArgs e)
		{
			unitsTextBox.Clear();
		}
		void AmountTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab){
				String Value = amountTextBox.Text;
				amountTextBox.Clear();
				amountTextBox.Text = Conversion.StringToMoney(Conversion.StringToDouble(Value).ToString());
				if(amountTextBox.Text == "" || Conversion.checkString(amountTextBox.Text) == false) amountTextBox.Text = "0,00";
				calculate();
			}
		}
		void AmountTextBoxTextChanged(object sender, EventArgs e)
		{
			if(amountTextBox.Text == "" || Conversion.checkString(amountTextBox.Text) == false) amountTextBox.Text = "0,00";
			if(listViewNomenclature.Items.Count > 0 && selectTableLine > -1){
				listViewNomenclature.Items[selectTableLine].SubItems[3].Text = amountTextBox.Text;
				calculate();
			}
		}
		void AmountTextBoxLostFocus(object sender, EventArgs e)
		{
			String Value = amountTextBox.Text;
			amountTextBox.Clear();
			amountTextBox.Text = Conversion.StringToMoney(Conversion.StringToDouble(Value).ToString());
			if(amountTextBox.Text == "" || Conversion.checkString(amountTextBox.Text) == false) amountTextBox.Text = "0,00";
			calculate();
		}
		void Button7Click(object sender, EventArgs e)
		{
			Calculator Calc = new Calculator();
			Calc.TextBoxReturnValue = amountTextBox;
			Calc.MdiParent = DataForms.FClient;
			Calc.Show();
		}
		void Button6Click(object sender, EventArgs e)
		{
			amountTextBox.Text = "0,00";
			calculate();
		}
		void PriceTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab){
				String Value = priceTextBox.Text;
				priceTextBox.Clear();
				priceTextBox.Text = Conversion.StringToMoney(Conversion.StringToDouble(Value).ToString());
				if(priceTextBox.Text == "" || Conversion.checkString(priceTextBox.Text) == false) priceTextBox.Text = "0,00";
				calculate();
			}
		}
		void PriceTextBoxTextChanged(object sender, EventArgs e)
		{
			if(priceTextBox.Text == "" || Conversion.checkString(priceTextBox.Text) == false) priceTextBox.Text = "0,00";
			if(listViewNomenclature.Items.Count > 0 && selectTableLine > -1){
				listViewNomenclature.Items[selectTableLine].SubItems[4].Text = priceTextBox.Text;
				calculate();
			}
		}
		void PriceTextBoxLostFocus(object sender, EventArgs e)
		{
			String Value = priceTextBox.Text;
			priceTextBox.Clear();
			priceTextBox.Text = Conversion.StringToMoney(Conversion.StringToDouble(Value).ToString());
			if(priceTextBox.Text == "" || Conversion.checkString(priceTextBox.Text) == false) priceTextBox.Text = "0,00";
			calculate();
		}
		void Button13Click(object sender, EventArgs e)
		{
			Calculator Calc = new Calculator();
			Calc.TextBoxReturnValue = priceTextBox;
			Calc.MdiParent = DataForms.FClient;
			Calc.Show();
		}
		void Button14Click(object sender, EventArgs e)
		{
			priceTextBox.Text = "0,00";
			calculate();
		}
		void ButtonCancelClick(object sender, EventArgs e)
		{
			Close();
		}
		void ButtonSaveClick(object sender, EventArgs e)
		{
			calculate();
			if(DataConfig.userPermissions == "guest"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			if(ID == null && ParentDoc == null){
				if(check()) saveNew();
			}else if(ID != null && ParentDoc == ""){
				if(check() == false) return;
				if(saveEdit() && saveEditOrderNomenclature()){
					DataForms.FClient.updateHistory("Orders");
					Utilits.Console.Log("Документ Заказ №" + docNumber + ": успешно изменён и сохранён.");
					Close();
				}else{
					Utilits.Console.Log("[ПРЕДУПРЕЖДЕНИЕ] Документ Заказ №" + docNumber + ": не удалось сохранить изменения.", false, true);
				}
			}else if(ID != null && ParentDoc != null && ParentDoc != "") {
				MessageBox.Show("Вы не можете сохранить изменения в документе Заказ №" + docNumber + Environment.NewLine +
				                "потому что он привязан к Плану закупок №" + ParentDoc + Environment.NewLine +
				                "Внесите изменения в План закуком и создайте Заказ на его основании.", "Сообщение");
				return;
			}
		}
		void FormOrderDocActivated(object sender, EventArgs e)
		{
			DataForms.FClient.messageInStatus(this.Text);
		}
		
		int printLine = 0;
		void PrintDocument1PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			int PosY = 0;
			if(printLine == 0){
				// Заголовок документа
				e.Graphics.DrawString("ЗАКАЗ № " + docNumberTextBox.Text + "   дата: " + dateTimePicker1.Text, new Font("Microsoft Sans Serif", 14, FontStyle.Regular), Brushes.Black, 20, PosY);
				// ШАПКА
				PosY += 60;
				e.Graphics.DrawString("Кому: " + counteragentTextBox.Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 5, PosY);
				PosY += 30;
				e.Graphics.DrawString("От кого: " + DataConstants.ConstFirmName, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 5, PosY);
				
				
				// ТАБЛИЧНАЯ ЧАСТЬ: Загрузка данных из таблицы
				PosY += 30;
				e.Graphics.DrawLine(new Pen(Color.Black), 0, PosY, 650, PosY);
				PosY += 15;
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(0, PosY, 400, 25));
				e.Graphics.DrawString("Наименование:", new Font("Microsoft Sans Serif", 10, FontStyle.Bold), Brushes.Black, 5, PosY);
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(405, PosY, 65, 25));
				e.Graphics.DrawString("Ед. изм:", new Font("Microsoft Sans Serif", 10, FontStyle.Bold), Brushes.Black, 410, PosY);
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(475, PosY, 65, 25));
				e.Graphics.DrawString("Кол-во:", new Font("Microsoft Sans Serif", 10, FontStyle.Bold), Brushes.Black, 480, PosY);
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(545, PosY, 100, 25));
				e.Graphics.DrawString("Цена:", new Font("Microsoft Sans Serif", 10, FontStyle.Bold), Brushes.Black, 550, PosY);
				PosY += 30;
				e.Graphics.DrawLine(new Pen(Color.Black), 0, PosY, 650, PosY);
				PosY += 30;
			}
			
			String textName;
			for(int i = printLine; i < listViewNomenclature.Items.Count; i++){
				//    Наименование
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(0, PosY, 400, 25));
				textName = listViewNomenclature.Items[i].SubItems[1].Text;
				if(textName.Length > 50) textName = textName.Substring(0, 50);
				e.Graphics.DrawString(textName, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 5, PosY);
				//    Ед. изм.
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(405, PosY, 65, 25));
				e.Graphics.DrawString(listViewNomenclature.Items[i].SubItems[2].Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 410, PosY);
				//    Количество.
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(475, PosY, 65, 25));
				e.Graphics.DrawString(listViewNomenclature.Items[i].SubItems[3].Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 480, PosY);
				//    Цена.
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(545, PosY, 100, 25));
				e.Graphics.DrawString(listViewNomenclature.Items[i].SubItems[4].Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 550, PosY);
				
				printLine++;
				PosY += 30;
				
				if(PosY >= 1000) {
					e.HasMorePages = true;
					return;
				}
			}
			
			if((PosY + 150) >= 1000) {
				e.HasMorePages = true;
				return;
			}
			PosY += 30;
			e.Graphics.DrawLine(new Pen(Color.Black), 0, PosY, 650, PosY);
			//	Сумма.
			PosY += 30;
			e.Graphics.FillRectangle(Brushes.White, new Rectangle(0, PosY, 250, 25));
			e.Graphics.DrawString("Сумма: " + sumTextBox.Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 0, PosY);
			//	НДС.
			PosY += 30;
			e.Graphics.FillRectangle(Brushes.White, new Rectangle(0, PosY, 250, 25));
			e.Graphics.DrawString("НДС: " + vatTextBox.Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 0, PosY);
			//	Всего.
			PosY += 30;
			e.Graphics.FillRectangle(Brushes.White, new Rectangle(0, PosY, 250, 25));
			e.Graphics.DrawString("Всего: " + totalTextBox.Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 0, PosY);
			
			
		}
		void ButtonPrintPreviewClick(object sender, EventArgs e)
		{
			printLine = 0;
			PrintPreviewDialog ppd = new PrintPreviewDialog();
			ppd.Document = printDocument1;
			ppd.MdiParent = DataForms.FClient;
			ppd.Show();
		}
		void ButtonPrintClick(object sender, EventArgs e)
		{
			printLine = 0;
			if(printDialog1.ShowDialog() == DialogResult.OK){
				printDialog1.Document.Print();
			}
		}
		void Button15Click(object sender, EventArgs e)
		{
			if(listViewNomenclature.Items.Count == 0) {
				MessageBox.Show("Таблица номенклатуры пустая, добавьте номенклатуру!", "Сообщение");
				return;
			}
			
			if(ID == null){
				MessageBox.Show("Чтобы отправить заказ по почте его необходимо сначала сохранить!", "Сообщение");
			}else{
				
				DataForms.FClient.messageInStatus("Пожалуйста подождите идет процесс отправки заказа по почте!");
				DataForms.FClient.Update();
				
				String fileName = pathFileTextBox.Text + fileNameTextBox.Text;
				
				int row = 0;
				int col = 0;
				
				Workbook workbook = new Workbook();
				
				try
				{
					Worksheet worksheet = new Worksheet("Заказ");
					
					/* ШАПКА */
					if(checkBox1.Checked){
						worksheet.Cells[row, 1] = new Cell("Поставщик:");
						worksheet.Cells[row, 2] = new Cell(counteragentTextBox.Text);
						row++;
					}
					if(checkBox2.Checked){
						worksheet.Cells[row, 1] = new Cell("Прайс лист от ");
						worksheet.Cells[row, 2] = new Cell(priceDate);
						row++;
					}
					if(checkBox3.Checked){
						worksheet.Cells[row, 1] = new Cell("Заказчик: ");
						worksheet.Cells[row, 2] = new Cell(DataConstants.ConstFirmName);
						row++;
					}
					if(checkBox4.Checked){
						worksheet.Cells[row, 2] = new Cell(DataConstants.ConstFirmAddress);
						row++;
					}
					if(checkBox5.Checked){
						worksheet.Cells[row, 2] = new Cell(DataConstants.ConstFirmEmail);
						row++;
					}
					
					/* ТАБЛИЦА */
					col = 0;
					row++;
					if(checkBox6.Checked){
						worksheet.Cells[row, col] = new Cell("№п/п:");
						col++;
					}
					if(checkBox7.Checked){
						worksheet.Cells[row, col] = new Cell("Код:");
						col++;
					}
					if(checkBox8.Checked){
						worksheet.Cells[row, col] = new Cell("Серия:");
						col++;
					}
					if(checkBox9.Checked){
						worksheet.Cells[row, col] = new Cell("Артикул:");
						col++;
					}
					if(checkBox10.Checked){
						worksheet.Cells[row, col] = new Cell("Наименование:");
						col++;
					}
					if(checkBox11.Checked){
						worksheet.Cells[row, col] = new Cell("Производитель:");
						col++;
					}
					if(checkBox12.Checked){
						worksheet.Cells[row, col] = new Cell("Ед.изм.:");
						col++;
					}
					if(checkBox13.Checked){
						worksheet.Cells[row, col] = new Cell("Срок годности:");
						col++;
					}
					if(checkBox14.Checked){
						worksheet.Cells[row, col] = new Cell("Остаток:");
						col++;
					}
					if(checkBox15.Checked){
						worksheet.Cells[row, col] = new Cell("Скидка №1:");
						col++;
						worksheet.Cells[row, col] = new Cell("Скидка №2:");
						col++;
						worksheet.Cells[row, col] = new Cell("Скидка №3:");
						col++;
						worksheet.Cells[row, col] = new Cell("Скидка №4:");
						col++;
					}
					if(checkBox16.Checked){
						worksheet.Cells[row, col] = new Cell("Цена:");
						col++;
					}
					if(checkBox17.Checked){
						worksheet.Cells[row, col] = new Cell("Заказ:");
						col++;
					}
					row++;
						
					int countRows = listViewNomenclature.Items.Count;
					int countColumns = col;
					for(int r = 0; r < countRows; r++){
						col = 0;
						if(checkBox6.Checked){
							worksheet.Cells[row, col] = new Cell(r);
							col++;
						}
						if(checkBox7.Checked){
							worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[14].Text);
							col++;
						}
						if(checkBox8.Checked){
							worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[15].Text);
							col++;
						}
						if(checkBox9.Checked){
							worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[16].Text);
							col++;
						}
						if(checkBox10.Checked){
							worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[1].Text);
							col++;
						}
						if(checkBox11.Checked){
							worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[7].Text);
							col++;
						}
						if(checkBox12.Checked){
							worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[2].Text);
							col++;
						}
						if(checkBox13.Checked){
							worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[9].Text);
							col++;
						}
						if(checkBox14.Checked){
							worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[8].Text);
							col++;
						}
						if(checkBox15.Checked){
							worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[10].Text);
							col++;
							worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[11].Text);
							col++;
							worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[12].Text);
							col++;
							worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[13].Text);
							col++;
						}
						if(checkBox16.Checked){
							worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[4].Text);
							col++;
						}
						if(checkBox17.Checked){
							worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[3].Text);
							col++;
						}
						row++;
		            }
					
					workbook.Worksheets.Add(worksheet);
		            workbook.Save(fileName);
	            } catch (Exception ex) {
					workbook = null;
					Utilits.Console.Log("[ОШИБКА] Создание файла заказа для отправки контрагенту: " + Environment.NewLine + ex.Message, false, true);
					DataForms.FClient.messageInStatus("Заказ не удалось отправить по почте!");
					DataForms.FClient.Update();
					return;
				}
				
				if(!File.Exists(fileName)){ 
					MessageBox.Show("Файл: " + fileName + " не найден!", "Сообщение");
					DataForms.FClient.messageInStatus("Заказ не удалось отправить по почте!");
					DataForms.FClient.Update();
	            	return;
	            }
	            
				SendMail mail = new SendMail();
				if(mail.Send(mailfromTextBox.Text, mailtoTextBox.Text, captionTextBox.Text, messageTextBox.Text, fileName)){
					MessageBox.Show("Заказ был успешно отправлен по почте!", "Сообщение");
					DataForms.FClient.messageInStatus("Заказ был успешно отправлен по почте!");
					DataForms.FClient.Update();
				}else{
					MessageBox.Show("Заказ не удалось отправить по почте!", "Сообщение");
					DataForms.FClient.messageInStatus("Заказ не удалось отправить по почте!");
					DataForms.FClient.Update();
				}
				
				if(File.Exists(fileName)) File.Delete(fileName);
			}
		}
		void ButtonSaveExcelClick(object sender, EventArgs e)
		{
			if(saveFileDialog1.ShowDialog() == DialogResult.OK){
				int row = 0;
				int col = 0;
				
				Workbook workbook = new Workbook();
				
				try
				{
					Worksheet worksheet = new Worksheet("Заказ");
					
					/* ШАПКА */
					worksheet.Cells[row, 1] = new Cell("Поставщик:");
					worksheet.Cells[row, 2] = new Cell(counteragentTextBox.Text);
					row++;
					worksheet.Cells[row, 1] = new Cell("Прайс лист от ");
					worksheet.Cells[row, 2] = new Cell(priceDate);
					row++;
					worksheet.Cells[row, 1] = new Cell("Заказчик: ");
					worksheet.Cells[row, 2] = new Cell(DataConstants.ConstFirmName);
					row++;
					worksheet.Cells[row, 2] = new Cell(DataConstants.ConstFirmAddress);
					row++;
					worksheet.Cells[row, 2] = new Cell(DataConstants.ConstFirmEmail);
					row++;
					
					/* ТАБЛИЦА */
					col = 0;
					row++;
					worksheet.Cells[row, col] = new Cell("№п/п:");
					col++;
					worksheet.Cells[row, col] = new Cell("Код:");
					col++;
					worksheet.Cells[row, col] = new Cell("Серия:");
					col++;
					worksheet.Cells[row, col] = new Cell("Артикул:");
					col++;
					worksheet.Cells[row, col] = new Cell("Наименование:");
					col++;
					worksheet.Cells[row, col] = new Cell("Производитель:");
					col++;
					worksheet.Cells[row, col] = new Cell("Ед.изм.:");
					col++;
					worksheet.Cells[row, col] = new Cell("Срок годности:");
					col++;
					worksheet.Cells[row, col] = new Cell("Остаток:");
					col++;
					worksheet.Cells[row, col] = new Cell("Скидка №1:");
					col++;
					worksheet.Cells[row, col] = new Cell("Скидка №2:");
					col++;
					worksheet.Cells[row, col] = new Cell("Скидка №3:");
					col++;
					worksheet.Cells[row, col] = new Cell("Скидка №4:");
					col++;
					worksheet.Cells[row, col] = new Cell("Цена:");
					col++;
					worksheet.Cells[row, col] = new Cell("Заказ:");
					col++;
					row++;
						
					int countRows = listViewNomenclature.Items.Count;
					int countColumns = col;
					for(int r = 0; r < countRows; r++){
						col = 0;
						worksheet.Cells[row, col] = new Cell(r);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[14].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[15].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[16].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[1].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[7].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[2].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[9].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[8].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[10].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[11].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[12].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[13].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[4].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[3].Text);
						col++;
						row++;
		            }
					
					workbook.Worksheets.Add(worksheet);
		            workbook.Save(saveFileDialog1.FileName);
	            } catch (Exception ex) {
					workbook = null;
					Utilits.Console.Log("[ОШИБКА] Создание excel файла заказ: " + Environment.NewLine + ex.Message, false, true);
					return;
				}
				
				if(!File.Exists(saveFileDialog1.FileName)){ 
					MessageBox.Show("Файл: " + saveFileDialog1.FileName + " не создан!", "Сообщение");
					return;
	            }
				
				MessageBox.Show("Файл сохранен!", "Сообщение");
			}
		}
		
		
	}
}
