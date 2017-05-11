/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 30.03.2017
 * Время: 9:14
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.OleDb;
using Aggregator.Data;
using Aggregator.Utilits;

namespace Aggregator.Database.Local
{
	/// <summary>
	/// Description of SearchNomenclatureOleDb.
	/// </summary>
	
	public class SearchNomenclatureOleDb
	{
		List<Price> priceList;
		List<Nomenclature> nomenclatureList;
		
		OleDbConnection oleDbConnection;
		OleDbCommand oleDbCommand;
		OleDbDataReader oleDbDataReader;
		
		public SearchNomenclatureOleDb()
		{
			priceList = new List<Price>();
			nomenclatureList = new List<Nomenclature>();
			oleDbConnection = new OleDbConnection();
			oleDbConnection.ConnectionString = DataConfig.oledbConnectLineBegin + DataConfig.localDatabase + DataConfig.oledbConnectLineEnd + DataConfig.oledbConnectPass;
		}
		
		public void setPrices(ListView listViewPrices)
		{
			priceList = new List<Price>();
			int count = listViewPrices.Items.Count;
			Price price;
			for(int i = 0; i < count; i++)
			{
				price.counteragentName = listViewPrices.Items[i].SubItems[1].Text;
				price.priceName = listViewPrices.Items[i].SubItems[2].Text;
				priceList.Add(price);
			}
		}
		
		public List<Nomenclature> getFindNomenclature(String nomenclatureID)
		{
			nomenclatureList = new List<Nomenclature>();
			
			String criteriasSearch = getCriteriasSearch(nomenclatureID);
			
			oleDbConnection.Open();
			foreach(Price price in priceList){
				oleDbCommand = new OleDbCommand("SELECT * FROM " + price.priceName + " " + criteriasSearch, oleDbConnection);

				oleDbDataReader = oleDbCommand.ExecuteReader();
				Nomenclature nomenclature;
		        while (oleDbDataReader.Read())
		        {
		        	nomenclature = new Nomenclature();
		        	nomenclature.Name = oleDbDataReader["name"].ToString();
		        	nomenclature.Code = oleDbDataReader["code"].ToString();
		        	nomenclature.Series = oleDbDataReader["series"].ToString();
		        	nomenclature.Article = oleDbDataReader["article"].ToString();
		        	nomenclature.Manufacturer = oleDbDataReader["manufacturer"].ToString();
		        	nomenclature.Units = DataConstants.ConstFirmUnits;
		        	nomenclature.Remainder = (Double)oleDbDataReader["remainder"];
		        	nomenclature.Price = (Double)oleDbDataReader["price"];
		        	nomenclature.Discount1 = (Double)oleDbDataReader["discount1"];
		        	nomenclature.Discount2 = (Double)oleDbDataReader["discount2"];
		        	nomenclature.Discount3 = (Double)oleDbDataReader["discount3"];
		        	nomenclature.Discount4 = (Double)oleDbDataReader["discount4"];
		        	nomenclature.Term = (DateTime)oleDbDataReader["term"];
		        	nomenclature.CounteragentName = price.counteragentName;
		        	nomenclature.CounteragentPrice = price.priceName;
		        	nomenclatureList.Add(nomenclature);
		        }
		        oleDbDataReader.Close();
			}

			oleDbConnection.Close();
			
			return nomenclatureList;
		}
		
