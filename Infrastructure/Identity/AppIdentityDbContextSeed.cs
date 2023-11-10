using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task<AppUser> SeedUsersAsync()
        {
                var user = new AppUser
                {
                    DisplayName = "Bob",
                    Email = "Bob@test.com",
                    UserName = "Bob@test.com"
                    //Address = new Address
                    //{
                    //    FirstName = "Bob",
                    //    LastName = "Bobbity",
                    //    Street = "10 The Street",
                    //    City = "New York",
                    //    State = "NY",
                    //    ZipCode = "937158"
                    //}, 
                };

                PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();
                user.PasswordHash = ph.HashPassword(user, "Pa$$w0rd");

            return user;
        }

    }
}
