using AdAstra.DataAccess.Constants;
using AdAstra.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdAstra.DataAccess.Data
{
    public class ApplicationDbSeeder
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ApplicationDbSeeder(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            var roles = new List<string>() { "Admin", "Moderator", Authorization.Roles.User.ToString() };

            foreach (var item in roles)
            {
                var exists = await _roleManager.RoleExistsAsync(item);
                if (!exists)
                {
                    await _roleManager.CreateAsync(new IdentityRole(item));
                }
            }
        }
    }
}