		String getCriteriasSearch(String nomenclatureID)
		{
			/* Входные данные */
			oleDbConnection.Open();
			Nomenclature templeteNomenclature;
			oleDbCommand = new OleDbCommand("SELECT * FROM Nomenclature WHERE (id = " + nomenclatureID + ")", oleDbConnection);
			oleDbDataReader = oleDbCommand.ExecuteReader();
			oleDbDataReader.Read();
			templeteNomenclature.Name = oleDbDataReader["name"].ToString();
			templeteNomenclature.Code = oleDbDataReader["code"].ToString();
			templeteNomenclature.Series = oleDbDataReader["series"].ToString();
			templeteNomenclature.Article = oleDbDataReader["article"].ToString();
			templeteNomenclature.Manufacturer = oleDbDataReader["manufacturer"].ToString();
			templeteNomenclature.Price = (Double)oleDbDataReader["price"];
			templeteNomenclature.Units = oleDbDataReader["units"].ToString();
			oleDbDataReader.Close();
			oleDbConnection.Close();
						
			// Начало построения запроса
			String stringQuery = "WHERE ";
			
			// По Наименованию
			int count = 0;
			String str = "";
			String[] words =  templeteNomenclature.Name.Split();
			
			count = words.Length;
			if(count > 0){
				for(int i = 0; i < count; i++){
					if(words[i].ToString() == "" || words[i].ToString() == " ") continue;
					
					if(str.Length == 0) str += "(";
					else if(str[str.Length - 1].ToString() == ")") str += " OR (";
					else str += "(";
					
					for(int j = 0; j <= i; j++){
						if(words[j].ToString() == "" || words[j].ToString() == " ") continue;
						
						if(str[str.Length - 1].ToString() == "'") str += " AND name LIKE '%" + words[j] + "%'";
						else str += "name LIKE '%" + words[j] + "%'";
					}
					str += ")";
				}
			}
			
			str = str.Replace(".", "").Replace(",", "");
			if(str != "") {
				stringQuery += str;
				stringQuery += " OR ";
			}
			
			// По Коду, Серии, Артиклу
			str = "";
			str += "(code = '" + templeteNomenclature.Code + "' AND code <> '')"+
						" OR (series = '" + templeteNomenclature.Series + "' AND series <> '')"+
						" OR (article = '" + templeteNomenclature.Article + "' AND article <> '')";
			
			str = str.Replace(".", "").Replace(",", "");
			if(str != "") {
				stringQuery += str;
			}
			
			// Упорядочить
			stringQuery += " ORDER BY price ASC";
			
			return stringQuery;
		}
		
		bool checkIgnore(String str)
		{
			Regex rgx = new Regex(@"[0-9]"); //@"[a-zA-Z0-9]" 
			if(rgx.IsMatch(str)) return true;
			rgx = new Regex(@"[/,№,\\]");
			if(rgx.IsMatch(str)) return true;
			return false;
		}
		
		bool ignoreNumber(String str)
		{
			Regex rgx = new Regex(@"[0-9]");
			return rgx.IsMatch(str);
		}
		
		bool ignoreSymbol(String str)
		{
			Regex rgx = new Regex(@"[/,№,\\]");
			return rgx.IsMatch(str);
		}
		
		/* AUTOMATION ======================================================================= */
		public void autoFindNomenclature(ListView sourceListView, NotificationSearchNomenclature notification)
		{
			String criteriasSearch;
			String nomenclatureID;
			int count = sourceListView.Items.Count;
			bool result = false;
			DateTime dt;
			String value;
			
			for(int i = 0; i < count; i++) {
				// получаем сформированный запрос по критериям выбранной номенклатуры
				nomenclatureID = sourceListView.Items[i].SubItems[1].Text;
				criteriasSearch = getAutoCriteriasSearch(nomenclatureID);
				
				// обработка прайс листов по выбранной номенклатуре
				foreach(Price price in priceList){
					oleDbConnection.Open();
					oleDbCommand = new OleDbCommand("SELECT * FROM " + price.priceName + " " + criteriasSearch, oleDbConnection);
					oleDbDataReader = oleDbCommand.ExecuteReader();
					result = oleDbDataReader.Read();
			        
					if(result){
						sourceListView.Items[i].StateImageIndex = 1;
						sourceListView.Items[i].SubItems[6].Text = oleDbDataReader["name"].ToString();
						value = Conversion.StringToMoney(Conversion.StringToDouble(oleDbDataReader["price"].ToString()).ToString());
			        	sourceListView.Items[i].SubItems[7].Text = value;
			        	sourceListView.Items[i].SubItems[8].Text = oleDbDataReader["manufacturer"].ToString();
			        	sourceListView.Items[i].SubItems[9].Text = oleDbDataReader["remainder"].ToString();
			        	dt = new DateTime();
						DateTime.TryParse(oleDbDataReader["term"].ToString(), out dt);
						sourceListView.Items[i].SubItems[10].Text = dt.ToString("dd.MM.yyyy");
						value = Conversion.StringToMoney(Conversion.StringToDouble(oleDbDataReader["discount1"].ToString()).ToString());
			        	sourceListView.Items[i].SubItems[11].Text = value;
			        	value = Conversion.StringToMoney(Conversion.StringToDouble(oleDbDataReader["discount2"].ToString()).ToString());
			        	sourceListView.Items[i].SubItems[12].Text = value;
			        	value = Conversion.StringToMoney(Conversion.StringToDouble(oleDbDataReader["discount3"].ToString()).ToString());
			        	sourceListView.Items[i].SubItems[13].Text = value;
			        	value = Conversion.StringToMoney(Conversion.StringToDouble(oleDbDataReader["discount4"].ToString()).ToString());
			        	sourceListView.Items[i].SubItems[14].Text = value;
			        	sourceListView.Items[i].SubItems[15].Text = oleDbDataReader["code"].ToString();
			        	sourceListView.Items[i].SubItems[16].Text = oleDbDataReader["series"].ToString();
			        	sourceListView.Items[i].SubItems[17].Text = oleDbDataReader["article"].ToString();
			        	sourceListView.Items[i].SubItems[18].Text = price.counteragentName;
			        	sourceListView.Items[i].SubItems[19].Text = price.priceName;
			        	sourceListView.Items[i].SubItems[20].Text = "";
					}
			        oleDbDataReader.Close();
			        oleDbConnection.Close();
				}
				
				notification.MessageText("Пожалуйста подождите идет процесс обработки списка номенклатуры " + (i+1).ToString() + "/" + count.ToString());
				
				DataForms.FClient.messageInStatus("Пожалуйста подождите идет процесс обработки списка номенклатуры " + (i+1).ToString() + "/" + count.ToString());
				DataForms.FClient.Update();
				System.Threading.Thread.Sleep(50);
			}
			notification.Close();
			MessageBox.Show("Обработка списка номенклатуры - завершена!", "Сообщение");
		}
		
