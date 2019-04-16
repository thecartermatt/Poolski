using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Poolski.API.Models;

namespace Poolski.API.Data
{
    public class VehiclesRepository : IVehiclesRepository
    {
        private readonly DataContext _context;

        public VehiclesRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Vehicle> AddVehicle(Vehicle vehicle)
        {
          await _context.Vehicles.AddAsync(vehicle);
          await _context.SaveChangesAsync();
          return vehicle;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
            return user;
        }

        public async Task<List<Vehicle>> GetVehiclesByUser(int id)
        {
            var vehicles = await _context.Vehicles.Where(v => v.User.Id == id).ToListAsync();
            return vehicles;

        }

        public async Task<Vehicle> GetVehicleById(int id)
        {
            var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
            return vehicle;
        }
    }
}