using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SAF.Extensions;
using SAF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAF.DAL
{
    public class DbInitializer
    {
        public async static Task Seed(Db_Saf _context, UserManager<AppUser> userManager,
                                                                   RoleManager<IdentityRole> roleManager,
                                                                   IConfiguration configuration)
        {
            await _context.Database.EnsureCreatedAsync();
            if (!await roleManager.RoleExistsAsync(StaticUsers.Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(StaticUsers.Admin));
            }

            if (await userManager.FindByNameAsync("Admin") == null)
            {
                var admin = new AppUser()
                {
                    Email = "ElchinSh@code.edu.az",
                    UserName = "admin"
                };

                var result = await userManager.CreateAsync(admin, "Admin123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, StaticUsers.Admin);
                }
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, StaticUsers.Admin);
                }
            }
        }
    }
}
