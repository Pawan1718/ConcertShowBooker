using ConcertShowBooking.Infrastructure;
using ConcertShowBooking_Entities;
using ConcertShowBooking_Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertShowBooking_Repositories.Implementations
{
    public class DbInitial : IDbInitial
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public DbInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public Task Seed()
        {
            if (!_roleManager.RoleExistsAsync(GlobalConfiguration.Admin_Role).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(GlobalConfiguration.Admin_Role)).GetAwaiter().GetResult(); ;
                var user = new ApplicationUser
                {
                    Email = "admin@gmail.com",
                    UserName = "admin@gmail.com"
                };
                _userManager.CreateAsync(user, "Admin@123").GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(user, GlobalConfiguration.Admin_Role).GetAwaiter().GetResult();
            }
            return Task.CompletedTask;
        }
    }
}
