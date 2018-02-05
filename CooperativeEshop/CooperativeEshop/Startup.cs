using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CooperativeEshop.Persistence.Repositories;
using CooperativeEshop.Core.Domain;
using CooperativeEshop.Core.Repositories;
using CooperativeEshop.Core;

using CooperativeEshop.Persistence;


namespace CooperativeEshop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration config)
        {
            Configuration = config;    
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CoopEshopContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<CoopEshopContext>()
                .AddDefaultTokenProviders();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IInventoryItemRepository, InventoryItemRepository>();
            services.AddTransient<IPriceComponentRepository, PriceComponentRepository>();
            services.AddTransient<IBasePriceComponentRepository, BasePriceComponentRepository>();
            services.AddTransient<ISurchargePriceComponentRepository, SurchargePriceComponentRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddMvc();
        }

        
        public void Configure(IApplicationBuilder app)
        {
            
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            //AdminSeedData.EnsurePopulated(app);
        }
        
    }
}
