using System.Collections.Generic;
using System.Threading.Tasks;
using Poolski.API.Models;

namespace Poolski.API.Data
{
    public interface IVehiclesRepository
    {
         Task<Vehicle> AddVehicle(Vehicle vehicle);
         Task<User> GetUserById(int id);
         Task<List<Vehicle>> GetVehiclesByUser(int id);

         Task<Vehicle> GetVehicleById(int id);
    }
}