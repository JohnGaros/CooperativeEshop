using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;



using CooperativeEshop.Core.Domain;

namespace CooperativeEshop.Persistence
{
    public class CoopEshopContext : IdentityDbContext<AppUser>
    {
        public CoopEshopContext(DbContextOptions<CoopEshopContext> options) : base(options){}

        public DbSet<CommunicationChannel> CommunicationChannels { get; set; }
        public DbSet<UserCommunicationChannel> UserCommunicationChannels { get; set; }
        public DbSet<Individual> Individuals { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Phone> Phones { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserCommunicationChannel>().HasKey(k => new { k.CommChannelID, k.UserID });
            builder.Entity<UserCommunicationChannel>().HasOne(x => x.User).WithMany(x => x.UserCommunicationChannels);
            builder.Entity<UserCommunicationChannel>().HasOne(x => x.CommChannel).WithMany(x => x.UserCommunicationChannels);

            builder.Entity<Individual>().HasKey(x => x.UserID);
            builder.Entity<Individual>().HasOne(u => u.User).WithOne(i => i.Individual).IsRequired();

            builder.Entity<Organization>().HasKey(x => x.UserID);
            builder.Entity<Organization>().HasOne(u => u.User).WithOne(i => i.Organization).IsRequired();

            builder.Entity<Phone>().HasKey(x => x.CommChannelID);
            builder.Entity<Phone>().HasOne(x => x.CommChannel).WithOne(x => x.Phone).IsRequired();


            base.OnModelCreating(builder);
        }
    }
}
