/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 19.03.2017
 * Время: 10:27
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Aggregator.Client.Documents.Order;
using Aggregator.Data;
using Aggregator.Database.Local;
using Aggregator.Database.Server;
using Aggregator.Client.Directories;
using Aggregator.Utilits;
using ExcelLibrary.SpreadSheet;

namespace Aggregator.Client.Documents.PurchasePlan
{
	/// <summary>
	/// Description of FormPurchasePlanDoc.
	/// </summary>
	public partial class FormPurchasePlanDoc : Form
	{
		public FormPurchasePlanDoc()
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
		SearchNomenclatureOleDb searchNomenclatureOleDb;
		SqlServer sqlServer;
		SearchNomenclatureSqlServer searchNomenclatureSql;
		String docNumber;
		int selectTableLine = -1;		// выбранная строка в таблице
		
		String getDocNumber()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL) {
				// OLEDB
				OleDbConnection oleDbConnection = new OleDbConnection();
				oleDbConnection.ConnectionString = DataConfig.oledbConnectLineBegin + DataConfig.localDatabase + DataConfig.oledbConnectLineEnd + DataConfig.oledbConnectPass;
				try{
					
					OleDbCommand oleDbCommand = new OleDbCommand("SELECT MAX(id) FROM PurchasePlan", oleDbConnection);
					oleDbConnection.Open();
					var order_id = oleDbCommand.ExecuteScalar();
					oleDbConnection.Close();
					
					int num;
					if (order_id.ToString() == "") num = 1;
					else num = (int)order_id + 1;
					String idStr = num.ToString();
					String numStr = "ПЗ-0000000";
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
					SqlCommand sqlCommand = new SqlCommand("SELECT MAX(id) FROM PurchasePlan", sqlConnection);
					sqlConnection.Open();
					var order_id = sqlCommand.ExecuteScalar();
					sqlConnection.Close();
					
					int num;
					if (order_id.ToString() == "") num = 1;
					else num = (int)order_id + 1;
					String idStr = num.ToString();
					String numStr = "ПЗ-0000000";
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
		
		void editPrice()
		{
			if(listViewPrices.SelectedIndices.Count > 0){
				FormCounteragentPrice FCounteragentPrice = new FormCounteragentPrice();
				FCounteragentPrice.MdiParent = DataForms.FClient;
				FCounteragentPrice.Text = "Прайс-лист контрагента: " + listViewPrices.Items[listViewPrices.SelectedIndices[0]].SubItems[1].Text.ToString();
				FCounteragentPrice.PriceName = listViewPrices.Items[listViewPrices.SelectedIndices[0]].SubItems[2].Text.ToString();
				FCounteragentPrice.Show();
			}
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
				oleDb.oleDbCommandSelect.CommandText = "SELECT id, docDate, docNumber, docName, docAutor, docSum, docVat, docTotal FROM PurchasePlan WHERE (id = 0)";
				oleDb.ExecuteFill("PurchasePlan");				
				
				DataRow newRow = oleDb.dataSet.Tables["PurchasePlan"].NewRow();
				newRow["docDate"] = dateTimePicker1.Value;
				newRow["docNumber"] = docNumber;
				newRow["docName"] = "План закупок";
				newRow["docAutor"] = DataConfig.userName;
				newRow["docSum"] = textBox4.Text;
				newRow["docVat"] = textBox5.Text;
				newRow["docTotal"] = textBox6.Text;
				oleDb.dataSet.Tables["PurchasePlan"].Rows.Add(newRow);
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO PurchasePlan (docDate, docNumber, docName, docAutor, docSum, docVat, docTotal) " +
					"VALUES (@docDate, @docNumber, @docName, @docAutor, @docSum, @docVat, @docTotal)";
				oleDb.oleDbCommandInsert.Parameters.Add("@docDate", OleDbType.Date, 255, "docDate");
				oleDb.oleDbCommandInsert.Parameters.Add("@docNumber", OleDbType.VarChar, 255, "docNumber");
				oleDb.oleDbCommandInsert.Parameters.Add("@docName", OleDbType.VarChar, 255, "docName");
				oleDb.oleDbCommandInsert.Parameters.Add("@docAutor", OleDbType.VarChar, 255, "docAutor");
				oleDb.oleDbCommandInsert.Parameters.Add("@docSum", OleDbType.Double, 15, "docSum");
				oleDb.oleDbCommandInsert.Parameters.Add("@docVat", OleDbType.Double, 15, "docVat");
				oleDb.oleDbCommandInsert.Parameters.Add("@docTotal", OleDbType.Double, 15, "docTotal");
				if(oleDb.ExecuteUpdate("PurchasePlan")){
					DataForms.FClient.updateHistory("PurchasePlan");
					if(saveNewChangesPriceLists() == false){
						Utilits.Console.Log("[ПРЕДУПРЕЖДЕНИЕ] Документ План закупок №" + docNumber + ": не удалось сохранить список выбранных прайс листов.", false, true);
						return;
					}
					if(saveNewOrderNomenclature() == false){
						Utilits.Console.Log("[ПРЕДУПРЕЖДЕНИЕ] Документ План закупок №" + docNumber + ": не удалось сохранить список выбранной номенклатуры.", false, true);
						return;
					}
					Utilits.Console.Log("Документ План закупок №" + docNumber + ": успешно создан.");
					Close();
				}
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				sqlServer = new SqlServer();
				sqlServer.sqlCommandSelect.CommandText = "SELECT id, docDate, docNumber, docName, docAutor, docSum, docVat, docTotal FROM PurchasePlan WHERE (id = 0)";
				sqlServer.ExecuteFill("PurchasePlan");				
				
				DataRow newRow = sqlServer.dataSet.Tables["PurchasePlan"].NewRow();
				newRow["docDate"] = dateTimePicker1.Value;
				newRow["docNumber"] = docNumber;
				newRow["docName"] = "План закупок";
				newRow["docAutor"] = DataConfig.userName;
				newRow["docSum"] = textBox4.Text;
				newRow["docVat"] = textBox5.Text;
				newRow["docTotal"] = textBox6.Text;
				sqlServer.dataSet.Tables["PurchasePlan"].Rows.Add(newRow);
				
				sqlServer.sqlCommandInsert.CommandText = "INSERT INTO PurchasePlan (docDate, docNumber, docName, docAutor, docSum, docVat, docTotal) " +
					"VALUES (@docDate, @docNumber, @docName, @docAutor, @docSum, @docVat, @docTotal)";
				sqlServer.sqlCommandInsert.Parameters.Add("@docDate", SqlDbType.Date, 255, "docDate");
				sqlServer.sqlCommandInsert.Parameters.Add("@docNumber", SqlDbType.VarChar, 255, "docNumber");
				sqlServer.sqlCommandInsert.Parameters.Add("@docName", SqlDbType.VarChar, 255, "docName");
				sqlServer.sqlCommandInsert.Parameters.Add("@docAutor", SqlDbType.VarChar, 255, "docAutor");
				sqlServer.sqlCommandInsert.Parameters.Add("@docSum", SqlDbType.Float, 15, "docSum");
				sqlServer.sqlCommandInsert.Parameters.Add("@docVat", SqlDbType.Float, 15, "docVat");
				sqlServer.sqlCommandInsert.Parameters.Add("@docTotal", SqlDbType.Float, 15, "docTotal");
				if(sqlServer.ExecuteUpdate("PurchasePlan")){
					DataForms.FClient.updateHistory("PurchasePlan");
					if(saveNewChangesPriceLists() == false){
						Utilits.Console.Log("[ПРЕДУПРЕЖДЕНИЕ] Документ План закупок №" + docNumber + ": не удалось сохранить список выбранных прайс листов.", false, true);
						return;
					}
					if(saveNewOrderNomenclature() == false){
						Utilits.Console.Log("[ПРЕДУПРЕЖДЕНИЕ] Документ План закупок №" + docNumber + ": не удалось сохранить список выбранной номенклатуры.", false, true);
						return;
					}
					Utilits.Console.Log("Документ План закупок №" + docNumber + ": успешно создан.");
					Close();
				}
			}
		}
		
		bool saveNewChangesPriceLists()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				// OLEDB
				oleDb = new OleDb(DataConfig.localDatabase);
				oleDb.oleDbCommandSelect.CommandText = "SELECT counteragentName, counteragentPricelist, docID FROM PurchasePlanPriceLists WHERE (id = 0)";
				oleDb.ExecuteFill("PurchasePlanPriceLists");				
				
				DataRow newRow = null;
				for(int i = 0; i < listViewPrices.Items.Count; i++){
					newRow = oleDb.dataSet.Tables["PurchasePlanPriceLists"].NewRow();
					newRow["counteragentName"] = listViewPrices.Items[i].SubItems[1].Text.ToString();
					newRow["counteragentPricelist"] = listViewPrices.Items[i].SubItems[2].Text.ToString();
					newRow["docID"] = docNumber;
					oleDb.dataSet.Tables["PurchasePlanPriceLists"].Rows.Add(newRow);
				}
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO PurchasePlanPriceLists (counteragentName, counteragentPricelist, docID) " +
					"VALUES (@counteragentName, @counteragentPricelist, @docID)";
				oleDb.oleDbCommandInsert.Parameters.Add("@counteragentName", OleDbType.VarChar, 255, "counteragentName");
				oleDb.oleDbCommandInsert.Parameters.Add("@counteragentPricelist", OleDbType.VarChar, 255, "counteragentPricelist");
				oleDb.oleDbCommandInsert.Parameters.Add("@docID", OleDbType.VarChar, 255, "docID");
				if(oleDb.ExecuteUpdate("PurchasePlanPriceLists")){
					return true;
				}else{
					return false;
				}
				
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				sqlServer = new SqlServer();
				sqlServer.sqlCommandSelect.CommandText = "SELECT counteragentName, counteragentPricelist, docID FROM PurchasePlanPriceLists WHERE (id = 0)";
				sqlServer.ExecuteFill("PurchasePlanPriceLists");
				
				DataRow newRow = null;
				for(int i = 0; i < listViewPrices.Items.Count; i++){
					newRow = sqlServer.dataSet.Tables["PurchasePlanPriceLists"].NewRow();
					newRow["counteragentName"] = listViewPrices.Items[i].SubItems[1].Text.ToString();
					newRow["counteragentPricelist"] = listViewPrices.Items[i].SubItems[2].Text.ToString();
					newRow["docID"] = docNumber;
					sqlServer.dataSet.Tables["PurchasePlanPriceLists"].Rows.Add(newRow);
				}
				
				sqlServer.sqlCommandInsert.CommandText = "INSERT INTO PurchasePlanPriceLists (counteragentName, counteragentPricelist, docID) " +
					"VALUES (@counteragentName, @counteragentPricelist, @docID)";
				sqlServer.sqlCommandInsert.Parameters.Add("@counteragentName", SqlDbType.VarChar, 255, "counteragentName");
				sqlServer.sqlCommandInsert.Parameters.Add("@counteragentPricelist", SqlDbType.VarChar, 255, "counteragentPricelist");
				sqlServer.sqlCommandInsert.Parameters.Add("@docID", SqlDbType.VarChar, 255, "docID");
				if(sqlServer.ExecuteUpdate("PurchasePlanPriceLists")){
					return true;
				}else{
					return false;
				}
			}
			return false;
		}
		
		bool saveNewOrderNomenclature()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL) {
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
					newRow["nomenclatureID"] = Convert.ToInt32(listViewNomenclature.Items[i].SubItems[1].Text);
					newRow["nomenclatureName"] = listViewNomenclature.Items[i].SubItems[2].Text;
					newRow["units"] = listViewNomenclature.Items[i].SubItems[3].Text;
					newRow["amount"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[4].Text);
					newRow["name"] = listViewNomenclature.Items[i].SubItems[6].Text;
					newRow["price"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[7].Text);
					newRow["manufacturer"] = listViewNomenclature.Items[i].SubItems[8].Text;
					newRow["remainder"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[9].Text);
					newRow["term"] = listViewNomenclature.Items[i].SubItems[10].Text;
					newRow["discount1"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[11].Text);
					newRow["discount2"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[12].Text);
					newRow["discount3"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[13].Text);
					newRow["discount4"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[14].Text);
					newRow["code"] = listViewNomenclature.Items[i].SubItems[15].Text;
					newRow["series"] = listViewNomenclature.Items[i].SubItems[16].Text;
					newRow["article"] = listViewNomenclature.Items[i].SubItems[17].Text;
					newRow["counteragentName"] = listViewNomenclature.Items[i].SubItems[18].Text;
					newRow["counteragentPricelist"] = listViewNomenclature.Items[i].SubItems[19].Text;
					newRow["docPurchasePlan"] = docNumber;
					newRow["docOrder"] = "";
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
				
			} else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
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
					newRow["nomenclatureID"] = Convert.ToInt32(listViewNomenclature.Items[i].SubItems[1].Text);
					newRow["nomenclatureName"] = listViewNomenclature.Items[i].SubItems[2].Text;
					newRow["units"] = listViewNomenclature.Items[i].SubItems[3].Text;
					newRow["amount"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[4].Text);
					newRow["name"] = listViewNomenclature.Items[i].SubItems[6].Text;
					newRow["price"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[7].Text);
					newRow["manufacturer"] = listViewNomenclature.Items[i].SubItems[8].Text;
					newRow["remainder"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[9].Text);
					newRow["term"] = listViewNomenclature.Items[i].SubItems[10].Text;
					newRow["discount1"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[11].Text);
					newRow["discount2"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[12].Text);
					newRow["discount3"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[13].Text);
					newRow["discount4"] = Convert.ToDouble(listViewNomenclature.Items[i].SubItems[14].Text);
					newRow["code"] = listViewNomenclature.Items[i].SubItems[15].Text;
					newRow["series"] = listViewNomenclature.Items[i].SubItems[16].Text;
					newRow["article"] = listViewNomenclature.Items[i].SubItems[17].Text;
					newRow["counteragentName"] = listViewNomenclature.Items[i].SubItems[18].Text;
					newRow["counteragentPricelist"] = listViewNomenclature.Items[i].SubItems[19].Text;
					newRow["docPurchasePlan"] = docNumber;
					newRow["docOrder"] = "";
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
				oleDb.oleDbCommandSelect.CommandText = "SELECT id, docDate, docNumber, docName, docAutor, docSum, docVat, docTotal FROM PurchasePlan WHERE (id = " + ID + ")";
				if(oleDb.ExecuteFill("PurchasePlan")){
					docNumber = oleDb.dataSet.Tables["PurchasePlan"].Rows[0]["docNumber"].ToString();
					docNumberTextBox.Text = docNumber;
					dateTimePicker1.Value = (DateTime)oleDb.dataSet.Tables["PurchasePlan"].Rows[0]["docDate"];
					autorLabel.Text = "Автор: " + oleDb.dataSet.Tables["PurchasePlan"].Rows[0]["docAutor"].ToString();
					openPrices();
					openOrderNomenclature();
					calculate();
				}else{
					Utilits.Console.Log("[ОШИБКА] программа не смогла открыть документ план закупок.", false, true);
				}
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				sqlServer = new SqlServer();
				sqlServer.sqlCommandSelect.CommandText = "SELECT id, docDate, docNumber, docName, docAutor, docSum, docVat, docTotal FROM PurchasePlan WHERE (id = " + ID + ")";
				if(sqlServer.ExecuteFill("PurchasePlan")){
					docNumber = sqlServer.dataSet.Tables["PurchasePlan"].Rows[0]["docNumber"].ToString();
					docNumberTextBox.Text = docNumber;
					dateTimePicker1.Value = (DateTime)sqlServer.dataSet.Tables["PurchasePlan"].Rows[0]["docDate"];
					autorLabel.Text = "Автор: " + sqlServer.dataSet.Tables["PurchasePlan"].Rows[0]["docAutor"].ToString();
					openPrices();
					openOrderNomenclature();
					calculate();
				}else{
					Utilits.Console.Log("[ОШИБКА] программа не смогла открыть документ план закупок.", false, true);
				}
			}
		}
		
		void openPrices()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				// OLEDB
				oleDb = new OleDb(DataConfig.localDatabase);
				oleDb.oleDbCommandSelect.CommandText = "SELECT counteragentName, counteragentPricelist, docID FROM PurchasePlanPriceLists WHERE (docID = '" + docNumber + "')";
				if(oleDb.ExecuteFill("PurchasePlanPriceLists")){
					ListViewItem ListViewItem_add;
					foreach(DataRow row in oleDb.dataSet.Tables["PurchasePlanPriceLists"].Rows){
						ListViewItem_add = new ListViewItem();
						ListViewItem_add.SubItems.Add(row["counteragentName"].ToString());
						ListViewItem_add.StateImageIndex = 0;
						ListViewItem_add.SubItems.Add(row["counteragentPricelist"].ToString());
						listViewPrices.Items.Add(ListViewItem_add);
					}
				}else{
					Utilits.Console.Log("[ПРЕДУПРЕЖДЕНИЕ] программа не смогла загрузить прайс листы документа план закупок №" + docNumber, false, true);
				}
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				sqlServer = new SqlServer();
				sqlServer.sqlCommandSelect.CommandText = "SELECT counteragentName, counteragentPricelist, docID FROM PurchasePlanPriceLists WHERE (docID = '" + docNumber + "')";
				if(sqlServer.ExecuteFill("PurchasePlanPriceLists")){
					ListViewItem ListViewItem_add;
					foreach(DataRow row in sqlServer.dataSet.Tables["PurchasePlanPriceLists"].Rows){
						ListViewItem_add = new ListViewItem();
						ListViewItem_add.SubItems.Add(row["counteragentName"].ToString());
						ListViewItem_add.StateImageIndex = 0;
						ListViewItem_add.SubItems.Add(row["counteragentPricelist"].ToString());
						listViewPrices.Items.Add(ListViewItem_add);
					}
				}else{
					Utilits.Console.Log("[ПРЕДУПРЕЖДЕНИЕ] программа не смогла загрузить прайс листы документа план закупок №" + docNumber, false, true);
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
					"FROM OrderNomenclature WHERE (docPurchasePlan = '" + docNumber + "')";
				if(oleDb.ExecuteFill("OrderNomenclature")){
					DateTime dt;
					ListViewItem ListViewItem_add;
					foreach(DataRow row in oleDb.dataSet.Tables["OrderNomenclature"].Rows){
						ListViewItem_add = new ListViewItem();
						ListViewItem_add.SubItems.Add(row["nomenclatureID"].ToString());
						ListViewItem_add.StateImageIndex = 1;
						ListViewItem_add.SubItems.Add(row["nomenclatureName"].ToString());
						ListViewItem_add.SubItems.Add(row["units"].ToString());
						ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(row["amount"].ToString()).ToString()));
						ListViewItem_add.SubItems.Add("-->");
						ListViewItem_add.SubItems.Add(row["name"].ToString());
						ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(row["price"].ToString()).ToString()));
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
					"FROM OrderNomenclature WHERE (docPurchasePlan = '" + docNumber + "')";
				if(sqlServer.ExecuteFill("OrderNomenclature")){
					DateTime dt;
					ListViewItem ListViewItem_add;
					foreach(DataRow row in sqlServer.dataSet.Tables["OrderNomenclature"].Rows){
						ListViewItem_add = new ListViewItem();
						ListViewItem_add.SubItems.Add(row["nomenclatureID"].ToString());
						ListViewItem_add.StateImageIndex = 1;
						ListViewItem_add.SubItems.Add(row["nomenclatureName"].ToString());
						ListViewItem_add.SubItems.Add(row["units"].ToString());
						ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(row["amount"].ToString()).ToString()));
						ListViewItem_add.SubItems.Add("-->");
						ListViewItem_add.SubItems.Add(row["name"].ToString());
						ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(row["price"].ToString()).ToString()));
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
				oleDb.oleDbCommandSelect.CommandText = "SELECT id, docDate, docNumber, docName, docAutor, docSum, docVat, docTotal FROM PurchasePlan WHERE (id = " + ID + ")";
				if(oleDb.ExecuteFill("PurchasePlan")){
					oleDb.dataSet.Tables["PurchasePlan"].Rows[0]["docDate"] = dateTimePicker1.Value;
					oleDb.dataSet.Tables["PurchasePlan"].Rows[0]["docAutor"] = DataConfig.userName;
					oleDb.dataSet.Tables["PurchasePlan"].Rows[0]["docSum"] = textBox4.Text;
					oleDb.dataSet.Tables["PurchasePlan"].Rows[0]["docVat"] = textBox5.Text;
					oleDb.dataSet.Tables["PurchasePlan"].Rows[0]["docTotal"] = textBox6.Text;
					oleDb.oleDbCommandUpdate.CommandText = "UPDATE PurchasePlan SET " +
					"[docDate] = @docDate, [docNumber] = @docNumber, " +
					"[docName] = @docName, [docAutor] = @docAutor, [docSum] = @docSum, " +
					"[docVat] = @docVat, [docTotal] = @docTotal " +
					"WHERE ([id] = @id)";
					oleDb.oleDbCommandUpdate.Parameters.Add("@docDate", OleDbType.Date, 255, "docDate");
					oleDb.oleDbCommandUpdate.Parameters.Add("@docNumber", OleDbType.VarChar, 255, "docNumber");
					oleDb.oleDbCommandUpdate.Parameters.Add("@docName", OleDbType.VarChar, 255, "docName");
					oleDb.oleDbCommandUpdate.Parameters.Add("@docAutor", OleDbType.VarChar, 255, "docAutor");
					oleDb.oleDbCommandUpdate.Parameters.Add("@docSum", OleDbType.Double, 15, "docSum");
					oleDb.oleDbCommandUpdate.Parameters.Add("@docVat", OleDbType.Double, 15, "docVat");
					oleDb.oleDbCommandUpdate.Parameters.Add("@docTotal", OleDbType.Double, 15, "docTotal");
					oleDb.oleDbCommandUpdate.Parameters.Add("@id", OleDbType.Integer, 10, "id");
					if(oleDb.ExecuteUpdate("PurchasePlan")){
						return true;
					}else{
						Utilits.Console.Log("[ОШИБКА] программа не смогла сохранить основные данные документа план закупок №" + docNumber, false, true);
					}
				}else{
					Utilits.Console.Log("[ОШИБКА] программа не смогла загрузить данные документа план закупок №" + docNumber, false, true);
				}			
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				sqlServer = new SqlServer();
				sqlServer.sqlCommandSelect.CommandText = "SELECT id, docDate, docNumber, docName, docAutor, docSum, docVat, docTotal FROM PurchasePlan WHERE (id = " + ID + ")";
				if(sqlServer.ExecuteFill("PurchasePlan")){
					sqlServer.dataSet.Tables["PurchasePlan"].Rows[0]["docDate"] = dateTimePicker1.Value;
					sqlServer.dataSet.Tables["PurchasePlan"].Rows[0]["docAutor"] = DataConfig.userName;
					sqlServer.dataSet.Tables["PurchasePlan"].Rows[0]["docSum"] = textBox4.Text;
					sqlServer.dataSet.Tables["PurchasePlan"].Rows[0]["docVat"] = textBox5.Text;
					sqlServer.dataSet.Tables["PurchasePlan"].Rows[0]["docTotal"] = textBox6.Text;
					sqlServer.sqlCommandUpdate.CommandText = "UPDATE PurchasePlan SET " +
					"[docDate] = @docDate, [docNumber] = @docNumber, " +
					"[docName] = @docName, [docAutor] = @docAutor, [docSum] = @docSum, " +
					"[docVat] = @docVat, [docTotal] = @docTotal " +
					"WHERE ([id] = @id)";
					sqlServer.sqlCommandUpdate.Parameters.Add("@docDate", SqlDbType.Date, 255, "docDate");
					sqlServer.sqlCommandUpdate.Parameters.Add("@docNumber", SqlDbType.VarChar, 255, "docNumber");
					sqlServer.sqlCommandUpdate.Parameters.Add("@docName", SqlDbType.VarChar, 255, "docName");
					sqlServer.sqlCommandUpdate.Parameters.Add("@docAutor", SqlDbType.VarChar, 255, "docAutor");
					sqlServer.sqlCommandUpdate.Parameters.Add("@docSum", SqlDbType.Float, 15, "docSum");
					sqlServer.sqlCommandUpdate.Parameters.Add("@docVat", SqlDbType.Float, 15, "docVat");
					sqlServer.sqlCommandUpdate.Parameters.Add("@docTotal", SqlDbType.Float, 15, "docTotal");
					sqlServer.sqlCommandUpdate.Parameters.Add("@id", SqlDbType.Int, 10, "id");
					if(sqlServer.ExecuteUpdate("PurchasePlan")){
						return true;
					}else{
						Utilits.Console.Log("[ОШИБКА] программа не смогла сохранить основные данные документа план закупок №" + docNumber, false, true);
					}
				}else{
					Utilits.Console.Log("[ОШИБКА] программа не смогла загрузить данные документа план закупок №" + docNumber, false, true);
				}
			}
			return false;
		}
		
		bool saveEditPrices()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				// OLEDB
				QueryOleDb query = new QueryOleDb(DataConfig.localDatabase);
				query.SetCommand("DELETE FROM PurchasePlanPriceLists WHERE (docID = '" + docNumber + "')");
				if(query.Execute()){
					if(saveNewChangesPriceLists()){
						return true;
					}else{
						Utilits.Console.Log("[ОШИБКА] программа не смогла записать ищменённый выбор прайс-листов в документ план закупок №" + docNumber, false, true);
					}
				}else{
					Utilits.Console.Log("[ОШИБКА] программа не смогла удалить прайс-листы из документа план закупок №" + docNumber, false, true);
				}
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				QuerySqlServer query = new QuerySqlServer(DataConfig.serverConnection);
				query.SetCommand("DELETE FROM PurchasePlanPriceLists WHERE (docID = '" + docNumber + "')");
				if(query.Execute()){
					if(saveNewChangesPriceLists()){
						return true;
					}else{
						Utilits.Console.Log("[ОШИБКА] программа не смогла записать ищменённый выбор прайс-листов в документ план закупок №" + docNumber, false, true);
					}
				}else{
					Utilits.Console.Log("[ОШИБКА] программа не смогла удалить прайс-листы из документа план закупок №" + docNumber, false, true);
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
					"FROM OrderNomenclature WHERE (docPurchasePlan = '" + docNumber + "')";
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
						row["nomenclatureID"] = item.SubItems[1].Text;
						row["nomenclatureName"] = item.SubItems[2].Text;
						row["units"] = item.SubItems[3].Text;
						row["amount"] = Convert.ToDouble(item.SubItems[4].Text);
						row["name"] = item.SubItems[6].Text;
						row["price"] = Convert.ToDouble(item.SubItems[7].Text);
						row["manufacturer"] = item.SubItems[8].Text;
						row["remainder"] = Convert.ToDouble(item.SubItems[9].Text);
						row["term"] = item.SubItems[10].Text;
						row["discount1"] = Convert.ToDouble(item.SubItems[11].Text);
						row["discount2"] = Convert.ToDouble(item.SubItems[12].Text);
						row["discount3"] = Convert.ToDouble(item.SubItems[13].Text);
						row["discount4"] = Convert.ToDouble(item.SubItems[14].Text);
						row["code"] = item.SubItems[15].Text;
						row["series"] = item.SubItems[16].Text;
						row["article"] = item.SubItems[17].Text;
						row["counteragentName"] = item.SubItems[18].Text;
						row["counteragentPricelist"] = item.SubItems[19].Text;
						row["docPurchasePlan"] = docNumberTextBox.Text;
						//row["docOrder"] = "";
					}
				}
				
				DataRow newRow;
				foreach(ListViewItem itemLV in listViewNomenclature.Items){
					if(itemLV.SubItems[20].Text == ""){
						newRow = oleDb.dataSet.Tables["OrderNomenclature"].NewRow();
						newRow["nomenclatureID"] = itemLV.SubItems[1].Text;
						newRow["nomenclatureName"] = itemLV.SubItems[2].Text;
						newRow["units"] = itemLV.SubItems[3].Text;
						newRow["amount"] = Convert.ToDouble(itemLV.SubItems[4].Text);
						newRow["name"] = itemLV.SubItems[6].Text;
						newRow["price"] = Convert.ToDouble(itemLV.SubItems[7].Text);
						newRow["manufacturer"] = itemLV.SubItems[8].Text;
						newRow["remainder"] = Convert.ToDouble(itemLV.SubItems[9].Text);
						newRow["term"] = itemLV.SubItems[10].Text;
						newRow["discount1"] = Convert.ToDouble(itemLV.SubItems[11].Text);
						newRow["discount2"] = Convert.ToDouble(itemLV.SubItems[12].Text);
						newRow["discount3"] = Convert.ToDouble(itemLV.SubItems[13].Text);
						newRow["discount4"] = Convert.ToDouble(itemLV.SubItems[14].Text);
						newRow["code"] = itemLV.SubItems[15].Text;
						newRow["series"] = itemLV.SubItems[16].Text;
						newRow["article"] = itemLV.SubItems[17].Text;
						newRow["counteragentName"] = itemLV.SubItems[18].Text;
						newRow["counteragentPricelist"] = itemLV.SubItems[19].Text;
						newRow["docPurchasePlan"] = docNumber;
						newRow["docOrder"] = "";
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
					"FROM OrderNomenclature WHERE (docPurchasePlan = '" + docNumber + "')";
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
						row["nomenclatureID"] = item.SubItems[1].Text;
						row["nomenclatureName"] = item.SubItems[2].Text;
						row["units"] = item.SubItems[3].Text;
						row["amount"] = Convert.ToDouble(item.SubItems[4].Text);
						row["name"] = item.SubItems[6].Text;
						row["price"] = Convert.ToDouble(item.SubItems[7].Text);
						row["manufacturer"] = item.SubItems[8].Text;
						row["remainder"] = Convert.ToDouble(item.SubItems[9].Text);
						row["term"] = item.SubItems[10].Text;
						row["discount1"] = Convert.ToDouble(item.SubItems[11].Text);
						row["discount2"] = Convert.ToDouble(item.SubItems[12].Text);
						row["discount3"] = Convert.ToDouble(item.SubItems[13].Text);
						row["discount4"] = Convert.ToDouble(item.SubItems[14].Text);
						row["code"] = item.SubItems[15].Text;
						row["series"] = item.SubItems[16].Text;
						row["article"] = item.SubItems[17].Text;
						row["counteragentName"] = item.SubItems[18].Text;
						row["counteragentPricelist"] = item.SubItems[19].Text;
						row["docPurchasePlan"] = docNumberTextBox.Text;
						//row["docOrder"] = "";
					}
				}
				
				DataRow newRow;
				foreach(ListViewItem itemLV in listViewNomenclature.Items){
					if(itemLV.SubItems[20].Text == ""){
						newRow = sqlServer.dataSet.Tables["OrderNomenclature"].NewRow();
						newRow["nomenclatureID"] = Convert.ToInt32(itemLV.SubItems[1].Text);
						newRow["nomenclatureName"] = itemLV.SubItems[2].Text;
						newRow["units"] = itemLV.SubItems[3].Text;
						newRow["amount"] = Convert.ToDouble(itemLV.SubItems[4].Text);
						newRow["name"] = itemLV.SubItems[6].Text;
						newRow["price"] = Convert.ToDouble(itemLV.SubItems[7].Text);
						newRow["manufacturer"] = itemLV.SubItems[8].Text;
						newRow["remainder"] = Convert.ToDouble(itemLV.SubItems[9].Text);
						newRow["term"] = itemLV.SubItems[10].Text;
						newRow["discount1"] = Convert.ToDouble(itemLV.SubItems[11].Text);
						newRow["discount2"] = Convert.ToDouble(itemLV.SubItems[12].Text);
						newRow["discount3"] = Convert.ToDouble(itemLV.SubItems[13].Text);
						newRow["discount4"] = Convert.ToDouble(itemLV.SubItems[14].Text);
						newRow["code"] = itemLV.SubItems[15].Text;
						newRow["series"] = itemLV.SubItems[16].Text;
						newRow["article"] = itemLV.SubItems[17].Text;
						newRow["counteragentName"] = itemLV.SubItems[18].Text;
						newRow["counteragentPricelist"] = itemLV.SubItems[19].Text;
						newRow["docPurchasePlan"] = docNumber;
						newRow["docOrder"] = "";
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
				if(id == listViewNomenclature.Items[i].SubItems[20].Text){
					return listViewNomenclature.Items[i];
				}
			}
			return null;
		}
		
		int searchStep = 0;
		struct SearchResult {
			public String value;	// значение поиска
			public int position;	// позиция найденного значения
		}
		List<SearchResult> searchResultList;
		
		void searchValues()
		{
			SearchResult searchResult;
			String str;
			searchResultList = new List<SearchResult>();
			for(int i = 0; i < listViewNomenclature.Items.Count; i++){
				str = listViewNomenclature.Items[i].SubItems[2].Text;
				if(str.Contains(searchTextBox.Text)){
					searchResult = new SearchResult();
					searchResult.value = searchTextBox.Text;
					searchResult.position = i;
					searchResultList.Add(searchResult);
				}
			}
			searchStep = 0;
		}
		
		void search()
		{
			if(searchTextBox.Text == "") return;
			
			if(searchResultList == null){
				searchValues();
			}else{
				if(searchResultList[0].value != searchTextBox.Text){
					searchValues();
				}else{
					searchStep++;
					if(searchStep >= searchResultList.Count) searchStep = 0;
				}
			}
			
			if(searchResultList.Count == 0){
				MessageBox.Show("Пойск ничего не нашел.", "Сообщение");
				searchResultList = null;
				return;
			}
			
			listViewNomenclature.FocusedItem = listViewNomenclature.Items[searchResultList[searchStep].position];
			listViewNomenclature.Items[searchResultList[searchStep].position].Selected = true;
			listViewNomenclature.Select();
			listViewNomenclature.EnsureVisible(searchResultList[searchStep].position);
		}
		
		
		bool check()
		{
			if(listViewPrices.Items.Count == 0){
				MessageBox.Show("Вы не добавили прайс-лист контрагента.", "Сообщение");
				return false;
			}
			if(listViewNomenclature.Items.Count == 0){
				MessageBox.Show("Вы не добавили номенклатуру.", "Сообщение");
				return false;
			}
			int count = listViewNomenclature.Items.Count;
			for(int i = 0; i < count; i++){
				if(listViewNomenclature.Items[i].StateImageIndex == 0){
					MessageBox.Show("Номенклатуре " + listViewNomenclature.Items[i].SubItems[2].Text + " нет соответствия из прайс-листа контрагента.", "Сообщение");
					return false;
				}
			}
			return true;
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
					if(listViewNomenclature.Items[i].SubItems[4].Text != "") amount = Conversion.StringToDouble(listViewNomenclature.Items[i].SubItems[4].Text);
					else amount = 0;
					if(listViewNomenclature.Items[i].SubItems[7].Text != "") price = Conversion.StringToDouble(listViewNomenclature.Items[i].SubItems[7].Text);
					else price = 0;
					sum += (price * amount);
				}
				sum = Math.Round(sum, 2);
				vat = sum * DataConstants.ConstFirmVAT / 100;
				vat = Math.Round(vat, 2);
				total = sum + vat;
				total = Math.Round(total, 2);
				
				textBox4.Text = Conversion.StringToMoney(Conversion.StringToDouble(sum.ToString()).ToString());
				textBox5.Text = Conversion.StringToMoney(Conversion.StringToDouble(vat.ToString()).ToString());
				textBox6.Text = Conversion.StringToMoney(Conversion.StringToDouble(total.ToString()).ToString());
			}else{
				textBox4.Text = "0,00";
				textBox5.Text = "0,00";
				textBox6.Text = "0,00";
			}
		}
		
		
		
		/* =================================================================================================
		 * РАЗДЕЛ: СОБЫТИЙ
		 * =================================================================================================
		 */	
		void FormPurchasePlanDocLoad(object sender, EventArgs e)
		{
			if(ID == null){
				Text = "План закупок: Создать";
				dateTimePicker1.Value = DateTime.Today.Date;
				autorLabel.Text = "Автор: " + DataConfig.userName;
			}else{
				Text = "План закупок: Изменить";
				open();
			}
			Utilits.Console.Log(Text);
		}
		void FormPurchasePlanDocFormClosed(object sender, FormClosedEventArgs e)
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
		void AddButtonClick(object sender, EventArgs e)
		{
			if(DataForms.FCounteragents != null) DataForms.FCounteragents.Close();
			if(DataForms.FCounteragents == null) {
				DataForms.FCounteragents = new FormCounteragents();
				DataForms.FCounteragents.MdiParent = DataForms.FClient;
				DataForms.FCounteragents.ListViewReturnValue = listViewPrices;
				DataForms.FCounteragents.TypeReturnValue = "name&price";
				DataForms.FCounteragents.ShowMenuReturnValue();
				DataForms.FCounteragents.Show();
			}	
		}
		void DeleteButtonClick(object sender, EventArgs e)
		{
			if(listViewPrices.SelectedItems.Count > 0) listViewPrices.Items[listViewPrices.SelectedItems[0].Index].Remove();
		}
		void PriceButtonClick(object sender, EventArgs e)
		{
			editPrice();
		}
		void ButtonSaveClick(object sender, EventArgs e)
		{
			calculate();
			if(DataConfig.userPermissions == "guest"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			if(ID == null){
				if(check()) saveNew();
			}else{
				if(check() == false) return;
				if(saveEdit() && saveEditPrices() && saveEditOrderNomenclature()){
					DataForms.FClient.updateHistory("PurchasePlan");
					Utilits.Console.Log("Документ План закупок №" + docNumber + ": успешно изменён и сохранён.");
					if(MessageBox.Show("Обновить заказы созданные на основании План закупок №" + docNumber + "?","Вопрос", MessageBoxButtons.YesNo) == DialogResult.Yes){
						InputToOrder inputToOrder = new InputToOrder(docNumberTextBox.Text);
						inputToOrder.Execute();
					}
					Close();
				}else{
					Utilits.Console.Log("[ПРЕДУПРЕЖДЕНИЕ] Документ План закупок №" + docNumber + ": не удалось сохранить изменения.", false, true);
				}
			}
		}
		void ButtonNomenclatureAddClick(object sender, EventArgs e)
		{
			if(DataForms.FNomenclature != null) DataForms.FNomenclature.Close();
			if(DataForms.FNomenclature == null) {
				DataForms.FNomenclature = new FormNomenclature();
				DataForms.FNomenclature.MdiParent = DataForms.FClient;
				DataForms.FNomenclature.ListViewReturnValue = listViewNomenclature;
				DataForms.FNomenclature.TypeReturnValue = "file&PurchasePlan";
				DataForms.FNomenclature.ShowMenuReturnValue();
				DataForms.FNomenclature.Show();
			}
		}
		void ButtonNomenclatureDeleteClick(object sender, EventArgs e)
		{
			if(listViewNomenclature.SelectedItems.Count > 0) listViewNomenclature.Items[listViewNomenclature.SelectedItems[0].Index].Remove();
			selectTableLine = -1;
			textBox1.Clear();
			textBox3.Clear();
			textBox2.Text = "0,00";
			calculate();
		}
		void ButtonNomenclaturesAddClick(object sender, EventArgs e)
		{
			if(DataForms.FNomenclature != null) DataForms.FNomenclature.Close();
			if(DataForms.FNomenclature == null) {
				DataForms.FNomenclature = new FormNomenclature();
				DataForms.FNomenclature.MdiParent = DataForms.FClient;
				DataForms.FNomenclature.ListViewReturnValue = listViewNomenclature;
				DataForms.FNomenclature.TypeReturnValue = "folder&PurchasePlan";
				DataForms.FNomenclature.ShowMenuReturnValue();
				DataForms.FNomenclature.Show();
			}
		}
		void ButtonNomenclaturesDeleteClick(object sender, EventArgs e)
		{
			while(listViewNomenclature.Items.Count > 0){
				listViewNomenclature.Items[0].Remove();
			}
			selectTableLine = -1;
			textBox1.Clear();
			textBox3.Clear();
			textBox2.Text = "0,00";
			calculate();
		}
		void Button4Click(object sender, EventArgs e)
		{
			if(listViewPrices.Items.Count == 0){
				MessageBox.Show("Вы не добавили не одного прайса.", "Сообщение");
				return;
			}
			
			if(listViewNomenclature.SelectedItems.Count > 0){
				List<Nomenclature> nomenclatureList;
				nomenclatureList = new List<Nomenclature>();
				
				String nID = listViewNomenclature.Items[listViewNomenclature.SelectedItems[0].Index].SubItems[1].Text;
				
				if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL) {
					// OLEDB
					searchNomenclatureOleDb = new SearchNomenclatureOleDb();
					searchNomenclatureOleDb.setPrices(listViewPrices);
					nomenclatureList = searchNomenclatureOleDb.getFindNomenclature(nID);
				} else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
					// MSSQL SERVER
					searchNomenclatureSql = new SearchNomenclatureSqlServer();
					searchNomenclatureSql.setPrices(listViewPrices);
					nomenclatureList = searchNomenclatureSql.getFindNomenclature(nID);
				}
							
				if(nomenclatureList == null) return;
				if(nomenclatureList.Count == 0) MessageBox.Show("Программе не удалось найти выбанную номенклатуру в прайсах контрагентов.", "Сообщение");
				FormPurchasePlanNomenclature FPurchasePlanNomenclature = new FormPurchasePlanNomenclature();
				FPurchasePlanNomenclature.MdiParent = DataForms.FClient;
				FPurchasePlanNomenclature.ListViewPrices = listViewPrices;
				FPurchasePlanNomenclature.ListViewReturnValue = listViewNomenclature;
				FPurchasePlanNomenclature.SelectTableLine = selectTableLine;
				FPurchasePlanNomenclature.FilterText = listViewNomenclature.Items[listViewNomenclature.SelectedItems[0].Index].SubItems[2].Text;
				FPurchasePlanNomenclature.LoadNomenclature(nomenclatureList);
				FPurchasePlanNomenclature.Show();
			}
		}
		void ListViewNomenclatureSelectedIndexChanged(object sender, EventArgs e)
		{
			if(listViewNomenclature.SelectedItems.Count > 0){
				selectTableLine = listViewNomenclature.SelectedItems[0].Index;
				textBox1.Text = listViewNomenclature.Items[selectTableLine].SubItems[2].Text;
				textBox2.Text = listViewNomenclature.Items[selectTableLine].SubItems[4].Text;
				textBox3.Text = listViewNomenclature.Items[selectTableLine].SubItems[3].Text;
			}
		}
		void Button8Click(object sender, EventArgs e)
		{
			if(DataForms.FUnits != null) DataForms.FUnits.Close();
			if(DataForms.FUnits == null) {
				DataForms.FUnits = new FormUnits();
				DataForms.FUnits.MdiParent = DataForms.FClient;
				DataForms.FUnits.TextBoxReturnValue = textBox3;
				DataForms.FUnits.ShowMenuReturnValue();
				DataForms.FUnits.Show();
			}
		}
		void Button9Click(object sender, EventArgs e)
		{
			textBox3.Clear();
		}
		void TextBox3TextChanged(object sender, EventArgs e)
		{
			if(listViewNomenclature.Items.Count > 0 && selectTableLine > -1){
				listViewNomenclature.Items[selectTableLine].SubItems[3].Text = textBox3.Text;
			}
		}
		void TextBox2KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab){
				String Value = textBox2.Text;
				textBox2.Clear();
				textBox2.Text = Conversion.StringToMoney(Conversion.StringToDouble(Value).ToString());
				if(textBox2.Text == "" || Conversion.checkString(textBox2.Text) == false) textBox2.Text = "0,00";
				calculate();
			}
		}
		void TextBox2TextLostFocus(object sender, EventArgs e)
		{
			String Value = textBox2.Text;
			textBox2.Clear();
			textBox2.Text = Conversion.StringToMoney(Conversion.StringToDouble(Value).ToString());
			if(textBox2.Text == "" || Conversion.checkString(textBox2.Text) == false) textBox2.Text = "0,00";
			calculate();
		}
		void TextBox2TextChanged(object sender, EventArgs e)
		{
			if(textBox2.Text == "" || Conversion.checkString(textBox2.Text) == false) textBox2.Text = "0,00";
			if(listViewNomenclature.Items.Count > 0 && selectTableLine > -1){
				listViewNomenclature.Items[selectTableLine].SubItems[4].Text = textBox2.Text;
				calculate();
			}
		}
		void Button6Click(object sender, EventArgs e)
		{
			textBox2.Text = "0,00";
			calculate();
		}
		void Button7Click(object sender, EventArgs e)
		{
			Calculator Calc = new Calculator();
			Calc.TextBoxReturnValue = textBox2;
			Calc.MdiParent = DataForms.FClient;
			Calc.Show();
		}
		void Button1Click(object sender, EventArgs e)
		{
			if(listViewPrices.Items.Count == 0){
				MessageBox.Show("Вы не добавили не одного прайса.", "Сообщение");
				return;
			}			
			
			/*
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL) {
				// OLEDB
				searchNomenclatureOleDb = new SearchNomenclatureOleDb();
				searchNomenclatureOleDb.setPrices(listViewPrices);
				searchNomenclatureOleDb.autoFindNomenclature(listViewNomenclature);
			} else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				searchNomenclatureSql = new SearchNomenclatureSqlServer();
				searchNomenclatureSql.setPrices(listViewPrices);
				searchNomenclatureSql.autoFindNomenclature(listViewNomenclature);
			}
			*/
			NotificationSearchNomenclature searchNomenclature = new NotificationSearchNomenclature();
			searchNomenclature.ListViewPrices = listViewPrices;
			searchNomenclature.ListViewNomenclature = listViewNomenclature;
			searchNomenclature.ShowDialog();
			
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
		
		int printLine = 0;
		void PrintDocument1PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			int PosY = 0;
			if(printLine == 0){
				// Заголовок документа
				e.Graphics.DrawString("ПЛАН ЗАКУПОК № " + docNumberTextBox.Text + "   дата: " + dateTimePicker1.Text, new Font("Microsoft Sans Serif", 14, FontStyle.Regular), Brushes.Black, 20, PosY);
				// ТАБЛИЧНАЯ ЧАСТЬ: Загрузка данных из таблицы
				PosY += 50;
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
				PosY += 15;
			}
			
			String textName;
			for(int i = printLine; i < listViewNomenclature.Items.Count; i++){
				//    Наименование
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(0, PosY, 400, 25));
				textName = listViewNomenclature.Items[i].SubItems[2].Text;
				if(textName.Length > 50) textName = textName.Substring(0, 50);
				e.Graphics.DrawString(textName, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 5, PosY);
				//    Ед. изм.
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(405, PosY, 65, 25));
				e.Graphics.DrawString(listViewNomenclature.Items[i].SubItems[3].Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 410, PosY);
				//    Количество.
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(475, PosY, 65, 25));
				e.Graphics.DrawString(listViewNomenclature.Items[i].SubItems[4].Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 480, PosY);
				//    Цена.
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(545, PosY, 100, 25));
				e.Graphics.DrawString(listViewNomenclature.Items[i].SubItems[7].Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 550, PosY);
				
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
			e.Graphics.DrawString("Сумма: " + textBox4.Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 0, PosY);
			//	НДС.
			PosY += 30;
			e.Graphics.FillRectangle(Brushes.White, new Rectangle(0, PosY, 250, 25));
			e.Graphics.DrawString("НДС: " + textBox5.Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 0, PosY);
			//	Всего.
			PosY += 30;
			e.Graphics.FillRectangle(Brushes.White, new Rectangle(0, PosY, 250, 25));
			e.Graphics.DrawString("Всего: " + textBox6.Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 0, PosY);
		}	

		
		void ДобавитьПрайслистToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(DataForms.FCounteragents != null) DataForms.FCounteragents.Close();
			if(DataForms.FCounteragents == null) {
				DataForms.FCounteragents = new FormCounteragents();
				DataForms.FCounteragents.MdiParent = DataForms.FClient;
				DataForms.FCounteragents.ListViewReturnValue = listViewPrices;
				DataForms.FCounteragents.TypeReturnValue = "name&price";
				DataForms.FCounteragents.ShowMenuReturnValue();
				DataForms.FCounteragents.Show();
			}
		}
		void УдалитьПрайслистToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(listViewPrices.SelectedItems.Count > 0) listViewPrices.Items[listViewPrices.SelectedItems[0].Index].Remove();
		}
		void ПросмотретьПрайслистToolStripMenuItemClick(object sender, EventArgs e)
		{
			editPrice();
		}
		void ДобавитьНоменклатуруToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(DataForms.FNomenclature != null) DataForms.FNomenclature.Close();
			if(DataForms.FNomenclature == null) {
				DataForms.FNomenclature = new FormNomenclature();
				DataForms.FNomenclature.MdiParent = DataForms.FClient;
				DataForms.FNomenclature.ListViewReturnValue = listViewNomenclature;
				DataForms.FNomenclature.TypeReturnValue = "file&PurchasePlan";
				DataForms.FNomenclature.ShowMenuReturnValue();
				DataForms.FNomenclature.Show();
			}
		}
		void ДобавитьМножествоНоменклатурыToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(DataForms.FNomenclature != null) DataForms.FNomenclature.Close();
			if(DataForms.FNomenclature == null) {
				DataForms.FNomenclature = new FormNomenclature();
				DataForms.FNomenclature.MdiParent = DataForms.FClient;
				DataForms.FNomenclature.ListViewReturnValue = listViewNomenclature;
				DataForms.FNomenclature.TypeReturnValue = "folder&PurchasePlan";
				DataForms.FNomenclature.ShowMenuReturnValue();
				DataForms.FNomenclature.Show();
			}
		}
		void УдалитьВыбраннуюНоменклатуруToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(listViewNomenclature.SelectedItems.Count > 0) listViewNomenclature.Items[listViewNomenclature.SelectedItems[0].Index].Remove();
			selectTableLine = -1;
			textBox1.Clear();
			textBox3.Clear();
			textBox2.Text = "0,00";
		}
		void УдалитьВесьПереченьНоменклатурыToolStripMenuItemClick(object sender, EventArgs e)
		{
			while(listViewNomenclature.Items.Count > 0){
				listViewNomenclature.Items[0].Remove();
			}
			selectTableLine = -1;
			textBox1.Clear();
			textBox3.Clear();
			textBox2.Text = "0,00";
		}
		void ПодобратьНоменклатуруToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(listViewPrices.Items.Count == 0){
				MessageBox.Show("Вы не добавили не одного прайса.", "Сообщение");
				return;
			}
			
			if(listViewNomenclature.SelectedItems.Count > 0){
				List<Nomenclature> nomenclatureList;
				
				String nID = listViewNomenclature.Items[listViewNomenclature.SelectedItems[0].Index].SubItems[1].Text;
				searchNomenclatureOleDb = new SearchNomenclatureOleDb();
				searchNomenclatureOleDb.setPrices(listViewPrices);
				nomenclatureList = searchNomenclatureOleDb.getFindNomenclature(nID);
				if(nomenclatureList.Count > 0){
					
					FormPurchasePlanNomenclature FPurchasePlanNomenclature = new FormPurchasePlanNomenclature();
					FPurchasePlanNomenclature.MdiParent = DataForms.FClient;
					FPurchasePlanNomenclature.ListViewReturnValue = listViewNomenclature;
					FPurchasePlanNomenclature.SelectTableLine = selectTableLine;
					FPurchasePlanNomenclature.LoadNomenclature(nomenclatureList);
					FPurchasePlanNomenclature.Show();
				}
			}
		}
		void АвтоподборНоменклатурыToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(listViewPrices.Items.Count == 0){
				MessageBox.Show("Вы не добавили не одного прайса.", "Сообщение");
				return;
			}
			/*
			searchNomenclatureOleDb = new SearchNomenclatureOleDb();
			searchNomenclatureOleDb.setPrices(listViewPrices);
			searchNomenclatureOleDb.autoFindNomenclature(listViewNomenclature);
			*/
			
			NotificationSearchNomenclature searchNomenclature = new NotificationSearchNomenclature();
			searchNomenclature.ListViewPrices = listViewPrices;
			searchNomenclature.ListViewNomenclature = listViewNomenclature;
			searchNomenclature.ShowDialog();
		}
		void FindButtonClick(object sender, EventArgs e)
		{
			search();
		}
		void Button3Click(object sender, EventArgs e)
		{
			textBox4.Text = "0,00";
		}
		void Button2Click(object sender, EventArgs e)
		{
			Calculator Calc = new Calculator();
			Calc.TextBoxReturnValue = textBox4;
			Calc.MdiParent = DataForms.FClient;
			Calc.Show();
		}
		void TextBox4TextLostFocus(object sender, EventArgs e)
		{
			String Value = textBox4.Text;
			textBox4.Clear();
			textBox4.Text = Conversion.StringToMoney(Math.Round(Conversion.StringToDouble(Value), 2).ToString());
			if(textBox4.Text == "" || Conversion.checkString(textBox4.Text) == false) textBox4.Text = "0,00";
		}
		void TextBox4KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab){
				String Value = textBox4.Text;
				textBox4.Clear();
				textBox4.Text = Conversion.StringToMoney(Math.Round(Conversion.StringToDouble(Value), 2).ToString());
				if(textBox4.Text == "" || Conversion.checkString(textBox4.Text) == false) textBox4.Text = "0,00";
			}
		}
		void TextBox4TextChanged(object sender, EventArgs e)
		{
			calculate();
			if(textBox4.Text == "" || Conversion.checkString(textBox4.Text) == false) textBox4.Text = "0,00";
		}
		void Button10Click(object sender, EventArgs e)
		{
			textBox5.Text = "0,00";
		}
		void Button5Click(object sender, EventArgs e)
		{
			Calculator Calc = new Calculator();
			Calc.TextBoxReturnValue = textBox5;
			Calc.MdiParent = DataForms.FClient;
			Calc.Show();
		}
		void TextBox5TextLostFocus(object sender, EventArgs e)
		{
			String Value = textBox5.Text;
			textBox5.Clear();
			textBox5.Text = Conversion.StringToMoney(Math.Round(Conversion.StringToDouble(Value), 2).ToString());
			if(textBox5.Text == "" || Conversion.checkString(textBox5.Text) == false) textBox5.Text = "0,00";
		}
		void TextBox5TextChanged(object sender, EventArgs e)
		{
			calculate();
			if(textBox5.Text == "" || Conversion.checkString(textBox5.Text) == false) textBox5.Text = "0,00";
		}
		void TextBox5KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab){
				String Value = textBox5.Text;
				textBox5.Clear();
				textBox5.Text = Conversion.StringToMoney(Math.Round(Conversion.StringToDouble(Value), 2).ToString());
				if(textBox5.Text == "" || Conversion.checkString(textBox5.Text) == false) textBox5.Text = "0,00";
			}
		}
		void Button12Click(object sender, EventArgs e)
		{
			textBox6.Text = "0,00";
		}
		void Button11Click(object sender, EventArgs e)
		{
			Calculator Calc = new Calculator();
			Calc.TextBoxReturnValue = textBox6;
			Calc.MdiParent = DataForms.FClient;
			Calc.Show();
		}
		void TextBox6TextLostFocus(object sender, EventArgs e)
		{
			String Value = textBox6.Text;
			textBox6.Clear();
			textBox6.Text = Conversion.StringToMoney(Math.Round(Conversion.StringToDouble(Value), 2).ToString());
			if(textBox6.Text == "" || Conversion.checkString(textBox6.Text) == false) textBox6.Text = "0,00";
		}
		void TextBox6TextChanged(object sender, EventArgs e)
		{
			calculate();
			if(textBox6.Text == "" || Conversion.checkString(textBox6.Text) == false) textBox6.Text = "0,00";
		}
		void TextBox6KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab){
				String Value = textBox6.Text;
				textBox6.Clear();
				textBox6.Text = Conversion.StringToMoney(Math.Round(Conversion.StringToDouble(Value), 2).ToString());
				if(textBox6.Text == "" || Conversion.checkString(textBox6.Text) == false) textBox6.Text = "0,00";
			}
		}
		void ButtonSaveExcelClick(object sender, EventArgs e)
		{
			if(ID == null){
				MessageBox.Show("Пока документ не сохранён вы не можите выгрузить данные в Excel", "Сообщение");
				return;
			}
			if(saveFileDialog1.ShowDialog() == DialogResult.OK){
				/*
				if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL) {
					// OLEDB
					ExportExcel.CreateWorkbook(saveFileDialog1.FileName, oleDb.dataSet);
				} else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
					// MSSQL SERVER
					ExportExcel.CreateWorkbook(saveFileDialog1.FileName, sqlServer.dataSet);
				}
				*/
				
				int row = 0;
				int col = 0;
				
				Workbook workbook = new Workbook();
				
				try
				{
					Worksheet worksheet = new Worksheet("План закупок");
					
					/* ШАПКА */
					worksheet.Cells[row, 1] = new Cell("План закупок №" + docNumberTextBox.Text);
					row++;
					
					/* ТАБЛИЦА */
					col = 0;
					row++;
					worksheet.Cells[row, col] = new Cell("№п/п:");
					col++;
					worksheet.Cells[row, col] = new Cell("Код товара:");
					col++;
					worksheet.Cells[row, col] = new Cell("Серия:");
					col++;
					worksheet.Cells[row, col] = new Cell("Артикул:");
					col++;
					worksheet.Cells[row, col] = new Cell("Номенклатура:");
					col++;
					worksheet.Cells[row, col] = new Cell("Ед.изм:");
					col++;
					worksheet.Cells[row, col] = new Cell("Кол-во:");
					col++;
					worksheet.Cells[row, col] = new Cell("Цена:");
					col++;
					worksheet.Cells[row, col] = new Cell("Производитель:");
					col++;
					worksheet.Cells[row, col] = new Cell("Остаток:");
					col++;
					worksheet.Cells[row, col] = new Cell("Срок годности:");
					col++;
					worksheet.Cells[row, col] = new Cell("Скидка №1:");
					col++;
					worksheet.Cells[row, col] = new Cell("Скидка №2:");
					col++;
					worksheet.Cells[row, col] = new Cell("Скидка №3:");
					col++;
					worksheet.Cells[row, col] = new Cell("Скидка №4:");
					col++;
					worksheet.Cells[row, col] = new Cell("Контрагент:");
					col++;
					row++;
						
					int countRows = listViewNomenclature.Items.Count;
					int countColumns = col;
					for(int r = 0; r < countRows; r++){
						col = 0;
						worksheet.Cells[row, col] = new Cell(r);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[15].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[16].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[17].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[6].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[3].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[4].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[7].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[8].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[9].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[10].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[11].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[12].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[13].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[14].Text);
						col++;
						worksheet.Cells[row, col] = new Cell(listViewNomenclature.Items[r].SubItems[18].Text);
						col++;
						row++;
		            }
					
					workbook.Worksheets.Add(worksheet);
		            workbook.Save(saveFileDialog1.FileName);
	            } catch (Exception ex) {
					workbook = null;
					Utilits.Console.Log("[ОШИБКА] Создание excel файла плана закупок: " + Environment.NewLine + ex.Message, false, true);
					return;
				}
				
				if(!File.Exists(saveFileDialog1.FileName)){ 
					MessageBox.Show("Файл: " + saveFileDialog1.FileName + " не создан!", "Сообщение");
					return;
	            }
				
				MessageBox.Show("Файл сохранен!", "Сообщение");
			}
		}
		void FormPurchasePlanDocActivated(object sender, EventArgs e)
		{
			DataForms.FClient.messageInStatus(this.Text);
		}
		void SearchTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyData == Keys.Enter){
				search();
			}
		}
		
	}
}
