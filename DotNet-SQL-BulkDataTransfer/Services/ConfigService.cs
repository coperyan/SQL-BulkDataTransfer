using System;
using Newtonsoft.Json;
using SQL.BulkDataTransfer.Models;
namespace SQL.BulkDataTransfer.Services
{
	public class ConfigService
	{

		public static List<DbTransfer> GetTransfers()
		{

	        string text = File.ReadAllText("../../../transferconfig.json");

            var transfers = JsonConvert.DeserializeObject<List<DbTransfer>>(text);

			return transfers;

        }

	}
}


