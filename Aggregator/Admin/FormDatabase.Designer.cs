/*
 * Создано в SharpDevelop.
 * Пользователь: Cartish
 * Дата: 06.05.2017
 * Время: 10:19
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace Aggregator.Admin
{
	partial class FormDatabase
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.RadioButton localRadioButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox localDatabaseTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.RadioButton serverRadioButton;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button testConnectButton;
		private System.Windows.Forms.TextBox serverTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDatabase));
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button5 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.testConnectButton = new System.Windows.Forms.Button();
			this.serverTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.serverRadioButton = new System.Windows.Forms.RadioButton();
			this.localRadioButton = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button4 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.localDatabaseTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.buttonSave);
			this.panel1.Controls.Add(this.buttonClose);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 308);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(456, 45);
			this.panel1.TabIndex = 1;
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
			this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonSave.Location = new System.Drawing.Point(268, 10);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(85, 23);
			this.buttonSave.TabIndex = 1;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSaveClick);
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.Image = ((System.Drawing.Image)(resources.GetObject("buttonClose.Image")));
			this.buttonClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonClose.Location = new System.Drawing.Point(359, 10);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(85, 23);
			this.buttonClose.TabIndex = 0;
			this.buttonClose.Text = "Отменить";
			this.buttonClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.groupBox2);
			this.panel2.Controls.Add(this.serverRadioButton);
			this.panel2.Controls.Add(this.localRadioButton);
			this.panel2.Controls.Add(this.groupBox1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(456, 308);
			this.panel2.TabIndex = 2;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.button5);
			this.groupBox2.Controls.Add(this.button3);
			this.groupBox2.Controls.Add(this.testConnectButton);
			this.groupBox2.Controls.Add(this.serverTextBox);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Location = new System.Drawing.Point(12, 165);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(432, 121);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(80, 59);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(341, 23);
			this.button5.TabIndex = 8;
			this.button5.Text = "Создать таблицы в пустой базе данных";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.Button5Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(80, 88);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(170, 23);
			this.button3.TabIndex = 7;
			this.button3.Text = "Создать новую базу данных";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// testConnectButton
			// 
			this.testConnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.testConnectButton.Location = new System.Drawing.Point(256, 88);
			this.testConnectButton.Name = "testConnectButton";
			this.testConnectButton.Size = new System.Drawing.Size(165, 23);
			this.testConnectButton.TabIndex = 5;
			this.testConnectButton.Text = "Проверить соединение";
			this.testConnectButton.UseVisualStyleBackColor = true;
			this.testConnectButton.Click += new System.EventHandler(this.TestConnectButtonClick);
			// 
			// serverTextBox
			// 
			this.serverTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.serverTextBox.Location = new System.Drawing.Point(8, 33);
			this.serverTextBox.Name = "serverTextBox";
			this.serverTextBox.Size = new System.Drawing.Size(418, 20);
			this.serverTextBox.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(8, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(242, 23);
			this.label3.TabIndex = 3;
			this.label3.Text = "Строка подключения к базе данных:";
			// 
			// serverRadioButton
			// 
			this.serverRadioButton.Location = new System.Drawing.Point(12, 144);
			this.serverRadioButton.Name = "serverRadioButton";
			this.serverRadioButton.Size = new System.Drawing.Size(426, 24);
			this.serverRadioButton.TabIndex = 2;
			this.serverRadioButton.TabStop = true;
			this.serverRadioButton.Text = "Microsoft SQL Server";
			this.serverRadioButton.UseVisualStyleBackColor = true;
			this.serverRadioButton.CheckedChanged += new System.EventHandler(this.RadioButtonsCheckedChanged);
			// 
			// localRadioButton
			// 
			this.localRadioButton.Location = new System.Drawing.Point(12, 12);
			this.localRadioButton.Name = "localRadioButton";
			this.localRadioButton.Size = new System.Drawing.Size(426, 24);
			this.localRadioButton.TabIndex = 1;
			this.localRadioButton.TabStop = true;
			this.localRadioButton.Text = "Microsoft Access";
			this.localRadioButton.UseVisualStyleBackColor = true;
			this.localRadioButton.CheckedChanged += new System.EventHandler(this.RadioButtonsCheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button4);
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.localDatabaseTextBox);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 37);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(432, 92);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// button4
			// 
			this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button4.Location = new System.Drawing.Point(261, 58);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(165, 23);
			this.button4.TabIndex = 7;
			this.button4.Text = "Проверить соединение";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(80, 58);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(170, 23);
			this.button2.TabIndex = 6;
			this.button2.Text = "Создать новую базу данных";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Location = new System.Drawing.Point(398, 32);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(28, 20);
			this.button1.TabIndex = 5;
			this.button1.Text = "...";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// localDatabaseTextBox
			// 
			this.localDatabaseTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.localDatabaseTextBox.Location = new System.Drawing.Point(8, 32);
			this.localDatabaseTextBox.Name = "localDatabaseTextBox";
			this.localDatabaseTextBox.ReadOnly = true;
			this.localDatabaseTextBox.Size = new System.Drawing.Size(388, 20);
			this.localDatabaseTextBox.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(207, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Путь к базе данных:";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "database.mdb";
			this.openFileDialog1.Filter = "Файл базы данных *.mdb|*.mdb";
			// 
			// FormDatabase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(456, 353);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormDatabase";
			this.Text = "Настройка базы данных";
			this.Activated += new System.EventHandler(this.FormDatabaseActivated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDatabaseFormClosed);
			this.Load += new System.EventHandler(this.FormDatabaseLoad);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
