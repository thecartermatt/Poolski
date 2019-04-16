using System;
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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TripsController : ControllerBase
    {
        private readonly ITripsRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILocationsRepository _lrepo;
        private readonly IVehiclesRepository _vrepo;

        public TripsController(ITripsRepository repo, IMapper mapper, ILocationsRepository lrepo,
        IVehiclesRepository vrepo)
        {
            _repo = repo;
            _mapper = mapper;
            _lrepo = lrepo;
            _vrepo = vrepo;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetTripsByUser(int userId)
        {
            if(userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            return Unauthorized();
            var trips = await _repo.GetTripsByUser(userId);
            return Ok(trips);
        }

        [HttpGet("{id}", Name="Trip")]
        public async Task<IActionResult> GetTripById(int id)
        {
            var trip = await _repo.GetTripByIdAsync(id);
            if (trip.HostUser.Id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
             return Unauthorized();
            return Ok(trip);
        }

        [HttpPost]
        public async Task<IActionResult> AddTrip(TripAddDto trip)
        {
            if(trip.HostUserId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                     return Unauthorized();
            Trip tripToAdd = new Trip();

            tripToAdd.FromLocation = await _lrepo.GetLocationById((int)trip.FromLocationId);
            tripToAdd.ToLocation = await _lrepo.GetLocationById((int)trip.ToLocationId);
            tripToAdd.Vehicle = await _vrepo.GetVehicleById((int)trip.VehicleId);
            tripToAdd.HostUser = await _repo.GetUserById((int)trip.HostUserId);
            tripToAdd.Cost = (decimal)trip.Cost;
            tripToAdd.Capacity = tripToAdd.Vehicle.Capacity;
            tripToAdd.DepatureDateTime = (DateTime)trip.DepartureDateTime;

            tripToAdd = await _repo.AddTripAsync(tripToAdd);
          

            return CreatedAtRoute("Trip", new { id = tripToAdd.Id}, tripToAdd);
        }
        


    }
}