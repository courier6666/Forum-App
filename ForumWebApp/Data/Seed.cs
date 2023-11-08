using ForumWebApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Security.Policy;
using System.Threading;

namespace ForumWebApp.Data
{
    public static class Seed
    {
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                
            }
        }
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScoop = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScoop.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                if (!context.ForumThreads.Any())
                {
                    var thread1 = new ForumThread()
                    {
                        Title = "Gaming",
                        Description = "Just gaming",
                    };

                    var thread2 = new ForumThread()
                    {
                        Title = "Programming",
                        Description = "Knowledge overflow",
                    };

                    context.ForumThreads.AddRange(thread1, thread2);
                    context.SaveChanges();

                    var post1 = new ThreadPost()
                    {
                        Title = "Valorant new update is weird?",
                        Content = "Some long text about valorant update",
                        ThreadId = thread1.Id,
                        CreateAtUtc = DateTime.UtcNow
                    };

                    var post2 = new ThreadPost()
                    {
                        Title = "C++ and its pointers",
                        Content = "Some long text about c++",
                        ThreadId = thread2.Id,
                        CreateAtUtc = DateTime.UtcNow
                    };

                    context.ThreadPosts.AddRange(post1, post2);
                    context.SaveChanges();
                }
            }
        }
    }
}
