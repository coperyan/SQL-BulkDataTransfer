
using SQL.BulkDataTransfer.Services;

namespace SQL.BulkDataTransfer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Parse json config, initialize list of DbTransfer models for iteration
            foreach(var transfer in ConfigService.GetTransfers())
            {

                Console.WriteLine(string.Format("{0} - Starting transfer for {1}..", DateTime.Now, transfer.source.objectName));

                DbService.TruncateTable(transfer.destination);
                DbService.BulkTransfer(transfer.source, transfer.destination);

                Console.WriteLine(string.Format("{0} - Starting transfer for {1}..", DateTime.Now, transfer.source.objectName));

            }

        }
    }
}
