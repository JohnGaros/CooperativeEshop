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
        public DbSet<Email> Emails { get; set; }
        public DbSet<PhysicalAddress> PhysicalAddresses { get; set; }
        public DbSet<CommunicationChannelType> CommunicationChannelTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SupplierProduct> SupplierProducts { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductCategoryClassification> ProductCategoryClassifications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserCommunicationChannel>().HasKey(k => new { k.CommChannelID, k.UserID });
            builder.Entity<UserCommunicationChannel>().HasOne(x => x.User).WithMany(x => x.UserCommunicationChannels).HasForeignKey(x => x.UserID).IsRequired();
            builder.Entity<UserCommunicationChannel>().HasOne(x => x.CommChannel).WithMany(x => x.UserCommunicationChannels).HasForeignKey(x => x.CommChannelID).IsRequired();

            builder.Entity<Individual>().HasKey(x => x.UserID);
            builder.Entity<Individual>().HasOne(u => u.User).WithOne(i => i.Individual).IsRequired();

            builder.Entity<Organization>().HasKey(x => x.UserID);
            builder.Entity<Organization>().HasOne(u => u.User).WithOne(i => i.Organization).IsRequired();

            builder.Entity<Phone>().HasKey(x => x.CommChannelID);
            builder.Entity<Phone>().HasOne(x => x.CommChannel).WithOne(x => x.Phone).IsRequired();

            builder.Entity<Email>().HasKey(x => x.CommChannelID);
            builder.Entity<Email>().HasOne(x => x.CommChannel).WithOne(x => x.Email).IsRequired();

            builder.Entity<PhysicalAddress>().HasKey(x => x.CommChannelID);
            builder.Entity<PhysicalAddress>().HasOne(x => x.CommChannel).WithOne(x => x.PhysicalAddress).IsRequired();

            builder.Entity<CommunicationChannelType>().HasKey(x => x.ID);
            builder.Entity<CommunicationChannel>().HasOne(x => x.Type).WithMany(x => x.CommChannels).IsRequired();

            builder.Entity<SupplierProduct>().HasKey(x => new { x.ProductID, x.UserID });
            builder.Entity<SupplierProduct>().HasOne(x => x.Seller).WithMany(x => x.SupplierProduct).HasForeignKey(x => x.UserID).IsRequired();

            builder.Entity<ProductCategoryClassification>().HasKey(x => new { x.CategoryID, x.ProductID });
            builder.Entity<ProductCategoryClassification>().HasOne(x => x.Product).WithMany(x => x.ProductCategoryClassifications).IsRequired().HasForeignKey(x => x.ProductID).IsRequired();
            builder.Entity<ProductCategoryClassification>().HasOne(x => x.Category).WithMany(x => x.ProductCategoryClassifications).IsRequired().HasForeignKey(x => x.CategoryID).IsRequired();
            

            base.OnModelCreating(builder);
        }
    }
}
