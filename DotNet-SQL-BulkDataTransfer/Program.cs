
using SQL.BulkDataTransfer.Services;

///https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlbulkcopy.destinationtablename?view=dotnet-plat-ext-7.0
///https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlbulkcopy.enablestreaming?view=dotnet-plat-ext-7.0https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlbulkcopy?view=dotnet-plat-ext-7.0
///https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlbulkcopy?view=dotnet-plat-ext-7.0#examples
///https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlbulkcopy?view=dotnet-plat-ext-7.0
///https://www.sentryone.com/blog/using-sqlbulkcopy-net-faster-bulk-data-loading

namespace SQL.BulkDataTransfer
{
    class Program
    {
        static void Main(string[] args)
        {

            // See https://aka.ms/new-console-template for more information
            Console.WriteLine("Hello, World!");

            //Get transfer queue from config JSON
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
