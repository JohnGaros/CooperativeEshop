using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace CooperativeEshop.Models.ViewModels
{
    public class AdminRolesViewModel
    {
        public IQueryable<IdentityRole> Roles { get; set; }
        public string Name { get; set; }
    }
}
