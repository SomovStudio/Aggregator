/*
 * Created by SharpDevelop.
 * User: Somov Studio
 * Date: 01.03.2017
 * Time: 10:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Aggregator.Data;
using Aggregator.Database.Config;

namespace Aggregator.Client.Settings
{
	/// <summary>
	/// Description of FormSettings.
	/// </summary>
	public partial class FormSettings : Form
	{
		public FormSettings()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void FormSettingsLoad(object sender, EventArgs e)
		{
			ReadingConfig.ReadSettings();
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL) {
				autoUpdateCheckBox.Checked = DataConfig.autoUpdate;
				autoUpdateCheckBox.Enabled = true;
			} else {
				autoUpdateCheckBox.Checked = true;
				autoUpdateCheckBox.Enabled = false;
			}
			showConsoleCheckBox.Checked = DataConfig.showConsole;
			
			// today, yesterday, week, month, year
			if(DataConfig.period == "today") periodComboBox.Text = "Сегодня";
			if(DataConfig.period == "yesterday") periodComboBox.Text = "Вчера";
			if(DataConfig.period == "week") periodComboBox.Text = "Неделя";
			if(DataConfig.period == "month") periodComboBox.Text = "Месяц";
			if(DataConfig.period == "year") periodComboBox.Text = "Год";
			
			Utilits.Console.Log(this.Text + ": открыт");
		}
		void FormSettingsFormClosed(object sender, FormClosedEventArgs e)
		{
			DataForms.FClient.messageInStatus("...");
			Utilits.Console.Log(Text + ": закрыт.");
			Dispose();
			DataForms.FSettings = null;
		}
		void ButtonCancelClick(object sender, EventArgs e)
		{
			Close();
		}
		void ButtonSaveClick(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "user" || DataConfig.userPermissions == "guest") {
				MessageBox.Show("У вас недостаточно прав чтобы выполнить данное действие.", "Сообщение");
				return;
			}
			
			DataForms.FClient.autoUpdateOff();
			DataConfig.autoUpdate = autoUpdateCheckBox.Checked;
			if(DataConfig.autoUpdate) DataForms.FClient.autoUpdateOn();
			DataConfig.showConsole = showConsoleCheckBox.Checked;
			
			if(periodComboBox.Text == "Сегодня") DataConfig.period = "today";
			if(periodComboBox.Text == "Вчера") DataConfig.period = "yesterday";
			if(periodComboBox.Text == "Неделя") DataConfig.period = "week";
			if(periodComboBox.Text == "Месяц") DataConfig.period = "month";
			if(periodComboBox.Text == "Год") DataConfig.period = "year";
			SavingConfig.SaveSettings();
			Close();
		}
		void FormSettingsActivated(object sender, EventArgs e)
		{
			DataForms.FClient.messageInStatus(this.Text);
		}
	}
}