		String getAutoCriteriasSearch(String nomenclatureID)
		{
			// получаем данные выбранной номенклатуры
			oleDbConnection.Open();
			Nomenclature templeteNomenclature;
			oleDbCommand = new OleDbCommand("SELECT * FROM Nomenclature WHERE (id = " + nomenclatureID + ")", oleDbConnection);
			oleDbDataReader = oleDbCommand.ExecuteReader();
			oleDbDataReader.Read();
			templeteNomenclature.Name = oleDbDataReader["name"].ToString();
			templeteNomenclature.Code = oleDbDataReader["code"].ToString();
			templeteNomenclature.Series = oleDbDataReader["series"].ToString();
			templeteNomenclature.Article = oleDbDataReader["article"].ToString();
			templeteNomenclature.Manufacturer = oleDbDataReader["manufacturer"].ToString();
			templeteNomenclature.Price = (Double)oleDbDataReader["price"];
			templeteNomenclature.Units = oleDbDataReader["units"].ToString();
			oleDbDataReader.Close();
			oleDbConnection.Close();
			
			// формируем запрос
			String stringQuery = "WHERE ";
			
			String str = "";
			String[] words =  templeteNomenclature.Name.Split();
			int count = words.Length;
			int i = 0;
			for(i = 0; i < count; i++){
				if(i == 0) str += "(";
				if(words[i].Length > 2 && checkIgnore(words[i]) == false){
					if( i > 0) str += " AND ";
					str += "name LIKE '%" + words[i] + "%'";
				}
				if(ignoreNumber(words[i])){
					if( i > 0) str += " AND ";
					str += "name LIKE '%" + words[i] + "%'";
				}
				if(i == (count-1)) str += ")";
			}
			
			str = str.Replace(".", "%").Replace(",", "%");
			if(str != "") {
				stringQuery += str;
				stringQuery += " OR ";
			}
			
			stringQuery += "(code = '" + templeteNomenclature.Code + "' AND code <> '')"+
						" OR (series = '" + templeteNomenclature.Series + "' AND series <> '')"+
						" OR (article = '" + templeteNomenclature.Article + "' AND article <> '')";
			stringQuery += " ORDER BY price ASC";
			
			return stringQuery;
		}
		/*====================================================================================*/
		
