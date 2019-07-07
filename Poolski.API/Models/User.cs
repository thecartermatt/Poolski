using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Poolski.API.Models
{
    public class User 
    {
   
        public int Id { get; set; } 

        public string Username { get; set; }
       
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
       public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public virtual ICollection<UserTrip> UserTrips { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }

    }
}