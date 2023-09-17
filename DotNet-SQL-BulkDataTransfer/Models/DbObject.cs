using System;
using System.Configuration;

namespace SQL.BulkDataTransfer.Models
{
	public class DbObject
	{
		public string connectionName { get; set; }
		public string database { get; set; }
		public string schema { get; set; }
		public string objectName { get; set; }

		public string getTruncateQuery()
		{
			return string.Format("TRUNCATE TABLE {0}.{1}.{2};", database, schema, objectName);

        }

		public string getRowCountQuery()
		{
			return string.Format("SELECT COUNT(*) FROM {0}.{1}.{2} (NOLOCK);", database, schema, objectName);

        }

		public string getSelectQuery()
		{
			return string.Format("SELECT * FROM {0}.{1}.{2} (NOLOCK);", database, schema, objectName);
        }

		public string getSqlConnectionString()
		{
			return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
		}
	}
}

