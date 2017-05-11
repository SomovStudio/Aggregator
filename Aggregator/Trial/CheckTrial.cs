/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 09.05.2017
 * Время: 6:58
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Windows.Forms;
using Aggregator.Data;
using Microsoft.Win32;

namespace Aggregator.Trial
{
	/// <summary>
	/// Description of CheckTrial.
	/// </summary>
	public class CheckTrial
	{
		
		public CheckTrial()
		{
			try{
				RegistryKey currentUserKey = Registry.CurrentUser;
				RegistryKey aggregatorKey = currentUserKey.OpenSubKey(DataConstants.NAME_APPLICATION);
				if(aggregatorKey == null){
					aggregatorKey = currentUserKey.CreateSubKey(DataConstants.NAME_APPLICATION);
					aggregatorKey.SetValue("000001", encrypt(DateTime.Today.ToString("dd.MM.yyyy").ToString()) );
					aggregatorKey.SetValue("000002", encrypt("0"));
				}
				
				DataConfig.dateStart = decipher(aggregatorKey.GetValue("000001").ToString());
				DataConfig.activated = decipher(aggregatorKey.GetValue("000002").ToString());
				aggregatorKey.Close();
			}catch(Exception ex){
				MessageBox.Show(ex.Message, "Ошибка");
				Application.Exit();
			}
		}
		
		public bool Check()
		{
			if(DataConfig.activated == DataConstants.KEY_APPLICATION){
				return true;
			}else{
				DateTime dt = Convert.ToDateTime(DataConfig.dateStart);
				TimeSpan ts = DateTime.Now - dt;
				int differenceInDays = 30 - ts.Days;
				
				FormTrial FTrial = new FormTrial();
				FTrial.DaysLeft = differenceInDays;
				FTrial.CTrial = this;
				FTrial.ShowDialog();
				
				if(differenceInDays < 0) return false;
				else return true;
			}
		}
		
		public void Activation(String key)
		{
			if(key == DataConstants.KEY_APPLICATION){
				
				try{
					RegistryKey currentUserKey = Registry.CurrentUser;
					RegistryKey aggregatorKey = currentUserKey.OpenSubKey(DataConstants.NAME_APPLICATION);
					if(aggregatorKey == null){
						aggregatorKey = currentUserKey.CreateSubKey(DataConstants.NAME_APPLICATION);
						aggregatorKey.SetValue("000001", encrypt(DateTime.Today.ToString("dd.MM.yyyy").ToString()) );
						aggregatorKey.SetValue("000002", encrypt(key));
					}else{
						aggregatorKey = currentUserKey.OpenSubKey(DataConstants.NAME_APPLICATION, true);
						aggregatorKey.SetValue("000002", encrypt(key));
					}
					
					DataConfig.dateStart = decipher(aggregatorKey.GetValue("000001").ToString());
					DataConfig.activated = decipher(aggregatorKey.GetValue("000002").ToString());
					aggregatorKey.Close();
					
				}catch(Exception ex){
					MessageBox.Show(ex.ToString(), "Ошибка");
					return;
				}
				
				MessageBox.Show("Активация прошла успешно!" + Environment.NewLine + "Необходимо перезапустить программу.", "Сообщение");
				DataConfig.programClose = true;
				Application.Exit();
			}else{
				MessageBox.Show("Вы ввели не верный ключ активации!", "Сообщение");
				return;
			}
		}
		
		String encrypt(String strValue)
		{
			String hexOutput = null;
			char[] values = strValue.ToCharArray();
			foreach(char letter in values)
			{
				int ivalue = Convert.ToInt32(letter);
				if(hexOutput == null) hexOutput += String.Format("{0:X}", ivalue);
				else hexOutput += " " + String.Format("{0:X}", ivalue);
			}
			return hexOutput;
		}
		
		String decipher(String hexValue)
		{
			String strOutput = null;
			String[] values = hexValue.Split(' ');
			foreach(String hex in values){
				int ivalue = Convert.ToInt32(hex, 16);
				strOutput += Char.ConvertFromUtf32(ivalue);
			}
			return strOutput;
		}
	}
}
