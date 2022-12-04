using System.ComponentModel.DataAnnotations;

namespace Bluedit.Dtos
{
    public class UserRegisterDto
    {
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        [MaxLength(255)]
        public string Password { get; set; } = string.Empty;
    }
}
