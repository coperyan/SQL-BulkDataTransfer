using System;
namespace SQL.BulkDataTransfer.Models
{
	public class DbTransfer
	{
		public DbObject source { get; set; }
		public DbObject destination { get; set; }
	}
}

