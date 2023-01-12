using Dapper;
using Microsoft.Data.Sqlite;
using System.Linq;
using System.Threading.Tasks;


namespace Markel.Claims.Service.Data
{
    public class DatabaseBootstrap : IDatabaseBootstrap
    {
 
            private readonly DatabaseConfig databaseConfig;

            public DatabaseBootstrap(DatabaseConfig databaseConfig)
            {
                this.databaseConfig = databaseConfig;
            }

            public void Setup()
            {
                using var connection = new SqliteConnection(databaseConfig.Name);

                connection.Open();  

                var table = connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND name = 'Claims';");
                bool bTableExists = table.Any(row => row.ToLower().Contains("claims"));
                if (!bTableExists)
                {
                connection.Execute("Create Table Claims (" +
                                    "ClaimId INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "UCR VARCHAR(20), " +
                                    "CompanyId INTEGER," +
                                    "ClaimDate DATETIME," +
                                    "LossDate DATETIME, " +
                                    "[Assured Name] VARCHAR(100), " +
                                    "[Incurred Loss] DECIMAL(15, 2), " +
                                    "Closed BIT" +
                                    ")"
                                    );
    
                }

            var companyTable = connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND name = 'Company';");
            bTableExists = companyTable.Any(row => row.ToLower().Contains("company"));
            if (bTableExists)
                return;

            connection.Execute("Create Table Company (" +
                                    "Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "Name VARCHAR(200), " +
                                    "Address1 varchar(100)," +
                                    "Address2 varchar(100)," +
                                    "Address3 varchar(100), " +
                                    "Postcode varchar(50), " +
                                    "Country varchar(50), " +
                                    "Active BIT," +
                                    "InsuranceEndDate DATETIME " +
                                    ")"
                                    );
            //TODO: Add foreign key constraint between Company and Claims
            connection.Close();
        }
    }
}
