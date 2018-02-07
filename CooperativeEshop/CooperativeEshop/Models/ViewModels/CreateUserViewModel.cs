using CooperativeEshop.Core.Domain;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CooperativeEshop.Models.ViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        public AppUser User { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public IdentityRole Role { get; set; }
    }
}
