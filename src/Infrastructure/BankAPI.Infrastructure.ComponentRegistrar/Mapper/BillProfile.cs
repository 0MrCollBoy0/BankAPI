using AutoMapper;
using BankAPI.Contracts.Contexts.Bill;
using BankAPI.Domain.Bill;
using BankAPI.Domain.User;

namespace BankAPI.Infrastructure.ComponentRegistrar.Mapper;

public class BillProfile : Profile
{
    public BillProfile()
    {
        CreateMap<Bill, BillDto>();
        CreateMap<CreateBillDto, Bill>()
            .ForMember(b => b.CreatedAt,
                map =>
                    map.MapFrom(src => DateTime.UtcNow));
    }
}