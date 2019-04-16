using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Poolski.API.Models;

namespace Poolski.API.Data
{
    public class TripsRepository : ITripsRepository
    {
        private readonly DataContext _context;

        public TripsRepository(DataContext context)
        {
           _context= context;

        }
        public async Task<Trip> AddTripAsync(Trip trip)
        {
          await _context.Trips.AddAsync(trip);
          await _context.SaveChangesAsync();
          return trip;
        }

        public async Task<Trip> GetTripByIdAsync(int id)
        {
            var trip = await _context.Trips.Include(t => t.FromLocation)
            .Include(t => t.ToLocation)
            .Include(t =>t.HostUser)
            .Include(t => t.Vehicle).FirstOrDefaultAsync(t => t.Id == id);
  
            return trip;
        }

        public async Task<List<Trip>> GetTripsByUser(int id)
        {
            var trips = await _context.Trips
            .Where(t => t.HostUser.Id == id)
            .Include(t => t.FromLocation)
            .Include(t => t.ToLocation)
            .Include(t => t.Vehicle)
            .ToListAsync();
            return trips;
        }

        public async Task<User> GetUserById(int id)
        {
                var user = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
            return user;
        }
    }
}