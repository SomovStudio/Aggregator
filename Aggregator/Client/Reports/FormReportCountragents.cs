/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 08.05.2017
 * Время: 14:55
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Aggregator.Data;
using Aggregator.Client.Directories;
using Aggregator.Database.Local;
using Aggregator.Database.Server;
using ExcelLibrary.SpreadSheet;

namespace Aggregator.Client.Reports
{
	/// <summary>
	/// Description of FormReportCountragents.
	/// </summary>
	public partial class FormReportCountragents : Form
	{
		public FormReportCountragents()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		int printCol = 0;
		int printRow = 0;
		
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
		
		String getCommandSelectOleDb()
		{
			int col = 0;
			String command = "SELECT ";
			if(codeSeriesArticleСheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.code ";
				else command += ", OrderNomenclature.code ";
				col++;
				command += ", OrderNomenclature.series ";
				col++;
				command += ", OrderNomenclature.article ";
				col++;
			}
			if(nameCheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.name ";
				else command += ", OrderNomenclature.name ";
				col++;
			}
			if(unitsСheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.units ";
				else command += ", OrderNomenclature.units ";
				col++;
			}
			if(amountСheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.amount ";
				else command += ", OrderNomenclature.amount ";
				col++;
			}
			if(priceСheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.price ";
				else command += ", OrderNomenclature.price ";
				col++;
			}
			if(discountСheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.discount1 ";
				else command += ", OrderNomenclature.discount1 ";
				col++;
				command += ", OrderNomenclature.discount2 ";
				col++;
				command += ", OrderNomenclature.discount3 ";
				col++;
				command += ", OrderNomenclature.discount4 ";
				col++;
			}
			if(manufacturerСheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.manufacturer ";
				else command += ", OrderNomenclature.manufacturer ";
				col++;
			}
			if(termСheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.term ";
				else command += ", OrderNomenclature.term ";
				col++;
			}
			if(orderCheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.docOrder ";
				else command += ", OrderNomenclature.docOrder ";
				col++;
			}
			if(PurchasePlanCheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.docPurchasePlan ";
				else command += ", OrderNomenclature.docPurchasePlan ";
				col++;
			}
			
			command += "FROM OrderNomenclature, Orders "+
			"WHERE (OrderNomenclature.counteragentName = '" + counteragentTextBox.Text + "') "+
			"AND (Orders.docCounteragent = '" + counteragentTextBox.Text + "') "+
			"AND (OrderNomenclature.docOrder = Orders.docNumber) " +
			"AND (Orders.docDate BETWEEN #" + 
			dateTimePicker1.Value.ToString("MM.dd.yyyy").Replace(".", "/") + "# AND #" + 
				dateTimePicker2.Value.ToString("MM.dd.yyyy").Replace(".", "/") + "#)";
			
			return command;
		}
		
		String getCommandSelectSqlServer()
		{
			int col = 0;
			String command = "SELECT ";
			if(codeSeriesArticleСheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.code ";
				else command += ", OrderNomenclature.code ";
				col++;
				command += ", OrderNomenclature.series ";
				col++;
				command += ", OrderNomenclature.article ";
				col++;
			}
			if(nameCheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.name ";
				else command += ", OrderNomenclature.name ";
				col++;
			}
			if(unitsСheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.units ";
				else command += ", OrderNomenclature.units ";
				col++;
			}
			if(amountСheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.amount ";
				else command += ", OrderNomenclature.amount ";
				col++;
			}
			if(priceСheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.price ";
				else command += ", OrderNomenclature.price ";
				col++;
			}
			if(discountСheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.discount1 ";
				else command += ", OrderNomenclature.discount1 ";
				col++;
				command += ", OrderNomenclature.discount2 ";
				col++;
				command += ", OrderNomenclature.discount3 ";
				col++;
				command += ", OrderNomenclature.discount4 ";
				col++;
			}
			if(manufacturerСheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.manufacturer ";
				else command += ", OrderNomenclature.manufacturer ";
				col++;
			}
			if(termСheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.term ";
				else command += ", OrderNomenclature.term ";
				col++;
			}
			if(orderCheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.docOrder ";
				else command += ", OrderNomenclature.docOrder ";
				col++;
			}
			if(PurchasePlanCheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.docPurchasePlan ";
				else command += ", OrderNomenclature.docPurchasePlan ";
				col++;
			}
			
			command += "FROM OrderNomenclature, Orders "+
			"WHERE (OrderNomenclature.counteragentName = '" + counteragentTextBox.Text + "') "+
			"AND (Orders.docCounteragent = '" + counteragentTextBox.Text + "') "+
			"AND (OrderNomenclature.docOrder = Orders.docNumber) " +
			"AND (Orders.docDate BETWEEN '" + dateTimePicker1.Text + "' AND '" + dateTimePicker2.Text + "')";
			
			return command;
		}
		
