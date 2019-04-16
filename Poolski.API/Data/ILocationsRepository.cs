using System.Collections.Generic;
using System.Threading.Tasks;
using Poolski.API.Models;

namespace Poolski.API.Data
{
    public interface ILocationsRepository
    {
          Task<List<Location>> GetLocations();

          Task<Location> GetLocationById(int id);

        List<Location> GetLocationsNotAsync();
 
    }
}