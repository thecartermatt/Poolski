using System;
using System.ComponentModel.DataAnnotations;

namespace Poolski.API.Dtos
{
    public class TripAddDto
    {
        [Required]
        public int? FromLocationId { get; set; }
           [Required]
        public int? ToLocationId { get; set; }
           [Required]
        public int? VehicleId { get; set; }
           [Required]
        public int? HostUserId { get; set; }
           [Required]
        public DateTime? DepartureDateTime  { get; set; }

   [Required]
        public decimal? Cost { get; set; }
    }
}