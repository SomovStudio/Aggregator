/*
 * Создано в SharpDevelop.
 * Пользователь: Cartish
 * Дата: 06.05.2017
 * Время: 12:07
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace Aggregator.Admin
{
	partial class FormCreateMSSQLDB
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox newDatabaseTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox passTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox userTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox databaseTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox serverTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreateMSSQLDB));
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.userTextBox = new System.Windows.Forms.TextBox();
			this.databaseTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.passTextBox = new System.Windows.Forms.TextBox();
			this.serverTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.newDatabaseTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.buttonSave);
			this.panel1.Controls.Add(this.buttonClose);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 196);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(402, 45);
			this.panel1.TabIndex = 3;
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
			this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonSave.Location = new System.Drawing.Point(232, 10);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(76, 23);
			this.buttonSave.TabIndex = 1;
			this.buttonSave.Text = "Создать";
			this.buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.ButtonSaveClick);
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.Image = ((System.Drawing.Image)(resources.GetObject("buttonClose.Image")));
			this.buttonClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonClose.Location = new System.Drawing.Point(314, 10);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(76, 23);
			this.buttonClose.TabIndex = 0;
			this.buttonClose.Text = "Закрыть";
			this.buttonClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.groupBox1);
			this.panel2.Controls.Add(this.newDatabaseTextBox);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(402, 196);
			this.panel2.TabIndex = 4;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.userTextBox);
			this.groupBox1.Controls.Add(this.databaseTextBox);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.passTextBox);
			this.groupBox1.Controls.Add(this.serverTextBox);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Location = new System.Drawing.Point(12, 52);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(378, 127);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Подключение к серверу баз данных:";
			// 
			// userTextBox
			// 
			this.userTextBox.Location = new System.Drawing.Point(143, 70);
			this.userTextBox.Name = "userTextBox";
			this.userTextBox.Size = new System.Drawing.Size(229, 20);
			this.userTextBox.TabIndex = 14;
			this.userTextBox.Text = "sa";
			// 
			// databaseTextBox
			// 
			this.databaseTextBox.Location = new System.Drawing.Point(143, 47);
			this.databaseTextBox.Name = "databaseTextBox";
			this.databaseTextBox.Size = new System.Drawing.Size(229, 20);
			this.databaseTextBox.TabIndex = 12;
			this.databaseTextBox.Text = "master";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 27);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 9;
			this.label2.Text = "Сервер (Server):";
			// 
			// passTextBox
			// 
			this.passTextBox.Location = new System.Drawing.Point(143, 93);
			this.passTextBox.Name = "passTextBox";
			this.passTextBox.PasswordChar = '*';
			this.passTextBox.Size = new System.Drawing.Size(229, 20);
			this.passTextBox.TabIndex = 16;
			// 
			// serverTextBox
			// 
			this.serverTextBox.Location = new System.Drawing.Point(143, 24);
			this.serverTextBox.Name = "serverTextBox";
			this.serverTextBox.Size = new System.Drawing.Size(229, 20);
			this.serverTextBox.TabIndex = 10;
			this.serverTextBox.Text = "***\\SQLEXPRESS";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(6, 96);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(127, 23);
			this.label6.TabIndex = 15;
			this.label6.Tag = "";
			this.label6.Text = "Пароль (Password):";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 50);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(136, 23);
			this.label4.TabIndex = 11;
			this.label4.Text = "База данных (Database):";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 73);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(147, 23);
			this.label5.TabIndex = 13;
			this.label5.Text = "Пользователь (User Id):";
			// 
			// newDatabaseTextBox
			// 
			this.newDatabaseTextBox.Location = new System.Drawing.Point(12, 26);
			this.newDatabaseTextBox.Name = "newDatabaseTextBox";
			this.newDatabaseTextBox.Size = new System.Drawing.Size(378, 20);
			this.newDatabaseTextBox.TabIndex = 8;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(153, 23);
			this.label1.TabIndex = 7;
			this.label1.Text = "Имя новой базы данных:";
			// 
			// FormCreateMSSQLDB
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(402, 241);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormCreateMSSQLDB";
			this.Text = "Создать базу данных Microsoft SQL Server";
			this.Activated += new System.EventHandler(this.FormCreateMSSQLDBActivated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCreateMSSQLDBFormClosed);
			this.Load += new System.EventHandler(this.FormCreateMSSQLDBLoad);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
