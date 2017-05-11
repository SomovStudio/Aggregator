/*
 * Создано в SharpDevelop.
 * Пользователь: Cartish
 * Дата: 18.03.2017
 * Время: 16:03
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace Aggregator.Client.Directories
{
	partial class FormUnits
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem создатьЗаписьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem изменитьЗаписьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem удалитьЗаписьToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem выбратьЗаписьToolStripMenuItem;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
		private System.Windows.Forms.ToolStripButton toolStripButton9;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripButton toolStripButton10;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUnits));
			this.panel1 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
			this.panel3 = new System.Windows.Forms.Panel();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.создатьЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.изменитьЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.удалитьЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.выбратьЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.buttonClose);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 325);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(611, 45);
			this.panel1.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(443, 10);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Выбрать";
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Visible = false;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.Location = new System.Drawing.Point(524, 10);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 0;
			this.buttonClose.Text = "Закрыть";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.toolStrip1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(611, 25);
			this.panel2.TabIndex = 3;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripButton1,
			this.toolStripButton2,
			this.toolStripButton3,
			this.toolStripSeparator5,
			this.toolStripComboBox1,
			this.toolStripButton9,
			this.toolStripSeparator6,
			this.toolStripButton10});
			this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(611, 25);
			this.toolStrip1.TabIndex = 18;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 20);
			this.toolStripButton1.Text = "Добавить";
			this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1Click);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(23, 20);
			this.toolStripButton2.Text = "Изменить";
			this.toolStripButton2.Click += new System.EventHandler(this.ToolStripButton2Click);
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(23, 20);
			this.toolStripButton3.Text = "Удалить";
			this.toolStripButton3.Click += new System.EventHandler(this.ToolStripButton3Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
			// 
			// toolStripComboBox1
			// 
			this.toolStripComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.toolStripComboBox1.Name = "toolStripComboBox1";
			this.toolStripComboBox1.Size = new System.Drawing.Size(200, 23);
			this.toolStripComboBox1.Text = "Введите данные для поиска";
			this.toolStripComboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ToolStripComboBox1KeyDown);
			// 
			// toolStripButton9
			// 
			this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
			this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton9.Name = "toolStripButton9";
			this.toolStripButton9.Size = new System.Drawing.Size(62, 20);
			this.toolStripButton9.Text = "Поиск";
			this.toolStripButton9.Click += new System.EventHandler(this.ToolStripButton9Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 23);
			// 
			// toolStripButton10
			// 
			this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
			this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton10.Name = "toolStripButton10";
			this.toolStripButton10.Size = new System.Drawing.Size(81, 20);
			this.toolStripButton10.Text = "Обновить";
			this.toolStripButton10.Click += new System.EventHandler(this.ToolStripButton10Click);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.listView1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 25);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(611, 300);
			this.panel3.TabIndex = 4;
			// 
			// listView1
			// 
			this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.columnHeader1,
			this.columnHeader2,
			this.columnHeader3,
			this.columnHeader4});
			this.listView1.ContextMenuStrip = this.contextMenuStrip1;
			this.listView1.Cursor = System.Windows.Forms.Cursors.Default;
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.LargeImageList = this.imageList1;
			this.listView1.Location = new System.Drawing.Point(0, 0);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(611, 300);
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.StateImageList = this.imageList1;
			this.listView1.TabIndex = 6;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "...";
			this.columnHeader1.Width = 40;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Наименование";
			this.columnHeader2.Width = 400;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "";
			this.columnHeader3.Width = 50;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "№";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.создатьЗаписьToolStripMenuItem,
			this.изменитьЗаписьToolStripMenuItem,
			this.удалитьЗаписьToolStripMenuItem,
			this.toolStripMenuItem2,
			this.выбратьЗаписьToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(172, 98);
			// 
			// создатьЗаписьToolStripMenuItem
			// 
			this.создатьЗаписьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("создатьЗаписьToolStripMenuItem.Image")));
			this.создатьЗаписьToolStripMenuItem.Name = "создатьЗаписьToolStripMenuItem";
			this.создатьЗаписьToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.создатьЗаписьToolStripMenuItem.Text = "Создать запись.";
			this.создатьЗаписьToolStripMenuItem.Click += new System.EventHandler(this.СоздатьЗаписьToolStripMenuItemClick);
			// 
			// изменитьЗаписьToolStripMenuItem
			// 
			this.изменитьЗаписьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("изменитьЗаписьToolStripMenuItem.Image")));
			this.изменитьЗаписьToolStripMenuItem.Name = "изменитьЗаписьToolStripMenuItem";
			this.изменитьЗаписьToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.изменитьЗаписьToolStripMenuItem.Text = "Изменить запись.";
			this.изменитьЗаписьToolStripMenuItem.Click += new System.EventHandler(this.ИзменитьЗаписьToolStripMenuItemClick);
			// 
			// удалитьЗаписьToolStripMenuItem
			// 
			this.удалитьЗаписьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("удалитьЗаписьToolStripMenuItem.Image")));
			this.удалитьЗаписьToolStripMenuItem.Name = "удалитьЗаписьToolStripMenuItem";
			this.удалитьЗаписьToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.удалитьЗаписьToolStripMenuItem.Text = "Удалить запись.";
			this.удалитьЗаписьToolStripMenuItem.Click += new System.EventHandler(this.УдалитьЗаписьToolStripMenuItemClick);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(168, 6);
			this.toolStripMenuItem2.Visible = false;
			// 
			// выбратьЗаписьToolStripMenuItem
			// 
			this.выбратьЗаписьToolStripMenuItem.Name = "выбратьЗаписьToolStripMenuItem";
			this.выбратьЗаписьToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.выбратьЗаписьToolStripMenuItem.Text = "Выбрать запись.";
			this.выбратьЗаписьToolStripMenuItem.Visible = false;
			this.выбратьЗаписьToolStripMenuItem.Click += new System.EventHandler(this.ВыбратьЗаписьToolStripMenuItemClick);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "folder.png");
			this.imageList1.Images.SetKeyName(1, "page.png");
			// 
			// FormUnits
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(611, 370);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormUnits";
			this.Text = "Единицы измерения";
			this.Activated += new System.EventHandler(this.FormUnitsActivated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormUnitsFormClosed);
			this.Load += new System.EventHandler(this.FormUnitsLoad);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
