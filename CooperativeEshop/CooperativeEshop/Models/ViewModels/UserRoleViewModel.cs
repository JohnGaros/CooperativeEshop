using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using CooperativeEshop.Core.Domain;

namespace CooperativeEshop.Models.ViewModels
{
    public class UserRoleViewModel
    {
        public IdentityRole Role { get; set; }
        public AppUser User { get; set; }
        
    }
}
