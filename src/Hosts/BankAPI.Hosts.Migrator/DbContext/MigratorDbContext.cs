using BankAPI.Infrastructure.DataAccess.DbContexts;

namespace BankAPI.Hosts.Migrator.DbContext;

using BankAPI.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Контекст для мигратора
/// </summary>
public class MigratorDbContext : ApplicationDbContext
{
    public MigratorDbContext(DbContextOptions options) : base(options)
    {
    }
}