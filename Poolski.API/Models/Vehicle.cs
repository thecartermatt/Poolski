using System.ComponentModel.DataAnnotations;

namespace Poolski.API.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public int Capacity { get; set; }
         [Required]
        public string Name { get; set; }
    }
}