using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexts;
using Store.Application.Services.Users.Queries.GetRoles;
using Store.Application.Services.Users.Queries.GetUsers;
using Store.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();
builder.Services.AddScoped<IGetUsersService, GetUserService>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));


var app = builder.Build();

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

app.MapControllerRoute(
    name : "areas",
    pattern : "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.Run();