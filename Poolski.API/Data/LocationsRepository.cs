using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Poolski.API.Models;

namespace Poolski.API.Data
{
    public class LocationsRepository : ILocationsRepository
    {
        private readonly DataContext _context;
        public LocationsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Location> GetLocationById(int id)
        {
           var location = await _context.Locations.FirstOrDefaultAsync(l => l.Id ==id);
           return location;
        }



        public async Task<List<Location>> GetLocations()
        {
           var locations = await _context.Locations.Include(l => l.LocationType).ToListAsync();
           return locations;
        }

        public List<Location> GetLocationsNotAsync()
        {
            var locations = _context.Locations.ToList();
            return locations;
        }
    }
}