/*
 * Created by SharpDevelop.
 * User: Cartish
 * Date: 26.02.2017
 * Time: 16:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Aggregator.User
{
	partial class FormUsers
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton toolStripButton4;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem добавитьПользователяToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem изменитьПользователяToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem удалитьПользователяToolStripMenuItem;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUsers));
			this.panel1 = new System.Windows.Forms.Panel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.panel2 = new System.Windows.Forms.Panel();
			this.buttonClose = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.добавитьПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.изменитьПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.удалитьПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.toolStrip1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(620, 25);
			this.panel1.TabIndex = 0;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripButton1,
			this.toolStripButton2,
			this.toolStripButton3,
			this.toolStripSeparator1,
			this.toolStripButton4});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(620, 25);
			this.toolStrip1.TabIndex = 5;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(79, 22);
			this.toolStripButton1.Text = "Добавить";
			this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1Click);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(107, 22);
			this.toolStripButton2.Text = "Редактировать";
			this.toolStripButton2.Click += new System.EventHandler(this.ToolStripButton2Click);
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(71, 22);
			this.toolStripButton3.Text = "Удалить";
			this.toolStripButton3.Click += new System.EventHandler(this.ToolStripButton3Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton4
			// 
			this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
			this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton4.Name = "toolStripButton4";
			this.toolStripButton4.Size = new System.Drawing.Size(81, 22);
			this.toolStripButton4.Text = "Обновить";
			this.toolStripButton4.Click += new System.EventHandler(this.ToolStripButton4Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "drive_user.png");
			this.imageList1.Images.SetKeyName(1, "report_user.png");
			this.imageList1.Images.SetKeyName(2, "folder_user.png");
			this.imageList1.Images.SetKeyName(3, "group.png");
			this.imageList1.Images.SetKeyName(4, "group_add.png");
			this.imageList1.Images.SetKeyName(5, "group_delete.png");
			this.imageList1.Images.SetKeyName(6, "group_edit.png");
			this.imageList1.Images.SetKeyName(7, "group_error.png");
			this.imageList1.Images.SetKeyName(8, "group_gear.png");
			this.imageList1.Images.SetKeyName(9, "group_go.png");
			this.imageList1.Images.SetKeyName(10, "arrow_refresh_small.png");
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.buttonClose);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 299);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(620, 45);
			this.panel2.TabIndex = 1;
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.Location = new System.Drawing.Point(533, 10);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 0;
			this.buttonClose.Text = "Закрыть";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.listView1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 25);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(620, 274);
			this.panel3.TabIndex = 2;
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
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.LargeImageList = this.imageList1;
			this.listView1.Location = new System.Drawing.Point(0, 0);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(620, 274);
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.StateImageList = this.imageList1;
			this.listView1.TabIndex = 0;
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
			this.columnHeader2.Text = "Имя";
			this.columnHeader2.Width = 350;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Права";
			this.columnHeader3.Width = 150;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "№";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.добавитьПользователяToolStripMenuItem,
			this.изменитьПользователяToolStripMenuItem,
			this.удалитьПользователяToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(233, 92);
			// 
			// добавитьПользователяToolStripMenuItem
			// 
			this.добавитьПользователяToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("добавитьПользователяToolStripMenuItem.Image")));
			this.добавитьПользователяToolStripMenuItem.Name = "добавитьПользователяToolStripMenuItem";
			this.добавитьПользователяToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
			this.добавитьПользователяToolStripMenuItem.Text = "Добавить пользователя";
			this.добавитьПользователяToolStripMenuItem.Click += new System.EventHandler(this.ДобавитьПользователяToolStripMenuItemClick);
			// 
			// изменитьПользователяToolStripMenuItem
			// 
			this.изменитьПользователяToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("изменитьПользователяToolStripMenuItem.Image")));
			this.изменитьПользователяToolStripMenuItem.Name = "изменитьПользователяToolStripMenuItem";
			this.изменитьПользователяToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
			this.изменитьПользователяToolStripMenuItem.Text = "Редактировать пользователя";
			this.изменитьПользователяToolStripMenuItem.Click += new System.EventHandler(this.ИзменитьПользователяToolStripMenuItemClick);
			// 
			// удалитьПользователяToolStripMenuItem
			// 
			this.удалитьПользователяToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("удалитьПользователяToolStripMenuItem.Image")));
			this.удалитьПользователяToolStripMenuItem.Name = "удалитьПользователяToolStripMenuItem";
			this.удалитьПользователяToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
			this.удалитьПользователяToolStripMenuItem.Text = "Удалить пользователя";
			this.удалитьПользователяToolStripMenuItem.Click += new System.EventHandler(this.УдалитьПользователяToolStripMenuItemClick);
			// 
			// FormUsers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(620, 344);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormUsers";
			this.Text = "Пользователи";
			this.Activated += new System.EventHandler(this.FormUsersActivated);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormUsersFormClosed);
			this.Load += new System.EventHandler(this.FormUsersLoad);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
