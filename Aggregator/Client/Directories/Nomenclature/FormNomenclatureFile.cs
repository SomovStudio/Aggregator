/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 17.03.2017
 * Время: 9:44
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.Sql;
using System.Drawing;
using System.Windows.Forms;
using Aggregator.Data;
using Aggregator.Database.Local;
using Aggregator.Database.Server;
using Aggregator.Utilits;

namespace Aggregator.Client.Directories
{
	/// <summary>
	/// Description of FormNomenclatureFile.
	/// </summary>
	public partial class FormNomenclatureFile : Form
	{
		public FormNomenclatureFile()
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
		public String ParentFolder;
		
		OleDb oleDb;
		SqlServer sqlServer;
		
		void getFolders()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				// OLEDB
				oleDb = new OleDb(DataConfig.localDatabase);
				oleDb.oleDbCommandSelect.CommandText = "SELECT name FROM Nomenclature WHERE (type = '" + DataConstants.FOLDER +"')";
				if(oleDb.ExecuteFill("Nomenclature")){
					foldersComboBox.Items.Clear();
					foreach(DataRow row in oleDb.dataSet.Tables["Nomenclature"].Rows){
						foldersComboBox.Items.Add(row["name"].ToString());
					}
				}
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				sqlServer = new SqlServer();
				sqlServer.sqlCommandSelect.CommandText = "SELECT name FROM Nomenclature WHERE (type = '" + DataConstants.FOLDER +"')";
				if(sqlServer.ExecuteFill("Nomenclature")){
					foldersComboBox.Items.Clear();
					foreach(DataRow row in sqlServer.dataSet.Tables["Nomenclature"].Rows){
						foldersComboBox.Items.Add(row["name"].ToString());
					}
				}
			}
		}
		
		void open()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				// OLEDB
				oleDb = new OleDb(DataConfig.localDatabase);
				oleDb.oleDbCommandSelect.CommandText = "SELECT id, name, type, " +
					"code, series, article, manufacturer, price, units, parent " +
					"FROM Nomenclature WHERE (id = " + ID + ")";
				if(oleDb.ExecuteFill("Nomenclature")){
					idTextBox.Text = oleDb.dataSet.Tables["Nomenclature"].Rows[0]["id"].ToString();
					nameTextBox.Text = oleDb.dataSet.Tables["Nomenclature"].Rows[0]["name"].ToString();
					codeTextBox.Text = oleDb.dataSet.Tables["Nomenclature"].Rows[0]["code"].ToString();
					seriesTextBox.Text = oleDb.dataSet.Tables["Nomenclature"].Rows[0]["series"].ToString();
					articleTextBox.Text = oleDb.dataSet.Tables["Nomenclature"].Rows[0]["article"].ToString();
					manufacturerTextBox.Text = oleDb.dataSet.Tables["Nomenclature"].Rows[0]["manufacturer"].ToString();
					priceTextBox.Text = oleDb.dataSet.Tables["Nomenclature"].Rows[0]["price"].ToString();
					String Value = priceTextBox.Text;
					priceTextBox.Clear();
					priceTextBox.Text = Conversion.StringToMoney(Math.Round(Conversion.StringToDouble(Value), 2).ToString());
					if(priceTextBox.Text == "" || Conversion.checkString(priceTextBox.Text) == false) priceTextBox.Text = "0,00";
					unitsTextBox.Text = oleDb.dataSet.Tables["Nomenclature"].Rows[0]["units"].ToString();
				}				
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER && DataConfig.typeDatabase == DataConstants.TYPE_MSSQL){
				// MSSQL SERVER
				sqlServer = new SqlServer();
				sqlServer.sqlCommandSelect.CommandText = "SELECT id, name, type, " +
					"code, series, article, manufacturer, price, units, parent " +
					"FROM Nomenclature WHERE (id = " + ID + ")";
				if(sqlServer.ExecuteFill("Nomenclature")){
					idTextBox.Text = sqlServer.dataSet.Tables["Nomenclature"].Rows[0]["id"].ToString();
					nameTextBox.Text = sqlServer.dataSet.Tables["Nomenclature"].Rows[0]["name"].ToString();
					codeTextBox.Text = sqlServer.dataSet.Tables["Nomenclature"].Rows[0]["code"].ToString();
					seriesTextBox.Text = sqlServer.dataSet.Tables["Nomenclature"].Rows[0]["series"].ToString();
					articleTextBox.Text = sqlServer.dataSet.Tables["Nomenclature"].Rows[0]["article"].ToString();
					manufacturerTextBox.Text = sqlServer.dataSet.Tables["Nomenclature"].Rows[0]["manufacturer"].ToString();
					priceTextBox.Text = sqlServer.dataSet.Tables["Nomenclature"].Rows[0]["price"].ToString();
					String Value = priceTextBox.Text;
					priceTextBox.Clear();
					priceTextBox.Text = Conversion.StringToMoney(Math.Round(Conversion.StringToDouble(Value), 2).ToString());
					if(priceTextBox.Text == "" || Conversion.checkString(priceTextBox.Text) == false) priceTextBox.Text = "0,00";
					unitsTextBox.Text = sqlServer.dataSet.Tables["Nomenclature"].Rows[0]["units"].ToString();
				}				
			}
		}
		
		void saveNew()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				// OLEDB
				oleDb = new OleDb(DataConfig.localDatabase);
				oleDb.oleDbCommandSelect.CommandText = "SELECT id, name, type, " +
					"code, series, article, manufacturer, price, units, parent " +
					"FROM Nomenclature WHERE (id = 0)";
				oleDb.ExecuteFill("Nomenclature");				
				
				DataRow newRow = oleDb.dataSet.Tables["Nomenclature"].NewRow();
				newRow["name"] = nameTextBox.Text;
				newRow["type"] = DataConstants.FILE;
				newRow["code"] = codeTextBox.Text;
				newRow["series"] = seriesTextBox.Text;
				newRow["article"] = articleTextBox.Text;
				newRow["manufacturer"] = manufacturerTextBox.Text;
				newRow["price"] = priceTextBox.Text;
				newRow["units"] = unitsTextBox.Text;				
				newRow["parent"] = foldersComboBox.Text;
				oleDb.dataSet.Tables["Nomenclature"].Rows.Add(newRow);
				
				oleDb.oleDbCommandInsert.CommandText = "INSERT INTO Nomenclature " +
					"(name, type, code, series, article, manufacturer, price, units, parent) " +
					"VALUES (@name, @type, @code, @series, @article, @manufacturer, @price, @units, @parent)";
				oleDb.oleDbCommandInsert.Parameters.Add("@name", OleDbType.VarChar, 255, "name");
				oleDb.oleDbCommandInsert.Parameters.Add("@type", OleDbType.VarChar, 255, "type");
				oleDb.oleDbCommandInsert.Parameters.Add("@code", OleDbType.VarChar, 255, "code");
				oleDb.oleDbCommandInsert.Parameters.Add("@series", OleDbType.VarChar, 255, "series");
				oleDb.oleDbCommandInsert.Parameters.Add("@article", OleDbType.VarChar, 255, "article");
				oleDb.oleDbCommandInsert.Parameters.Add("@manufacturer", OleDbType.VarChar, 255, "manufacturer");
				oleDb.oleDbCommandInsert.Parameters.Add("@price", OleDbType.Double, 15, "price");
				oleDb.oleDbCommandInsert.Parameters.Add("@units", OleDbType.VarChar, 255, "units");
				oleDb.oleDbCommandInsert.Parameters.Add("@parent", OleDbType.VarChar, 255, "parent");
				if(oleDb.ExecuteUpdate("Nomenclature")){
					DataForms.FClient.updateHistory("Nomenclature");
					Utilits.Console.Log("Создана новая номенклатура.");
					Close();
				}else{
					oleDb.Error();
					Utilits.Console.Log("[ОШИБКА] Ошибка создания новой номенклатуры.");
				}
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				sqlServer = new SqlServer();
				sqlServer.sqlCommandSelect.CommandText = "SELECT id, name, type, " +
					"code, series, article, manufacturer, price, units, parent " +
					"FROM Nomenclature WHERE (id = 0)";
				sqlServer.ExecuteFill("Nomenclature");				
				
				DataRow newRow = sqlServer.dataSet.Tables["Nomenclature"].NewRow();
				newRow["name"] = nameTextBox.Text;
				newRow["type"] = DataConstants.FILE;
				newRow["code"] = codeTextBox.Text;
				newRow["series"] = seriesTextBox.Text;
				newRow["article"] = articleTextBox.Text;
				newRow["manufacturer"] = manufacturerTextBox.Text;
				newRow["price"] = priceTextBox.Text;
				newRow["units"] = unitsTextBox.Text;				
				newRow["parent"] = foldersComboBox.Text;
				sqlServer.dataSet.Tables["Nomenclature"].Rows.Add(newRow);
								
				sqlServer.sqlCommandInsert.CommandText = "INSERT INTO Nomenclature " +
					"(name, type, code, series, article, manufacturer, price, units, parent) " +
					"VALUES (@name, @type, @code, @series, @article, @manufacturer, @price, @units, @parent)";
				sqlServer.sqlCommandInsert.Parameters.Add("@name", SqlDbType.VarChar, 255, "name");
				sqlServer.sqlCommandInsert.Parameters.Add("@type", SqlDbType.VarChar, 255, "type");
				sqlServer.sqlCommandInsert.Parameters.Add("@code", SqlDbType.VarChar, 255, "code");
				sqlServer.sqlCommandInsert.Parameters.Add("@series", SqlDbType.VarChar, 255, "series");
				sqlServer.sqlCommandInsert.Parameters.Add("@article", SqlDbType.VarChar, 255, "article");
				sqlServer.sqlCommandInsert.Parameters.Add("@manufacturer", SqlDbType.VarChar, 255, "manufacturer");
				sqlServer.sqlCommandInsert.Parameters.Add("@price", SqlDbType.Float, 15, "price");
				sqlServer.sqlCommandInsert.Parameters.Add("@units", SqlDbType.VarChar, 255, "units");
				sqlServer.sqlCommandInsert.Parameters.Add("@parent", SqlDbType.VarChar, 255, "parent");
				if(sqlServer.ExecuteUpdate("Nomenclature")){
					DataForms.FClient.updateHistory("Nomenclature");
					Utilits.Console.Log("Создана новая номенклатура.");
					Close();
				}else{
					sqlServer.Error();
					Utilits.Console.Log("[ОШИБКА] Ошибка создания новой номенклатуры.");
				}
			}
		}
		
		void saveEdit()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				// OLEDB
				oleDb = new OleDb(DataConfig.localDatabase);
				oleDb.oleDbCommandSelect.CommandText = "SELECT id, name, type, " +
					"code, series, article, manufacturer, price, units, parent " +
					"FROM Nomenclature WHERE (id = " + ID +")";
				oleDb.ExecuteFill("Nomenclature");	
				oleDb.dataSet.Tables["Nomenclature"].Rows[0]["name"] = nameTextBox.Text;
				oleDb.dataSet.Tables["Nomenclature"].Rows[0]["type"] = DataConstants.FILE;
				oleDb.dataSet.Tables["Nomenclature"].Rows[0]["code"] = codeTextBox.Text;
				oleDb.dataSet.Tables["Nomenclature"].Rows[0]["series"] = seriesTextBox.Text;
				oleDb.dataSet.Tables["Nomenclature"].Rows[0]["article"] = articleTextBox.Text;
				oleDb.dataSet.Tables["Nomenclature"].Rows[0]["manufacturer"] = manufacturerTextBox.Text;
				oleDb.dataSet.Tables["Nomenclature"].Rows[0]["price"] = priceTextBox.Text;
				oleDb.dataSet.Tables["Nomenclature"].Rows[0]["units"] = unitsTextBox.Text;
				oleDb.dataSet.Tables["Nomenclature"].Rows[0]["parent"] = foldersComboBox.Text;
				
				oleDb.oleDbCommandUpdate.CommandText = "UPDATE Nomenclature SET " +
					"[name] = @name, [type] = @type, " +
					"[code] = @code, [series] = @series, [article] = @article, [manufacturer] = @manufacturer," +
					"[price] = @price, [units] = @units, [parent] = @parent "+
					"WHERE ([id] = @id)";
				oleDb.oleDbCommandUpdate.Parameters.Add("@name", OleDbType.VarChar, 255, "name");
				oleDb.oleDbCommandUpdate.Parameters.Add("@type", OleDbType.VarChar, 255, "type");
				oleDb.oleDbCommandUpdate.Parameters.Add("@code", OleDbType.VarChar, 255, "code");
				oleDb.oleDbCommandUpdate.Parameters.Add("@series", OleDbType.VarChar, 255, "series");
				oleDb.oleDbCommandUpdate.Parameters.Add("@article", OleDbType.VarChar, 255, "article");
				oleDb.oleDbCommandUpdate.Parameters.Add("@manufacturer", OleDbType.VarChar, 255, "manufacturer");
				oleDb.oleDbCommandUpdate.Parameters.Add("@price", OleDbType.Double, 15, "price");
				oleDb.oleDbCommandUpdate.Parameters.Add("@units", OleDbType.VarChar, 255, "units");
				oleDb.oleDbCommandUpdate.Parameters.Add("@parent", OleDbType.VarChar, 255, "parent");
				oleDb.oleDbCommandUpdate.Parameters.Add("@id", OleDbType.Integer, 10, "id");
				if(oleDb.ExecuteUpdate("Nomenclature")){
					DataForms.FClient.updateHistory("Nomenclature");
					Utilits.Console.Log("Номенклатура успешно изменена.");
					Close();
				}else{
					oleDb.Error();
					Utilits.Console.Log("[ОШИБКА] Ошибка изменения номенклатуры.");
				}
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				sqlServer = new SqlServer();
				sqlServer.sqlCommandSelect.CommandText = "SELECT id, name, type, " +
					"code, series, article, manufacturer, price, units, parent " +
					"FROM Nomenclature WHERE (id = " + ID +")";
				sqlServer.ExecuteFill("Nomenclature");	
				sqlServer.dataSet.Tables["Nomenclature"].Rows[0]["name"] = nameTextBox.Text;
				sqlServer.dataSet.Tables["Nomenclature"].Rows[0]["type"] = DataConstants.FILE;
				sqlServer.dataSet.Tables["Nomenclature"].Rows[0]["code"] = codeTextBox.Text;
				sqlServer.dataSet.Tables["Nomenclature"].Rows[0]["series"] = seriesTextBox.Text;
				sqlServer.dataSet.Tables["Nomenclature"].Rows[0]["article"] = articleTextBox.Text;
				sqlServer.dataSet.Tables["Nomenclature"].Rows[0]["manufacturer"] = manufacturerTextBox.Text;
				sqlServer.dataSet.Tables["Nomenclature"].Rows[0]["price"] = priceTextBox.Text;
				sqlServer.dataSet.Tables["Nomenclature"].Rows[0]["units"] = unitsTextBox.Text;
				sqlServer.dataSet.Tables["Nomenclature"].Rows[0]["parent"] = foldersComboBox.Text;
				
				sqlServer.sqlCommandUpdate.CommandText = "UPDATE Nomenclature SET " +
					"[name] = @name, [type] = @type, " +
					"[code] = @code, [series] = @series, [article] = @article, [manufacturer] = @manufacturer," +
					"[price] = @price, [units] = @units, [parent] = @parent "+
					"WHERE ([id] = @id)";
				sqlServer.sqlCommandUpdate.Parameters.Add("@name", SqlDbType.VarChar, 255, "name");
				sqlServer.sqlCommandUpdate.Parameters.Add("@type", SqlDbType.VarChar, 255, "type");
				sqlServer.sqlCommandUpdate.Parameters.Add("@code", SqlDbType.VarChar, 255, "code");
				sqlServer.sqlCommandUpdate.Parameters.Add("@series", SqlDbType.VarChar, 255, "series");
				sqlServer.sqlCommandUpdate.Parameters.Add("@article", SqlDbType.VarChar, 255, "article");
				sqlServer.sqlCommandUpdate.Parameters.Add("@manufacturer", SqlDbType.VarChar, 255, "manufacturer");
				sqlServer.sqlCommandUpdate.Parameters.Add("@price", SqlDbType.Float, 15, "price");
				sqlServer.sqlCommandUpdate.Parameters.Add("@units", SqlDbType.VarChar, 255, "units");
				sqlServer.sqlCommandUpdate.Parameters.Add("@parent", SqlDbType.VarChar, 255, "parent");
				sqlServer.sqlCommandUpdate.Parameters.Add("@id", SqlDbType.Int, 10, "id");
				if(sqlServer.ExecuteUpdate("Nomenclature")){
					DataForms.FClient.updateHistory("Nomenclature");
					Utilits.Console.Log("Номенклатура успешно изменена.");
					Close();
				}else{
					sqlServer.Error();
					Utilits.Console.Log("[ОШИБКА] Ошибка изменения номенклатуры.");
				}
			}
		}
		
		bool check()
		{
			if(nameTextBox.Text == "") return false;
			if(foldersComboBox.Text != ""){
				getFolders();
				bool checkParent = false;
				for(int i = 0; i < foldersComboBox.Items.Count; i++){
					if(foldersComboBox.Text == foldersComboBox.Items[i].ToString()){
						checkParent = true;
						break;
					}
				}
				if(checkParent){
					return true;
				}else{
					Utilits.Console.Log("[ПРЕДУПРЕЖДЕНИЕ] Папка '" + foldersComboBox.Text + "' не существует. Выберите другую родительскую папку.", false, true);
					return false;
				}
			}else{
				return true;
			}
		}
		
		
		/* =================================================================================================
		 * РАЗДЕЛ: СОБЫТИЙ
		 * =================================================================================================
		 */	
		void FormNomenclatureFileLoad(object sender, EventArgs e)
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL) oleDb = new OleDb(DataConfig.localDatabase);
			if(DataConfig.typeConnection == DataConstants.CONNETION_SERVER) sqlServer = new SqlServer();
			getFolders();
			foldersComboBox.Text = ParentFolder;
			if(ID == null){
				Text = "Номенклатура: Создать";
				unitsTextBox.Text = DataConstants.ConstFirmUnits;
			}else{
				Text = "Номенклатура: Изменить";
				open();
			}
			Utilits.Console.Log(Text);
		}
		void FormNomenclatureFileFormClosed(object sender, FormClosedEventArgs e)
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL && oleDb != null) oleDb.Dispose();
			if(DataConfig.typeConnection == DataConstants.CONNETION_SERVER && sqlServer != null) sqlServer.Dispose();
			DataForms.FClient.messageInStatus("...");
			Utilits.Console.Log(this.Text + ": закрыт");
			Dispose();
		}
		void PriceTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab){
				String Value = priceTextBox.Text;
				priceTextBox.Clear();
				priceTextBox.Text = Conversion.StringToMoney(Math.Round(Conversion.StringToDouble(Value), 2).ToString());
				if(priceTextBox.Text == "" || Conversion.checkString(priceTextBox.Text) == false) priceTextBox.Text = "0,00";
			}
		}
		void PriceTextBoxTextChanged(object sender, EventArgs e)
		{
			if(priceTextBox.Text == "" || Conversion.checkString(priceTextBox.Text) == false) priceTextBox.Text = "0,00";
		}
		void PriceTextBoxTextLostFocus(object sender, EventArgs e)
		{
			String Value = priceTextBox.Text;
			priceTextBox.Clear();
			priceTextBox.Text = Conversion.StringToMoney(Math.Round(Conversion.StringToDouble(Value), 2).ToString());
			if(priceTextBox.Text == "" || Conversion.checkString(priceTextBox.Text) == false) priceTextBox.Text = "0,00";
		}
		void Button7Click(object sender, EventArgs e)
		{
			Calculator Calc = new Calculator();
			Calc.TextBoxReturnValue = priceTextBox;
			Calc.MdiParent = DataForms.FClient;
			Calc.Show();
		}
		void ButtonCancelClick(object sender, EventArgs e)
		{
			Close();
		}
		void ButtonSaveClick(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			if(check()){
				if(ID == null){
					saveNew();
				}else{
					saveEdit();
				}
			}else{
				MessageBox.Show("Некорректно заполнены поля формы.", "Сообщение:");
			}
		}
		void ButtonClearClick(object sender, EventArgs e)
		{
			Button target = (sender as Button);
			if(target.Name == "button1") nameTextBox.Clear();
			if(target.Name == "button2") codeTextBox.Clear();
			if(target.Name == "button3") seriesTextBox.Clear();
			if(target.Name == "button4") articleTextBox.Clear();
			if(target.Name == "button5") manufacturerTextBox.Clear();
			if(target.Name == "button6") priceTextBox.Clear();
			if(target.Name == "button9") unitsTextBox.Clear();
			if(target.Name == "button11") foldersComboBox.Text = "";
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
		void FormNomenclatureFileActivated(object sender, EventArgs e)
		{
			DataForms.FClient.messageInStatus(this.Text);
		}
	}
}
