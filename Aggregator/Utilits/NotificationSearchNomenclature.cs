/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 30.04.2017
 * Время: 10:45
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Aggregator.Data;
using Aggregator.Database.Local;
using Aggregator.Database.Server;


namespace Aggregator.Utilits
{
	/// <summary>
	/// Description of NotificationSearchNomenclature.
	/// </summary>
	public partial class NotificationSearchNomenclature : Form
	{
		public NotificationSearchNomenclature()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public ListView ListViewPrices;
		public ListView ListViewNomenclature;
		SearchNomenclatureOleDb searchNomenclatureOleDb;
		SearchNomenclatureSqlServer searchNomenclatureSql;
		
		public void Run()
		{
			if(DataConfig.typeConnection == DataConstants.CONNETION_LOCAL) {
				// OLEDB
				searchNomenclatureOleDb = new SearchNomenclatureOleDb();
				searchNomenclatureOleDb.setPrices(ListViewPrices);
				searchNomenclatureOleDb.autoFindNomenclature(ListViewNomenclature, this);
			} else if (DataConfig.typeConnection == DataConstants.CONNETION_SERVER){
				// MSSQL SERVER
				searchNomenclatureSql = new SearchNomenclatureSqlServer();
				searchNomenclatureSql.setPrices(ListViewPrices);
				searchNomenclatureSql.autoFindNomenclature(ListViewNomenclature, this);
			}
		}
		
		public void MessageText(String mText)
		{
			label1.Text = mText;
			label1.Update();
			Update();
		}
		
		/* =================================================================================================
		 * РАЗДЕЛ: СОБЫТИЙ
		 * =================================================================================================
		 */	
		void NotificationSearchNomenclatureLoad(object sender, EventArgs e)
		{
			
		}
		void Button1Click(object sender, EventArgs e)
		{
			Run();
		}
		void NotificationSearchNomenclatureFormClosed(object sender, FormClosedEventArgs e)
		{
			Dispose();
		}
		
	}
}
