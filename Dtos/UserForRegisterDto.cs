using System.ComponentModel.DataAnnotations;

namespace databasePractice.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "You need a password between 8~64 characters")]
        public string Password { get; set; }
    }
}