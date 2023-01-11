using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Markel.Claims.Service.Data.Repository
{
    public class CompanyRepository //: IGenericRepository<Company>
    {
        private readonly DatabaseConfig databaseConfig;
        public CompanyRepository(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        //public async Task<int> Add(Company claim)
        //{
        //    int inserted = 0;
        //    using (var connection = new SqliteConnection(databaseConfig.Name))
        //    {
        //        connection.Open();
        //        await connection.ExecuteAsync("INSERT INTO Company(UCR, ClaimDate, LossDate, [Assured Name],[Incurred Loss], Closed) values ('" + claim.UCR + "','" + claim.ClaimDate + "','" +
        //                                                               claim.LossDate + "','" +
        //                                                               claim.AssuredName + "','" +
        //                                                               claim.IncurredLoss + "','" +
        //                                                               claim.Closed + "')");
        //        inserted++;
        //        return inserted;
        //    }

        //}


        //public async Task<Company> Get(int id)
        //{

        //    using (var connection = new SqliteConnection(databaseConfig.Name))
        //    {
        //        connection.Open();
        //        var result = await connection.QuerySingleOrDefaultAsync("SELECT UCR, rowId, CompanyId, ClaimDate, LossDate, [Assured Name] as AssuredName, [Incurred Loss] as IncurredLoss, Closed, JulianDay(datetime('now')) - JulianDay(ClaimDate) as NumberOfDaysOld FROM Company where ClaimId = ", new { ClaimId = id });
        //        if (result != null) { return Task.FromResult(result); }
        //        await connection.CloseAsync();
        //    }
        //    return null;
        //}

        //public async Task<IReadOnlyList<Company>> GetAll()
        //{
        //    using (var connection = new SqliteConnection(databaseConfig.Name))
        //    {
        //        connection.Open();
        //        var result = await connection.QuerySingleOrDefaultAsync("SELECT UCR, ClaimId, CompanyId, ClaimDate, LossDate, [Assured Name] as AssuredName, [Incurred Loss] as IncurredLoss, Closed, JulianDay(datetime('now')) - JulianDay(ClaimDate) as NumberOfDaysOld FROM Company");
        //        if (result != null) { return Task.FromResult(result); }
        //        await connection.CloseAsync();
        //        return null;
        //    }
        //}

        //public async Task<int> Update(Company claim)
        //{
        //    int updateResult = 0;
        //    using (var connection = new SqliteConnection(databaseConfig.Name))
        //    {
        //        connection.Open();

        //        await connection.ExecuteAsync("UPDATE Company SET UCR ='" + claim.UCR + "', CLAIMDATE = '" + claim.ClaimDate + "',LOSSDATE='" + claim.LossDate + "',[ASSURED NAME]='" +
        //                                                               claim.AssuredName + "',[INCURRED LOSS] ='" +
        //                                                               claim.IncurredLoss + "',CLOSED='" +
        //                                                               claim.Closed + "' WHERE CLAIMID=" + claim.ClaimId);
        //        return updateResult;
        //    }
        //}
    }
}
