using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CooperativeEshop.Models.ViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public IdentityRole Role = new IdentityRole
        {
            Name = "Customer"
        };
    }
}
