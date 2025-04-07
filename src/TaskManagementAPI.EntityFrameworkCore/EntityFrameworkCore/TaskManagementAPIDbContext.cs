using Abp.Zero.EntityFrameworkCore;
using TaskManagementAPI.Authorization.Roles;
using TaskManagementAPI.Authorization.Users;
using TaskManagementAPI.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskManagementAPI.Dutys;

namespace TaskManagementAPI.EntityFrameworkCore;

public class TaskManagementAPIDbContext : AbpZeroDbContext<Tenant, Role, User, TaskManagementAPIDbContext>
{
    public DbSet<Duty> Duties { get; set; }
    public DbSet<UserOtp> UserOtps { get; set; }

    /* Define a DbSet for each entity of the application */

    public TaskManagementAPIDbContext(DbContextOptions<TaskManagementAPIDbContext> options)
        : base(options)
    {
    }
}
