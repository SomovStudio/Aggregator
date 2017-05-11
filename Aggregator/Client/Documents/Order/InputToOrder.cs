/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 08.05.2017
 * Время: 11:33
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows.Forms;
using Aggregator.Data;
using Aggregator.Database.Local;
using Aggregator.Database.Server;
using Aggregator.Utilits;

namespace Aggregator.Client.Documents.Order
{
	/// <summary>
	/// Description of InputToOrder.
	/// </summary>
	public class InputToOrder
	{
		struct Price {
			public String counteragentName;		// наименование контрагента
			public String priceName;			// идентификатор прайслиста
		}
	
		struct OrderDoc{
			public DateTime docDate;
			public String docNumber;
			public String docName;
			public String docCounteragent;
			public String docAutor;
			public Double docSum;
			public Double docVat;
			public Double docTotal;
			public String docPurchasePlan;
		}
		
		String docPPNumber;
		List<Price> priceList;
		String connectionString = DataConfig.oledbConnectLineBegin + DataConfig.localDatabase + DataConfig.oledbConnectLineEnd + DataConfig.oledbConnectPass;
		
		public InputToOrder(String docNumberPurchasePlan)
		{
			docPPNumber = docNumberPurchasePlan;
		}
		
		public void Execute()
		{
			if(loadPrices() == false){
				MessageBox.Show("Докуммент План закупок №" + docPPNumber + " не содержитт прайсов." + Environment.NewLine + 
				                "Создание Заказов на основании Плана закупок невозможен!", "Сообщение");
				return;
			}
			
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				// OLEDB
				deleteOrdersOleDb();
				createOrdersOleDb();
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				deleteOrdersSqlServer();
				createOrdersSqlServer();
			}
		}
		
