using System.ComponentModel.DataAnnotations;

namespace Poolski.API.Models
{
    public class Location
    {
        public int Id { get; set; }

        [Required]
        public LocationType LocationType { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        
    }
}