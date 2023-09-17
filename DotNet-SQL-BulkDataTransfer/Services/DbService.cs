using System;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using SQL.BulkDataTransfer.Models;
namespace SQL.BulkDataTransfer.Services
{
	public class DbService
	{

		private static string ConnectionString(string connectionName)
		{
			return Configuration.ConnectionStrings[connectionName].ConnectionString);
		}

		public static void TruncateTable(DbObject table)
		{

		}

		public static void BulkTransfer(DbObject source, DbObject dest)
		{

		}
	}
}

