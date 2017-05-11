/*
 * Создано в SharpDevelop.
 * Пользователь: Cartish
 * Дата: 17.03.2017
 * Время: 9:44
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace Aggregator.Client.Directories
{
	partial class FormNomenclatureFile
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox idTextBox;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox foldersComboBox;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.TextBox codeTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox seriesTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox articleTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox manufacturerTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox priceTextBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.TextBox unitsTextBox;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNomenclatureFile));
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.button9 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.unitsTextBox = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.button7 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.priceTextBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.manufacturerTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.articleTextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.seriesTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.codeTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.button11 = new System.Windows.Forms.Button();
			this.foldersComboBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.idTextBox = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.buttonSave);
			this.panel1.Controls.Add(this.buttonCancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 417);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(524, 45);
			this.panel1.TabIndex = 2;
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
			this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonSave.Location = new System.Drawing.Point(340, 10);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(83, 23);
			this.buttonSave.TabIndex = 1;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSaveClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
			this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonCancel.Location = new System.Drawing.Point(429, 10);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(83, 23);
			this.buttonCancel.TabIndex = 0;
			this.buttonCancel.Text = "Отменить";
			this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// tabControl1
			// 
			this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(524, 417);
			this.tabControl1.TabIndex = 3;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.button9);
			this.tabPage1.Controls.Add(this.button8);
			this.tabPage1.Controls.Add(this.unitsTextBox);
			this.tabPage1.Controls.Add(this.label8);
			this.tabPage1.Controls.Add(this.button7);
			this.tabPage1.Controls.Add(this.button6);
			this.tabPage1.Controls.Add(this.button5);
			this.tabPage1.Controls.Add(this.button4);
			this.tabPage1.Controls.Add(this.button3);
			this.tabPage1.Controls.Add(this.button2);
			this.tabPage1.Controls.Add(this.button1);
			this.tabPage1.Controls.Add(this.priceTextBox);
			this.tabPage1.Controls.Add(this.label7);
			this.tabPage1.Controls.Add(this.manufacturerTextBox);
			this.tabPage1.Controls.Add(this.label6);
			this.tabPage1.Controls.Add(this.articleTextBox);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.seriesTextBox);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.codeTextBox);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.nameTextBox);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(516, 388);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Основная информация";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// button9
			// 
			this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button9.Location = new System.Drawing.Point(486, 167);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(20, 20);
			this.button9.TabIndex = 22;
			this.button9.Text = "X";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.ButtonClearClick);
			// 
			// button8
			// 
			this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button8.Image = ((System.Drawing.Image)(resources.GetObject("button8.Image")));
			this.button8.Location = new System.Drawing.Point(454, 167);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(26, 20);
			this.button8.TabIndex = 21;
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.Button8Click);
			// 
			// unitsTextBox
			// 
			this.unitsTextBox.Location = new System.Drawing.Point(112, 167);
			this.unitsTextBox.Name = "unitsTextBox";
			this.unitsTextBox.Size = new System.Drawing.Size(342, 20);
			this.unitsTextBox.TabIndex = 20;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 170);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 23);
			this.label8.TabIndex = 19;
			this.label8.Text = "Ед. изм.:";
			// 
			// button7
			// 
			this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
			this.button7.Location = new System.Drawing.Point(454, 144);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(26, 20);
			this.button7.TabIndex = 18;
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.Button7Click);
			// 
			// button6
			// 
			this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button6.Location = new System.Drawing.Point(486, 144);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(20, 20);
			this.button6.TabIndex = 17;
			this.button6.Text = "X";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.ButtonClearClick);
			// 
			// button5
			// 
			this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button5.Location = new System.Drawing.Point(486, 103);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(20, 20);
			this.button5.TabIndex = 16;
			this.button5.Text = "X";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.ButtonClearClick);
			// 
			// button4
			// 
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button4.Location = new System.Drawing.Point(486, 80);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(20, 20);
			this.button4.TabIndex = 15;
			this.button4.Text = "X";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.ButtonClearClick);
			// 
			// button3
			// 
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button3.Location = new System.Drawing.Point(486, 57);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(20, 20);
			this.button3.TabIndex = 14;
			this.button3.Text = "X";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.ButtonClearClick);
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button2.Location = new System.Drawing.Point(486, 34);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(20, 20);
			this.button2.TabIndex = 13;
			this.button2.Text = "X";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.ButtonClearClick);
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Location = new System.Drawing.Point(486, 11);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(20, 20);
			this.button1.TabIndex = 12;
			this.button1.Text = "X";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.ButtonClearClick);
			// 
			// priceTextBox
			// 
			this.priceTextBox.Location = new System.Drawing.Point(112, 144);
			this.priceTextBox.Name = "priceTextBox";
			this.priceTextBox.Size = new System.Drawing.Size(342, 20);
			this.priceTextBox.TabIndex = 11;
			this.priceTextBox.Text = "0,00";
			this.priceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.priceTextBox.TextChanged += new System.EventHandler(this.PriceTextBoxTextChanged);
			this.priceTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PriceTextBoxKeyDown);
			this.priceTextBox.LostFocus += new System.EventHandler(this.PriceTextBoxTextLostFocus);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 147);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 10;
			this.label7.Text = "Цена:";
			// 
			// manufacturerTextBox
			// 
			this.manufacturerTextBox.Location = new System.Drawing.Point(112, 103);
			this.manufacturerTextBox.Name = "manufacturerTextBox";
			this.manufacturerTextBox.Size = new System.Drawing.Size(368, 20);
			this.manufacturerTextBox.TabIndex = 9;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 106);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 8;
			this.label6.Text = "Производитель:";
			// 
			// articleTextBox
			// 
			this.articleTextBox.Location = new System.Drawing.Point(112, 80);
			this.articleTextBox.Name = "articleTextBox";
			this.articleTextBox.Size = new System.Drawing.Size(368, 20);
			this.articleTextBox.TabIndex = 7;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 83);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 6;
			this.label5.Text = "Артикул:";
			// 
			// seriesTextBox
			// 
			this.seriesTextBox.Location = new System.Drawing.Point(112, 57);
			this.seriesTextBox.Name = "seriesTextBox";
			this.seriesTextBox.Size = new System.Drawing.Size(368, 20);
			this.seriesTextBox.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 60);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 4;
			this.label4.Text = "Серия:";
			// 
			// codeTextBox
			// 
			this.codeTextBox.Location = new System.Drawing.Point(112, 34);
			this.codeTextBox.Name = "codeTextBox";
			this.codeTextBox.Size = new System.Drawing.Size(368, 20);
			this.codeTextBox.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 37);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Код товара:";
			// 
			// nameTextBox
			// 
			this.nameTextBox.Location = new System.Drawing.Point(112, 11);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(368, 20);
			this.nameTextBox.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "Наименование:";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.button11);
			this.tabPage2.Controls.Add(this.foldersComboBox);
			this.tabPage2.Controls.Add(this.label1);
			this.tabPage2.Controls.Add(this.idTextBox);
			this.tabPage2.Controls.Add(this.label13);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(516, 388);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Разное";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// button11
			// 
			this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button11.Location = new System.Drawing.Point(483, 29);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(20, 20);
			this.button11.TabIndex = 12;
			this.button11.Text = "X";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.ButtonClearClick);
			// 
			// foldersComboBox
			// 
			this.foldersComboBox.FormattingEnabled = true;
			this.foldersComboBox.Location = new System.Drawing.Point(118, 29);
			this.foldersComboBox.Name = "foldersComboBox";
			this.foldersComboBox.Size = new System.Drawing.Size(359, 21);
			this.foldersComboBox.TabIndex = 7;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 6;
			this.label1.Text = "Папка:";
			// 
			// idTextBox
			// 
			this.idTextBox.Location = new System.Drawing.Point(118, 6);
			this.idTextBox.Name = "idTextBox";
			this.idTextBox.ReadOnly = true;
			this.idTextBox.Size = new System.Drawing.Size(100, 20);
			this.idTextBox.TabIndex = 5;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(4, 9);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(100, 23);
			this.label13.TabIndex = 4;
			this.label13.Text = "Код:";
			// 
			// FormNomenclatureFile
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(524, 462);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormNomenclatureFile";
			this.Text = "Номенклатура";
			this.Activated += new System.EventHandler(this.FormNomenclatureFileActivated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormNomenclatureFileFormClosed);
			this.Load += new System.EventHandler(this.FormNomenclatureFileLoad);
			this.panel1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
