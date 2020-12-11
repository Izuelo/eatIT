using System.ComponentModel.DataAnnotations;

namespace eatIT.Database.Dtos
{
    public class UserRegisterDto
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        [StringLength(24, MinimumLength =4, ErrorMessage = "You must specify a password between 4 and 24 characters.")]
        public string Password { get; set; }
    }
}