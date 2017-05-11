/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 14.04.2017
 * Время: 7:09
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows.Forms;
using Aggregator.Data;
using Aggregator.Utilits;

namespace Aggregator.Client.Documents.Order
{
	/// <summary>
	/// Description of FormOrderNomenclature.
	/// </summary>
	public partial class FormOrderNomenclature : Form
	{
		public FormOrderNomenclature()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		int searchStep = 0;
		struct SearchResult {
			public String value;	// значение поиска
			public int position;	// позиция найденного значения
		}
		List<SearchResult> searchResultList;
		
		public ListView ListViewReturnValue;
		public String Counteragent;
		String priceName = "";
		
		OleDbConnection oleDbConnection;
		OleDbCommand oleDbCommand;
		OleDbDataReader oleDbDataReader;
		
		SqlConnection sqlConnection;
		SqlCommand sqlCommand;
		SqlDataReader sqlDataReader;
		
		public void loadNomenclature()
		{
			DateTime dt;
			ListViewItem ListViewItem_add;
			
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				oleDbConnection = new OleDbConnection();
				oleDbConnection.ConnectionString = DataConfig.oledbConnectLineBegin + 
													DataConfig.localDatabase + 
													DataConfig.oledbConnectLineEnd + 
													DataConfig.oledbConnectPass;
				oleDbConnection.Open();
				oleDbCommand = new OleDbCommand("SELECT * FROM Counteragents WHERE (name = '" + Counteragent + "')", oleDbConnection);
				oleDbDataReader = oleDbCommand.ExecuteReader();
				if(oleDbDataReader.Read()){
					priceName = oleDbDataReader["excel_table_id"].ToString();
				}else{
					MessageBox.Show("Контрагент " + "\"" + Counteragent + "\"" + " не существует в справочнике контрагентов.", "Сообщение");
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
						ListViewItem_add.SubItems.Add(oleDbDataReader["price"].ToString());
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
						ListViewItem_add.SubItems.Add(Counteragent);
						ListViewItem_add.SubItems.Add(priceName);
						listView1.Items.Add(ListViewItem_add);
					}
					oleDbDataReader.Close();
				}else{
					MessageBox.Show("Контрагент " + Counteragent + " не содержит прайс-листа.", "Сообщение");
				}
				oleDbConnection.Close();
			}else if(DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				sqlConnection = new SqlConnection(DataConfig.serverConnection);
				sqlConnection.Open();
				sqlCommand = new SqlCommand("SELECT * FROM Counteragents WHERE (name = '" + Counteragent + "')", sqlConnection);
				sqlDataReader = sqlCommand.ExecuteReader();
				if(sqlDataReader.Read()){
					priceName = sqlDataReader["excel_table_id"].ToString();
				}else{
					MessageBox.Show("Контрагент " + "\"" + Counteragent + "\"" + " не существует в справочнике контрагентов.", "Сообщение");
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
						ListViewItem_add.SubItems.Add(sqlDataReader["price"].ToString());
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
						ListViewItem_add.SubItems.Add(Counteragent);
						ListViewItem_add.SubItems.Add(priceName);
						listView1.Items.Add(ListViewItem_add);
					}
					sqlDataReader.Close();
				}else{
					MessageBox.Show("Контрагент " + Counteragent + " не содержит прайс-листа.", "Сообщение");
				}
				sqlConnection.Close();
			}
		}
		
		void searchValues()
		{
			SearchResult searchResult;
			String str;
			searchResultList = new List<SearchResult>();
			for(int i = 0; i < listView1.Items.Count; i++){
				str = listView1.Items[i].SubItems[1].Text;
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
			
			listView1.FocusedItem = listView1.Items[searchResultList[searchStep].position];
			listView1.Items[searchResultList[searchStep].position].Selected = true;
			listView1.Select();
			listView1.EnsureVisible(searchResultList[searchStep].position);
		}
		
		bool returnValue()
		{
			if(listView1.Items.Count == 0) return false;
			
			DateTime dt;
			ListViewItem ListViewItem_add;
			int selectLineIndex;
			
			if(listView1.SelectedIndices.Count > 0){
				
				selectLineIndex = listView1.SelectedItems[0].Index;
				
				ListViewItem_add = new ListViewItem();
				/*Наимен. */ ListViewItem_add.SubItems.Add(listView1.Items[selectLineIndex].SubItems[1].Text);
				/*Картинка*/ ListViewItem_add.StateImageIndex = 0;
				/*Ед.изм. */ ListViewItem_add.SubItems.Add(DataConstants.ConstFirmUnits);
				/*Кол-во  */ ListViewItem_add.SubItems.Add("0,00");
				/*Цена    */ ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(listView1.Items[selectLineIndex].SubItems[2].Text).ToString()));
				/*НДС     */ ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble("0").ToString()));
				/*Сумма   */ ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble("0").ToString()));
				/*Производ*/ ListViewItem_add.SubItems.Add(listView1.Items[selectLineIndex].SubItems[3].Text);
				/*Остаток */ ListViewItem_add.SubItems.Add(listView1.Items[selectLineIndex].SubItems[4].Text);
				/*Срок год*/
				dt = new DateTime();
				DateTime.TryParse(listView1.Items[selectLineIndex].SubItems[5].Text, out dt);
				ListViewItem_add.SubItems.Add(dt.ToString("dd.MM.yyyy"));
				/*Скидки  */
				ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(listView1.Items[selectLineIndex].SubItems[6].Text).ToString()));
				ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(listView1.Items[selectLineIndex].SubItems[7].Text).ToString()));
				ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(listView1.Items[selectLineIndex].SubItems[8].Text).ToString()));
				ListViewItem_add.SubItems.Add(Conversion.StringToMoney(Conversion.StringToDouble(listView1.Items[selectLineIndex].SubItems[9].Text).ToString()));
				/*Код тов.*/ ListViewItem_add.SubItems.Add(listView1.Items[selectLineIndex].SubItems[10].Text);
				/*Серия т.*/ ListViewItem_add.SubItems.Add(listView1.Items[selectLineIndex].SubItems[11].Text);
				/*Артикул */ ListViewItem_add.SubItems.Add(listView1.Items[selectLineIndex].SubItems[12].Text);
				/*Контраг.*/ ListViewItem_add.SubItems.Add(listView1.Items[selectLineIndex].SubItems[13].Text);
				/*Прайс л.*/ ListViewItem_add.SubItems.Add(listView1.Items[selectLineIndex].SubItems[14].Text);
				/*№       */ ListViewItem_add.SubItems.Add("");
				ListViewReturnValue.Items.Add(ListViewItem_add);
				
				return true;
			}
			return false;
		}
		
		/* =================================================================================================
		 * РАЗДЕЛ: СОБЫТИЙ
		 * =================================================================================================
		 */	
		void FormOrderNomenclatureLoad(object sender, EventArgs e)
		{
			Utilits.Console.Log(this.Text + ": открыт");
		}
		void FormOrderNomenclatureFormClosed(object sender, FormClosedEventArgs e)
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				oleDbDataReader.Close();
				oleDbConnection.Close();
				oleDbCommand.Dispose();
				oleDbConnection.Dispose();
			}
			if(DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				sqlDataReader.Close();
				sqlConnection.Close();
				sqlCommand.Dispose();
				sqlConnection.Dispose();
			}
			DataForms.FClient.messageInStatus("...");
			Utilits.Console.Log(Text + ": закрыт.");
			Dispose();
		}
		void ListView1SelectedIndexChanged(object sender, EventArgs e)
		{
			if(listView1.SelectedItems.Count > 0){
				label1.Text = listView1.Items[listView1.SelectedItems[0].Index].SubItems[1].Text;
			}
		}
		void FindButtonClick(object sender, EventArgs e)
		{
			search();
		}
		void TextBox1KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyData == Keys.Enter){
				search();
			}
		}
		void ButtonCancelClick(object sender, EventArgs e)
		{
			Close();
		}
		void ButtonSaveClick(object sender, EventArgs e)
		{
			if(returnValue()) Close();
		}
		void ВыбратьНоменклатуруToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(returnValue()) Close();
		}
		void FormOrderNomenclatureActivated(object sender, EventArgs e)
		{
			DataForms.FClient.messageInStatus(this.Text);
		}
	}
}
