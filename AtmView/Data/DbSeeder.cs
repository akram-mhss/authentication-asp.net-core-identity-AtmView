using AtmView.Constants;
using Microsoft.AspNetCore.Identity;

namespace AtmView.Data
{
    public class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
            //Seed Roles
            var userManager = service.GetService<UserManager<ApplicationData>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));

            // creating admin

            var user = new ApplicationData
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                Name = "Akram",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var userInDb = await userManager.FindByEmailAsync(user.Email);
            if (userInDb == null)
            {
                await userManager.CreateAsync(user, "Root1234@");
                await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
            }
        }
    }
}
