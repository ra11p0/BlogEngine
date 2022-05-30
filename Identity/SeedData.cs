using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.DbModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Identity
{
    public class SeedData
    {
        private const string ADMIN_LOGIN = "admin";
        private const string ADMIN_PASSWORD = "P@ssw0rd";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            BlogIdentityDbContext context = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<BlogIdentityDbContext>();
            if (context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();
            UserManager<User> userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<User>>();
            User user = await userManager.FindByNameAsync(ADMIN_LOGIN);
            if (user == null)
            {
                user = new User(ADMIN_LOGIN);
                user.Email = "admin@example.com";
                user.PhoneNumber = "555-1234";
                await userManager.CreateAsync(user, ADMIN_PASSWORD);
            }

        }
    }
}
