/*
 * Created by SharpDevelop.
 * User: Somov Studio
 * Date: 23.02.2017
 * Time: 11:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Aggregator.Client.Documents;
using Aggregator.Client.OpenFiles;
using Aggregator.Client.Reports;
using Aggregator.Data;
using Aggregator.Database.Constants;
using Aggregator.Database.Local;
using Aggregator.Admin;
using Aggregator.Database.Server;
using Aggregator.Trial;
using Aggregator.User;
using Aggregator.Client.Settings;
using Aggregator.Client.Directories;
using Aggregator.Client.Documents.PurchasePlan;
using Aggregator.Client.Documents.Order;
using Aggregator.Utilits;

namespace Aggregator.Client
{
	/// <summary>
	/// Description of FormClient.
	/// </summary>
	public partial class FormClient : Form
	{
		public FormClient()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		/* =================================================================================================
		 * РАЗДЕЛ: ПРОЦЕДУР И ФУНКЦИЙ
		 * =================================================================================================
		 */	
		HistoryRefreshOleDb historyRefreshOleDb;
		HistoryRefreshSqlServer historyRefreshSqlServer;
		
		/* Применить права пользователя */
		void applyPermissions()
		{
			if(DataConfig.userPermissions == "admin"){
				администраторToolStripMenuItem.Visible = true;
			}else if(DataConfig.userPermissions == "operator"){
				администраторToolStripMenuItem.Visible = false;
			}else if(DataConfig.userPermissions == "user"){
				администраторToolStripMenuItem.Visible = false;
			}else if(DataConfig.userPermissions == "guest"){
				администраторToolStripMenuItem.Visible = false;
			}
		}
		
		/* Открыть окно пользователей */
		void usersShow()
		{
			if(DataForms.FUsers == null){
				DataForms.FUsers = new FormUsers();
				DataForms.FUsers.MdiParent = DataForms.FClient;
				DataForms.FUsers.Show();
			}
		}
		
		/* Открыть окно настройки подключения к базе данных */
		void databaseSettingsShow()
		{
			if(DataForms.FDatabase == null){
				DataForms.FDatabase = new FormDatabase();
				DataForms.FDatabase.MdiParent = DataForms.FClient;
				DataForms.FDatabase.Show();
			}
		}
		
		/* Открыть окно настроек */
		void settingsShow()
		{
			if(DataForms.FSettings == null) {
				DataForms.FSettings = new FormSettings();
				DataForms.FSettings.MdiParent = DataForms.FClient;
				DataForms.FSettings.Show();
			}
		}
		
		/* Отобразить консоль */
		void consoleVisible()
		{
			if(consolePanel.Visible) consolePanel.Visible = false;
			else consolePanel.Visible = true;
		}
		
		/* Открыть консоль запросов */
		void consoleQuery()
		{
			if(DataForms.FConsoleQuery == null){
				DataForms.FConsoleQuery = new FormConsoleQuery();
				DataForms.FConsoleQuery.MdiParent = DataForms.FClient;
				DataForms.FConsoleQuery.Show();
			}
		}
		
		/* Открыть Excel файл */
		void openFileExcel()
		{
			FormOpenExcel FOpenExcel;
			if(openFileDialog1.ShowDialog() == DialogResult.OK){
				FOpenExcel = new FormOpenExcel();
				FOpenExcel.FileName = openFileDialog1.FileName;
				FOpenExcel.MdiParent = DataForms.FClient;
				FOpenExcel.Show();
			}
		}
		
		/* О программе */
		void about()
		{
			/*
			MessageBox.Show("Программа: Aggregator" + System.Environment.NewLine +
			                "Разработчик: Somov Studio" + System.Environment.NewLine +
			                "Лиценция: Freeware" + System.Environment.NewLine +
			                "Версия: 1.0.0" + System.Environment.NewLine +
			                "Дата: 01.03.2017" + System.Environment.NewLine +
			                "Почта: somov.studio@gmail.com" + System.Environment.NewLine +
			                "Сайт: http://somov.hol.es/", "О программе");
			*/
			FormAbout FAbout = new FormAbout();
			FAbout.ShowDialog();
		}
		
		/* Открыть окно констант */
		void constantsShow()
		{
			if(DataForms.FConstants == null) {
				DataForms.FConstants = new FormConstants();
				DataForms.FConstants.MdiParent = DataForms.FClient;
				DataForms.FConstants.Show();
			}
		}
		
		/* Открыть окно контрагентов */
		void counteragentsShow()
		{
			if(DataForms.FCounteragents == null) {
				DataForms.FCounteragents = new FormCounteragents();
				DataForms.FCounteragents.MdiParent = DataForms.FClient;
				DataForms.FCounteragents.Show();
			}
		}
		
		/* Открыть окно номенклатуры */
		void nomenclatureShow()
		{
			if(DataForms.FNomenclature == null){
				DataForms.FNomenclature = new FormNomenclature();
				DataForms.FNomenclature.MdiParent = DataForms.FClient;
				DataForms.FNomenclature.Show();
			}
		}
		
		void unitsShow()
		{
			if(DataForms.FUnits == null){
				DataForms.FUnits = new FormUnits();
				DataForms.FUnits.MdiParent = DataForms.FClient;
				DataForms.FUnits.Show();
			}
		}
		
		void purchasePlanJournalShow()
		{
			if(DataForms.FPurchasePlanJournal == null){
				DataForms.FPurchasePlanJournal = new FormPurchasePlanJournal();
				DataForms.FPurchasePlanJournal.MdiParent = DataForms.FClient;
				DataForms.FPurchasePlanJournal.Show();
			}
		}
		
		void purchasePlanDoclShow()
		{
			FormPurchasePlanDoc FPurchasePlanDoc = new FormPurchasePlanDoc();
			FPurchasePlanDoc.MdiParent = DataForms.FClient;
			FPurchasePlanDoc.ID = null;
			FPurchasePlanDoc.Show();
		}
		
		void orderJournalShow()
		{
			if(DataForms.FOrderJournal == null){
				DataForms.FOrderJournal = new FormOrderJournal();
				DataForms.FOrderJournal.MdiParent = DataForms.FClient;
				DataForms.FOrderJournal.Show();
			}
		}
		
		void orderDocShow()
		{
			FormOrderDoc FOrderDoc = new FormOrderDoc();
			FOrderDoc.MdiParent = DataForms.FClient;
			FOrderDoc.ID = null;
			FOrderDoc.Show();
		}
		
		void fullJournalShow()
		{
			if(DataForms.FFullJournal == null){
				DataForms.FFullJournal = new FormFullJournal();
				DataForms.FFullJournal.MdiParent= DataForms.FClient;
				DataForms.FFullJournal.Show();
			}
		}
		
		void calcCostRealizationShow()
		{
			CalculationCostRealization FCalculationCostRealization = new CalculationCostRealization();
			(FCalculationCostRealization as Form).MdiParent = DataForms.FClient;
			(FCalculationCostRealization as Form).Show();
		}
		
		void reportCountragent()
		{
			FormReportCountragents FReportCountragents= new FormReportCountragents();
			FReportCountragents.MdiParent = DataForms.FClient;
			FReportCountragents.Show();
		}
		
		void helpShow()
		{
			try{
				System.Diagnostics.Process.Start(DataConfig.programPath + "help.chm");
			}catch(Exception ex){
				MessageBox.Show(ex.Message, "Ошибка");
			}
		}
		
		/* Сообщение в статусе */
		public void messageInStatus(String message) {
			toolStripStatusLabel2.Text = message;
		}
		
		/* Включить/отключить работу авто обновления таблиц (только для OleDb)*/
		public void autoUpdateOn()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				indicator(true);
				timer1.Start();
			}else{
				indicator(false);
				timer1.Stop();
			}
		}
		
		public void autoUpdateOff()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				indicator(false);
				timer1.Stop();
			}else{
				indicator(false);
				timer1.Stop();
			}
		}
		
		public void indicator(Boolean statusOnOff)
		{
			if(statusOnOff){ // on (автоматическое обновление включено)
				toolStripStatusLabel1.Text = "Мониторинг изменений в базе данных: включен.";
				toolStripStatusLabel1.ImageIndex = 0;
				toolStripStatusLabel1.Visible = true;
			}else{ // off (автоматическое обновление отключено)
				toolStripStatusLabel1.Text = "Мониторинг изменений в базе данных: отключен.";
				toolStripStatusLabel1.ImageIndex = 2;
				toolStripStatusLabel1.Visible = true;
			}
		}
		
		/* Обновть данные в Истории */
		public void updateHistory(String tableName)
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){	
				// OLEDB
				if(DataConfig.autoUpdate && historyRefreshOleDb != null) historyRefreshOleDb.update(tableName);
				if(!DataConfig.autoUpdate && historyRefreshOleDb != null) historyRefreshOleDb.refresh(tableName, tableName);
			}else if(DataConfig.typeConnection == DataConstants.CONNETION_SERVER){	
				// MSSQL
				if(historyRefreshSqlServer != null)	historyRefreshSqlServer.update(tableName);
			}
		}
		
		/* =================================================================================================
		 * РАЗДЕЛ: СОБЫТИЙ
		 * =================================================================================================
		 */		
		
		void FormClientLoad(object sender, EventArgs e)
		{
			statusStrip1.ImageList = imageList1;
			
			ReadingConstants readingConstants = new ReadingConstants(); // константы
			readingConstants.read();
			readingConstants.Dispose();
			
			applyPermissions(); // права пользователя
			
			Utilits.Console.Log("Программа запущена!");
			
			/* Мониторин (автоматическое обновление данных в прогремме) */
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){ // OLEDB
				historyRefreshOleDb = new HistoryRefreshOleDb();
				if(DataConfig.autoUpdate) autoUpdateOn();
				else autoUpdateOff();
			}else if(DataConfig.typeConnection == DataConstants.CONNETION_SERVER){	// MSSQL
				historyRefreshSqlServer = new HistoryRefreshSqlServer();
				historyRefreshSqlServer.MonitoringRun();
			}
		}
		void FormClientFormClosing(object sender, FormClosingEventArgs e)
		{
			if(DataConfig.programClose == false){
				if(MessageBox.Show("Вы хотите выйти из программы?","Вопрос:", MessageBoxButtons.YesNo) == DialogResult.Yes){
					if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL)
					{
						timer1.Stop();
						historyRefreshOleDb.Dispose();
					}
					if(DataConfig.typeConnection == DataConstants.CONNETION_SERVER)
					{
						historyRefreshSqlServer.MonitoringStop();
						historyRefreshSqlServer.Dispose();
					}
					e.Cancel = false;
				}else{
					e.Cancel = true;
				}
			}
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			if(toolStripStatusLabel1.ImageIndex == 1) toolStripStatusLabel1.ImageIndex = 0;
			else toolStripStatusLabel1.ImageIndex = 1;
			historyRefreshOleDb.check();
		}
		void FormClientFormClosed(object sender, FormClosedEventArgs e)
		{
			timer1.Stop();
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL && historyRefreshOleDb != null) {
				historyRefreshOleDb.Dispose();
			}else if(DataConfig.typeConnection == DataConstants.CONNETION_SERVER && historyRefreshSqlServer != null){
				historyRefreshSqlServer.MonitoringStop();
			}			
			Dispose();
			Application.Exit();
		}
		void КонсольСообщенийToolStripMenuItemClick(object sender, EventArgs e)
		{
			consoleVisible();
		}
		void ToolStripButton1Click(object sender, EventArgs e)
		{
			consoleVisible();
		}
		void БазаДанныхToolStripMenuItemClick(object sender, EventArgs e)
		{
			databaseSettingsShow();
		}
		void КонсольЗапросовToolStripMenuItemClick(object sender, EventArgs e)
		{
			consoleQuery();
		}
		void ПользователиToolStripMenuItemClick(object sender, EventArgs e)
		{
			usersShow();
		}
		void НастройкиToolStripMenuItemClick(object sender, EventArgs e)
		{
			settingsShow();
		}
		void ExcelФайлФормат2007ToolStripMenuItemClick(object sender, EventArgs e)
		{
			openFileExcel();
		}
		void ВыходToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}
		void ОПрограммеToolStripMenuItemClick(object sender, EventArgs e)
		{
			about();
		}
		void КонстантыToolStripMenuItemClick(object sender, EventArgs e)
		{
			constantsShow();
		}
		void КонтрагентыToolStripMenuItemClick(object sender, EventArgs e)
		{
			counteragentsShow();
		}
		void ПанельИнструментовToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(панельИнструментовToolStripMenuItem.Checked){
				панельИнструментовToolStripMenuItem.Checked = false;
				toolStrip1.Visible = false;
			}else{
				панельИнструментовToolStripMenuItem.Checked = true;
				toolStrip1.Visible = true;
			}
		}
		void ToolStripButton2Click(object sender, EventArgs e)
		{
			constantsShow();
		}
		void ToolStripButton3Click(object sender, EventArgs e)
		{
			counteragentsShow();
		}
		void КалькуляторToolStripMenuItemClick(object sender, EventArgs e)
		{
			try{
				System.Diagnostics.Process.Start("calc.exe");
			}catch(Exception ex){
				MessageBox.Show(ex.Message, "Ошибка");
			}
		}
		void БлокнотToolStripMenuItemClick(object sender, EventArgs e)
		{
			try{
				System.Diagnostics.Process.Start("notepad.exe");
			}catch(Exception ex){
				MessageBox.Show(ex.Message, "Ошибка");
			}
		}
		void WordPadToolStripMenuItemClick(object sender, EventArgs e)
		{
			try{
				System.Diagnostics.Process.Start("wordpad.exe");
			}catch(Exception ex){
				MessageBox.Show(ex.Message, "Ошибка");
			}
		}
		void PaintToolStripMenuItemClick(object sender, EventArgs e)
		{
			try{
				System.Diagnostics.Process.Start("mspaint.exe");
			}catch(Exception ex){
				MessageBox.Show(ex.Message, "Ошибка");
			}
		}
		void ExplorerToolStripMenuItemClick(object sender, EventArgs e)
		{
			try{
				System.Diagnostics.Process.Start("explorer.exe");
			}catch(Exception ex){
				MessageBox.Show(ex.Message, "Ошибка");
			}
		}
		void КоманданяСтрокаToolStripMenuItemClick(object sender, EventArgs e)
		{
			try{
				System.Diagnostics.Process.Start("cmd.exe");
			}catch(Exception ex){
				MessageBox.Show(ex.Message, "Ошибка");
			}
		}
		void НоменклатураToolStripMenuItemClick(object sender, EventArgs e)
		{
			nomenclatureShow();
		}
		void ToolStripButton4Click(object sender, EventArgs e)
		{
			nomenclatureShow();
		}
		void ЕдинициИзмеренияToolStripMenuItemClick(object sender, EventArgs e)
		{
			unitsShow();
		}
		void ToolStripButton5Click(object sender, EventArgs e)
		{
			unitsShow();
		}
		void ПланЗакупокToolStripMenuItemClick(object sender, EventArgs e)
		{
			purchasePlanDoclShow();
		}
		void ЖурналЗакупокToolStripMenuItemClick(object sender, EventArgs e)
		{
			purchasePlanJournalShow();
		}
		void ToolStripButton10Click(object sender, EventArgs e)
		{
			purchasePlanJournalShow();
		}
		void ToolStripButton6Click(object sender, EventArgs e)
		{
			purchasePlanDoclShow();
		}
		void ЖурналЗаказовToolStripMenuItemClick(object sender, EventArgs e)
		{
			orderJournalShow();
		}
		void ToolStripButton9Click(object sender, EventArgs e)
		{
			orderJournalShow();
		}
		void ЗаказToolStripMenuItemClick(object sender, EventArgs e)
		{
			orderDocShow();
		}
		void ToolStripButton7Click(object sender, EventArgs e)
		{
			orderDocShow();
		}
		void СтоимостьРеализацииToolStripMenuItemClick(object sender, EventArgs e)
		{
			calcCostRealizationShow();
		}
		void ВыходToolStripMenuItem1Click(object sender, EventArgs e)
		{
			Close();
		}
		void ТекстовыйФайлToolStripMenuItem2Click(object sender, EventArgs e)
		{
	
		}
		void ТекстовыйФайлToolStripMenuItem3Click(object sender, EventArgs e)
		{
	
		}
		void ExcelФайлToolStripMenuItemClick(object sender, EventArgs e)
		{
			openFileExcel();
		}
		void ToolStripButton13Click(object sender, EventArgs e)
		{
			Close();
		}
		void ToolStripButton11Click(object sender, EventArgs e)
		{
			settingsShow();
		}
		void ПолныйЖурналToolStripMenuItemClick(object sender, EventArgs e)
		{
			fullJournalShow();
		}
		void ToolStripButton8Click(object sender, EventArgs e)
		{
			fullJournalShow();
		}
		void ОтчетПоКонтрагентуToolStripMenuItemClick(object sender, EventArgs e)
		{
			reportCountragent();
		}
		void ToolStripButton14Click(object sender, EventArgs e)
		{
			reportCountragent();
		}
		void ВвестиКлючПрограммыToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(DataConfig.activated != DataConstants.KEY_APPLICATION){
				CheckTrial checkTrial = new CheckTrial();
				checkTrial.Check();
			}else{
				MessageBox.Show("Ваша копия программы уже активизирована!", "Сообщение");
			}
		}
		void ToolStripButton12Click(object sender, EventArgs e)
		{
			helpShow();
		}
		void ПомощьToolStripMenuItemClick(object sender, EventArgs e)
		{
			helpShow();
		}
		
				
	}
}
