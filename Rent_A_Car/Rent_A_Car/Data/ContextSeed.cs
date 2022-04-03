
using Microsoft.AspNetCore.Identity;
using Rent_A_Car.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Rent_A_Car.Data
{
    
    public static class ContextSeed
    {
        public static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "admin1",
                Email = "admin@gmail.com",
                FirstName = "Pavel",
                LastName = "Panev",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123456Pa.");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.User.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Admin.ToString());
                }

            }
        }
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles          
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.User.ToString()));
        }

        internal static Task SeedAdminAsync(object userManager, object roleManager)
        {
            throw new NotImplementedException();
        }
    }
    
}
        