		public List<Nomenclature> getAllNomenclature()
		{
			nomenclatureList = new List<Nomenclature>();
			
			oleDbConnection.Open();
			foreach(Price price in priceList){
				oleDbCommand = new OleDbCommand("SELECT * FROM " + price.priceName + " ORDER BY name ASC", oleDbConnection);
				
				oleDbDataReader = oleDbCommand.ExecuteReader();
				Nomenclature nomenclature;
		        while (oleDbDataReader.Read())
		        {
		        	nomenclature = new Nomenclature();
		        	nomenclature.Name = oleDbDataReader["name"].ToString();
		        	nomenclature.Code = oleDbDataReader["code"].ToString();
		        	nomenclature.Series = oleDbDataReader["series"].ToString();
		        	nomenclature.Article = oleDbDataReader["article"].ToString();
		        	nomenclature.Manufacturer = oleDbDataReader["manufacturer"].ToString();
		        	nomenclature.Units = DataConstants.ConstFirmUnits;
		        	nomenclature.Remainder = (Double)oleDbDataReader["remainder"];
		        	nomenclature.Price = (Double)oleDbDataReader["price"];
		        	nomenclature.Discount1 = (Double)oleDbDataReader["discount1"];
		        	nomenclature.Discount2 = (Double)oleDbDataReader["discount2"];
		        	nomenclature.Discount3 = (Double)oleDbDataReader["discount3"];
		        	nomenclature.Discount4 = (Double)oleDbDataReader["discount4"];
		        	nomenclature.Term = (DateTime)oleDbDataReader["term"];
		        	nomenclature.CounteragentName = price.counteragentName;
		        	nomenclature.CounteragentPrice = price.priceName;
		        	nomenclatureList.Add(nomenclature);
		        }
		        oleDbDataReader.Close();
			}

			oleDbConnection.Close();
			
			return nomenclatureList;
		}
		
		public List<Nomenclature> filterNomenclature(String value)
		{
			if(value == ""){
				MessageBox.Show("Фильтр не содержит данных!", "Предупреждение");
				return null;
			}
			
			String names = "";
			String[] words =  value.Split();
			int count = 0;
			count = words.Length;
			if(count > 0){
				for(int i = 0; i < count; i++){
					if(words[i].ToString() == "" || words[i].ToString() == " ")	continue;
					
					if(names.Length > 0) names += " OR ";
					names += "(name LIKE '%" + words[i] + "%')";
				}
			}			
			
			String strCommand = "";
			nomenclatureList = new List<Nomenclature>();
			
			oleDbConnection.Open();
			foreach(Price price in priceList){
				
				/*
				strCommand = "SELECT * FROM " + price.priceName + " WHERE (" +
						"name LIKE '%" + value + "%') " +
						"OR(code = '" + value + "' AND code <> '') "+
						"OR (series = '" + value + "' AND series <> '') "+
						"OR (article = '" + value + "' AND article <> '') "+
						"ORDER BY name ASC";
				*/
				strCommand = "SELECT * FROM " + price.priceName + " WHERE " + names +
						" OR (code = '" + value + "' AND code <> '')"+
						" OR (series = '" + value + "' AND series <> '')"+
						" OR (article = '" + value + "' AND article <> '')"+
						" ORDER BY name ASC";
				
				oleDbCommand = new OleDbCommand(strCommand, oleDbConnection);
				
				oleDbDataReader = oleDbCommand.ExecuteReader();
				Nomenclature nomenclature;
		        while (oleDbDataReader.Read())
		        {
		        	nomenclature = new Nomenclature();
		        	nomenclature.Name = oleDbDataReader["name"].ToString();
		        	nomenclature.Code = oleDbDataReader["code"].ToString();
		        	nomenclature.Series = oleDbDataReader["series"].ToString();
		        	nomenclature.Article = oleDbDataReader["article"].ToString();
		        	nomenclature.Manufacturer = oleDbDataReader["manufacturer"].ToString();
		        	nomenclature.Units = DataConstants.ConstFirmUnits;
		        	nomenclature.Remainder = (Double)oleDbDataReader["remainder"];
		        	nomenclature.Price = (Double)oleDbDataReader["price"];
		        	nomenclature.Discount1 = (Double)oleDbDataReader["discount1"];
		        	nomenclature.Discount2 = (Double)oleDbDataReader["discount2"];
		        	nomenclature.Discount3 = (Double)oleDbDataReader["discount3"];
		        	nomenclature.Discount4 = (Double)oleDbDataReader["discount4"];
		        	nomenclature.Term = (DateTime)oleDbDataReader["term"];
		        	nomenclature.CounteragentName = price.counteragentName;
		        	nomenclature.CounteragentPrice = price.priceName;
		        	nomenclatureList.Add(nomenclature);
		        }
		        oleDbDataReader.Close();
			}

			oleDbConnection.Close();
			
			return nomenclatureList;
		}
	}
}
