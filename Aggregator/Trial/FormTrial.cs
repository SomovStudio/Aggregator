/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 09.05.2017
 * Время: 6:58
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Aggregator.Trial
{
	/// <summary>
	/// Description of FormTrial.
	/// </summary>
	public partial class FormTrial : Form
	{
		public FormTrial()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public int DaysLeft = 0;
		public CheckTrial CTrial = null;
		
		void Button2Click(object sender, EventArgs e)
		{
			Close();
		}
		void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try{
				System.Diagnostics.Process.Start(linkLabel1.Text);
			}catch(Exception ex){
				MessageBox.Show(ex.Message, "Ошибка");
			}
		}
		void FormTrialLoad(object sender, EventArgs e)
		{
			if(DaysLeft <= 0) {
				label5.Text = "У вас осталось: 0 дней. \nВы не можите больше пользоваться программой пока не купите лицензионный ключ.";
				button2.Enabled = false;
			} else {
				label5.Text = "У вас осталось: " + DaysLeft.ToString() + " дней";
				button2.Enabled = true;
			}
		}
		void Button1Click(object sender, EventArgs e)
		{
			CTrial.Activation(textBox1.Text);
		}
	}
}
