using System;
namespace SQL.BulkDataTransfer.Models
{
	public class DbTransfer
	{
		public DbObject sourceObject { get; set; }
		public DbObject destinationObject { get; set; }
	}
}

