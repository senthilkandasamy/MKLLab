using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Markel.Claims.Service.Data.Repository
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<IReadOnlyList<Claims>> GetAllClaimsOfCompany(int CompanyId);
    }
}
