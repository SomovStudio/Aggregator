/*
 * Created by SharpDevelop.
 * User: Somov Studio
 * Date: 23.02.2017
 * Time: 10:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Aggregator.Data
{
	/// <summary>
	/// Description of DataConfig.
	/// </summary>
	public static class DataConfig
	{
		/* Программа */	
		public static String programPath = "";			// адрес программы
		public static String resource = "";				// адрес папки ресурсов
		public static String configFile = "";			// адрес и имя файла базы данных config.mdb
		public static Boolean programClose = true;		// флаг обязательного закрытия приложения
		public static String dateStart = null;			// дата первого запуска программы
		public static String activated = null;			// флаг активации программы
		
		
		/* Пользователь */
		public static String userName = "";				// имя
		public static String userPass = "";				// пароль
		public static String userPermissions = "";		// права (admin, operator, user, guest)
		
		/* Локальная база данных */		
		public static String oledbConnectLineBegin = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
		public static String oledbConnectLineEnd = "";
		public static String oledbConnectPass = "";
		//public static String oledbConnectLineEnd = ";Jet OLEDB:Database Password=";
		//public static String oledbConnectPass = "12345";
		
		/* Настройки подключения к базе данных */		
		public static String localDatabase = "";		// адрес и имя файла базы данных database.mdb
		public static String typeConnection = "";		// тип подключения к базе данных (local/servel)
		public static String typeDatabase = "";			// тип провайдера данных (oledb/mssql)
		public static String serverConnection = "";		// строка подключения к серверу MSSQL Server
		
		/* Настройки программы*/
		public static Boolean autoUpdate = true;		// автоматическое обновление данных в журналах
		public static Boolean showConsole = true;		// показывать консоль каждый раз при ошибках
		public static String period = "";				// фильтр период по умолчанию для журналов
		
	}
}
