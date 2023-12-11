using AutoMapper;
using BankAPI.Application.AppServices.Contexts.Bill.Repositories;
using BankAPI.Application.AppServices.Contexts.Bill.Services;
using BankAPI.Application.AppServices.Contexts.User.Repositories;
using BankAPI.Application.AppServices.Contexts.User.Services;
using BankAPI.Infrastructure.ComponentRegistrar.Mapper;
using BankAPI.Infrastructure.DataAccess.Common.Repositories;
using BankAPI.Infrastructure.DataAccess.Contexts.Bill.Repositories;
using BankAPI.Infrastructure.DataAccess.Contexts.Users.Repositories;
using BankAPI.Infrastructure.DataAccess.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankAPI.Infrastructure.ComponentRegistrar;

public static class ComponentRegistrar
{
    public static IServiceCollection AddServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {

        serviceCollection.AddAutoMapper(ConfigAutoMapper);
        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IBillService, BillService>();
        serviceCollection.AddScoped<IBillRepository, BillRepository>();
        serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        serviceCollection.AddScoped<DbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        serviceCollection.AddDbContext<ApplicationDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        return serviceCollection;
    }

    private static void ConfigAutoMapper(IMapperConfigurationExpression configuration)
    {
        configuration.AddProfile<UserProfile>();
        configuration.AddProfile<BillProfile>();
    }
}