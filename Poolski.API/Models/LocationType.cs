using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Poolski.API.Models
{
    public class LocationType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }


    }
}