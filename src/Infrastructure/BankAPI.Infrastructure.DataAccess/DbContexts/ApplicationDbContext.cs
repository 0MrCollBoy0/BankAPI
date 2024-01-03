using System.Reflection;
using BankAPI.Infrastructure.DataAccess.Contexts.Users.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BankAPI.Infrastructure.DataAccess.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }
    
    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), t => t.GetInterfaces().Any(i =>
            i.IsGenericType &&
            i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}