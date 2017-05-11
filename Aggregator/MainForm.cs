/*
 * Created by SharpDevelop.
 * User: Somov Studio
 * Date: 21.02.2017
 * Time: 14:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Aggregator.Data;
using Aggregator.Database;
using Aggregator.Trial;
using Aggregator.User;
using Aggregator.Database.Config;

namespace Aggregator
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			CheckTrial checkTrial = new CheckTrial();
			if(checkTrial.Check()) timer1.Start();
			else Application.Exit();
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			timer1.Stop();
			
			try {
				initLocalPath();
				initResource();
				initLocalBase();
			}catch(Exception ex){
				MessageBox.Show(ex.Message + Environment.NewLine + Environment.NewLine + "Запустите программу от имени администратора.", "Сообщение");
				DataConfig.programClose = true;
				Application.Exit();
			}
		}
		
		void initLocalPath()
		{
			//определяем расположение программы (путь)
			DataConfig.programPath = Environment.CurrentDirectory + "\\";
			//расположение папки ресурсов
			DataConfig.resource = DataConfig.programPath + "resource";
		}
		
		void initResource()
		{
			//Проверка существования папки
			if(!Directory.Exists(DataConfig.resource)){
				//папки нет, она будет создана заново
				Directory.CreateDirectory(DataConfig.resource);
			}
		}
		
		void initLocalBase()
		{
			// Поиск локальной базы данный Config
			DataConfig.configFile = DataConfig.resource + "\\config.mdb";
			if(!File.Exists(DataConfig.configFile)){ 
				CreateConfig.Create(); //файл не найден, он будет создан
				ReadingConfig.ReadDatabaseSettings();
				ReadingConfig.ReadSettings();
			}else{
				ReadingConfig.ReadDatabaseSettings();
				ReadingConfig.ReadSettings();
			}
			
			// Поиск локальной базы данный Database
			if(!File.Exists(DataConfig.localDatabase) && DataConfig.typeConnection == DataConstants.CONNETION_LOCAL){
				// файл не найден, он будет создан
				DataConfig.oledbConnectLineBegin = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
				DataConfig.oledbConnectLineEnd = "";
				DataConfig.oledbConnectPass = "";
				CreateDatabaseMSAccess createDatabaseMSAccess = new CreateDatabaseMSAccess(DataConfig.localDatabase);
				createDatabaseMSAccess.CreateDB();
			}
			
			createFormSelectUser();
		}
		
		void createFormSelectUser()
		{
			// Открываем окно выбора пользователя
			DataForms.FCheckUser = new FormCheckUser();
			DataForms.FCheckUser.Show();
			DataForms.FMain = this;
		}
		void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
			Dispose();
		}
	}
}
