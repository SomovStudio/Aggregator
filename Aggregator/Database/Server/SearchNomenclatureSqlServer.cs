/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 08.04.2017
 * Время: 8:03
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;
using Aggregator.Data;
using Aggregator.Database.Local;
using Aggregator.Utilits;

namespace Aggregator.Database.Server
{
	/// <summary>
	/// Description of SearchNomenclatureSqlServer.
	/// </summary>
	
	public class SearchNomenclatureSqlServer
	{
        public const string MIN_PRICE = "По минимальным ценам";
        public const string MAX_PRICE = "По максимальным ценам";

        List<Price> priceList;
		List<Nomenclature> nomenclatureList;
		
		SqlConnection sqlConnection;
		SqlCommand sqlCommand;
		SqlDataReader sqlDataReader;
		
		public SearchNomenclatureSqlServer()
		{
			priceList = new List<Price>();
			nomenclatureList = new List<Nomenclature>();
			sqlConnection = new SqlConnection(DataConfig.serverConnection);
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

            String query = "";

			foreach(Price price in priceList){
                query = getQuery(nomenclatureID, price.priceName);

                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
				Nomenclature nomenclature;
		        while (sqlDataReader.Read())
		        {
		        	nomenclature = new Nomenclature();
		        	nomenclature.Name = sqlDataReader["name"].ToString();
		        	nomenclature.Code = sqlDataReader["code"].ToString();
		        	nomenclature.Series = sqlDataReader["series"].ToString();
		        	nomenclature.Article = sqlDataReader["article"].ToString();
		        	nomenclature.Manufacturer = sqlDataReader["manufacturer"].ToString();
		        	nomenclature.Units = DataConstants.ConstFirmUnits;
		        	nomenclature.Remainder = (Double)sqlDataReader["remainder"];
		        	nomenclature.Price = (Double)sqlDataReader["price"];
		        	nomenclature.Discount1 = (Double)sqlDataReader["discount1"];
		        	nomenclature.Discount2 = (Double)sqlDataReader["discount2"];
		        	nomenclature.Discount3 = (Double)sqlDataReader["discount3"];
		        	nomenclature.Discount4 = (Double)sqlDataReader["discount4"];
		        	nomenclature.Term = (DateTime)sqlDataReader["term"];
		        	nomenclature.CounteragentName = price.counteragentName;
		        	nomenclature.CounteragentPrice = price.priceName;
					nomenclature.Relevance = sqlDataReader["relevance"].ToString();
                    nomenclatureList.Add(nomenclature);
		        }
		        sqlDataReader.Close();
                sqlConnection.Close();
            }

            nomenclatureList.Sort((p1, p2) => p2.Relevance.CompareTo(p1.Relevance));

            return nomenclatureList;
		}

        String getQuery(String nomenclatureID, String pricename)
		{
            /* Входные данные */
            sqlConnection.Open();
            Nomenclature templeteNomenclature;
            sqlCommand = new SqlCommand("SELECT * FROM Nomenclature WHERE (id = " + nomenclatureID + ")", sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            sqlDataReader.Read();
            templeteNomenclature.Name = sqlDataReader["name"].ToString();
            templeteNomenclature.Code = sqlDataReader["code"].ToString();
            templeteNomenclature.Series = sqlDataReader["series"].ToString();
            templeteNomenclature.Article = sqlDataReader["article"].ToString();
            templeteNomenclature.Manufacturer = sqlDataReader["manufacturer"].ToString();
            templeteNomenclature.Price = (Double)sqlDataReader["price"];
            templeteNomenclature.Units = sqlDataReader["units"].ToString();
            sqlDataReader.Close();
            sqlConnection.Close();

            // По Наименованию
            int count = 0;
            String str = "SELECT *," + Environment.NewLine;

            String[] words = templeteNomenclature.Name.Split();
            count = words.Length;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (words[i].ToString() == "" || words[i].ToString() == " ") continue;
                    str += "IIF(LOWER([name]) LIKE '%" + words[i].ToLower() + "%', 1, 0)";
                    if ((i + 1) < count) str += " +" + Environment.NewLine;
                }
                str += " AS relevance" + Environment.NewLine;
                str += "FROM " + pricename + Environment.NewLine;
                str += "WHERE" + Environment.NewLine;
                for (int j = 0; j < count; j++)
                {
                    if (words[j].ToString() == "" || words[j].ToString() == " ") continue;
                    str += "LOWER([name]) LIKE '%" + words[j].ToLower() + "%'";
                    if ((j + 1) < count) str += " OR" + Environment.NewLine;
                }
                str += "ORDER BY" + Environment.NewLine;
                for (int k = 0; k < count; k++)
                {
                    if (words[k].ToString() == "" || words[k].ToString() == " ") continue;
                    str += "IIF(LOWER([name]) LIKE '%" + words[k].ToLower() + "%', 1, 0)";
                    if ((k + 1) < count) str += " +" + Environment.NewLine;
                }
                str += " DESC";
            }
            return str;
        }

