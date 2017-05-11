/*
 * Created by SharpDevelop.
 * User: Somov Studio
 * Date: 21.02.2017
 * Time: 15:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Aggregator.Data;
using Aggregator.Database.Local;
using Aggregator.Client;
using Aggregator.Database.Server;
using Aggregator.Utilits;

namespace Aggregator.User
{
	/// <summary>
	/// Description of FormSelectUser.
	/// </summary>
	public partial class FormCheckUser : Form
	{
		public FormCheckUser()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		//Boolean programClose;	//флаг закрытия приложения
		OleDb oleDb;			// OleDb
		SqlServer sqlServer;	// MSSQL
		
		void loadData()
		{
			//Подключение базы данных
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL && DataConfig.typeDatabase == DataConstants.TYPE_OLEDB) {
				// OLEDB
				try{
					oleDb = new OleDb(DataConfig.localDatabase);
					oleDb.oleDbCommandSelect.CommandText = "SELECT * FROM Users";
					oleDb.ExecuteFill("Users");
				}catch(Exception ex){
					oleDb.Error();
					MessageBox.Show(ex.ToString());
					Application.Exit();
				}
			} else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER && DataConfig.typeDatabase == DataConstants.TYPE_MSSQL){
				// MSSQL SERVER
				try{
					sqlServer = new SqlServer();
					sqlServer.sqlCommandSelect.CommandText = "SELECT * FROM Users";
					sqlServer.ExecuteFill("Users");
				}catch(Exception ex){
					sqlServer.Error();
					MessageBox.Show(ex.ToString());
					Application.Exit();
				}
			}
			readData();
		}
		
		void readData()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL && DataConfig.typeDatabase == DataConstants.TYPE_OLEDB) {
				foreach(DataRow row in oleDb.dataSet.Tables["Users"].Rows)
				{
					comboBox1.Items.Add(row[1].ToString());
				}
			} else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER && DataConfig.typeDatabase == DataConstants.TYPE_MSSQL){
				foreach(DataRow row in sqlServer.dataSet.Tables["Users"].Rows)
				{
					comboBox1.Items.Add(row[1].ToString());
				}
			}
		}
		
		void checkUser()
		{
			//Проверка логина и пароля
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL && DataConfig.typeDatabase == DataConstants.TYPE_OLEDB) {
				try{
					if(comboBox1.Text == ""){
						MessageBox.Show("Вы не выбрали пользователя!","Сообщение:");
					}else{
						String pass = oleDb.dataSet.Tables["Users"].Rows[comboBox1.SelectedIndex]["pass"].ToString();
						if(textBox1.Text == pass){
							Visible = false;
							DataConfig.userName = oleDb.dataSet.Tables["Users"].Rows[comboBox1.SelectedIndex]["name"].ToString();
							DataConfig.userPass = oleDb.dataSet.Tables["Users"].Rows[comboBox1.SelectedIndex]["pass"].ToString();
							DataConfig.userPermissions = oleDb.dataSet.Tables["Users"].Rows[comboBox1.SelectedIndex]["permissions"].ToString(); 
							DataForms.FMain.Visible = false;
							DataConfig.programClose = false;
							DataForms.FClient = new FormClient();
							DataForms.FClient.Show();
							Utilits.Console.Log("Пользователь успешно авторизовался!");
							Close();
						}else{
							MessageBox.Show("Вы ввели не верный пароль.","Сообщение:");
						}
					}
				}catch{
					MessageBox.Show("Призошла ошибка при загрузке клиента.","Сообщение:");
				}
			}else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER && DataConfig.typeDatabase == DataConstants.TYPE_MSSQL){
				try{
					if(comboBox1.Text == ""){
						MessageBox.Show("Вы не выбрали пользователя!","Сообщение:");
					}else{
						String pass = sqlServer.dataSet.Tables["Users"].Rows[comboBox1.SelectedIndex]["pass"].ToString();
						if(textBox1.Text == pass){
							Visible = false;
							DataConfig.userName = sqlServer.dataSet.Tables["Users"].Rows[comboBox1.SelectedIndex]["name"].ToString();
							DataConfig.userPass = sqlServer.dataSet.Tables["Users"].Rows[comboBox1.SelectedIndex]["pass"].ToString();
							DataConfig.userPermissions = sqlServer.dataSet.Tables["Users"].Rows[comboBox1.SelectedIndex]["permissions"].ToString(); 
							DataForms.FMain.Visible = false;
							DataConfig.programClose = false;
							DataForms.FClient = new FormClient();
							DataForms.FClient.Show();
							Utilits.Console.Log("Пользователь успешно авторизовался!");
							Close();
						}else{
							MessageBox.Show("Вы ввели не верный пароль.","Сообщение:");
						}
					}
				}catch{
					MessageBox.Show("Призошла ошибка при загрузке клиента.","Сообщение:");
				}
			}
		}
		
		/* =================================================================================================
		 * РАЗДЕЛ: СОБЫТИЙ
		 * =================================================================================================
		 */
		void FormSelectUserFormClosed(object sender, FormClosedEventArgs e)
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL && oleDb != null) oleDb.Dispose();
			if(DataConfig.typeConnection == DataConstants.CONNETION_SERVER && sqlServer != null) sqlServer.Dispose();
			if(DataConfig.programClose) Application.Exit();
		}
		void Button2Click(object sender, EventArgs e)
		{
			Close();
		}
		void FormSelectUserLoad(object sender, EventArgs e)
		{
			DataConfig.programClose = true;
			loadData();
		}
		void Button1Click(object sender, EventArgs e)
		{
			checkUser();
		}
		
	}
}
