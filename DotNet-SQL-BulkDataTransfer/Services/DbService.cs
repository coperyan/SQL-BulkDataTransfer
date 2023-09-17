using System;
using System.Configuration;
using System.Data.SqlClient;
using SQL.BulkDataTransfer.Models;
namespace SQL.BulkDataTransfer.Services
{
	public class DbService
	{
		private static int SQL_COMMAND_TIMEOUT = 600;
		private static int BULK_COPY_TIMEOUT = 600;


		public static void TruncateTable(DbObject table)
		{
			string truncateQuery = table.getTruncateQuery();

			using (SqlConnection connection = new SqlConnection(table.getSqlConnectionString()))
			{
				SqlCommand command = new SqlCommand(truncateQuery, connection);
				command.Connection.Open();
				command.ExecuteNonQuery();
			}

			Console.WriteLine("Completed execution of {0}", truncateQuery);

        }

		public static void BulkTransfer(DbObject source, DbObject dest)
		{

			using (SqlConnection sourceConnection = new SqlConnection(source.getSqlConnectionString()))
			{
				sourceConnection.Open();

				SqlCommand commandRowCount = new SqlCommand(source.getRowCountQuery(), sourceConnection);

				long rwcnt = System.Convert.ToInt32(commandRowCount.ExecuteScalar());
				Console.WriteLine("Starting row count: {0}", rwcnt);

				SqlCommand commandSourceData = new SqlCommand(source.getSelectQuery(), sourceConnection);
				commandSourceData.CommandTimeout = SQL_COMMAND_TIMEOUT;
                SqlDataReader reader = commandSourceData.ExecuteReader();

				using (SqlConnection destinationConnection = new SqlConnection(dest.getSqlConnectionString()))
				{
					destinationConnection.Open();

					using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
					{
						bulkCopy.DestinationTableName = string.Format("{0}.{1}", dest.schema, dest.objectName);
						bulkCopy.BulkCopyTimeout = BULK_COPY_TIMEOUT;

						try
						{
							bulkCopy.WriteToServer(reader);
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.Message);
						}
						finally
						{
							reader.Close();
						}
					}

                    long countEnd = System.Convert.ToInt32(commandRowCount.ExecuteScalar());
                    Console.WriteLine("Ending row count = {0}", countEnd);

                }
			}

		}
	}
}

///Users/rcope/dev/personal_projects/SQL-BulkDataTransfer/DotNet-SQL-BulkDataTransfer/app.config