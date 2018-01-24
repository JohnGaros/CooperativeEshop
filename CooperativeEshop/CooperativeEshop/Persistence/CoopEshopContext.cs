using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using CooperativeEshop.Core.Domain;

namespace CooperativeEshop.Persistence
{
    public class CoopEshopContext : IdentityDbContext<AppUser>
    {
        public CoopEshopContext(DbContextOptions<CoopEshopContext> options) : base(options){}

        public DbSet<CommunicationChannel> CommunicationChannels { get; set; }
        public DbSet<UserCommunicationChannel> UserCommunicationChannels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserCommunicationChannel>().HasKey(k => new
            {
                k.CommChannelID, k.UserID
            });


            base.OnModelCreating(builder);
        }
    }
}
