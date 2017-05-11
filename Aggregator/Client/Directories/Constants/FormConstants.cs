/*
 * Created by SharpDevelop.
 * User: Somov Studio
 * Date: 04.03.2017
 * Time: 10:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Aggregator.Data;
using Aggregator.Database.Constants;

namespace Aggregator.Client.Directories
{
	/// <summary>
	/// Description of FormConstants.
	/// </summary>
	public partial class FormConstants : Form
	{
		public FormConstants()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		/* =================================================================================================
		 * РАЗДЕЛ: СОБЫТИЙ
		 * =================================================================================================
		 */	
		
		void FormConstantsLoad(object sender, EventArgs e)
		{
			nameTextBox.Text = DataConstants.ConstFirmName;
			addressTextBox.Text = DataConstants.ConstFirmAddress;
			vatTextBox.Text = DataConstants.ConstFirmVAT.ToString();
			unitsTextBox.Text = DataConstants.ConstFirmUnits;
			
			emailTextBox.Text = DataConstants.ConstFirmEmail;
			pwdTextBox.Text = DataConstants.ConstFirmPwd;
			smtpTextBox.Text = DataConstants.ConstFirmSmtp;
			portTextBox.Text = DataConstants.ConstFirmPort;
			sslCheckBox.Checked = DataConstants.ConstFirmEnableSsl;
			captionTextBox.Text = DataConstants.ConstFirmCaption;
			messageTextBox.Text = DataConstants.ConstFirmMessage;
			
			Utilits.Console.Log(this.Text + ": открыт.");
		}
		void FormConstantsFormClosed(object sender, FormClosedEventArgs e)
		{
			DataForms.FClient.messageInStatus("...");
			Utilits.Console.Log(this.Text + ": закрыт.");
			Dispose();
			DataForms.FConstants = null;
		}
		void ButtonSaveClick(object sender, EventArgs e)
		{
			if(DataConfig.userPermissions == "user" || DataConfig.userPermissions == "guest") {
				MessageBox.Show("У вас недостаточно прав чтобы выполнить эту операцию.", "Сообщение");
				return;
			}
			DataConstants.ConstFirmName = nameTextBox.Text;
			DataConstants.ConstFirmAddress = addressTextBox.Text;
			DataConstants.ConstFirmVAT = Convert.ToDouble(vatTextBox.Text);
			DataConstants.ConstFirmUnits = unitsTextBox.Text;
			
			DataConstants.ConstFirmEmail = emailTextBox.Text;
			DataConstants.ConstFirmPwd = pwdTextBox.Text;
			DataConstants.ConstFirmSmtp = smtpTextBox.Text;
			DataConstants.ConstFirmPort = portTextBox.Text;
			DataConstants.ConstFirmEnableSsl = sslCheckBox.Checked;
			DataConstants.ConstFirmCaption = captionTextBox.Text;
			DataConstants.ConstFirmMessage = messageTextBox.Text;
			
			SavingConstants savingConstants = new SavingConstants();
			savingConstants.save();
			savingConstants.Dispose();
			Close();
		}
		void ButtonCancelClick(object sender, EventArgs e)
		{
			Close();
		}
		void Button3Click(object sender, EventArgs e)
		{
			nameTextBox.Clear();
		}
		void Button4Click(object sender, EventArgs e)
		{
			emailTextBox.Clear();
		}
		void Button5Click(object sender, EventArgs e)
		{
			addressTextBox.Clear();
		}
		void Button1Click(object sender, EventArgs e)
		{
			vatTextBox.Text = "0";
		}
		void Button2Click(object sender, EventArgs e)
		{
			smtpTextBox.Clear();
		}
		void Button7Click(object sender, EventArgs e)
		{
			portTextBox.Clear();
		}
		void Button6Click(object sender, EventArgs e)
		{
			pwdTextBox.Clear();
		}
		void Button9Click(object sender, EventArgs e)
		{
			unitsTextBox.Clear();
		}
		void Button8Click(object sender, EventArgs e)
		{
			if(DataForms.FUnits != null) DataForms.FUnits.Close();
			if(DataForms.FUnits == null) {
				DataForms.FUnits = new FormUnits();
				DataForms.FUnits.MdiParent = DataForms.FClient;
				DataForms.FUnits.TextBoxReturnValue = unitsTextBox;
				DataForms.FUnits.ShowMenuReturnValue();
				DataForms.FUnits.Show();
			}
		}
		void FormConstantsActivated(object sender, EventArgs e)
		{
			DataForms.FClient.messageInStatus(this.Text);
		}
		void Button10Click(object sender, EventArgs e)
		{
			captionTextBox.Clear();
		}
		void Button11Click(object sender, EventArgs e)
		{
			messageTextBox.Clear();
		}
		
		
	}
}