		void settingsColumns()
		{
			int col = 0;
			String command = "SELECT ";
			if(codeSeriesArticleСheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.code ";
				else command += ", OrderNomenclature.code ";
				dataGridView1.Columns[col].HeaderText = "Код";
				dataGridView1.Columns[col].Width = 50;
				col++;
				command += ", OrderNomenclature.series ";
				dataGridView1.Columns[col].HeaderText = "Серия";
				dataGridView1.Columns[col].Width = 50;
				col++;
				command += ", OrderNomenclature.article ";
				dataGridView1.Columns[col].HeaderText = "Артикул";
				dataGridView1.Columns[col].Width = 50;
				col++;
			}
			if(nameCheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.name ";
				else command += ", OrderNomenclature.name ";
				dataGridView1.Columns[col].HeaderText = "Наименование";
				dataGridView1.Columns[col].Width = 400;
				col++;
			}
			if(unitsСheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.units ";
				else command += ", OrderNomenclature.units ";
				dataGridView1.Columns[col].HeaderText = "Ед.изм.";
				dataGridView1.Columns[col].Width = 50;
				col++;
			}
			if(amountСheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.amount ";
				else command += ", OrderNomenclature.amount ";
				dataGridView1.Columns[col].HeaderText = "Кол-во";
				dataGridView1.Columns[col].Width = 100;
				col++;
			}
			if(priceСheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.price ";
				else command += ", OrderNomenclature.price ";
				dataGridView1.Columns[col].HeaderText = "Цена";
				dataGridView1.Columns[col].Width = 100;
				col++;
			}
			if(discountСheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.discount1 ";
				else command += ", OrderNomenclature.discount1 ";
				dataGridView1.Columns[col].HeaderText = "Скидка №1";
				dataGridView1.Columns[col].Width = 100;
				col++;
				command += ", OrderNomenclature.discount2 ";
				dataGridView1.Columns[col].HeaderText = "Скидка №2";
				dataGridView1.Columns[col].Width = 100;
				col++;
				command += ", OrderNomenclature.discount3 ";
				dataGridView1.Columns[col].HeaderText = "Скидка №3";
				dataGridView1.Columns[col].Width = 100;
				col++;
				command += ", OrderNomenclature.discount4 ";
				dataGridView1.Columns[col].HeaderText = "Скидка №4";
				dataGridView1.Columns[col].Width = 100;
				col++;
			}
			if(manufacturerСheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.manufacturer ";
				else command += ", OrderNomenclature.manufacturer ";
				dataGridView1.Columns[col].HeaderText = "Производитель";
				dataGridView1.Columns[col].Width = 250;
				col++;
			}
			if(termСheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.term ";
				else command += ", OrderNomenclature.term ";
				dataGridView1.Columns[col].HeaderText = "Срок годности";
				dataGridView1.Columns[col].Width = 100;
				col++;
			}
			if(orderCheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.docOrder ";
				else command += ", OrderNomenclature.docOrder ";
				dataGridView1.Columns[col].HeaderText = "Заказ";
				dataGridView1.Columns[col].Width = 100;
				col++;
			}
			if(PurchasePlanCheckBox.Checked){
				if(col == 0) command += "OrderNomenclature.docPurchasePlan ";
				else command += ", OrderNomenclature.docPurchasePlan ";
				dataGridView1.Columns[col].HeaderText = "План закупок";
				dataGridView1.Columns[col].Width = 100;
				col++;
			}
		}
		
