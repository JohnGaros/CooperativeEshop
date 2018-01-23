using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CooperativeEshop.Core.Domain;

namespace CooperativeEshop.Persistence
{
    public class CoopEshopContext : IdentityDbContext<AppUser>
    {
        public CoopEshopContext(DbContextOptions<CoopEshopContext> options) : base(options)
        {
                
        }
    }
}
