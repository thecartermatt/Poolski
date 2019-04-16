using System;
using System.Collections.Generic;

namespace Poolski.API.Models
{
    public class Trip
    {
        
        public int Id { get; set; }
        public Location FromLocation { get; set; }
        public Location ToLocation { get; set; }

        public DateTime DepatureDateTime { get; set; }

        public User HostUser { get; set; }
        


        public decimal Cost { get; set; }

        public virtual ICollection<UserTrip> UserTrips { get; set; }
        public Vehicle Vehicle { get; set; }
        public int Capacity { get; set; }

        
    }
}