		void generateReport()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL && DataConfig.typeDatabase == DataConstants.TYPE_OLEDB) {
				// OLEDB
				reportOleDb();
			} else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER && DataConfig.typeDatabase == DataConstants.TYPE_MSSQL){
				// MSSQL SERVER
				reportSqlServer();
			}
		}
		
		void reportOleDb()
		{
			OleDb oleDb = null;
			try{
				oleDb = new OleDb(DataConfig.localDatabase);
				oleDb.dataSet.Clear();
			
				oleDb.oleDbCommandSelect.CommandText = getCommandSelectOleDb();
				
				/*
				oleDb.oleDbCommandSelect.CommandText = "SELECT " +
					"OrderNomenclature.name " +
					"FROM OrderNomenclature, Orders "+
					"WHERE (OrderNomenclature.counteragentName = '" + counteragentTextBox.Text + "') "+
					"AND (Orders.docCounteragent = '" + counteragentTextBox.Text + "') "+
					"AND (OrderNomenclature.docOrder = Orders.docNumber) " +
					"AND (Orders.docDate BETWEEN #" + 
					dateTimePicker1.Value.ToString("MM.dd.yyyy").Replace(".", "/") + "# AND #" + 
					dateTimePicker2.Value.ToString("MM.dd.yyyy").Replace(".", "/") + "#) ";
				*/
				
				if(oleDb.ExecuteFill("OrderNomenclature")){
					
					if(oleDb.dataSet.Tables.Count > 0){
					
						dataGridView1.DataSource = oleDb.dataSet;
						dataGridView1.DataMember = oleDb.dataSet.Tables[0].TableName;
						settingsColumns();
					}
				}
			}catch(Exception ex){
				if(oleDb != null) oleDb.Dispose();
				Utilits.Console.Log("[ОШИБКА]: " + ex.Message, false, true);
			}
		}
		
		void reportSqlServer()
		{
			SqlServer sqlServer = null;
			try{
				sqlServer = new SqlServer();
				sqlServer.dataSet.Clear();
				sqlServer.sqlCommandSelect.CommandText = getCommandSelectSqlServer();
				
				if(sqlServer.ExecuteFill("OrderNomenclature")){
					if(sqlServer.dataSet.Tables.Count > 0){
						dataGridView1.DataSource = sqlServer.dataSet;
						dataGridView1.DataMember = sqlServer.dataSet.Tables[0].TableName;
						settingsColumns();
					}
				}
			}catch(Exception ex){
				if(sqlServer != null) sqlServer.Dispose();
				Utilits.Console.Log("[ОШИБКА]: " + ex.Message.ToString(), false, true);
			}
		}
		
		/* =================================================================================================
		 * РАЗДЕЛ: СОБЫТИЙ
		 * =================================================================================================
		 */	
		void FormReportCountragentsLoad(object sender, EventArgs e)
		{
			getPeriod();
			Utilits.Console.Log(this.Text + ": открыт");
		}
		void FormReportCountragentsFormClosed(object sender, FormClosedEventArgs e)
		{
			DataForms.FClient.messageInStatus("...");
			Utilits.Console.Log(this.Text + ": закрыт");
			Dispose();
		}
		void FormReportCountragentsActivated(object sender, EventArgs e)
		{
			DataForms.FClient.messageInStatus(this.Text);
		}
		void Button2Click(object sender, EventArgs e)
		{
			counteragentTextBox.Clear();
		}
		void Button1Click(object sender, EventArgs e)
		{
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
		void ButtonSaveClick(object sender, EventArgs e)
		{
			generateReport();
		}
		void ButtonPrintClick(object sender, EventArgs e)
		{
			printRow = 0;
			printCol = 0;
			if(printDialog1.ShowDialog() == DialogResult.OK){
				printDialog1.Document.Print();
			}
		}
		void ButtonPrintPreviewClick(object sender, EventArgs e)
		{
			printRow = 0;
			printCol = 0;
			PrintPreviewDialog ppd = new PrintPreviewDialog();
			ppd.Document = printDocument1;
			ppd.MdiParent = DataForms.FClient;
			ppd.Show();
		}
		void PrintDocument1PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			int PosY = 0;
			if(printRow == 0){
				// Заголовок документа
				e.Graphics.DrawString("ОТЧЕТ ПО КОНТРАГЕНТУ", new Font("Microsoft Sans Serif", 14, FontStyle.Regular), Brushes.Black, 20, PosY);
				// ШАПКА
				PosY += 60;
				e.Graphics.DrawString("Контрагент: " + counteragentTextBox.Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 5, PosY);
				PosY += 30;
				e.Graphics.DrawString("Период: с " +dateTimePicker1.Text + " по " + dateTimePicker2.Text , new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 5, PosY);
				PosY += 30;
			}
			// ДАННЫЕ
			
			int countColumns = dataGridView1.Columns.Count;
			int countRows = dataGridView1.Rows.Count;
			
			for(int row = printRow; row < countRows; row++){
				
				PosY += 5;
				if(printCol == 0) { 
					e.Graphics.DrawLine(new Pen(Color.Black), 0, PosY, 650, PosY);
					PosY += 5;
				}
				
				for(int col = printCol; col < countColumns; col++){
					e.Graphics.DrawString(dataGridView1.Columns[col].HeaderText + ": " + dataGridView1[col, row].Value.ToString(), new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 5, PosY);
					PosY += 15;
					
					printCol++;
					if(PosY >= 1000) {
						e.HasMorePages = true;
						return;
					}
				}
				
				if(printCol == countColumns) printCol = 0;
				
				printRow++;
				if(PosY >= 1000) {
					e.HasMorePages = true;
					return;
				}

			}
			
			PosY += 15;
			e.Graphics.DrawLine(new Pen(Color.Black), 0, PosY, 650, PosY);
		}
		void ButtonSaveExcelClick(object sender, EventArgs e)
		{
			if(saveFileDialog1.ShowDialog() == DialogResult.OK){
				int row = 0;
				int col = 0;
				
				Workbook workbook = new Workbook();
				
				try
				{
					Worksheet worksheet = new Worksheet("Отчёт");
					
					/* ШАПКА */
					worksheet.Cells[row, 2] = new Cell("ОТЧЕТ ПО КОНТРАГЕНТУ:");
					row++;
					worksheet.Cells[row, 1] = new Cell("Контрагент:");
					worksheet.Cells[row, 2] = new Cell(counteragentTextBox.Text);
					row++;
					worksheet.Cells[row, 1] = new Cell("Период с: ");
					worksheet.Cells[row, 2] = new Cell(dateTimePicker1.Text);
					worksheet.Cells[row, 3] = new Cell(" по ");
					worksheet.Cells[row, 4] = new Cell(dateTimePicker2.Text);
					row++;
					row++;
					
					/* ТАБЛИЦА */
					col = 0;
					worksheet.Cells[row, col] = new Cell("№п/п:");
					col++;
					
					int countColumns = dataGridView1.Columns.Count;
					for(int columns = 0; columns < countColumns; columns++){
						worksheet.Cells[row, col] = new Cell(dataGridView1.Columns[columns].HeaderText);
						col++;
					}
					row++;
					
					int countRows = dataGridView1.Rows.Count;
					for(int rows = 0; rows < countRows; rows++){
						
						col = 0;
						worksheet.Cells[row, col] = new Cell(rows);
						col++;
						
						for(int columns = 0; columns < countColumns; columns++){
							
							worksheet.Cells[row, col] = new Cell(dataGridView1[columns, rows].Value);
							col++;
							
						}
						row++;
					}
					
					workbook.Worksheets.Add(worksheet);
		            workbook.Save(saveFileDialog1.FileName);
				} catch (Exception ex) {
					workbook = null;
					Utilits.Console.Log("[ОШИБКА] Создание excel файла: " + Environment.NewLine + ex.ToString(), false, true);
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
