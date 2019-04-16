using System.ComponentModel.DataAnnotations;

namespace Poolski.API.Dtos
{
    public class UserForRegisterDto
    {

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify a password between 4 and 8 characters")]
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        
    }
}