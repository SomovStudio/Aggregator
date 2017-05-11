/*
 * Created by SharpDevelop.
 * User: Cartish
 * Date: 23.02.2017
 * Time: 11:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Aggregator.Client
{
	partial class FormClient
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem текстовыйФайлToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem панельИнструментовToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem консольСообщенийToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem документыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem журналыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem сервисToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem администраторToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem константыToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem контрагентыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem номенклатураToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem калькуляторToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem пользователиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem базаДанныхToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
		public System.Windows.Forms.Panel consolePanel;
		private System.Windows.Forms.ToolTip toolTip1;
		public System.Windows.Forms.TextBox consoleText;
		private System.Windows.Forms.ToolStripMenuItem консольЗапросовToolStripMenuItem;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ToolStripMenuItem excelФайлФормат2007ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem текстовыйФайлToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem документWordpadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem заказToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem планЗакупокToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem полныйЖурналToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem журналЗаказовToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem журналЗакупокToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.ToolStripButton toolStripButton4;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem блокнотToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem wordPadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem paintToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem explorerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem команданяСтрокаToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem единициИзмеренияToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton toolStripButton5;
		private System.Windows.Forms.ToolStripButton toolStripButton6;
		private System.Windows.Forms.ToolStripButton toolStripButton7;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripButton toolStripButton8;
		private System.Windows.Forms.ToolStripButton toolStripButton9;
		private System.Windows.Forms.ToolStripButton toolStripButton10;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripMenuItem расчетыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem стоимостьРеализацииToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
		private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem excelФайлToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton toolStripButton11;
		private System.Windows.Forms.ToolStripButton toolStripButton12;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
		private System.Windows.Forms.ToolStripButton toolStripButton13;
		private System.Windows.Forms.ToolStripMenuItem отчетПоКонтрагентуToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton toolStripButton14;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
		private System.Windows.Forms.ToolStripMenuItem ввестиКлючПрограммыToolStripMenuItem;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClient));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.открытьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.excelФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.выходToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.панельИнструментовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.консольСообщенийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.константыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.контрагентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.номенклатураToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.единициИзмеренияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.документыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.заказToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.планЗакупокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.журналыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.полныйЖурналToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.журналЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.журналЗакупокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.отчетПоКонтрагентуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.расчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.стоимостьРеализацииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.калькуляторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.блокнотToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.wordPadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.paintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.explorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.команданяСтрокаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.администраторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.пользователиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.базаДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.консольЗапросовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ввестиКлючПрограммыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton14 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.consolePanel = new System.Windows.Forms.Panel();
			this.consoleText = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.текстовыйФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.текстовыйФайлToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.документWordpadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.excelФайлФормат2007ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.consolePanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripMenuItem1,
			this.видToolStripMenuItem,
			this.справочникиToolStripMenuItem,
			this.документыToolStripMenuItem,
			this.журналыToolStripMenuItem,
			this.отчетыToolStripMenuItem,
			this.расчетыToolStripMenuItem,
			this.сервисToolStripMenuItem,
			this.администраторToolStripMenuItem,
			this.настройкиToolStripMenuItem,
			this.справкаToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(912, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.открытьToolStripMenuItem1,
			this.toolStripSeparator9,
			this.выходToolStripMenuItem1});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
			this.toolStripMenuItem1.Text = "&Файл";
			// 
			// открытьToolStripMenuItem1
			// 
			this.открытьToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.excelФайлToolStripMenuItem});
			this.открытьToolStripMenuItem1.Name = "открытьToolStripMenuItem1";
			this.открытьToolStripMenuItem1.Size = new System.Drawing.Size(121, 22);
			this.открытьToolStripMenuItem1.Text = "Открыть";
			// 
			// excelФайлToolStripMenuItem
			// 
			this.excelФайлToolStripMenuItem.Name = "excelФайлToolStripMenuItem";
			this.excelФайлToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
			this.excelФайлToolStripMenuItem.Text = "Excel файл";
			this.excelФайлToolStripMenuItem.Click += new System.EventHandler(this.ExcelФайлToolStripMenuItemClick);
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(118, 6);
			// 
			// выходToolStripMenuItem1
			// 
			this.выходToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("выходToolStripMenuItem1.Image")));
			this.выходToolStripMenuItem1.Name = "выходToolStripMenuItem1";
			this.выходToolStripMenuItem1.Size = new System.Drawing.Size(121, 22);
			this.выходToolStripMenuItem1.Text = "Выход";
			this.выходToolStripMenuItem1.Click += new System.EventHandler(this.ВыходToolStripMenuItem1Click);
			// 
			// видToolStripMenuItem
			// 
			this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.панельИнструментовToolStripMenuItem,
			this.консольСообщенийToolStripMenuItem});
			this.видToolStripMenuItem.Name = "видToolStripMenuItem";
			this.видToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.видToolStripMenuItem.Text = "&Вид";
			// 
			// панельИнструментовToolStripMenuItem
			// 
			this.панельИнструментовToolStripMenuItem.Checked = true;
			this.панельИнструментовToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.панельИнструментовToolStripMenuItem.Name = "панельИнструментовToolStripMenuItem";
			this.панельИнструментовToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.панельИнструментовToolStripMenuItem.Text = "Панель инструментов";
			this.панельИнструментовToolStripMenuItem.Click += new System.EventHandler(this.ПанельИнструментовToolStripMenuItemClick);
			// 
			// консольСообщенийToolStripMenuItem
			// 
			this.консольСообщенийToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("консольСообщенийToolStripMenuItem.Image")));
			this.консольСообщенийToolStripMenuItem.Name = "консольСообщенийToolStripMenuItem";
			this.консольСообщенийToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
			this.консольСообщенийToolStripMenuItem.Text = "Консоль сообщений";
			this.консольСообщенийToolStripMenuItem.Click += new System.EventHandler(this.КонсольСообщенийToolStripMenuItemClick);
			// 
			// справочникиToolStripMenuItem
			// 
			this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.константыToolStripMenuItem,
			this.toolStripSeparator3,
			this.контрагентыToolStripMenuItem,
			this.номенклатураToolStripMenuItem,
			this.единициИзмеренияToolStripMenuItem});
			this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
			this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
			this.справочникиToolStripMenuItem.Text = "Справочники";
			// 
			// константыToolStripMenuItem
			// 
			this.константыToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("константыToolStripMenuItem.Image")));
			this.константыToolStripMenuItem.Name = "константыToolStripMenuItem";
			this.константыToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.константыToolStripMenuItem.Text = "Константы";
			this.константыToolStripMenuItem.Click += new System.EventHandler(this.КонстантыToolStripMenuItemClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(181, 6);
			// 
			// контрагентыToolStripMenuItem
			// 
			this.контрагентыToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("контрагентыToolStripMenuItem.Image")));
			this.контрагентыToolStripMenuItem.Name = "контрагентыToolStripMenuItem";
			this.контрагентыToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.контрагентыToolStripMenuItem.Text = "Контрагенты";
			this.контрагентыToolStripMenuItem.Click += new System.EventHandler(this.КонтрагентыToolStripMenuItemClick);
			// 
			// номенклатураToolStripMenuItem
			// 
			this.номенклатураToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("номенклатураToolStripMenuItem.Image")));
			this.номенклатураToolStripMenuItem.Name = "номенклатураToolStripMenuItem";
			this.номенклатураToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.номенклатураToolStripMenuItem.Text = "Номенклатура";
			this.номенклатураToolStripMenuItem.Click += new System.EventHandler(this.НоменклатураToolStripMenuItemClick);
			// 
			// единициИзмеренияToolStripMenuItem
			// 
			this.единициИзмеренияToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("единициИзмеренияToolStripMenuItem.Image")));
			this.единициИзмеренияToolStripMenuItem.Name = "единициИзмеренияToolStripMenuItem";
			this.единициИзмеренияToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.единициИзмеренияToolStripMenuItem.Text = "Единици измерения";
			this.единициИзмеренияToolStripMenuItem.Click += new System.EventHandler(this.ЕдинициИзмеренияToolStripMenuItemClick);
			// 
			// документыToolStripMenuItem
			// 
			this.документыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.заказToolStripMenuItem,
			this.планЗакупокToolStripMenuItem});
			this.документыToolStripMenuItem.Name = "документыToolStripMenuItem";
			this.документыToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
			this.документыToolStripMenuItem.Text = "Документы";
			// 
			// заказToolStripMenuItem
			// 
			this.заказToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("заказToolStripMenuItem.Image")));
			this.заказToolStripMenuItem.Name = "заказToolStripMenuItem";
			this.заказToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.заказToolStripMenuItem.Text = "Заказ";
			this.заказToolStripMenuItem.Click += new System.EventHandler(this.ЗаказToolStripMenuItemClick);
			// 
			// планЗакупокToolStripMenuItem
			// 
			this.планЗакупокToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("планЗакупокToolStripMenuItem.Image")));
			this.планЗакупокToolStripMenuItem.Name = "планЗакупокToolStripMenuItem";
			this.планЗакупокToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.планЗакупокToolStripMenuItem.Text = "План закупок";
			this.планЗакупокToolStripMenuItem.Click += new System.EventHandler(this.ПланЗакупокToolStripMenuItemClick);
			// 
			// журналыToolStripMenuItem
			// 
			this.журналыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.полныйЖурналToolStripMenuItem,
			this.toolStripSeparator4,
			this.журналЗаказовToolStripMenuItem,
			this.журналЗакупокToolStripMenuItem});
			this.журналыToolStripMenuItem.Name = "журналыToolStripMenuItem";
			this.журналыToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
			this.журналыToolStripMenuItem.Text = "Журналы";
			// 
			// полныйЖурналToolStripMenuItem
			// 
			this.полныйЖурналToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("полныйЖурналToolStripMenuItem.Image")));
			this.полныйЖурналToolStripMenuItem.Name = "полныйЖурналToolStripMenuItem";
			this.полныйЖурналToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.полныйЖурналToolStripMenuItem.Text = "Полный журнал";
			this.полныйЖурналToolStripMenuItem.Click += new System.EventHandler(this.ПолныйЖурналToolStripMenuItemClick);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(162, 6);
			// 
			// журналЗаказовToolStripMenuItem
			// 
			this.журналЗаказовToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("журналЗаказовToolStripMenuItem.Image")));
			this.журналЗаказовToolStripMenuItem.Name = "журналЗаказовToolStripMenuItem";
			this.журналЗаказовToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.журналЗаказовToolStripMenuItem.Text = "Журнал заказов";
			this.журналЗаказовToolStripMenuItem.Click += new System.EventHandler(this.ЖурналЗаказовToolStripMenuItemClick);
			// 
			// журналЗакупокToolStripMenuItem
			// 
			this.журналЗакупокToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("журналЗакупокToolStripMenuItem.Image")));
			this.журналЗакупокToolStripMenuItem.Name = "журналЗакупокToolStripMenuItem";
			this.журналЗакупокToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.журналЗакупокToolStripMenuItem.Text = "Журнал закупок";
			this.журналЗакупокToolStripMenuItem.Click += new System.EventHandler(this.ЖурналЗакупокToolStripMenuItemClick);
			// 
			// отчетыToolStripMenuItem
			// 
			this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.отчетПоКонтрагентуToolStripMenuItem});
			this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
			this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
			this.отчетыToolStripMenuItem.Text = "Отчеты";
			// 
			// отчетПоКонтрагентуToolStripMenuItem
			// 
			this.отчетПоКонтрагентуToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("отчетПоКонтрагентуToolStripMenuItem.Image")));
			this.отчетПоКонтрагентуToolStripMenuItem.Name = "отчетПоКонтрагентуToolStripMenuItem";
			this.отчетПоКонтрагентуToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.отчетПоКонтрагентуToolStripMenuItem.Text = "Отчет по контрагенту";
			this.отчетПоКонтрагентуToolStripMenuItem.Click += new System.EventHandler(this.ОтчетПоКонтрагентуToolStripMenuItemClick);
			// 
			// расчетыToolStripMenuItem
			// 
			this.расчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.стоимостьРеализацииToolStripMenuItem});
			this.расчетыToolStripMenuItem.Name = "расчетыToolStripMenuItem";
			this.расчетыToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
			this.расчетыToolStripMenuItem.Text = "Расчеты";
			// 
			// стоимостьРеализацииToolStripMenuItem
			// 
			this.стоимостьРеализацииToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("стоимостьРеализацииToolStripMenuItem.Image")));
			this.стоимостьРеализацииToolStripMenuItem.Name = "стоимостьРеализацииToolStripMenuItem";
			this.стоимостьРеализацииToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
			this.стоимостьРеализацииToolStripMenuItem.Text = "Стоимость реализации";
			this.стоимостьРеализацииToolStripMenuItem.Click += new System.EventHandler(this.СтоимостьРеализацииToolStripMenuItemClick);
			// 
			// сервисToolStripMenuItem
			// 
			this.сервисToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.калькуляторToolStripMenuItem,
			this.блокнотToolStripMenuItem,
			this.wordPadToolStripMenuItem,
			this.paintToolStripMenuItem,
			this.toolStripSeparator6,
			this.explorerToolStripMenuItem,
			this.команданяСтрокаToolStripMenuItem});
			this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
			this.сервисToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.сервисToolStripMenuItem.Text = "Сервис";
			// 
			// калькуляторToolStripMenuItem
			// 
			this.калькуляторToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("калькуляторToolStripMenuItem.Image")));
			this.калькуляторToolStripMenuItem.Name = "калькуляторToolStripMenuItem";
			this.калькуляторToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.калькуляторToolStripMenuItem.Text = "Калькулятор";
			this.калькуляторToolStripMenuItem.Click += new System.EventHandler(this.КалькуляторToolStripMenuItemClick);
			// 
			// блокнотToolStripMenuItem
			// 
			this.блокнотToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("блокнотToolStripMenuItem.Image")));
			this.блокнотToolStripMenuItem.Name = "блокнотToolStripMenuItem";
			this.блокнотToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.блокнотToolStripMenuItem.Text = "Блокнот";
			this.блокнотToolStripMenuItem.Click += new System.EventHandler(this.БлокнотToolStripMenuItemClick);
			// 
			// wordPadToolStripMenuItem
			// 
			this.wordPadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("wordPadToolStripMenuItem.Image")));
			this.wordPadToolStripMenuItem.Name = "wordPadToolStripMenuItem";
			this.wordPadToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.wordPadToolStripMenuItem.Text = "WordPad";
			this.wordPadToolStripMenuItem.Click += new System.EventHandler(this.WordPadToolStripMenuItemClick);
			// 
			// paintToolStripMenuItem
			// 
			this.paintToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("paintToolStripMenuItem.Image")));
			this.paintToolStripMenuItem.Name = "paintToolStripMenuItem";
			this.paintToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.paintToolStripMenuItem.Text = "Paint";
			this.paintToolStripMenuItem.Click += new System.EventHandler(this.PaintToolStripMenuItemClick);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(172, 6);
			// 
			// explorerToolStripMenuItem
			// 
			this.explorerToolStripMenuItem.Name = "explorerToolStripMenuItem";
			this.explorerToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.explorerToolStripMenuItem.Text = "Проводник";
			this.explorerToolStripMenuItem.Click += new System.EventHandler(this.ExplorerToolStripMenuItemClick);
			// 
			// команданяСтрокаToolStripMenuItem
			// 
			this.команданяСтрокаToolStripMenuItem.Name = "команданяСтрокаToolStripMenuItem";
			this.команданяСтрокаToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.команданяСтрокаToolStripMenuItem.Text = "Команданя строка";
			this.команданяСтрокаToolStripMenuItem.Click += new System.EventHandler(this.КоманданяСтрокаToolStripMenuItemClick);
			// 
			// администраторToolStripMenuItem
			// 
			this.администраторToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.пользователиToolStripMenuItem,
			this.базаДанныхToolStripMenuItem,
			this.консольЗапросовToolStripMenuItem});
			this.администраторToolStripMenuItem.Name = "администраторToolStripMenuItem";
			this.администраторToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
			this.администраторToolStripMenuItem.Text = "Администратор";
			// 
			// пользователиToolStripMenuItem
			// 
			this.пользователиToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("пользователиToolStripMenuItem.Image")));
			this.пользователиToolStripMenuItem.Name = "пользователиToolStripMenuItem";
			this.пользователиToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.пользователиToolStripMenuItem.Text = "Пользователи";
			this.пользователиToolStripMenuItem.Click += new System.EventHandler(this.ПользователиToolStripMenuItemClick);
			// 
			// базаДанныхToolStripMenuItem
			// 
			this.базаДанныхToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("базаДанныхToolStripMenuItem.Image")));
			this.базаДанныхToolStripMenuItem.Name = "базаДанныхToolStripMenuItem";
			this.базаДанныхToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.базаДанныхToolStripMenuItem.Text = "База данных";
			this.базаДанныхToolStripMenuItem.Click += new System.EventHandler(this.БазаДанныхToolStripMenuItemClick);
			// 
			// консольЗапросовToolStripMenuItem
			// 
			this.консольЗапросовToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("консольЗапросовToolStripMenuItem.Image")));
			this.консольЗапросовToolStripMenuItem.Name = "консольЗапросовToolStripMenuItem";
			this.консольЗапросовToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.консольЗапросовToolStripMenuItem.Text = "Консоль запросов";
			this.консольЗапросовToolStripMenuItem.Visible = false;
			this.консольЗапросовToolStripMenuItem.Click += new System.EventHandler(this.КонсольЗапросовToolStripMenuItemClick);
			// 
			// настройкиToolStripMenuItem
			// 
			this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
			this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
			this.настройкиToolStripMenuItem.Text = "Настройки";
			this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.НастройкиToolStripMenuItemClick);
			// 
			// справкаToolStripMenuItem
			// 
			this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.ввестиКлючПрограммыToolStripMenuItem,
			this.помощьToolStripMenuItem,
			this.оПрограммеToolStripMenuItem});
			this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
			this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
			this.справкаToolStripMenuItem.Text = "Справка";
			// 
			// ввестиКлючПрограммыToolStripMenuItem
			// 
			this.ввестиКлючПрограммыToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ввестиКлючПрограммыToolStripMenuItem.Image")));
			this.ввестиКлючПрограммыToolStripMenuItem.Name = "ввестиКлючПрограммыToolStripMenuItem";
			this.ввестиКлючПрограммыToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
			this.ввестиКлючПрограммыToolStripMenuItem.Text = "Ввести ключь программы";
			this.ввестиКлючПрограммыToolStripMenuItem.Click += new System.EventHandler(this.ВвестиКлючПрограммыToolStripMenuItemClick);
			// 
			// помощьToolStripMenuItem
			// 
			this.помощьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("помощьToolStripMenuItem.Image")));
			this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
			this.помощьToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
			this.помощьToolStripMenuItem.Text = "Помощь";
			this.помощьToolStripMenuItem.Click += new System.EventHandler(this.ПомощьToolStripMenuItemClick);
			// 
			// оПрограммеToolStripMenuItem
			// 
			this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
			this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
			this.оПрограммеToolStripMenuItem.Text = "О программе";
			this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.ОПрограммеToolStripMenuItemClick);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripButton1,
			this.toolStripSeparator2,
			this.toolStripButton2,
			this.toolStripButton3,
			this.toolStripButton4,
			this.toolStripButton5,
			this.toolStripSeparator5,
			this.toolStripButton7,
			this.toolStripButton6,
			this.toolStripSeparator7,
			this.toolStripButton9,
			this.toolStripButton10,
			this.toolStripButton8,
			this.toolStripSeparator8,
			this.toolStripButton14,
			this.toolStripSeparator11,
			this.toolStripButton11,
			this.toolStripButton12,
			this.toolStripSeparator10,
			this.toolStripButton13});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(912, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "Панель инструментов";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "Консоль";
			this.toolStripButton1.ToolTipText = "Консоль";
			this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton2.Text = "Константы";
			this.toolStripButton2.ToolTipText = "Константы";
			this.toolStripButton2.Click += new System.EventHandler(this.ToolStripButton2Click);
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton3.Text = "Контрагенты";
			this.toolStripButton3.ToolTipText = "Контрагенты";
			this.toolStripButton3.Click += new System.EventHandler(this.ToolStripButton3Click);
			// 
			// toolStripButton4
			// 
			this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
			this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton4.Name = "toolStripButton4";
			this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton4.Text = "Номенклатура";
			this.toolStripButton4.ToolTipText = "Номенклатура";
			this.toolStripButton4.Click += new System.EventHandler(this.ToolStripButton4Click);
			// 
			// toolStripButton5
			// 
			this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
			this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton5.Name = "toolStripButton5";
			this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton5.Text = "Единицы измерения";
			this.toolStripButton5.Click += new System.EventHandler(this.ToolStripButton5Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton7
			// 
			this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
			this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton7.Name = "toolStripButton7";
			this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton7.Text = "Заказ";
			this.toolStripButton7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolStripButton7.Click += new System.EventHandler(this.ToolStripButton7Click);
			// 
			// toolStripButton6
			// 
			this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
			this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton6.Name = "toolStripButton6";
			this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton6.Text = "План закупок";
			this.toolStripButton6.Click += new System.EventHandler(this.ToolStripButton6Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton9
			// 
			this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
			this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton9.Name = "toolStripButton9";
			this.toolStripButton9.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton9.Text = "Журнал заказов";
			this.toolStripButton9.Click += new System.EventHandler(this.ToolStripButton9Click);
			// 
			// toolStripButton10
			// 
			this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
			this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton10.Name = "toolStripButton10";
			this.toolStripButton10.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton10.Text = "Журнал закупок";
			this.toolStripButton10.Click += new System.EventHandler(this.ToolStripButton10Click);
			// 
			// toolStripButton8
			// 
			this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
			this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton8.Name = "toolStripButton8";
			this.toolStripButton8.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton8.Text = "Полный журнал документов";
			this.toolStripButton8.Click += new System.EventHandler(this.ToolStripButton8Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton14
			// 
			this.toolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton14.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton14.Image")));
			this.toolStripButton14.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton14.Name = "toolStripButton14";
			this.toolStripButton14.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton14.Text = "Отчет по контрагенту";
			this.toolStripButton14.Click += new System.EventHandler(this.ToolStripButton14Click);
			// 
			// toolStripSeparator11
			// 
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton11
			// 
			this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton11.Image")));
			this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton11.Name = "toolStripButton11";
			this.toolStripButton11.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton11.Text = "Настройки";
			this.toolStripButton11.Click += new System.EventHandler(this.ToolStripButton11Click);
			// 
			// toolStripButton12
			// 
			this.toolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton12.Image")));
			this.toolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton12.Name = "toolStripButton12";
			this.toolStripButton12.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton12.Text = "Помощь";
			this.toolStripButton12.Click += new System.EventHandler(this.ToolStripButton12Click);
			// 
			// toolStripSeparator10
			// 
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton13
			// 
			this.toolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton13.Image")));
			this.toolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton13.Name = "toolStripButton13";
			this.toolStripButton13.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton13.Text = "Выход";
			this.toolStripButton13.Click += new System.EventHandler(this.ToolStripButton13Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripStatusLabel1,
			this.toolStripStatusLabel2});
			this.statusStrip1.Location = new System.Drawing.Point(0, 540);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(912, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel1.Image")));
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(251, 17);
			this.toolStripStatusLabel1.Text = "Мониторинг изменений в базе данных: ...";
			this.toolStripStatusLabel1.ToolTipText = "Индикатор состояния мониторинга изменений в базе данных.";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(16, 17);
			this.toolStripStatusLabel2.Text = "...";
			// 
			// consolePanel
			// 
			this.consolePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.consolePanel.Controls.Add(this.consoleText);
			this.consolePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.consolePanel.Location = new System.Drawing.Point(0, 406);
			this.consolePanel.Name = "consolePanel";
			this.consolePanel.Size = new System.Drawing.Size(912, 134);
			this.consolePanel.TabIndex = 4;
			this.consolePanel.Visible = false;
			// 
			// consoleText
			// 
			this.consoleText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.consoleText.Location = new System.Drawing.Point(0, 0);
			this.consoleText.Multiline = true;
			this.consoleText.Name = "consoleText";
			this.consoleText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.consoleText.Size = new System.Drawing.Size(908, 130);
			this.consoleText.TabIndex = 0;
			// 
			// timer1
			// 
			this.timer1.Interval = 2000;
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "database.png");
			this.imageList1.Images.SetKeyName(1, "database_go.png");
			this.imageList1.Images.SetKeyName(2, "database_delete.png");
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "*.xls|*.xls|*.xlsx|*.xlsx";
			// 
			// создатьToolStripMenuItem
			// 
			this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
			this.создатьToolStripMenuItem.Size = new System.Drawing.Size(62, 23);
			this.создатьToolStripMenuItem.Text = "Создать";
			// 
			// текстовыйФайлToolStripMenuItem
			// 
			this.текстовыйФайлToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("текстовыйФайлToolStripMenuItem.Image")));
			this.текстовыйФайлToolStripMenuItem.Name = "текстовыйФайлToolStripMenuItem";
			this.текстовыйФайлToolStripMenuItem.Size = new System.Drawing.Size(181, 23);
			this.текстовыйФайлToolStripMenuItem.Text = "Текстовый файл (*.txt, *rtf)";
			// 
			// открытьToolStripMenuItem
			// 
			this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
			this.открытьToolStripMenuItem.Size = new System.Drawing.Size(66, 23);
			this.открытьToolStripMenuItem.Text = "Открыть";
			// 
			// текстовыйФайлToolStripMenuItem1
			// 
			this.текстовыйФайлToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("текстовыйФайлToolStripMenuItem1.Image")));
			this.текстовыйФайлToolStripMenuItem1.Name = "текстовыйФайлToolStripMenuItem1";
			this.текстовыйФайлToolStripMenuItem1.Size = new System.Drawing.Size(158, 23);
			this.текстовыйФайлToolStripMenuItem1.Text = "Текстовый файл (*.txt)";
			// 
			// документWordpadToolStripMenuItem
			// 
			this.документWordpadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("документWordpadToolStripMenuItem.Image")));
			this.документWordpadToolStripMenuItem.Name = "документWordpadToolStripMenuItem";
			this.документWordpadToolStripMenuItem.Size = new System.Drawing.Size(172, 23);
			this.документWordpadToolStripMenuItem.Text = "Документ WordPad (*.rtf)";
			// 
			// excelФайлФормат2007ToolStripMenuItem
			// 
			this.excelФайлФормат2007ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("excelФайлФормат2007ToolStripMenuItem.Image")));
			this.excelФайлФормат2007ToolStripMenuItem.Name = "excelФайлФормат2007ToolStripMenuItem";
			this.excelФайлФормат2007ToolStripMenuItem.Size = new System.Drawing.Size(178, 23);
			this.excelФайлФормат2007ToolStripMenuItem.Text = "Excel файл (*.xls или *.xlsx)";
			this.excelФайлФормат2007ToolStripMenuItem.Click += new System.EventHandler(this.ExcelФайлФормат2007ToolStripMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
			// 
			// выходToolStripMenuItem
			// 
			this.выходToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("выходToolStripMenuItem.Image")));
			this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
			this.выходToolStripMenuItem.Size = new System.Drawing.Size(69, 23);
			this.выходToolStripMenuItem.Text = "Выход";
			this.выходToolStripMenuItem.Click += new System.EventHandler(this.ВыходToolStripMenuItemClick);
			// 
			// FormClient
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(912, 562);
			this.Controls.Add(this.consolePanel);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "FormClient";
			this.Text = "Агрегатор v 1.0";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClientFormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormClientFormClosed);
			this.Load += new System.EventHandler(this.FormClientLoad);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.consolePanel.ResumeLayout(false);
			this.consolePanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
