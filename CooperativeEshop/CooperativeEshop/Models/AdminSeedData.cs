using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CooperativeEshop.Models
{
    public class AdminSeedData
    {
        private const string adminUser = "JohnG";
        private const string adminPassword = "@Polo1234";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            UserManager<IdentityUser> userManager = app.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser user = await userManager.FindByIdAsync(adminUser);
            if(user == null)
            {
                user = new IdentityUser("JohnG");
                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}
