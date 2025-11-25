using System.ComponentModel.DataAnnotations;

namespace finalProject.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(200, ErrorMessage = "Email cannot exceed 200 characters")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
}

