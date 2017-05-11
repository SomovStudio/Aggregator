/*
 * Created by SharpDevelop.
 * User: Somov Studio
 * Date: 02.03.2017
 * Time: 17:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Aggregator.Data;

namespace Aggregator.Database.Server
{
	/// <summary>
	/// Description of sqlServer.
	/// </summary>
	public class SqlServer
	{
		public SqlCommand sqlCommandSelect;
		public SqlCommand sqlCommandInsert;
		public SqlCommand sqlCommandUpdate;
		public SqlCommand sqlCommandDelete;
		public DataSet dataSet;
		
		public SqlConnection sqlConnection;
		public SqlDataAdapter sqlDataAdapter;
		
		public SqlServer()
		{
			sqlConnection = new SqlConnection(DataConfig.serverConnection);
			sqlCommandSelect = new SqlCommand("", sqlConnection);
			sqlCommandInsert = new SqlCommand("", sqlConnection);
			sqlCommandUpdate = new SqlCommand("", sqlConnection);
			sqlCommandDelete = new SqlCommand("", sqlConnection);
			sqlDataAdapter = new SqlDataAdapter();
			dataSet = new DataSet();
		}
		
		public bool ExecuteFill(String tableName){
			sqlDataAdapter.SelectCommand = sqlCommandSelect;
			sqlDataAdapter.InsertCommand = sqlCommandInsert;
			sqlDataAdapter.UpdateCommand = sqlCommandUpdate;
			sqlDataAdapter.DeleteCommand = sqlCommandDelete;
			try{
				sqlConnection.Open();
				sqlDataAdapter.Fill(dataSet, tableName);
				sqlConnection.Close();
				return true;
			}catch(Exception ex){
				sqlConnection.Close();
				Utilits.Console.Log("[ОШИБКА] " + ex.Message.ToString(), false, true);
				return false;
			}
		}
		
		public bool ExecuteUpdate(String tableName){
			sqlDataAdapter.SelectCommand = sqlCommandSelect;
			sqlDataAdapter.InsertCommand = sqlCommandInsert;
			sqlDataAdapter.UpdateCommand = sqlCommandUpdate;
			sqlDataAdapter.DeleteCommand = sqlCommandDelete;
			try{
				sqlConnection.Open();
				sqlDataAdapter.Update(dataSet, tableName);
				sqlConnection.Close();
				return true;
			}catch(Exception ex){
				sqlConnection.Close();
				Utilits.Console.Log("[ОШИБКА] " + ex.Message.ToString(), false, true);
				return false;
			}
		}
		
		public void Error()
		{
			Dispose();
		}
		
		public void Dispose()
		{
			if(sqlConnection != null) {
				sqlConnection.Close();
				sqlConnection.Dispose();
			}
			if(sqlCommandSelect != null) sqlCommandSelect.Dispose();
			if(sqlCommandDelete != null) sqlCommandDelete.Dispose();
			if(sqlCommandUpdate != null) sqlCommandUpdate.Dispose();
			if(sqlCommandInsert != null) sqlCommandInsert.Dispose();
			if(sqlDataAdapter != null) sqlDataAdapter.Dispose();
			if(dataSet != null){
				dataSet.Clear();
				dataSet.Dispose();
			}
		}
	}
}
