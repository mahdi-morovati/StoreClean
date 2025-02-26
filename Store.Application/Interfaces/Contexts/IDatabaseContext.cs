using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities.Users;

namespace Store.Application.Interfaces.Contexts;

public interface IDatabaseContext
{
    DbSet<User> Users { get; set; }
    DbSet<Role> Roles { get; set; }
    DbSet<UserInRole> UserInRoles { get; set; }
    
}