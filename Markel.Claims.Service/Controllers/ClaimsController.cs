using Markel.Claims.Service.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


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

        [HttpGet("{id}")]
        public async Task<ActionResult<Markel.Claims.Service.Data.Claims>> Get(int ClaimId) 
        {
            var claim = await _claimsRepository.Get(ClaimId);

            return claim;
        }

        [HttpGet]
        public async Task<IEnumerable<Markel.Claims.Service.Data.Claims>> Get()
        {
            var claims = await _claimsRepository.GetAll();

            return claims;
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(Markel.Claims.Service.Data.Claims newClaim)
        {
            if(!TryValidateModel(newClaim,nameof(Markel.Claims.Service.Data.Claims)))
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }

            var inserted = await _claimsRepository.Add(newClaim);
            if(inserted <= 0)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
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
    