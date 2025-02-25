using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities.Users;

namespace Store.Persistance.Contexts;

public class DataBaseContext : DbContext
{
    public DataBaseContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserInRole> UserInRoles { get; set; }
}