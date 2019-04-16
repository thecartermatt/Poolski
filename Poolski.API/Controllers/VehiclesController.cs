using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Poolski.API.Data;
using Poolski.API.Dtos;
using Poolski.API.Models;

namespace Poolski.API.Controllers
{    
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class VehiclesController : ControllerBase
    {
        private readonly IVehiclesRepository _repo;
        private readonly IMapper _mapper;
        public VehiclesController(IVehiclesRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> AddVehicle(Vehicle vehicle)
        {
            if(vehicle.User.Id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            return Unauthorized();
            var userToPost = await _repo.GetUserById(vehicle.User.Id);
            vehicle.User = userToPost;
            var newVehicle = await _repo.AddVehicle(vehicle);
            return Ok(vehicle);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehiclesByUser(int id)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            return Unauthorized();
                     var vehicles = await _repo.GetVehiclesByUser(id);
            var vehiclesForList = _mapper.Map<IEnumerable<VehicleListDto>>(vehicles);
   
         
            return Ok(vehiclesForList);
        }

  
        

    }
}