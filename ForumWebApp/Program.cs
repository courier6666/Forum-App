using ForumWebApp.Data;
using ForumWebApp.Interfaces;
using ForumWebApp.Models;
using ForumWebApp.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IForumThreadRepository, ForumThreadRepository>();
builder.Services.AddScoped<IThreadPostRepository, ThreadPostRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IVoteRepository, VoteRepository>();

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();


var app = builder.Build();

Seed.SeedData(app);
//Seed.SeedUsersAndRolesAsync(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "postDetail",
        pattern: "ForumThread/Detail/{threadId:int}/ThreadPost/Detail/{postId:int}",
        defaults: new { controller = "ThreadPost", action = "Detail" });

    endpoints.MapControllerRoute(
        name: "postIndex",
        pattern: "ForumThread/Detail/{threadId:int}/ThreadPost",
        defaults: new { controller = "ThreadPost", action = "Index" }
        );

    endpoints.MapControllerRoute(
        name: "postCreate",
        pattern: "ForumThread/Detail/{threadId:int}/ThreadPost/Create",
        defaults: new {controller = "ThreadPost", action = "Create"}
        );
});

app.Run();
