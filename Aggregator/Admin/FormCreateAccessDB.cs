/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 06.05.2017
 * Время: 12:06
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
	/// Description of FormCreateAccessDB.
	/// </summary>
	public partial class FormCreateAccessDB : Form
	{
		public FormCreateAccessDB()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void FormCreateAccessDBLoad(object sender, EventArgs e)
		{
			Utilits.Console.Log(this.Text + ": открыт.");
		}
		void FormCreateAccessDBFormClosed(object sender, FormClosedEventArgs e)
		{
			DataForms.FClient.messageInStatus("...");
			Utilits.Console.Log(this.Text + ": закрыт.");
			Dispose();
		}
		void FormCreateAccessDBActivated(object sender, EventArgs e)
		{
			DataForms.FClient.messageInStatus(this.Text);
		}
		void ButtonCloseClick(object sender, EventArgs e)
		{
			Close();
		}
		void Button1Click(object sender, EventArgs e)
		{
			if(folderBrowserDialog1.ShowDialog() == DialogResult.OK){
				pathTextBox.Text = folderBrowserDialog1.SelectedPath;
			}
		}
		void ButtonSaveClick(object sender, EventArgs e)
		{
			if(baseNameTextBox.Text == ""){
				MessageBox.Show("Вы не ввели имя базы данных!", "Предупреждение");
				return;
			}
			if(pathTextBox.Text == ""){
				MessageBox.Show("Вы не выбрали путь куда необходимо сохранить файл!", "Предупреждение");
				return;
			}
			
			CreateDatabaseMSAccess createDatabaseMSAccess = new CreateDatabaseMSAccess(pathTextBox.Text + "\\" + baseNameTextBox.Text + ".mdb");
			createDatabaseMSAccess.CreateDB();
		}
	}
}