        String getCriteriasSearch(String nomenclatureID)
		{
			/* Входные данные */
			sqlConnection.Open();
			Nomenclature templeteNomenclature;
			sqlCommand = new SqlCommand("SELECT * FROM Nomenclature WHERE (id = " + nomenclatureID + ")", sqlConnection);
			sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			templeteNomenclature.Name = sqlDataReader["name"].ToString();
			templeteNomenclature.Code = sqlDataReader["code"].ToString();
			templeteNomenclature.Series = sqlDataReader["series"].ToString();
			templeteNomenclature.Article = sqlDataReader["article"].ToString();
			templeteNomenclature.Manufacturer = sqlDataReader["manufacturer"].ToString();
			templeteNomenclature.Price = (Double)sqlDataReader["price"];
			templeteNomenclature.Units = sqlDataReader["units"].ToString();
			sqlDataReader.Close();
			sqlConnection.Close();
			
			
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
		public void autoFindNomenclature(ListView sourceListView, string filterPrice, NotificationSearchNomenclature notification)
		{
			String criteriasSearch;
			String nomenclatureID;
			int count = sourceListView.Items.Count;
			bool result = false;
			DateTime dt;
			String value;
            Double lastPrice = 0;

            for (int i = 0; i < count; i++) {
				// получаем сформированный запрос по критериям выбранной номенклатуры
				nomenclatureID = sourceListView.Items[i].SubItems[1].Text;
				criteriasSearch = getAutoCriteriasSearch(nomenclatureID);

                lastPrice = 0;

                // обработка прайс листов по выбранной номенклатуре
                foreach (Price price in priceList){
					sqlConnection.Open();
					sqlCommand = new SqlCommand("SELECT * FROM " + price.priceName + " " + criteriasSearch, sqlConnection);
					sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
					{
                        if (filterPrice == MIN_PRICE && lastPrice > 0 && lastPrice < Conversion.StringToDouble(sqlDataReader["price"].ToString()))
                        {
                            continue;
                        }
                        else if (filterPrice == MAX_PRICE && lastPrice > 0 && lastPrice > Conversion.StringToDouble(sqlDataReader["price"].ToString()))
                        {
                            continue;
                        }
						else
						{
                            sourceListView.Items[i].StateImageIndex = 1;
                            sourceListView.Items[i].SubItems[6].Text = sqlDataReader["name"].ToString();
                            value = Conversion.StringToMoney(Conversion.StringToDouble(sqlDataReader["price"].ToString()).ToString());
                            sourceListView.Items[i].SubItems[7].Text = value;
                            sourceListView.Items[i].SubItems[8].Text = sqlDataReader["manufacturer"].ToString();
                            sourceListView.Items[i].SubItems[9].Text = sqlDataReader["remainder"].ToString();
                            dt = new DateTime();
                            DateTime.TryParse(sqlDataReader["term"].ToString(), out dt);
                            sourceListView.Items[i].SubItems[10].Text = dt.ToString("dd.MM.yyyy");
                            value = Conversion.StringToMoney(Conversion.StringToDouble(sqlDataReader["discount1"].ToString()).ToString());
                            sourceListView.Items[i].SubItems[11].Text = value;
                            value = Conversion.StringToMoney(Conversion.StringToDouble(sqlDataReader["discount2"].ToString()).ToString());
                            sourceListView.Items[i].SubItems[12].Text = value;
                            value = Conversion.StringToMoney(Conversion.StringToDouble(sqlDataReader["discount3"].ToString()).ToString());
                            sourceListView.Items[i].SubItems[13].Text = value;
                            value = Conversion.StringToMoney(Conversion.StringToDouble(sqlDataReader["discount4"].ToString()).ToString());
                            sourceListView.Items[i].SubItems[14].Text = value;
                            sourceListView.Items[i].SubItems[15].Text = sqlDataReader["code"].ToString();
                            sourceListView.Items[i].SubItems[16].Text = sqlDataReader["series"].ToString();
                            sourceListView.Items[i].SubItems[17].Text = sqlDataReader["article"].ToString();
                            sourceListView.Items[i].SubItems[18].Text = price.counteragentName;
                            sourceListView.Items[i].SubItems[19].Text = price.priceName;
                            sourceListView.Items[i].SubItems[20].Text = "";
                            lastPrice = Conversion.StringToDouble(sqlDataReader["price"].ToString());
                        }
                    }

			        sqlDataReader.Close();
			        sqlConnection.Close();
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
			sqlConnection.Open();
			Nomenclature templeteNomenclature;
			sqlCommand = new SqlCommand("SELECT * FROM Nomenclature WHERE (id = " + nomenclatureID + ")", sqlConnection);
			sqlDataReader = sqlCommand.ExecuteReader();
			sqlDataReader.Read();
			templeteNomenclature.Name = sqlDataReader["name"].ToString();
			templeteNomenclature.Code = sqlDataReader["code"].ToString();
			templeteNomenclature.Series = sqlDataReader["series"].ToString();
			templeteNomenclature.Article = sqlDataReader["article"].ToString();
			templeteNomenclature.Manufacturer = sqlDataReader["manufacturer"].ToString();
			templeteNomenclature.Price = (Double)sqlDataReader["price"];
			templeteNomenclature.Units = sqlDataReader["units"].ToString();
			sqlDataReader.Close();
			sqlConnection.Close();
			
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
			
			sqlConnection.Open();
			foreach(Price price in priceList){
				sqlCommand = new SqlCommand("SELECT * FROM " + price.priceName + " ORDER BY name ASC", sqlConnection);
				
				sqlDataReader = sqlCommand.ExecuteReader();
				Nomenclature nomenclature;
		        while (sqlDataReader.Read())
		        {
		        	nomenclature = new Nomenclature();
		        	nomenclature.Name = sqlDataReader["name"].ToString();
		        	nomenclature.Code = sqlDataReader["code"].ToString();
		        	nomenclature.Series = sqlDataReader["series"].ToString();
		        	nomenclature.Article = sqlDataReader["article"].ToString();
		        	nomenclature.Manufacturer = sqlDataReader["manufacturer"].ToString();
		        	nomenclature.Units = DataConstants.ConstFirmUnits;
		        	nomenclature.Remainder = (Double)sqlDataReader["remainder"];
		        	nomenclature.Price = (Double)sqlDataReader["price"];
		        	nomenclature.Discount1 = (Double)sqlDataReader["discount1"];
		        	nomenclature.Discount2 = (Double)sqlDataReader["discount2"];
		        	nomenclature.Discount3 = (Double)sqlDataReader["discount3"];
		        	nomenclature.Discount4 = (Double)sqlDataReader["discount4"];
		        	nomenclature.Term = (DateTime)sqlDataReader["term"];
		        	nomenclature.CounteragentName = price.counteragentName;
		        	nomenclature.CounteragentPrice = price.priceName;
		        	nomenclatureList.Add(nomenclature);
		        }
		        sqlDataReader.Close();
			}

			sqlConnection.Close();
			
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
			
			sqlConnection.Open();
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
				
				sqlCommand = new SqlCommand(strCommand, sqlConnection);
				
				sqlDataReader = sqlCommand.ExecuteReader();
				Nomenclature nomenclature;
		        while (sqlDataReader.Read())
		        {
		        	nomenclature = new Nomenclature();
		        	nomenclature.Name = sqlDataReader["name"].ToString();
		        	nomenclature.Code = sqlDataReader["code"].ToString();
		        	nomenclature.Series = sqlDataReader["series"].ToString();
		        	nomenclature.Article = sqlDataReader["article"].ToString();
		        	nomenclature.Manufacturer = sqlDataReader["manufacturer"].ToString();
		        	nomenclature.Units = DataConstants.ConstFirmUnits;
		        	nomenclature.Remainder = (Double)sqlDataReader["remainder"];
		        	nomenclature.Price = (Double)sqlDataReader["price"];
		        	nomenclature.Discount1 = (Double)sqlDataReader["discount1"];
		        	nomenclature.Discount2 = (Double)sqlDataReader["discount2"];
		        	nomenclature.Discount3 = (Double)sqlDataReader["discount3"];
		        	nomenclature.Discount4 = (Double)sqlDataReader["discount4"];
		        	nomenclature.Term = (DateTime)sqlDataReader["term"];
		        	nomenclature.CounteragentName = price.counteragentName;
		        	nomenclature.CounteragentPrice = price.priceName;
		        	nomenclatureList.Add(nomenclature);
		        }
		        sqlDataReader.Close();
			}

			sqlConnection.Close();
			
			return nomenclatureList;
		}
	}
}
