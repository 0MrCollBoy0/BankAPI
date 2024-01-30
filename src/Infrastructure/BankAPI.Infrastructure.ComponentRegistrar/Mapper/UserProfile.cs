using AutoMapper;
using BankAPI.Contracts.Contexts.User;
using BankAPI.Domain.User;

namespace BankAPI.Infrastructure.ComponentRegistrar.Mapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>()
            .ForMember(d => d.Email, map => map.MapFrom(s => s.Email));

        CreateMap<CreateUserDto, User>()
            .ForMember(u => u.CreatedAt,
                map =>
                    map.MapFrom(s => DateTime.UtcNow));
        CreateMap<UpdateUserDto, User>();
        CreateMap<User, ShortUserDto>();

    }
}