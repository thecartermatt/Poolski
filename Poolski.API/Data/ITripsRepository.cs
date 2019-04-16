using System.Collections.Generic;
using System.Threading.Tasks;
using Poolski.API.Models;

namespace Poolski.API.Data
{
    public interface ITripsRepository
    {
         Task<Trip> AddTripAsync(Trip trip);

         Task<List<Trip>> GetTripsByUser(int id);

         Task<User> GetUserById(int id);

         Task<Trip> GetTripByIdAsync(int id);
    }
}