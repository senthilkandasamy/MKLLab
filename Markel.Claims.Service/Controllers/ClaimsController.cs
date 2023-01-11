using Markel.Claims.Service.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;

namespace Markel.Claims.Service.Controllers
{
    [Route("api/claims")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly IGenericRepository<Markel.Claims.Service.Data.Claims> _claimsRepository;

        public ClaimsController(IGenericRepository<Markel.Claims.Service.Data.Claims> claimsRepository)
        {
            this._claimsRepository = claimsRepository;
        }

        [HttpGet("{ClaimId}")]
        public async Task<IActionResult> Get(int ClaimId) 
        {
            var claimFetched = await _claimsRepository.Get(ClaimId);

            if(claimFetched == null)
            {
                return NotFound();
            }

            return Ok(claimFetched);
        }

        [HttpGet]
        public async Task<IEnumerable<Markel.Claims.Service.Data.Claims>> Get()
        {
            var claims = await _claimsRepository.GetAll();

            return claims;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Markel.Claims.Service.Data.Claims newClaim)
        {
            if(!TryValidateModel(newClaim,nameof(Markel.Claims.Service.Data.Claims)))
            {
                return new ValidationFailedResult(base.ModelState);
            }

            var inserted = await _claimsRepository.Add(newClaim);

            return Ok(inserted);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdateClaim(Markel.Claims.Service.Data.Claims newClaim)
        {
            if (!TryValidateModel(newClaim, nameof(Markel.Claims.Service.Data.Claims)))
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }

            var inserted = await _claimsRepository.Update(newClaim);
            if (inserted <= 0)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
    }
}
    