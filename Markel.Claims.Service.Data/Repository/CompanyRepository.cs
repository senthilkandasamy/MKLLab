using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Markel.Claims.Service.Data.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DatabaseConfig databaseConfig;
        public CompanyRepository(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        
        public async Task<int> Add(Company newCompany)
        {
            int inserted = 0;
            using (var connection = new SqliteConnection(databaseConfig.Name))
            {
                connection.Open();
                await connection.ExecuteAsync("INSERT INTO Company(CompanyName , Address1 , Address2 , Address3 , PostCode , Country , IsActive , InsuranceEndDate) values ('" + newCompany.CompanyName + "','" + newCompany.Address1 + "','" +
                                                                       newCompany.Address2 + "','" +
                                                                       newCompany.Address3 + "','" +
                                                                       newCompany.PostCode + "','" +
                                                                       newCompany.Country + "','" +
                                                                       newCompany.IsActive + "','" +
                                                                       newCompany.InsuranceEndDate + "','" +
                                                                       ")");
                inserted++;
                return inserted;
            }

        }


        public async Task<Company> Get(int id)
        {

            using (var connection = new SqliteConnection(databaseConfig.Name))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Company> ("SELECT Id ,Name , Address1 ,Address2 ,Address3 ,Postcode ,Country ,Active ,InsuranceEndDate From Company INNER JOIN Claims on Company.Id = Claims.CompanyId WHERE Company.Id = @CompanyId", new { CompanyId = id });
                if (result != null) { return result; }
            }
            return null;
        }

        public async Task<IReadOnlyList<Company>> GetAll()
        {
            using (var connection = new SqliteConnection(databaseConfig.Name))
            {
                connection.Open();
                var result = await connection.QueryAsync<Company>("SELECT Id , CompanyName , Address1 , Address2 , Address3 , PostCode , Country , IsActive , InsuranceEndDate FROM Company");
                if (result != null) { return result.ToList(); }
                return null;
            }
        }

        public async Task<IReadOnlyList<Claims>> GetAllClaimsOfCompany(int companyId)
        {
            using (var connection = new SqliteConnection(databaseConfig.Name))
            {
                connection.Open();
                var result = await connection.QueryAsync<Claims> ("SELECT UCR, rowId, CompanyId, ClaimDate, LossDate, [Assured Name] as AssuredName, [Incurred Loss] as IncurredLoss, Closed FROM Claims INNER JOIN Company on Company.Id = Claims.CompanyId WHERE Company.Id = @CompanyId ", new { CompanyId = companyId });
                if (result != null) { return result.ToList(); }
                return null;
            }
        }

        public async Task<int> Update(Company entity)
        {
            int updateResult = 0;
            using (var connection = new SqliteConnection(databaseConfig.Name))
            {
                connection.Open();
                await connection.ExecuteAsync("UPDATE Company SET CompanyName ='" + entity.CompanyName + "', Address1= '" + entity.Address1+ "',Address2='" + entity.Address2 + "', Address3='" + entity.Address3  + "',PostCode ='" + entity.PostCode + "', Country='" + entity.Country + "' WHERE Id=" + entity.Id);
                return updateResult;
            }
        }
    }
}
