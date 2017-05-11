/*
 * Создано в SharpDevelop.
 * Пользователь: Cartish
 * Дата: 14.04.2017
 * Время: 7:09
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace Aggregator.Client.Documents.Order
{
	partial class FormOrderNomenclature
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button findButton;
		private System.Windows.Forms.TextBox searchTextBox;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem выбратьНоменклатуруToolStripMenuItem;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.Label label1;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOrderNomenclature));
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.findButton = new System.Windows.Forms.Button();
			this.searchTextBox = new System.Windows.Forms.TextBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.выбратьНоменклатуруToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
			this.panel1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.findButton);
			this.panel1.Controls.Add(this.searchTextBox);
			this.panel1.Controls.Add(this.buttonSave);
			this.panel1.Controls.Add(this.buttonCancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 241);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(407, 72);
			this.panel1.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(12, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(383, 31);
			this.label1.TabIndex = 19;
			this.label1.Text = "...";
			// 
			// findButton
			// 
			this.findButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.findButton.Image = ((System.Drawing.Image)(resources.GetObject("findButton.Image")));
			this.findButton.Location = new System.Drawing.Point(208, 37);
			this.findButton.Name = "findButton";
			this.findButton.Size = new System.Drawing.Size(25, 23);
			this.findButton.TabIndex = 18;
			this.findButton.UseVisualStyleBackColor = true;
			this.findButton.Click += new System.EventHandler(this.FindButtonClick);
			// 
			// searchTextBox
			// 
			this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.searchTextBox.Location = new System.Drawing.Point(12, 39);
			this.searchTextBox.Name = "searchTextBox";
			this.searchTextBox.Size = new System.Drawing.Size(195, 20);
			this.searchTextBox.TabIndex = 2;
			this.searchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1KeyDown);
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
			this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonSave.Location = new System.Drawing.Point(239, 37);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 1;
			this.buttonSave.Text = "Выбрать";
			this.buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSaveClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
			this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonCancel.Location = new System.Drawing.Point(320, 37);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 0;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.выбратьНоменклатуруToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(204, 26);
			// 
			// выбратьНоменклатуруToolStripMenuItem
			// 
			this.выбратьНоменклатуруToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("выбратьНоменклатуруToolStripMenuItem.Image")));
			this.выбратьНоменклатуруToolStripMenuItem.Name = "выбратьНоменклатуруToolStripMenuItem";
			this.выбратьНоменклатуруToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.выбратьНоменклатуруToolStripMenuItem.Text = "Выбрать номенклатуру";
			this.выбратьНоменклатуруToolStripMenuItem.Click += new System.EventHandler(this.ВыбратьНоменклатуруToolStripMenuItemClick);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "page.png");
			// 
			// listView1
			// 
			this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.columnHeader1,
			this.columnHeader2,
			this.columnHeader3,
			this.columnHeader4,
			this.columnHeader5,
			this.columnHeader6,
			this.columnHeader7,
			this.columnHeader8,
			this.columnHeader9,
			this.columnHeader10,
			this.columnHeader11,
			this.columnHeader12,
			this.columnHeader13,
			this.columnHeader14,
			this.columnHeader15});
			this.listView1.ContextMenuStrip = this.contextMenuStrip1;
			this.listView1.Cursor = System.Windows.Forms.Cursors.Default;
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.LargeImageList = this.imageList1;
			this.listView1.Location = new System.Drawing.Point(0, 0);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(407, 241);
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.StateImageList = this.imageList1;
			this.listView1.TabIndex = 8;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.ListView1SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "...";
			this.columnHeader1.Width = 40;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Наименование";
			this.columnHeader2.Width = 250;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Цена";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader3.Width = 100;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Производитель";
			this.columnHeader4.Width = 250;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Остаток";
			this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Срок годности";
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Скидка №1";
			this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Скидка №2";
			this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "Скидка №3";
			this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "Скидка №4";
			this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "Код товара";
			// 
			// columnHeader12
			// 
			this.columnHeader12.Text = "Серия";
			// 
			// columnHeader13
			// 
			this.columnHeader13.Text = "Артикул";
			// 
			// columnHeader14
			// 
			this.columnHeader14.Text = "Контрагент";
			this.columnHeader14.Width = 250;
			// 
			// columnHeader15
			// 
			this.columnHeader15.Text = "Прайс-лист";
			this.columnHeader15.Width = 100;
			// 
			// FormOrderNomenclature
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(407, 313);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormOrderNomenclature";
			this.Text = "Прайс-лист конрагента";
			this.Activated += new System.EventHandler(this.FormOrderNomenclatureActivated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormOrderNomenclatureFormClosed);
			this.Load += new System.EventHandler(this.FormOrderNomenclatureLoad);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
