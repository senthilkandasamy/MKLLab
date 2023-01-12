using Markel.Claims.Service.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Markel.Claims.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            this._companyRepository = companyRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Markel.Claims.Service.Data.Company>> Get()
        {
            var companies = await _companyRepository.GetAll();

            return companies;
        }

        [HttpGet("{CompanyId}")]
        public async Task<IActionResult> Get(int CompanyId)
        {
            var companyFetched = await _companyRepository.Get(CompanyId);

            if (companyFetched == null)
            {
                return NotFound();
            }

            return Ok(companyFetched);
        }

        [HttpGet("~/GetAllClaims/{CompanyId}")]
        public async Task<IActionResult> GetAllClaims(int CompanyId)
        {
            var companyFetched = await _companyRepository.Get(CompanyId);

            if (companyFetched == null)
            {
                return NotFound();
            }

            return Ok(companyFetched);
        }

    }
}
