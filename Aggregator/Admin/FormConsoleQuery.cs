/*
 * Created by SharpDevelop.
 * User: Somov Studio
 * Date: 26.02.2017
 * Time: 10:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Aggregator.Data;
using Aggregator.Database.Local;

namespace Aggregator.Admin
{
	/// <summary>
	/// Description of FormConsoleQuery.
	/// </summary>
	public partial class FormConsoleQuery : Form
	{
		public FormConsoleQuery()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		OleDb oleDb;
		QueryOleDb query;
		
		void FormConsoleQueryLoad(object sender, EventArgs e)
		{
			comboBox1.Items.Add(DataConfig.configFile);
			comboBox1.Items.Add(DataConfig.localDatabase);
			Utilits.Console.Log("Консоль запросов: открыт.");
		}
		void FormConsoleQueryFormClosed(object sender, FormClosedEventArgs e)
		{
			Dispose();
			DataForms.FClient.messageInStatus("...");
			Utilits.Console.Log("Консоль запросов: закрыт.");
			DataForms.FConsoleQuery = null;
		}
		void Button1Click(object sender, EventArgs e)
		{
			if(comboBox1.Text != "" && comboBox2.Text != ""){
				oleDb.dataSet.Clear();
				dataGrid1.DataSource = oleDb.dataSet;
				oleDb.oleDbCommandSelect.CommandText = textBox1.Text;
				oleDb.ExecuteFill(comboBox2.Text);
			}else{
				MessageBox.Show("Вы не выбрали файл базы данных или не указали имя таблицы!");
			}
		}
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			oleDb = new OleDb(comboBox1.Text);
			query = new QueryOleDb(comboBox1.Text);
		}
		void Button2Click(object sender, EventArgs e)
		{
			if(textBox1.Text == ""){
				MessageBox.Show("Необходимо ввести запрос Select");
				return;
			}
			if(comboBox1.Text != "" && comboBox2.Text != ""){
				query.SetCommand(textBox2.Text);
				query.Execute();
				
				oleDb.dataSet.Clear();
				dataGrid1.DataSource = oleDb.dataSet;
				oleDb.oleDbCommandSelect.CommandText = textBox1.Text;
				oleDb.ExecuteFill(comboBox2.Text);
			}else{
				MessageBox.Show("Вы не выбрали файл базы данных или не указали имя таблицы!");
			}
		}
		void Button3Click(object sender, EventArgs e)
		{
			if(textBox1.Text == ""){
				MessageBox.Show("Необходимо ввести запрос Select");
				return;
			}
			if(comboBox1.Text != "" && comboBox2.Text != ""){
				query.SetCommand(textBox3.Text);
				query.Execute();
				
				oleDb.dataSet.Clear();
				dataGrid1.DataSource = oleDb.dataSet;
				oleDb.oleDbCommandSelect.CommandText = textBox1.Text;
				oleDb.ExecuteFill(comboBox2.Text);
			}else{
				MessageBox.Show("Вы не выбрали файл базы данных или не указали имя таблицы!");
			}
		}
		void Button4Click(object sender, EventArgs e)
		{
			if(textBox1.Text == ""){
				MessageBox.Show("Необходимо ввести запрос Select");
				return;
			}
			if(comboBox1.Text != "" && comboBox2.Text != ""){
				query.SetCommand(textBox4.Text);
				query.Execute();
				
				oleDb.dataSet.Clear();
				dataGrid1.DataSource = oleDb.dataSet;
				oleDb.oleDbCommandSelect.CommandText = textBox1.Text;
				oleDb.ExecuteFill(comboBox2.Text);
			}else{
				MessageBox.Show("Вы не выбрали файл базы данных или не указали имя таблицы!");
			}
		}
		void FormConsoleQueryActivated(object sender, EventArgs e)
		{
			DataForms.FClient.messageInStatus(this.Text);
		}
	}
}
