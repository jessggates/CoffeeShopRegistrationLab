using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShopRegistration.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(50)]
        [MinLength(8,ErrorMessage ="Password must be at least 8 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match. Please verify your password and confirm." )]
        public string ConfirmPassword { get; set; }

        [Display(Name = "What is your preferred location? ")]
        public string? LocationName { get; set; }

        public bool MarketingOptIn {  get; set; }

        public int? CategoryId { get; set; } 

    }
}
