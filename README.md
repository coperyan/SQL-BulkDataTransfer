# SQL - Bulk Data Transfer App
- An extremely efficient solution for large data movement between SQL server instances.
- Blows SSIS, turbodbc (Python), etc. out of the water.
- Performs a `transfer` (copy) for a user-defined list of Sql `objects` (tables, views, etc.)

## Configuration
See the example [transferconfig.json](example_config/transferconfig.json)
Each item in the outer array represents a database operation `source` to `destination`

```json
  {
    "source": {
      "connectionName": "crm-sql",
      "database": "crm",
      "schema": "dbo",
      "objectName": "Customers"
    },
    "destination": {
      "connectionName": "bi-sql",
      "database": "Reporting",
      "Schema": "dbo",
      "objectName": "Customers"
    }
  }
```
Edit the db, schema, obj names, and make sure the connectionName matches a `connectionString` listed in the program's configuration. 
See the example [app.config](example_config/app.config) for more. 

## Runtime

```csharp
//Parse json config, initialize list of DbTransfer models for iteration
foreach(var transfer in ConfigService.GetTransfers())
{
    Console.WriteLine(string.Format("{0} - Starting transfer for {1}..", DateTime.Now, transfer.source.objectName));

    DbService.TruncateTable(transfer.destination);
    DbService.BulkTransfer(transfer.source, transfer.destination);

    Console.WriteLine(string.Format("{0} - Starting transfer for {1}..", DateTime.Now, transfer.source.objectName));
}```

## Dependencies 

-`.NETCore 7.0.11`
- `Newtonsoft.Json 13.0.3`
  - Parses the local .json configuration
- `System.Configuration.ConfigurationManager - 7.0.0`
  - For interacting with app.config, obtaining/storing connectionStrings
- `System.Data.SqlClient - 4.8.5`
  - For interacting with Sql
