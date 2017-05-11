/*
 * Created by SharpDevelop.
 * User: Somov Studio
 * Date: 25.02.2017
 * Time: 11:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using Aggregator.Data;

namespace Aggregator.Utilits
{
	/// <summary>
	/// Description of Console.
	/// </summary>
	public static class Console
	{
		public static void Log(String message, bool clear = false, bool show = false)
		{
			if(DataForms.FClient != null){
				if(DataForms.FClient.consoleText.Text.Length > 10000) DataForms.FClient.consoleText.Clear();
				if(show && DataConfig.showConsole){
					DataForms.FClient.consolePanel.Visible = true;
				}
				if(clear){
					DataForms.FClient.consoleText.Clear();
					DataForms.FClient.consoleText.Text = "[" + DateTime.Now.ToString() + "]: " + message;
				}else{
					DataForms.FClient.consoleText.Text = "[" + DateTime.Now.ToString() + "]: " + message + Environment.NewLine + DataForms.FClient.consoleText.Text;
				}
			}else{
				if(show) MessageBox.Show(message, "Ошибка");
			}
		}
	}
}
