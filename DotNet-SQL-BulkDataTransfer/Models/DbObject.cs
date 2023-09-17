using System;
namespace SQL.BulkDataTransfer.Models
{
	public class DbObject
	{
		public string connectionName { get; set; }
		public string database { get; set; }
		public string schema { get; set; }
		public string name { get; set; }
	}
}

