/*
 * Created by SharpDevelop.
 * User: Cartish
 * Date: 01.03.2017
 * Time: 10:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Aggregator.Client.Settings
{
	partial class FormSettings
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.CheckBox autoUpdateCheckBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox periodComboBox;
		private System.Windows.Forms.CheckBox showConsoleCheckBox;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
			this.panel2 = new System.Windows.Forms.Panel();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.showConsoleCheckBox = new System.Windows.Forms.CheckBox();
			this.periodComboBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.autoUpdateCheckBox = new System.Windows.Forms.CheckBox();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.buttonSave);
			this.panel2.Controls.Add(this.buttonCancel);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 170);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(426, 51);
			this.panel2.TabIndex = 2;
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
			this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonSave.Location = new System.Drawing.Point(238, 16);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(85, 23);
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
			this.buttonCancel.Location = new System.Drawing.Point(329, 16);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(85, 23);
			this.buttonCancel.TabIndex = 0;
			this.buttonCancel.Text = "Отменить";
			this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.showConsoleCheckBox);
			this.panel1.Controls.Add(this.periodComboBox);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.autoUpdateCheckBox);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(426, 170);
			this.panel1.TabIndex = 3;
			// 
			// showConsoleCheckBox
			// 
			this.showConsoleCheckBox.Location = new System.Drawing.Point(12, 42);
			this.showConsoleCheckBox.Name = "showConsoleCheckBox";
			this.showConsoleCheckBox.Size = new System.Drawing.Size(402, 24);
			this.showConsoleCheckBox.TabIndex = 3;
			this.showConsoleCheckBox.Text = "Автоматически открывать консоль при ошибках.";
			this.showConsoleCheckBox.UseVisualStyleBackColor = true;
			// 
			// periodComboBox
			// 
			this.periodComboBox.FormattingEnabled = true;
			this.periodComboBox.Items.AddRange(new object[] {
			"Сегодня",
			"Вчера",
			"Неделя",
			"Месяц",
			"Год"});
			this.periodComboBox.Location = new System.Drawing.Point(258, 72);
			this.periodComboBox.Name = "periodComboBox";
			this.periodComboBox.Size = new System.Drawing.Size(156, 21);
			this.periodComboBox.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 75);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(257, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Период по умолчанию для открытых журналов:";
			// 
			// autoUpdateCheckBox
			// 
			this.autoUpdateCheckBox.Location = new System.Drawing.Point(12, 12);
			this.autoUpdateCheckBox.Name = "autoUpdateCheckBox";
			this.autoUpdateCheckBox.Size = new System.Drawing.Size(402, 24);
			this.autoUpdateCheckBox.TabIndex = 0;
			this.autoUpdateCheckBox.Text = "Автоматическое обновление данных в открытых журналах.";
			this.autoUpdateCheckBox.UseVisualStyleBackColor = true;
			// 
			// FormSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(426, 221);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormSettings";
			this.Text = "Настройки";
			this.Activated += new System.EventHandler(this.FormSettingsActivated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSettingsFormClosed);
			this.Load += new System.EventHandler(this.FormSettingsLoad);
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
