using Microsoft.AspNetCore.Identity;
using SimCom.Core.Constants;
using SimCom.Core.DomainModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCom.Services.DummyDataService
{
    public class DummyUserCreator
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public DummyUserCreator(UserManager<User> userManager,
                                RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        private async Task CreateUserRoleIfNotExists()
        {
            var sysAdminRoleExists = await _roleManager.FindByNameAsync(Roles.SysAdmin);
            if (await _roleManager.FindByNameAsync(Roles.SysAdmin) == null)
            {
                var role = new Role(Roles.SysAdmin);
                await _roleManager.CreateAsync(role);
            }

            if (await _roleManager.FindByNameAsync(Roles.Admin) == null)
            {
                var role = new Role(Roles.Admin);
                await _roleManager.CreateAsync(role);
            }

            if (await _roleManager.FindByNameAsync(Roles.Customer) == null)
            {
                var role = new Role(Roles.Customer);
                await _roleManager.CreateAsync(role);
            }
        }
        public async Task CreateDummyUsersForEachRole()
        {
            await CreateUserRoleIfNotExists();

            if ((await _userManager.GetUsersInRoleAsync(Roles.SysAdmin)).Count == 0)
            {
                var sysAdminUser = new User
                {
                    Email = "demo@sysadmin.com",
                    UserName = "sysAdminDemo"
                };

                await _userManager.CreateAsync(sysAdminUser, "Demo123*");

                await _userManager.AddToRoleAsync(sysAdminUser, Roles.SysAdmin);
            }

            if ((await _userManager.GetUsersInRoleAsync(Roles.Admin)).Count == 0)
            {
                var adminUser = new User
                {
                    Email = "demo@admin.com",
                    UserName = "adminDemo"
                };

                await _userManager.CreateAsync(adminUser, "Demo123*");

                await _userManager.AddToRoleAsync(adminUser, Roles.Admin);
            }

            if ((await _userManager.GetUsersInRoleAsync(Roles.Customer)).Count == 0)
            {
                var customerUser = new User
                {
                    Email = "demo@customer.com",
                    UserName = "customerDemo"
                };

                await _userManager.CreateAsync(customerUser, "Demo123*");

                await _userManager.AddToRoleAsync(customerUser, Roles.Customer);
            }
        }
    }
}
