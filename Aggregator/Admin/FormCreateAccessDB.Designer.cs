/*
 * Создано в SharpDevelop.
 * Пользователь: Cartish
 * Дата: 06.05.2017
 * Время: 12:06
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace Aggregator.Admin
{
	partial class FormCreateAccessDB
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox baseNameTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.TextBox pathTextBox;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreateAccessDB));
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.pathTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.baseNameTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.buttonSave);
			this.panel1.Controls.Add(this.buttonClose);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 111);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(402, 45);
			this.panel1.TabIndex = 2;
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
			this.panel2.Controls.Add(this.button1);
			this.panel2.Controls.Add(this.pathTextBox);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.baseNameTextBox);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(402, 111);
			this.panel2.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Location = new System.Drawing.Point(362, 76);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(28, 20);
			this.button1.TabIndex = 7;
			this.button1.Text = "...";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// pathTextBox
			// 
			this.pathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.pathTextBox.Location = new System.Drawing.Point(12, 76);
			this.pathTextBox.Name = "pathTextBox";
			this.pathTextBox.ReadOnly = true;
			this.pathTextBox.Size = new System.Drawing.Size(348, 20);
			this.pathTextBox.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(287, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Путь по которому будет создан файл базы данных:";
			// 
			// baseNameTextBox
			// 
			this.baseNameTextBox.Location = new System.Drawing.Point(12, 26);
			this.baseNameTextBox.Name = "baseNameTextBox";
			this.baseNameTextBox.Size = new System.Drawing.Size(378, 20);
			this.baseNameTextBox.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(109, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Имя базы данных:";
			// 
			// FormCreateAccessDB
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(402, 156);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormCreateAccessDB";
			this.Text = "Создать базу данных Microsoft Access";
			this.Activated += new System.EventHandler(this.FormCreateAccessDBActivated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCreateAccessDBFormClosed);
			this.Load += new System.EventHandler(this.FormCreateAccessDBLoad);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
