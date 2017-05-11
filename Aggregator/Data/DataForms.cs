/*
 * Created by SharpDevelop.
 * User: Somov Studio
 * Date: 23.02.2017
 * Time: 10:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Aggregator.Admin;
using Aggregator.Client;
using Aggregator.Client.Directories;
using Aggregator.Client.Documents;
using Aggregator.Client.Documents.Order;
using Aggregator.Client.Documents.PurchasePlan;
using Aggregator.Client.Settings;
using Aggregator.User;

namespace Aggregator.Data
{
	/// <summary>
	/// Description of DataForms.
	/// </summary>
	public static class DataForms
	{
		public static MainForm FMain;
		public static FormCheckUser FCheckUser;
		/* Клиент */
		public static FormClient FClient;
		public static FormSettings FSettings;
		public static FormConstants FConstants;
		public static FormCounteragents FCounteragents;
		public static FormNomenclature FNomenclature;
		public static FormUnits FUnits;
		public static FormPurchasePlanJournal FPurchasePlanJournal;
		public static FormOrderJournal FOrderJournal;
		public static FormFullJournal FFullJournal;
		/*Администратор*/
		public static FormDatabase FDatabase;
		public static FormConsoleQuery FConsoleQuery;
		public static FormUsers FUsers;
	}
}
