using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace TaskManagementAPI.EntityFrameworkCore;

public static class TaskManagementAPIDbContextConfigurer
{
    public static void Configure(DbContextOptionsBuilder<TaskManagementAPIDbContext> builder, string connectionString)
    {
        builder.UseSqlServer(connectionString);
    }

    public static void Configure(DbContextOptionsBuilder<TaskManagementAPIDbContext> builder, DbConnection connection)
    {
        builder.UseSqlServer(connection);
    }
}
