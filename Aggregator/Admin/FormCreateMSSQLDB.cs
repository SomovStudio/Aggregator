/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 06.05.2017
 * Время: 12:07
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Aggregator.Data;
using Aggregator.Database;

namespace Aggregator.Admin
{
	/// <summary>
	/// Description of FormCreateMSSQLDB.
	/// </summary>
	public partial class FormCreateMSSQLDB : Form
	{
		public FormCreateMSSQLDB()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void FormCreateMSSQLDBLoad(object sender, EventArgs e)
		{
			Utilits.Console.Log(this.Text + ": открыт.");
		}
		void FormCreateMSSQLDBFormClosed(object sender, FormClosedEventArgs e)
		{
			DataForms.FClient.messageInStatus("...");
			Utilits.Console.Log(this.Text + ": закрыт.");
			Dispose();
		}
		void FormCreateMSSQLDBActivated(object sender, EventArgs e)
		{
			DataForms.FClient.messageInStatus(this.Text);
		}
		void ButtonCloseClick(object sender, EventArgs e)
		{
			Close();
		}
		void ButtonSaveClick(object sender, EventArgs e)
		{
			if(newDatabaseTextBox.Text == ""){
				MessageBox.Show("Вы не ввели имя базы данных!", "Предупреждение");
				return;
			}
						
			CreateDatabaseMSSQL createDatabaseMSSQL = new CreateDatabaseMSSQL(newDatabaseTextBox.Text,
			                                                                  serverTextBox.Text,
			                                                                  databaseTextBox.Text, 
			                                                                  userTextBox.Text, passTextBox.Text);
			createDatabaseMSSQL.CreateDB();
		}
	}
}
