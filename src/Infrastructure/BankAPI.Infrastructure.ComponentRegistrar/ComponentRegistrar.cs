using AutoMapper;
using BankAPI.Application.AppServices.Contexts.User.Repositories;
using BankAPI.Application.AppServices.Contexts.User.Services;
using BankAPI.Infrastructure.ComponentRegistrar.Mapper;
using BankAPI.Infrastructure.DataAccess.Contexts.Users.Repositories;
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

        return serviceCollection;
    }

    private static void ConfigAutoMapper(IMapperConfigurationExpression configuration)
    {
        configuration.AddProfile<UserProfile>();
    }
}