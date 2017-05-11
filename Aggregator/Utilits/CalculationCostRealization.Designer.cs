/*
 * Создано в SharpDevelop.
 * Пользователь: Cartish
 * Дата: 20.04.2017
 * Время: 10:16
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace Aggregator.Utilits
{
	partial class CalculationCostRealization
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonSaveExcel;
		private System.Windows.Forms.Button buttonPrintPreview;
		private System.Windows.Forms.Button buttonPrint;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Button findButton;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button buttonNomenclaturesDelete;
		private System.Windows.Forms.Button buttonNomenclaturesAdd;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Button buttonNomenclatureDelete;
		private System.Windows.Forms.Button buttonNomenclatureAdd;
		private System.Windows.Forms.ListView listViewNomenclature;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ImageList imageList1;
		private System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.PrintDialog printDialog1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox priceTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Button button14;
		private System.Windows.Forms.TextBox amountTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.TextBox unitsTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox resultTextBox;
		private System.Windows.Forms.TextBox extraChargeTextBox;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.TextBox costPriceTextBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox price2TextBox;
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalculationCostRealization));
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonSaveExcel = new System.Windows.Forms.Button();
			this.buttonPrintPreview = new System.Windows.Forms.Button();
			this.buttonPrint = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.panel5 = new System.Windows.Forms.Panel();
			this.findButton = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.buttonNomenclaturesDelete = new System.Windows.Forms.Button();
			this.buttonNomenclaturesAdd = new System.Windows.Forms.Button();
			this.panel6 = new System.Windows.Forms.Panel();
			this.buttonNomenclatureDelete = new System.Windows.Forms.Button();
			this.buttonNomenclatureAdd = new System.Windows.Forms.Button();
			this.listViewNomenclature = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.printDialog1 = new System.Windows.Forms.PrintDialog();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.priceTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.button13 = new System.Windows.Forms.Button();
			this.button14 = new System.Windows.Forms.Button();
			this.amountTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.button9 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.unitsTextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.price2TextBox = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.resultTextBox = new System.Windows.Forms.TextBox();
			this.extraChargeTextBox = new System.Windows.Forms.TextBox();
			this.button5 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.costPriceTextBox = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.panel1.SuspendLayout();
			this.panel5.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.buttonSaveExcel);
			this.panel1.Controls.Add(this.buttonPrintPreview);
			this.panel1.Controls.Add(this.buttonPrint);
			this.panel1.Controls.Add(this.buttonCancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 437);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(791, 45);
			this.panel1.TabIndex = 5;
			// 
			// buttonSaveExcel
			// 
			this.buttonSaveExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSaveExcel.Image = ((System.Drawing.Image)(resources.GetObject("buttonSaveExcel.Image")));
			this.buttonSaveExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonSaveExcel.Location = new System.Drawing.Point(567, 10);
			this.buttonSaveExcel.Name = "buttonSaveExcel";
			this.buttonSaveExcel.Size = new System.Drawing.Size(123, 23);
			this.buttonSaveExcel.TabIndex = 41;
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
			this.buttonPrintPreview.Location = new System.Drawing.Point(7, 11);
			this.buttonPrintPreview.Name = "buttonPrintPreview";
			this.buttonPrintPreview.Size = new System.Drawing.Size(85, 23);
			this.buttonPrintPreview.TabIndex = 40;
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
			this.buttonPrint.Location = new System.Drawing.Point(98, 11);
			this.buttonPrint.Name = "buttonPrint";
			this.buttonPrint.Size = new System.Drawing.Size(75, 23);
			this.buttonPrint.TabIndex = 39;
			this.buttonPrint.Text = "Печать.";
			this.buttonPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonPrint.UseVisualStyleBackColor = true;
			this.buttonPrint.Click += new System.EventHandler(this.ButtonPrintClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
			this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonCancel.Location = new System.Drawing.Point(696, 10);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(83, 23);
			this.buttonCancel.TabIndex = 0;
			this.buttonCancel.Text = "Отменить";
			this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.findButton);
			this.panel5.Controls.Add(this.comboBox1);
			this.panel5.Controls.Add(this.buttonNomenclaturesDelete);
			this.panel5.Controls.Add(this.buttonNomenclaturesAdd);
			this.panel5.Controls.Add(this.panel6);
			this.panel5.Controls.Add(this.buttonNomenclatureDelete);
			this.panel5.Controls.Add(this.buttonNomenclatureAdd);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(0, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(791, 29);
			this.panel5.TabIndex = 6;
			// 
			// findButton
			// 
			this.findButton.Image = ((System.Drawing.Image)(resources.GetObject("findButton.Image")));
			this.findButton.Location = new System.Drawing.Point(343, 3);
			this.findButton.Name = "findButton";
			this.findButton.Size = new System.Drawing.Size(25, 23);
			this.findButton.TabIndex = 19;
			this.findButton.UseVisualStyleBackColor = true;
			this.findButton.Click += new System.EventHandler(this.FindButtonClick);
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(145, 4);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(196, 21);
			this.comboBox1.TabIndex = 18;
			this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ComboBox1KeyDown);
			// 
			// buttonNomenclaturesDelete
			// 
			this.buttonNomenclaturesDelete.Image = ((System.Drawing.Image)(resources.GetObject("buttonNomenclaturesDelete.Image")));
			this.buttonNomenclaturesDelete.Location = new System.Drawing.Point(100, 3);
			this.buttonNomenclaturesDelete.Name = "buttonNomenclaturesDelete";
			this.buttonNomenclaturesDelete.Size = new System.Drawing.Size(25, 23);
			this.buttonNomenclaturesDelete.TabIndex = 14;
			this.buttonNomenclaturesDelete.UseVisualStyleBackColor = true;
			this.buttonNomenclaturesDelete.Click += new System.EventHandler(this.ButtonNomenclaturesDeleteClick);
			// 
			// buttonNomenclaturesAdd
			// 
			this.buttonNomenclaturesAdd.Image = ((System.Drawing.Image)(resources.GetObject("buttonNomenclaturesAdd.Image")));
			this.buttonNomenclaturesAdd.Location = new System.Drawing.Point(38, 3);
			this.buttonNomenclaturesAdd.Name = "buttonNomenclaturesAdd";
			this.buttonNomenclaturesAdd.Size = new System.Drawing.Size(25, 23);
			this.buttonNomenclaturesAdd.TabIndex = 13;
			this.buttonNomenclaturesAdd.UseVisualStyleBackColor = true;
			this.buttonNomenclaturesAdd.Click += new System.EventHandler(this.ButtonNomenclaturesAddClick);
			// 
			// panel6
			// 
			this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel6.Location = new System.Drawing.Point(131, 3);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(4, 23);
			this.panel6.TabIndex = 12;
			// 
			// buttonNomenclatureDelete
			// 
			this.buttonNomenclatureDelete.Image = ((System.Drawing.Image)(resources.GetObject("buttonNomenclatureDelete.Image")));
			this.buttonNomenclatureDelete.Location = new System.Drawing.Point(69, 3);
			this.buttonNomenclatureDelete.Name = "buttonNomenclatureDelete";
			this.buttonNomenclatureDelete.Size = new System.Drawing.Size(25, 23);
			this.buttonNomenclatureDelete.TabIndex = 11;
			this.buttonNomenclatureDelete.UseVisualStyleBackColor = true;
			this.buttonNomenclatureDelete.Click += new System.EventHandler(this.ButtonNomenclatureDeleteClick);
			// 
			// buttonNomenclatureAdd
			// 
			this.buttonNomenclatureAdd.Image = ((System.Drawing.Image)(resources.GetObject("buttonNomenclatureAdd.Image")));
			this.buttonNomenclatureAdd.Location = new System.Drawing.Point(7, 3);
			this.buttonNomenclatureAdd.Name = "buttonNomenclatureAdd";
			this.buttonNomenclatureAdd.Size = new System.Drawing.Size(25, 23);
			this.buttonNomenclatureAdd.TabIndex = 10;
			this.buttonNomenclatureAdd.UseVisualStyleBackColor = true;
			this.buttonNomenclatureAdd.Click += new System.EventHandler(this.ButtonNomenclatureAddClick);
			// 
			// listViewNomenclature
			// 
			this.listViewNomenclature.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.listViewNomenclature.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.columnHeader1,
			this.columnHeader2,
			this.columnHeader3,
			this.columnHeader4,
			this.columnHeader5,
			this.columnHeader6});
			this.listViewNomenclature.Cursor = System.Windows.Forms.Cursors.Default;
			this.listViewNomenclature.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewNomenclature.FullRowSelect = true;
			this.listViewNomenclature.LargeImageList = this.imageList1;
			this.listViewNomenclature.Location = new System.Drawing.Point(0, 29);
			this.listViewNomenclature.MultiSelect = false;
			this.listViewNomenclature.Name = "listViewNomenclature";
			this.listViewNomenclature.Size = new System.Drawing.Size(791, 274);
			this.listViewNomenclature.SmallImageList = this.imageList1;
			this.listViewNomenclature.StateImageList = this.imageList1;
			this.listViewNomenclature.TabIndex = 10;
			this.listViewNomenclature.UseCompatibleStateImageBehavior = false;
			this.listViewNomenclature.View = System.Windows.Forms.View.Details;
			this.listViewNomenclature.SelectedIndexChanged += new System.EventHandler(this.ListViewNomenclatureSelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "...";
			this.columnHeader1.Width = 40;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Наименование:";
			this.columnHeader2.Width = 300;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Ед.изм:";
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Вес / Кол-во:";
			this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader4.Width = 100;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Цена:";
			this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader5.Width = 100;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Сумма:";
			this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader6.Width = 100;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "basket.png");
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
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitContainer1.Location = new System.Drawing.Point(0, 341);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
			this.splitContainer1.Size = new System.Drawing.Size(791, 96);
			this.splitContainer1.SplitterDistance = 381;
			this.splitContainer1.TabIndex = 11;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.priceTextBox);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.button13);
			this.groupBox1.Controls.Add(this.button14);
			this.groupBox1.Controls.Add(this.amountTextBox);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.button9);
			this.groupBox1.Controls.Add(this.button7);
			this.groupBox1.Controls.Add(this.button8);
			this.groupBox1.Controls.Add(this.button6);
			this.groupBox1.Controls.Add(this.unitsTextBox);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(381, 96);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "...";
			// 
			// priceTextBox
			// 
			this.priceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.priceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.priceTextBox.Location = new System.Drawing.Point(102, 65);
			this.priceTextBox.Name = "priceTextBox";
			this.priceTextBox.Size = new System.Drawing.Size(225, 20);
			this.priceTextBox.TabIndex = 26;
			this.priceTextBox.Text = "0,00";
			this.priceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.priceTextBox.TextChanged += new System.EventHandler(this.PriceTextBoxTextChanged);
			this.priceTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PriceTextBoxKeyDown);
			this.priceTextBox.LostFocus += new System.EventHandler(this.PriceTextBoxLostFocus);
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.Location = new System.Drawing.Point(10, 68);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 17);
			this.label6.TabIndex = 25;
			this.label6.Text = "Цена:";
			// 
			// button13
			// 
			this.button13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button13.Image = ((System.Drawing.Image)(resources.GetObject("button13.Image")));
			this.button13.Location = new System.Drawing.Point(328, 65);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(26, 20);
			this.button13.TabIndex = 28;
			this.button13.UseVisualStyleBackColor = true;
			this.button13.Click += new System.EventHandler(this.Button13Click);
			// 
			// button14
			// 
			this.button14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button14.Location = new System.Drawing.Point(356, 65);
			this.button14.Name = "button14";
			this.button14.Size = new System.Drawing.Size(20, 20);
			this.button14.TabIndex = 27;
			this.button14.Text = "X";
			this.button14.UseVisualStyleBackColor = true;
			this.button14.Click += new System.EventHandler(this.Button14Click);
			// 
			// amountTextBox
			// 
			this.amountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.amountTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.amountTextBox.Location = new System.Drawing.Point(102, 42);
			this.amountTextBox.Name = "amountTextBox";
			this.amountTextBox.Size = new System.Drawing.Size(225, 20);
			this.amountTextBox.TabIndex = 4;
			this.amountTextBox.Text = "0,00";
			this.amountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.amountTextBox.TextChanged += new System.EventHandler(this.AmountTextBoxTextChanged);
			this.amountTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AmountTextBoxKeyDown);
			this.amountTextBox.LostFocus += new System.EventHandler(this.AmountTextBoxLostFocus);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(10, 45);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 17);
			this.label4.TabIndex = 1;
			this.label4.Text = "Вес / Кол-во:";
			// 
			// button9
			// 
			this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button9.Location = new System.Drawing.Point(356, 19);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(20, 20);
			this.button9.TabIndex = 24;
			this.button9.Text = "X";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.Button9Click);
			// 
			// button7
			// 
			this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
			this.button7.Location = new System.Drawing.Point(328, 42);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(26, 20);
			this.button7.TabIndex = 20;
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.Button7Click);
			// 
			// button8
			// 
			this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button8.Image = ((System.Drawing.Image)(resources.GetObject("button8.Image")));
			this.button8.Location = new System.Drawing.Point(328, 19);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(26, 20);
			this.button8.TabIndex = 23;
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.Button8Click);
			// 
			// button6
			// 
			this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button6.Location = new System.Drawing.Point(356, 42);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(20, 20);
			this.button6.TabIndex = 19;
			this.button6.Text = "X";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.Button6Click);
			// 
			// unitsTextBox
			// 
			this.unitsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.unitsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.unitsTextBox.Location = new System.Drawing.Point(102, 19);
			this.unitsTextBox.Name = "unitsTextBox";
			this.unitsTextBox.Size = new System.Drawing.Size(225, 20);
			this.unitsTextBox.TabIndex = 5;
			this.unitsTextBox.TextChanged += new System.EventHandler(this.UnitsTextBoxTextChanged);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.Location = new System.Drawing.Point(10, 22);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 17);
			this.label5.TabIndex = 2;
			this.label5.Text = "Ед. измерения:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.price2TextBox);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.resultTextBox);
			this.groupBox2.Controls.Add(this.extraChargeTextBox);
			this.groupBox2.Controls.Add(this.button5);
			this.groupBox2.Controls.Add(this.button10);
			this.groupBox2.Controls.Add(this.costPriceTextBox);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(406, 96);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Итоги:";
			// 
			// price2TextBox
			// 
			this.price2TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.price2TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.price2TextBox.Location = new System.Drawing.Point(294, 43);
			this.price2TextBox.Name = "price2TextBox";
			this.price2TextBox.ReadOnly = true;
			this.price2TextBox.Size = new System.Drawing.Size(106, 20);
			this.price2TextBox.TabIndex = 29;
			this.price2TextBox.Text = "0,00";
			this.price2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label10.Location = new System.Drawing.Point(257, 46);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(48, 18);
			this.label10.TabIndex = 28;
			this.label10.Text = "Цена:";
			// 
			// resultTextBox
			// 
			this.resultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.resultTextBox.Location = new System.Drawing.Point(137, 66);
			this.resultTextBox.Name = "resultTextBox";
			this.resultTextBox.ReadOnly = true;
			this.resultTextBox.Size = new System.Drawing.Size(263, 20);
			this.resultTextBox.TabIndex = 27;
			this.resultTextBox.Text = "0,00";
			this.resultTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// extraChargeTextBox
			// 
			this.extraChargeTextBox.Location = new System.Drawing.Point(137, 43);
			this.extraChargeTextBox.Name = "extraChargeTextBox";
			this.extraChargeTextBox.Size = new System.Drawing.Size(65, 20);
			this.extraChargeTextBox.TabIndex = 24;
			this.extraChargeTextBox.Text = "0,00";
			this.extraChargeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.extraChargeTextBox.TextChanged += new System.EventHandler(this.ExtraChargeTextBoxTextChanged);
			this.extraChargeTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExtraChargeTextBoxKeyDown);
			this.extraChargeTextBox.LostFocus += new System.EventHandler(this.ExtraChargeTextBoxLostFocus);
			// 
			// button5
			// 
			this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
			this.button5.Location = new System.Drawing.Point(203, 43);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(26, 20);
			this.button5.TabIndex = 26;
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.Button5Click);
			// 
			// button10
			// 
			this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button10.Location = new System.Drawing.Point(231, 43);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(20, 20);
			this.button10.TabIndex = 25;
			this.button10.Text = "X";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.Button10Click);
			// 
			// costPriceTextBox
			// 
			this.costPriceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.costPriceTextBox.Location = new System.Drawing.Point(137, 19);
			this.costPriceTextBox.Name = "costPriceTextBox";
			this.costPriceTextBox.ReadOnly = true;
			this.costPriceTextBox.Size = new System.Drawing.Size(263, 20);
			this.costPriceTextBox.TabIndex = 21;
			this.costPriceTextBox.Text = "0,00";
			this.costPriceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(6, 69);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(147, 23);
			this.label8.TabIndex = 2;
			this.label8.Text = "Стоимость реализации:";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(6, 46);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(125, 23);
			this.label7.TabIndex = 1;
			this.label7.Text = "Торговая наценка (%):";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(6, 22);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 23);
			this.label9.TabIndex = 0;
			this.label9.Text = "Себестоимость:";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textBox3);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.textBox2);
			this.groupBox3.Controls.Add(this.textBox1);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox3.Location = new System.Drawing.Point(0, 303);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(791, 38);
			this.groupBox3.TabIndex = 12;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Всего:";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(505, 12);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(165, 20);
			this.textBox3.TabIndex = 5;
			this.textBox3.Text = "0,00";
			this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(458, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 19);
			this.label3.TabIndex = 4;
			this.label3.Text = "Сумма:";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(291, 12);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(165, 20);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "0,00";
			this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(83, 12);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(165, 20);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "0,00";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(254, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 19);
			this.label2.TabIndex = 1;
			this.label2.Text = "Цена:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "Вес / Кол-во:";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.Filter = "Microsoft Excel 97/2000/XP (.xls)|*.xls";
			// 
			// CalculationCostRealization
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(791, 482);
			this.Controls.Add(this.listViewNomenclature);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CalculationCostRealization";
			this.Text = "Расчет: Стоимость реализации";
			this.Activated += new System.EventHandler(this.FormCalculationCostRealizationActivated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCalculationCostRealizationFormClosed);
			this.Load += new System.EventHandler(this.FormCalculationCostRealizationLoad);
			this.panel1.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
