using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using System.Security.Claims;
using Poolski.API.Data;
using AutoMapper;
using Poolski.API.Dtos;
using System.Collections.Generic;

namespace Poolski.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationsRepository _repo;
        private readonly IMapper _mapper;
        public LocationsController(ILocationsRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }


        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            var locations = await _repo.GetLocations();
            var locationsToReturn = _mapper.Map<IEnumerable<LocationForDropdownDto>>(locations);

            return Ok(locationsToReturn);
        }

    }
}