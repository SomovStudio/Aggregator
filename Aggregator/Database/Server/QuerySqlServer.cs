/*
 * Created by SharpDevelop.
 * User: Somov Studio
 * Date: 02.03.2017
 * Time: 18:20
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
	/// Description of QuerySqlServer.
	/// </summary>
	public class QuerySqlServer
	{
		SqlConnection sqlConnection;
		SqlCommand sqlCommand;		
		
		public QuerySqlServer(String connectionString)
		{
			sqlConnection = new SqlConnection();
			sqlConnection.ConnectionString = connectionString;
		}
		
		public void SetCommand(String sqlTextCommand)
		{
			sqlCommand = new SqlCommand(sqlTextCommand, sqlConnection);
		}
		
		public bool Execute()
		{
			try{
				sqlConnection.Open();
				sqlCommand.ExecuteNonQuery();	//выполнение запроса				
				sqlConnection.Close();
				return true;
			}catch(Exception ex){
				sqlConnection.Close();
				Utilits.Console.Log("[ОШИБКА] ошибка выполнения запроса: " + ex.Message.ToString(), false, true);
				return false;
			}
		}
		
		public void Dispose()
		{
			if(sqlCommand != null) sqlCommand.Dispose();
			if(sqlConnection != null) sqlConnection.Dispose();
		}
	}
}
