/*
 * Created by SharpDevelop.
 * User: Cartish
 * Date: 02.03.2017
 * Time: 7:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Aggregator.User
{
	partial class FormUsersEdit
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox permissionsComboBox;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox passTextBox2;
		private System.Windows.Forms.TextBox passTextBox1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox infoTextBox;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox checkBox5;
		private System.Windows.Forms.CheckBox checkBox4;
		private System.Windows.Forms.CheckBox checkBox6;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUsersEdit));
			this.label1 = new System.Windows.Forms.Label();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.permissionsComboBox = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.passTextBox2 = new System.Windows.Forms.TextBox();
			this.passTextBox1 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.infoTextBox = new System.Windows.Forms.TextBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.checkBox6 = new System.Windows.Forms.CheckBox();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Логин:";
			// 
			// nameTextBox
			// 
			this.nameTextBox.Location = new System.Drawing.Point(45, 6);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(330, 20);
			this.nameTextBox.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Location = new System.Drawing.Point(381, 6);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(20, 20);
			this.button1.TabIndex = 2;
			this.button1.Text = "X";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(11, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Права:";
			// 
			// permissionsComboBox
			// 
			this.permissionsComboBox.FormattingEnabled = true;
			this.permissionsComboBox.Items.AddRange(new object[] {
			"администратор",
			"оператор",
			"пользователь",
			"гость"});
			this.permissionsComboBox.Location = new System.Drawing.Point(53, 19);
			this.permissionsComboBox.Name = "permissionsComboBox";
			this.permissionsComboBox.Size = new System.Drawing.Size(330, 21);
			this.permissionsComboBox.TabIndex = 4;
			this.permissionsComboBox.SelectedIndexChanged += new System.EventHandler(this.PermissionsComboBoxSelectedIndexChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button3);
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.passTextBox2);
			this.groupBox1.Controls.Add(this.passTextBox1);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Location = new System.Drawing.Point(3, 172);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(409, 66);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Безопасность:";
			// 
			// button3
			// 
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button3.Location = new System.Drawing.Point(378, 36);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(20, 20);
			this.button3.TabIndex = 7;
			this.button3.Text = "X";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// button2
			// 
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button2.Location = new System.Drawing.Point(378, 13);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(20, 20);
			this.button2.TabIndex = 6;
			this.button2.Text = "X";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// passTextBox2
			// 
			this.passTextBox2.Location = new System.Drawing.Point(112, 36);
			this.passTextBox2.Name = "passTextBox2";
			this.passTextBox2.PasswordChar = '*';
			this.passTextBox2.Size = new System.Drawing.Size(260, 20);
			this.passTextBox2.TabIndex = 5;
			// 
			// passTextBox1
			// 
			this.passTextBox1.Location = new System.Drawing.Point(112, 13);
			this.passTextBox1.Name = "passTextBox1";
			this.passTextBox1.PasswordChar = '*';
			this.passTextBox1.Size = new System.Drawing.Size(260, 20);
			this.passTextBox1.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 39);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(114, 23);
			this.label4.TabIndex = 3;
			this.label4.Text = "Повторить пароль:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(62, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 2;
			this.label5.Text = "Пароль:";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button5);
			this.panel1.Controls.Add(this.button4);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 393);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(416, 45);
			this.panel1.TabIndex = 7;
			// 
			// button5
			// 
			this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
			this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button5.Location = new System.Drawing.Point(321, 10);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(83, 23);
			this.button5.TabIndex = 1;
			this.button5.Text = "Отменить";
			this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.Button5Click);
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
			this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button4.Location = new System.Drawing.Point(232, 10);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(83, 23);
			this.button4.TabIndex = 0;
			this.button4.Text = "Сохранить";
			this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.infoTextBox);
			this.groupBox2.Location = new System.Drawing.Point(3, 244);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(409, 137);
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Дополнительно:";
			// 
			// infoTextBox
			// 
			this.infoTextBox.Location = new System.Drawing.Point(6, 19);
			this.infoTextBox.Multiline = true;
			this.infoTextBox.Name = "infoTextBox";
			this.infoTextBox.Size = new System.Drawing.Size(397, 112);
			this.infoTextBox.TabIndex = 0;
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(182, 46);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(135, 24);
			this.checkBox1.TabIndex = 9;
			this.checkBox1.Text = "Aдминистрирование";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(53, 46);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(104, 24);
			this.checkBox2.TabIndex = 10;
			this.checkBox2.Text = "Создание";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox3
			// 
			this.checkBox3.Location = new System.Drawing.Point(53, 65);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(104, 24);
			this.checkBox3.TabIndex = 11;
			this.checkBox3.Text = "Чтение";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.checkBox6);
			this.groupBox3.Controls.Add(this.checkBox5);
			this.groupBox3.Controls.Add(this.checkBox1);
			this.groupBox3.Controls.Add(this.checkBox4);
			this.groupBox3.Controls.Add(this.permissionsComboBox);
			this.groupBox3.Controls.Add(this.checkBox3);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.checkBox2);
			this.groupBox3.Location = new System.Drawing.Point(3, 30);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(409, 136);
			this.groupBox3.TabIndex = 12;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Права доступа:";
			// 
			// checkBox6
			// 
			this.checkBox6.Location = new System.Drawing.Point(182, 65);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new System.Drawing.Size(104, 24);
			this.checkBox6.TabIndex = 14;
			this.checkBox6.Text = "Настройки";
			this.checkBox6.UseVisualStyleBackColor = true;
			// 
			// checkBox5
			// 
			this.checkBox5.Location = new System.Drawing.Point(53, 106);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(104, 24);
			this.checkBox5.TabIndex = 13;
			this.checkBox5.Text = "Удаление";
			this.checkBox5.UseVisualStyleBackColor = true;
			// 
			// checkBox4
			// 
			this.checkBox4.Location = new System.Drawing.Point(53, 85);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(117, 24);
			this.checkBox4.TabIndex = 12;
			this.checkBox4.Text = "Редактирвоание";
			this.checkBox4.UseVisualStyleBackColor = true;
			// 
			// FormUsersEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(416, 438);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.nameTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox2);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormUsersEdit";
			this.Text = "Пользователь";
			this.Activated += new System.EventHandler(this.FormUsersEditActivated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormUsersEditFormClosed);
			this.Load += new System.EventHandler(this.FormUsersEditLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
