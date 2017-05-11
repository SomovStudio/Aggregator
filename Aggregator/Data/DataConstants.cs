/*
 * Created by SharpDevelop.
 * User: Somov Studio
 * Date: 23.02.2017
 * Time: 11:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Aggregator.Data
{
	/// <summary>
	/// Description of DataConstants.
	/// </summary>
	public static class DataConstants
	{
		public const String KEY_APPLICATION = "0000-0000-0000-0000-0000";
		public const String NAME_APPLICATION = "{00000000-0000-0000-0000-000000000000}";
		
		public const String CONNETION_LOCAL = "connection_local";
		public const String CONNETION_SERVER = "connection_server";
		public const String TYPE_OLEDB = "type_oledb";
		public const String TYPE_MSSQL = "type_mssql";
		public const String ADMIN = "admin";
		public const String USER = "user";
		public const String FOLDER = "folder";
		public const String FILE = "file";
		public const String TODAY = "today";
		public const String YESTERDAY = "yesterday";
		public const String WEEK = "week";
		public const String MONTH = "month";
		public const String YEAR = "year";
		
		/* Константы из базы данных */
		public static String ConstFirmName = "";
		public static String ConstFirmAddress = "";
		public static Double ConstFirmVAT = 0;
		public static String ConstFirmUnits = "";
		
		public static String ConstFirmEmail = "";
		public static String ConstFirmPwd = "";
		public static String ConstFirmSmtp = "";
		public static String ConstFirmPort = "";
		public static Boolean ConstFirmEnableSsl = false;
		public static String ConstFirmCaption = "";
		public static String ConstFirmMessage = "";
		
	}
}
