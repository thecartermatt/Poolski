using AutoMapper;
using Poolski.API.Dtos;
using Poolski.API.Models;

namespace Poolski.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Location, LocationForDropdownDto>();

            CreateMap<Vehicle, VehicleListDto>();

            
            


           
        }
    }
}