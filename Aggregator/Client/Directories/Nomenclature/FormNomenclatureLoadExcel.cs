/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 17.03.2017
 * Время: 10:42
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.Sql;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Aggregator.Client.OpenFiles;
using Aggregator.Data;
using Aggregator.Database.Local;
using Aggregator.Database.Server;
using Excel;

namespace Aggregator.Client.Directories
{
	/// <summary>
	/// Description of FormNomenclatureLoadExcel.
	/// </summary>
	public partial class FormNomenclatureLoadExcel : Form
	{
		public FormNomenclatureLoadExcel()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public String ParentFolder;
		DataSet dataSet;
		OleDb oleDb;
		SqlServer sqlServer;
		
		void openFileExcel()
		{
			if(openFileDialog1.ShowDialog() == DialogResult.OK){
				fileTextBox.Text = openFileDialog1.FileName;
				if(fileTextBox.Text.Substring(fileTextBox.Text.Length - 3) == "xls"){
					readExcelFormat972003();
				}else{
					readExcelFormat2007();
				}
				FormOpenExcel FOpenExcel = new FormOpenExcel();
				FOpenExcel.FileName = openFileDialog1.FileName;
				FOpenExcel.MdiParent = DataForms.FClient;
				FOpenExcel.Show();
			}
		}
		
		void readExcelFormat972003()
		{
			try{
				FileStream stream = File.Open(fileTextBox.Text, FileMode.Open, FileAccess.Read);
				IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
				dataSet = excelReader.AsDataSet();
				excelReader.Close();
				Utilits.Console.Log("Файл " + fileTextBox.Text + " успешно открыт и прочитан.");
			}catch(Exception ex){
				MessageBox.Show(ex.ToString(), "ERROR");
			}
		}
		
		void readExcelFormat2007()
		{
			try{
				FileStream stream = File.Open(fileTextBox.Text, FileMode.Open, FileAccess.Read);
				IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
				dataSet = excelReader.AsDataSet();
				excelReader.Close();
				Utilits.Console.Log("Файл " + fileTextBox.Text + " успешно открыт и прочитан.");
			}catch(Exception ex){
				MessageBox.Show(ex.ToString(), "ERROR");
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
				
				DataRow newRow;
				int colsCount = dataSet.Tables[0].Columns.Count;
				foreach(DataRow row in dataSet.Tables[0].Rows){
					newRow = oleDb.dataSet.Tables["Nomenclature"].NewRow();
					if(colsCount > 0) newRow["name"] = row[0];
					if(colsCount > 1) newRow["code"] = row[1];
					if(colsCount > 2) newRow["series"] = row[2];
					if(colsCount > 3) newRow["article"] = row[3];
					if(colsCount > 4) newRow["manufacturer"] = row[4];
					if(colsCount > 5){
						if(row[5].ToString() == "") newRow["price"] = 0;
						else newRow["price"] = row[5];
					}
					if(colsCount > 6) newRow["units"] = row[6];	
					newRow["type"] = DataConstants.FILE;					
					newRow["parent"] = ParentFolder;
					oleDb.dataSet.Tables["Nomenclature"].Rows.Add(newRow);
				}
				
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
					Utilits.Console.Log("Номенклатура успешно загружена из Excel файла.");
					Close();
				}else{
					oleDb.Error();
					Utilits.Console.Log("[ОШИБКА] Ошибка загрузки данных из Excel файла.");
				}
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				sqlServer = new SqlServer();
				sqlServer.sqlCommandSelect.CommandText = "SELECT id, name, type, " +
					"code, series, article, manufacturer, price, units, parent " +
					"FROM Nomenclature WHERE (id = 0)";
				sqlServer.ExecuteFill("Nomenclature");				
				
				DataRow newRow;
				int colsCount = dataSet.Tables[0].Columns.Count;
				foreach(DataRow row in dataSet.Tables[0].Rows){
					newRow = sqlServer.dataSet.Tables["Nomenclature"].NewRow();
					if(colsCount > 0) newRow["name"] = row[0];
					if(colsCount > 1) newRow["code"] = row[1];
					if(colsCount > 2) newRow["series"] = row[2];
					if(colsCount > 3) newRow["article"] = row[3];
					if(colsCount > 4) newRow["manufacturer"] = row[4];
					if(colsCount > 5){
						if(row[5].ToString() == "") newRow["price"] = 0;
						else newRow["price"] = row[5];
					}
					if(colsCount > 6) newRow["units"] = row[6];	
					newRow["type"] = DataConstants.FILE;					
					newRow["parent"] = ParentFolder;
					sqlServer.dataSet.Tables["Nomenclature"].Rows.Add(newRow);
				}
				
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
					Utilits.Console.Log("Номенклатура успешно загружена из Excel файла.");
					Close();
				}else{
					sqlServer.Error();
					Utilits.Console.Log("[ОШИБКА] Ошибка загрузки данных из Excel файла.");
				}
			}
		}
		
		/* =================================================================================================
		 * РАЗДЕЛ: СОБЫТИЙ
		 * =================================================================================================
		 */	
		void FormNomenclatureLoadExcelLoad(object sender, EventArgs e)
		{
			Utilits.Console.Log(Text + ": открыт");
		}
		void FormNomenclatureLoadExcelFormClosed(object sender, FormClosedEventArgs e)
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL && oleDb != null) oleDb.Dispose();
			if(DataConfig.typeConnection == DataConstants.CONNETION_SERVER && sqlServer != null) sqlServer.Dispose();
			DataForms.FClient.messageInStatus("...");
			Utilits.Console.Log(Text + ": закрыт");
			Dispose();
		}
		void Button1Click(object sender, EventArgs e)
		{
			openFileExcel();
		}
		void CloseButtonClick(object sender, EventArgs e)
		{
			Close();
		}
		void LoadButtonClick(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "guest"){
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			if(dataSet != null){
				if(dataSet.Tables.Count > 0) saveNew();
				else Utilits.Console.Log("Неудалось открыть и прочитать файл Excel. Данные не загружены." , false, true);
			}
		}
		void FormNomenclatureLoadExcelActivated(object sender, EventArgs e)
		{
			DataForms.FClient.messageInStatus(this.Text);
		}
		
		
	}
}
