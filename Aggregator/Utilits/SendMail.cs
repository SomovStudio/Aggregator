/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 01.05.2017
 * Время: 8:13
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Net;
using System.Net.Mail;
using Aggregator.Data;

namespace Aggregator.Utilits
{
	/// <summary>
	/// Description of SendMail.
	/// </summary>
	
	
	public class SendMail
	{
		MailMessage mail;
		SmtpClient client;
		
		public SendMail()
		{
			mail = new MailMessage();
			client = new SmtpClient();
		}
		
		public bool Send(String mailfrom, String mailto, String caption, String message, String attachFile = null)
		{
			try
			{ 
				mail.From = new MailAddress(mailfrom);						// Адрес отправителя
				mail.To.Add(new MailAddress(mailto));						// Адрес получателя
				mail.Subject = caption;										// Тема письма
				mail.Body = message;										// Сообщение
				if (!String.IsNullOrEmpty(attachFile))	
					mail.Attachments.Add(new Attachment(attachFile));		// Присоединенный файл
				
				client.Host = DataConstants.ConstFirmSmtp;					// Имя SMTP-сервера
				client.Port = Convert.ToInt32(DataConstants.ConstFirmPort);	// Порт
				client.EnableSsl = DataConstants.ConstFirmEnableSsl;		// SSL
				client.Credentials = new NetworkCredential(mailfrom.Split('@')[0], DataConstants.ConstFirmPwd); // пароль
				client.DeliveryMethod = SmtpDeliveryMethod.Network;
				client.Send(mail);
				mail.Dispose();
				return true;
			} catch (Exception ex) {
				client = null;
				mail.Dispose();
				Utilits.Console.Log("[ОШИБКА] Отправка заказа по почте: " + ex.Message, false, true);
				return false;
			}
		}
		
		/*
		/// <param name="smtpServer">Имя SMTP-сервера</param>
		/// <param name="from">Адрес отправителя</param>
		/// <param name="password">пароль к почтовому ящику отправителя</param>
		/// <param name="mailto">Адрес получателя</param>
		/// <param name="caption">Тема письма</param>
		/// <param name="message">Сообщение</param>
		/// <param name="attachFile">Присоединенный файл</param>
		public void Send(string smtpServer, string from , string password, string mailto, string caption, string message, string attachFile = null)
		{
			try
			{ 
				MailMessage mail = new MailMessage();
				mail.From = new MailAddress(from);
				mail.To.Add(new MailAddress(mailto));
				mail.Subject = caption;
				mail.Body = message;
				if (!string.IsNullOrEmpty(attachFile))	mail.Attachments.Add(new Attachment(attachFile));
				SmtpClient client = new SmtpClient(); 
				client.Host = smtpServer; 
				client.Port = 587; 
				client.EnableSsl = true;
				client.Credentials = new NetworkCredential(from.Split('@')[0], password);
				client.DeliveryMethod = SmtpDeliveryMethod.Network;
				client.Send(mail);
				mail.Dispose();
			} catch (Exception e) {
				throw new Exception("Mail.Send: " + e.Message);
			}
		}
		*/
	}
}
