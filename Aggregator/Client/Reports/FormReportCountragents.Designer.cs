/*
 * Создано в SharpDevelop.
 * Пользователь: Cartish
 * Дата: 08.05.2017
 * Время: 14:55
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace Aggregator.Client.Reports
{
	partial class FormReportCountragents
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox counteragentTextBox;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox nameCheckBox;
		private System.Windows.Forms.CheckBox unitsСheckBox;
		private System.Windows.Forms.CheckBox amountСheckBox;
		private System.Windows.Forms.CheckBox priceСheckBox;
		private System.Windows.Forms.CheckBox discountСheckBox;
		private System.Windows.Forms.CheckBox manufacturerСheckBox;
		private System.Windows.Forms.CheckBox termСheckBox;
		private System.Windows.Forms.CheckBox codeSeriesArticleСheckBox;
		private System.Windows.Forms.CheckBox orderCheckBox;
		private System.Windows.Forms.CheckBox PurchasePlanCheckBox;
		private System.Windows.Forms.Button buttonPrintPreview;
		private System.Windows.Forms.Button buttonPrint;
		private System.Windows.Forms.Button buttonSaveExcel;
		private System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.PrintDialog printDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReportCountragents));
			this.panel2 = new System.Windows.Forms.Panel();
			this.buttonSaveExcel = new System.Windows.Forms.Button();
			this.buttonPrintPreview = new System.Windows.Forms.Button();
			this.buttonPrint = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.counteragentTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.PurchasePlanCheckBox = new System.Windows.Forms.CheckBox();
			this.orderCheckBox = new System.Windows.Forms.CheckBox();
			this.codeSeriesArticleСheckBox = new System.Windows.Forms.CheckBox();
			this.termСheckBox = new System.Windows.Forms.CheckBox();
			this.manufacturerСheckBox = new System.Windows.Forms.CheckBox();
			this.discountСheckBox = new System.Windows.Forms.CheckBox();
			this.priceСheckBox = new System.Windows.Forms.CheckBox();
			this.amountСheckBox = new System.Windows.Forms.CheckBox();
			this.unitsСheckBox = new System.Windows.Forms.CheckBox();
			this.nameCheckBox = new System.Windows.Forms.CheckBox();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.printDialog1 = new System.Windows.Forms.PrintDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.buttonSaveExcel);
			this.panel2.Controls.Add(this.buttonPrintPreview);
			this.panel2.Controls.Add(this.buttonPrint);
			this.panel2.Controls.Add(this.buttonCancel);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 397);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(761, 51);
			this.panel2.TabIndex = 3;
			// 
			// buttonSaveExcel
			// 
			this.buttonSaveExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSaveExcel.Image = ((System.Drawing.Image)(resources.GetObject("buttonSaveExcel.Image")));
			this.buttonSaveExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonSaveExcel.Location = new System.Drawing.Point(541, 16);
			this.buttonSaveExcel.Name = "buttonSaveExcel";
			this.buttonSaveExcel.Size = new System.Drawing.Size(123, 23);
			this.buttonSaveExcel.TabIndex = 43;
			this.buttonSaveExcel.Text = "Сохранить в Excel";
			this.buttonSaveExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonSaveExcel.UseVisualStyleBackColor = true;
			this.buttonSaveExcel.Click += new System.EventHandler(this.ButtonSaveExcelClick);
			// 
			// buttonPrintPreview
			// 
			this.buttonPrintPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("buttonPrintPreview.Image")));
			this.buttonPrintPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonPrintPreview.Location = new System.Drawing.Point(15, 16);
			this.buttonPrintPreview.Name = "buttonPrintPreview";
			this.buttonPrintPreview.Size = new System.Drawing.Size(85, 23);
			this.buttonPrintPreview.TabIndex = 42;
			this.buttonPrintPreview.Text = "Просмотр";
			this.buttonPrintPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonPrintPreview.UseVisualStyleBackColor = true;
			this.buttonPrintPreview.Click += new System.EventHandler(this.ButtonPrintPreviewClick);
			// 
			// buttonPrint
			// 
			this.buttonPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonPrint.Image = ((System.Drawing.Image)(resources.GetObject("buttonPrint.Image")));
			this.buttonPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonPrint.Location = new System.Drawing.Point(106, 16);
			this.buttonPrint.Name = "buttonPrint";
			this.buttonPrint.Size = new System.Drawing.Size(75, 23);
			this.buttonPrint.TabIndex = 41;
			this.buttonPrint.Text = "Печать.";
			this.buttonPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonPrint.UseVisualStyleBackColor = true;
			this.buttonPrint.Click += new System.EventHandler(this.ButtonPrintClick);
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
			this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonSave.Location = new System.Drawing.Point(638, 37);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(111, 23);
			this.buttonSave.TabIndex = 1;
			this.buttonSave.Text = "Сформировать";
			this.buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSaveClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
			this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonCancel.Location = new System.Drawing.Point(670, 16);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(79, 23);
			this.buttonCancel.TabIndex = 0;
			this.buttonCancel.Text = "Закрыть";
			this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.dateTimePicker2);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.buttonSave);
			this.panel1.Controls.Add(this.dateTimePicker1);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.counteragentTextBox);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(761, 63);
			this.panel1.TabIndex = 4;
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.CustomFormat = "dd.MM.yyyy";
			this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker2.Location = new System.Drawing.Point(212, 38);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(96, 20);
			this.dateTimePicker2.TabIndex = 32;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(187, 34);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 23);
			this.label2.TabIndex = 35;
			this.label2.Text = "по";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
			this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label3.Location = new System.Drawing.Point(3, 34);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(74, 23);
			this.label3.TabIndex = 34;
			this.label3.Text = "Период с";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.CustomFormat = "dd.MM.yyyy";
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker1.Location = new System.Drawing.Point(85, 37);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(96, 20);
			this.dateTimePicker1.TabIndex = 31;
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button2.Location = new System.Drawing.Point(470, 12);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(26, 20);
			this.button2.TabIndex = 30;
			this.button2.Text = "X";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.Location = new System.Drawing.Point(443, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(26, 20);
			this.button1.TabIndex = 29;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// counteragentTextBox
			// 
			this.counteragentTextBox.Location = new System.Drawing.Point(85, 12);
			this.counteragentTextBox.Name = "counteragentTextBox";
			this.counteragentTextBox.Size = new System.Drawing.Size(356, 20);
			this.counteragentTextBox.TabIndex = 28;
			// 
			// label1
			// 
			this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
			this.label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.label1.Location = new System.Drawing.Point(3, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(101, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Контрагент:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.Size = new System.Drawing.Size(598, 334);
			this.dataGridView1.TabIndex = 5;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 63);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
			this.splitContainer1.Size = new System.Drawing.Size(761, 334);
			this.splitContainer1.SplitterDistance = 159;
			this.splitContainer1.TabIndex = 6;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.PurchasePlanCheckBox);
			this.groupBox1.Controls.Add(this.orderCheckBox);
			this.groupBox1.Controls.Add(this.codeSeriesArticleСheckBox);
			this.groupBox1.Controls.Add(this.termСheckBox);
			this.groupBox1.Controls.Add(this.manufacturerСheckBox);
			this.groupBox1.Controls.Add(this.discountСheckBox);
			this.groupBox1.Controls.Add(this.priceСheckBox);
			this.groupBox1.Controls.Add(this.amountСheckBox);
			this.groupBox1.Controls.Add(this.unitsСheckBox);
			this.groupBox1.Controls.Add(this.nameCheckBox);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(159, 334);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Колонки:";
			// 
			// PurchasePlanCheckBox
			// 
			this.PurchasePlanCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.PurchasePlanCheckBox.Location = new System.Drawing.Point(12, 289);
			this.PurchasePlanCheckBox.Name = "PurchasePlanCheckBox";
			this.PurchasePlanCheckBox.Size = new System.Drawing.Size(141, 24);
			this.PurchasePlanCheckBox.TabIndex = 9;
			this.PurchasePlanCheckBox.Text = "План закупок";
			this.PurchasePlanCheckBox.UseVisualStyleBackColor = true;
			// 
			// orderCheckBox
			// 
			this.orderCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.orderCheckBox.Location = new System.Drawing.Point(12, 259);
			this.orderCheckBox.Name = "orderCheckBox";
			this.orderCheckBox.Size = new System.Drawing.Size(141, 24);
			this.orderCheckBox.TabIndex = 8;
			this.orderCheckBox.Text = "Заказ";
			this.orderCheckBox.UseVisualStyleBackColor = true;
			// 
			// codeSeriesArticleСheckBox
			// 
			this.codeSeriesArticleСheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.codeSeriesArticleСheckBox.Location = new System.Drawing.Point(12, 19);
			this.codeSeriesArticleСheckBox.Name = "codeSeriesArticleСheckBox";
			this.codeSeriesArticleСheckBox.Size = new System.Drawing.Size(141, 24);
			this.codeSeriesArticleСheckBox.TabIndex = 7;
			this.codeSeriesArticleСheckBox.Text = "Код, серия, артикул";
			this.codeSeriesArticleСheckBox.UseVisualStyleBackColor = true;
			// 
			// termСheckBox
			// 
			this.termСheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.termСheckBox.Location = new System.Drawing.Point(12, 229);
			this.termСheckBox.Name = "termСheckBox";
			this.termСheckBox.Size = new System.Drawing.Size(141, 24);
			this.termСheckBox.TabIndex = 6;
			this.termСheckBox.Text = "Срок годности";
			this.termСheckBox.UseVisualStyleBackColor = true;
			// 
			// manufacturerСheckBox
			// 
			this.manufacturerСheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.manufacturerСheckBox.Location = new System.Drawing.Point(12, 199);
			this.manufacturerСheckBox.Name = "manufacturerСheckBox";
			this.manufacturerСheckBox.Size = new System.Drawing.Size(141, 24);
			this.manufacturerСheckBox.TabIndex = 5;
			this.manufacturerСheckBox.Text = "Производитель";
			this.manufacturerСheckBox.UseVisualStyleBackColor = true;
			// 
			// discountСheckBox
			// 
			this.discountСheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.discountСheckBox.Location = new System.Drawing.Point(12, 169);
			this.discountСheckBox.Name = "discountСheckBox";
			this.discountСheckBox.Size = new System.Drawing.Size(141, 24);
			this.discountСheckBox.TabIndex = 4;
			this.discountСheckBox.Text = "Скидка";
			this.discountСheckBox.UseVisualStyleBackColor = true;
			// 
			// priceСheckBox
			// 
			this.priceСheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.priceСheckBox.Checked = true;
			this.priceСheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.priceСheckBox.Location = new System.Drawing.Point(12, 139);
			this.priceСheckBox.Name = "priceСheckBox";
			this.priceСheckBox.Size = new System.Drawing.Size(141, 24);
			this.priceСheckBox.TabIndex = 3;
			this.priceСheckBox.Text = "Цена";
			this.priceСheckBox.UseVisualStyleBackColor = true;
			// 
			// amountСheckBox
			// 
			this.amountСheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.amountСheckBox.Checked = true;
			this.amountСheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.amountСheckBox.Location = new System.Drawing.Point(12, 109);
			this.amountСheckBox.Name = "amountСheckBox";
			this.amountСheckBox.Size = new System.Drawing.Size(141, 24);
			this.amountСheckBox.TabIndex = 2;
			this.amountСheckBox.Text = "Количество";
			this.amountСheckBox.UseVisualStyleBackColor = true;
			// 
			// unitsСheckBox
			// 
			this.unitsСheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.unitsСheckBox.Checked = true;
			this.unitsСheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.unitsСheckBox.Location = new System.Drawing.Point(12, 79);
			this.unitsСheckBox.Name = "unitsСheckBox";
			this.unitsСheckBox.Size = new System.Drawing.Size(141, 24);
			this.unitsСheckBox.TabIndex = 1;
			this.unitsСheckBox.Text = "Единицы измерения";
			this.unitsСheckBox.UseVisualStyleBackColor = true;
			// 
			// nameCheckBox
			// 
			this.nameCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.nameCheckBox.Checked = true;
			this.nameCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.nameCheckBox.Location = new System.Drawing.Point(12, 49);
			this.nameCheckBox.Name = "nameCheckBox";
			this.nameCheckBox.Size = new System.Drawing.Size(141, 24);
			this.nameCheckBox.TabIndex = 0;
			this.nameCheckBox.Text = "Наименование";
			this.nameCheckBox.UseVisualStyleBackColor = true;
			// 
			// printDocument1
			// 
			this.printDocument1.OriginAtMargins = true;
			this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument1PrintPage);
			// 
			// printDialog1
			// 
			this.printDialog1.Document = this.printDocument1;
			this.printDialog1.UseEXDialog = true;
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.Filter = "Microsoft Excel 97/2000/XP (.xls)|*.xls";
			// 
			// FormReportCountragents
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(761, 448);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormReportCountragents";
			this.Text = "Отчет по контрагенту";
			this.Activated += new System.EventHandler(this.FormReportCountragentsActivated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormReportCountragentsFormClosed);
			this.Load += new System.EventHandler(this.FormReportCountragentsLoad);
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