		/* Загрузка прайсов из Плана закупок */
		bool loadPrices()
		{
			priceList = new List<Price>();
			Price price;
			
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				// OLEDB
				OleDbConnection oleDbConnection = null;
				OleDbCommand oleDbCommand = null;
				OleDbDataReader oleDbDataReader = null;
				try{
					oleDbConnection = new OleDbConnection(connectionString);
					oleDbCommand = new OleDbCommand("SELECT counteragentName, counteragentPricelist, " +
			                                "docID FROM PurchasePlanPriceLists WHERE (docID = '" + docPPNumber + 
			                                "')", oleDbConnection);
					oleDbConnection.Open();
					oleDbDataReader = oleDbCommand.ExecuteReader();
					while(oleDbDataReader.Read())
					{
						price = new Price();
						price.counteragentName = oleDbDataReader["counteragentName"].ToString();
						price.priceName = oleDbDataReader["counteragentPricelist"].ToString();
						priceList.Add(price);
					}
					
					if(oleDbConnection != null){
						oleDbConnection.Close();
						oleDbConnection.Dispose();
					}
					if(oleDbDataReader != null) oleDbDataReader.Close();
					if(oleDbCommand != null) oleDbCommand.Dispose();
					
					if(priceList.Count > 0) return true;
					else return false;
					
				}catch(Exception ex){
					if(oleDbConnection != null){
						oleDbConnection.Close();
						oleDbConnection.Dispose();
					}
					if(oleDbDataReader != null) oleDbDataReader.Close();
					if(oleDbCommand != null) oleDbCommand.Dispose();
					Utilits.Console.Log("[ОШИБКА] " + ex.ToString(), false, true);
					return false;
				}
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				SqlConnection sqlConnection = null;
				SqlCommand sqlCommand = null;
				SqlDataReader sqlDataReader = null;
				try{
					sqlConnection = new SqlConnection(DataConfig.serverConnection);
					if(sqlCommand != null) sqlCommand.Dispose();
					sqlCommand = new SqlCommand("SELECT counteragentName, counteragentPricelist, " +
			                                "docID FROM PurchasePlanPriceLists WHERE (docID = '" + docPPNumber + 
			                                "')", sqlConnection);
					sqlConnection.Open();
					
					sqlDataReader = sqlCommand.ExecuteReader();
					while(sqlDataReader.Read())
					{
						price = new Price();
						price.counteragentName = sqlDataReader["counteragentName"].ToString();
						price.priceName = sqlDataReader["counteragentPricelist"].ToString();
						priceList.Add(price);
					}
					
					if(sqlConnection != null){
						sqlConnection.Close();
						sqlConnection.Dispose();
					}
					if(sqlDataReader != null) sqlDataReader.Close();
					if(sqlCommand != null) sqlCommand.Dispose();
					
					if(priceList.Count > 0) return true;
					else return false;
					
				}catch(Exception ex){
					if(sqlConnection != null){
						sqlConnection.Close();
						sqlConnection.Dispose();
					}
					if(sqlDataReader != null) sqlDataReader.Close();
					if(sqlCommand != null) sqlCommand.Dispose();
					Utilits.Console.Log("[ОШИБКА] " + ex.Message.ToString(), false, true);
					return false;
				}
			}
			return false;
		}
		
		/* Создать номер для документа Заказ */
		String createDocNumber()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL) {
				// OLEDB
				OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
				OleDbCommand oleDbCommand = null;
				try{
					if(oleDbCommand != null) oleDbCommand.Dispose();
					oleDbCommand = new OleDbCommand("SELECT MAX(id) FROM Orders", oleDbConnection);
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
					Utilits.Console.Log("[ОШИБКА]: " + ex.Message, false, true);
				}
				if(oleDbConnection != null){
					oleDbConnection.Close();
					oleDbConnection.Dispose();
				}
				if(oleDbCommand != null) oleDbCommand.Dispose();
			} else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				SqlConnection sqlConnection = new SqlConnection(DataConfig.serverConnection);
				SqlCommand sqlCommand = null;
				try{
					sqlCommand = new SqlCommand("SELECT MAX(id) FROM Orders", sqlConnection);
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
					Utilits.Console.Log("[ОШИБКА]: " + ex.Message, false, true);
				}
				if(sqlConnection != null){
					sqlConnection.Close();
					sqlConnection.Dispose();
				}
				if(sqlCommand != null) sqlCommand.Dispose();
			}
			return null;
		}
				
		void deleteOrdersOleDb()
		{
			QueryOleDb query;
			query = new QueryOleDb(DataConfig.localDatabase);
			query.SetCommand("UPDATE OrderNomenclature SET docOrder = '' WHERE (docPurchasePlan = '" + docPPNumber + "')");
			if(query.Execute()){
				query = new QueryOleDb(DataConfig.localDatabase);
				query.SetCommand("DELETE FROM Orders WHERE (docPurchasePlan = '" + docPPNumber + "')");
				if(query.Execute()){
					DataForms.FClient.updateHistory("Orders");
					Utilits.Console.Log("Ввод на основании: старые заказы удалены.");
				}else{
					Utilits.Console.Log("[ОШИБКА] Ввод на основании: старый заказ не удалён!", false, true);
				}
			}else{
				Utilits.Console.Log("[ОШИБКА] Ввод на основании: Документ План закупок №" + docPPNumber + " не удалось обновить при удалении старых заказов!", false, true);
			}	
		}
		
		void deleteOrdersSqlServer()
		{
			QuerySqlServer query;
			query = new QuerySqlServer(DataConfig.serverConnection);
			query.SetCommand("UPDATE OrderNomenclature SET docOrder = '' WHERE (docPurchasePlan = '" + docPPNumber + "')");
			if(query.Execute()){
				query = new QuerySqlServer(DataConfig.serverConnection);
				query.SetCommand("DELETE FROM Orders WHERE (docPurchasePlan = '" + docPPNumber + "')");
				if(query.Execute()){
					DataForms.FClient.updateHistory("Orders");
					Utilits.Console.Log("Ввод на основании: старые заказы удалены.");
				}else{
					Utilits.Console.Log("[ОШИБКА] Ввод на основании: старый заказ не удалён!", false, true);
				}
			}else{
				Utilits.Console.Log("[ОШИБКА] Ввод на основании: Документ План закупок №" + docPPNumber + " не удалось обновить при удалении старых заказов!", false, true);
			}
		}
		
		void createOrdersOleDb()
		{
			Double sum = 0;
			Double amount = 0;
			Double price = 0;
			Double vat = 0;
			Double total = 0;
			
			OleDb oleDb = null;
			QueryOleDb oleDbQuery = null;
			
			OrderDoc orderDoc;
			
			try{
				oleDb = new OleDb(DataConfig.localDatabase);
				
				foreach(Price plist in priceList) // Обход прайсов
				{
					sum = 0;
					amount = 0;
					price = 0;
					vat = 0;
					total = 0;
					
					/* Создание основной информации документа заказ */
					orderDoc = new OrderDoc();
					orderDoc.docDate =  DateTime.Today.Date;
					orderDoc.docNumber = createDocNumber();
					orderDoc.docName = "Заказ";
					orderDoc.docCounteragent = plist.counteragentName;
					orderDoc.docAutor = DataConfig.userName;
					orderDoc.docSum = 0;
					orderDoc.docVat = 0;
					orderDoc.docTotal = 0;
					orderDoc.docPurchasePlan = docPPNumber;
					
					oleDb = new OleDb(DataConfig.localDatabase);
					oleDb.oleDbCommandSelect.CommandText = "SELECT " +
						"id, nomenclatureID, nomenclatureName, units, amount, " +
						"name, price, manufacturer, remainder, term, discount1, discount2, discount3, discount4, code, series, article, " +
						"counteragentName, counteragentPricelist, " +
						"docPurchasePlan, docOrder " +
						"FROM OrderNomenclature WHERE (docPurchasePlan = '" + docPPNumber + "' AND counteragentName = '" + plist.counteragentName + "')";
					
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
					
					if(oleDb.ExecuteFill("OrderNomenclature")){ // получаем перечень номенклатуры ПЗ
						
						if(oleDb.dataSet.Tables["OrderNomenclature"].Rows.Count <= 0) continue; // пропускаем (нет номенклатуры по данному контрагенту)
						
						foreach(DataRow row in oleDb.dataSet.Tables["OrderNomenclature"].Rows){
							/* Привязываем к документу */
							row["docOrder"] = orderDoc.docNumber;
															
							/* Вычисления */
							price = (Double)row["price"];
							amount = (Double)row["amount"];
							sum += (price * amount);
						}
						
						/* Итоги вычислений */
						sum = Math.Round(sum, 2);
						vat = sum * DataConstants.ConstFirmVAT / 100;
						vat = Math.Round(vat, 2);
						total = sum + vat;
						total = Math.Round(total, 2);
						
						orderDoc.docSum = sum;
						orderDoc.docVat = vat;
						orderDoc.docTotal = total;
						
						
						/* Создаём новый заказ */
						oleDbQuery = new QueryOleDb(DataConfig.localDatabase);
						oleDbQuery.SetCommand("INSERT INTO Orders " +
							"(docDate, docNumber, docName, docCounteragent, " +
							"docAutor, docSum, docVat, docTotal, docPurchasePlan) " +
							"VALUES ('" + orderDoc.docDate + "', " +
							"'" + orderDoc.docNumber + "', " +
							"'" + orderDoc.docName + "', " +
							"'" + orderDoc.docCounteragent + "', " +
							"'" + orderDoc.docAutor + "', " +
							"" + Conversion.DoubleToString(orderDoc.docSum) + ", " +
							"" + Conversion.DoubleToString(orderDoc.docVat) + ", " +
							"" + Conversion.DoubleToString(orderDoc.docTotal) + ", " +
							"'" + orderDoc.docPurchasePlan + "')");
						if(oleDbQuery.Execute()){
							/* Обновляем журнал Заказов */
							DataForms.FClient.updateHistory("Orders");
							Utilits.Console.Log("Ввод на основании: создан Заказ №" + orderDoc.docNumber  + " для План закупок №" + docPPNumber);
							
							/* Обновление номенклатуры ПЗ (добавляем номер документа Заказ) */
							if(oleDb.ExecuteUpdate("OrderNomenclature")){
								Utilits.Console.Log("Ввод на основании: План заказов №" + docPPNumber  + " обновлён.");
							}else{
								if(oleDb != null) oleDb.Dispose();
								if(oleDbQuery != null) oleDbQuery.Dispose();
								Utilits.Console.Log("[ОШИБКА] Ввод на основании: План закупок №" + docPPNumber + " не удалось одновить! Заказ №" + orderDoc.docNumber, false, true);
								MessageBox.Show("Не удалось обновить План закупок №" + docPPNumber + " Создание заказов прервано!", "Сообщение");
								return;
							}
							
						}else{
							if(oleDb != null) oleDb.Dispose();
							if(oleDbQuery != null) oleDbQuery.Dispose();
							Utilits.Console.Log("[ОШИБКА] Ввод на основании: Не удалось создать Заказ для План закупок №" + docPPNumber, false, true);
							MessageBox.Show("Не удалось создать Заказ для План закупок №" + docPPNumber, "Сообщение");
							return;
						}
						
					}else{
						if(oleDb != null) oleDb.Dispose();
						if(oleDbQuery != null) oleDbQuery.Dispose();
						Utilits.Console.Log("[ОШИБКА] Ввод на основании: Не удалось загрузить перечень номенклатуры из документа" + docPPNumber, false, true);
						MessageBox.Show("Не удалось загрузить перечень номенклатуры из документа" + docPPNumber + "" + Environment.NewLine + 
			                "Создание Заказов на основании Плана закупок невозможно!", "Сообщение");
						return;
					}
				}
				
			}catch(Exception ex){
				if(oleDb != null) oleDb.Dispose();
				if(oleDbQuery != null) oleDbQuery.Dispose();
				Utilits.Console.Log("[ОШИБКА] Ввод на основании: " + ex.Message, false, true);
			}
			
			if(oleDb != null) oleDb.Dispose();
			if(oleDbQuery != null) oleDbQuery.Dispose();
			MessageBox.Show("План закупок №" + docPPNumber + " был успешно обработан!" + Environment.NewLine + "Заказы созданы в соответствии с выбранными прайс-листами и номенклатурой! ", "Сообщение");
		}
		
		void createOrdersSqlServer()
		{
			Double sum = 0;
			Double amount = 0;
			Double price = 0;
			Double vat = 0;
			Double total = 0;
			
			SqlServer sqlServer = null;
			QuerySqlServer sqlQuery = null;
			
			OrderDoc orderDoc;
			
			try{
				sqlServer = new SqlServer();
				
				foreach(Price plist in priceList) // Обход прайсов
				{
					sum = 0;
					amount = 0;
					price = 0;
					vat = 0;
					total = 0;
					
					/* Создание основной информации документа заказ */
					orderDoc = new OrderDoc();
					orderDoc.docDate =  DateTime.Today.Date;
					orderDoc.docNumber = createDocNumber();
					orderDoc.docName = "Заказ";
					orderDoc.docCounteragent = plist.counteragentName;
					orderDoc.docAutor = DataConfig.userName;
					orderDoc.docSum = 0;
					orderDoc.docVat = 0;
					orderDoc.docTotal = 0;
					orderDoc.docPurchasePlan = docPPNumber;
					
					sqlServer = new SqlServer();
					sqlServer.sqlCommandSelect.CommandText = "SELECT " +
						"id, nomenclatureID, nomenclatureName, units, amount, " +
						"name, price, manufacturer, remainder, term, discount1, discount2, discount3, discount4, code, series, article, " +
						"counteragentName, counteragentPricelist, " +
						"docPurchasePlan, docOrder " +
						"FROM OrderNomenclature WHERE (docPurchasePlan = '" + docPPNumber + "' AND counteragentName = '" + plist.counteragentName + "')";
					
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
					
					if(sqlServer.ExecuteFill("OrderNomenclature")){ // получаем перечень номенклатуры ПЗ
						
						if(sqlServer.dataSet.Tables["OrderNomenclature"].Rows.Count <= 0) continue; // пропускаем (нет номенклатуры по данному контрагенту)
						
						foreach(DataRow row in sqlServer.dataSet.Tables["OrderNomenclature"].Rows){
							/* Привязываем к документу */
							row["docOrder"] = orderDoc.docNumber;
															
							/* Вычисления */
							price = (Double)row["price"];
							amount = (Double)row["amount"];
							sum += (price * amount);
						}
						
						/* Итоги вычислений */
						sum = Math.Round(sum, 2);
						vat = sum * DataConstants.ConstFirmVAT / 100;
						vat = Math.Round(vat, 2);
						total = sum + vat;
						total = Math.Round(total, 2);
						
						orderDoc.docSum = sum;
						orderDoc.docVat = vat;
						orderDoc.docTotal = total;
						
						
						/* Создаём новый заказ */
						sqlQuery = new QuerySqlServer(DataConfig.serverConnection);
						sqlQuery.SetCommand("INSERT INTO Orders " +
							"(docDate, docNumber, docName, docCounteragent, " +
							"docAutor, docSum, docVat, docTotal, docPurchasePlan) " +
							"VALUES ('" + orderDoc.docDate + "', " +
							"'" + orderDoc.docNumber + "', " +
							"'" + orderDoc.docName + "', " +
							"'" + orderDoc.docCounteragent + "', " +
							"'" + orderDoc.docAutor + "', " +
							"" + Conversion.DoubleToString(orderDoc.docSum) + ", " +
							"" + Conversion.DoubleToString(orderDoc.docVat) + ", " +
							"" + Conversion.DoubleToString(orderDoc.docTotal) + ", " +
							"'" + orderDoc.docPurchasePlan + "')");
						if(sqlQuery.Execute()){
							/* Обновляем журнал Заказов */
							DataForms.FClient.updateHistory("Orders");
							Utilits.Console.Log("Ввод на основании: создан Заказ №" + orderDoc.docNumber  + " для План закупок №" + docPPNumber);
							
							/* Обновление номенклатуры ПЗ (добавляем номер документа Заказ) */
							if(sqlServer.ExecuteUpdate("OrderNomenclature")){
								Utilits.Console.Log("Ввод на основании: План заказов №" + docPPNumber  + " обновлён.");
							}else{
								if(sqlServer != null) sqlServer.Dispose();
								if(sqlQuery != null) sqlQuery.Dispose();
								Utilits.Console.Log("[ОШИБКА] Ввод на основании: План закупок №" + docPPNumber + " не удалось одновить! Заказ №" + orderDoc.docNumber, false, true);
								MessageBox.Show("Не удалось обновить План закупок №" + docPPNumber + " Создание заказов прервано!", "Сообщение");
								return;
							}
							
						}else{
							if(sqlServer != null) sqlServer.Dispose();
							if(sqlQuery != null) sqlQuery.Dispose();
							Utilits.Console.Log("[ОШИБКА] Ввод на основании: Не удалось создать Заказ для План закупок №" + docPPNumber, false, true);
							MessageBox.Show("Не удалось создать Заказ для План закупок №" + docPPNumber, "Сообщение");
							return;
						}
						
					}else{
						if(sqlServer != null) sqlServer.Dispose();
						if(sqlQuery != null) sqlQuery.Dispose();
						Utilits.Console.Log("[ОШИБКА] Ввод на основании: Не удалось загрузить перечень номенклатуры из документа" + docPPNumber, false, true);
						MessageBox.Show("Не удалось загрузить перечень номенклатуры из документа" + docPPNumber + "" + Environment.NewLine + 
			                "Создание Заказов на основании Плана закупок невозможно!", "Сообщение");
						return;
					}
				}
				
			}catch(Exception ex){
				if(sqlServer != null) sqlServer.Dispose();
				if(sqlQuery != null) sqlQuery.Dispose();
				Utilits.Console.Log("[ОШИБКА] Ввод на основании: " + ex.Message, false, true);
			}
			
			if(sqlServer != null) sqlServer.Dispose();
			if(sqlQuery != null) sqlQuery.Dispose();
			MessageBox.Show("План закупок №" + docPPNumber + " был успешно обработан!" + Environment.NewLine + "Заказы созданы в соответствии с выбранными прайс-листами и номенклатурой! ", "Сообщение");
		}
	}
}
